namespace AquariusShell.ShellApps
{
    partial class RunDialog
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
            pbRunIcon = new System.Windows.Forms.PictureBox();
            cbURI = new System.Windows.Forms.ComboBox();
            btnCancel = new System.Windows.Forms.Button();
            btnExecute = new System.Windows.Forms.Button();
            btnBrowse = new System.Windows.Forms.Button();
            ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pbRunIcon).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(44, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(381, 23);
            label1.TabIndex = 0;
            label1.Text = "Select a file to open or a program to run or a website address to go to:";
            // 
            // pbRunIcon
            // 
            pbRunIcon.Location = new System.Drawing.Point(6, 10);
            pbRunIcon.Name = "pbRunIcon";
            pbRunIcon.Size = new System.Drawing.Size(32, 32);
            pbRunIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbRunIcon.TabIndex = 1;
            pbRunIcon.TabStop = false;
            // 
            // cbURI
            // 
            cbURI.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            cbURI.FormattingEnabled = true;
            cbURI.Location = new System.Drawing.Point(7, 47);
            cbURI.Name = "cbURI";
            cbURI.Size = new System.Drawing.Size(411, 23);
            cbURI.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(7, 80);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "C&ancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnExecute
            // 
            btnExecute.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnExecute.Location = new System.Drawing.Point(343, 80);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new System.Drawing.Size(75, 23);
            btnExecute.TabIndex = 4;
            btnExecute.Text = "E&xecute";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new System.Drawing.Point(262, 80);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new System.Drawing.Size(75, 23);
            btnBrowse.TabIndex = 5;
            btnBrowse.Text = "B&rowse...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // ofdBrowse
            // 
            ofdBrowse.AddToRecent = false;
            ofdBrowse.Filter = "Programs (*.exe)|*.exe|Batch scripts (*.cmd, *.bat, *.ps1)|*.cmd,*.bat,*.ps1|Text and document files (*.txt, *.doc, *.xls, *.ppt)|*.txt,*.doc,*.docx,*.xls,*.xlsx,*.ppt,*.pptx|All files (*.*)|*.*";
            ofdBrowse.OkRequiresInteraction = true;
            ofdBrowse.ShowReadOnly = true;
            ofdBrowse.SupportMultiDottedExtensions = true;
            ofdBrowse.Title = "Select a program or document:";
            // 
            // RunDialog
            // 
            AcceptButton = btnExecute;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(430, 110);
            Controls.Add(btnBrowse);
            Controls.Add(btnExecute);
            Controls.Add(btnCancel);
            Controls.Add(cbURI);
            Controls.Add(pbRunIcon);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RunDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "Open a file or launch a program...";
            FormClosing += RunDialog_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pbRunIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbRunIcon;
        private System.Windows.Forms.ComboBox cbURI;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog ofdBrowse;
    }
}