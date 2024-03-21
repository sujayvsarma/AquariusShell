namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    partial class SettingsBrowserSettingsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsBrowserSettingsPage));
            chkShowAppOnLauncher = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            pbLauncherIcon = new System.Windows.Forms.PictureBox();
            tbLauncherCaption = new System.Windows.Forms.TextBox();
            ofdFindLauncherIcon = new System.Windows.Forms.OpenFileDialog();
            mngLstHiddenControlPanelApplets = new Controls.ManageableShellItemsListbox();
            label3 = new System.Windows.Forms.Label();
            chkAllowRunningCPLWithPassword = new System.Windows.Forms.CheckBox();
            chkRequirePasswordToLaunchSettingsBrowser = new System.Windows.Forms.CheckBox();
            tbLaunchPassword = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            tbAppletLaunchPassword = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pbLauncherIcon).BeginInit();
            SuspendLayout();
            // 
            // chkShowAppOnLauncher
            // 
            chkShowAppOnLauncher.AutoSize = true;
            chkShowAppOnLauncher.Location = new System.Drawing.Point(8, 10);
            chkShowAppOnLauncher.Name = "chkShowAppOnLauncher";
            chkShowAppOnLauncher.Size = new System.Drawing.Size(326, 19);
            chkShowAppOnLauncher.TabIndex = 13;
            chkShowAppOnLauncher.Text = "Show the Settings Browser app on the Program Launcher";
            chkShowAppOnLauncher.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(27, 31);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(30, 15);
            label2.TabIndex = 16;
            label2.Text = "Icon";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(71, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(49, 15);
            label1.TabIndex = 15;
            label1.Text = "Caption";
            // 
            // pbLauncherIcon
            // 
            pbLauncherIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pbLauncherIcon.Location = new System.Drawing.Point(27, 49);
            pbLauncherIcon.Name = "pbLauncherIcon";
            pbLauncherIcon.Size = new System.Drawing.Size(24, 24);
            pbLauncherIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbLauncherIcon.TabIndex = 17;
            pbLauncherIcon.TabStop = false;
            pbLauncherIcon.Click += pbLauncherIcon_Click;
            // 
            // tbLauncherCaption
            // 
            tbLauncherCaption.Location = new System.Drawing.Point(71, 51);
            tbLauncherCaption.Name = "tbLauncherCaption";
            tbLauncherCaption.Size = new System.Drawing.Size(436, 23);
            tbLauncherCaption.TabIndex = 19;
            // 
            // ofdFindLauncherIcon
            // 
            ofdFindLauncherIcon.Filter = "All supported types (*.jpg,*.png,*.ico)|*.jpg;*.png;*.ico";
            ofdFindLauncherIcon.OkRequiresInteraction = true;
            ofdFindLauncherIcon.RestoreDirectory = true;
            ofdFindLauncherIcon.ShowPreview = true;
            ofdFindLauncherIcon.SupportMultiDottedExtensions = true;
            // 
            // mngLstHiddenControlPanelApplets
            // 
            mngLstHiddenControlPanelApplets.AllowSelectApps = true;
            mngLstHiddenControlPanelApplets.AllowSelectControlPanelItems = true;
            mngLstHiddenControlPanelApplets.AllowSelectDrivesDirectoriesAndFiles = true;
            mngLstHiddenControlPanelApplets.BackColor = System.Drawing.Color.SteelBlue;
            mngLstHiddenControlPanelApplets.ForeColor = System.Drawing.Color.White;
            mngLstHiddenControlPanelApplets.ListboxBackgroundColor = System.Drawing.SystemColors.Window;
            mngLstHiddenControlPanelApplets.Location = new System.Drawing.Point(13, 165);
            mngLstHiddenControlPanelApplets.Name = "mngLstHiddenControlPanelApplets";
            mngLstHiddenControlPanelApplets.Size = new System.Drawing.Size(494, 249);
            mngLstHiddenControlPanelApplets.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(13, 147);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(315, 15);
            label3.TabIndex = 21;
            label3.Text = "Do not show the following Windows Control Panel applets";
            // 
            // chkAllowRunningCPLWithPassword
            // 
            chkAllowRunningCPLWithPassword.AutoSize = true;
            chkAllowRunningCPLWithPassword.Location = new System.Drawing.Point(8, 422);
            chkAllowRunningCPLWithPassword.Name = "chkAllowRunningCPLWithPassword";
            chkAllowRunningCPLWithPassword.Size = new System.Drawing.Size(392, 19);
            chkAllowRunningCPLWithPassword.TabIndex = 22;
            chkAllowRunningCPLWithPassword.Text = "Allow running above Windows Control Panel applets with a password";
            chkAllowRunningCPLWithPassword.UseVisualStyleBackColor = true;
            chkAllowRunningCPLWithPassword.CheckedChanged += chkAllowRunningCPLWithPassword_CheckedChanged;
            // 
            // chkRequirePasswordToLaunchSettingsBrowser
            // 
            chkRequirePasswordToLaunchSettingsBrowser.AutoSize = true;
            chkRequirePasswordToLaunchSettingsBrowser.Location = new System.Drawing.Point(8, 93);
            chkRequirePasswordToLaunchSettingsBrowser.Name = "chkRequirePasswordToLaunchSettingsBrowser";
            chkRequirePasswordToLaunchSettingsBrowser.Size = new System.Drawing.Size(271, 19);
            chkRequirePasswordToLaunchSettingsBrowser.TabIndex = 22;
            chkRequirePasswordToLaunchSettingsBrowser.Text = "Require a password to launch Settings Browser";
            chkRequirePasswordToLaunchSettingsBrowser.UseVisualStyleBackColor = true;
            chkRequirePasswordToLaunchSettingsBrowser.CheckedChanged += chkRequirePasswordToLaunchSettingsBrowser_CheckedChanged;
            // 
            // tbLaunchPassword
            // 
            tbLaunchPassword.Location = new System.Drawing.Point(131, 115);
            tbLaunchPassword.Name = "tbLaunchPassword";
            tbLaunchPassword.PasswordChar = '*';
            tbLaunchPassword.Size = new System.Drawing.Size(376, 23);
            tbLaunchPassword.TabIndex = 23;
            tbLaunchPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(27, 118);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(57, 15);
            label4.TabIndex = 24;
            label4.Text = "Password";
            // 
            // tbAppletLaunchPassword
            // 
            tbAppletLaunchPassword.Location = new System.Drawing.Point(131, 447);
            tbAppletLaunchPassword.Name = "tbAppletLaunchPassword";
            tbAppletLaunchPassword.PasswordChar = '*';
            tbAppletLaunchPassword.Size = new System.Drawing.Size(376, 23);
            tbAppletLaunchPassword.TabIndex = 23;
            tbAppletLaunchPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(27, 450);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(57, 15);
            label5.TabIndex = 24;
            label5.Text = "Password";
            // 
            // SettingsBrowserSettingsPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(tbAppletLaunchPassword);
            Controls.Add(tbLaunchPassword);
            Controls.Add(chkRequirePasswordToLaunchSettingsBrowser);
            Controls.Add(chkAllowRunningCPLWithPassword);
            Controls.Add(label3);
            Controls.Add(mngLstHiddenControlPanelApplets);
            Controls.Add(tbLauncherCaption);
            Controls.Add(chkShowAppOnLauncher);
            Controls.Add(label2);
            Controls.Add(pbLauncherIcon);
            Controls.Add(label1);
            ForeColor = System.Drawing.Color.White;
            Name = "SettingsBrowserSettingsPage";
            Size = new System.Drawing.Size(524, 494);
            ((System.ComponentModel.ISupportInitialize)pbLauncherIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox chkShowAppOnLauncher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbLauncherIcon;
        private System.Windows.Forms.TextBox tbLauncherCaption;
        private System.Windows.Forms.OpenFileDialog ofdFindLauncherIcon;
        private Controls.ManageableShellItemsListbox mngLstHiddenControlPanelApplets;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAllowRunningCPLWithPassword;
        private System.Windows.Forms.CheckBox chkRequirePasswordToLaunchSettingsBrowser;
        private System.Windows.Forms.TextBox tbLaunchPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAppletLaunchPassword;
        private System.Windows.Forms.Label label5;
    }
}
