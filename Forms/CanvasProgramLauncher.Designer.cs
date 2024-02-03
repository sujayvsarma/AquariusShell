namespace AquariusShell.Forms
{
    partial class CanvasProgramLauncher
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CanvasProgramLauncher));
            accordionPanel = new System.Windows.Forms.FlowLayoutPanel();
            panelAquariusShellApps = new System.Windows.Forms.Panel();
            lvShellApps = new System.Windows.Forms.ListView();
            lvAppsListIcons32 = new System.Windows.Forms.ImageList(components);
            btnCloseLauncher = new System.Windows.Forms.Button();
            btnAquariusShellAppsAccordionHeader = new System.Windows.Forms.Button();
            chevronImages = new System.Windows.Forms.ImageList(components);
            tbWinProgsSearchBox = new System.Windows.Forms.TextBox();
            lvWindowsApps = new System.Windows.Forms.ListView();
            prgGlobalFilesWatcher = new System.IO.FileSystemWatcher();
            prgUserFilesWatcher = new System.IO.FileSystemWatcher();
            accordionPanel.SuspendLayout();
            panelAquariusShellApps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)prgGlobalFilesWatcher).BeginInit();
            ((System.ComponentModel.ISupportInitialize)prgUserFilesWatcher).BeginInit();
            SuspendLayout();
            // 
            // accordionPanel
            // 
            accordionPanel.BackColor = System.Drawing.Color.Transparent;
            accordionPanel.Controls.Add(panelAquariusShellApps);
            accordionPanel.Controls.Add(tbWinProgsSearchBox);
            accordionPanel.Controls.Add(lvWindowsApps);
            accordionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            accordionPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            accordionPanel.Location = new System.Drawing.Point(0, 0);
            accordionPanel.Name = "accordionPanel";
            accordionPanel.Size = new System.Drawing.Size(290, 697);
            accordionPanel.TabIndex = 1;
            // 
            // panelAquariusShellApps
            // 
            panelAquariusShellApps.Anchor = System.Windows.Forms.AnchorStyles.Top;
            panelAquariusShellApps.Controls.Add(lvShellApps);
            panelAquariusShellApps.Controls.Add(btnCloseLauncher);
            panelAquariusShellApps.Controls.Add(btnAquariusShellAppsAccordionHeader);
            panelAquariusShellApps.Location = new System.Drawing.Point(3, 3);
            panelAquariusShellApps.Name = "panelAquariusShellApps";
            panelAquariusShellApps.Size = new System.Drawing.Size(311, 243);
            panelAquariusShellApps.TabIndex = 0;
            // 
            // lvShellApps
            // 
            lvShellApps.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            lvShellApps.BackColor = System.Drawing.SystemColors.Control;
            lvShellApps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lvShellApps.LargeImageList = lvAppsListIcons32;
            lvShellApps.Location = new System.Drawing.Point(1, 49);
            lvShellApps.MultiSelect = false;
            lvShellApps.Name = "lvShellApps";
            lvShellApps.ShowGroups = false;
            lvShellApps.ShowItemToolTips = true;
            lvShellApps.Size = new System.Drawing.Size(302, 191);
            lvShellApps.Sorting = System.Windows.Forms.SortOrder.Ascending;
            lvShellApps.TabIndex = 6;
            lvShellApps.UseCompatibleStateImageBehavior = false;
            lvShellApps.ItemActivate += lvShellApps_ItemActivate;
            // 
            // lvAppsListIcons32
            // 
            lvAppsListIcons32.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            lvAppsListIcons32.ImageSize = new System.Drawing.Size(32, 32);
            lvAppsListIcons32.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnCloseLauncher
            // 
            btnCloseLauncher.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCloseLauncher.Image = (System.Drawing.Image)resources.GetObject("btnCloseLauncher.Image");
            btnCloseLauncher.Location = new System.Drawing.Point(268, 4);
            btnCloseLauncher.Name = "btnCloseLauncher";
            btnCloseLauncher.Size = new System.Drawing.Size(39, 42);
            btnCloseLauncher.TabIndex = 5;
            btnCloseLauncher.UseVisualStyleBackColor = true;
            btnCloseLauncher.Click += btnCloseLauncher_Click;
            // 
            // btnAquariusShellAppsAccordionHeader
            // 
            btnAquariusShellAppsAccordionHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnAquariusShellAppsAccordionHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnAquariusShellAppsAccordionHeader.ImageKey = "DN";
            btnAquariusShellAppsAccordionHeader.ImageList = chevronImages;
            btnAquariusShellAppsAccordionHeader.Location = new System.Drawing.Point(1, 3);
            btnAquariusShellAppsAccordionHeader.Name = "btnAquariusShellAppsAccordionHeader";
            btnAquariusShellAppsAccordionHeader.Size = new System.Drawing.Size(306, 43);
            btnAquariusShellAppsAccordionHeader.TabIndex = 3;
            btnAquariusShellAppsAccordionHeader.Text = "Aquarius Shell Apps";
            btnAquariusShellAppsAccordionHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnAquariusShellAppsAccordionHeader.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnAquariusShellAppsAccordionHeader.UseVisualStyleBackColor = true;
            btnAquariusShellAppsAccordionHeader.Click += btnAquariusShellAppsAccordionHeader_Click;
            // 
            // chevronImages
            // 
            chevronImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            chevronImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("chevronImages.ImageStream");
            chevronImages.TransparentColor = System.Drawing.Color.Transparent;
            chevronImages.Images.SetKeyName(0, "DN");
            chevronImages.Images.SetKeyName(1, "UP");
            // 
            // tbWinProgsSearchBox
            // 
            tbWinProgsSearchBox.Location = new System.Drawing.Point(3, 252);
            tbWinProgsSearchBox.MaxLength = 255;
            tbWinProgsSearchBox.Name = "tbWinProgsSearchBox";
            tbWinProgsSearchBox.PlaceholderText = "Search...";
            tbWinProgsSearchBox.Size = new System.Drawing.Size(307, 23);
            tbWinProgsSearchBox.TabIndex = 6;
            tbWinProgsSearchBox.WordWrap = false;
            tbWinProgsSearchBox.TextChanged += tbWinProgsSearchBox_TextChanged;
            // 
            // lvWindowsApps
            // 
            lvWindowsApps.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            lvWindowsApps.BackColor = System.Drawing.SystemColors.Control;
            lvWindowsApps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lvWindowsApps.LargeImageList = lvAppsListIcons32;
            lvWindowsApps.Location = new System.Drawing.Point(3, 281);
            lvWindowsApps.MultiSelect = false;
            lvWindowsApps.Name = "lvWindowsApps";
            lvWindowsApps.ShowGroups = false;
            lvWindowsApps.ShowItemToolTips = true;
            lvWindowsApps.Size = new System.Drawing.Size(245, 193);
            lvWindowsApps.Sorting = System.Windows.Forms.SortOrder.Ascending;
            lvWindowsApps.TabIndex = 7;
            lvWindowsApps.UseCompatibleStateImageBehavior = false;
            lvWindowsApps.ItemActivate += lvWindowsApps_ItemActivate;
            // 
            // prgGlobalFilesWatcher
            // 
            prgGlobalFilesWatcher.EnableRaisingEvents = true;
            prgGlobalFilesWatcher.IncludeSubdirectories = true;
            prgGlobalFilesWatcher.NotifyFilter = System.IO.NotifyFilters.FileName;
            prgGlobalFilesWatcher.SynchronizingObject = this;
            prgGlobalFilesWatcher.Created += prgFilesWatcher_Created;
            prgGlobalFilesWatcher.Deleted += prgFilesWatcher_Deleted;
            // 
            // prgUserFilesWatcher
            // 
            prgUserFilesWatcher.EnableRaisingEvents = true;
            prgUserFilesWatcher.IncludeSubdirectories = true;
            prgUserFilesWatcher.NotifyFilter = System.IO.NotifyFilters.FileName;
            prgUserFilesWatcher.SynchronizingObject = this;
            prgUserFilesWatcher.Created += prgFilesWatcher_Created;
            prgUserFilesWatcher.Deleted += prgFilesWatcher_Deleted;
            // 
            // CanvasProgramLauncher
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCloseLauncher;
            ClientSize = new System.Drawing.Size(290, 697);
            ControlBox = false;
            Controls.Add(accordionPanel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "CanvasProgramLauncher";
            ShowIcon = false;
            ShowInTaskbar = false;
            Load += CanvasProgramLauncher_Load;
            accordionPanel.ResumeLayout(false);
            accordionPanel.PerformLayout();
            panelAquariusShellApps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)prgGlobalFilesWatcher).EndInit();
            ((System.ComponentModel.ISupportInitialize)prgUserFilesWatcher).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel accordionPanel;
        private System.Windows.Forms.Panel panelAquariusShellApps;
        private System.Windows.Forms.Button btnAquariusShellAppsAccordionHeader;
        private System.Windows.Forms.ImageList chevronImages;
        private System.Windows.Forms.Button btnCloseLauncher;
        private System.IO.FileSystemWatcher prgGlobalFilesWatcher;
        private System.IO.FileSystemWatcher prgUserFilesWatcher;
        private System.Windows.Forms.ImageList lvAppsListIcons32;
        private System.Windows.Forms.ListView lvShellApps;
        private System.Windows.Forms.TextBox tbWinProgsSearchBox;
        private System.Windows.Forms.ListView lvWindowsApps;
    }
}