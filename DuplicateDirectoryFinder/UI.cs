namespace DDFinder.UI
{
	using Services.DuplicateScanner;

	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Windows.Forms;

	public static class Helpers
	{
		public static Control[] GetExplorerControls(Main form, Control container, DirectoryList directoryList, string fileHash)
		{
			// room for buttons and controls
			var boxTopMargin = 23;
			var diffControlMargin = 110;

			// control collection to add
			var explorerControls = new List<Control>();

			// duplicate file information
			var allDuplicates = directoryList.ScanInfo.DuplicateFiles.GetDuplicatesByHash;
			var duplicateFiles = allDuplicates.First(d => d.Key == fileHash).Value;

			// for each file duplicate,
			// create a listbox with buttons
			var fileIndex = 0;
			foreach (File f in duplicateFiles)
			{
				var newBox = new ListBox();
				newBox.Name = "explorerControl-" + Services.IO.Helpers.MakeSafe(f.Path);
				newBox.BorderStyle = BorderStyle.None;
				newBox.Width = container.Width;
				newBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				newBox.Height = (int)System.Math.Floor(container.Height / (float)duplicateFiles.Count) - boxTopMargin;
				newBox.Top = fileIndex * newBox.Height + (fileIndex + 1) * boxTopMargin;
				newBox.SelectionMode = SelectionMode.MultiSimple;
				newBox.IntegralHeight = false;
				newBox.MultiColumn = true;

				if (System.IO.Directory.Exists(f.Path))
				{
					var dirInfo = new System.IO.DirectoryInfo(f.Path);
					var dirNames = dirInfo.GetDirectories().Select(f2 => string.Format("  [{0}]  ", f2.Name)).ToArray();
					newBox.Items.AddRange(dirNames);
					var fileNames = dirInfo.GetFiles().Select(f2 => f2.Name).ToArray();
					newBox.Items.AddRange(fileNames);

					var duplicatesInThisFolder = allDuplicates
						.Where(dup => dup.Value.Any(df => df.Path == f.Path && fileNames.Contains(df.Name)))
						.SelectMany(dup => dup.Value)
						.Where(dupval => dupval.Path == f.Path && fileNames.Contains(dupval.Name))
						.Select(dupval => dupval.Name)
						.ToArray();

					var selected = newBox.SelectedItems;
					for (var i = 0; i < duplicatesInThisFolder.Length; i++)
					{
						selected.Add(duplicatesInThisFolder[i]);
					}
				}

				var checkboxFolder = new CheckBox
				{
					Anchor = AnchorStyles.Right,
					AutoSize = false,
					Left = newBox.Right - 100,
					Tag = f.Path,
					Text = "Folder Diff",
					Top = newBox.Top - boxTopMargin,
					Width = 100,
				};
				checkboxFolder.CheckedChanged += new System.EventHandler(form.checkboxFolder_Changed);


				var pathButton = new Button();
				pathButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				pathButton.AutoSize = false;
				pathButton.Top = newBox.Top - boxTopMargin;
				pathButton.Left = 0;
				pathButton.Width = newBox.Width - diffControlMargin;
				pathButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
				pathButton.Text = f.Path;
				pathButton.Tag = f;
				pathButton.Click += new System.EventHandler(form.DirectoryButton_Click);

				explorerControls.Add(newBox);
				explorerControls.Add(pathButton);
				explorerControls.Add(checkboxFolder);
				fileIndex++;
			}

			return explorerControls.ToArray();
		}

		public static TreeNode[] GetTreeNodes(DirectoryList directoryList)
		{
			var dupFiles = directoryList.ScanInfo.DuplicateFiles.GetDuplicatesByHash
				.OrderByDescending(f => 
					f.Value[0].Size * f.Value.Count);


			var rootNodes = new List<TreeNode>();
			var rangeIdx = 0;
			foreach (var range in Business.Definitions.FileSizeRanges.Ranges)
			{
				// each file size range
				var wastedSpaceThisRange = 0L;
				var hashNodes = new List<TreeNode>();
				
				foreach (var d in dupFiles
					.Where(f => f.Value[0].Size >= range[0] && f.Value[0].Size < range[1])
					.OrderByDescending(f =>	f.Value[0].Size * f.Value.Count))
				{
					// each unique hash node 
					// containing duplicate files
					var uniqueHashNode = new TreeNode(string.Join(", ", d.Value.Select(f => f.Name)));
					uniqueHashNode.Tag = d.Key;

					// count the number of actual duplicates that exist on disk
					var dupFileCount = 0;
					foreach (var f in d.Value)
					{
						if (!System.IO.File.Exists(f.FullName)) continue;

						// node for each unique file
						var fileNode = new TreeNode(
							"("
							+ f.Size.ToString("#,##0", System.Globalization.CultureInfo.InvariantCulture)
							+ " B) "
							+ f.FullName);

						fileNode.Tag = f.FullName;

						uniqueHashNode.Nodes.Add(fileNode);
						dupFileCount++;
					}

					// do not add this hash node if there are no duplicates left,
					// do not add to the statistics
					if (dupFileCount <= 1) continue;

					var wastedSpace = (d.Value.Count - 1) * d.Value[0].Size;
					wastedSpaceThisRange += wastedSpace;

					var wastedSpaceLabel = string.Format("{0} MiB, {1}×", 
						(wastedSpace / 1048576f).ToString("#,##0.0"), 
						d.Value.Count.ToString("#,##0.0"));

					uniqueHashNode.Text = wastedSpaceLabel + " " + uniqueHashNode.Text;
					hashNodes.Add(uniqueHashNode);
				}

				if (hashNodes.Count > 0)
				{
					var wastedSpaceLabel = string.Format("{0} MiB", 
						(wastedSpaceThisRange / 1048576f).ToString("#,##0.0"));

					var nodeLabel = string.Format("{0} wasted, files of 1 {1}+ ({2}×)", 
						wastedSpaceLabel, 
						Business.Definitions.FileSizeRanges.Labels[rangeIdx], 
						hashNodes.Count.ToString("#,##0.0"));

					var rangeNode = new TreeNode(nodeLabel);

					rangeNode.Nodes.AddRange(hashNodes.ToArray());
					rootNodes.Add(rangeNode);
				}

				rangeIdx++;
			}

			return rootNodes.ToArray();
		}

		// replaced by node update method
		//public static TreeNode[] TrimDuplicateFileTreeNodes(TreeNodeCollection nodes)
		//{
		//	var result = new TreeNode[nodes.Count];
		//	var rootNodeIdx = 0;
		//	var removeLeafNodes = new List<TreeNode>();
		//	foreach (var rootNode in nodes)
		//	{
		//		var rootNodeObject = (TreeNode)rootNode;
		//		foreach (var hashNode in rootNodeObject.Nodes)
		//		{
		//			var hashNodeObject = (TreeNode)hashNode;
		//			foreach (var fileNode in hashNodeObject.Nodes)
		//			{
		//				var treeNodeObject = (TreeNode)fileNode;
		//				var fullName = (string)treeNodeObject.Tag;
		//				if (!System.IO.File.Exists(fullName))
		//				{
		//					removeLeafNodes.Add(treeNodeObject);
		//				}
		//			}
		//		}
		//		result[rootNodeIdx] = rootNodeObject;
		//		rootNodeIdx++;
		//	}

		//	foreach (var node in removeLeafNodes)
		//	{
		//		var nodeParent = node.Parent;
		//		node.Remove();
		//		if (nodeParent.Nodes.Count <= 1)
		//		{
		//			nodeParent.Remove();
		//		}
		//	}

		//	return result;
		//}

		/// <summary>
		/// Clear tree nodes and re-create tree nodes
		/// </summary>
		/// <param name="directoryList"></param>
		/// <param name="treeView"></param>
		public static void UpdateTree(DirectoryList directoryList, TreeView tree)
		{
			var rootNodes = GetTreeNodes(directoryList);
			tree.Nodes.Clear();
			tree.Nodes.AddRange(rootNodes);
		}

		/// <summary>
		/// Ask to confirm these paths before starting the comparator
		/// </summary>
		/// <param name="path1"></param>
		/// <param name="path2"></param>
		public static void AskExternalComparePaths(string path1, string path2)
		{
			if (MessageBox.Show(
				string.Format("Compare directories\n{0}\nand\n{1}?", path1, path2),
				"Compare directories?",
				MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				ExternalComparePaths(path1, path2);
			}
		}

		/// <summary>
		/// Launch the directory compare program
		/// </summary>
		/// <param name="path1"></param>
		/// <param name="path2"></param>
		public static void ExternalComparePaths(string path1, string path2) 
		{
			var argument = string.Format("\"{0}\" \"{1}\"", path1, path2);
			var treeComp = Properties.Settings.Default.TreeCompFullName;

			if (System.IO.File.Exists(treeComp))
			{
				Process.Start(treeComp, argument);
			}
		}

		public static void PlaySound()
		{
			var assemblyInfo = new System.IO.FileInfo(System.Reflection.Assembly.GetAssembly(typeof(Helpers)).Location);

			new System.Media.SoundPlayer(assemblyInfo.DirectoryName + "\\Ding.wav").Play();
		}
	}
}
