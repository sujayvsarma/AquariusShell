namespace AquariusShell.ShellApps
{
    partial class FileBrowser
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
            viewImagesLarge = new System.Windows.Forms.ImageList(components);
            fsWatcher = new System.IO.FileSystemWatcher();
            explorerToolbar = new System.Windows.Forms.ToolStrip();
            tssbMyComputer = new System.Windows.Forms.ToolStripSplitButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            tsDDBNew = new System.Windows.Forms.ToolStripDropDownButton();
            tsmiCreateNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            tsbEditCut = new System.Windows.Forms.ToolStripButton();
            tsbEditCopy = new System.Windows.Forms.ToolStripButton();
            tsbEditPaste = new System.Windows.Forms.ToolStripButton();
            tsbEditDelete = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            tsbProperties = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            largeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            tsbRefresh = new System.Windows.Forms.ToolStripButton();
            tsbRecyclebinRestore = new System.Windows.Forms.ToolStripButton();
            lvFileSystemView = new System.Windows.Forms.ListView();
            viewImagesSmall = new System.Windows.Forms.ImageList(components);
            chIcon = new System.Windows.Forms.ColumnHeader();
            chSync = new System.Windows.Forms.ColumnHeader();
            chFileName = new System.Windows.Forms.ColumnHeader();
            chFileType = new System.Windows.Forms.ColumnHeader();
            chFileSize = new System.Windows.Forms.ColumnHeader();
            chLastModified = new System.Windows.Forms.ColumnHeader();
            cmsContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            btnJumpGo = new System.Windows.Forms.Button();
            tbJumpAddress = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)fsWatcher).BeginInit();
            explorerToolbar.SuspendLayout();
            cmsContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // viewImagesLarge
            // 
            viewImagesLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            viewImagesLarge.ImageSize = new System.Drawing.Size(32, 32);
            viewImagesLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // fsWatcher
            // 
            fsWatcher.EnableRaisingEvents = true;
            fsWatcher.NotifyFilter = System.IO.NotifyFilters.FileName;
            fsWatcher.SynchronizingObject = this;
            // 
            // explorerToolbar
            // 
            explorerToolbar.BackColor = System.Drawing.SystemColors.ButtonFace;
            explorerToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tssbMyComputer, toolStripSeparator2, tsDDBNew, toolStripSeparator1, tsbEditCut, tsbEditCopy, tsbEditPaste, tsbEditDelete, toolStripSeparator3, tsbProperties, toolStripSeparator5, toolStripDropDownButton1, toolStripSeparator4, tsbRefresh, tsbRecyclebinRestore });
            explorerToolbar.Location = new System.Drawing.Point(0, 0);
            explorerToolbar.Name = "explorerToolbar";
            explorerToolbar.Size = new System.Drawing.Size(957, 38);
            explorerToolbar.TabIndex = 1;
            // 
            // tssbMyComputer
            // 
            tssbMyComputer.Image = Properties.Resources.computer;
            tssbMyComputer.ImageTransparentColor = System.Drawing.Color.Magenta;
            tssbMyComputer.Name = "tssbMyComputer";
            tssbMyComputer.Size = new System.Drawing.Size(58, 35);
            tssbMyComputer.Text = "My PC";
            tssbMyComputer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tssbMyComputer.ButtonClick += ToolstripButton_MyComputer_ClickEvent;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // tsDDBNew
            // 
            tsDDBNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiCreateNewFolder, tsmiFile });
            tsDDBNew.Image = Properties.Resources.add_circle_filled;
            tsDDBNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsDDBNew.Name = "tsDDBNew";
            tsDDBNew.Size = new System.Drawing.Size(44, 35);
            tsDDBNew.Text = "&New";
            tsDDBNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tsDDBNew.ToolTipText = "Create new file or folder";
            // 
            // tsmiCreateNewFolder
            // 
            tsmiCreateNewFolder.Image = Properties.Resources.folder_open;
            tsmiCreateNewFolder.Name = "tsmiCreateNewFolder";
            tsmiCreateNewFolder.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.N;
            tsmiCreateNewFolder.Size = new System.Drawing.Size(182, 22);
            tsmiCreateNewFolder.Text = "F&older";
            tsmiCreateNewFolder.Click += ToolstripButton_CreateNewFolder_ClickEvent;
            // 
            // tsmiFile
            // 
            tsmiFile.Name = "tsmiFile";
            tsmiFile.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N;
            tsmiFile.Size = new System.Drawing.Size(182, 22);
            tsmiFile.Text = "F&ile";
            tsmiFile.Click += ToolstripButton_CreateNewFile_ClickEvent;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // tsbEditCut
            // 
            tsbEditCut.Image = Properties.Resources.cut;
            tsbEditCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbEditCut.Name = "tsbEditCut";
            tsbEditCut.Size = new System.Drawing.Size(30, 35);
            tsbEditCut.Text = "C&ut";
            tsbEditCut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tsbEditCut.Click += ToolbarOrContextAction_CutItemsEvent;
            // 
            // tsbEditCopy
            // 
            tsbEditCopy.Image = Properties.Resources.copy;
            tsbEditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbEditCopy.Name = "tsbEditCopy";
            tsbEditCopy.Size = new System.Drawing.Size(39, 35);
            tsbEditCopy.Text = "C&opy";
            tsbEditCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tsbEditCopy.Click += ToolbarOrContextAction_CopyItemsEvent;
            // 
            // tsbEditPaste
            // 
            tsbEditPaste.Image = Properties.Resources.paste;
            tsbEditPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbEditPaste.Name = "tsbEditPaste";
            tsbEditPaste.Size = new System.Drawing.Size(39, 35);
            tsbEditPaste.Text = "P&aste";
            tsbEditPaste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tsbEditPaste.Click += ToolbarOrContextAction_PasteEvent;
            // 
            // tsbEditDelete
            // 
            tsbEditDelete.ForeColor = System.Drawing.Color.DarkRed;
            tsbEditDelete.Image = Properties.Resources.delete_stop_error;
            tsbEditDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbEditDelete.Name = "tsbEditDelete";
            tsbEditDelete.Size = new System.Drawing.Size(44, 35);
            tsbEditDelete.Text = "D&elete";
            tsbEditDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tsbEditDelete.Click += ToolbarOrContextAction_DeleteEvent;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // tsbProperties
            // 
            tsbProperties.Image = Properties.Resources.properties_settings_wrench;
            tsbProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbProperties.Name = "tsbProperties";
            tsbProperties.Size = new System.Drawing.Size(64, 35);
            tsbProperties.Text = "P&roperties";
            tsbProperties.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tsbProperties.Click += ToolbarOrContextAction_ShowPropertiesBoxEvent;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { largeIconsToolStripMenuItem, smallIconsToolStripMenuItem, detailsToolStripMenuItem });
            toolStripDropDownButton1.Image = Properties.Resources.show;
            toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new System.Drawing.Size(45, 35);
            toolStripDropDownButton1.Text = "&View";
            toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // largeIconsToolStripMenuItem
            // 
            largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            largeIconsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            largeIconsToolStripMenuItem.Text = "&Large icons";
            largeIconsToolStripMenuItem.Click += largeIconsToolStripMenuItem_Click;
            // 
            // smallIconsToolStripMenuItem
            // 
            smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            smallIconsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            smallIconsToolStripMenuItem.Text = "&Small icons";
            smallIconsToolStripMenuItem.Click += smallIconsToolStripMenuItem_Click;
            // 
            // detailsToolStripMenuItem
            // 
            detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            detailsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            detailsToolStripMenuItem.Text = "&Details";
            detailsToolStripMenuItem.Click += detailsToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // tsbRefresh
            // 
            tsbRefresh.Image = Properties.Resources.undo_restart;
            tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbRefresh.Name = "tsbRefresh";
            tsbRefresh.Size = new System.Drawing.Size(50, 35);
            tsbRefresh.Text = "Re&fresh";
            tsbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tsbRefresh.Click += ToolbarOrContextAction_RefreshViewEvent;
            // 
            // tsbRecyclebinRestore
            // 
            tsbRecyclebinRestore.Enabled = false;
            tsbRecyclebinRestore.Image = Properties.Resources.share_forward;
            tsbRecyclebinRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbRecyclebinRestore.Name = "tsbRecyclebinRestore";
            tsbRecyclebinRestore.Size = new System.Drawing.Size(50, 35);
            tsbRecyclebinRestore.Text = "Restore";
            tsbRecyclebinRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tsbRecyclebinRestore.Click += ToolbarOrContextAction_RestoreFromRecycleBinEvent;
            // 
            // lvFileSystemView
            // 
            lvFileSystemView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            lvFileSystemView.AllowDrop = true;
            lvFileSystemView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lvFileSystemView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lvFileSystemView.Font = new System.Drawing.Font("Segoe UI", 8F);
            lvFileSystemView.FullRowSelect = true;
            lvFileSystemView.LabelEdit = true;
            lvFileSystemView.LargeImageList = viewImagesLarge;
            lvFileSystemView.Location = new System.Drawing.Point(3, 69);
            lvFileSystemView.Name = "lvFileSystemView";
            lvFileSystemView.ShowItemToolTips = true;
            lvFileSystemView.Size = new System.Drawing.Size(952, 453);
            lvFileSystemView.SmallImageList = viewImagesSmall;
            lvFileSystemView.TabIndex = 2;
            lvFileSystemView.UseCompatibleStateImageBehavior = false;
            lvFileSystemView.ItemActivate += lvFileSystemView_ItemActivate;
            lvFileSystemView.DragDrop += lvFileSystemView_DragDrop;
            lvFileSystemView.DragEnter += lvFileSystemView_DragEnter;
            lvFileSystemView.QueryContinueDrag += lvFileSystemView_QueryContinueDrag;
            lvFileSystemView.MouseDown += lvFileSystemView_MouseDown;
            lvFileSystemView.MouseUp += lvFileSystemView_MouseUp;
            // 
            // viewImagesSmall
            // 
            viewImagesSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            viewImagesSmall.ImageSize = new System.Drawing.Size(16, 16);
            viewImagesSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmsContextMenu
            // 
            cmsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripMenuItem1, deleteToolStripMenuItem, restoreToolStripMenuItem, toolStripMenuItem2, refreshToolStripMenuItem, propertiesToolStripMenuItem });
            cmsContextMenu.Name = "cmsContextMenu";
            cmsContextMenu.Size = new System.Drawing.Size(147, 170);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = Properties.Resources.cut;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X;
            cutToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            cutToolStripMenuItem.Text = "C&ut";
            cutToolStripMenuItem.Click += ToolbarOrContextAction_CutItemsEvent;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = Properties.Resources.copy;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C;
            copyToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            copyToolStripMenuItem.Text = "C&opy";
            copyToolStripMenuItem.Click += ToolbarOrContextAction_CopyItemsEvent;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Image = Properties.Resources.paste;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V;
            pasteToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            pasteToolStripMenuItem.Text = "P&aste";
            pasteToolStripMenuItem.Click += ToolbarOrContextAction_PasteEvent;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Image = Properties.Resources.delete_stop_error;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            deleteToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            deleteToolStripMenuItem.Text = "D&elete";
            deleteToolStripMenuItem.Click += ToolbarOrContextAction_DeleteEvent;
            // 
            // restoreToolStripMenuItem
            // 
            restoreToolStripMenuItem.Enabled = false;
            restoreToolStripMenuItem.Image = Properties.Resources.share_forward;
            restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            restoreToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            restoreToolStripMenuItem.Text = "Res&tore";
            restoreToolStripMenuItem.Click += ToolbarOrContextAction_RestoreFromRecycleBinEvent;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(143, 6);
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            refreshToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            refreshToolStripMenuItem.Text = "Re&fresh";
            refreshToolStripMenuItem.Click += ToolbarOrContextAction_RefreshViewEvent;
            // 
            // propertiesToolStripMenuItem
            // 
            propertiesToolStripMenuItem.Image = Properties.Resources.properties_settings_wrench;
            propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            propertiesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            propertiesToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            propertiesToolStripMenuItem.Text = "P&roperties";
            propertiesToolStripMenuItem.Click += ToolbarOrContextAction_ShowPropertiesBoxEvent;
            // 
            // btnJumpGo
            // 
            btnJumpGo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnJumpGo.BackgroundImage = Properties.Resources.openNew;
            btnJumpGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btnJumpGo.Location = new System.Drawing.Point(924, 41);
            btnJumpGo.Name = "btnJumpGo";
            btnJumpGo.Size = new System.Drawing.Size(27, 27);
            btnJumpGo.TabIndex = 5;
            btnJumpGo.UseVisualStyleBackColor = true;
            btnJumpGo.Click += JumpAddressGoButton_ClickEvent;
            // 
            // tbJumpAddress
            // 
            tbJumpAddress.Location = new System.Drawing.Point(57, 44);
            tbJumpAddress.Name = "tbJumpAddress";
            tbJumpAddress.Size = new System.Drawing.Size(861, 23);
            tbJumpAddress.TabIndex = 6;
            tbJumpAddress.WordWrap = false;
            tbJumpAddress.KeyUp += JumpAddressTextbox_EnterKeyPressedEvent;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 47);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 15);
            label1.TabIndex = 7;
            label1.Text = "Go to:";
            // 
            // FileBrowser
            // 
            AutoScroll = true;
            ClientSize = new System.Drawing.Size(957, 526);
            Controls.Add(label1);
            Controls.Add(tbJumpAddress);
            Controls.Add(btnJumpGo);
            Controls.Add(lvFileSystemView);
            Controls.Add(explorerToolbar);
            Name = "FileBrowser";
            Text = "File browser";
            FormClosing += FileBrowser_FormClosing;
            Load += FileBrowser_Load;
            ((System.ComponentModel.ISupportInitialize)fsWatcher).EndInit();
            explorerToolbar.ResumeLayout(false);
            explorerToolbar.PerformLayout();
            cmsContextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.IO.FileSystemWatcher fsWatcher;
        private System.Windows.Forms.ImageList viewImagesLarge;

        #endregion

        private System.Windows.Forms.ToolStrip explorerToolbar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbEditCut;
        private System.Windows.Forms.ToolStripButton tsbEditCopy;
        private System.Windows.Forms.ToolStripButton tsbEditPaste;
        private System.Windows.Forms.ToolStripButton tsbEditDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton tsDDBNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateNewFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbProperties;
        private System.Windows.Forms.ToolStripSplitButton tssbMyComputer;
        private System.Windows.Forms.ListView lvFileSystemView;
        private System.Windows.Forms.ImageList viewImagesSmall;
        private System.Windows.Forms.ColumnHeader chIcon;
        private System.Windows.Forms.ColumnHeader chSync;
        private System.Windows.Forms.ColumnHeader chFileName;
        private System.Windows.Forms.ColumnHeader chFileType;
        private System.Windows.Forms.ColumnHeader chFileSize;
        private System.Windows.Forms.ColumnHeader chLastModified;
        private System.Windows.Forms.ContextMenuStrip cmsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Button btnJumpGo;
        private System.Windows.Forms.TextBox tbJumpAddress;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem largeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbRecyclebinRestore;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}