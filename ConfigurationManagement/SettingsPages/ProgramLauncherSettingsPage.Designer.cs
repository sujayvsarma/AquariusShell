namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    partial class ProgramLauncherSettingsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramLauncherSettingsPage));
            chkShowSearchBox = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            mngLstHiddenItems = new Controls.ManageableShellItemsListbox();
            label2 = new System.Windows.Forms.Label();
            mngLstRequirePasswordItems = new Controls.ManageableShellItemsListbox();
            label3 = new System.Windows.Forms.Label();
            tbPassword = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // chkShowSearchBox
            // 
            chkShowSearchBox.AutoSize = true;
            chkShowSearchBox.Location = new System.Drawing.Point(13, 11);
            chkShowSearchBox.Name = "chkShowSearchBox";
            chkShowSearchBox.Size = new System.Drawing.Size(219, 19);
            chkShowSearchBox.TabIndex = 0;
            chkShowSearchBox.Text = "Show the programs/apps search box";
            chkShowSearchBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 42);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(169, 15);
            label1.TabIndex = 1;
            label1.Text = "Hidden apps, programs or files";
            // 
            // mngLstHiddenItems
            // 
            mngLstHiddenItems.BackColor = System.Drawing.Color.SteelBlue;
            mngLstHiddenItems.ForeColor = System.Drawing.Color.White;
            mngLstHiddenItems.ListboxBackgroundColor = System.Drawing.SystemColors.Window;
            mngLstHiddenItems.Location = new System.Drawing.Point(13, 60);
            mngLstHiddenItems.Name = "mngLstHiddenItems";
            mngLstHiddenItems.Size = new System.Drawing.Size(493, 150);
            mngLstHiddenItems.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(13, 224);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(323, 15);
            label2.TabIndex = 1;
            label2.Text = "Require a password for the following apps, programs or files";
            // 
            // mngLstRequirePasswordItems
            // 
            mngLstRequirePasswordItems.BackColor = System.Drawing.Color.SteelBlue;
            mngLstRequirePasswordItems.ForeColor = System.Drawing.Color.White;
            mngLstRequirePasswordItems.ListboxBackgroundColor = System.Drawing.SystemColors.Window;
            mngLstRequirePasswordItems.Location = new System.Drawing.Point(13, 242);
            mngLstRequirePasswordItems.Name = "mngLstRequirePasswordItems";
            mngLstRequirePasswordItems.Size = new System.Drawing.Size(493, 142);
            mngLstRequirePasswordItems.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(13, 397);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(177, 15);
            label3.TabIndex = 1;
            label3.Text = "Password to launch above items";
            // 
            // tbPassword
            // 
            tbPassword.Location = new System.Drawing.Point(15, 414);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new System.Drawing.Size(491, 23);
            tbPassword.TabIndex = 3;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // ProgramLauncherSettingsPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            Controls.Add(tbPassword);
            Controls.Add(mngLstRequirePasswordItems);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(mngLstHiddenItems);
            Controls.Add(label1);
            Controls.Add(chkShowSearchBox);
            ForeColor = System.Drawing.Color.White;
            Name = "ProgramLauncherSettingsPage";
            Size = new System.Drawing.Size(524, 494);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox chkShowSearchBox;
        private System.Windows.Forms.Label label1;
        private Controls.ManageableShellItemsListbox mngLstHiddenItems;
        private System.Windows.Forms.Label label2;
        private Controls.ManageableShellItemsListbox mngLstRequirePasswordItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPassword;
    }
}
