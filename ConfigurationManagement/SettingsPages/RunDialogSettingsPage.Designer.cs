namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    partial class RunDialogSettingsPage
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
            tbLauncherCaption = new System.Windows.Forms.TextBox();
            pbLauncherIcon = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            chkShowAppOnLauncher = new System.Windows.Forms.CheckBox();
            ofdFindLauncherIcon = new System.Windows.Forms.OpenFileDialog();
            chkStoreMRU = new System.Windows.Forms.CheckBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            chkMRUIsReadonly = new System.Windows.Forms.CheckBox();
            chkShowBrowseButton = new System.Windows.Forms.CheckBox();
            mngLstNeverStoreUri = new Controls.ManageableStringItemsListbox();
            mngLstAlwaysAppendUri = new Controls.ManageableStringItemsListbox();
            tbMaxUriLength = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pbLauncherIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbMaxUriLength).BeginInit();
            SuspendLayout();
            // 
            // tbLauncherCaption
            // 
            tbLauncherCaption.Location = new System.Drawing.Point(70, 49);
            tbLauncherCaption.Name = "tbLauncherCaption";
            tbLauncherCaption.Size = new System.Drawing.Size(434, 23);
            tbLauncherCaption.TabIndex = 19;
            // 
            // pbLauncherIcon
            // 
            pbLauncherIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pbLauncherIcon.Location = new System.Drawing.Point(31, 49);
            pbLauncherIcon.Name = "pbLauncherIcon";
            pbLauncherIcon.Size = new System.Drawing.Size(24, 24);
            pbLauncherIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbLauncherIcon.TabIndex = 17;
            pbLauncherIcon.TabStop = false;
            pbLauncherIcon.Click += pbLauncherIcon_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(70, 29);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(49, 15);
            label1.TabIndex = 15;
            label1.Text = "Caption";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(26, 29);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(30, 15);
            label2.TabIndex = 16;
            label2.Text = "Icon";
            // 
            // chkShowAppOnLauncher
            // 
            chkShowAppOnLauncher.AutoSize = true;
            chkShowAppOnLauncher.Location = new System.Drawing.Point(7, 8);
            chkShowAppOnLauncher.Name = "chkShowAppOnLauncher";
            chkShowAppOnLauncher.Size = new System.Drawing.Size(266, 19);
            chkShowAppOnLauncher.TabIndex = 13;
            chkShowAppOnLauncher.Text = "Show the 'Run' app on the Program Launcher";
            chkShowAppOnLauncher.UseVisualStyleBackColor = true;
            // 
            // ofdFindLauncherIcon
            // 
            ofdFindLauncherIcon.Filter = "All supported types (*.jpg,*.png,*.ico)|*.jpg;*.png;*.ico";
            ofdFindLauncherIcon.OkRequiresInteraction = true;
            ofdFindLauncherIcon.RestoreDirectory = true;
            ofdFindLauncherIcon.ShowPreview = true;
            ofdFindLauncherIcon.SupportMultiDottedExtensions = true;
            // 
            // chkStoreMRU
            // 
            chkStoreMRU.AutoSize = true;
            chkStoreMRU.Location = new System.Drawing.Point(7, 106);
            chkStoreMRU.Name = "chkStoreMRU";
            chkStoreMRU.Size = new System.Drawing.Size(248, 19);
            chkStoreMRU.TabIndex = 20;
            chkStoreMRU.Text = "Store and show previously run commands";
            chkStoreMRU.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(24, 157);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(198, 15);
            label3.TabIndex = 21;
            label3.Text = "Maximum number of items to show";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(24, 181);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(152, 15);
            label4.TabIndex = 21;
            label4.Text = "Never store these addresses";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(24, 330);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(160, 15);
            label5.TabIndex = 21;
            label5.Text = "Always show these addresses";
            // 
            // chkMRUIsReadonly
            // 
            chkMRUIsReadonly.AutoSize = true;
            chkMRUIsReadonly.Location = new System.Drawing.Point(26, 131);
            chkMRUIsReadonly.Name = "chkMRUIsReadonly";
            chkMRUIsReadonly.Size = new System.Drawing.Size(304, 19);
            chkMRUIsReadonly.TabIndex = 23;
            chkMRUIsReadonly.Text = "Force pick from existing addresses (read-only listing)";
            chkMRUIsReadonly.UseVisualStyleBackColor = true;
            // 
            // chkShowBrowseButton
            // 
            chkShowBrowseButton.AutoSize = true;
            chkShowBrowseButton.Location = new System.Drawing.Point(7, 81);
            chkShowBrowseButton.Name = "chkShowBrowseButton";
            chkShowBrowseButton.Size = new System.Drawing.Size(192, 19);
            chkShowBrowseButton.TabIndex = 23;
            chkShowBrowseButton.Text = "Allow user to browse and select";
            chkShowBrowseButton.UseVisualStyleBackColor = true;
            // 
            // mngLstNeverStoreUri
            // 
            mngLstNeverStoreUri.BackColor = System.Drawing.Color.SteelBlue;
            mngLstNeverStoreUri.ForeColor = System.Drawing.Color.White;
            mngLstNeverStoreUri.KeepItemsUnique = true;
            mngLstNeverStoreUri.Location = new System.Drawing.Point(24, 195);
            mngLstNeverStoreUri.Name = "mngLstNeverStoreUri";
            mngLstNeverStoreUri.Size = new System.Drawing.Size(480, 127);
            mngLstNeverStoreUri.TabIndex = 24;
            // 
            // mngLstAlwaysAppendUri
            // 
            mngLstAlwaysAppendUri.BackColor = System.Drawing.Color.SteelBlue;
            mngLstAlwaysAppendUri.ForeColor = System.Drawing.Color.White;
            mngLstAlwaysAppendUri.KeepItemsUnique = true;
            mngLstAlwaysAppendUri.Location = new System.Drawing.Point(26, 348);
            mngLstAlwaysAppendUri.Name = "mngLstAlwaysAppendUri";
            mngLstAlwaysAppendUri.Size = new System.Drawing.Size(480, 123);
            mngLstAlwaysAppendUri.TabIndex = 24;
            // 
            // tbMaxUriLength
            // 
            tbMaxUriLength.Location = new System.Drawing.Point(413, 155);
            tbMaxUriLength.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            tbMaxUriLength.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            tbMaxUriLength.Name = "tbMaxUriLength";
            tbMaxUriLength.Size = new System.Drawing.Size(91, 23);
            tbMaxUriLength.TabIndex = 25;
            tbMaxUriLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            tbMaxUriLength.ValueChanged += tbMaxUriLength_ValueChanged;
            // 
            // RunDialogSettingsPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            Controls.Add(tbMaxUriLength);
            Controls.Add(mngLstAlwaysAppendUri);
            Controls.Add(mngLstNeverStoreUri);
            Controls.Add(chkShowBrowseButton);
            Controls.Add(chkMRUIsReadonly);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(chkStoreMRU);
            Controls.Add(tbLauncherCaption);
            Controls.Add(pbLauncherIcon);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(chkShowAppOnLauncher);
            ForeColor = System.Drawing.Color.White;
            Name = "RunDialogSettingsPage";
            Size = new System.Drawing.Size(524, 494);
            ((System.ComponentModel.ISupportInitialize)pbLauncherIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbMaxUriLength).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox tbLauncherCaption;
        private System.Windows.Forms.PictureBox pbLauncherIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkShowAppOnLauncher;
        private System.Windows.Forms.OpenFileDialog ofdFindLauncherIcon;
        private System.Windows.Forms.CheckBox chkStoreMRU;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkMRUIsReadonly;
        private System.Windows.Forms.CheckBox chkShowBrowseButton;
        private Controls.ManageableStringItemsListbox mngLstNeverStoreUri;
        private Controls.ManageableStringItemsListbox mngLstAlwaysAppendUri;
        private System.Windows.Forms.NumericUpDown tbMaxUriLength;
    }
}
