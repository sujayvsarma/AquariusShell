namespace AquariusShell.ShellApps
{
    partial class AccessControlBrowser
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
            label1 = new System.Windows.Forms.Label();
            tvFilesystemBrowser = new System.Windows.Forms.TreeView();
            ilFileSystemImages = new System.Windows.Forms.ImageList(components);
            label2 = new System.Windows.Forms.Label();
            lbPrincipalsList = new System.Windows.Forms.ListBox();
            btnDeletePrincipal = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            aclLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            label5 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            aclTypeCreateDirectory = new System.Windows.Forms.ComboBox();
            aclTypeCreateFiles = new System.Windows.Forms.ComboBox();
            aclTypeReadAttributes = new System.Windows.Forms.ComboBox();
            aclTypeListRead = new System.Windows.Forms.ComboBox();
            aclTypeReadPermissions = new System.Windows.Forms.ComboBox();
            aclTypeDelete = new System.Windows.Forms.ComboBox();
            aclTypeChangePermissions = new System.Windows.Forms.ComboBox();
            aclTypeExecute = new System.Windows.Forms.ComboBox();
            aclTypeWriteAttributes = new System.Windows.Forms.ComboBox();
            diCreateDirectory = new System.Windows.Forms.CheckBox();
            diCreateFiles = new System.Windows.Forms.CheckBox();
            diReadAttributes = new System.Windows.Forms.CheckBox();
            diListRead = new System.Windows.Forms.CheckBox();
            diReadPermissions = new System.Windows.Forms.CheckBox();
            diDelete = new System.Windows.Forms.CheckBox();
            diChangePermissions = new System.Windows.Forms.CheckBox();
            diExecute = new System.Windows.Forms.CheckBox();
            diWriteAttributes = new System.Windows.Forms.CheckBox();
            oiCreateDirectory = new System.Windows.Forms.CheckBox();
            oiCreateFiles = new System.Windows.Forms.CheckBox();
            oiReadAttributes = new System.Windows.Forms.CheckBox();
            oiListRead = new System.Windows.Forms.CheckBox();
            oiReadPermissions = new System.Windows.Forms.CheckBox();
            oiDelete = new System.Windows.Forms.CheckBox();
            oiChangePermissions = new System.Windows.Forms.CheckBox();
            oiExecute = new System.Windows.Forms.CheckBox();
            oiWriteAttributes = new System.Windows.Forms.CheckBox();
            breakCreateDirectory = new System.Windows.Forms.CheckBox();
            breakCreateFiles = new System.Windows.Forms.CheckBox();
            breakReadAttributes = new System.Windows.Forms.CheckBox();
            breakListRead = new System.Windows.Forms.CheckBox();
            breakReadPermissions = new System.Windows.Forms.CheckBox();
            breakDelete = new System.Windows.Forms.CheckBox();
            breakChangePermissions = new System.Windows.Forms.CheckBox();
            breakExecute = new System.Windows.Forms.CheckBox();
            breakWriteAttributes = new System.Windows.Forms.CheckBox();
            label20 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            aclTypeReadExtendedAttributes = new System.Windows.Forms.ComboBox();
            aclTypeWriteExtendedAttributes = new System.Windows.Forms.ComboBox();
            aclTypeDeleteRecursive = new System.Windows.Forms.ComboBox();
            diReadExtendedAttributes = new System.Windows.Forms.CheckBox();
            oiReadExtendedAttributes = new System.Windows.Forms.CheckBox();
            breakReadExtendedAttributes = new System.Windows.Forms.CheckBox();
            diWriteExtendedAttributes = new System.Windows.Forms.CheckBox();
            oiWriteExtendedAttributes = new System.Windows.Forms.CheckBox();
            breakWriteExtendedAttributes = new System.Windows.Forms.CheckBox();
            diDeleteRecursive = new System.Windows.Forms.CheckBox();
            oiDeleteRecursive = new System.Windows.Forms.CheckBox();
            breakDeleteRecursive = new System.Windows.Forms.CheckBox();
            chkMarkPrincipalOwner = new System.Windows.Forms.CheckBox();
            btnResolvePrincipalNameRaw = new System.Windows.Forms.Button();
            tbPrincipalNameRaw = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            btnSavePermissionEdits = new System.Windows.Forms.Button();
            btnEditPrincipal = new System.Windows.Forms.Button();
            btnCloseDialog = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            tbCurrentOwnerPrincipal = new System.Windows.Forms.TextBox();
            btnTakeOwnership = new System.Windows.Forms.Button();
            btnAddPrincipal = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            aclLayoutTable.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(245, 23);
            label1.TabIndex = 0;
            label1.Text = "Browse to:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tvFilesystemBrowser
            // 
            tvFilesystemBrowser.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            tvFilesystemBrowser.HideSelection = false;
            tvFilesystemBrowser.ImageIndex = 0;
            tvFilesystemBrowser.ImageList = ilFileSystemImages;
            tvFilesystemBrowser.Indent = 18;
            tvFilesystemBrowser.ItemHeight = 16;
            tvFilesystemBrowser.Location = new System.Drawing.Point(11, 35);
            tvFilesystemBrowser.Name = "tvFilesystemBrowser";
            tvFilesystemBrowser.SelectedImageIndex = 0;
            tvFilesystemBrowser.Size = new System.Drawing.Size(246, 712);
            tvFilesystemBrowser.TabIndex = 1;
            tvFilesystemBrowser.BeforeExpand += TreeViewFileSystem_LazyLoadChildren;
            tvFilesystemBrowser.AfterSelect += TreeViewFileSystem_ShowPrincipalsOnItemClick;
            // 
            // ilFileSystemImages
            // 
            ilFileSystemImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            ilFileSystemImages.ImageSize = new System.Drawing.Size(16, 16);
            ilFileSystemImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label2.Location = new System.Drawing.Point(270, 101);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(522, 23);
            label2.TabIndex = 0;
            label2.Text = "Users/groups/principals with permissions:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPrincipalsList
            // 
            lbPrincipalsList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lbPrincipalsList.FormattingEnabled = true;
            lbPrincipalsList.IntegralHeight = false;
            lbPrincipalsList.ItemHeight = 15;
            lbPrincipalsList.Location = new System.Drawing.Point(270, 127);
            lbPrincipalsList.Name = "lbPrincipalsList";
            lbPrincipalsList.Size = new System.Drawing.Size(522, 109);
            lbPrincipalsList.Sorted = true;
            lbPrincipalsList.TabIndex = 2;
            lbPrincipalsList.SelectedIndexChanged += ListboxPrincipals_ShowPermissionsReadonly;
            // 
            // btnDeletePrincipal
            // 
            btnDeletePrincipal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDeletePrincipal.Enabled = false;
            btnDeletePrincipal.Location = new System.Drawing.Point(270, 240);
            btnDeletePrincipal.Name = "btnDeletePrincipal";
            btnDeletePrincipal.Size = new System.Drawing.Size(113, 32);
            btnDeletePrincipal.TabIndex = 3;
            btnDeletePrincipal.Text = "Delete principal";
            btnDeletePrincipal.UseVisualStyleBackColor = true;
            btnDeletePrincipal.Click += ListboxPrincipals_DeleteSelectedPrincipal;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(aclLayoutTable);
            groupBox1.Controls.Add(chkMarkPrincipalOwner);
            groupBox1.Controls.Add(btnResolvePrincipalNameRaw);
            groupBox1.Controls.Add(tbPrincipalNameRaw);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new System.Drawing.Point(267, 277);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(533, 441);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add/edit principal and permission(s):";
            // 
            // aclLayoutTable
            // 
            aclLayoutTable.ColumnCount = 5;
            aclLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            aclLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            aclLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            aclLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            aclLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            aclLayoutTable.Controls.Add(label5, 0, 0);
            aclLayoutTable.Controls.Add(label7, 0, 1);
            aclLayoutTable.Controls.Add(label8, 0, 2);
            aclLayoutTable.Controls.Add(label9, 0, 3);
            aclLayoutTable.Controls.Add(label10, 0, 4);
            aclLayoutTable.Controls.Add(label11, 0, 5);
            aclLayoutTable.Controls.Add(label12, 0, 6);
            aclLayoutTable.Controls.Add(label13, 0, 7);
            aclLayoutTable.Controls.Add(label14, 0, 8);
            aclLayoutTable.Controls.Add(label15, 0, 9);
            aclLayoutTable.Controls.Add(label16, 1, 0);
            aclLayoutTable.Controls.Add(label17, 2, 0);
            aclLayoutTable.Controls.Add(label18, 3, 0);
            aclLayoutTable.Controls.Add(label19, 4, 0);
            aclLayoutTable.Controls.Add(aclTypeCreateDirectory, 1, 1);
            aclLayoutTable.Controls.Add(aclTypeCreateFiles, 1, 2);
            aclLayoutTable.Controls.Add(aclTypeReadAttributes, 1, 3);
            aclLayoutTable.Controls.Add(aclTypeListRead, 1, 4);
            aclLayoutTable.Controls.Add(aclTypeReadPermissions, 1, 5);
            aclLayoutTable.Controls.Add(aclTypeDelete, 1, 6);
            aclLayoutTable.Controls.Add(aclTypeChangePermissions, 1, 7);
            aclLayoutTable.Controls.Add(aclTypeExecute, 1, 8);
            aclLayoutTable.Controls.Add(aclTypeWriteAttributes, 1, 9);
            aclLayoutTable.Controls.Add(diCreateDirectory, 2, 1);
            aclLayoutTable.Controls.Add(diCreateFiles, 2, 2);
            aclLayoutTable.Controls.Add(diReadAttributes, 2, 3);
            aclLayoutTable.Controls.Add(diListRead, 2, 4);
            aclLayoutTable.Controls.Add(diReadPermissions, 2, 5);
            aclLayoutTable.Controls.Add(diDelete, 2, 6);
            aclLayoutTable.Controls.Add(diChangePermissions, 2, 7);
            aclLayoutTable.Controls.Add(diExecute, 2, 8);
            aclLayoutTable.Controls.Add(diWriteAttributes, 2, 9);
            aclLayoutTable.Controls.Add(oiCreateDirectory, 3, 1);
            aclLayoutTable.Controls.Add(oiCreateFiles, 3, 2);
            aclLayoutTable.Controls.Add(oiReadAttributes, 3, 3);
            aclLayoutTable.Controls.Add(oiListRead, 3, 4);
            aclLayoutTable.Controls.Add(oiReadPermissions, 3, 5);
            aclLayoutTable.Controls.Add(oiDelete, 3, 6);
            aclLayoutTable.Controls.Add(oiChangePermissions, 3, 7);
            aclLayoutTable.Controls.Add(oiExecute, 3, 8);
            aclLayoutTable.Controls.Add(oiWriteAttributes, 3, 9);
            aclLayoutTable.Controls.Add(breakCreateDirectory, 4, 1);
            aclLayoutTable.Controls.Add(breakCreateFiles, 4, 2);
            aclLayoutTable.Controls.Add(breakReadAttributes, 4, 3);
            aclLayoutTable.Controls.Add(breakListRead, 4, 4);
            aclLayoutTable.Controls.Add(breakReadPermissions, 4, 5);
            aclLayoutTable.Controls.Add(breakDelete, 4, 6);
            aclLayoutTable.Controls.Add(breakChangePermissions, 4, 7);
            aclLayoutTable.Controls.Add(breakExecute, 4, 8);
            aclLayoutTable.Controls.Add(breakWriteAttributes, 4, 9);
            aclLayoutTable.Controls.Add(label20, 0, 10);
            aclLayoutTable.Controls.Add(label21, 0, 11);
            aclLayoutTable.Controls.Add(label22, 0, 12);
            aclLayoutTable.Controls.Add(aclTypeReadExtendedAttributes, 1, 10);
            aclLayoutTable.Controls.Add(aclTypeWriteExtendedAttributes, 1, 11);
            aclLayoutTable.Controls.Add(aclTypeDeleteRecursive, 1, 12);
            aclLayoutTable.Controls.Add(diReadExtendedAttributes, 2, 10);
            aclLayoutTable.Controls.Add(oiReadExtendedAttributes, 3, 10);
            aclLayoutTable.Controls.Add(breakReadExtendedAttributes, 4, 10);
            aclLayoutTable.Controls.Add(diWriteExtendedAttributes, 2, 11);
            aclLayoutTable.Controls.Add(oiWriteExtendedAttributes, 3, 11);
            aclLayoutTable.Controls.Add(breakWriteExtendedAttributes, 4, 11);
            aclLayoutTable.Controls.Add(diDeleteRecursive, 2, 12);
            aclLayoutTable.Controls.Add(oiDeleteRecursive, 3, 12);
            aclLayoutTable.Controls.Add(breakDeleteRecursive, 4, 12);
            aclLayoutTable.Location = new System.Drawing.Point(19, 102);
            aclLayoutTable.Name = "aclLayoutTable";
            aclLayoutTable.RowCount = 13;
            aclLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            aclLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            aclLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            aclLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            aclLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            aclLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            aclLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            aclLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            aclLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            aclLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            aclLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            aclLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            aclLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            aclLayoutTable.Size = new System.Drawing.Size(502, 330);
            aclLayoutTable.TabIndex = 6;
            // 
            // label5
            // 
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(3, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(320, 24);
            label5.TabIndex = 0;
            label5.Text = "Permission";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Location = new System.Drawing.Point(3, 25);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(320, 24);
            label7.TabIndex = 0;
            label7.Text = "Create subdirectories";
            // 
            // label8
            // 
            label8.Location = new System.Drawing.Point(3, 50);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(320, 24);
            label8.TabIndex = 0;
            label8.Text = "Create/modify files";
            // 
            // label9
            // 
            label9.Location = new System.Drawing.Point(3, 75);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(320, 24);
            label9.TabIndex = 0;
            label9.Text = "View attributes and metadata";
            // 
            // label10
            // 
            label10.Location = new System.Drawing.Point(3, 100);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(320, 24);
            label10.TabIndex = 0;
            label10.Text = "List directory or view file data";
            // 
            // label11
            // 
            label11.Location = new System.Drawing.Point(3, 125);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(320, 24);
            label11.TabIndex = 0;
            label11.Text = "View permissions";
            // 
            // label12
            // 
            label12.Location = new System.Drawing.Point(3, 150);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(320, 24);
            label12.TabIndex = 0;
            label12.Text = "Delete (subdirectories, files)";
            // 
            // label13
            // 
            label13.Location = new System.Drawing.Point(3, 175);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(320, 24);
            label13.TabIndex = 0;
            label13.Text = "Modify permissions";
            // 
            // label14
            // 
            label14.Location = new System.Drawing.Point(3, 200);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(320, 24);
            label14.TabIndex = 0;
            label14.Text = "Execute a file/program";
            // 
            // label15
            // 
            label15.Location = new System.Drawing.Point(3, 225);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(320, 24);
            label15.TabIndex = 0;
            label15.Text = "Modify attributes and metadata";
            // 
            // label16
            // 
            label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label16.Location = new System.Drawing.Point(329, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(40, 24);
            label16.TabIndex = 0;
            label16.Text = "Type";
            label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label17.Location = new System.Drawing.Point(400, 0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(29, 24);
            label17.TabIndex = 0;
            label17.Text = "Di";
            label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            label18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label18.Location = new System.Drawing.Point(435, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(29, 24);
            label18.TabIndex = 0;
            label18.Text = "Oi";
            label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            label19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label19.Location = new System.Drawing.Point(470, 0);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(29, 24);
            label19.TabIndex = 0;
            label19.Text = "X";
            label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aclTypeCreateDirectory
            // 
            aclTypeCreateDirectory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            aclTypeCreateDirectory.FormattingEnabled = true;
            aclTypeCreateDirectory.Items.AddRange(new object[] { "Allow", "Deny" });
            aclTypeCreateDirectory.Location = new System.Drawing.Point(329, 28);
            aclTypeCreateDirectory.Name = "aclTypeCreateDirectory";
            aclTypeCreateDirectory.Size = new System.Drawing.Size(65, 23);
            aclTypeCreateDirectory.TabIndex = 1;
            // 
            // aclTypeCreateFiles
            // 
            aclTypeCreateFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            aclTypeCreateFiles.FormattingEnabled = true;
            aclTypeCreateFiles.Items.AddRange(new object[] { "Allow", "Deny" });
            aclTypeCreateFiles.Location = new System.Drawing.Point(329, 53);
            aclTypeCreateFiles.Name = "aclTypeCreateFiles";
            aclTypeCreateFiles.Size = new System.Drawing.Size(65, 23);
            aclTypeCreateFiles.TabIndex = 1;
            // 
            // aclTypeReadAttributes
            // 
            aclTypeReadAttributes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            aclTypeReadAttributes.FormattingEnabled = true;
            aclTypeReadAttributes.Items.AddRange(new object[] { "Allow", "Deny" });
            aclTypeReadAttributes.Location = new System.Drawing.Point(329, 78);
            aclTypeReadAttributes.Name = "aclTypeReadAttributes";
            aclTypeReadAttributes.Size = new System.Drawing.Size(65, 23);
            aclTypeReadAttributes.TabIndex = 1;
            // 
            // aclTypeListRead
            // 
            aclTypeListRead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            aclTypeListRead.FormattingEnabled = true;
            aclTypeListRead.Items.AddRange(new object[] { "Allow", "Deny" });
            aclTypeListRead.Location = new System.Drawing.Point(329, 103);
            aclTypeListRead.Name = "aclTypeListRead";
            aclTypeListRead.Size = new System.Drawing.Size(65, 23);
            aclTypeListRead.TabIndex = 1;
            // 
            // aclTypeReadPermissions
            // 
            aclTypeReadPermissions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            aclTypeReadPermissions.FormattingEnabled = true;
            aclTypeReadPermissions.Items.AddRange(new object[] { "Allow", "Deny" });
            aclTypeReadPermissions.Location = new System.Drawing.Point(329, 128);
            aclTypeReadPermissions.Name = "aclTypeReadPermissions";
            aclTypeReadPermissions.Size = new System.Drawing.Size(65, 23);
            aclTypeReadPermissions.TabIndex = 1;
            // 
            // aclTypeDelete
            // 
            aclTypeDelete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            aclTypeDelete.FormattingEnabled = true;
            aclTypeDelete.Items.AddRange(new object[] { "Allow", "Deny" });
            aclTypeDelete.Location = new System.Drawing.Point(329, 153);
            aclTypeDelete.Name = "aclTypeDelete";
            aclTypeDelete.Size = new System.Drawing.Size(65, 23);
            aclTypeDelete.TabIndex = 1;
            // 
            // aclTypeChangePermissions
            // 
            aclTypeChangePermissions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            aclTypeChangePermissions.FormattingEnabled = true;
            aclTypeChangePermissions.Items.AddRange(new object[] { "Allow", "Deny" });
            aclTypeChangePermissions.Location = new System.Drawing.Point(329, 178);
            aclTypeChangePermissions.Name = "aclTypeChangePermissions";
            aclTypeChangePermissions.Size = new System.Drawing.Size(65, 23);
            aclTypeChangePermissions.TabIndex = 1;
            // 
            // aclTypeExecute
            // 
            aclTypeExecute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            aclTypeExecute.FormattingEnabled = true;
            aclTypeExecute.Items.AddRange(new object[] { "Allow", "Deny" });
            aclTypeExecute.Location = new System.Drawing.Point(329, 203);
            aclTypeExecute.Name = "aclTypeExecute";
            aclTypeExecute.Size = new System.Drawing.Size(65, 23);
            aclTypeExecute.TabIndex = 1;
            // 
            // aclTypeWriteAttributes
            // 
            aclTypeWriteAttributes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            aclTypeWriteAttributes.FormattingEnabled = true;
            aclTypeWriteAttributes.Items.AddRange(new object[] { "Allow", "Deny" });
            aclTypeWriteAttributes.Location = new System.Drawing.Point(329, 228);
            aclTypeWriteAttributes.Name = "aclTypeWriteAttributes";
            aclTypeWriteAttributes.Size = new System.Drawing.Size(65, 23);
            aclTypeWriteAttributes.TabIndex = 1;
            // 
            // diCreateDirectory
            // 
            diCreateDirectory.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            diCreateDirectory.Location = new System.Drawing.Point(400, 28);
            diCreateDirectory.Name = "diCreateDirectory";
            diCreateDirectory.Size = new System.Drawing.Size(29, 19);
            diCreateDirectory.TabIndex = 2;
            diCreateDirectory.UseVisualStyleBackColor = true;
            // 
            // diCreateFiles
            // 
            diCreateFiles.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            diCreateFiles.Location = new System.Drawing.Point(400, 53);
            diCreateFiles.Name = "diCreateFiles";
            diCreateFiles.Size = new System.Drawing.Size(29, 19);
            diCreateFiles.TabIndex = 2;
            diCreateFiles.UseVisualStyleBackColor = true;
            // 
            // diReadAttributes
            // 
            diReadAttributes.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            diReadAttributes.Location = new System.Drawing.Point(400, 78);
            diReadAttributes.Name = "diReadAttributes";
            diReadAttributes.Size = new System.Drawing.Size(29, 19);
            diReadAttributes.TabIndex = 2;
            diReadAttributes.UseVisualStyleBackColor = true;
            // 
            // diListRead
            // 
            diListRead.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            diListRead.Location = new System.Drawing.Point(400, 103);
            diListRead.Name = "diListRead";
            diListRead.Size = new System.Drawing.Size(29, 19);
            diListRead.TabIndex = 2;
            diListRead.UseVisualStyleBackColor = true;
            // 
            // diReadPermissions
            // 
            diReadPermissions.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            diReadPermissions.Location = new System.Drawing.Point(400, 128);
            diReadPermissions.Name = "diReadPermissions";
            diReadPermissions.Size = new System.Drawing.Size(29, 19);
            diReadPermissions.TabIndex = 2;
            diReadPermissions.UseVisualStyleBackColor = true;
            // 
            // diDelete
            // 
            diDelete.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            diDelete.Location = new System.Drawing.Point(400, 153);
            diDelete.Name = "diDelete";
            diDelete.Size = new System.Drawing.Size(29, 19);
            diDelete.TabIndex = 2;
            diDelete.UseVisualStyleBackColor = true;
            // 
            // diChangePermissions
            // 
            diChangePermissions.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            diChangePermissions.Location = new System.Drawing.Point(400, 178);
            diChangePermissions.Name = "diChangePermissions";
            diChangePermissions.Size = new System.Drawing.Size(29, 19);
            diChangePermissions.TabIndex = 2;
            diChangePermissions.UseVisualStyleBackColor = true;
            // 
            // diExecute
            // 
            diExecute.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            diExecute.Location = new System.Drawing.Point(400, 203);
            diExecute.Name = "diExecute";
            diExecute.Size = new System.Drawing.Size(29, 19);
            diExecute.TabIndex = 2;
            diExecute.UseVisualStyleBackColor = true;
            // 
            // diWriteAttributes
            // 
            diWriteAttributes.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            diWriteAttributes.Location = new System.Drawing.Point(400, 228);
            diWriteAttributes.Name = "diWriteAttributes";
            diWriteAttributes.Size = new System.Drawing.Size(29, 19);
            diWriteAttributes.TabIndex = 2;
            diWriteAttributes.UseVisualStyleBackColor = true;
            // 
            // oiCreateDirectory
            // 
            oiCreateDirectory.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            oiCreateDirectory.Location = new System.Drawing.Point(435, 28);
            oiCreateDirectory.Name = "oiCreateDirectory";
            oiCreateDirectory.Size = new System.Drawing.Size(29, 19);
            oiCreateDirectory.TabIndex = 2;
            oiCreateDirectory.UseVisualStyleBackColor = true;
            // 
            // oiCreateFiles
            // 
            oiCreateFiles.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            oiCreateFiles.Location = new System.Drawing.Point(435, 53);
            oiCreateFiles.Name = "oiCreateFiles";
            oiCreateFiles.Size = new System.Drawing.Size(29, 19);
            oiCreateFiles.TabIndex = 2;
            oiCreateFiles.UseVisualStyleBackColor = true;
            // 
            // oiReadAttributes
            // 
            oiReadAttributes.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            oiReadAttributes.Location = new System.Drawing.Point(435, 78);
            oiReadAttributes.Name = "oiReadAttributes";
            oiReadAttributes.Size = new System.Drawing.Size(29, 19);
            oiReadAttributes.TabIndex = 2;
            oiReadAttributes.UseVisualStyleBackColor = true;
            // 
            // oiListRead
            // 
            oiListRead.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            oiListRead.Location = new System.Drawing.Point(435, 103);
            oiListRead.Name = "oiListRead";
            oiListRead.Size = new System.Drawing.Size(29, 19);
            oiListRead.TabIndex = 2;
            oiListRead.UseVisualStyleBackColor = true;
            // 
            // oiReadPermissions
            // 
            oiReadPermissions.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            oiReadPermissions.Location = new System.Drawing.Point(435, 128);
            oiReadPermissions.Name = "oiReadPermissions";
            oiReadPermissions.Size = new System.Drawing.Size(29, 19);
            oiReadPermissions.TabIndex = 2;
            oiReadPermissions.UseVisualStyleBackColor = true;
            // 
            // oiDelete
            // 
            oiDelete.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            oiDelete.Location = new System.Drawing.Point(435, 153);
            oiDelete.Name = "oiDelete";
            oiDelete.Size = new System.Drawing.Size(29, 19);
            oiDelete.TabIndex = 2;
            oiDelete.UseVisualStyleBackColor = true;
            // 
            // oiChangePermissions
            // 
            oiChangePermissions.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            oiChangePermissions.Location = new System.Drawing.Point(435, 178);
            oiChangePermissions.Name = "oiChangePermissions";
            oiChangePermissions.Size = new System.Drawing.Size(29, 19);
            oiChangePermissions.TabIndex = 2;
            oiChangePermissions.UseVisualStyleBackColor = true;
            // 
            // oiExecute
            // 
            oiExecute.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            oiExecute.Location = new System.Drawing.Point(435, 203);
            oiExecute.Name = "oiExecute";
            oiExecute.Size = new System.Drawing.Size(29, 19);
            oiExecute.TabIndex = 2;
            oiExecute.UseVisualStyleBackColor = true;
            // 
            // oiWriteAttributes
            // 
            oiWriteAttributes.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            oiWriteAttributes.Location = new System.Drawing.Point(435, 228);
            oiWriteAttributes.Name = "oiWriteAttributes";
            oiWriteAttributes.Size = new System.Drawing.Size(29, 19);
            oiWriteAttributes.TabIndex = 2;
            oiWriteAttributes.UseVisualStyleBackColor = true;
            // 
            // breakCreateDirectory
            // 
            breakCreateDirectory.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            breakCreateDirectory.Location = new System.Drawing.Point(470, 28);
            breakCreateDirectory.Name = "breakCreateDirectory";
            breakCreateDirectory.Size = new System.Drawing.Size(29, 19);
            breakCreateDirectory.TabIndex = 2;
            breakCreateDirectory.UseVisualStyleBackColor = true;
            // 
            // breakCreateFiles
            // 
            breakCreateFiles.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            breakCreateFiles.Location = new System.Drawing.Point(470, 53);
            breakCreateFiles.Name = "breakCreateFiles";
            breakCreateFiles.Size = new System.Drawing.Size(29, 19);
            breakCreateFiles.TabIndex = 2;
            breakCreateFiles.UseVisualStyleBackColor = true;
            // 
            // breakReadAttributes
            // 
            breakReadAttributes.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            breakReadAttributes.Location = new System.Drawing.Point(470, 78);
            breakReadAttributes.Name = "breakReadAttributes";
            breakReadAttributes.Size = new System.Drawing.Size(29, 19);
            breakReadAttributes.TabIndex = 2;
            breakReadAttributes.UseVisualStyleBackColor = true;
            // 
            // breakListRead
            // 
            breakListRead.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            breakListRead.Location = new System.Drawing.Point(470, 103);
            breakListRead.Name = "breakListRead";
            breakListRead.Size = new System.Drawing.Size(29, 19);
            breakListRead.TabIndex = 2;
            breakListRead.UseVisualStyleBackColor = true;
            // 
            // breakReadPermissions
            // 
            breakReadPermissions.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            breakReadPermissions.Location = new System.Drawing.Point(470, 128);
            breakReadPermissions.Name = "breakReadPermissions";
            breakReadPermissions.Size = new System.Drawing.Size(29, 19);
            breakReadPermissions.TabIndex = 2;
            breakReadPermissions.UseVisualStyleBackColor = true;
            // 
            // breakDelete
            // 
            breakDelete.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            breakDelete.Location = new System.Drawing.Point(470, 153);
            breakDelete.Name = "breakDelete";
            breakDelete.Size = new System.Drawing.Size(29, 19);
            breakDelete.TabIndex = 2;
            breakDelete.UseVisualStyleBackColor = true;
            // 
            // breakChangePermissions
            // 
            breakChangePermissions.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            breakChangePermissions.Location = new System.Drawing.Point(470, 178);
            breakChangePermissions.Name = "breakChangePermissions";
            breakChangePermissions.Size = new System.Drawing.Size(29, 19);
            breakChangePermissions.TabIndex = 2;
            breakChangePermissions.UseVisualStyleBackColor = true;
            // 
            // breakExecute
            // 
            breakExecute.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            breakExecute.Location = new System.Drawing.Point(470, 203);
            breakExecute.Name = "breakExecute";
            breakExecute.Size = new System.Drawing.Size(29, 19);
            breakExecute.TabIndex = 2;
            breakExecute.UseVisualStyleBackColor = true;
            // 
            // breakWriteAttributes
            // 
            breakWriteAttributes.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            breakWriteAttributes.Location = new System.Drawing.Point(470, 228);
            breakWriteAttributes.Name = "breakWriteAttributes";
            breakWriteAttributes.Size = new System.Drawing.Size(29, 19);
            breakWriteAttributes.TabIndex = 2;
            breakWriteAttributes.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            label20.Location = new System.Drawing.Point(3, 250);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(320, 24);
            label20.TabIndex = 0;
            label20.Text = "View extended attributes and metadata";
            // 
            // label21
            // 
            label21.Location = new System.Drawing.Point(3, 275);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(320, 24);
            label21.TabIndex = 0;
            label21.Text = "Modify extended attributes and metadata";
            // 
            // label22
            // 
            label22.Location = new System.Drawing.Point(3, 300);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(320, 24);
            label22.TabIndex = 0;
            label22.Text = "Delete everything recursively";
            // 
            // aclTypeReadExtendedAttributes
            // 
            aclTypeReadExtendedAttributes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            aclTypeReadExtendedAttributes.FormattingEnabled = true;
            aclTypeReadExtendedAttributes.Items.AddRange(new object[] { "Allow", "Deny" });
            aclTypeReadExtendedAttributes.Location = new System.Drawing.Point(329, 253);
            aclTypeReadExtendedAttributes.Name = "aclTypeReadExtendedAttributes";
            aclTypeReadExtendedAttributes.Size = new System.Drawing.Size(65, 23);
            aclTypeReadExtendedAttributes.TabIndex = 1;
            // 
            // aclTypeWriteExtendedAttributes
            // 
            aclTypeWriteExtendedAttributes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            aclTypeWriteExtendedAttributes.FormattingEnabled = true;
            aclTypeWriteExtendedAttributes.Items.AddRange(new object[] { "Allow", "Deny" });
            aclTypeWriteExtendedAttributes.Location = new System.Drawing.Point(329, 278);
            aclTypeWriteExtendedAttributes.Name = "aclTypeWriteExtendedAttributes";
            aclTypeWriteExtendedAttributes.Size = new System.Drawing.Size(65, 23);
            aclTypeWriteExtendedAttributes.TabIndex = 1;
            // 
            // aclTypeDeleteRecursive
            // 
            aclTypeDeleteRecursive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            aclTypeDeleteRecursive.FormattingEnabled = true;
            aclTypeDeleteRecursive.Items.AddRange(new object[] { "Allow", "Deny" });
            aclTypeDeleteRecursive.Location = new System.Drawing.Point(329, 303);
            aclTypeDeleteRecursive.Name = "aclTypeDeleteRecursive";
            aclTypeDeleteRecursive.Size = new System.Drawing.Size(65, 23);
            aclTypeDeleteRecursive.TabIndex = 1;
            // 
            // diReadExtendedAttributes
            // 
            diReadExtendedAttributes.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            diReadExtendedAttributes.Location = new System.Drawing.Point(400, 253);
            diReadExtendedAttributes.Name = "diReadExtendedAttributes";
            diReadExtendedAttributes.Size = new System.Drawing.Size(29, 19);
            diReadExtendedAttributes.TabIndex = 2;
            diReadExtendedAttributes.UseVisualStyleBackColor = true;
            // 
            // oiReadExtendedAttributes
            // 
            oiReadExtendedAttributes.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            oiReadExtendedAttributes.Location = new System.Drawing.Point(435, 253);
            oiReadExtendedAttributes.Name = "oiReadExtendedAttributes";
            oiReadExtendedAttributes.Size = new System.Drawing.Size(29, 19);
            oiReadExtendedAttributes.TabIndex = 2;
            oiReadExtendedAttributes.UseVisualStyleBackColor = true;
            // 
            // breakReadExtendedAttributes
            // 
            breakReadExtendedAttributes.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            breakReadExtendedAttributes.Location = new System.Drawing.Point(470, 253);
            breakReadExtendedAttributes.Name = "breakReadExtendedAttributes";
            breakReadExtendedAttributes.Size = new System.Drawing.Size(29, 19);
            breakReadExtendedAttributes.TabIndex = 2;
            breakReadExtendedAttributes.UseVisualStyleBackColor = true;
            // 
            // diWriteExtendedAttributes
            // 
            diWriteExtendedAttributes.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            diWriteExtendedAttributes.Location = new System.Drawing.Point(400, 278);
            diWriteExtendedAttributes.Name = "diWriteExtendedAttributes";
            diWriteExtendedAttributes.Size = new System.Drawing.Size(29, 19);
            diWriteExtendedAttributes.TabIndex = 2;
            diWriteExtendedAttributes.UseVisualStyleBackColor = true;
            // 
            // oiWriteExtendedAttributes
            // 
            oiWriteExtendedAttributes.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            oiWriteExtendedAttributes.Location = new System.Drawing.Point(435, 278);
            oiWriteExtendedAttributes.Name = "oiWriteExtendedAttributes";
            oiWriteExtendedAttributes.Size = new System.Drawing.Size(29, 19);
            oiWriteExtendedAttributes.TabIndex = 2;
            oiWriteExtendedAttributes.UseVisualStyleBackColor = true;
            // 
            // breakWriteExtendedAttributes
            // 
            breakWriteExtendedAttributes.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            breakWriteExtendedAttributes.Location = new System.Drawing.Point(470, 278);
            breakWriteExtendedAttributes.Name = "breakWriteExtendedAttributes";
            breakWriteExtendedAttributes.Size = new System.Drawing.Size(29, 19);
            breakWriteExtendedAttributes.TabIndex = 2;
            breakWriteExtendedAttributes.UseVisualStyleBackColor = true;
            // 
            // diDeleteRecursive
            // 
            diDeleteRecursive.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            diDeleteRecursive.Location = new System.Drawing.Point(400, 303);
            diDeleteRecursive.Name = "diDeleteRecursive";
            diDeleteRecursive.Size = new System.Drawing.Size(29, 19);
            diDeleteRecursive.TabIndex = 2;
            diDeleteRecursive.UseVisualStyleBackColor = true;
            // 
            // oiDeleteRecursive
            // 
            oiDeleteRecursive.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            oiDeleteRecursive.Location = new System.Drawing.Point(435, 303);
            oiDeleteRecursive.Name = "oiDeleteRecursive";
            oiDeleteRecursive.Size = new System.Drawing.Size(29, 19);
            oiDeleteRecursive.TabIndex = 2;
            oiDeleteRecursive.UseVisualStyleBackColor = true;
            // 
            // breakDeleteRecursive
            // 
            breakDeleteRecursive.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            breakDeleteRecursive.Location = new System.Drawing.Point(470, 303);
            breakDeleteRecursive.Name = "breakDeleteRecursive";
            breakDeleteRecursive.Size = new System.Drawing.Size(29, 19);
            breakDeleteRecursive.TabIndex = 2;
            breakDeleteRecursive.UseVisualStyleBackColor = true;
            // 
            // chkMarkPrincipalOwner
            // 
            chkMarkPrincipalOwner.AutoSize = true;
            chkMarkPrincipalOwner.Location = new System.Drawing.Point(94, 55);
            chkMarkPrincipalOwner.Name = "chkMarkPrincipalOwner";
            chkMarkPrincipalOwner.Size = new System.Drawing.Size(278, 19);
            chkMarkPrincipalOwner.TabIndex = 5;
            chkMarkPrincipalOwner.Text = "Make as owner (current owner will be replaced!)";
            chkMarkPrincipalOwner.UseVisualStyleBackColor = true;
            // 
            // btnResolvePrincipalNameRaw
            // 
            btnResolvePrincipalNameRaw.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnResolvePrincipalNameRaw.Enabled = false;
            btnResolvePrincipalNameRaw.Location = new System.Drawing.Point(446, 26);
            btnResolvePrincipalNameRaw.Name = "btnResolvePrincipalNameRaw";
            btnResolvePrincipalNameRaw.Size = new System.Drawing.Size(75, 23);
            btnResolvePrincipalNameRaw.TabIndex = 2;
            btnResolvePrincipalNameRaw.Text = "Resolve";
            btnResolvePrincipalNameRaw.UseVisualStyleBackColor = true;
            btnResolvePrincipalNameRaw.Click += ButtonRawPrincipal_ResolveName;
            // 
            // tbPrincipalNameRaw
            // 
            tbPrincipalNameRaw.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbPrincipalNameRaw.Location = new System.Drawing.Point(94, 26);
            tbPrincipalNameRaw.Name = "tbPrincipalNameRaw";
            tbPrincipalNameRaw.Size = new System.Drawing.Size(346, 23);
            tbPrincipalNameRaw.TabIndex = 1;
            tbPrincipalNameRaw.TextChanged += OwnerNameRaw_EnableResolveName;
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(15, 82);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(73, 15);
            label4.TabIndex = 0;
            label4.Text = "Permissions:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(15, 29);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(73, 15);
            label3.TabIndex = 0;
            label3.Text = "Principal:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSavePermissionEdits
            // 
            btnSavePermissionEdits.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSavePermissionEdits.Enabled = false;
            btnSavePermissionEdits.Location = new System.Drawing.Point(633, 724);
            btnSavePermissionEdits.Name = "btnSavePermissionEdits";
            btnSavePermissionEdits.Size = new System.Drawing.Size(75, 24);
            btnSavePermissionEdits.TabIndex = 2;
            btnSavePermissionEdits.Text = "Save";
            btnSavePermissionEdits.UseVisualStyleBackColor = true;
            btnSavePermissionEdits.Click += AddEditPrincipals_SaveChanges;
            // 
            // btnEditPrincipal
            // 
            btnEditPrincipal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnEditPrincipal.Enabled = false;
            btnEditPrincipal.Location = new System.Drawing.Point(679, 240);
            btnEditPrincipal.Name = "btnEditPrincipal";
            btnEditPrincipal.Size = new System.Drawing.Size(113, 32);
            btnEditPrincipal.TabIndex = 3;
            btnEditPrincipal.Text = "Edit...";
            btnEditPrincipal.UseVisualStyleBackColor = true;
            btnEditPrincipal.Click += ListboxPrincipals_EditSelectedPrincipal;
            // 
            // btnCloseDialog
            // 
            btnCloseDialog.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCloseDialog.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCloseDialog.Location = new System.Drawing.Point(714, 723);
            btnCloseDialog.Name = "btnCloseDialog";
            btnCloseDialog.Size = new System.Drawing.Size(75, 24);
            btnCloseDialog.TabIndex = 3;
            btnCloseDialog.Text = "Close";
            btnCloseDialog.UseVisualStyleBackColor = true;
            btnCloseDialog.Click += CloseDialog_Clicked;
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label6.Location = new System.Drawing.Point(267, 9);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(522, 23);
            label6.TabIndex = 0;
            label6.Text = "Current owner:";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbCurrentOwnerPrincipal
            // 
            tbCurrentOwnerPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tbCurrentOwnerPrincipal.Location = new System.Drawing.Point(270, 36);
            tbCurrentOwnerPrincipal.Name = "tbCurrentOwnerPrincipal";
            tbCurrentOwnerPrincipal.ReadOnly = true;
            tbCurrentOwnerPrincipal.Size = new System.Drawing.Size(519, 23);
            tbCurrentOwnerPrincipal.TabIndex = 5;
            // 
            // btnTakeOwnership
            // 
            btnTakeOwnership.Enabled = false;
            btnTakeOwnership.Location = new System.Drawing.Point(676, 65);
            btnTakeOwnership.Name = "btnTakeOwnership";
            btnTakeOwnership.Size = new System.Drawing.Size(113, 32);
            btnTakeOwnership.TabIndex = 6;
            btnTakeOwnership.Text = "Take ownership";
            btnTakeOwnership.UseVisualStyleBackColor = true;
            btnTakeOwnership.Click += TakeOwnership_Clicked;
            // 
            // btnAddPrincipal
            // 
            btnAddPrincipal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddPrincipal.Location = new System.Drawing.Point(560, 240);
            btnAddPrincipal.Name = "btnAddPrincipal";
            btnAddPrincipal.Size = new System.Drawing.Size(113, 32);
            btnAddPrincipal.TabIndex = 3;
            btnAddPrincipal.Text = "Add...";
            btnAddPrincipal.UseVisualStyleBackColor = true;
            btnAddPrincipal.Click += ListboxPrincipals_AddPrincipal;
            // 
            // AccessControlBrowser
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCloseDialog;
            ClientSize = new System.Drawing.Size(809, 753);
            Controls.Add(btnTakeOwnership);
            Controls.Add(tbCurrentOwnerPrincipal);
            Controls.Add(btnSavePermissionEdits);
            Controls.Add(groupBox1);
            Controls.Add(btnCloseDialog);
            Controls.Add(btnAddPrincipal);
            Controls.Add(btnEditPrincipal);
            Controls.Add(btnDeletePrincipal);
            Controls.Add(lbPrincipalsList);
            Controls.Add(tvFilesystemBrowser);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AccessControlBrowser";
            Text = "Permissions browser";
            Shown += AccessControlBrowser_Shown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            aclLayoutTable.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tvFilesystemBrowser;
        private System.Windows.Forms.ImageList ilFileSystemImages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbPrincipalsList;
        private System.Windows.Forms.Button btnDeletePrincipal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnResolvePrincipalNameRaw;
        private System.Windows.Forms.TextBox tbPrincipalNameRaw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEditPrincipal;
        private System.Windows.Forms.Button btnSavePermissionEdits;
        private System.Windows.Forms.Button btnCloseDialog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCurrentOwnerPrincipal;
        private System.Windows.Forms.Button btnTakeOwnership;
        private System.Windows.Forms.CheckBox chkMarkPrincipalOwner;
        private System.Windows.Forms.TableLayoutPanel aclLayoutTable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox aclTypeCreateDirectory;
        private System.Windows.Forms.ComboBox aclTypeCreateFiles;
        private System.Windows.Forms.ComboBox aclTypeReadAttributes;
        private System.Windows.Forms.ComboBox aclTypeListRead;
        private System.Windows.Forms.ComboBox aclTypeReadPermissions;
        private System.Windows.Forms.ComboBox aclTypeDelete;
        private System.Windows.Forms.ComboBox aclTypeChangePermissions;
        private System.Windows.Forms.ComboBox aclTypeExecute;
        private System.Windows.Forms.ComboBox aclTypeWriteAttributes;
        private System.Windows.Forms.CheckBox diCreateDirectory;
        private System.Windows.Forms.CheckBox diCreateFiles;
        private System.Windows.Forms.CheckBox diReadAttributes;
        private System.Windows.Forms.CheckBox diListRead;
        private System.Windows.Forms.CheckBox diReadPermissions;
        private System.Windows.Forms.CheckBox diDelete;
        private System.Windows.Forms.CheckBox diChangePermissions;
        private System.Windows.Forms.CheckBox diExecute;
        private System.Windows.Forms.CheckBox diWriteAttributes;
        private System.Windows.Forms.CheckBox oiCreateDirectory;
        private System.Windows.Forms.CheckBox oiCreateFiles;
        private System.Windows.Forms.CheckBox oiReadAttributes;
        private System.Windows.Forms.CheckBox oiListRead;
        private System.Windows.Forms.CheckBox oiReadPermissions;
        private System.Windows.Forms.CheckBox oiDelete;
        private System.Windows.Forms.CheckBox oiChangePermissions;
        private System.Windows.Forms.CheckBox oiExecute;
        private System.Windows.Forms.CheckBox oiWriteAttributes;
        private System.Windows.Forms.CheckBox breakCreateDirectory;
        private System.Windows.Forms.CheckBox breakCreateFiles;
        private System.Windows.Forms.CheckBox breakReadAttributes;
        private System.Windows.Forms.CheckBox breakListRead;
        private System.Windows.Forms.CheckBox breakReadPermissions;
        private System.Windows.Forms.CheckBox breakDelete;
        private System.Windows.Forms.CheckBox breakChangePermissions;
        private System.Windows.Forms.CheckBox breakExecute;
        private System.Windows.Forms.CheckBox breakWriteAttributes;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox aclTypeReadExtendedAttributes;
        private System.Windows.Forms.ComboBox aclTypeWriteExtendedAttributes;
        private System.Windows.Forms.ComboBox aclTypeDeleteRecursive;
        private System.Windows.Forms.CheckBox diReadExtendedAttributes;
        private System.Windows.Forms.CheckBox oiReadExtendedAttributes;
        private System.Windows.Forms.CheckBox breakReadExtendedAttributes;
        private System.Windows.Forms.CheckBox diWriteExtendedAttributes;
        private System.Windows.Forms.CheckBox oiWriteExtendedAttributes;
        private System.Windows.Forms.CheckBox breakWriteExtendedAttributes;
        private System.Windows.Forms.CheckBox diDeleteRecursive;
        private System.Windows.Forms.CheckBox oiDeleteRecursive;
        private System.Windows.Forms.CheckBox breakDeleteRecursive;
        private System.Windows.Forms.Button btnAddPrincipal;
    }
}