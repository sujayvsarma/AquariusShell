using Microsoft.VisualBasic.ApplicationServices;

namespace AquariusShell.Forms
{
    partial class CanvasProgramLauncher
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CanvasProgramLauncher));
            accordionPanel = new System.Windows.Forms.FlowLayoutPanel();
            lvShellApps = new System.Windows.Forms.ListView();
            imgListWindowsAppIcons = new System.Windows.Forms.ImageList(components);
            lvWindowsApps = new System.Windows.Forms.ListView();
            tbWinProgsSearchBox = new System.Windows.Forms.TextBox();
            imgListShellAppIcons = new System.Windows.Forms.ImageList(components);
            chevronImages = new System.Windows.Forms.ImageList(components);
            accordionPanel.SuspendLayout();
            SuspendLayout();
            // 
            // accordionPanel
            // 
            accordionPanel.BackColor = System.Drawing.Color.SteelBlue;
            accordionPanel.Controls.Add(lvShellApps);
            accordionPanel.Controls.Add(lvWindowsApps);
            accordionPanel.Controls.Add(tbWinProgsSearchBox);
            accordionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            accordionPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            accordionPanel.Location = new System.Drawing.Point(0, 0);
            accordionPanel.Name = "accordionPanel";
            accordionPanel.Size = new System.Drawing.Size(794, 594);
            accordionPanel.TabIndex = 1;
            // 
            // lvShellApps
            // 
            lvShellApps.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            lvShellApps.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lvShellApps.BackColor = System.Drawing.Color.SteelBlue;
            lvShellApps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lvShellApps.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lvShellApps.LargeImageList = imgListShellAppIcons;
            lvShellApps.Location = new System.Drawing.Point(3, 12);
            lvShellApps.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            lvShellApps.MultiSelect = false;
            lvShellApps.Name = "lvShellApps";
            lvShellApps.ShowGroups = false;
            lvShellApps.ShowItemToolTips = true;
            lvShellApps.Size = new System.Drawing.Size(791, 116);
            lvShellApps.SmallImageList = imgListShellAppIcons;
            lvShellApps.Sorting = System.Windows.Forms.SortOrder.Ascending;
            lvShellApps.TabIndex = 8;
            lvShellApps.UseCompatibleStateImageBehavior = false;
            lvShellApps.ItemActivate += lvShellApps_ItemActivate;
            // 
            // lvWindowsAppsListIcons32
            // 
            imgListWindowsAppIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imgListWindowsAppIcons.ImageSize = new System.Drawing.Size(24, 24);
            imgListWindowsAppIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lvWindowsApps
            // 
            lvWindowsApps.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            lvWindowsApps.BackColor = System.Drawing.Color.SteelBlue;
            lvWindowsApps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lvWindowsApps.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lvWindowsApps.LargeImageList = imgListWindowsAppIcons;
            lvWindowsApps.Location = new System.Drawing.Point(3, 134);
            lvWindowsApps.MultiSelect = false;
            lvWindowsApps.Name = "lvWindowsApps";
            lvWindowsApps.ShowGroups = false;
            lvWindowsApps.ShowItemToolTips = true;
            lvWindowsApps.Size = new System.Drawing.Size(791, 418);
            lvWindowsApps.SmallImageList = imgListWindowsAppIcons;
            lvWindowsApps.Sorting = System.Windows.Forms.SortOrder.Ascending;
            lvWindowsApps.TabIndex = 7;
            lvWindowsApps.UseCompatibleStateImageBehavior = false;
            lvWindowsApps.ItemActivate += lvWindowsApps_ItemActivate;
            // 
            // tbWinProgsSearchBox
            // 
            tbWinProgsSearchBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbWinProgsSearchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            tbWinProgsSearchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            tbWinProgsSearchBox.Location = new System.Drawing.Point(6, 561);
            tbWinProgsSearchBox.Margin = new System.Windows.Forms.Padding(6);
            tbWinProgsSearchBox.MaxLength = 255;
            tbWinProgsSearchBox.Name = "tbWinProgsSearchBox";
            tbWinProgsSearchBox.PlaceholderText = "Search...";
            tbWinProgsSearchBox.Size = new System.Drawing.Size(785, 23);
            tbWinProgsSearchBox.TabIndex = 9;
            tbWinProgsSearchBox.WordWrap = false;
            tbWinProgsSearchBox.TextChanged += tbWinProgsSearchBox_TextChanged;
            // 
            // lvShellAppsListIcons32
            // 
            imgListShellAppIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imgListShellAppIcons.ImageSize = new System.Drawing.Size(24, 24);
            imgListShellAppIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // chevronImages
            // 
            chevronImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            chevronImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("chevronImages.ImageStream");
            chevronImages.TransparentColor = System.Drawing.Color.Transparent;
            chevronImages.Images.SetKeyName(0, "DN");
            chevronImages.Images.SetKeyName(1, "UP");
            // 
            // CanvasProgramLauncher
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            ClientSize = new System.Drawing.Size(794, 594);
            ControlBox = false;
            Controls.Add(accordionPanel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "CanvasProgramLauncher";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Apps and Programs";
            accordionPanel.ResumeLayout(false);
            accordionPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel accordionPanel;
        private System.Windows.Forms.ImageList chevronImages;
        private System.Windows.Forms.ImageList imgListWindowsAppIcons;
        private System.Windows.Forms.ImageList imgListShellAppIcons;
        private System.Windows.Forms.ListView lvWindowsApps;
        private System.Windows.Forms.ListView lvShellApps;
        private System.Windows.Forms.TextBox tbWinProgsSearchBox;
    }
}