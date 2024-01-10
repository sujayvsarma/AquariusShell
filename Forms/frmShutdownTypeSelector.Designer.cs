namespace AquariusShell
{
    partial class frmShutdownTypeSelector
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
            groupBox1 = new GroupBox();
            rbReboot = new RadioButton();
            rbLogOff = new RadioButton();
            rbShutdown = new RadioButton();
            btnDoShutdownAction = new Button();
            btnCancelShutdownAction = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbReboot);
            groupBox1.Controls.Add(rbLogOff);
            groupBox1.Controls.Add(rbShutdown);
            groupBox1.Location = new Point(12, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(388, 111);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select the type of shutdown action to perform:";
            // 
            // rbReboot
            // 
            rbReboot.AutoSize = true;
            rbReboot.Location = new Point(15, 75);
            rbReboot.Name = "rbReboot";
            rbReboot.Size = new Size(188, 19);
            rbReboot.TabIndex = 4;
            rbReboot.TabStop = true;
            rbReboot.Text = "Reboot or restart my computer";
            rbReboot.UseVisualStyleBackColor = true;
            // 
            // rbLogOff
            // 
            rbLogOff.AutoSize = true;
            rbLogOff.Location = new Point(15, 25);
            rbLogOff.Name = "rbLogOff";
            rbLogOff.Size = new Size(274, 19);
            rbLogOff.TabIndex = 5;
            rbLogOff.TabStop = true;
            rbLogOff.Text = "Exit all my programs and log me off the system";
            rbLogOff.UseVisualStyleBackColor = true;
            // 
            // rbShutdown
            // 
            rbShutdown.AutoSize = true;
            rbShutdown.Location = new Point(15, 50);
            rbShutdown.Name = "rbShutdown";
            rbShutdown.Size = new Size(267, 19);
            rbShutdown.TabIndex = 5;
            rbShutdown.TabStop = true;
            rbShutdown.Text = "Exit all programs and shutdown my computer";
            rbShutdown.UseVisualStyleBackColor = true;
            // 
            // btnDoShutdownAction
            // 
            btnDoShutdownAction.DialogResult = DialogResult.OK;
            btnDoShutdownAction.Location = new Point(300, 128);
            btnDoShutdownAction.Name = "btnDoShutdownAction";
            btnDoShutdownAction.Size = new Size(100, 36);
            btnDoShutdownAction.TabIndex = 1;
            btnDoShutdownAction.Text = "&OK";
            btnDoShutdownAction.UseVisualStyleBackColor = true;
            btnDoShutdownAction.Click += btnDoShutdownAction_Click;
            // 
            // btnCancelShutdownAction
            // 
            btnCancelShutdownAction.DialogResult = DialogResult.Cancel;
            btnCancelShutdownAction.Location = new Point(12, 128);
            btnCancelShutdownAction.Name = "btnCancelShutdownAction";
            btnCancelShutdownAction.Size = new Size(100, 36);
            btnCancelShutdownAction.TabIndex = 1;
            btnCancelShutdownAction.Text = "C&ancel";
            btnCancelShutdownAction.UseVisualStyleBackColor = true;
            btnCancelShutdownAction.Click += btnCancelShutdownAction_Click;
            // 
            // frmShutdownTypeSelector
            // 
            AcceptButton = btnDoShutdownAction;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelShutdownAction;
            ClientSize = new Size(412, 171);
            ControlBox = false;
            Controls.Add(btnCancelShutdownAction);
            Controls.Add(btnDoShutdownAction);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmShutdownTypeSelector";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shutdown system";
            TopMost = true;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton rbHibernate;
        private RadioButton rbSleep;
        private RadioButton rbReboot;
        private RadioButton rbShutdown;
        private Button btnDoShutdownAction;
        private Button btnCancelShutdownAction;
        private RadioButton rbLogOff;
    }
}