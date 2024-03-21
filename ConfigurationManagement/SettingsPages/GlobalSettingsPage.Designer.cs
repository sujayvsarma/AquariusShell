namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    partial class GlobalSettingsPage
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            pbCobrandedSplash = new System.Windows.Forms.PictureBox();
            pbCobrandedIcon = new System.Windows.Forms.PictureBox();
            tbCobrandingName = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            tbCacheDirectoryPath = new System.Windows.Forms.TextBox();
            btnCacheDirectoryBrowse = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            cbLstLogEvents = new System.Windows.Forms.CheckedListBox();
            label8 = new System.Windows.Forms.Label();
            cbLogRolloverStrategy = new System.Windows.Forms.ComboBox();
            label9 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            btnLoggingDirectoryBrowse = new System.Windows.Forms.Button();
            tbLogFileMaxSizeBytes = new System.Windows.Forms.TextBox();
            tbLoggingDirectoryPath = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            chkIsLoggingEnabled = new System.Windows.Forms.CheckBox();
            cbEnableMultiMonitorSupport = new System.Windows.Forms.CheckBox();
            cbEnableVirtualDesktopSupport = new System.Windows.Forms.CheckBox();
            fbdBrowseForDirectories = new System.Windows.Forms.FolderBrowserDialog();
            ofdBrowseForCobrandImages = new System.Windows.Forms.OpenFileDialog();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCobrandedSplash).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCobrandedIcon).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pbCobrandedSplash);
            groupBox1.Controls.Add(pbCobrandedIcon);
            groupBox1.Controls.Add(tbCobrandingName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = System.Drawing.Color.White;
            groupBox1.Location = new System.Drawing.Point(12, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(495, 95);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Co-branding";
            // 
            // pbCobrandedSplash
            // 
            pbCobrandedSplash.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pbCobrandedSplash.Location = new System.Drawing.Point(431, 40);
            pbCobrandedSplash.Name = "pbCobrandedSplash";
            pbCobrandedSplash.Size = new System.Drawing.Size(32, 32);
            pbCobrandedSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbCobrandedSplash.TabIndex = 2;
            pbCobrandedSplash.TabStop = false;
            pbCobrandedSplash.Click += pbCobrandedSplash_Click;
            // 
            // pbCobrandedIcon
            // 
            pbCobrandedIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pbCobrandedIcon.Location = new System.Drawing.Point(341, 40);
            pbCobrandedIcon.Name = "pbCobrandedIcon";
            pbCobrandedIcon.Size = new System.Drawing.Size(32, 32);
            pbCobrandedIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbCobrandedIcon.TabIndex = 2;
            pbCobrandedIcon.TabStop = false;
            pbCobrandedIcon.Click += pbCobrandedIcon_Click;
            // 
            // tbCobrandingName
            // 
            tbCobrandingName.Location = new System.Drawing.Point(17, 40);
            tbCobrandingName.Name = "tbCobrandingName";
            tbCobrandingName.Size = new System.Drawing.Size(297, 23);
            tbCobrandingName.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(409, 22);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(77, 15);
            label3.TabIndex = 0;
            label3.Text = "Splash image";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(328, 22);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(58, 15);
            label2.TabIndex = 0;
            label2.Text = "Shell icon";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(17, 22);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Shell name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 114);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(90, 15);
            label4.TabIndex = 1;
            label4.Text = "Cache directory";
            // 
            // tbCacheDirectoryPath
            // 
            tbCacheDirectoryPath.Location = new System.Drawing.Point(17, 134);
            tbCacheDirectoryPath.Name = "tbCacheDirectoryPath";
            tbCacheDirectoryPath.Size = new System.Drawing.Size(406, 23);
            tbCacheDirectoryPath.TabIndex = 2;
            // 
            // btnCacheDirectoryBrowse
            // 
            btnCacheDirectoryBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCacheDirectoryBrowse.Location = new System.Drawing.Point(432, 133);
            btnCacheDirectoryBrowse.Name = "btnCacheDirectoryBrowse";
            btnCacheDirectoryBrowse.Size = new System.Drawing.Size(75, 24);
            btnCacheDirectoryBrowse.TabIndex = 3;
            btnCacheDirectoryBrowse.Text = "Browse...";
            btnCacheDirectoryBrowse.UseVisualStyleBackColor = true;
            btnCacheDirectoryBrowse.Click += btnCacheDirectoryBrowse_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbLstLogEvents);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(cbLogRolloverStrategy);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(btnLoggingDirectoryBrowse);
            groupBox2.Controls.Add(tbLogFileMaxSizeBytes);
            groupBox2.Controls.Add(tbLoggingDirectoryPath);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(chkIsLoggingEnabled);
            groupBox2.ForeColor = System.Drawing.Color.White;
            groupBox2.Location = new System.Drawing.Point(12, 172);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(495, 218);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Logging settings";
            // 
            // cbLstLogEvents
            // 
            cbLstLogEvents.BackColor = System.Drawing.Color.SteelBlue;
            cbLstLogEvents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            cbLstLogEvents.ForeColor = System.Drawing.Color.White;
            cbLstLogEvents.FormattingEnabled = true;
            cbLstLogEvents.IntegralHeight = false;
            cbLstLogEvents.Location = new System.Drawing.Point(138, 136);
            cbLstLogEvents.Name = "cbLstLogEvents";
            cbLstLogEvents.Size = new System.Drawing.Size(344, 76);
            cbLstLogEvents.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(409, 109);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(35, 15);
            label8.TabIndex = 6;
            label8.Text = "bytes";
            // 
            // cbLogRolloverStrategy
            // 
            cbLogRolloverStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbLogRolloverStrategy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cbLogRolloverStrategy.FormattingEnabled = true;
            cbLogRolloverStrategy.Location = new System.Drawing.Point(140, 76);
            cbLogRolloverStrategy.Name = "cbLogRolloverStrategy";
            cbLogRolloverStrategy.Size = new System.Drawing.Size(342, 23);
            cbLogRolloverStrategy.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(8, 137);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(75, 15);
            label9.TabIndex = 4;
            label9.Text = "Events to log";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(8, 108);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(103, 15);
            label7.TabIndex = 4;
            label7.Text = "Maximum file size";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(8, 79);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(95, 15);
            label6.TabIndex = 4;
            label6.Text = "Rollover strategy";
            // 
            // btnLoggingDirectoryBrowse
            // 
            btnLoggingDirectoryBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLoggingDirectoryBrowse.Location = new System.Drawing.Point(407, 44);
            btnLoggingDirectoryBrowse.Name = "btnLoggingDirectoryBrowse";
            btnLoggingDirectoryBrowse.Size = new System.Drawing.Size(75, 24);
            btnLoggingDirectoryBrowse.TabIndex = 3;
            btnLoggingDirectoryBrowse.Text = "Browse...";
            btnLoggingDirectoryBrowse.UseVisualStyleBackColor = true;
            btnLoggingDirectoryBrowse.Click += btnLoggingDirectoryBrowse_Click;
            // 
            // tbLogFileMaxSizeBytes
            // 
            tbLogFileMaxSizeBytes.Location = new System.Drawing.Point(140, 105);
            tbLogFileMaxSizeBytes.Name = "tbLogFileMaxSizeBytes";
            tbLogFileMaxSizeBytes.Size = new System.Drawing.Size(261, 23);
            tbLogFileMaxSizeBytes.TabIndex = 2;
            // 
            // tbLoggingDirectoryPath
            // 
            tbLoggingDirectoryPath.Location = new System.Drawing.Point(139, 45);
            tbLoggingDirectoryPath.Name = "tbLoggingDirectoryPath";
            tbLoggingDirectoryPath.Size = new System.Drawing.Size(261, 23);
            tbLoggingDirectoryPath.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(8, 48);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(82, 15);
            label5.TabIndex = 1;
            label5.Text = "Logs directory";
            // 
            // chkIsLoggingEnabled
            // 
            chkIsLoggingEnabled.AutoSize = true;
            chkIsLoggingEnabled.Location = new System.Drawing.Point(11, 23);
            chkIsLoggingEnabled.Name = "chkIsLoggingEnabled";
            chkIsLoggingEnabled.Size = new System.Drawing.Size(126, 19);
            chkIsLoggingEnabled.TabIndex = 0;
            chkIsLoggingEnabled.Text = "Logging is enabled";
            chkIsLoggingEnabled.UseVisualStyleBackColor = true;
            chkIsLoggingEnabled.CheckedChanged += chkIsLoggingEnabled_CheckedChanged;
            // 
            // cbEnableMultiMonitorSupport
            // 
            cbEnableMultiMonitorSupport.AutoSize = true;
            cbEnableMultiMonitorSupport.Location = new System.Drawing.Point(14, 400);
            cbEnableMultiMonitorSupport.Name = "cbEnableMultiMonitorSupport";
            cbEnableMultiMonitorSupport.Size = new System.Drawing.Size(184, 19);
            cbEnableMultiMonitorSupport.TabIndex = 5;
            cbEnableMultiMonitorSupport.Text = "Enable multi-monitor support";
            cbEnableMultiMonitorSupport.UseVisualStyleBackColor = true;
            // 
            // cbEnableVirtualDesktopSupport
            // 
            cbEnableVirtualDesktopSupport.AutoSize = true;
            cbEnableVirtualDesktopSupport.Enabled = false;
            cbEnableVirtualDesktopSupport.Location = new System.Drawing.Point(14, 425);
            cbEnableVirtualDesktopSupport.Name = "cbEnableVirtualDesktopSupport";
            cbEnableVirtualDesktopSupport.Size = new System.Drawing.Size(191, 19);
            cbEnableVirtualDesktopSupport.TabIndex = 5;
            cbEnableVirtualDesktopSupport.Text = "Enable virtual desktops support";
            cbEnableVirtualDesktopSupport.UseVisualStyleBackColor = true;
            cbEnableVirtualDesktopSupport.Visible = false;
            // 
            // fbdBrowseForDirectories
            // 
            fbdBrowseForDirectories.AddToRecent = false;
            fbdBrowseForDirectories.OkRequiresInteraction = true;
            fbdBrowseForDirectories.ShowPinnedPlaces = false;
            // 
            // ofdBrowseForCobrandImages
            // 
            ofdBrowseForCobrandImages.AddToRecent = false;
            ofdBrowseForCobrandImages.OkRequiresInteraction = true;
            ofdBrowseForCobrandImages.RestoreDirectory = true;
            ofdBrowseForCobrandImages.ShowPreview = true;
            ofdBrowseForCobrandImages.SupportMultiDottedExtensions = true;
            // 
            // GlobalSettingsPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = System.Drawing.Color.SteelBlue;
            Controls.Add(cbEnableVirtualDesktopSupport);
            Controls.Add(cbEnableMultiMonitorSupport);
            Controls.Add(groupBox2);
            Controls.Add(btnCacheDirectoryBrowse);
            Controls.Add(tbCacheDirectoryPath);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            ForeColor = System.Drawing.Color.White;
            Name = "GlobalSettingsPage";
            Size = new System.Drawing.Size(524, 494);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbCobrandedSplash).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCobrandedIcon).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbCobrandingName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbCobrandedIcon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbCobrandedSplash;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCacheDirectoryPath;
        private System.Windows.Forms.Button btnCacheDirectoryBrowse;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLoggingDirectoryBrowse;
        private System.Windows.Forms.TextBox tbLoggingDirectoryPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsLoggingEnabled;
        private System.Windows.Forms.ComboBox cbLogRolloverStrategy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbLogFileMaxSizeBytes;
        private System.Windows.Forms.CheckedListBox cbLstLogEvents;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbEnableMultiMonitorSupport;
        private System.Windows.Forms.CheckBox cbEnableVirtualDesktopSupport;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowseForDirectories;
        private System.Windows.Forms.OpenFileDialog ofdBrowseForCobrandImages;
    }
}
