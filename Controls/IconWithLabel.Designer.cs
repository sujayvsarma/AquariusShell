namespace AquariusShell.Controls
{
    partial class IconWithLabel
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
            layoutPanel = new System.Windows.Forms.Panel();
            iconLabel = new System.Windows.Forms.Label();
            icon = new System.Windows.Forms.PictureBox();
            layoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon).BeginInit();
            SuspendLayout();
            // 
            // layoutPanel
            // 
            layoutPanel.Controls.Add(iconLabel);
            layoutPanel.Controls.Add(icon);
            layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutPanel.Location = new System.Drawing.Point(0, 0);
            layoutPanel.Name = "layoutPanel";
            layoutPanel.Size = new System.Drawing.Size(99, 85);
            layoutPanel.TabIndex = 0;
            layoutPanel.MouseDoubleClick += UIElementMouseClick;
            layoutPanel.MouseEnter += UIElementMouseEnter;
            layoutPanel.MouseLeave += UIElementMouseLeave;
            // 
            // iconLabel
            // 
            iconLabel.BackColor = System.Drawing.Color.Transparent;
            iconLabel.Location = new System.Drawing.Point(5, 38);
            iconLabel.Name = "iconLabel";
            iconLabel.Size = new System.Drawing.Size(91, 47);
            iconLabel.TabIndex = 1;
            iconLabel.Text = "(filename)";
            iconLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            iconLabel.MouseDoubleClick += UIElementMouseClick;
            iconLabel.MouseEnter += UIElementMouseEnter;
            iconLabel.MouseLeave += UIElementMouseLeave;
            // 
            // icon
            // 
            icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            icon.Location = new System.Drawing.Point(34, 3);
            icon.Name = "icon";
            icon.Size = new System.Drawing.Size(32, 32);
            icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            icon.TabIndex = 0;
            icon.TabStop = false;
            icon.MouseDoubleClick += UIElementMouseClick;
            icon.MouseEnter += UIElementMouseEnter;
            icon.MouseLeave += UIElementMouseLeave;
            // 
            // IconWithLabel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutPanel);
            Name = "IconWithLabel";
            Size = new System.Drawing.Size(99, 85);
            layoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)icon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel layoutPanel;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.Label iconLabel;
    }
}
