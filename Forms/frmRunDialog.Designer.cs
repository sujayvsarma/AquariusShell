namespace AquariusShell
{
    partial class frmRunDialog
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
            label1 = new Label();
            cbOpenURI = new ComboBox();
            btnOK = new Button();
            btnCancel = new Button();
            btnBrowse = new Button();
            ofdBrowseDialog = new OpenFileDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(8, 9);
            label1.Name = "label1";
            label1.Size = new Size(362, 37);
            label1.TabIndex = 0;
            label1.Text = "Type or select the name of a program, document, file or website address you wish to open:";
            // 
            // cbOpenURI
            // 
            cbOpenURI.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbOpenURI.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbOpenURI.FormattingEnabled = true;
            cbOpenURI.Location = new Point(8, 50);
            cbOpenURI.MaxDropDownItems = 5;
            cbOpenURI.Name = "cbOpenURI";
            cbOpenURI.Size = new Size(355, 23);
            cbOpenURI.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(263, 79);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 36);
            btnOK.TabIndex = 2;
            btnOK.Text = "&OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(157, 79);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 36);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "C&ancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(8, 79);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(100, 36);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "B&rowse...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // ofdBrowseDialog
            // 
            ofdBrowseDialog.Filter = "All Programs and Apps|*.exe;*.ps1;*.cmd;*.bat|Anything|*.*";
            ofdBrowseDialog.RestoreDirectory = true;
            ofdBrowseDialog.ShowReadOnly = true;
            ofdBrowseDialog.SupportMultiDottedExtensions = true;
            ofdBrowseDialog.Title = "Browse...";
            // 
            // frmRunDialog
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(375, 124);
            Controls.Add(btnBrowse);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(cbOpenURI);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRunDialog";
            StartPosition = FormStartPosition.Manual;
            Text = "Run";
            TopMost = true;
            Shown += frmRunDialog_Shown;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox cbOpenURI;
        private Button btnOK;
        private Button btnCancel;
        private Button btnBrowse;
        private OpenFileDialog ofdBrowseDialog;
    }
}