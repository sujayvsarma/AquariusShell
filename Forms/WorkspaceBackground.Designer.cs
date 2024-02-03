namespace AquariusShell.Forms
{
    partial class WorkspaceBackground
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
            backgroundChangerTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // backgroundChangerTimer
            // 
            backgroundChangerTimer.Tick += backgroundChangerTimer_Tick;
            // 
            // WorkspaceBackground
            // 
            AllowDrop = true;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            BackColor = System.Drawing.Color.SteelBlue;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            CausesValidation = false;
            ClientSize = new System.Drawing.Size(800, 450);
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WorkspaceBackground";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            FormClosing += WorkspaceBackground_FormClosing;
            Shown += WorkspaceBackground_Shown;
            ResizeEnd += WorkspaceBackground_ResizeEnd;
            DragDrop += WorkspaceBackground_DragDrop;
            DragEnter += WorkspaceBackground_DragEnter;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer backgroundChangerTimer;
    }
}