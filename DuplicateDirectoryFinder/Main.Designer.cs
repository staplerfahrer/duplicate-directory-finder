namespace DuplicateDirectoryFinder
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.panelTop = new System.Windows.Forms.Panel();
			this.buttonUpdateTree = new System.Windows.Forms.Button();
			this.buttonLoadFileHashes = new System.Windows.Forms.Button();
			this.splitContainerTop = new System.Windows.Forms.SplitContainer();
			this.labelLast10Directories = new System.Windows.Forms.Label();
			this.labelLast10Files = new System.Windows.Forms.Label();
			this.labelSize2 = new System.Windows.Forms.Label();
			this.labelSize1 = new System.Windows.Forms.Label();
			this.numericUpDownSkipSize = new System.Windows.Forms.NumericUpDown();
			this.buttonLoadLastScan = new System.Windows.Forms.Button();
			this.labelFilesDirs = new System.Windows.Forms.Label();
			this.progressScan = new System.Windows.Forms.ProgressBar();
			this.buttonStartScan = new System.Windows.Forms.Button();
			this.labelDirectory = new System.Windows.Forms.Label();
			this.buttonPickDirectory = new System.Windows.Forms.Button();
			this.textBoxScanDirectory = new System.Windows.Forms.TextBox();
			this.directoryPicker = new System.Windows.Forms.FolderBrowserDialog();
			this.uiUpdateTimer = new System.Windows.Forms.Timer(this.components);
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.treeView = new System.Windows.Forms.TreeView();
			this.loadingTimer = new System.Windows.Forms.Timer(this.components);
			this.toolTipSizeHelp = new System.Windows.Forms.ToolTip(this.components);
			this.labelStats = new System.Windows.Forms.Label();
			this.labelLast10DirectoriesTitle = new System.Windows.Forms.Label();
			this.labelLast10FilesTitle = new System.Windows.Forms.Label();
			this.panelTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerTop)).BeginInit();
			this.splitContainerTop.Panel1.SuspendLayout();
			this.splitContainerTop.Panel2.SuspendLayout();
			this.splitContainerTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSkipSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTop
			// 
			this.panelTop.BackColor = System.Drawing.SystemColors.Control;
			this.panelTop.Controls.Add(this.labelLast10FilesTitle);
			this.panelTop.Controls.Add(this.labelLast10DirectoriesTitle);
			this.panelTop.Controls.Add(this.labelStats);
			this.panelTop.Controls.Add(this.numericUpDownSkipSize);
			this.panelTop.Controls.Add(this.buttonUpdateTree);
			this.panelTop.Controls.Add(this.buttonLoadFileHashes);
			this.panelTop.Controls.Add(this.splitContainerTop);
			this.panelTop.Controls.Add(this.labelSize2);
			this.panelTop.Controls.Add(this.labelSize1);
			this.panelTop.Controls.Add(this.buttonLoadLastScan);
			this.panelTop.Controls.Add(this.labelFilesDirs);
			this.panelTop.Controls.Add(this.progressScan);
			this.panelTop.Controls.Add(this.buttonStartScan);
			this.panelTop.Controls.Add(this.labelDirectory);
			this.panelTop.Controls.Add(this.buttonPickDirectory);
			this.panelTop.Controls.Add(this.textBoxScanDirectory);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(933, 209);
			this.panelTop.TabIndex = 0;
			// 
			// buttonUpdateTree
			// 
			this.buttonUpdateTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUpdateTree.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonUpdateTree.Location = new System.Drawing.Point(775, 154);
			this.buttonUpdateTree.Name = "buttonUpdateTree";
			this.buttonUpdateTree.Size = new System.Drawing.Size(146, 23);
			this.buttonUpdateTree.TabIndex = 14;
			this.buttonUpdateTree.Text = "Update Tree";
			this.buttonUpdateTree.UseVisualStyleBackColor = true;
			this.buttonUpdateTree.Click += new System.EventHandler(this.buttonTrimTree_Click);
			// 
			// buttonLoadFileHashes
			// 
			this.buttonLoadFileHashes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLoadFileHashes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonLoadFileHashes.Location = new System.Drawing.Point(775, 69);
			this.buttonLoadFileHashes.Name = "buttonLoadFileHashes";
			this.buttonLoadFileHashes.Size = new System.Drawing.Size(146, 23);
			this.buttonLoadFileHashes.TabIndex = 13;
			this.buttonLoadFileHashes.Text = "Load File Hashes";
			this.buttonLoadFileHashes.UseVisualStyleBackColor = true;
			this.buttonLoadFileHashes.Click += new System.EventHandler(this.buttonLoadFileHashes_Click);
			// 
			// splitContainerTop
			// 
			this.splitContainerTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainerTop.Location = new System.Drawing.Point(151, 90);
			this.splitContainerTop.Name = "splitContainerTop";
			// 
			// splitContainerTop.Panel1
			// 
			this.splitContainerTop.Panel1.Controls.Add(this.labelLast10Directories);
			// 
			// splitContainerTop.Panel2
			// 
			this.splitContainerTop.Panel2.Controls.Add(this.labelLast10Files);
			this.splitContainerTop.Size = new System.Drawing.Size(618, 108);
			this.splitContainerTop.SplitterDistance = 391;
			this.splitContainerTop.TabIndex = 11;
			// 
			// labelLast10Directories
			// 
			this.labelLast10Directories.BackColor = System.Drawing.SystemColors.Window;
			this.labelLast10Directories.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelLast10Directories.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLast10Directories.ForeColor = System.Drawing.SystemColors.GrayText;
			this.labelLast10Directories.Location = new System.Drawing.Point(0, 0);
			this.labelLast10Directories.Name = "labelLast10Directories";
			this.labelLast10Directories.Size = new System.Drawing.Size(391, 108);
			this.labelLast10Directories.TabIndex = 7;
			this.labelLast10Directories.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// labelLast10Files
			// 
			this.labelLast10Files.BackColor = System.Drawing.SystemColors.Window;
			this.labelLast10Files.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelLast10Files.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLast10Files.ForeColor = System.Drawing.SystemColors.GrayText;
			this.labelLast10Files.Location = new System.Drawing.Point(0, 0);
			this.labelLast10Files.Name = "labelLast10Files";
			this.labelLast10Files.Size = new System.Drawing.Size(223, 108);
			this.labelLast10Files.TabIndex = 6;
			this.labelLast10Files.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// labelSize2
			// 
			this.labelSize2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelSize2.AutoSize = true;
			this.labelSize2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSize2.Location = new System.Drawing.Point(899, 101);
			this.labelSize2.Name = "labelSize2";
			this.labelSize2.Size = new System.Drawing.Size(25, 13);
			this.labelSize2.TabIndex = 10;
			this.labelSize2.Text = "kB*";
			this.toolTipSizeHelp.SetToolTip(this.labelSize2, "0 kB means 1 byte.");
			// 
			// labelSize1
			// 
			this.labelSize1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelSize1.AutoSize = true;
			this.labelSize1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSize1.Location = new System.Drawing.Point(783, 101);
			this.labelSize1.Name = "labelSize1";
			this.labelSize1.Size = new System.Drawing.Size(64, 13);
			this.labelSize1.TabIndex = 9;
			this.labelSize1.Text = "Skip files <";
			this.toolTipSizeHelp.SetToolTip(this.labelSize1, "0 kB means 1 byte.");
			// 
			// numericUpDownSkipSize
			// 
			this.numericUpDownSkipSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownSkipSize.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownSkipSize.Location = new System.Drawing.Point(846, 99);
			this.numericUpDownSkipSize.Maximum = new decimal(new int[] {
            -1,
            2097151,
            0,
            0});
			this.numericUpDownSkipSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownSkipSize.Name = "numericUpDownSkipSize";
			this.numericUpDownSkipSize.Size = new System.Drawing.Size(53, 22);
			this.numericUpDownSkipSize.TabIndex = 8;
			this.numericUpDownSkipSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownSkipSize.ThousandsSeparator = true;
			this.toolTipSizeHelp.SetToolTip(this.numericUpDownSkipSize, "0 kB means 1 byte.");
			this.numericUpDownSkipSize.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
			// 
			// buttonLoadLastScan
			// 
			this.buttonLoadLastScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLoadLastScan.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonLoadLastScan.Location = new System.Drawing.Point(775, 40);
			this.buttonLoadLastScan.Name = "buttonLoadLastScan";
			this.buttonLoadLastScan.Size = new System.Drawing.Size(146, 23);
			this.buttonLoadLastScan.TabIndex = 2;
			this.buttonLoadLastScan.Text = "Load Last Scan";
			this.buttonLoadLastScan.UseVisualStyleBackColor = true;
			this.buttonLoadLastScan.Click += new System.EventHandler(this.ButtonLoadLastScan_Click);
			// 
			// labelFilesDirs
			// 
			this.labelFilesDirs.BackColor = System.Drawing.SystemColors.Window;
			this.labelFilesDirs.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFilesDirs.Location = new System.Drawing.Point(12, 90);
			this.labelFilesDirs.Name = "labelFilesDirs";
			this.labelFilesDirs.Size = new System.Drawing.Size(124, 108);
			this.labelFilesDirs.TabIndex = 5;
			this.labelFilesDirs.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// progressScan
			// 
			this.progressScan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressScan.Location = new System.Drawing.Point(151, 40);
			this.progressScan.Name = "progressScan";
			this.progressScan.Size = new System.Drawing.Size(618, 23);
			this.progressScan.TabIndex = 4;
			// 
			// buttonStartScan
			// 
			this.buttonStartScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStartScan.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonStartScan.Location = new System.Drawing.Point(775, 125);
			this.buttonStartScan.Name = "buttonStartScan";
			this.buttonStartScan.Size = new System.Drawing.Size(146, 23);
			this.buttonStartScan.TabIndex = 3;
			this.buttonStartScan.Text = "Start Scanning";
			this.buttonStartScan.UseVisualStyleBackColor = true;
			this.buttonStartScan.Click += new System.EventHandler(this.ButtonStartScan_Click);
			// 
			// labelDirectory
			// 
			this.labelDirectory.AutoSize = true;
			this.labelDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDirectory.Location = new System.Drawing.Point(12, 15);
			this.labelDirectory.Name = "labelDirectory";
			this.labelDirectory.Size = new System.Drawing.Size(133, 13);
			this.labelDirectory.TabIndex = 2;
			this.labelDirectory.Text = "Directories, separate by |";
			// 
			// buttonPickDirectory
			// 
			this.buttonPickDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonPickDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPickDirectory.Location = new System.Drawing.Point(775, 10);
			this.buttonPickDirectory.Name = "buttonPickDirectory";
			this.buttonPickDirectory.Size = new System.Drawing.Size(146, 23);
			this.buttonPickDirectory.TabIndex = 0;
			this.buttonPickDirectory.Text = "Pick Directory to Scan";
			this.buttonPickDirectory.UseVisualStyleBackColor = true;
			this.buttonPickDirectory.Click += new System.EventHandler(this.ButtonPickDirectory_Click);
			// 
			// textBoxScanDirectory
			// 
			this.textBoxScanDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxScanDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxScanDirectory.Location = new System.Drawing.Point(151, 12);
			this.textBoxScanDirectory.Name = "textBoxScanDirectory";
			this.textBoxScanDirectory.Size = new System.Drawing.Size(618, 22);
			this.textBoxScanDirectory.TabIndex = 1;
			this.textBoxScanDirectory.Text = "C:\\";
			// 
			// uiUpdateTimer
			// 
			this.uiUpdateTimer.Interval = 50;
			this.uiUpdateTimer.Tick += new System.EventHandler(this.UIUpdateTimer_Tick);
			// 
			// splitContainerMain
			// 
			this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMain.Location = new System.Drawing.Point(0, 209);
			this.splitContainerMain.Name = "splitContainerMain";
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.treeView);
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.splitContainerMain.Size = new System.Drawing.Size(933, 539);
			this.splitContainerMain.SplitterDistance = 397;
			this.splitContainerMain.TabIndex = 1;
			// 
			// treeView
			// 
			this.treeView.BackColor = System.Drawing.SystemColors.Control;
			this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.treeView.FullRowSelect = true;
			this.treeView.HideSelection = false;
			this.treeView.HotTracking = true;
			this.treeView.Location = new System.Drawing.Point(0, 0);
			this.treeView.Name = "treeView";
			this.treeView.Size = new System.Drawing.Size(397, 539);
			this.treeView.TabIndex = 0;
			this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewDuplicates_AfterSelect);
			// 
			// loadingTimer
			// 
			this.loadingTimer.Tick += new System.EventHandler(this.LoadingTimer_Tick);
			// 
			// toolTipSizeHelp
			// 
			this.toolTipSizeHelp.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.toolTipSizeHelp.ToolTipTitle = "Hint";
			// 
			// labelStats
			// 
			this.labelStats.AutoSize = true;
			this.labelStats.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStats.Location = new System.Drawing.Point(12, 74);
			this.labelStats.Name = "labelStats";
			this.labelStats.Size = new System.Drawing.Size(32, 13);
			this.labelStats.TabIndex = 15;
			this.labelStats.Text = "Stats";
			// 
			// labelLast10DirectoriesTitle
			// 
			this.labelLast10DirectoriesTitle.AutoSize = true;
			this.labelLast10DirectoriesTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLast10DirectoriesTitle.Location = new System.Drawing.Point(148, 74);
			this.labelLast10DirectoriesTitle.Name = "labelLast10DirectoriesTitle";
			this.labelLast10DirectoriesTitle.Size = new System.Drawing.Size(99, 13);
			this.labelLast10DirectoriesTitle.TabIndex = 16;
			this.labelLast10DirectoriesTitle.Text = "Last 10 directories";
			// 
			// labelLast10FilesTitle
			// 
			this.labelLast10FilesTitle.AutoSize = true;
			this.labelLast10FilesTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLast10FilesTitle.Location = new System.Drawing.Point(543, 74);
			this.labelLast10FilesTitle.Name = "labelLast10FilesTitle";
			this.labelLast10FilesTitle.Size = new System.Drawing.Size(66, 13);
			this.labelLast10FilesTitle.TabIndex = 17;
			this.labelLast10FilesTitle.Text = "Last 10 files";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(933, 748);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.panelTop);
			this.Name = "Main";
			this.Text = "Duplicate Directory Finder";
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.splitContainerTop.Panel1.ResumeLayout(false);
			this.splitContainerTop.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerTop)).EndInit();
			this.splitContainerTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSkipSize)).EndInit();
			this.splitContainerMain.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
			this.splitContainerMain.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelDirectory;
        private System.Windows.Forms.Button buttonPickDirectory;
        private System.Windows.Forms.TextBox textBoxScanDirectory;
        private System.Windows.Forms.FolderBrowserDialog directoryPicker;
		private System.Windows.Forms.ProgressBar progressScan;
		private System.Windows.Forms.Button buttonStartScan;
		private System.Windows.Forms.Timer uiUpdateTimer;
		private System.Windows.Forms.Label labelFilesDirs;
		private System.Windows.Forms.Label labelLast10Directories;
		private System.Windows.Forms.Label labelLast10Files;
		private System.Windows.Forms.SplitContainer splitContainerMain;
		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.Button buttonLoadLastScan;
		private System.Windows.Forms.Timer loadingTimer;
		private System.Windows.Forms.Label labelSize2;
		private System.Windows.Forms.Label labelSize1;
		private System.Windows.Forms.NumericUpDown numericUpDownSkipSize;
		private System.Windows.Forms.SplitContainer splitContainerTop;
		private System.Windows.Forms.Button buttonLoadFileHashes;
		private System.Windows.Forms.Button buttonUpdateTree;
		private System.Windows.Forms.ToolTip toolTipSizeHelp;
		private System.Windows.Forms.Label labelLast10FilesTitle;
		private System.Windows.Forms.Label labelLast10DirectoriesTitle;
		private System.Windows.Forms.Label labelStats;
    }
}

