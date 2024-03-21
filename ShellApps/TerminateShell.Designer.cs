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
            cbShutdownSwitchToExplorer = new System.Windows.Forms.CheckBox();
            btnAction = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            cbForce = new System.Windows.Forms.CheckBox();
            cbShutdownAction = new System.Windows.Forms.ComboBox();
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
            // cbShutdownSwitchToExplorer
            // 
            cbShutdownSwitchToExplorer.AutoSize = true;
            cbShutdownSwitchToExplorer.Location = new System.Drawing.Point(9, 54);
            cbShutdownSwitchToExplorer.Name = "cbShutdownSwitchToExplorer";
            cbShutdownSwitchToExplorer.Size = new System.Drawing.Size(352, 19);
            cbShutdownSwitchToExplorer.TabIndex = 2;
            cbShutdownSwitchToExplorer.Text = "Switch to Windows Explorer the next time my computer starts";
            cbShutdownSwitchToExplorer.UseVisualStyleBackColor = true;
            // 
            // btnAction
            // 
            btnAction.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnAction.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAction.Location = new System.Drawing.Point(319, 119);
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
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.Location = new System.Drawing.Point(12, 119);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "C&ancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // cbForce
            // 
            cbForce.AutoSize = true;
            cbForce.Location = new System.Drawing.Point(9, 79);
            cbForce.Name = "cbForce";
            cbForce.Size = new System.Drawing.Size(283, 19);
            cbForce.TabIndex = 6;
            cbForce.Text = "Force (ignore running apps and logged on users)";
            cbForce.UseVisualStyleBackColor = true;
            // 
            // cbShutdownAction
            // 
            cbShutdownAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbShutdownAction.FormattingEnabled = true;
            cbShutdownAction.Location = new System.Drawing.Point(9, 25);
            cbShutdownAction.Name = "cbShutdownAction";
            cbShutdownAction.Size = new System.Drawing.Size(386, 23);
            cbShutdownAction.TabIndex = 7;
            // 
            // TerminateShell
            // 
            AcceptButton = btnAction;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(406, 154);
            Controls.Add(cbShutdownAction);
            Controls.Add(cbForce);
            Controls.Add(btnCancel);
            Controls.Add(btnAction);
            Controls.Add(cbShutdownSwitchToExplorer);
            Controls.Add(label1);
            ForeColor = System.Drawing.Color.White;
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
        private System.Windows.Forms.CheckBox cbShutdownSwitchToExplorer;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbForce;
        private System.Windows.Forms.ComboBox cbShutdownAction;
    }
}