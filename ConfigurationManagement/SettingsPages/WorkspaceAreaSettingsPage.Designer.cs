namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    partial class WorkspaceAreaSettingsPage
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
            label1 = new System.Windows.Forms.Label();
            pbBackgroundColour = new System.Windows.Forms.PictureBox();
            tbBackgroundColourHex = new System.Windows.Forms.TextBox();
            chkShowBackgroundImage = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            cmbBackgroundImageSource = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            tbPictureChangeInterval = new System.Windows.Forms.NumericUpDown();
            cmbBackgroundChangeIntervalUnits = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            tbLocalFolderSourceLocation = new System.Windows.Forms.TextBox();
            btnBackgroundImageFolderBrowse = new System.Windows.Forms.Button();
            chkShowIconsOnDesktop = new System.Windows.Forms.CheckBox();
            clrDlgPickBackgroundColour = new System.Windows.Forms.ColorDialog();
            fbdFolders = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)pbBackgroundColour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbPictureChangeInterval).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(108, 15);
            label1.TabIndex = 0;
            label1.Text = "Background colour";
            // 
            // pbBackgroundColour
            // 
            pbBackgroundColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pbBackgroundColour.Location = new System.Drawing.Point(476, 9);
            pbBackgroundColour.Name = "pbBackgroundColour";
            pbBackgroundColour.Size = new System.Drawing.Size(24, 24);
            pbBackgroundColour.TabIndex = 1;
            pbBackgroundColour.TabStop = false;
            pbBackgroundColour.Click += pbBackgroundColour_Click;
            // 
            // tbBackgroundColourHex
            // 
            tbBackgroundColourHex.Location = new System.Drawing.Point(246, 9);
            tbBackgroundColourHex.Name = "tbBackgroundColourHex";
            tbBackgroundColourHex.Size = new System.Drawing.Size(224, 23);
            tbBackgroundColourHex.TabIndex = 2;
            tbBackgroundColourHex.TextChanged += tbBackgroundColourHex_TextChanged;
            // 
            // chkShowBackgroundImage
            // 
            chkShowBackgroundImage.AutoSize = true;
            chkShowBackgroundImage.Location = new System.Drawing.Point(11, 36);
            chkShowBackgroundImage.Name = "chkShowBackgroundImage";
            chkShowBackgroundImage.Size = new System.Drawing.Size(225, 19);
            chkShowBackgroundImage.TabIndex = 3;
            chkShowBackgroundImage.Text = "Show background images (wallpaper)";
            chkShowBackgroundImage.UseVisualStyleBackColor = true;
            chkShowBackgroundImage.CheckedChanged += chkShowBackgroundImage_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(33, 62);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(78, 15);
            label2.TabIndex = 4;
            label2.Text = "Image source";
            // 
            // cmbBackgroundImageSource
            // 
            cmbBackgroundImageSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbBackgroundImageSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbBackgroundImageSource.FormattingEnabled = true;
            cmbBackgroundImageSource.Items.AddRange(new object[] { "Local directory", "Bing Daily Images" });
            cmbBackgroundImageSource.Location = new System.Drawing.Point(246, 62);
            cmbBackgroundImageSource.Name = "cmbBackgroundImageSource";
            cmbBackgroundImageSource.Size = new System.Drawing.Size(254, 23);
            cmbBackgroundImageSource.TabIndex = 5;
            cmbBackgroundImageSource.SelectedIndexChanged += cmbBackgroundImageSource_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(33, 93);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(128, 15);
            label3.TabIndex = 6;
            label3.Text = "Picture change interval";
            // 
            // tbPictureChangeInterval
            // 
            tbPictureChangeInterval.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            tbPictureChangeInterval.Location = new System.Drawing.Point(246, 91);
            tbPictureChangeInterval.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            tbPictureChangeInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            tbPictureChangeInterval.Name = "tbPictureChangeInterval";
            tbPictureChangeInterval.Size = new System.Drawing.Size(99, 23);
            tbPictureChangeInterval.TabIndex = 7;
            tbPictureChangeInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            tbPictureChangeInterval.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbBackgroundChangeIntervalUnits
            // 
            cmbBackgroundChangeIntervalUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbBackgroundChangeIntervalUnits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbBackgroundChangeIntervalUnits.FormattingEnabled = true;
            cmbBackgroundChangeIntervalUnits.Items.AddRange(new object[] { "Seconds", "Minutes", "Hours", "Days" });
            cmbBackgroundChangeIntervalUnits.Location = new System.Drawing.Point(351, 91);
            cmbBackgroundChangeIntervalUnits.Name = "cmbBackgroundChangeIntervalUnits";
            cmbBackgroundChangeIntervalUnits.Size = new System.Drawing.Size(149, 23);
            cmbBackgroundChangeIntervalUnits.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(33, 124);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(86, 15);
            label4.TabIndex = 9;
            label4.Text = "Folder location";
            // 
            // tbLocalFolderSourceLocation
            // 
            tbLocalFolderSourceLocation.Location = new System.Drawing.Point(246, 120);
            tbLocalFolderSourceLocation.Name = "tbLocalFolderSourceLocation";
            tbLocalFolderSourceLocation.Size = new System.Drawing.Size(175, 23);
            tbLocalFolderSourceLocation.TabIndex = 10;
            // 
            // btnBackgroundImageFolderBrowse
            // 
            btnBackgroundImageFolderBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBackgroundImageFolderBrowse.Location = new System.Drawing.Point(427, 118);
            btnBackgroundImageFolderBrowse.Name = "btnBackgroundImageFolderBrowse";
            btnBackgroundImageFolderBrowse.Size = new System.Drawing.Size(75, 27);
            btnBackgroundImageFolderBrowse.TabIndex = 11;
            btnBackgroundImageFolderBrowse.Text = "Browse...";
            btnBackgroundImageFolderBrowse.UseVisualStyleBackColor = true;
            btnBackgroundImageFolderBrowse.Click += btnBackgroundImageFolderBrowse_Click;
            // 
            // chkShowIconsOnDesktop
            // 
            chkShowIconsOnDesktop.AutoSize = true;
            chkShowIconsOnDesktop.Location = new System.Drawing.Point(11, 153);
            chkShowIconsOnDesktop.Name = "chkShowIconsOnDesktop";
            chkShowIconsOnDesktop.Size = new System.Drawing.Size(255, 19);
            chkShowIconsOnDesktop.TabIndex = 12;
            chkShowIconsOnDesktop.Text = "Show Windows Desktop items on Workarea";
            chkShowIconsOnDesktop.UseVisualStyleBackColor = true;
            // 
            // clrDlgPickBackgroundColour
            // 
            clrDlgPickBackgroundColour.AnyColor = true;
            clrDlgPickBackgroundColour.Color = System.Drawing.Color.SteelBlue;
            clrDlgPickBackgroundColour.FullOpen = true;
            // 
            // fbdFolders
            // 
            fbdFolders.AddToRecent = false;
            fbdFolders.OkRequiresInteraction = true;
            fbdFolders.ShowNewFolderButton = false;
            // 
            // WorkspaceAreaSettingsPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            Controls.Add(chkShowIconsOnDesktop);
            Controls.Add(btnBackgroundImageFolderBrowse);
            Controls.Add(tbLocalFolderSourceLocation);
            Controls.Add(label4);
            Controls.Add(cmbBackgroundChangeIntervalUnits);
            Controls.Add(tbPictureChangeInterval);
            Controls.Add(label3);
            Controls.Add(cmbBackgroundImageSource);
            Controls.Add(label2);
            Controls.Add(chkShowBackgroundImage);
            Controls.Add(tbBackgroundColourHex);
            Controls.Add(pbBackgroundColour);
            Controls.Add(label1);
            ForeColor = System.Drawing.Color.White;
            Name = "WorkspaceAreaSettingsPage";
            Size = new System.Drawing.Size(524, 494);
            ((System.ComponentModel.ISupportInitialize)pbBackgroundColour).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbPictureChangeInterval).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbBackgroundColour;
        private System.Windows.Forms.TextBox tbBackgroundColourHex;
        private System.Windows.Forms.CheckBox chkShowBackgroundImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBackgroundImageSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tbPictureChangeInterval;
        private System.Windows.Forms.ComboBox cmbBackgroundChangeIntervalUnits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLocalFolderSourceLocation;
        private System.Windows.Forms.Button btnBackgroundImageFolderBrowse;
        private System.Windows.Forms.CheckBox chkShowIconsOnDesktop;
        private System.Windows.Forms.ColorDialog clrDlgPickBackgroundColour;
        private System.Windows.Forms.FolderBrowserDialog fbdFolders;
    }
}
