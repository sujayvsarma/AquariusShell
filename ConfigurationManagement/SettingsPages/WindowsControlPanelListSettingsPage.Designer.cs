namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    partial class WindowsControlPanelListSettingsPage
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
            components = new System.ComponentModel.Container();
            imgLstListView = new System.Windows.Forms.ImageList(components);
            lvActiveFolderItems = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            SuspendLayout();
            // 
            // imgLstListView
            // 
            imgLstListView.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imgLstListView.ImageSize = new System.Drawing.Size(24, 24);
            imgLstListView.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lvActiveFolderItems
            // 
            lvActiveFolderItems.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            lvActiveFolderItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lvActiveFolderItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1 });
            lvActiveFolderItems.Dock = System.Windows.Forms.DockStyle.Fill;
            lvActiveFolderItems.FullRowSelect = true;
            lvActiveFolderItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            lvActiveFolderItems.LargeImageList = imgLstListView;
            lvActiveFolderItems.Location = new System.Drawing.Point(0, 0);
            lvActiveFolderItems.MultiSelect = false;
            lvActiveFolderItems.Name = "lvActiveFolderItems";
            lvActiveFolderItems.ShowGroups = false;
            lvActiveFolderItems.ShowItemToolTips = true;
            lvActiveFolderItems.Size = new System.Drawing.Size(524, 494);
            lvActiveFolderItems.SmallImageList = imgLstListView;
            lvActiveFolderItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            lvActiveFolderItems.TabIndex = 1;
            lvActiveFolderItems.UseCompatibleStateImageBehavior = false;
            lvActiveFolderItems.View = System.Windows.Forms.View.Details;
            lvActiveFolderItems.ItemActivate += lvActiveFolderItems_ItemActivate;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Control Panel Applet Name";
            columnHeader1.Width = 480;
            // 
            // WindowsControlPanelListSettingsPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            Controls.Add(lvActiveFolderItems);
            ForeColor = System.Drawing.Color.White;
            Name = "WindowsControlPanelListSettingsPage";
            Size = new System.Drawing.Size(524, 494);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ImageList imgLstListView;
        private System.Windows.Forms.ListView lvActiveFolderItems;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
