namespace AquariusShell.Forms
{
    partial class FileEntryProperties
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
            horizontalLine1 = new Controls.HorizontalLine();
            lblFileNameWithoutExtension = new System.Windows.Forms.Label();
            pbFileTypeIcon = new System.Windows.Forms.PictureBox();
            sfdFileCopyMoveDestinationPicker = new System.Windows.Forms.SaveFileDialog();
            tbProperties = new System.Windows.Forms.TabControl();
            tpGeneral = new System.Windows.Forms.TabPage();
            btnUnblockFileOrManageAcl = new System.Windows.Forms.Button();
            btnCopyFile = new System.Windows.Forms.Button();
            btnMoveFile = new System.Windows.Forms.Button();
            btnDeleteFile = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            layoutAttributesList = new System.Windows.Forms.FlowLayoutPanel();
            basicInfoLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            lblSize = new System.Windows.Forms.Label();
            lblTypeName = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            lblLocation = new System.Windows.Forms.Label();
            lblCreated = new System.Windows.Forms.Label();
            lblLastModified = new System.Windows.Forms.Label();
            lblLastAccessed = new System.Windows.Forms.Label();
            tpMetadata = new System.Windows.Forms.TabPage();
            lvMetadata = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)pbFileTypeIcon).BeginInit();
            tbProperties.SuspendLayout();
            tpGeneral.SuspendLayout();
            groupBox1.SuspendLayout();
            basicInfoLayoutTable.SuspendLayout();
            tpMetadata.SuspendLayout();
            SuspendLayout();
            // 
            // horizontalLine1
            // 
            horizontalLine1.BackColor = System.Drawing.SystemColors.ControlText;
            horizontalLine1.Location = new System.Drawing.Point(-1, 42);
            horizontalLine1.Name = "horizontalLine1";
            horizontalLine1.Size = new System.Drawing.Size(418, 1);
            horizontalLine1.TabIndex = 0;
            // 
            // lblFileNameWithoutExtension
            // 
            lblFileNameWithoutExtension.AutoEllipsis = true;
            lblFileNameWithoutExtension.Location = new System.Drawing.Point(42, 4);
            lblFileNameWithoutExtension.Name = "lblFileNameWithoutExtension";
            lblFileNameWithoutExtension.Size = new System.Drawing.Size(366, 32);
            lblFileNameWithoutExtension.TabIndex = 1;
            lblFileNameWithoutExtension.Text = "Noname";
            lblFileNameWithoutExtension.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbFileTypeIcon
            // 
            pbFileTypeIcon.Location = new System.Drawing.Point(7, 4);
            pbFileTypeIcon.Name = "pbFileTypeIcon";
            pbFileTypeIcon.Size = new System.Drawing.Size(32, 32);
            pbFileTypeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbFileTypeIcon.TabIndex = 10;
            pbFileTypeIcon.TabStop = false;
            // 
            // sfdFileCopyMoveDestinationPicker
            // 
            sfdFileCopyMoveDestinationPicker.AddToRecent = false;
            sfdFileCopyMoveDestinationPicker.ExpandedMode = false;
            sfdFileCopyMoveDestinationPicker.Filter = "All files (*.*)|*.*";
            sfdFileCopyMoveDestinationPicker.OkRequiresInteraction = true;
            sfdFileCopyMoveDestinationPicker.SupportMultiDottedExtensions = true;
            sfdFileCopyMoveDestinationPicker.Title = "Select the destination location";
            // 
            // tbProperties
            // 
            tbProperties.Controls.Add(tpGeneral);
            tbProperties.Controls.Add(tpMetadata);
            tbProperties.Location = new System.Drawing.Point(6, 49);
            tbProperties.Name = "tbProperties";
            tbProperties.SelectedIndex = 0;
            tbProperties.Size = new System.Drawing.Size(411, 416);
            tbProperties.TabIndex = 13;
            // 
            // tpGeneral
            // 
            tpGeneral.BackColor = System.Drawing.Color.SteelBlue;
            tpGeneral.Controls.Add(btnUnblockFileOrManageAcl);
            tpGeneral.Controls.Add(btnCopyFile);
            tpGeneral.Controls.Add(btnMoveFile);
            tpGeneral.Controls.Add(btnDeleteFile);
            tpGeneral.Controls.Add(groupBox1);
            tpGeneral.Controls.Add(basicInfoLayoutTable);
            tpGeneral.Location = new System.Drawing.Point(4, 24);
            tpGeneral.Name = "tpGeneral";
            tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            tpGeneral.Size = new System.Drawing.Size(403, 388);
            tpGeneral.TabIndex = 0;
            tpGeneral.Text = "General";
            // 
            // btnUnblockFileOrManageAcl
            // 
            btnUnblockFileOrManageAcl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUnblockFileOrManageAcl.Location = new System.Drawing.Point(312, 352);
            btnUnblockFileOrManageAcl.Name = "btnUnblockFileOrManageAcl";
            btnUnblockFileOrManageAcl.Size = new System.Drawing.Size(86, 30);
            btnUnblockFileOrManageAcl.TabIndex = 14;
            btnUnblockFileOrManageAcl.Text = "&Unblock";
            btnUnblockFileOrManageAcl.UseVisualStyleBackColor = true;
            btnUnblockFileOrManageAcl.Click += btnUnblockFileOrManageAcl_Click;
            // 
            // btnCopyFile
            // 
            btnCopyFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCopyFile.Location = new System.Drawing.Point(170, 352);
            btnCopyFile.Name = "btnCopyFile";
            btnCopyFile.Size = new System.Drawing.Size(75, 30);
            btnCopyFile.TabIndex = 15;
            btnCopyFile.Text = "C&opy";
            btnCopyFile.UseVisualStyleBackColor = true;
            // 
            // btnMoveFile
            // 
            btnMoveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMoveFile.Location = new System.Drawing.Point(89, 352);
            btnMoveFile.Name = "btnMoveFile";
            btnMoveFile.Size = new System.Drawing.Size(75, 30);
            btnMoveFile.TabIndex = 16;
            btnMoveFile.Text = "&Move";
            btnMoveFile.UseVisualStyleBackColor = true;
            // 
            // btnDeleteFile
            // 
            btnDeleteFile.BackColor = System.Drawing.Color.Red;
            btnDeleteFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDeleteFile.ForeColor = System.Drawing.Color.White;
            btnDeleteFile.Location = new System.Drawing.Point(8, 352);
            btnDeleteFile.Name = "btnDeleteFile";
            btnDeleteFile.Size = new System.Drawing.Size(75, 30);
            btnDeleteFile.TabIndex = 13;
            btnDeleteFile.Text = "D&elete";
            btnDeleteFile.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = System.Drawing.Color.SteelBlue;
            groupBox1.Controls.Add(layoutAttributesList);
            groupBox1.Location = new System.Drawing.Point(-2, 165);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(406, 182);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "File attributes";
            // 
            // layoutAttributesList
            // 
            layoutAttributesList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            layoutAttributesList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            layoutAttributesList.Location = new System.Drawing.Point(8, 18);
            layoutAttributesList.Name = "layoutAttributesList";
            layoutAttributesList.Size = new System.Drawing.Size(392, 158);
            layoutAttributesList.TabIndex = 0;
            layoutAttributesList.WrapContents = false;
            // 
            // basicInfoLayoutTable
            // 
            basicInfoLayoutTable.AutoSize = true;
            basicInfoLayoutTable.ColumnCount = 2;
            basicInfoLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.87685F));
            basicInfoLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.12315F));
            basicInfoLayoutTable.Controls.Add(lblSize, 1, 2);
            basicInfoLayoutTable.Controls.Add(lblTypeName, 1, 1);
            basicInfoLayoutTable.Controls.Add(label1, 0, 0);
            basicInfoLayoutTable.Controls.Add(label2, 0, 1);
            basicInfoLayoutTable.Controls.Add(label4, 0, 2);
            basicInfoLayoutTable.Controls.Add(label5, 0, 3);
            basicInfoLayoutTable.Controls.Add(label6, 0, 4);
            basicInfoLayoutTable.Controls.Add(label7, 0, 5);
            basicInfoLayoutTable.Controls.Add(lblLocation, 1, 0);
            basicInfoLayoutTable.Controls.Add(lblCreated, 1, 3);
            basicInfoLayoutTable.Controls.Add(lblLastModified, 1, 4);
            basicInfoLayoutTable.Controls.Add(lblLastAccessed, 1, 5);
            basicInfoLayoutTable.Location = new System.Drawing.Point(-2, 8);
            basicInfoLayoutTable.Name = "basicInfoLayoutTable";
            basicInfoLayoutTable.RowCount = 6;
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            basicInfoLayoutTable.Size = new System.Drawing.Size(406, 151);
            basicInfoLayoutTable.TabIndex = 10;
            // 
            // lblSize
            // 
            lblSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblSize.AutoEllipsis = true;
            lblSize.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblSize.Location = new System.Drawing.Point(104, 52);
            lblSize.Name = "lblSize";
            lblSize.Size = new System.Drawing.Size(296, 20);
            lblSize.TabIndex = 10;
            lblSize.Text = "1 KB (1,000 bytes)";
            lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            lblTypeName.Text = "Text document (.txt)";
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
            label1.Text = "Location";
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
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label4.Location = new System.Drawing.Point(3, 52);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(83, 20);
            label4.TabIndex = 4;
            label4.Text = "Size";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label5.Location = new System.Drawing.Point(3, 77);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(83, 20);
            label5.TabIndex = 5;
            label5.Text = "Created";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label6.Location = new System.Drawing.Point(3, 102);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(83, 20);
            label6.TabIndex = 6;
            label6.Text = "Last modified";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label7.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label7.Location = new System.Drawing.Point(3, 128);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(83, 20);
            label7.TabIndex = 7;
            label7.Text = "Last accessed";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLocation
            // 
            lblLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblLocation.AutoEllipsis = true;
            lblLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblLocation.Location = new System.Drawing.Point(104, 2);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new System.Drawing.Size(296, 20);
            lblLocation.TabIndex = 8;
            lblLocation.Text = "C:\\Temp";
            lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreated
            // 
            lblCreated.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblCreated.AutoEllipsis = true;
            lblCreated.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblCreated.Location = new System.Drawing.Point(104, 77);
            lblCreated.Name = "lblCreated";
            lblCreated.Size = new System.Drawing.Size(296, 20);
            lblCreated.TabIndex = 11;
            lblCreated.Text = "Jan 01, 2024 10:33:42";
            lblCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastModified
            // 
            lblLastModified.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblLastModified.AutoEllipsis = true;
            lblLastModified.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblLastModified.Location = new System.Drawing.Point(104, 102);
            lblLastModified.Name = "lblLastModified";
            lblLastModified.Size = new System.Drawing.Size(296, 20);
            lblLastModified.TabIndex = 12;
            lblLastModified.Text = "Jan 01, 2024 10:33:42";
            lblLastModified.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastAccessed
            // 
            lblLastAccessed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblLastAccessed.AutoEllipsis = true;
            lblLastAccessed.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblLastAccessed.Location = new System.Drawing.Point(104, 128);
            lblLastAccessed.Name = "lblLastAccessed";
            lblLastAccessed.Size = new System.Drawing.Size(296, 20);
            lblLastAccessed.TabIndex = 13;
            lblLastAccessed.Text = "Jan 01, 2024 10:33:42";
            lblLastAccessed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpMetadata
            // 
            tpMetadata.BackColor = System.Drawing.Color.SteelBlue;
            tpMetadata.Controls.Add(lvMetadata);
            tpMetadata.ForeColor = System.Drawing.Color.White;
            tpMetadata.Location = new System.Drawing.Point(4, 24);
            tpMetadata.Name = "tpMetadata";
            tpMetadata.Padding = new System.Windows.Forms.Padding(3);
            tpMetadata.Size = new System.Drawing.Size(403, 388);
            tpMetadata.TabIndex = 1;
            tpMetadata.Text = "Metadata";
            // 
            // lvMetadata
            // 
            lvMetadata.BackColor = System.Drawing.Color.SteelBlue;
            lvMetadata.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lvMetadata.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2 });
            lvMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            lvMetadata.ForeColor = System.Drawing.Color.White;
            lvMetadata.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            lvMetadata.LabelWrap = false;
            lvMetadata.Location = new System.Drawing.Point(3, 3);
            lvMetadata.MultiSelect = false;
            lvMetadata.Name = "lvMetadata";
            lvMetadata.ShowGroups = false;
            lvMetadata.Size = new System.Drawing.Size(397, 382);
            lvMetadata.TabIndex = 0;
            lvMetadata.UseCompatibleStateImageBehavior = false;
            lvMetadata.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 190;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Value";
            columnHeader2.Width = 190;
            // 
            // FileEntryProperties
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            ClientSize = new System.Drawing.Size(420, 470);
            Controls.Add(tbProperties);
            Controls.Add(pbFileTypeIcon);
            Controls.Add(lblFileNameWithoutExtension);
            Controls.Add(horizontalLine1);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FileEntryProperties";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Properties";
            ((System.ComponentModel.ISupportInitialize)pbFileTypeIcon).EndInit();
            tbProperties.ResumeLayout(false);
            tpGeneral.ResumeLayout(false);
            tpGeneral.PerformLayout();
            groupBox1.ResumeLayout(false);
            basicInfoLayoutTable.ResumeLayout(false);
            tpMetadata.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Controls.HorizontalLine horizontalLine1;
        private System.Windows.Forms.Label lblFileNameWithoutExtension;
        private System.Windows.Forms.PictureBox pbFileTypeIcon;
        private System.Windows.Forms.SaveFileDialog sfdFileCopyMoveDestinationPicker;
        private System.Windows.Forms.TabControl tbProperties;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel layoutAttributesList;
        private System.Windows.Forms.TableLayoutPanel basicInfoLayoutTable;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblTypeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label lblLastModified;
        private System.Windows.Forms.Label lblLastAccessed;
        private System.Windows.Forms.TabPage tpMetadata;
        private System.Windows.Forms.Button btnUnblockFileOrManageAcl;
        private System.Windows.Forms.Button btnCopyFile;
        private System.Windows.Forms.Button btnMoveFile;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.ListView lvMetadata;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}