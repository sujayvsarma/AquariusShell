namespace AquariusShell.Controls
{
    partial class AccordionItem
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccordionItem));
            il = new System.Windows.Forms.ImageList(components);
            headerButton = new System.Windows.Forms.Button();
            surface = new IconListDisplaySurface();
            SuspendLayout();
            // 
            // il
            // 
            il.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            il.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("il.ImageStream");
            il.TransparentColor = System.Drawing.Color.Transparent;
            il.Images.SetKeyName(0, "DN");
            il.Images.SetKeyName(1, "UP");
            // 
            // headerButton
            // 
            headerButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            headerButton.ImageKey = "DN";
            headerButton.ImageList = il;
            headerButton.Location = new System.Drawing.Point(3, 3);
            headerButton.Name = "headerButton";
            headerButton.Size = new System.Drawing.Size(464, 41);
            headerButton.TabIndex = 0;
            headerButton.Text = "My Accordion Item";
            headerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            headerButton.UseVisualStyleBackColor = true;
            headerButton.Click += headerButton_Click;
            // 
            // surface
            // 
            surface.AutoScroll = true;
            surface.DirectoryToLoad = "C:\\Users\\SujayVSarma\\Desktop";
            surface.IconSize = Modules.IconSizesEnum.x32;
            surface.IsHiddenFilesVisible = false;
            surface.IsSystemFilesVisible = false;
            surface.Location = new System.Drawing.Point(3, 50);
            surface.Name = "surface";
            surface.Size = new System.Drawing.Size(464, 144);
            surface.TabIndex = 1;
            // 
            // AccordionItem
            // 
            Controls.Add(surface);
            Controls.Add(headerButton);
            Name = "AccordionItem";
            Size = new System.Drawing.Size(470, 197);
            Resize += AccordionItem_Resize;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button chevBtn;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.Button headerButton;
        private IconListDisplaySurface surface;
    }
}
