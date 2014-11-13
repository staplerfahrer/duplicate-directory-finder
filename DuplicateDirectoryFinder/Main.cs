namespace DDFinder.UI
{
	using Business;
	using Extensions;
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Windows.Forms;

	public partial class Main : Form
	{
		private UiState uiState;

		private Services.DuplicateScanner.DirectoryList directoryList;
		private Services.DuplicateScanner.UseFileInfoDictionary useFileInfoDictionary;
		private string IOResultMessage;

		/*
		 * VIEW STATE STUFF 
		 */
		public enum UiState
		{
			Idle,
			BusyScanning,
			BusyTrimming,
			BusyComparing
		}
		public bool ToIdle()
		{
			if (CanGoIdle()) return SetState(UiState.Idle);
			return false;
		}
		public bool ToBusyScanning()
		{
			if (CanGoBusyScanning()) return SetState(UiState.BusyScanning);
			return false;
		}
		public bool ToBusyTrimming()
		{
			if (CanGoBusyTrimming()) return SetState(UiState.BusyTrimming);
			return false;
		}
		public bool ToBusyComparing()
		{
			if (CanGoBusyComparing()) return SetState(UiState.BusyComparing);
			return false;
		}
		public bool CanGoIdle()
		{
			return uiState != UiState.Idle;
		}
		public bool CanGoBusyScanning()
		{
			return uiState == UiState.Idle;
		}
		public bool CanGoBusyTrimming()
		{
			return uiState == UiState.Idle;
		}
		public bool CanGoBusyComparing()
		{
			return uiState == UiState.Idle;
		}
		private bool SetState(UiState newState)
		{
			switch (newState)
			{
				case UiState.Idle:
					break;
				case UiState.BusyScanning:
					break;
				case UiState.BusyTrimming:
					break;
				case UiState.BusyComparing:
					break;
				default:
					return false;
			}
			return true;
		}

		public Main()
		{
			InitializeComponent();

			// get drive letters
			textBoxScanDirectory.Text = string.Join("|", Services.DuplicateScanner.Drive.GetDrives());
		}

		/* Top panel */
		private async void ButtonLoadLastScan_Click(object sender, EventArgs e)
		{
			((Button)sender).Enabled = false;
			this.UseWaitCursor = true;

			await LoadLastScanAsync();
		}

		private void ButtonPickDirectory_Click(object sender, EventArgs e)
		{
			if (directoryPicker.ShowDialog() == System.Windows.Forms.DialogResult.OK
				&& System.IO.Directory.Exists(directoryPicker.SelectedPath))
			{
				textBoxScanDirectory.Text = textBoxScanDirectory.Text.JoinWith("|", directoryPicker.SelectedPath);
			}
		}

		private void ButtonStartScan_Click(object sender, EventArgs e)
		{
			buttonStartScan.Enabled = false;

			var paths = textBoxScanDirectory.Text.Split('|');
			var skipSize = (long)numericUpDownSkipSize.Value;

			// start scanning background thread
			StartScanning(paths, skipSize);
		}

		private void buttonLoadFileHashes_Click(object sender, EventArgs e)
		{
			this.UseWaitCursor = true;
			((Button)sender).Enabled = false;
			((Button)sender).Update();
			useFileInfoDictionary = new Services.DuplicateScanner.UseFileInfoDictionary(true);
			this.UseWaitCursor = false;
			Helpers.PlaySound();
		}

		/* right panel: directory view button event */
		public void DirectoryButton_Click(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(Button))
			{
				var senderObj = (Button)sender;
				var fullName = ((Services.DuplicateScanner.File)senderObj.Tag).FullName;
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
				var paths = (string[])senderObj.Tag;
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
				var path1 = (string)checkedBoxes[0].Tag;
				var path2 = (string)checkedBoxes[1].Tag;
				UI.Helpers.AskExternalComparePaths(path1, path2);
			}
		}

		/* Loading timer */
		private void LoadingTimer_Tick(object sender, EventArgs e)
		{
			if (directoryList == null && IOResultMessage == null)
			{
				progressScan.Style = ProgressBarStyle.Marquee;
			}
			else
			{
				progressScan.Style = ProgressBarStyle.Continuous;
				loadingTimer.Stop();
				if (directoryList != null)
				{
					UI.Helpers.UpdateTree(directoryList, treeView);
				}
				else
				{
					MessageBox.Show(IOResultMessage, "An error occurred while loading.", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				UI.Helpers.PlaySound();
				this.UseWaitCursor = false;
			}
		}

		/* UI updates */
		private Stopwatch stopWatch;
		private void UIUpdateTimer_Tick(object sender, EventArgs e)
		{
			if (stopWatch == null)
			{
				stopWatch = new Stopwatch();
			}
			if (!stopWatch.IsRunning)
			{
				stopWatch.Start();
			}
			if (directoryList != null)
			{
				labelFilesDirs.Text = directoryList.ScanInfo.FileScanCount.ToString("#,##0") + " files\n"
					+ directoryList.ScanInfo.DirectoryCount.ToString("#,##0") + " dirs \n"
					+ stopWatch.Elapsed.ToString("hh\\:mm\\:ss") + " time ";

				labelLast10Files.Text = string.Join("\n", directoryList.ScanInfo.Last10Files);
				labelLast10Directories.Text = string.Join("\n", directoryList.ScanInfo.Last10Directories);

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
				labelFilesDirs.Text = "- files\n- dirs \n- hh:mm:ss";
			}
		}

		/// <summary>
		/// Load the serialized DirectoryList containing the saved data from the last scan.
		/// </summary>
		private async Task LoadLastScanAsync()
		{
			// load directorylist object
			if (!System.IO.File.Exists(Services.IO.Storage.DirectoryListFullPath))
			{
				MessageBox.Show(string.Format(
						"The previous scan results could not be loaded from {0}.",
						Services.IO.Storage.DirectoryListFullPath));
				return;
			}

			// the timer will reset the UI when loading is done
			IOResultMessage = null;
			directoryList = null;
			loadingTimer.Start();

			var taskResult = await Services.IO.Storage.LoadDirectoryListAsync<Services.DuplicateScanner.DirectoryList>();
			if (taskResult.Object != null)
			{
				IOResultMessage = null;
				directoryList = taskResult.Object;
			}
			else if (taskResult.Message != null)
			{
				IOResultMessage = taskResult.Message;
				directoryList = null;
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
				directoryList = new Services.DuplicateScanner.DirectoryList();
				directoryList.ScanInfo.Reset();
				foreach (var path in paths)
				{
					var newD = new Services.DuplicateScanner.Directory(fullPath: path);
					directoryList.Add(newD);
				}
				directoryList.Scan(skipSize);

				directoryList.ScanInfo.DoneScanning = true;
				directoryList.ScanInfo.DuplicateFiles = new Services.DuplicateScanner.Statistics.DuplicateFiles(directoryList);

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
			Services.IO.Storage.SaveDirectoryList(directoryList);

			// save file hash dictionary
			var uFid = new Services.DuplicateScanner.UseFileInfoDictionary(directoryList);
			uFid.Save();
			useFileInfoDictionary = uFid;

			stopWatch.Stop();
			uiUpdateTimer.Stop();
			progressScan.Value = 0;
			buttonStartScan.Enabled = true;
			UI.Helpers.UpdateTree(directoryList, treeView);
			UI.Helpers.PlaySound();
		}

		private void TreeViewDuplicates_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Tag != null)
			{
				splitContainerMain.Panel2.Controls.Clear();
				var explorerControls = UI.Helpers.GetExplorerControls(this, splitContainerMain.Panel2, directoryList, (string)e.Node.Tag);
				splitContainerMain.Panel2.Controls.AddRange(explorerControls);
			}
		}

		// todo: context menu for deleting files
		//private void treeView_MouseUp(object sender, MouseEventArgs e)
		//{
		//	if (e.Button == System.Windows.Forms.MouseButtons.Right)
		//	{
		//		if (MessageBox.Show(string.Format("Delete file {0}?", ""), 
		//			"Delete file?", 
		//			MessageBoxButtons.YesNo) 
		//			== DialogResult.Yes)
		//		{
		//			// delete file
		//		}
		//	}
		//}

		private void buttonTrimTree_Click(object sender, EventArgs e)
		{
			// now trims non-duplicates
			UI.Helpers.UpdateTree(directoryList, treeView);
		}
	}
}
