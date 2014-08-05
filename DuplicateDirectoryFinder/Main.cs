﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;

namespace DuplicateDirectoryFinder
{
	public partial class Main : Form
	{
		private Data.DirectoryList directoryList;
		private Data.UseFileInfoDictionary useFileInfoDictionary; 

		public Main()
		{
			InitializeComponent();

			// get drive letters
			textBoxScanDirectory.Text = string.Join("|", Data.Drive.GetDrives());
		}

		/* Top panel */
		private void ButtonLoadLastScan_Click(object sender, EventArgs e)
		{
			((Button)sender).Enabled = false;
			this.UseWaitCursor = true;

			LoadLastScan();
		}

		private void ButtonPickDirectory_Click(object sender, EventArgs e)
		{
			if (DirectoryPicker.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if (System.IO.Directory.Exists(DirectoryPicker.SelectedPath))
				{
					textBoxScanDirectory.Text = DirectoryPicker.SelectedPath;
				}
			}
		}

		private void ButtonStartScan_Click(object sender, EventArgs e)
		{
			buttonStartScan.Enabled = false;

			var paths = textBoxScanDirectory.Text.Split('|');
			var skipSize = (long)NumericUpDownSkipSize.Value;

			// start scanning background thread
			StartScanning(paths, skipSize);
		}

		private void buttonLoadFileHashes_Click(object sender, EventArgs e)
		{
			this.UseWaitCursor = true;
			((Button)sender).Enabled = false;
			((Button)sender).Update();
			useFileInfoDictionary = new Data.UseFileInfoDictionary(true);
			this.UseWaitCursor = false;
			(new System.Media.SoundPlayer("Ding.wav")).Play();
		}

		/* right panel: directory view button event */
		public void DirectoryButton_Click(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(Button))
			{
				var senderObj = (Button)sender;
				var fullName = ((Data.File)senderObj.Tag).FullName;
				if (!System.IO.File.Exists(fullName))
				{
					return;
				}

				// it doesn't matter if there is a space after ','
				string argument = @"/select, " + fullName;

				System.Diagnostics.Process.Start("explorer.exe", argument);
			}
		}

		/* right panel: diff button event */
		public void DiffButton_Click(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(Button))
			{
				var senderObj = (Button)sender;
				var paths = ((string[])senderObj.Tag);
				if (!System.IO.Directory.Exists(paths[0])
					|| !System.IO.Directory.Exists(paths[1]))
				{
					return;
				}

				// it doesn't matter if there is a space after ','
				string argument = string.Format("\"{0}\" \"{1}\"", paths);

				var winMerge = Properties.Settings.Default.WinMergeFullName;
				if (System.IO.File.Exists(winMerge)) System.Diagnostics.Process.Start(winMerge, argument);
			}
		}

		public void checkboxFolder_Changed(object sender, EventArgs e)
		{
			var checkedBoxes = new List<CheckBox>();
			foreach (var c in splitContainerMain.Panel2.Controls)
			{
				if (c.GetType() == typeof(CheckBox))
				{
					var cb = (CheckBox)c;
					if (cb.Checked) checkedBoxes.Add(cb);
				}
			}
			if (checkedBoxes.Count == 2)
			{
				AskComparePaths((string)checkedBoxes[0].Tag, (string)checkedBoxes[1].Tag);
			}
		}

		private void AskComparePaths(string p1, string p2)
		{
			if (MessageBox.Show(string.Format("Compare directories {0}\nand\n{1}?", p1, p2),
				"Compare directories?",
				MessageBoxButtons.YesNo)
				== System.Windows.Forms.DialogResult.Yes)
			{
				string argument = string.Format("\"{0}\" \"{1}\"", p1, p2);

				var treeComp = Properties.Settings.Default.TreeCompFullName;
				if (System.IO.File.Exists(treeComp)) System.Diagnostics.Process.Start(treeComp, argument);
			}
		}

		/* Loading timer */
		private void LoadingTimer_Tick(object sender, EventArgs e)
		{
			if (directoryList == null)
			{
				if (progressScan.Style != ProgressBarStyle.Marquee)
				{
					progressScan.Style = ProgressBarStyle.Marquee;
				}
			}
			else
			{
				progressScan.Style = ProgressBarStyle.Continuous;
				loadingTimer.Stop();
				UpdateTree();
				(new System.Media.SoundPlayer("Ding.wav")).Play();
				this.UseWaitCursor = false;
			}
		}

		/* UI updates */
		private System.Diagnostics.Stopwatch stopWatch;
		private void UIUpdateTimer_Tick(object sender, EventArgs e)
		{
			if (stopWatch == null)
			{
				stopWatch = new System.Diagnostics.Stopwatch();
			}
			if (!stopWatch.IsRunning)
			{
				stopWatch.Start();
			}
			if (directoryList != null)
			{
				LabelFilesDirs.Text = directoryList.ScanInfo.FileScanCount.ToString("#,##0") + " files\n"
					+ directoryList.ScanInfo.DirectoryCount.ToString("#,##0") + " dirs \n"
					+ stopWatch.Elapsed.ToString("hh\\:mm\\:ss") + " time ";

				LabelLast10Files.Text = string.Join("\n", directoryList.ScanInfo.Last10Files);
				LabelLast10Directories.Text = string.Join("\n", directoryList.ScanInfo.Last10Directories);

				if (directoryList.ScanInfo.DoneScanning)
				{
					ScanFinished();

					int fileHashCount = (int)(directoryList.ScanInfo.FileHashCount % int.MaxValue);

					// if files are added while scanning,
					// update the size of the progress bar
					if (fileHashCount > progressScan.Maximum)
					{
						progressScan.Maximum = fileHashCount;
					}
					progressScan.Value = fileHashCount;
				}

				if (directoryList.ScanInfo.DoneHashing)
				{
					HashFinished();
				}
			}
			else
			{
				LabelFilesDirs.Text = "- files\n- dirs \n- hh:mm:ss";
			}
		}

		private void LoadLastScan()
		{
			// load directorylist object
			if (System.IO.File.Exists(Data.IO.Path + "DirectoryList"))
			{
				// the timer will reset the UI when loading is done
				loadingTimer.Start();
				ThreadPool.QueueUserWorkItem(delegate
				{
					directoryList = Data.IO.LoadDirectoryList("DirectoryList");
				}, null);
			}
		}

		private void StartScanning(string[] paths, long skipSize)
		{
			// do we have scan data?
			if (directoryList != null)
			{
				// set and reset UI status values
				int fileCount = (int)(directoryList.ScanInfo.FileScanCount % int.MaxValue);
				progressScan.Value = 0;
				progressScan.Maximum = fileCount;
			}

			uiUpdateTimer.Start();

			ThreadPool.QueueUserWorkItem(delegate
			{
				directoryList = new Data.DirectoryList();
				directoryList.ScanInfo.Reset();
				foreach (var path in paths)
				{
					var newD = new Data.Directory(fullPath: path);
					directoryList.Add(newD);
				}
				directoryList.Scan(skipSize);

				directoryList.ScanInfo.DoneScanning = true;
				directoryList.ScanInfo.DuplicateFiles = new Data.Statistics.DuplicateFiles(directoryList);

				directoryList.Hash(useFileInfoDictionary);

				directoryList.ScanInfo.DuplicateFiles.Process(directoryList);
				directoryList.ScanInfo.DoneHashing = true;
			}, null);
		}

		private void ScanFinished()
		{
			// update progress bar size
			int fileCount = (int)(directoryList.ScanInfo.FileScanCount % int.MaxValue);
			progressScan.Maximum = fileCount;
		}

		private void HashFinished()
		{
			// update UI, 
			
			// save results list
			Data.IO.SaveDirectoryList(directoryList, "DirectoryList");

			// save file hash dictionary
			var uFid = new Data.UseFileInfoDictionary(directoryList);
			uFid.Save();
			useFileInfoDictionary = uFid;

			stopWatch.Stop();
			uiUpdateTimer.Stop();
			progressScan.Value = 0;
			buttonStartScan.Enabled = true;
			UpdateTree();
			(new System.Media.SoundPlayer("Ding.wav")).Play();
		}

		private void TreeViewDuplicates_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Tag != null)
			{
				splitContainerMain.Panel2.Controls.Clear();
				var explorerControls = UI.GetExplorerControls(this, splitContainerMain.Panel2, directoryList, (string)e.Node.Tag);
				splitContainerMain.Panel2.Controls.AddRange(explorerControls);
			}
		}

		private void treeView_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				if (MessageBox.Show(string.Format("Delete file {0}?", ""), 
					"Delete file?", 
					MessageBoxButtons.YesNo) 
					== System.Windows.Forms.DialogResult.Yes)
				{
					// delete file
				}
			}
		}

		private void buttonTrimTree_Click(object sender, EventArgs e)
		{
			// old tree trimming routine
			//var trimmedNodes = UI.TrimDuplicateFileTreeNodes(treeView.Nodes);
			//treeView.Nodes.Clear();
			//treeView.Nodes.AddRange(trimmedNodes);

			// now trims non-duplicates
			UpdateTree();
		}

		private void UpdateTree()
		{
			var rootNodes = UI.GetTreeNodes(directoryList);
			treeView.Nodes.Clear();
			treeView.Nodes.AddRange(rootNodes);
		}
	}
}