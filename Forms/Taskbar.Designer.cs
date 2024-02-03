using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using AquariusShell.Modules;
using AquariusShell.Properties;
using AquariusShell.Runtime;

namespace AquariusShell.Forms
{
    partial class Taskbar
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
            SuspendLayout();

            int buttonSizes = Icons.ToPixels(ShellEnvironment.ConfiguredSizeOfIcons.ToNextLargerSize());

            taskbarItemsFlowLayout = new()
            {
                FlowDirection = FlowDirection.LeftToRight,
                Location = new(1, 1),
                Size = new(((buttonSizes + 6) * 2), this.ClientSize.Height)
            };
            taskbarItemsFlowLayout.SuspendLayout();

            taskListButton = new()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left,
                BackColor = Color.White,
                Location = new Point(5, 1),
                Name = "taskListButton",
                Size = new Size(buttonSizes, buttonSizes),
                UseVisualStyleBackColor = false,
                Image = Icon.ExtractIcon(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "explorer.exe"), 16)
                            .Resize(ShellEnvironment.ConfiguredSizeOfIcons).ToBitmap(),
                ImageAlign = ContentAlignment.MiddleCenter,
                TextImageRelation = TextImageRelation.Overlay
            };
            taskListButton.Click += TaskListButtonClicked;

            startButton = new()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left,
                BackColor = Color.White,
                Name = "startButton",
                Location = new(taskListButton.Right + 2, 1),
                Size = new Size(buttonSizes, buttonSizes),
                UseVisualStyleBackColor = false,
                Image = new Bitmap(Resources.windows_logo, ShellEnvironment.ConfiguredSizeOfIconsInPixels, ShellEnvironment.ConfiguredSizeOfIconsInPixels),
                ImageAlign = ContentAlignment.MiddleCenter,
                TextImageRelation = TextImageRelation.Overlay
            };
            startButton.Click += OnStartButtonClicked;

            sysTrayPanel = new()
            {
                Dock = DockStyle.Right,
                Name = "sysTrayPanel",
                Location = new(this.Width - 150, 1),
                Size = new(150, buttonSizes),
                BorderStyle = BorderStyle.Fixed3D
            };
            sysTrayPanel.SuspendLayout();

            clockLabel = new()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right,
                Name = "clockLabel",
                Size = new(148, buttonSizes),
                Text = "Jan 01, 2024, 23:59:59",
                TextAlign = ContentAlignment.MiddleRight
            };
            sysTrayPanel.Controls.Add(clockLabel);
            
            taskbarItemsFlowLayout.Controls.Add(startButton);
            taskbarItemsFlowLayout.Controls.Add(taskListButton);

            clock = new()
            {
                Interval = (int)TimeSpan.FromSeconds(1).TotalMilliseconds
            };
            clock.Tick += OnClockTimerTickEvent;

            AllowDrop = true;
            AutoValidate = AutoValidate.Disable;
            BackColor = SystemColors.ButtonFace;
            ForeColor = SystemColors.ControlText;
            ClientSize = new(930, 42);
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Taskbar";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            ResizeEnd += OnSizeOrLocationChanged;
            Move += OnSizeOrLocationChanged;
            DragEnter += Taskbar_DragEnter;
            DragDrop += Taskbar_DragDrop;

            Controls.Add(taskbarItemsFlowLayout);
            Controls.Add(sysTrayPanel);

            sysTrayPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button startButton, taskListButton;
        private FlowLayoutPanel taskbarItemsFlowLayout;
        private Panel sysTrayPanel;
        private Label clockLabel;
        private System.Windows.Forms.Timer clock;
    }
}