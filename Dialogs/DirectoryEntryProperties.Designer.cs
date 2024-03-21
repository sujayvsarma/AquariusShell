namespace AquariusShell.Forms
{
    partial class DirectoryEntryProperties
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
            tbProperties = new System.Windows.Forms.TabControl();
            tpGeneral = new System.Windows.Forms.TabPage();
            btnManageSecurity = new System.Windows.Forms.Button();
            btnCopyDirectory = new System.Windows.Forms.Button();
            btnMoveDirectory = new System.Windows.Forms.Button();
            btnDeleteDirectory = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            layoutAttributesList = new System.Windows.Forms.FlowLayoutPanel();
            basicInfoLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            lblTypeName = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
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
            fbdDestinationPicker = new System.Windows.Forms.FolderBrowserDialog();
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
            tpGeneral.Controls.Add(btnManageSecurity);
            tpGeneral.Controls.Add(btnCopyDirectory);
            tpGeneral.Controls.Add(btnMoveDirectory);
            tpGeneral.Controls.Add(btnDeleteDirectory);
            tpGeneral.Controls.Add(groupBox1);
            tpGeneral.Controls.Add(basicInfoLayoutTable);
            tpGeneral.Location = new System.Drawing.Point(4, 24);
            tpGeneral.Name = "tpGeneral";
            tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            tpGeneral.Size = new System.Drawing.Size(403, 388);
            tpGeneral.TabIndex = 0;
            tpGeneral.Text = "General";
            // 
            // btnManageSecurity
            // 
            btnManageSecurity.BackColor = System.Drawing.Color.SteelBlue;
            btnManageSecurity.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnManageSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnManageSecurity.Location = new System.Drawing.Point(311, 352);
            btnManageSecurity.Name = "btnManageSecurity";
            btnManageSecurity.Size = new System.Drawing.Size(86, 30);
            btnManageSecurity.TabIndex = 15;
            btnManageSecurity.Text = "&Security...";
            btnManageSecurity.UseVisualStyleBackColor = false;
            btnManageSecurity.Click += btnManageSecurity_Click;
            // 
            // btnCopyDirectory
            // 
            btnCopyDirectory.BackColor = System.Drawing.Color.SteelBlue;
            btnCopyDirectory.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnCopyDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCopyDirectory.Location = new System.Drawing.Point(170, 352);
            btnCopyDirectory.Name = "btnCopyDirectory";
            btnCopyDirectory.Size = new System.Drawing.Size(75, 30);
            btnCopyDirectory.TabIndex = 15;
            btnCopyDirectory.Text = "C&opy";
            btnCopyDirectory.UseVisualStyleBackColor = false;
            btnCopyDirectory.Click += btnCopyDirectory_Click;
            // 
            // btnMoveDirectory
            // 
            btnMoveDirectory.BackColor = System.Drawing.Color.SteelBlue;
            btnMoveDirectory.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnMoveDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMoveDirectory.Location = new System.Drawing.Point(89, 352);
            btnMoveDirectory.Name = "btnMoveDirectory";
            btnMoveDirectory.Size = new System.Drawing.Size(75, 30);
            btnMoveDirectory.TabIndex = 16;
            btnMoveDirectory.Text = "&Move";
            btnMoveDirectory.UseVisualStyleBackColor = false;
            btnMoveDirectory.Click += btnMoveDirectory_Click;
            // 
            // btnDeleteDirectory
            // 
            btnDeleteDirectory.BackColor = System.Drawing.Color.Red;
            btnDeleteDirectory.ForeColor = System.Drawing.Color.White;
            btnDeleteDirectory.Location = new System.Drawing.Point(8, 352);
            btnDeleteDirectory.Name = "btnDeleteDirectory";
            btnDeleteDirectory.Size = new System.Drawing.Size(75, 30);
            btnDeleteDirectory.TabIndex = 13;
            btnDeleteDirectory.Text = "D&elete";
            btnDeleteDirectory.UseVisualStyleBackColor = false;
            btnDeleteDirectory.Click += btnDeleteDirectory_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(layoutAttributesList);
            groupBox1.Location = new System.Drawing.Point(-2, 145);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(406, 202);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Directory attributes";
            // 
            // layoutAttributesList
            // 
            layoutAttributesList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            layoutAttributesList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            layoutAttributesList.Location = new System.Drawing.Point(8, 18);
            layoutAttributesList.Name = "layoutAttributesList";
            layoutAttributesList.Size = new System.Drawing.Size(392, 178);
            layoutAttributesList.TabIndex = 0;
            layoutAttributesList.WrapContents = false;
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
            basicInfoLayoutTable.Controls.Add(lblLocation, 1, 0);
            basicInfoLayoutTable.Controls.Add(lblCreated, 1, 2);
            basicInfoLayoutTable.Controls.Add(lblLastModified, 1, 3);
            basicInfoLayoutTable.Controls.Add(lblLastAccessed, 1, 4);
            basicInfoLayoutTable.Location = new System.Drawing.Point(-2, 8);
            basicInfoLayoutTable.Name = "basicInfoLayoutTable";
            basicInfoLayoutTable.RowCount = 5;
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            basicInfoLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            basicInfoLayoutTable.Size = new System.Drawing.Size(406, 131);
            basicInfoLayoutTable.TabIndex = 10;
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
            lblTypeName.Text = "Folder (Directory)";
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
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label5.Location = new System.Drawing.Point(3, 52);
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
            label6.Location = new System.Drawing.Point(3, 77);
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
            label7.Location = new System.Drawing.Point(3, 105);
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
            lblCreated.Location = new System.Drawing.Point(104, 52);
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
            lblLastModified.Location = new System.Drawing.Point(104, 77);
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
            lblLastAccessed.Location = new System.Drawing.Point(104, 105);
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
            // fbdDestinationPicker
            // 
            fbdDestinationPicker.AddToRecent = false;
            fbdDestinationPicker.OkRequiresInteraction = true;
            fbdDestinationPicker.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // DirectoryEntryProperties
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
            Name = "DirectoryEntryProperties";
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
        private System.Windows.Forms.TabControl tbProperties;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel layoutAttributesList;
        private System.Windows.Forms.TableLayoutPanel basicInfoLayoutTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label lblLastModified;
        private System.Windows.Forms.Label lblLastAccessed;
        private System.Windows.Forms.TabPage tpMetadata;
        private System.Windows.Forms.Button btnCopyDirectory;
        private System.Windows.Forms.Button btnMoveDirectory;
        private System.Windows.Forms.Button btnDeleteDirectory;
        private System.Windows.Forms.ListView lvMetadata;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lblTypeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog fbdDestinationPicker;
        private System.Windows.Forms.Button btnManageSecurity;
    }
}