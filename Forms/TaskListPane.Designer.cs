using System.Drawing;

namespace AquariusShell.Forms
{
    partial class TaskListPane
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
            lvTasksList = new System.Windows.Forms.ListView();
            lvTaskListImages = new System.Windows.Forms.ImageList(components);
            SuspendLayout();
            // 
            // lvTasksList
            // 
            lvTasksList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            lvTasksList.BackColor = Color.SteelBlue;
            lvTasksList.Dock = System.Windows.Forms.DockStyle.Fill;
            lvTasksList.LargeImageList = lvTaskListImages;
            lvTasksList.Location = new Point(0, 0);
            lvTasksList.MultiSelect = false;
            lvTasksList.Name = "lvTasksList";
            lvTasksList.ShowItemToolTips = true;
            lvTasksList.Size = new Size(807, 144);
            lvTasksList.TabIndex = 8;
            lvTasksList.UseCompatibleStateImageBehavior = false;
            lvTasksList.ItemActivate += lvTasksList_ItemActivate;
            // 
            // lvTaskListImages
            // 
            lvTaskListImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            lvTaskListImages.ImageSize = new Size(32, 32);
            lvTaskListImages.TransparentColor = Color.Transparent;
            // 
            // TaskListPane
            // 
            BackColor = Color.SteelBlue;
            ClientSize = new Size(807, 144);
            ControlBox = false;
            Controls.Add(lvTasksList);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TaskListPane";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Pick a task to switch to";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListView lvTasksList;
        private System.Windows.Forms.ImageList lvTaskListImages;
    }
}