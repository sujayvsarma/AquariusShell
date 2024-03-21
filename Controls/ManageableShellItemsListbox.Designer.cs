namespace AquariusShell.Controls
{
    partial class ManageableShellItemsListbox
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
            lstListBox = new System.Windows.Forms.ListBox();
            btnDelete = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();
            btnBrowseToAdd = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lstListBox
            // 
            lstListBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lstListBox.FormattingEnabled = true;
            lstListBox.IntegralHeight = false;
            lstListBox.ItemHeight = 15;
            lstListBox.Location = new System.Drawing.Point(3, 3);
            lstListBox.Name = "lstListBox";
            lstListBox.Size = new System.Drawing.Size(453, 352);
            lstListBox.TabIndex = 0;
            lstListBox.KeyUp += lstListBox_KeyUp;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDelete.Location = new System.Drawing.Point(276, 361);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(87, 23);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClear.Location = new System.Drawing.Point(3, 361);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(87, 23);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnBrowseToAdd
            // 
            btnBrowseToAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnBrowseToAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBrowseToAdd.Location = new System.Drawing.Point(369, 361);
            btnBrowseToAdd.Name = "btnBrowseToAdd";
            btnBrowseToAdd.Size = new System.Drawing.Size(87, 23);
            btnBrowseToAdd.TabIndex = 2;
            btnBrowseToAdd.Text = "&Add...";
            btnBrowseToAdd.UseVisualStyleBackColor = true;
            btnBrowseToAdd.Click += btnBrowse_Click;
            // 
            // ManageableShellItemsListbox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnBrowseToAdd);
            Controls.Add(lstListBox);
            ForeColor = System.Drawing.Color.White;
            Name = "ManageableShellItemsListbox";
            Size = new System.Drawing.Size(459, 387);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox lstListBox;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBrowseToAdd;
    }
}
