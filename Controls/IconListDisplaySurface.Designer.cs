namespace AquariusShell.Controls
{
    partial class IconListDisplaySurface
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
            flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            viewImages = new System.Windows.Forms.ImageList(components);
            fsWatcher = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)fsWatcher).BeginInit();
            SuspendLayout();
            // 
            // flowLayout
            // 
            flowLayout.AutoSize = true;
            flowLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flowLayout.BackColor = System.Drawing.Color.Transparent;
            flowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayout.Location = new System.Drawing.Point(0, 0);
            flowLayout.Name = "flowLayout";
            flowLayout.Size = new System.Drawing.Size(367, 199);
            flowLayout.AutoScroll = true;
            flowLayout.TabIndex = 0;
            // 
            // viewImages
            // 
            viewImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            viewImages.ImageSize = new System.Drawing.Size(16, 16);
            viewImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // fsWatcher
            // 
            fsWatcher.EnableRaisingEvents = true;
            fsWatcher.NotifyFilter = System.IO.NotifyFilters.FileName;
            fsWatcher.SynchronizingObject = this;
            fsWatcher.Changed += OnFilesystemItemCreatedDeletedOrChanged;
            fsWatcher.Created += OnFilesystemItemCreatedDeletedOrChanged;
            fsWatcher.Deleted += OnFilesystemItemCreatedDeletedOrChanged;
            fsWatcher.Renamed += OnFilesystemItemRenamed;
            // 
            // IconListDisplaySurface
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(flowLayout);
            Name = "IconListDisplaySurface";
            Size = new System.Drawing.Size(367, 199);
            ((System.ComponentModel.ISupportInitialize)fsWatcher).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayout;
        private System.Windows.Forms.ImageList viewImages;
        private System.IO.FileSystemWatcher fsWatcher;
    }
}
