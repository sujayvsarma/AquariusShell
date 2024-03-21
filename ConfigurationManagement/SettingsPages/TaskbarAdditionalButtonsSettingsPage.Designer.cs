namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    partial class TaskbarAdditionalButtonsSettingsPage
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
            flpDefinedButtons = new System.Windows.Forms.FlowLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            pbButtonIcon = new System.Windows.Forms.PictureBox();
            label2 = new System.Windows.Forms.Label();
            tbCaption = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            tbCustomCommand = new System.Windows.Forms.TextBox();
            cmbBuiltInCommands = new System.Windows.Forms.ComboBox();
            btnAddButton = new System.Windows.Forms.Button();
            btnUpdateButton = new System.Windows.Forms.Button();
            btnDeleteButton = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            ofdPickButtonIcon = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pbButtonIcon).BeginInit();
            SuspendLayout();
            // 
            // flpDefinedButtons
            // 
            flpDefinedButtons.AutoScroll = true;
            flpDefinedButtons.Font = new System.Drawing.Font("Segoe UI", 8F);
            flpDefinedButtons.Location = new System.Drawing.Point(12, 196);
            flpDefinedButtons.Name = "flpDefinedButtons";
            flpDefinedButtons.Padding = new System.Windows.Forms.Padding(3);
            flpDefinedButtons.Size = new System.Drawing.Size(502, 284);
            flpDefinedButtons.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(30, 15);
            label1.TabIndex = 1;
            label1.Text = "Icon";
            // 
            // pbButtonIcon
            // 
            pbButtonIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pbButtonIcon.Location = new System.Drawing.Point(119, 12);
            pbButtonIcon.Name = "pbButtonIcon";
            pbButtonIcon.Size = new System.Drawing.Size(24, 24);
            pbButtonIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbButtonIcon.TabIndex = 2;
            pbButtonIcon.TabStop = false;
            pbButtonIcon.Click += pbButtonIcon_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(9, 46);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(104, 15);
            label2.TabIndex = 1;
            label2.Text = "Caption (optional)";
            // 
            // tbCaption
            // 
            tbCaption.Location = new System.Drawing.Point(119, 43);
            tbCaption.Name = "tbCaption";
            tbCaption.Size = new System.Drawing.Size(395, 23);
            tbCaption.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(9, 74);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(64, 15);
            label3.TabIndex = 1;
            label3.Text = "Command";
            // 
            // tbCustomCommand
            // 
            tbCustomCommand.Location = new System.Drawing.Point(119, 103);
            tbCustomCommand.Name = "tbCustomCommand";
            tbCustomCommand.Size = new System.Drawing.Size(395, 23);
            tbCustomCommand.TabIndex = 3;
            // 
            // cmbBuiltInCommands
            // 
            cmbBuiltInCommands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbBuiltInCommands.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbBuiltInCommands.FormattingEnabled = true;
            cmbBuiltInCommands.Location = new System.Drawing.Point(119, 74);
            cmbBuiltInCommands.Name = "cmbBuiltInCommands";
            cmbBuiltInCommands.Size = new System.Drawing.Size(395, 23);
            cmbBuiltInCommands.TabIndex = 4;
            cmbBuiltInCommands.SelectedIndexChanged += cmbBuiltInCommands_SelectedIndexChanged;
            // 
            // btnAddButton
            // 
            btnAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddButton.Location = new System.Drawing.Point(434, 132);
            btnAddButton.Name = "btnAddButton";
            btnAddButton.Size = new System.Drawing.Size(80, 28);
            btnAddButton.TabIndex = 5;
            btnAddButton.Text = "&Add";
            btnAddButton.UseVisualStyleBackColor = true;
            btnAddButton.Click += btnAddButton_Click;
            // 
            // btnUpdateButton
            // 
            btnUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUpdateButton.Location = new System.Drawing.Point(348, 132);
            btnUpdateButton.Name = "btnUpdateButton";
            btnUpdateButton.Size = new System.Drawing.Size(80, 28);
            btnUpdateButton.TabIndex = 5;
            btnUpdateButton.Text = "&Update";
            btnUpdateButton.UseVisualStyleBackColor = true;
            btnUpdateButton.Click += btnUpdateButton_Click;
            // 
            // btnDeleteButton
            // 
            btnDeleteButton.BackColor = System.Drawing.Color.Red;
            btnDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDeleteButton.Location = new System.Drawing.Point(119, 132);
            btnDeleteButton.Name = "btnDeleteButton";
            btnDeleteButton.Size = new System.Drawing.Size(80, 28);
            btnDeleteButton.TabIndex = 5;
            btnDeleteButton.Text = "D&elete";
            btnDeleteButton.UseVisualStyleBackColor = false;
            btnDeleteButton.Click += btnDeleteButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 178);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(266, 15);
            label4.TabIndex = 6;
            label4.Text = "Existing custom buttons (click to edit or delete it)";
            // 
            // ofdPickButtonIcon
            // 
            ofdPickButtonIcon.AddToRecent = false;
            ofdPickButtonIcon.Filter = "All supported types (*.jpg,*.png,*.ico)|*.jpg;*.png;*.ico";
            ofdPickButtonIcon.OkRequiresInteraction = true;
            ofdPickButtonIcon.RestoreDirectory = true;
            // 
            // TaskbarAdditionalButtonsSettingsPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            Controls.Add(label4);
            Controls.Add(btnDeleteButton);
            Controls.Add(btnUpdateButton);
            Controls.Add(btnAddButton);
            Controls.Add(cmbBuiltInCommands);
            Controls.Add(tbCustomCommand);
            Controls.Add(tbCaption);
            Controls.Add(pbButtonIcon);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flpDefinedButtons);
            ForeColor = System.Drawing.Color.White;
            Name = "TaskbarAdditionalButtonsSettingsPage";
            Size = new System.Drawing.Size(524, 494);
            ((System.ComponentModel.ISupportInitialize)pbButtonIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpDefinedButtons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbButtonIcon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCaption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCustomCommand;
        private System.Windows.Forms.ComboBox cmbBuiltInCommands;
        private System.Windows.Forms.Button btnAddButton;
        private System.Windows.Forms.Button btnUpdateButton;
        private System.Windows.Forms.Button btnDeleteButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog ofdPickButtonIcon;
    }
}
