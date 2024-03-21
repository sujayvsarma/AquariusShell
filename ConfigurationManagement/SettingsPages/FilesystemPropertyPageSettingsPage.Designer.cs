namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    partial class FilesystemPropertyPageSettingsPage
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
            chkDeletePermanent = new System.Windows.Forms.CheckBox();
            chkFormatUsb = new System.Windows.Forms.CheckBox();
            chkFormatAny = new System.Windows.Forms.CheckBox();
            chkChangeCompression = new System.Windows.Forms.CheckBox();
            chkChangeAttributes = new System.Windows.Forms.CheckBox();
            chkUnblock = new System.Windows.Forms.CheckBox();
            chkCopy = new System.Windows.Forms.CheckBox();
            chkDelete = new System.Windows.Forms.CheckBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            chkAllowRename = new System.Windows.Forms.CheckBox();
            chkTakeDiskOffline = new System.Windows.Forms.CheckBox();
            chkModifyBitlocker = new System.Windows.Forms.CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkDeletePermanent);
            groupBox1.Controls.Add(chkChangeCompression);
            groupBox1.Controls.Add(chkAllowRename);
            groupBox1.Controls.Add(chkChangeAttributes);
            groupBox1.Controls.Add(chkUnblock);
            groupBox1.Controls.Add(chkCopy);
            groupBox1.Controls.Add(chkDelete);
            groupBox1.ForeColor = System.Drawing.Color.White;
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(498, 214);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Directories or files";
            // 
            // chkDeletePermanent
            // 
            chkDeletePermanent.AutoSize = true;
            chkDeletePermanent.Location = new System.Drawing.Point(37, 50);
            chkDeletePermanent.Name = "chkDeletePermanent";
            chkDeletePermanent.Size = new System.Drawing.Size(322, 19);
            chkDeletePermanent.TabIndex = 0;
            chkDeletePermanent.Text = "Permanently delete item (hold SHIFT key when deleting)";
            chkDeletePermanent.UseVisualStyleBackColor = true;
            // 
            // chkFormatUsb
            // 
            chkFormatUsb.AutoSize = true;
            chkFormatUsb.Location = new System.Drawing.Point(37, 49);
            chkFormatUsb.Name = "chkFormatUsb";
            chkFormatUsb.Size = new System.Drawing.Size(242, 19);
            chkFormatUsb.TabIndex = 0;
            chkFormatUsb.Text = "Format removable drives (eg: USB drives)";
            chkFormatUsb.UseVisualStyleBackColor = true;
            // 
            // chkFormatAny
            // 
            chkFormatAny.AutoSize = true;
            chkFormatAny.Location = new System.Drawing.Point(19, 24);
            chkFormatAny.Name = "chkFormatAny";
            chkFormatAny.Size = new System.Drawing.Size(115, 19);
            chkFormatAny.TabIndex = 0;
            chkFormatAny.Text = "Format any drive";
            chkFormatAny.UseVisualStyleBackColor = true;
            // 
            // chkChangeCompression
            // 
            chkChangeCompression.AutoSize = true;
            chkChangeCompression.Location = new System.Drawing.Point(19, 125);
            chkChangeCompression.Name = "chkChangeCompression";
            chkChangeCompression.Size = new System.Drawing.Size(256, 19);
            chkChangeCompression.TabIndex = 0;
            chkChangeCompression.Text = "Compress or uncompress a file (NTFS only!)";
            chkChangeCompression.UseVisualStyleBackColor = true;
            // 
            // chkChangeAttributes
            // 
            chkChangeAttributes.AutoSize = true;
            chkChangeAttributes.Location = new System.Drawing.Point(19, 150);
            chkChangeAttributes.Name = "chkChangeAttributes";
            chkChangeAttributes.Size = new System.Drawing.Size(203, 19);
            chkChangeAttributes.TabIndex = 0;
            chkChangeAttributes.Text = "Change directory or file attributes";
            chkChangeAttributes.UseVisualStyleBackColor = true;
            // 
            // chkUnblock
            // 
            chkUnblock.AutoSize = true;
            chkUnblock.Location = new System.Drawing.Point(19, 100);
            chkUnblock.Name = "chkUnblock";
            chkUnblock.Size = new System.Drawing.Size(318, 19);
            chkUnblock.TabIndex = 0;
            chkUnblock.Text = "Unblocking unsafe files (eg: downloaded from Internet)";
            chkUnblock.UseVisualStyleBackColor = true;
            // 
            // chkCopy
            // 
            chkCopy.AutoSize = true;
            chkCopy.Location = new System.Drawing.Point(19, 75);
            chkCopy.Name = "chkCopy";
            chkCopy.Size = new System.Drawing.Size(137, 19);
            chkCopy.TabIndex = 0;
            chkCopy.Text = "Copy directory or file";
            chkCopy.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            chkDelete.AutoSize = true;
            chkDelete.Location = new System.Drawing.Point(19, 25);
            chkDelete.Name = "chkDelete";
            chkDelete.Size = new System.Drawing.Size(142, 19);
            chkDelete.TabIndex = 0;
            chkDelete.Text = "Delete directory or file";
            chkDelete.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkFormatUsb);
            groupBox2.Controls.Add(chkModifyBitlocker);
            groupBox2.Controls.Add(chkTakeDiskOffline);
            groupBox2.Controls.Add(chkFormatAny);
            groupBox2.ForeColor = System.Drawing.Color.White;
            groupBox2.Location = new System.Drawing.Point(12, 241);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(498, 129);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Disks and drives";
            // 
            // chkAllowRename
            // 
            chkAllowRename.AutoSize = true;
            chkAllowRename.Location = new System.Drawing.Point(19, 175);
            chkAllowRename.Name = "chkAllowRename";
            chkAllowRename.Size = new System.Drawing.Size(179, 19);
            chkAllowRename.TabIndex = 0;
            chkAllowRename.Text = "Rename disk, directory or file";
            chkAllowRename.UseVisualStyleBackColor = true;
            // 
            // chkTakeDiskOffline
            // 
            chkTakeDiskOffline.AutoSize = true;
            chkTakeDiskOffline.Location = new System.Drawing.Point(19, 74);
            chkTakeDiskOffline.Name = "chkTakeDiskOffline";
            chkTakeDiskOffline.Size = new System.Drawing.Size(86, 19);
            chkTakeDiskOffline.TabIndex = 0;
            chkTakeDiskOffline.Text = "Take offline";
            chkTakeDiskOffline.UseVisualStyleBackColor = true;
            // 
            // chkModifyBitlocker
            // 
            chkModifyBitlocker.AutoSize = true;
            chkModifyBitlocker.Location = new System.Drawing.Point(19, 99);
            chkModifyBitlocker.Name = "chkModifyBitlocker";
            chkModifyBitlocker.Size = new System.Drawing.Size(160, 19);
            chkModifyBitlocker.TabIndex = 0;
            chkModifyBitlocker.Text = "Modify BitLocker settings";
            chkModifyBitlocker.UseVisualStyleBackColor = true;
            // 
            // FilesystemPropertyPageSettingsPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            ForeColor = System.Drawing.Color.White;
            Name = "FilesystemPropertyPageSettingsPage";
            Size = new System.Drawing.Size(524, 494);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkDeletePermanent;
        private System.Windows.Forms.CheckBox chkChangeCompression;
        private System.Windows.Forms.CheckBox chkChangeAttributes;
        private System.Windows.Forms.CheckBox chkUnblock;
        private System.Windows.Forms.CheckBox chkCopy;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkFormatUsb;
        private System.Windows.Forms.CheckBox chkFormatAny;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAllowRename;
        private System.Windows.Forms.CheckBox chkModifyBitlocker;
        private System.Windows.Forms.CheckBox chkTakeDiskOffline;
    }
}
