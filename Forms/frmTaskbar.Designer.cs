namespace AquariusShell
{
    partial class frmTaskbar
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaskbar));
            btnStartMenu = new Button();
            imgLstTaskbarIcons32x32 = new ImageList(components);
            taskbuttonsPanel = new FlowLayoutPanel();
            pnlSysTray = new Panel();
            lblClock = new Label();
            tmrClock = new System.Windows.Forms.Timer(components);
            pnlSysTray.SuspendLayout();
            SuspendLayout();
            // 
            // btnStartMenu
            // 
            btnStartMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnStartMenu.BackColor = Color.White;
            btnStartMenu.ImageKey = "Win11Logo";
            btnStartMenu.ImageList = imgLstTaskbarIcons32x32;
            btnStartMenu.Location = new Point(4, 3);
            btnStartMenu.Name = "btnStartMenu";
            btnStartMenu.Size = new Size(42, 36);
            btnStartMenu.TabIndex = 0;
            btnStartMenu.UseVisualStyleBackColor = false;
            btnStartMenu.Click += btnStartMenu_Click;
            // 
            // imgLstTaskbarIcons32x32
            // 
            imgLstTaskbarIcons32x32.ColorDepth = ColorDepth.Depth32Bit;
            imgLstTaskbarIcons32x32.ImageStream = (ImageListStreamer)resources.GetObject("imgLstTaskbarIcons32x32.ImageStream");
            imgLstTaskbarIcons32x32.TransparentColor = Color.Transparent;
            imgLstTaskbarIcons32x32.Images.SetKeyName(0, "Win11Logo");
            // 
            // taskbuttonsPanel
            // 
            taskbuttonsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            taskbuttonsPanel.Location = new Point(52, 0);
            taskbuttonsPanel.Name = "taskbuttonsPanel";
            taskbuttonsPanel.Size = new Size(721, 39);
            taskbuttonsPanel.TabIndex = 1;
            taskbuttonsPanel.WrapContents = false;
            // 
            // pnlSysTray
            // 
            pnlSysTray.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlSysTray.Controls.Add(lblClock);
            pnlSysTray.Location = new Point(779, 0);
            pnlSysTray.Name = "pnlSysTray";
            pnlSysTray.Size = new Size(150, 39);
            pnlSysTray.TabIndex = 2;
            // 
            // lblClock
            // 
            lblClock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblClock.ForeColor = SystemColors.ControlText;
            lblClock.Location = new Point(48, 14);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(99, 15);
            lblClock.TabIndex = 0;
            lblClock.Text = "Jan 01, 2024 14:55";
            lblClock.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tmrClock
            // 
            tmrClock.Interval = 1000;
            tmrClock.Tick += tmrClock_Tick;
            // 
            // frmTaskbar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            BackColor = SystemColors.Control;
            ClientSize = new Size(930, 40);
            ControlBox = false;
            Controls.Add(pnlSysTray);
            Controls.Add(taskbuttonsPanel);
            Controls.Add(btnStartMenu);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmTaskbar";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            FormClosing += frmTaskbar_FormClosing;
            Load += frmTaskbar_Load;
            Shown += frmTaskbar_Shown;
            pnlSysTray.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnStartMenu;
        private ImageList imgLstTaskbarIcons32x32;
        private FlowLayoutPanel taskbuttonsPanel;
        private Panel pnlSysTray;
        private Label lblClock;
        private System.Windows.Forms.Timer tmrClock;
    }
}
