namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    partial class TerminateShellSettingsPage
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
            chkAllowSwitchToExplorer = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            chkShellExit = new System.Windows.Forms.CheckBox();
            chkLogOff = new System.Windows.Forms.CheckBox();
            chkReboot = new System.Windows.Forms.CheckBox();
            chkShutdown = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // chkAllowSwitchToExplorer
            // 
            chkAllowSwitchToExplorer.AutoSize = true;
            chkAllowSwitchToExplorer.Location = new System.Drawing.Point(11, 13);
            chkAllowSwitchToExplorer.Name = "chkAllowSwitchToExplorer";
            chkAllowSwitchToExplorer.Size = new System.Drawing.Size(249, 19);
            chkAllowSwitchToExplorer.TabIndex = 0;
            chkAllowSwitchToExplorer.Text = "Allow switching to Windows Explorer shell";
            chkAllowSwitchToExplorer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 44);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(91, 15);
            label1.TabIndex = 1;
            label1.Text = "Allowed actions";
            // 
            // chkShellExit
            // 
            chkShellExit.AutoSize = true;
            chkShellExit.Location = new System.Drawing.Point(29, 71);
            chkShellExit.Name = "chkShellExit";
            chkShellExit.Size = new System.Drawing.Size(95, 19);
            chkShellExit.TabIndex = 2;
            chkShellExit.Text = "Exit this Shell";
            chkShellExit.UseVisualStyleBackColor = true;
            // 
            // chkLogOff
            // 
            chkLogOff.AutoSize = true;
            chkLogOff.Location = new System.Drawing.Point(29, 96);
            chkLogOff.Name = "chkLogOff";
            chkLogOff.Size = new System.Drawing.Size(130, 19);
            chkLogOff.TabIndex = 2;
            chkLogOff.Text = "Log off current user";
            chkLogOff.UseVisualStyleBackColor = true;
            // 
            // chkReboot
            // 
            chkReboot.AutoSize = true;
            chkReboot.Location = new System.Drawing.Point(29, 121);
            chkReboot.Name = "chkReboot";
            chkReboot.Size = new System.Drawing.Size(139, 19);
            chkReboot.TabIndex = 2;
            chkReboot.Text = "Reboot the computer";
            chkReboot.UseVisualStyleBackColor = true;
            // 
            // chkShutdown
            // 
            chkShutdown.AutoSize = true;
            chkShutdown.Location = new System.Drawing.Point(29, 146);
            chkShutdown.Name = "chkShutdown";
            chkShutdown.Size = new System.Drawing.Size(155, 19);
            chkShutdown.TabIndex = 2;
            chkShutdown.Text = "Shutdown the computer";
            chkShutdown.UseVisualStyleBackColor = true;
            // 
            // TerminateShellSettingsPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            Controls.Add(chkShutdown);
            Controls.Add(chkReboot);
            Controls.Add(chkLogOff);
            Controls.Add(chkShellExit);
            Controls.Add(label1);
            Controls.Add(chkAllowSwitchToExplorer);
            ForeColor = System.Drawing.Color.White;
            Name = "TerminateShellSettingsPage";
            Size = new System.Drawing.Size(524, 494);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox chkAllowSwitchToExplorer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkShellExit;
        private System.Windows.Forms.CheckBox chkLogOff;
        private System.Windows.Forms.CheckBox chkReboot;
        private System.Windows.Forms.CheckBox chkShutdown;
    }
}
