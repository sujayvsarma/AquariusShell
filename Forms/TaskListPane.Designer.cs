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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskListPane));
            btnCloseLauncher = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            lvTasksList = new System.Windows.Forms.ListView();
            lvTaskListImages = new System.Windows.Forms.ImageList(components);
            SuspendLayout();
            // 
            // btnCloseLauncher
            // 
            btnCloseLauncher.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCloseLauncher.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCloseLauncher.Image = (Image)resources.GetObject("btnCloseLauncher.Image");
            btnCloseLauncher.Location = new Point(770, 2);
            btnCloseLauncher.Name = "btnCloseLauncher";
            btnCloseLauncher.Size = new Size(39, 40);
            btnCloseLauncher.TabIndex = 6;
            btnCloseLauncher.UseVisualStyleBackColor = true;
            btnCloseLauncher.Click += btnCloseLauncher_Click;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ButtonFace;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(761, 37);
            label1.TabIndex = 7;
            label1.Text = "Pick a window to switch to";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lvTasksList
            // 
            lvTasksList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            lvTasksList.BackColor = SystemColors.Control;
            lvTasksList.LargeImageList = lvTaskListImages;
            lvTasksList.Location = new Point(3, 43);
            lvTasksList.MultiSelect = false;
            lvTasksList.Name = "lvTasksList";
            lvTasksList.ShowItemToolTips = true;
            lvTasksList.Size = new Size(818, 115);
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
            BackColor = SystemColors.Control;
            ClientSize = new Size(811, 148);
            ControlBox = false;
            Controls.Add(lvTasksList);
            Controls.Add(label1);
            Controls.Add(btnCloseLauncher);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TaskListPane";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnCloseLauncher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvTasksList;
        private System.Windows.Forms.ImageList lvTaskListImages;
    }
}