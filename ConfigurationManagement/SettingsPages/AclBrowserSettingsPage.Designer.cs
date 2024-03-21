namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    partial class AclBrowserSettingsPage
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
            tbLauncherCaption = new System.Windows.Forms.TextBox();
            pbLauncherIcon = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            chkShowAppOnLauncher = new System.Windows.Forms.CheckBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            chkPrincipalAdd = new System.Windows.Forms.CheckBox();
            chkPrincipalEdit = new System.Windows.Forms.CheckBox();
            chkPrincipalDelete = new System.Windows.Forms.CheckBox();
            chkPrincipalReplaceOwner = new System.Windows.Forms.CheckBox();
            chkPrincipalAllowTakeOwnership = new System.Windows.Forms.CheckBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            chkAclStandalone = new System.Windows.Forms.CheckBox();
            chkAclOi = new System.Windows.Forms.CheckBox();
            chkAclCi = new System.Windows.Forms.CheckBox();
            chkAclDeny = new System.Windows.Forms.CheckBox();
            chkAclAllow = new System.Windows.Forms.CheckBox();
            ofdFindLauncherIcon = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pbLauncherIcon).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // tbLauncherCaption
            // 
            tbLauncherCaption.Location = new System.Drawing.Point(77, 53);
            tbLauncherCaption.Name = "tbLauncherCaption";
            tbLauncherCaption.Size = new System.Drawing.Size(422, 23);
            tbLauncherCaption.TabIndex = 19;
            // 
            // pbLauncherIcon
            // 
            pbLauncherIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pbLauncherIcon.Location = new System.Drawing.Point(35, 51);
            pbLauncherIcon.Name = "pbLauncherIcon";
            pbLauncherIcon.Size = new System.Drawing.Size(24, 24);
            pbLauncherIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbLauncherIcon.TabIndex = 17;
            pbLauncherIcon.TabStop = false;
            pbLauncherIcon.Click += pbLauncherIcon_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(77, 33);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(49, 15);
            label1.TabIndex = 15;
            label1.Text = "Caption";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(33, 33);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(30, 15);
            label2.TabIndex = 16;
            label2.Text = "Icon";
            // 
            // chkShowAppOnLauncher
            // 
            chkShowAppOnLauncher.AutoSize = true;
            chkShowAppOnLauncher.Location = new System.Drawing.Point(14, 12);
            chkShowAppOnLauncher.Name = "chkShowAppOnLauncher";
            chkShowAppOnLauncher.Size = new System.Drawing.Size(347, 19);
            chkShowAppOnLauncher.TabIndex = 13;
            chkShowAppOnLauncher.Text = "Show the Permissions Browser app on the Program Launcher";
            chkShowAppOnLauncher.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkPrincipalAdd);
            groupBox2.Controls.Add(chkPrincipalEdit);
            groupBox2.Controls.Add(chkPrincipalDelete);
            groupBox2.Controls.Add(chkPrincipalReplaceOwner);
            groupBox2.Controls.Add(chkPrincipalAllowTakeOwnership);
            groupBox2.ForeColor = System.Drawing.Color.White;
            groupBox2.Location = new System.Drawing.Point(14, 87);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(484, 152);
            groupBox2.TabIndex = 21;
            groupBox2.TabStop = false;
            groupBox2.Text = "Principal edit options";
            // 
            // chkPrincipalAdd
            // 
            chkPrincipalAdd.AutoSize = true;
            chkPrincipalAdd.Location = new System.Drawing.Point(16, 122);
            chkPrincipalAdd.Name = "chkPrincipalAdd";
            chkPrincipalAdd.Size = new System.Drawing.Size(267, 19);
            chkPrincipalAdd.TabIndex = 0;
            chkPrincipalAdd.Text = "Allow adding new principals with permissions";
            chkPrincipalAdd.UseVisualStyleBackColor = true;
            // 
            // chkPrincipalEdit
            // 
            chkPrincipalEdit.AutoSize = true;
            chkPrincipalEdit.Location = new System.Drawing.Point(16, 97);
            chkPrincipalEdit.Name = "chkPrincipalEdit";
            chkPrincipalEdit.Size = new System.Drawing.Size(229, 19);
            chkPrincipalEdit.TabIndex = 0;
            chkPrincipalEdit.Text = "Allow editing permissions for principal";
            chkPrincipalEdit.UseVisualStyleBackColor = true;
            // 
            // chkPrincipalDelete
            // 
            chkPrincipalDelete.AutoSize = true;
            chkPrincipalDelete.Location = new System.Drawing.Point(16, 72);
            chkPrincipalDelete.Name = "chkPrincipalDelete";
            chkPrincipalDelete.Size = new System.Drawing.Size(225, 19);
            chkPrincipalDelete.TabIndex = 0;
            chkPrincipalDelete.Text = "Allow deleting permissioned principal";
            chkPrincipalDelete.UseVisualStyleBackColor = true;
            // 
            // chkPrincipalReplaceOwner
            // 
            chkPrincipalReplaceOwner.AutoSize = true;
            chkPrincipalReplaceOwner.Location = new System.Drawing.Point(16, 47);
            chkPrincipalReplaceOwner.Name = "chkPrincipalReplaceOwner";
            chkPrincipalReplaceOwner.Size = new System.Drawing.Size(263, 19);
            chkPrincipalReplaceOwner.TabIndex = 0;
            chkPrincipalReplaceOwner.Text = "Allow replacing owner with another principal";
            chkPrincipalReplaceOwner.UseVisualStyleBackColor = true;
            // 
            // chkPrincipalAllowTakeOwnership
            // 
            chkPrincipalAllowTakeOwnership.AutoSize = true;
            chkPrincipalAllowTakeOwnership.Location = new System.Drawing.Point(16, 22);
            chkPrincipalAllowTakeOwnership.Name = "chkPrincipalAllowTakeOwnership";
            chkPrincipalAllowTakeOwnership.Size = new System.Drawing.Size(168, 19);
            chkPrincipalAllowTakeOwnership.TabIndex = 0;
            chkPrincipalAllowTakeOwnership.Text = "Allow capturing ownership";
            chkPrincipalAllowTakeOwnership.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(chkAclStandalone);
            groupBox3.Controls.Add(chkAclOi);
            groupBox3.Controls.Add(chkAclCi);
            groupBox3.Controls.Add(chkAclDeny);
            groupBox3.Controls.Add(chkAclAllow);
            groupBox3.ForeColor = System.Drawing.Color.White;
            groupBox3.Location = new System.Drawing.Point(14, 245);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(484, 158);
            groupBox3.TabIndex = 22;
            groupBox3.TabStop = false;
            groupBox3.Text = "Types of permissions to allow";
            // 
            // chkAclStandalone
            // 
            chkAclStandalone.AutoSize = true;
            chkAclStandalone.Location = new System.Drawing.Point(16, 122);
            chkAclStandalone.Name = "chkAclStandalone";
            chkAclStandalone.Size = new System.Drawing.Size(230, 19);
            chkAclStandalone.TabIndex = 0;
            chkAclStandalone.Text = "Standalone (not inherited) permissions";
            chkAclStandalone.UseVisualStyleBackColor = true;
            // 
            // chkAclOi
            // 
            chkAclOi.AutoSize = true;
            chkAclOi.Location = new System.Drawing.Point(16, 97);
            chkAclOi.Name = "chkAclOi";
            chkAclOi.Size = new System.Drawing.Size(119, 19);
            chkAclOi.TabIndex = 0;
            chkAclOi.Text = "File-inherited (OI)";
            chkAclOi.UseVisualStyleBackColor = true;
            // 
            // chkAclCi
            // 
            chkAclCi.AutoSize = true;
            chkAclCi.Location = new System.Drawing.Point(16, 72);
            chkAclCi.Name = "chkAclCi";
            chkAclCi.Size = new System.Drawing.Size(148, 19);
            chkAclCi.TabIndex = 0;
            chkAclCi.Text = "Directory-inherited (CI)";
            chkAclCi.UseVisualStyleBackColor = true;
            // 
            // chkAclDeny
            // 
            chkAclDeny.AutoSize = true;
            chkAclDeny.Location = new System.Drawing.Point(16, 47);
            chkAclDeny.Name = "chkAclDeny";
            chkAclDeny.Size = new System.Drawing.Size(129, 19);
            chkAclDeny.TabIndex = 0;
            chkAclDeny.Text = "\"Deny\" permissions";
            chkAclDeny.UseVisualStyleBackColor = true;
            // 
            // chkAclAllow
            // 
            chkAclAllow.AutoSize = true;
            chkAclAllow.Location = new System.Drawing.Point(16, 22);
            chkAclAllow.Name = "chkAclAllow";
            chkAclAllow.Size = new System.Drawing.Size(132, 19);
            chkAclAllow.TabIndex = 0;
            chkAclAllow.Text = "\"Allow\" permissions";
            chkAclAllow.UseVisualStyleBackColor = true;
            // 
            // ofdFindLauncherIcon
            // 
            ofdFindLauncherIcon.Filter = "All supported types (*.jpg,*.png,*.ico)|*.jpg;*.png;*.ico";
            ofdFindLauncherIcon.OkRequiresInteraction = true;
            ofdFindLauncherIcon.RestoreDirectory = true;
            ofdFindLauncherIcon.ShowPreview = true;
            ofdFindLauncherIcon.SupportMultiDottedExtensions = true;
            // 
            // AclBrowserSettingsPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(tbLauncherCaption);
            Controls.Add(pbLauncherIcon);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(chkShowAppOnLauncher);
            ForeColor = System.Drawing.Color.White;
            Name = "AclBrowserSettingsPage";
            Size = new System.Drawing.Size(524, 494);
            ((System.ComponentModel.ISupportInitialize)pbLauncherIcon).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox tbLauncherCaption;
        private System.Windows.Forms.PictureBox pbLauncherIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkShowAppOnLauncher;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkPrincipalAdd;
        private System.Windows.Forms.CheckBox chkPrincipalEdit;
        private System.Windows.Forms.CheckBox chkPrincipalDelete;
        private System.Windows.Forms.CheckBox chkPrincipalReplaceOwner;
        private System.Windows.Forms.CheckBox chkPrincipalAllowTakeOwnership;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkAclDeny;
        private System.Windows.Forms.CheckBox chkAclAllow;
        private System.Windows.Forms.CheckBox chkAclOi;
        private System.Windows.Forms.CheckBox chkAclCi;
        private System.Windows.Forms.CheckBox chkAclStandalone;
        private System.Windows.Forms.OpenFileDialog ofdFindLauncherIcon;
    }
}
