namespace AquariusShell.Forms
{
    partial class DriveProperties
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
            pbDriveTypeIcon = new System.Windows.Forms.PictureBox();
            horizontalLine1 = new Controls.HorizontalLine();
            basicInfoLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            lblTypeName = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            lblDriveLetter = new System.Windows.Forms.Label();
            lblDriveFormat = new System.Windows.Forms.Label();
            lblTotalSize = new System.Windows.Forms.Label();
            lblTotalFreeSpace = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            lblAvailableSpace = new System.Windows.Forms.Label();
            lblDriveLabel = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            btnInvokeRenameVolume = new System.Windows.Forms.Button();
            btnInvokeDefrag = new System.Windows.Forms.Button();
            btnInvokeCheckdisk = new System.Windows.Forms.Button();
            btnInvokeTakeOffline = new System.Windows.Forms.Button();
            btnManageSecurity = new System.Windows.Forms.Button();
            btnInvokeManageBitlocker = new System.Windows.Forms.Button();
            btnInvokeFormatDisk = new System.Windows.Forms.Button();
            prgDriveSpaceUsage = new System.Windows.Forms.ProgressBar();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pbDriveTypeIcon).BeginInit();
            basicInfoLayoutTable.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pbDriveTypeIcon
            // 
            pbDriveTypeIcon.Location = new System.Drawing.Point(7, 7);
            pbDriveTypeIcon.Name = "pbDriveTypeIcon";
            pbDriveTypeIcon.Size = new System.Drawing.Size(32, 32);
            pbDriveTypeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbDriveTypeIcon.TabIndex = 12;
            pbDriveTypeIcon.TabStop = false;
            // 
            // horizontalLine1
            // 
            horizontalLine1.BackColor = System.Drawing.SystemColors.ControlText;
            horizontalLine1.Location = new System.Drawing.Point(0, 44);
            horizontalLine1.Name = "horizontalLine1";
            horizontalLine1.Size = new System.Drawing.Size(418, 1);
            horizontalLine1.TabIndex = 13;
            // 
            // basicInfoLayoutTable
            // 
            basicInfoLayoutTable.AutoSize = true;
            basicInfoLayoutTable.ColumnCount = 2;
            basicInfoLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.87685F));
            basicInfoLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.12315F));
            basicInfoLayoutTable.Controls.Add(lblTypeName, 1, 1);
            basicInfoLayoutTable.Controls.Add(label1, 0, 0);
            basicInfoLayoutTable.Controls.Add(label2, 0, 1);
            basicInfoLayoutTable.Controls.Add(label5, 0, 2);
            basicInfoLayoutTable.Controls.Add(label6, 0, 3);
            basicInfoLayoutTable.Controls.Add(label7, 0, 4);
            basicInfoLayoutTable.Controls.Add(lblDriveLetter, 1, 0);
            basicInfoLayoutTable.Controls.Add(lblDriveFormat, 1, 2);
            basicInfoLayoutTable.Controls.Add(lblTotalSize, 1, 3);
            basicInfoLayoutTable.Controls.Add(lblTotalFreeSpace, 1, 4);
            basicInfoLayoutTable.Controls.Add(label3, 0, 5);
            basicInfoLayoutTable.Controls.Add(lblAvailableSpace, 1, 5);
            basicInfoLayoutTable.Location = new System.Drawing.Point(7, 51);
            basicInfoLayoutTable.Name = "basicInfoLayoutTable";
            basicInfoLayoutTable.RowCount = 6;
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            basicInfoLayoutTable.Size = new System.Drawing.Size(406, 154);
            basicInfoLayoutTable.TabIndex = 14;
            // 
            // lblTypeName
            // 
            lblTypeName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblTypeName.AutoEllipsis = true;
            lblTypeName.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblTypeName.Location = new System.Drawing.Point(104, 27);
            lblTypeName.Name = "lblTypeName";
            lblTypeName.Size = new System.Drawing.Size(296, 20);
            lblTypeName.TabIndex = 9;
            lblTypeName.Text = "Fixed drive";
            lblTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label1.Location = new System.Drawing.Point(3, 2);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 20);
            label1.TabIndex = 1;
            label1.Text = "Drive letter";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label2.Location = new System.Drawing.Point(3, 27);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(83, 20);
            label2.TabIndex = 2;
            label2.Text = "Type";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label5.Location = new System.Drawing.Point(3, 52);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(83, 20);
            label5.TabIndex = 5;
            label5.Text = "Format";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label6.Location = new System.Drawing.Point(3, 77);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(83, 20);
            label6.TabIndex = 6;
            label6.Text = "Total size";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label7.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label7.Location = new System.Drawing.Point(3, 102);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(95, 20);
            label7.TabIndex = 7;
            label7.Text = "Total free space";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDriveLetter
            // 
            lblDriveLetter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblDriveLetter.AutoEllipsis = true;
            lblDriveLetter.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblDriveLetter.Location = new System.Drawing.Point(104, 2);
            lblDriveLetter.Name = "lblDriveLetter";
            lblDriveLetter.Size = new System.Drawing.Size(296, 20);
            lblDriveLetter.TabIndex = 8;
            lblDriveLetter.Text = "C:";
            lblDriveLetter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDriveFormat
            // 
            lblDriveFormat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblDriveFormat.AutoEllipsis = true;
            lblDriveFormat.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblDriveFormat.Location = new System.Drawing.Point(104, 52);
            lblDriveFormat.Name = "lblDriveFormat";
            lblDriveFormat.Size = new System.Drawing.Size(296, 20);
            lblDriveFormat.TabIndex = 11;
            lblDriveFormat.Text = "NTFS";
            lblDriveFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalSize
            // 
            lblTotalSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblTotalSize.AutoEllipsis = true;
            lblTotalSize.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblTotalSize.Location = new System.Drawing.Point(104, 77);
            lblTotalSize.Name = "lblTotalSize";
            lblTotalSize.Size = new System.Drawing.Size(296, 20);
            lblTotalSize.TabIndex = 12;
            lblTotalSize.Text = "1 TB";
            lblTotalSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalFreeSpace
            // 
            lblTotalFreeSpace.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblTotalFreeSpace.AutoEllipsis = true;
            lblTotalFreeSpace.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblTotalFreeSpace.Location = new System.Drawing.Point(104, 102);
            lblTotalFreeSpace.Name = "lblTotalFreeSpace";
            lblTotalFreeSpace.Size = new System.Drawing.Size(296, 20);
            lblTotalFreeSpace.TabIndex = 13;
            lblTotalFreeSpace.Text = "500 GB";
            lblTotalFreeSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label3.Location = new System.Drawing.Point(3, 129);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(95, 20);
            label3.TabIndex = 7;
            label3.Text = "Available space";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAvailableSpace
            // 
            lblAvailableSpace.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblAvailableSpace.AutoEllipsis = true;
            lblAvailableSpace.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblAvailableSpace.Location = new System.Drawing.Point(104, 129);
            lblAvailableSpace.Name = "lblAvailableSpace";
            lblAvailableSpace.Size = new System.Drawing.Size(296, 20);
            lblAvailableSpace.TabIndex = 13;
            lblAvailableSpace.Text = "450 GB";
            lblAvailableSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDriveLabel
            // 
            lblDriveLabel.AutoEllipsis = true;
            lblDriveLabel.Location = new System.Drawing.Point(42, 7);
            lblDriveLabel.Name = "lblDriveLabel";
            lblDriveLabel.Size = new System.Drawing.Size(366, 32);
            lblDriveLabel.TabIndex = 15;
            lblDriveLabel.Text = "Noname";
            lblDriveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnInvokeRenameVolume);
            groupBox1.Controls.Add(btnInvokeDefrag);
            groupBox1.Controls.Add(btnInvokeCheckdisk);
            groupBox1.Controls.Add(btnInvokeTakeOffline);
            groupBox1.Controls.Add(btnManageSecurity);
            groupBox1.Controls.Add(btnInvokeManageBitlocker);
            groupBox1.Controls.Add(btnInvokeFormatDisk);
            groupBox1.ForeColor = System.Drawing.Color.White;
            groupBox1.Location = new System.Drawing.Point(7, 277);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(405, 100);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tools";
            // 
            // btnInvokeRenameVolume
            // 
            btnInvokeRenameVolume.BackColor = System.Drawing.Color.SteelBlue;
            btnInvokeRenameVolume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnInvokeRenameVolume.Location = new System.Drawing.Point(240, 30);
            btnInvokeRenameVolume.Name = "btnInvokeRenameVolume";
            btnInvokeRenameVolume.Size = new System.Drawing.Size(75, 23);
            btnInvokeRenameVolume.TabIndex = 0;
            btnInvokeRenameVolume.Text = "Re&name";
            btnInvokeRenameVolume.UseVisualStyleBackColor = false;
            btnInvokeRenameVolume.Click += btnInvokeRenameVolume_Click;
            // 
            // btnInvokeDefrag
            // 
            btnInvokeDefrag.BackColor = System.Drawing.Color.SteelBlue;
            btnInvokeDefrag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnInvokeDefrag.Location = new System.Drawing.Point(159, 30);
            btnInvokeDefrag.Name = "btnInvokeDefrag";
            btnInvokeDefrag.Size = new System.Drawing.Size(75, 23);
            btnInvokeDefrag.TabIndex = 0;
            btnInvokeDefrag.Text = "D&efrag";
            btnInvokeDefrag.UseVisualStyleBackColor = false;
            btnInvokeDefrag.Click += btnInvokeDefrag_Click;
            // 
            // btnInvokeCheckdisk
            // 
            btnInvokeCheckdisk.BackColor = System.Drawing.Color.SteelBlue;
            btnInvokeCheckdisk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnInvokeCheckdisk.Location = new System.Drawing.Point(78, 30);
            btnInvokeCheckdisk.Name = "btnInvokeCheckdisk";
            btnInvokeCheckdisk.Size = new System.Drawing.Size(75, 23);
            btnInvokeCheckdisk.TabIndex = 0;
            btnInvokeCheckdisk.Text = "C&heck disk";
            btnInvokeCheckdisk.UseVisualStyleBackColor = false;
            btnInvokeCheckdisk.Click += btnInvokeCheckdisk_Click;
            // 
            // btnInvokeTakeOffline
            // 
            btnInvokeTakeOffline.BackColor = System.Drawing.Color.SteelBlue;
            btnInvokeTakeOffline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnInvokeTakeOffline.Location = new System.Drawing.Point(33, 59);
            btnInvokeTakeOffline.Name = "btnInvokeTakeOffline";
            btnInvokeTakeOffline.Size = new System.Drawing.Size(75, 23);
            btnInvokeTakeOffline.TabIndex = 0;
            btnInvokeTakeOffline.Text = "O&ffline";
            btnInvokeTakeOffline.UseVisualStyleBackColor = false;
            btnInvokeTakeOffline.Click += btnInvokeTakeOffline_Click;
            // 
            // btnManageSecurity
            // 
            btnManageSecurity.BackColor = System.Drawing.Color.SteelBlue;
            btnManageSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnManageSecurity.Location = new System.Drawing.Point(276, 59);
            btnManageSecurity.Name = "btnManageSecurity";
            btnManageSecurity.Size = new System.Drawing.Size(75, 23);
            btnManageSecurity.TabIndex = 0;
            btnManageSecurity.Text = "&Security...";
            btnManageSecurity.UseVisualStyleBackColor = false;
            btnManageSecurity.Click += btnInvokeManageSecurity_Click;
            // 
            // btnInvokeManageBitlocker
            // 
            btnInvokeManageBitlocker.BackColor = System.Drawing.Color.SteelBlue;
            btnInvokeManageBitlocker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnInvokeManageBitlocker.Location = new System.Drawing.Point(195, 59);
            btnInvokeManageBitlocker.Name = "btnInvokeManageBitlocker";
            btnInvokeManageBitlocker.Size = new System.Drawing.Size(75, 23);
            btnInvokeManageBitlocker.TabIndex = 0;
            btnInvokeManageBitlocker.Text = "&Bitlocker";
            btnInvokeManageBitlocker.UseVisualStyleBackColor = false;
            btnInvokeManageBitlocker.Click += btnInvokeManageBitlocker_Click;
            // 
            // btnInvokeFormatDisk
            // 
            btnInvokeFormatDisk.BackColor = System.Drawing.Color.SteelBlue;
            btnInvokeFormatDisk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnInvokeFormatDisk.Location = new System.Drawing.Point(114, 59);
            btnInvokeFormatDisk.Name = "btnInvokeFormatDisk";
            btnInvokeFormatDisk.Size = new System.Drawing.Size(75, 23);
            btnInvokeFormatDisk.TabIndex = 0;
            btnInvokeFormatDisk.Text = "F&ormat";
            btnInvokeFormatDisk.UseVisualStyleBackColor = false;
            btnInvokeFormatDisk.Click += btnInvokeFormatDisk_Click;
            // 
            // prgDriveSpaceUsage
            // 
            prgDriveSpaceUsage.Location = new System.Drawing.Point(7, 237);
            prgDriveSpaceUsage.Name = "prgDriveSpaceUsage";
            prgDriveSpaceUsage.Size = new System.Drawing.Size(405, 25);
            prgDriveSpaceUsage.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            prgDriveSpaceUsage.TabIndex = 17;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label4.Location = new System.Drawing.Point(7, 214);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(405, 20);
            label4.TabIndex = 7;
            label4.Text = "Drive space usage";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DriveProperties
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            ClientSize = new System.Drawing.Size(420, 386);
            Controls.Add(prgDriveSpaceUsage);
            Controls.Add(groupBox1);
            Controls.Add(lblDriveLabel);
            Controls.Add(basicInfoLayoutTable);
            Controls.Add(horizontalLine1);
            Controls.Add(pbDriveTypeIcon);
            Controls.Add(label4);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DriveProperties";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Properties";
            ((System.ComponentModel.ISupportInitialize)pbDriveTypeIcon).EndInit();
            basicInfoLayoutTable.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pbDriveTypeIcon;
        private Controls.HorizontalLine horizontalLine1;
        private System.Windows.Forms.TableLayoutPanel basicInfoLayoutTable;
        private System.Windows.Forms.Label lblTypeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDriveLetter;
        private System.Windows.Forms.Label lblDriveFormat;
        private System.Windows.Forms.Label lblTotalSize;
        private System.Windows.Forms.Label lblTotalFreeSpace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAvailableSpace;
        private System.Windows.Forms.Label lblDriveLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInvokeCheckdisk;
        private System.Windows.Forms.Button btnInvokeFormatDisk;
        private System.Windows.Forms.Button btnInvokeRenameVolume;
        private System.Windows.Forms.Button btnInvokeDefrag;
        private System.Windows.Forms.Button btnInvokeManageBitlocker;
        private System.Windows.Forms.ProgressBar prgDriveSpaceUsage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnInvokeTakeOffline;
        private System.Windows.Forms.Button btnManageSecurity;
    }
}