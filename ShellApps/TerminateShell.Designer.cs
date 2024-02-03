namespace AquariusShell.ShellApps
{
    partial class TerminateShell
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
            label1 = new System.Windows.Forms.Label();
            rbShutdown = new System.Windows.Forms.RadioButton();
            rbReboot = new System.Windows.Forms.RadioButton();
            rbLogOff = new System.Windows.Forms.RadioButton();
            rbSwitchShell = new System.Windows.Forms.RadioButton();
            rbAdvancedExitShell = new System.Windows.Forms.RadioButton();
            cbRebootSwitchToExplorer = new System.Windows.Forms.CheckBox();
            cbShutdownSwitchToExplorer = new System.Windows.Forms.CheckBox();
            btnAction = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            horizontalLine1 = new Controls.HorizontalLine();
            horizontalLine2 = new Controls.HorizontalLine();
            cbForce = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(4, 5);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(578, 23);
            label1.TabIndex = 0;
            label1.Text = "Select the action to perform. No further confirmations will be prompted.";
            // 
            // rbShutdown
            // 
            rbShutdown.AutoSize = true;
            rbShutdown.Location = new System.Drawing.Point(12, 38);
            rbShutdown.Name = "rbShutdown";
            rbShutdown.Size = new System.Drawing.Size(333, 19);
            rbShutdown.TabIndex = 1;
            rbShutdown.TabStop = true;
            rbShutdown.Text = "Shutdown the computer (will be powered off if supported)";
            rbShutdown.UseVisualStyleBackColor = true;
            // 
            // rbReboot
            // 
            rbReboot.AutoSize = true;
            rbReboot.Location = new System.Drawing.Point(12, 84);
            rbReboot.Name = "rbReboot";
            rbReboot.Size = new System.Drawing.Size(138, 19);
            rbReboot.TabIndex = 1;
            rbReboot.TabStop = true;
            rbReboot.Text = "Reboot the computer";
            rbReboot.UseVisualStyleBackColor = true;
            // 
            // rbLogOff
            // 
            rbLogOff.AutoSize = true;
            rbLogOff.Location = new System.Drawing.Point(12, 134);
            rbLogOff.Name = "rbLogOff";
            rbLogOff.Size = new System.Drawing.Size(86, 19);
            rbLogOff.TabIndex = 1;
            rbLogOff.TabStop = true;
            rbLogOff.Text = "Log me out";
            rbLogOff.UseVisualStyleBackColor = true;
            // 
            // rbSwitchShell
            // 
            rbSwitchShell.AutoSize = true;
            rbSwitchShell.Location = new System.Drawing.Point(12, 159);
            rbSwitchShell.Name = "rbSwitchShell";
            rbSwitchShell.Size = new System.Drawing.Size(172, 19);
            rbSwitchShell.TabIndex = 1;
            rbSwitchShell.TabStop = true;
            rbSwitchShell.Text = "Switch to Windows Explorer";
            rbSwitchShell.UseVisualStyleBackColor = true;
            // 
            // rbAdvancedExitShell
            // 
            rbAdvancedExitShell.AutoSize = true;
            rbAdvancedExitShell.Location = new System.Drawing.Point(12, 184);
            rbAdvancedExitShell.Name = "rbAdvancedExitShell";
            rbAdvancedExitShell.Size = new System.Drawing.Size(184, 19);
            rbAdvancedExitShell.TabIndex = 1;
            rbAdvancedExitShell.TabStop = true;
            rbAdvancedExitShell.Text = "Exit Shell (...to a blank screen!)";
            rbAdvancedExitShell.UseVisualStyleBackColor = true;
            // 
            // cbRebootSwitchToExplorer
            // 
            cbRebootSwitchToExplorer.AutoSize = true;
            cbRebootSwitchToExplorer.Location = new System.Drawing.Point(31, 109);
            cbRebootSwitchToExplorer.Name = "cbRebootSwitchToExplorer";
            cbRebootSwitchToExplorer.Size = new System.Drawing.Size(352, 19);
            cbRebootSwitchToExplorer.TabIndex = 2;
            cbRebootSwitchToExplorer.Text = "Switch to Windows Explorer the next time my computer starts";
            cbRebootSwitchToExplorer.UseVisualStyleBackColor = true;
            // 
            // cbShutdownSwitchToExplorer
            // 
            cbShutdownSwitchToExplorer.AutoSize = true;
            cbShutdownSwitchToExplorer.Location = new System.Drawing.Point(31, 63);
            cbShutdownSwitchToExplorer.Name = "cbShutdownSwitchToExplorer";
            cbShutdownSwitchToExplorer.Size = new System.Drawing.Size(352, 19);
            cbShutdownSwitchToExplorer.TabIndex = 2;
            cbShutdownSwitchToExplorer.Text = "Switch to Windows Explorer the next time my computer starts";
            cbShutdownSwitchToExplorer.UseVisualStyleBackColor = true;
            // 
            // btnAction
            // 
            btnAction.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnAction.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnAction.Location = new System.Drawing.Point(12, 224);
            btnAction.Name = "btnAction";
            btnAction.Size = new System.Drawing.Size(75, 23);
            btnAction.TabIndex = 3;
            btnAction.Text = "OK";
            btnAction.UseVisualStyleBackColor = true;
            btnAction.Click += btnAction_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(507, 224);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "C&ancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // horizontalLine1
            // 
            horizontalLine1.BackColor = System.Drawing.SystemColors.ControlText;
            horizontalLine1.Location = new System.Drawing.Point(4, 31);
            horizontalLine1.Name = "horizontalLine1";
            horizontalLine1.Size = new System.Drawing.Size(578, 1);
            horizontalLine1.TabIndex = 5;
            // 
            // horizontalLine2
            // 
            horizontalLine2.BackColor = System.Drawing.SystemColors.ControlText;
            horizontalLine2.Location = new System.Drawing.Point(4, 209);
            horizontalLine2.Name = "horizontalLine2";
            horizontalLine2.Size = new System.Drawing.Size(578, 1);
            horizontalLine2.TabIndex = 5;
            // 
            // cbForce
            // 
            cbForce.AutoSize = true;
            cbForce.Location = new System.Drawing.Point(93, 227);
            cbForce.Name = "cbForce";
            cbForce.Size = new System.Drawing.Size(283, 19);
            cbForce.TabIndex = 6;
            cbForce.Text = "Force (ignore running apps and logged on users)";
            cbForce.UseVisualStyleBackColor = true;
            // 
            // TerminateShell
            // 
            AcceptButton = btnAction;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(594, 259);
            Controls.Add(cbForce);
            Controls.Add(horizontalLine2);
            Controls.Add(horizontalLine1);
            Controls.Add(btnCancel);
            Controls.Add(btnAction);
            Controls.Add(cbShutdownSwitchToExplorer);
            Controls.Add(cbRebootSwitchToExplorer);
            Controls.Add(rbAdvancedExitShell);
            Controls.Add(rbSwitchShell);
            Controls.Add(rbLogOff);
            Controls.Add(rbReboot);
            Controls.Add(rbShutdown);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TerminateShell";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Terminate";
            TopMost = true;
            FormClosing += TerminateShell_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbShutdown;
        private System.Windows.Forms.RadioButton rbReboot;
        private System.Windows.Forms.RadioButton rbLogOff;
        private System.Windows.Forms.RadioButton rbSwitchShell;
        private System.Windows.Forms.RadioButton rbAdvancedExitShell;
        private System.Windows.Forms.CheckBox cbRebootSwitchToExplorer;
        private System.Windows.Forms.CheckBox cbShutdownSwitchToExplorer;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Button btnCancel;
        private Controls.HorizontalLine horizontalLine1;
        private Controls.HorizontalLine horizontalLine2;
        private System.Windows.Forms.CheckBox cbForce;
    }
}