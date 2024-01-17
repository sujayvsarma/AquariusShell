namespace AquariusShell.Forms
{
    partial class Form1
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
            accordion1 = new Controls.Accordion();
            SuspendLayout();
            // 
            // accordion1
            // 
            accordion1.Dock = System.Windows.Forms.DockStyle.Fill;
            accordion1.Location = new System.Drawing.Point(0, 0);
            accordion1.Name = "accordion1";
            accordion1.Size = new System.Drawing.Size(800, 450);
            accordion1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(accordion1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Shown += Form1_Shown;
            Resize += Form1_Resize;
            ResumeLayout(false);
        }

        private Controls.Accordion accordion1;

        #endregion

        //private Controls.AccordionItem accordionItem1;
    }
}