namespace AquariusShell.ShellApps
{
    partial class SettingsBrowser
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Icon related settings");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Global settings", new System.Windows.Forms.TreeNode[] { treeNode1 });
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Custom buttons");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Taskbar", new System.Windows.Forms.TreeNode[] { treeNode3 });
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Programs launcher");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Directory, File or Drive Properties");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("File browser", new System.Windows.Forms.TreeNode[] { treeNode6 });
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Access control browser");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Run dialog");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Terminate shell");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Workspace");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Settings browser");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Shell apps", new System.Windows.Forms.TreeNode[] { treeNode7, treeNode8, treeNode9, treeNode10, treeNode11, treeNode12 });
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Windows Control Panel");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsBrowser));
            tvSettingsTree = new System.Windows.Forms.TreeView();
            tvImageList = new System.Windows.Forms.ImageList(components);
            pnlSettingsPageHost = new System.Windows.Forms.Panel();
            btnApplyPage = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            btnResetPageToDefaults = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // tvSettingsTree
            // 
            tvSettingsTree.BackColor = System.Drawing.Color.SteelBlue;
            tvSettingsTree.ForeColor = System.Drawing.Color.White;
            tvSettingsTree.ImageIndex = 0;
            tvSettingsTree.ImageList = tvImageList;
            tvSettingsTree.Location = new System.Drawing.Point(5, 4);
            tvSettingsTree.Name = "tvSettingsTree";
            treeNode1.ImageKey = "node";
            treeNode1.Name = "tvnGlobalIcons";
            treeNode1.SelectedImageKey = "node";
            treeNode1.Text = "Icon related settings";
            treeNode2.ImageKey = "node";
            treeNode2.Name = "tvnGlobal";
            treeNode2.SelectedImageKey = "node";
            treeNode2.Text = "Global settings";
            treeNode3.ImageKey = "node";
            treeNode3.Name = "tvnTaskbarCustomButtons";
            treeNode3.SelectedImageKey = "node";
            treeNode3.Text = "Custom buttons";
            treeNode4.ImageKey = "node";
            treeNode4.Name = "tvnTaskbar";
            treeNode4.SelectedImageKey = "node";
            treeNode4.Text = "Taskbar";
            treeNode5.ImageKey = "node";
            treeNode5.Name = "tvnLauncher";
            treeNode5.SelectedImageKey = "node";
            treeNode5.Text = "Programs launcher";
            treeNode6.ImageKey = "node";
            treeNode6.Name = "tvnShellAppsFileBrowserDFFProperties";
            treeNode6.Text = "Directory, File or Drive Properties";
            treeNode7.ImageKey = "node";
            treeNode7.Name = "tvnShellAppsFileBrowser";
            treeNode7.SelectedImageKey = "node";
            treeNode7.Text = "File browser";
            treeNode8.ImageKey = "node";
            treeNode8.Name = "tvnShellAppsAclBrowser";
            treeNode8.SelectedImageKey = "node";
            treeNode8.Text = "Access control browser";
            treeNode9.ImageKey = "node";
            treeNode9.Name = "tvnShellAppsRun";
            treeNode9.SelectedImageKey = "node";
            treeNode9.Text = "Run dialog";
            treeNode10.ImageKey = "node";
            treeNode10.Name = "tvnShellAppsTerminateShell";
            treeNode10.SelectedImageKey = "node";
            treeNode10.Text = "Terminate shell";
            treeNode11.ImageKey = "node";
            treeNode11.Name = "tvnShellAppsWorkspace";
            treeNode11.SelectedImageKey = "node";
            treeNode11.Text = "Workspace";
            treeNode12.ImageKey = "node";
            treeNode12.Name = "tvnSettingsBrowser";
            treeNode12.SelectedImageKey = "node";
            treeNode12.Text = "Settings browser";
            treeNode13.ImageKey = "node";
            treeNode13.Name = "tvnShellApps";
            treeNode13.SelectedImageKey = "node";
            treeNode13.Text = "Shell apps";
            treeNode14.ImageKey = "node";
            treeNode14.Name = "tvnWindowsControlPanel";
            treeNode14.SelectedImageKey = "node";
            treeNode14.Text = "Windows Control Panel";
            tvSettingsTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode2, treeNode4, treeNode5, treeNode13, treeNode14 });
            tvSettingsTree.SelectedImageIndex = 0;
            tvSettingsTree.Size = new System.Drawing.Size(237, 554);
            tvSettingsTree.TabIndex = 0;
            tvSettingsTree.AfterSelect += tvSettingsTree_AfterSelect;
            // 
            // tvImageList
            // 
            tvImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            tvImageList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("tvImageList.ImageStream");
            tvImageList.TransparentColor = System.Drawing.Color.Transparent;
            tvImageList.Images.SetKeyName(0, "node");
            // 
            // pnlSettingsPageHost
            // 
            pnlSettingsPageHost.Location = new System.Drawing.Point(248, 4);
            pnlSettingsPageHost.Name = "pnlSettingsPageHost";
            pnlSettingsPageHost.Size = new System.Drawing.Size(530, 500);
            pnlSettingsPageHost.TabIndex = 1;
            // 
            // btnApplyPage
            // 
            btnApplyPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnApplyPage.Location = new System.Drawing.Point(687, 521);
            btnApplyPage.Name = "btnApplyPage";
            btnApplyPage.Size = new System.Drawing.Size(91, 28);
            btnApplyPage.TabIndex = 2;
            btnApplyPage.Text = "&Apply";
            btnApplyPage.UseVisualStyleBackColor = true;
            btnApplyPage.Click += btnApplyPage_Click;
            // 
            // btnClose
            // 
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.Location = new System.Drawing.Point(248, 521);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(91, 28);
            btnClose.TabIndex = 2;
            btnClose.Text = "&Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnResetPageToDefaults
            // 
            btnResetPageToDefaults.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnResetPageToDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnResetPageToDefaults.Location = new System.Drawing.Point(558, 521);
            btnResetPageToDefaults.Name = "btnResetPageToDefaults";
            btnResetPageToDefaults.Size = new System.Drawing.Size(123, 28);
            btnResetPageToDefaults.TabIndex = 2;
            btnResetPageToDefaults.Text = "&Reset to defaults";
            btnResetPageToDefaults.UseVisualStyleBackColor = true;
            btnResetPageToDefaults.Click += btnResetPageToDefaults_Click;
            // 
            // SettingsBrowser
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            CancelButton = btnClose;
            ClientSize = new System.Drawing.Size(784, 561);
            Controls.Add(btnClose);
            Controls.Add(btnResetPageToDefaults);
            Controls.Add(btnApplyPage);
            Controls.Add(pnlSettingsPageHost);
            Controls.Add(tvSettingsTree);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsBrowser";
            Text = "Configuration browser";
            FormClosing += SettingsBrowser_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TreeView tvSettingsTree;
        private System.Windows.Forms.ImageList tvImageList;
        private System.Windows.Forms.Panel pnlSettingsPageHost;
        private System.Windows.Forms.Button btnApplyPage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnResetPageToDefaults;
    }
}