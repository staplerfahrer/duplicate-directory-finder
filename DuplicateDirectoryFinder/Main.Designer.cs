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
			this.PanelTop = new System.Windows.Forms.Panel();
			this.buttonUpdateTree = new System.Windows.Forms.Button();
			this.buttonLoadFileHashes = new System.Windows.Forms.Button();
			this.splitContainerTop = new System.Windows.Forms.SplitContainer();
			this.LabelLast10Directories = new System.Windows.Forms.Label();
			this.LabelLast10Files = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.NumericUpDownSkipSize = new System.Windows.Forms.NumericUpDown();
			this.ButtonLoadLastScan = new System.Windows.Forms.Button();
			this.LabelFilesDirs = new System.Windows.Forms.Label();
			this.progressScan = new System.Windows.Forms.ProgressBar();
			this.buttonStartScan = new System.Windows.Forms.Button();
			this.LabelDirectory = new System.Windows.Forms.Label();
			this.ButtonPickDirectory = new System.Windows.Forms.Button();
			this.textBoxScanDirectory = new System.Windows.Forms.TextBox();
			this.DirectoryPicker = new System.Windows.Forms.FolderBrowserDialog();
			this.uiUpdateTimer = new System.Windows.Forms.Timer(this.components);
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.treeView = new System.Windows.Forms.TreeView();
			this.loadingTimer = new System.Windows.Forms.Timer(this.components);
			this.PanelTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerTop)).BeginInit();
			this.splitContainerTop.Panel1.SuspendLayout();
			this.splitContainerTop.Panel2.SuspendLayout();
			this.splitContainerTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericUpDownSkipSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// PanelTop
			// 
			this.PanelTop.BackColor = System.Drawing.SystemColors.Window;
			this.PanelTop.Controls.Add(this.buttonUpdateTree);
			this.PanelTop.Controls.Add(this.buttonLoadFileHashes);
			this.PanelTop.Controls.Add(this.splitContainerTop);
			this.PanelTop.Controls.Add(this.label2);
			this.PanelTop.Controls.Add(this.label1);
			this.PanelTop.Controls.Add(this.NumericUpDownSkipSize);
			this.PanelTop.Controls.Add(this.ButtonLoadLastScan);
			this.PanelTop.Controls.Add(this.LabelFilesDirs);
			this.PanelTop.Controls.Add(this.progressScan);
			this.PanelTop.Controls.Add(this.buttonStartScan);
			this.PanelTop.Controls.Add(this.LabelDirectory);
			this.PanelTop.Controls.Add(this.ButtonPickDirectory);
			this.PanelTop.Controls.Add(this.textBoxScanDirectory);
			this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.PanelTop.Location = new System.Drawing.Point(0, 0);
			this.PanelTop.Name = "PanelTop";
			this.PanelTop.Size = new System.Drawing.Size(933, 191);
			this.PanelTop.TabIndex = 0;
			// 
			// buttonUpdateTree
			// 
			this.buttonUpdateTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
			this.buttonLoadFileHashes.Location = new System.Drawing.Point(775, 70);
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
			this.splitContainerTop.Location = new System.Drawing.Point(145, 69);
			this.splitContainerTop.Name = "splitContainerTop";
			// 
			// splitContainerTop.Panel1
			// 
			this.splitContainerTop.Panel1.Controls.Add(this.LabelLast10Directories);
			// 
			// splitContainerTop.Panel2
			// 
			this.splitContainerTop.Panel2.Controls.Add(this.LabelLast10Files);
			this.splitContainerTop.Size = new System.Drawing.Size(624, 108);
			this.splitContainerTop.SplitterDistance = 395;
			this.splitContainerTop.TabIndex = 11;
			// 
			// LabelLast10Directories
			// 
			this.LabelLast10Directories.BackColor = System.Drawing.SystemColors.Control;
			this.LabelLast10Directories.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LabelLast10Directories.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelLast10Directories.Location = new System.Drawing.Point(0, 0);
			this.LabelLast10Directories.Name = "LabelLast10Directories";
			this.LabelLast10Directories.Size = new System.Drawing.Size(395, 108);
			this.LabelLast10Directories.TabIndex = 7;
			this.LabelLast10Directories.Text = "-";
			this.LabelLast10Directories.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// LabelLast10Files
			// 
			this.LabelLast10Files.BackColor = System.Drawing.SystemColors.Control;
			this.LabelLast10Files.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LabelLast10Files.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelLast10Files.Location = new System.Drawing.Point(0, 0);
			this.LabelLast10Files.Name = "LabelLast10Files";
			this.LabelLast10Files.Size = new System.Drawing.Size(225, 108);
			this.LabelLast10Files.TabIndex = 6;
			this.LabelLast10Files.Text = "-";
			this.LabelLast10Files.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(902, 101);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(20, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "kB";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(776, 101);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Skip  files <";
			// 
			// NumericUpDownSkipSize
			// 
			this.NumericUpDownSkipSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NumericUpDownSkipSize.Location = new System.Drawing.Point(843, 99);
			this.NumericUpDownSkipSize.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
			this.NumericUpDownSkipSize.Name = "NumericUpDownSkipSize";
			this.NumericUpDownSkipSize.Size = new System.Drawing.Size(53, 20);
			this.NumericUpDownSkipSize.TabIndex = 8;
			this.NumericUpDownSkipSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.NumericUpDownSkipSize.ThousandsSeparator = true;
			this.NumericUpDownSkipSize.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
			// 
			// ButtonLoadLastScan
			// 
			this.ButtonLoadLastScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonLoadLastScan.Location = new System.Drawing.Point(775, 41);
			this.ButtonLoadLastScan.Name = "ButtonLoadLastScan";
			this.ButtonLoadLastScan.Size = new System.Drawing.Size(146, 23);
			this.ButtonLoadLastScan.TabIndex = 2;
			this.ButtonLoadLastScan.Text = "Load Last Scan";
			this.ButtonLoadLastScan.UseVisualStyleBackColor = true;
			this.ButtonLoadLastScan.Click += new System.EventHandler(this.ButtonLoadLastScan_Click);
			// 
			// LabelFilesDirs
			// 
			this.LabelFilesDirs.BackColor = System.Drawing.SystemColors.Control;
			this.LabelFilesDirs.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelFilesDirs.Location = new System.Drawing.Point(15, 69);
			this.LabelFilesDirs.Name = "LabelFilesDirs";
			this.LabelFilesDirs.Size = new System.Drawing.Size(124, 108);
			this.LabelFilesDirs.TabIndex = 5;
			this.LabelFilesDirs.Text = "-";
			this.LabelFilesDirs.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// progressScan
			// 
			this.progressScan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressScan.Location = new System.Drawing.Point(145, 40);
			this.progressScan.Name = "progressScan";
			this.progressScan.Size = new System.Drawing.Size(624, 23);
			this.progressScan.TabIndex = 4;
			// 
			// buttonStartScan
			// 
			this.buttonStartScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStartScan.Location = new System.Drawing.Point(775, 125);
			this.buttonStartScan.Name = "buttonStartScan";
			this.buttonStartScan.Size = new System.Drawing.Size(146, 23);
			this.buttonStartScan.TabIndex = 3;
			this.buttonStartScan.Text = "Start Scanning";
			this.buttonStartScan.UseVisualStyleBackColor = true;
			this.buttonStartScan.Click += new System.EventHandler(this.ButtonStartScan_Click);
			// 
			// LabelDirectory
			// 
			this.LabelDirectory.AutoSize = true;
			this.LabelDirectory.Location = new System.Drawing.Point(12, 9);
			this.LabelDirectory.Name = "LabelDirectory";
			this.LabelDirectory.Size = new System.Drawing.Size(105, 26);
			this.LabelDirectory.TabIndex = 2;
			this.LabelDirectory.Text = "Directories,\r\nseparate multiple by |";
			// 
			// ButtonPickDirectory
			// 
			this.ButtonPickDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonPickDirectory.Location = new System.Drawing.Point(775, 12);
			this.ButtonPickDirectory.Name = "ButtonPickDirectory";
			this.ButtonPickDirectory.Size = new System.Drawing.Size(146, 23);
			this.ButtonPickDirectory.TabIndex = 0;
			this.ButtonPickDirectory.Text = "Pick Directory to Scan";
			this.ButtonPickDirectory.UseVisualStyleBackColor = true;
			this.ButtonPickDirectory.Click += new System.EventHandler(this.ButtonPickDirectory_Click);
			// 
			// textBoxScanDirectory
			// 
			this.textBoxScanDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxScanDirectory.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxScanDirectory.Location = new System.Drawing.Point(145, 15);
			this.textBoxScanDirectory.Name = "textBoxScanDirectory";
			this.textBoxScanDirectory.Size = new System.Drawing.Size(624, 20);
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
			this.splitContainerMain.Location = new System.Drawing.Point(0, 191);
			this.splitContainerMain.Name = "splitContainerMain";
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.treeView);
			this.splitContainerMain.Size = new System.Drawing.Size(933, 557);
			this.splitContainerMain.SplitterDistance = 397;
			this.splitContainerMain.TabIndex = 1;
			// 
			// treeView
			// 
			this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView.FullRowSelect = true;
			this.treeView.HideSelection = false;
			this.treeView.HotTracking = true;
			this.treeView.Location = new System.Drawing.Point(0, 0);
			this.treeView.Name = "treeView";
			this.treeView.Size = new System.Drawing.Size(397, 557);
			this.treeView.TabIndex = 0;
			this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewDuplicates_AfterSelect);
			// 
			// loadingTimer
			// 
			this.loadingTimer.Tick += new System.EventHandler(this.LoadingTimer_Tick);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(933, 748);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.PanelTop);
			this.Name = "Main";
			this.Text = "Duplicate Directory Finder";
			this.PanelTop.ResumeLayout(false);
			this.PanelTop.PerformLayout();
			this.splitContainerTop.Panel1.ResumeLayout(false);
			this.splitContainerTop.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerTop)).EndInit();
			this.splitContainerTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.NumericUpDownSkipSize)).EndInit();
			this.splitContainerMain.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
			this.splitContainerMain.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTop;
        private System.Windows.Forms.Label LabelDirectory;
        private System.Windows.Forms.Button ButtonPickDirectory;
        private System.Windows.Forms.TextBox textBoxScanDirectory;
        private System.Windows.Forms.FolderBrowserDialog DirectoryPicker;
		private System.Windows.Forms.ProgressBar progressScan;
		private System.Windows.Forms.Button buttonStartScan;
		private System.Windows.Forms.Timer uiUpdateTimer;
		private System.Windows.Forms.Label LabelFilesDirs;
		private System.Windows.Forms.Label LabelLast10Directories;
		private System.Windows.Forms.Label LabelLast10Files;
		private System.Windows.Forms.SplitContainer splitContainerMain;
		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.Button ButtonLoadLastScan;
		private System.Windows.Forms.Timer loadingTimer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown NumericUpDownSkipSize;
		private System.Windows.Forms.SplitContainer splitContainerTop;
		private System.Windows.Forms.Button buttonLoadFileHashes;
		private System.Windows.Forms.Button buttonUpdateTree;
    }
}

