namespace AquariusShell.Controls
{
    partial class Accordion
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
            itemsContainerPanel = new System.Windows.Forms.FlowLayoutPanel();
            SuspendLayout();
            // 
            // itemsContainerPanel
            // 
            itemsContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            itemsContainerPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            itemsContainerPanel.Location = new System.Drawing.Point(0, 0);
            itemsContainerPanel.Name = "itemsContainerPanel";
            itemsContainerPanel.Size = new System.Drawing.Size(317, 165);
            itemsContainerPanel.TabIndex = 0;
            // 
            // Accordion
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(itemsContainerPanel);
            Name = "Accordion";
            Size = new System.Drawing.Size(317, 165);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel itemsContainerPanel;
    }
}
