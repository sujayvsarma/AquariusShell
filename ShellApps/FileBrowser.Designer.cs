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
            tsbRefresh = new System.Windows.Forms.ToolStripButton();
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
            tsbRecyclebinRestore = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            largeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            tsbProperties = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            tspCloseActiveTab = new System.Windows.Forms.ToolStripButton();
            tsbOpenTabNewWindow = new System.Windows.Forms.ToolStripButton();
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
            tbJumpAddress = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            tbTabbedPages = new System.Windows.Forms.TabControl();
            tpDefaultPage = new System.Windows.Forms.TabPage();
            lvDefaultFileBrowser = new System.Windows.Forms.ListView();
            tpAddNewPage = new System.Windows.Forms.TabPage();
            ilTabImages = new System.Windows.Forms.ImageList(components);
            tsbOpenInTerminal = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)fsWatcher).BeginInit();
            explorerToolbar.SuspendLayout();
            cmsContextMenu.SuspendLayout();
            tbTabbedPages.SuspendLayout();
            tpDefaultPage.SuspendLayout();
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
            explorerToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsbRefresh, tssbMyComputer, toolStripSeparator2, tsDDBNew, toolStripSeparator1, tsbEditCut, tsbEditCopy, tsbEditPaste, tsbEditDelete, tsbRecyclebinRestore, toolStripSeparator3, toolStripDropDownButton1, toolStripSeparator5, tsbProperties, toolStripSeparator4, tspCloseActiveTab, tsbOpenTabNewWindow, tsbOpenInTerminal });
            explorerToolbar.Location = new System.Drawing.Point(0, 0);
            explorerToolbar.Name = "explorerToolbar";
            explorerToolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            explorerToolbar.Size = new System.Drawing.Size(957, 25);
            explorerToolbar.TabIndex = 1;
            // 
            // tsbRefresh
            // 
            tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbRefresh.Image = Properties.Resources.undo_restart;
            tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbRefresh.Name = "tsbRefresh";
            tsbRefresh.Size = new System.Drawing.Size(23, 22);
            tsbRefresh.Text = "Re&fresh";
            tsbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tsbRefresh.Click += ToolbarOrContextAction_RefreshViewEvent;
            // 
            // tssbMyComputer
            // 
            tssbMyComputer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tssbMyComputer.Image = Properties.Resources.home;
            tssbMyComputer.ImageTransparentColor = System.Drawing.Color.Magenta;
            tssbMyComputer.Name = "tssbMyComputer";
            tssbMyComputer.Size = new System.Drawing.Size(32, 22);
            tssbMyComputer.Text = "My PC";
            tssbMyComputer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tssbMyComputer.ButtonClick += ToolstripButton_MyComputer_ClickEvent;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsDDBNew
            // 
            tsDDBNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsDDBNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiCreateNewFolder, tsmiFile });
            tsDDBNew.Image = Properties.Resources.add_circle_filled;
            tsDDBNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsDDBNew.Name = "tsDDBNew";
            tsDDBNew.Size = new System.Drawing.Size(29, 22);
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
            toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbEditCut
            // 
            tsbEditCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbEditCut.Image = Properties.Resources.cut;
            tsbEditCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbEditCut.Name = "tsbEditCut";
            tsbEditCut.Size = new System.Drawing.Size(23, 22);
            tsbEditCut.Text = "C&ut";
            tsbEditCut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tsbEditCut.Click += ToolbarOrContextAction_CutItemsEvent;
            // 
            // tsbEditCopy
            // 
            tsbEditCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbEditCopy.Image = Properties.Resources.copy;
            tsbEditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbEditCopy.Name = "tsbEditCopy";
            tsbEditCopy.Size = new System.Drawing.Size(23, 22);
            tsbEditCopy.Text = "C&opy";
            tsbEditCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tsbEditCopy.Click += ToolbarOrContextAction_CopyItemsEvent;
            // 
            // tsbEditPaste
            // 
            tsbEditPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbEditPaste.Image = Properties.Resources.paste;
            tsbEditPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbEditPaste.Name = "tsbEditPaste";
            tsbEditPaste.Size = new System.Drawing.Size(23, 22);
            tsbEditPaste.Text = "P&aste";
            tsbEditPaste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tsbEditPaste.Click += ToolbarOrContextAction_PasteEvent;
            // 
            // tsbEditDelete
            // 
            tsbEditDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbEditDelete.ForeColor = System.Drawing.Color.DarkRed;
            tsbEditDelete.Image = Properties.Resources.trash_solid;
            tsbEditDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbEditDelete.Name = "tsbEditDelete";
            tsbEditDelete.Size = new System.Drawing.Size(23, 22);
            tsbEditDelete.Text = "D&elete";
            tsbEditDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tsbEditDelete.Click += ToolbarOrContextAction_DeleteEvent;
            // 
            // tsbRecyclebinRestore
            // 
            tsbRecyclebinRestore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbRecyclebinRestore.Enabled = false;
            tsbRecyclebinRestore.Image = Properties.Resources.share_forward;
            tsbRecyclebinRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbRecyclebinRestore.Name = "tsbRecyclebinRestore";
            tsbRecyclebinRestore.Size = new System.Drawing.Size(23, 22);
            tsbRecyclebinRestore.Text = "Restore";
            tsbRecyclebinRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tsbRecyclebinRestore.Click += ToolbarOrContextAction_RestoreFromRecycleBinEvent;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { largeIconsToolStripMenuItem, smallIconsToolStripMenuItem, detailsToolStripMenuItem });
            toolStripDropDownButton1.Image = Properties.Resources.list_solid;
            toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            toolStripDropDownButton1.Text = "&View";
            toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // largeIconsToolStripMenuItem
            // 
            largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            largeIconsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            largeIconsToolStripMenuItem.Text = "&Large icons";
            largeIconsToolStripMenuItem.Click += largeIconsToolStripMenuItem_Click;
            // 
            // smallIconsToolStripMenuItem
            // 
            smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            smallIconsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            smallIconsToolStripMenuItem.Text = "&Small icons";
            smallIconsToolStripMenuItem.Click += smallIconsToolStripMenuItem_Click;
            // 
            // detailsToolStripMenuItem
            // 
            detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            detailsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            detailsToolStripMenuItem.Text = "&Details";
            detailsToolStripMenuItem.Click += detailsToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbProperties
            // 
            tsbProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbProperties.Image = Properties.Resources.properties_settings_gears;
            tsbProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbProperties.Name = "tsbProperties";
            tsbProperties.Size = new System.Drawing.Size(23, 22);
            tsbProperties.Text = "P&roperties";
            tsbProperties.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tsbProperties.Click += ToolbarOrContextAction_ShowPropertiesBoxEvent;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tspCloseActiveTab
            // 
            tspCloseActiveTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tspCloseActiveTab.Image = Properties.Resources.delete_stop_error;
            tspCloseActiveTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            tspCloseActiveTab.Name = "tspCloseActiveTab";
            tspCloseActiveTab.Size = new System.Drawing.Size(23, 22);
            tspCloseActiveTab.Text = "Close Tab";
            tspCloseActiveTab.ToolTipText = "Close active tab";
            tspCloseActiveTab.Click += tspCloseActiveTab_Click;
            // 
            // tsbOpenTabNewWindow
            // 
            tsbOpenTabNewWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbOpenTabNewWindow.Image = Properties.Resources.openNew;
            tsbOpenTabNewWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbOpenTabNewWindow.Name = "tsbOpenTabNewWindow";
            tsbOpenTabNewWindow.Size = new System.Drawing.Size(23, 22);
            tsbOpenTabNewWindow.Text = "Open tab in new window";
            tsbOpenTabNewWindow.Click += tsbOpenTabNewWindow_Click;
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
            // tbJumpAddress
            // 
            tbJumpAddress.Location = new System.Drawing.Point(49, 29);
            tbJumpAddress.Name = "tbJumpAddress";
            tbJumpAddress.Size = new System.Drawing.Size(902, 23);
            tbJumpAddress.TabIndex = 6;
            tbJumpAddress.WordWrap = false;
            tbJumpAddress.KeyUp += JumpAddressTextbox_EnterKeyPressedEvent;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(4, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 15);
            label1.TabIndex = 7;
            label1.Text = "Go to:";
            // 
            // tbTabbedPages
            // 
            tbTabbedPages.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbTabbedPages.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            tbTabbedPages.Controls.Add(tpDefaultPage);
            tbTabbedPages.Controls.Add(tpAddNewPage);
            tbTabbedPages.ImageList = ilTabImages;
            tbTabbedPages.ItemSize = new System.Drawing.Size(120, 32);
            tbTabbedPages.Location = new System.Drawing.Point(3, 58);
            tbTabbedPages.Multiline = true;
            tbTabbedPages.Name = "tbTabbedPages";
            tbTabbedPages.Padding = new System.Drawing.Point(3, 3);
            tbTabbedPages.SelectedIndex = 0;
            tbTabbedPages.Size = new System.Drawing.Size(948, 554);
            tbTabbedPages.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tbTabbedPages.TabIndex = 8;
            tbTabbedPages.Selecting += TabPageBeforeClicked_AddNewTabOrRefreshView;
            // 
            // tpDefaultPage
            // 
            tpDefaultPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            tpDefaultPage.Controls.Add(lvDefaultFileBrowser);
            tpDefaultPage.Location = new System.Drawing.Point(4, 36);
            tpDefaultPage.Name = "tpDefaultPage";
            tpDefaultPage.Padding = new System.Windows.Forms.Padding(3);
            tpDefaultPage.Size = new System.Drawing.Size(940, 514);
            tpDefaultPage.TabIndex = 0;
            tpDefaultPage.Text = "My Computer";
            tpDefaultPage.UseVisualStyleBackColor = true;
            // 
            // lvDefaultFileBrowser
            // 
            lvDefaultFileBrowser.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            lvDefaultFileBrowser.AllowDrop = true;
            lvDefaultFileBrowser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lvDefaultFileBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            lvDefaultFileBrowser.Font = new System.Drawing.Font("Segoe UI", 8F);
            lvDefaultFileBrowser.FullRowSelect = true;
            lvDefaultFileBrowser.LabelEdit = true;
            lvDefaultFileBrowser.LargeImageList = viewImagesLarge;
            lvDefaultFileBrowser.Location = new System.Drawing.Point(3, 3);
            lvDefaultFileBrowser.Name = "lvDefaultFileBrowser";
            lvDefaultFileBrowser.ShowItemToolTips = true;
            lvDefaultFileBrowser.Size = new System.Drawing.Size(930, 504);
            lvDefaultFileBrowser.SmallImageList = viewImagesSmall;
            lvDefaultFileBrowser.TabIndex = 3;
            lvDefaultFileBrowser.UseCompatibleStateImageBehavior = false;
            lvDefaultFileBrowser.ItemActivate += lvActiveFileExplorer_ItemActivate;
            lvDefaultFileBrowser.DragDrop += lvActiveFileExplorer_DragDrop;
            lvDefaultFileBrowser.DragEnter += lvActiveFileExplorer_DragEnter;
            lvDefaultFileBrowser.QueryContinueDrag += lvActiveFileExplorer_QueryContinueDrag;
            lvDefaultFileBrowser.MouseDown += lvActiveFileExplorer_MouseDown;
            lvDefaultFileBrowser.MouseUp += lvActiveFileExplorer_MouseUp;
            // 
            // tpAddNewPage
            // 
            tpAddNewPage.Location = new System.Drawing.Point(4, 36);
            tpAddNewPage.Name = "tpAddNewPage";
            tpAddNewPage.Padding = new System.Windows.Forms.Padding(3);
            tpAddNewPage.Size = new System.Drawing.Size(940, 514);
            tpAddNewPage.TabIndex = 1;
            tpAddNewPage.Text = "+ New tab";
            tpAddNewPage.ToolTipText = "Click on this tab to open a new tab that starts in My Computer view.";
            tpAddNewPage.UseVisualStyleBackColor = true;
            // 
            // ilTabImages
            // 
            ilTabImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            ilTabImages.ImageSize = new System.Drawing.Size(16, 16);
            ilTabImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tsbOpenInTerminal
            // 
            tsbOpenInTerminal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbOpenInTerminal.Image = Properties.Resources.terminal_solid;
            tsbOpenInTerminal.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbOpenInTerminal.Name = "tsbOpenInTerminal";
            tsbOpenInTerminal.Size = new System.Drawing.Size(23, 22);
            tsbOpenInTerminal.Text = "Open in command prompt (terminal)";
            tsbOpenInTerminal.Click += tsbOpenInTerminal_Click;
            // 
            // FileBrowser
            // 
            AutoScroll = true;
            ClientSize = new System.Drawing.Size(957, 619);
            Controls.Add(tbTabbedPages);
            Controls.Add(label1);
            Controls.Add(tbJumpAddress);
            Controls.Add(explorerToolbar);
            Name = "FileBrowser";
            Text = "File browser";
            FormClosing += FileBrowser_FormClosing;
            Load += FileBrowser_Load;
            ((System.ComponentModel.ISupportInitialize)fsWatcher).EndInit();
            explorerToolbar.ResumeLayout(false);
            explorerToolbar.PerformLayout();
            cmsContextMenu.ResumeLayout(false);
            tbTabbedPages.ResumeLayout(false);
            tpDefaultPage.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tbTabbedPages;
        private System.Windows.Forms.TabPage tpDefaultPage;
        private System.Windows.Forms.ListView lvDefaultFileBrowser;
        private System.Windows.Forms.TabPage tpAddNewPage;
        private System.Windows.Forms.ImageList ilTabImages;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tspCloseActiveTab;
        private System.Windows.Forms.ToolStripButton tsbOpenTabNewWindow;
        private System.Windows.Forms.ToolStripButton tsbOpenInTerminal;
    }
}