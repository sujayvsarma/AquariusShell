namespace AquariusShell.Forms
{
    partial class PopupTextInput
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
            lblPrompt = new System.Windows.Forms.Label();
            tbInputValue = new System.Windows.Forms.TextBox();
            btnAccept = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lblPrompt
            // 
            lblPrompt.Location = new System.Drawing.Point(8, 10);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new System.Drawing.Size(338, 42);
            lblPrompt.TabIndex = 0;
            lblPrompt.Text = "PROMPT TEXT";
            lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbInputValue
            // 
            tbInputValue.Location = new System.Drawing.Point(8, 64);
            tbInputValue.Name = "tbInputValue";
            tbInputValue.PlaceholderText = "Enter the value...";
            tbInputValue.Size = new System.Drawing.Size(338, 23);
            tbInputValue.TabIndex = 1;
            tbInputValue.WordWrap = false;
            // 
            // btnAccept
            // 
            btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAccept.Location = new System.Drawing.Point(271, 102);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new System.Drawing.Size(75, 23);
            btnAccept.TabIndex = 2;
            btnAccept.Text = "&OK";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.Location = new System.Drawing.Point(8, 102);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "C&ancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // PopupTextInput
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(358, 140);
            ControlBox = false;
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(tbInputValue);
            Controls.Add(lblPrompt);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PopupTextInput";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Aquarius Shell";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox tbInputValue;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}