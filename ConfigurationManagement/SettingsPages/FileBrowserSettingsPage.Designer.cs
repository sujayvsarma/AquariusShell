namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    partial class FileBrowserSettingsPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileBrowserSettingsPage));
            chkShowAppOnLauncher = new System.Windows.Forms.CheckBox();
            chkShowCaptionsOnToolbar = new System.Windows.Forms.CheckBox();
            chkAllowJumpToAddress = new System.Windows.Forms.CheckBox();
            chkEnableTabbedBrowsing = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            lstEnabledButtons = new System.Windows.Forms.ListBox();
            label2 = new System.Windows.Forms.Label();
            mngLstHiddenPaths = new Controls.ManageableShellItemsListbox();
            chkShowDeletedItems = new System.Windows.Forms.CheckBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            pbLauncherIcon = new System.Windows.Forms.PictureBox();
            tbLauncherCaption = new System.Windows.Forms.TextBox();
            tbInitialDirectory = new System.Windows.Forms.TextBox();
            btnBrowseForInitialDirectory = new System.Windows.Forms.Button();
            ofdFindLauncherIcon = new System.Windows.Forms.OpenFileDialog();
            fbdFindInitialDirectoryPath = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)pbLauncherIcon).BeginInit();
            SuspendLayout();
            // 
            // chkShowAppOnLauncher
            // 
            chkShowAppOnLauncher.AutoSize = true;
            chkShowAppOnLauncher.Location = new System.Drawing.Point(15, 12);
            chkShowAppOnLauncher.Name = "chkShowAppOnLauncher";
            chkShowAppOnLauncher.Size = new System.Drawing.Size(302, 19);
            chkShowAppOnLauncher.TabIndex = 0;
            chkShowAppOnLauncher.Text = "Show the File Browser app on the Program Launcher";
            chkShowAppOnLauncher.UseVisualStyleBackColor = true;
            // 
            // chkShowCaptionsOnToolbar
            // 
            chkShowCaptionsOnToolbar.AutoSize = true;
            chkShowCaptionsOnToolbar.Location = new System.Drawing.Point(15, 96);
            chkShowCaptionsOnToolbar.Name = "chkShowCaptionsOnToolbar";
            chkShowCaptionsOnToolbar.Size = new System.Drawing.Size(186, 19);
            chkShowCaptionsOnToolbar.TabIndex = 1;
            chkShowCaptionsOnToolbar.Text = "Show captions on the toolbars";
            chkShowCaptionsOnToolbar.UseVisualStyleBackColor = true;
            // 
            // chkAllowJumpToAddress
            // 
            chkAllowJumpToAddress.AutoSize = true;
            chkAllowJumpToAddress.Location = new System.Drawing.Point(15, 121);
            chkAllowJumpToAddress.Name = "chkAllowJumpToAddress";
            chkAllowJumpToAddress.Size = new System.Drawing.Size(310, 19);
            chkAllowJumpToAddress.TabIndex = 2;
            chkAllowJumpToAddress.Text = "Allow changing active path by typing into address bar";
            chkAllowJumpToAddress.UseVisualStyleBackColor = true;
            // 
            // chkEnableTabbedBrowsing
            // 
            chkEnableTabbedBrowsing.AutoSize = true;
            chkEnableTabbedBrowsing.Location = new System.Drawing.Point(15, 146);
            chkEnableTabbedBrowsing.Name = "chkEnableTabbedBrowsing";
            chkEnableTabbedBrowsing.Size = new System.Drawing.Size(153, 19);
            chkEnableTabbedBrowsing.TabIndex = 3;
            chkEnableTabbedBrowsing.Text = "Enable tabbed browsing";
            chkEnableTabbedBrowsing.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(15, 211);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(93, 15);
            label1.TabIndex = 4;
            label1.Text = "Enabled buttons";
            // 
            // lstEnabledButtons
            // 
            lstEnabledButtons.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lstEnabledButtons.FormattingEnabled = true;
            lstEnabledButtons.ItemHeight = 15;
            lstEnabledButtons.Location = new System.Drawing.Point(15, 232);
            lstEnabledButtons.Name = "lstEnabledButtons";
            lstEnabledButtons.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            lstEnabledButtons.Size = new System.Drawing.Size(493, 109);
            lstEnabledButtons.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(15, 354);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(275, 15);
            label2.TabIndex = 6;
            label2.Text = "Hide the following paths from view and navigation";
            // 
            // mngLstHiddenPaths
            // 
            mngLstHiddenPaths.AllowSelectApps = true;
            mngLstHiddenPaths.AllowSelectDrivesDirectoriesAndFiles = true;
            mngLstHiddenPaths.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            mngLstHiddenPaths.BackColor = System.Drawing.Color.SteelBlue;
            mngLstHiddenPaths.ForeColor = System.Drawing.Color.White;
            mngLstHiddenPaths.ListboxBackgroundColor = System.Drawing.SystemColors.Window;
            mngLstHiddenPaths.Location = new System.Drawing.Point(15, 372);
            mngLstHiddenPaths.Name = "mngLstHiddenPaths";
            mngLstHiddenPaths.Size = new System.Drawing.Size(493, 110);
            mngLstHiddenPaths.TabIndex = 7;
            // 
            // chkShowDeletedItems
            // 
            chkShowDeletedItems.AutoSize = true;
            chkShowDeletedItems.Location = new System.Drawing.Point(15, 171);
            chkShowDeletedItems.Name = "chkShowDeletedItems";
            chkShowDeletedItems.Size = new System.Drawing.Size(232, 19);
            chkShowDeletedItems.TabIndex = 8;
            chkShowDeletedItems.Text = "Show \"Deleted Items\" in the navigation";
            chkShowDeletedItems.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(34, 33);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(30, 15);
            label3.TabIndex = 9;
            label3.Text = "Icon";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(78, 33);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(49, 15);
            label4.TabIndex = 9;
            label4.Text = "Caption";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(258, 34);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(94, 15);
            label5.TabIndex = 9;
            label5.Text = "Start in directory";
            // 
            // pbLauncherIcon
            // 
            pbLauncherIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pbLauncherIcon.Location = new System.Drawing.Point(39, 53);
            pbLauncherIcon.Name = "pbLauncherIcon";
            pbLauncherIcon.Size = new System.Drawing.Size(24, 24);
            pbLauncherIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbLauncherIcon.TabIndex = 10;
            pbLauncherIcon.TabStop = false;
            pbLauncherIcon.Click += pbLauncherIcon_Click;
            // 
            // tbLauncherCaption
            // 
            tbLauncherCaption.Location = new System.Drawing.Point(83, 56);
            tbLauncherCaption.Name = "tbLauncherCaption";
            tbLauncherCaption.Size = new System.Drawing.Size(164, 23);
            tbLauncherCaption.TabIndex = 11;
            // 
            // tbInitialDirectory
            // 
            tbInitialDirectory.Location = new System.Drawing.Point(258, 56);
            tbInitialDirectory.Name = "tbInitialDirectory";
            tbInitialDirectory.Size = new System.Drawing.Size(164, 23);
            tbInitialDirectory.TabIndex = 11;
            // 
            // btnBrowseForInitialDirectory
            // 
            btnBrowseForInitialDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBrowseForInitialDirectory.Location = new System.Drawing.Point(422, 55);
            btnBrowseForInitialDirectory.Name = "btnBrowseForInitialDirectory";
            btnBrowseForInitialDirectory.Size = new System.Drawing.Size(75, 23);
            btnBrowseForInitialDirectory.TabIndex = 12;
            btnBrowseForInitialDirectory.Text = "Browse...";
            btnBrowseForInitialDirectory.UseVisualStyleBackColor = true;
            btnBrowseForInitialDirectory.Click += btnBrowseForInitialDirectory_Click;
            // 
            // ofdFindLauncherIcon
            // 
            ofdFindLauncherIcon.Filter = "All supported types (*.jpg,*.png,*.ico)|*.jpg;*.png;*.ico";
            ofdFindLauncherIcon.OkRequiresInteraction = true;
            ofdFindLauncherIcon.RestoreDirectory = true;
            ofdFindLauncherIcon.ShowPreview = true;
            ofdFindLauncherIcon.SupportMultiDottedExtensions = true;
            // 
            // fbdFindInitialDirectoryPath
            // 
            fbdFindInitialDirectoryPath.AddToRecent = false;
            fbdFindInitialDirectoryPath.OkRequiresInteraction = true;
            // 
            // FileBrowserSettingsPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            Controls.Add(btnBrowseForInitialDirectory);
            Controls.Add(tbInitialDirectory);
            Controls.Add(tbLauncherCaption);
            Controls.Add(pbLauncherIcon);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(chkShowDeletedItems);
            Controls.Add(mngLstHiddenPaths);
            Controls.Add(label2);
            Controls.Add(lstEnabledButtons);
            Controls.Add(label1);
            Controls.Add(chkEnableTabbedBrowsing);
            Controls.Add(chkAllowJumpToAddress);
            Controls.Add(chkShowCaptionsOnToolbar);
            Controls.Add(chkShowAppOnLauncher);
            ForeColor = System.Drawing.Color.White;
            Name = "FileBrowserSettingsPage";
            Size = new System.Drawing.Size(524, 494);
            ((System.ComponentModel.ISupportInitialize)pbLauncherIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox chkShowAppOnLauncher;
        private System.Windows.Forms.CheckBox chkShowCaptionsOnToolbar;
        private System.Windows.Forms.CheckBox chkAllowJumpToAddress;
        private System.Windows.Forms.CheckBox chkEnableTabbedBrowsing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstEnabledButtons;
        private System.Windows.Forms.Label label2;
        private Controls.ManageableShellItemsListbox mngLstHiddenPaths;
        private System.Windows.Forms.CheckBox chkShowDeletedItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbLauncherIcon;
        private System.Windows.Forms.TextBox tbLauncherCaption;
        private System.Windows.Forms.TextBox tbInitialDirectory;
        private System.Windows.Forms.Button btnBrowseForInitialDirectory;
        private System.Windows.Forms.OpenFileDialog ofdFindLauncherIcon;
        private System.Windows.Forms.FolderBrowserDialog fbdFindInitialDirectoryPath;
    }
}
