namespace AquariusShell.Forms
{
    partial class FileOperationWithProgress
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
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            lblSource = new System.Windows.Forms.Label();
            lblDestination = new System.Windows.Forms.Label();
            lblCurrentFileSize = new System.Windows.Forms.Label();
            lblCurrentFileName = new System.Windows.Forms.Label();
            prgOperationProgress = new System.Windows.Forms.ProgressBar();
            prgOperationProgressLabel = new System.Windows.Forms.Label();
            btnCancelOperation = new System.Windows.Forms.Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(lblSource, 1, 0);
            tableLayoutPanel1.Controls.Add(lblDestination, 1, 1);
            tableLayoutPanel1.Controls.Add(lblCurrentFileSize, 1, 3);
            tableLayoutPanel1.Controls.Add(lblCurrentFileName, 1, 2);
            tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            tableLayoutPanel1.Size = new System.Drawing.Size(564, 110);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label1.Location = new System.Drawing.Point(3, 1);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(101, 24);
            label1.TabIndex = 0;
            label1.Text = "From";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label2.Location = new System.Drawing.Point(3, 27);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(101, 24);
            label2.TabIndex = 1;
            label2.Text = "To";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label3.Location = new System.Drawing.Point(3, 53);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(101, 24);
            label3.TabIndex = 1;
            label3.Text = "Current";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label4.Location = new System.Drawing.Point(3, 82);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(101, 24);
            label4.TabIndex = 1;
            label4.Text = "Size";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSource
            // 
            lblSource.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblSource.Location = new System.Drawing.Point(115, 1);
            lblSource.Name = "lblSource";
            lblSource.Size = new System.Drawing.Size(446, 24);
            lblSource.TabIndex = 0;
            lblSource.Text = "C:\\";
            lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDestination
            // 
            lblDestination.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblDestination.Location = new System.Drawing.Point(115, 27);
            lblDestination.Name = "lblDestination";
            lblDestination.Size = new System.Drawing.Size(446, 24);
            lblDestination.TabIndex = 0;
            lblDestination.Text = "D:\\";
            lblDestination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrentFileSize
            // 
            lblCurrentFileSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblCurrentFileSize.Location = new System.Drawing.Point(115, 82);
            lblCurrentFileSize.Name = "lblCurrentFileSize";
            lblCurrentFileSize.Size = new System.Drawing.Size(444, 24);
            lblCurrentFileSize.TabIndex = 0;
            lblCurrentFileSize.Text = "1 KB";
            lblCurrentFileSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrentFileName
            // 
            lblCurrentFileName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblCurrentFileName.Location = new System.Drawing.Point(115, 53);
            lblCurrentFileName.Name = "lblCurrentFileName";
            lblCurrentFileName.Size = new System.Drawing.Size(444, 24);
            lblCurrentFileName.TabIndex = 0;
            lblCurrentFileName.Text = "Untitled1.txt";
            lblCurrentFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prgOperationProgress
            // 
            prgOperationProgress.Location = new System.Drawing.Point(8, 123);
            prgOperationProgress.Name = "prgOperationProgress";
            prgOperationProgress.Size = new System.Drawing.Size(563, 23);
            prgOperationProgress.Step = 1;
            prgOperationProgress.TabIndex = 1;
            // 
            // prgOperationProgressLabel
            // 
            prgOperationProgressLabel.Location = new System.Drawing.Point(8, 152);
            prgOperationProgressLabel.Name = "prgOperationProgressLabel";
            prgOperationProgressLabel.Size = new System.Drawing.Size(564, 21);
            prgOperationProgressLabel.TabIndex = 2;
            prgOperationProgressLabel.Text = "1 / 583";
            prgOperationProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancelOperation
            // 
            btnCancelOperation.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCancelOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancelOperation.Location = new System.Drawing.Point(487, 179);
            btnCancelOperation.Name = "btnCancelOperation";
            btnCancelOperation.Size = new System.Drawing.Size(84, 29);
            btnCancelOperation.TabIndex = 3;
            btnCancelOperation.Text = "C&ancel";
            btnCancelOperation.UseVisualStyleBackColor = true;
            btnCancelOperation.Click += btnCancelOperation_Click;
            // 
            // FileOperationWithProgress
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            ClientSize = new System.Drawing.Size(578, 217);
            ControlBox = false;
            Controls.Add(btnCancelOperation);
            Controls.Add(prgOperationProgressLabel);
            Controls.Add(prgOperationProgress);
            Controls.Add(tableLayoutPanel1);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FileOperationWithProgress";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "File operation progress";
            TopMost = true;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label lblCurrentFileSize;
        private System.Windows.Forms.Label lblCurrentFileName;
        private System.Windows.Forms.ProgressBar prgOperationProgress;
        private System.Windows.Forms.Label prgOperationProgressLabel;
        private System.Windows.Forms.Button btnCancelOperation;
    }
}