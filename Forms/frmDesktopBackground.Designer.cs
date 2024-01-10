namespace AquariusShell.Forms
{
    partial class frmDesktopBackground
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
            lvDesktopIcons = new ListView();
            iconsList = new ImageList(components);
            SuspendLayout();
            // 
            // lvDesktopIcons
            // 
            lvDesktopIcons.BackColor = Color.SteelBlue;
            lvDesktopIcons.BorderStyle = BorderStyle.None;
            lvDesktopIcons.ForeColor = Color.White;
            lvDesktopIcons.GroupImageList = iconsList;
            lvDesktopIcons.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvDesktopIcons.LargeImageList = iconsList;
            lvDesktopIcons.Location = new Point(12, 12);
            lvDesktopIcons.Name = "lvDesktopIcons";
            lvDesktopIcons.ShowGroups = false;
            lvDesktopIcons.Size = new Size(121, 97);
            lvDesktopIcons.SmallImageList = iconsList;
            lvDesktopIcons.Alignment = ListViewAlignment.Top;
            lvDesktopIcons.View = View.LargeIcon;
            lvDesktopIcons.Sorting = SortOrder.Ascending;
            lvDesktopIcons.StateImageList = iconsList;
            lvDesktopIcons.TabIndex = 0;
            lvDesktopIcons.UseCompatibleStateImageBehavior = false;
            // 
            // iconsList
            // 
            iconsList.ColorDepth = ColorDepth.Depth32Bit;
            iconsList.ImageSize = new Size(32, 32);
            iconsList.TransparentColor = Color.Transparent;
            // 
            // frmDesktopBackground
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(284, 261);
            ControlBox = false;
            Controls.Add(lvDesktopIcons);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(256, 40);
            Name = "frmDesktopBackground";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.Manual;
            Shown += frmDesktopBackground_Shown;
            ResumeLayout(false);
        }

        #endregion

        private ListView lvDesktopIcons;
        private ImageList iconsList;
        private ColumnHeader typeIcon;
        private ColumnHeader Filename;
    }
}