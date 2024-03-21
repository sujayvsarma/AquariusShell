namespace AquariusShell.Dialogs
{
    partial class ShellItemBrowser
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
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            tvShellItemsTree = new System.Windows.Forms.TreeView();
            imgLstTreeView = new System.Windows.Forms.ImageList(components);
            lvActiveFolderItems = new System.Windows.Forms.ListView();
            imgLstListView = new System.Windows.Forms.ImageList(components);
            btnAccept = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tvShellItemsTree);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lvActiveFolderItems);
            splitContainer1.Size = new System.Drawing.Size(787, 434);
            splitContainer1.SplitterDistance = 262;
            splitContainer1.TabIndex = 1;
            // 
            // tvShellItemsTree
            // 
            tvShellItemsTree.BackColor = System.Drawing.SystemColors.Window;
            tvShellItemsTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tvShellItemsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            tvShellItemsTree.ImageIndex = 0;
            tvShellItemsTree.ImageList = imgLstTreeView;
            tvShellItemsTree.Location = new System.Drawing.Point(0, 0);
            tvShellItemsTree.Name = "tvShellItemsTree";
            tvShellItemsTree.SelectedImageIndex = 0;
            tvShellItemsTree.Size = new System.Drawing.Size(262, 434);
            tvShellItemsTree.TabIndex = 1;
            tvShellItemsTree.BeforeExpand += tvShellItemsTree_LazyLoadChildrenOnExpandAttempt;
            tvShellItemsTree.AfterSelect += tvShellItemsTree_ShowSubItemsInListViewOnItemClick;
            // 
            // imgLstTreeView
            // 
            imgLstTreeView.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imgLstTreeView.ImageSize = new System.Drawing.Size(24, 24);
            imgLstTreeView.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lvActiveFolderItems
            // 
            lvActiveFolderItems.Activation = System.Windows.Forms.ItemActivation.OneClick;
            lvActiveFolderItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lvActiveFolderItems.Dock = System.Windows.Forms.DockStyle.Fill;
            lvActiveFolderItems.LargeImageList = imgLstListView;
            lvActiveFolderItems.Location = new System.Drawing.Point(0, 0);
            lvActiveFolderItems.Name = "lvActiveFolderItems";
            lvActiveFolderItems.ShowGroups = false;
            lvActiveFolderItems.ShowItemToolTips = true;
            lvActiveFolderItems.Size = new System.Drawing.Size(521, 434);
            lvActiveFolderItems.TabIndex = 0;
            lvActiveFolderItems.UseCompatibleStateImageBehavior = false;
            // 
            // imgLstListView
            // 
            imgLstListView.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imgLstListView.ImageSize = new System.Drawing.Size(24, 24);
            imgLstListView.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAccept.Location = new System.Drawing.Point(687, 440);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new System.Drawing.Size(87, 30);
            btnAccept.TabIndex = 2;
            btnAccept.Text = "&OK";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.Location = new System.Drawing.Point(12, 440);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(87, 30);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "C&ancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ShellItemBrowser
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            ClientSize = new System.Drawing.Size(786, 482);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(splitContainer1);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ShellItemBrowser";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Select an app, program or file:";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvShellItemsTree;
        private System.Windows.Forms.ListView lvActiveFolderItems;
        private System.Windows.Forms.ImageList imgLstTreeView;
        private System.Windows.Forms.ImageList imgLstListView;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}