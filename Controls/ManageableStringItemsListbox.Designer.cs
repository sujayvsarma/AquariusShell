namespace AquariusShell.Controls
{
    partial class ManageableStringItemsListbox
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
            btnClear = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            lstListBox = new System.Windows.Forms.ListBox();
            tbAddEditItem = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // btnClear
            // 
            btnClear.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClear.Location = new System.Drawing.Point(3, 390);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(87, 23);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDelete.Location = new System.Drawing.Point(382, 390);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(87, 23);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAdd.Location = new System.Drawing.Point(382, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(87, 25);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "&Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lstListBox
            // 
            lstListBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lstListBox.FormattingEnabled = true;
            lstListBox.IntegralHeight = false;
            lstListBox.ItemHeight = 15;
            lstListBox.Location = new System.Drawing.Point(3, 36);
            lstListBox.Name = "lstListBox";
            lstListBox.Size = new System.Drawing.Size(466, 348);
            lstListBox.TabIndex = 3;
            lstListBox.SelectedIndexChanged += lstListBox_SelectedIndexChanged;
            // 
            // tbAddEditItem
            // 
            tbAddEditItem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbAddEditItem.Location = new System.Drawing.Point(3, 5);
            tbAddEditItem.Name = "tbAddEditItem";
            tbAddEditItem.Size = new System.Drawing.Size(373, 23);
            tbAddEditItem.TabIndex = 7;
            // 
            // ManageableStringItemsListbox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            Controls.Add(tbAddEditItem);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(lstListBox);
            ForeColor = System.Drawing.Color.White;
            Name = "ManageableStringItemsListbox";
            Size = new System.Drawing.Size(472, 416);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox lstListBox;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbAddEditItem;
    }
}
