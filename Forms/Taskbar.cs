using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using AquariusShell.Modules;
using AquariusShell.Runtime;

namespace AquariusShell.Forms
{
    /// <summary>
    /// The horizontal taskbar at the bottom of the screen. Ideally this should be moveable to anywhere else 
    /// just like it was with Windows 95.
    /// </summary>
    public partial class Taskbar : Form
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public Taskbar()
        {
            InitializeComponent();

            clock.Enabled = true;
            clock.Start();
        }

        /// <summary>
        /// Dragging something onto the taskbar. We allow programs/files to be opened or launched this way!
        /// </summary>
        private void Taskbar_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.Data != null) && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string? path = ((string[]?)e.Data.GetData(DataFormats.FileDrop))?[0];
                if (!string.IsNullOrWhiteSpace(path))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        /// <summary>
        /// Dropping something onto the taskbar. Open/launch the program or file if we can
        /// </summary>
        private void Taskbar_DragDrop(object sender, DragEventArgs e)
        {
            if ((e.Data != null) && (e.Effect == DragDropEffects.Copy))
            {
                string? path = ((string[]?)e.Data.GetData(DataFormats.FileDrop))?[0];
                if (!string.IsNullOrWhiteSpace(path))
                {
                    if (File.Exists(path))
                    {
                        Shell32.ExecuteOrLaunchTarget(path);
                    }
                }
            }
        }

        /// <summary>
        /// We were resized or moved away elsewhere. Update the metadata about where we are (and how big)
        /// </summary>
        private void OnSizeOrLocationChanged(object sender, EventArgs e)
        {
            taskbarItemsFlowLayout.Left = ((this.Width / 2) - (taskbarItemsFlowLayout.Width / 2));
            ShellEnvironment.TaskbarBounds = this.Bounds;
        }

        /// <summary>
        /// A timer tick. Do the clock thing!
        /// </summary>
        private void OnClockTimerTickEvent(object? sender, EventArgs e)
        {
            clockLabel.Text = DateTime.Now.ToString("MMM dd, yyyy HH:mm:ss");
        }

        /// <summary>
        /// The "task list" button was clicked. Show the list of running tasks. (ALT+TAB)
        /// </summary>
        private void TaskListButtonClicked(object? sender, EventArgs e)
        {
            taskPane.Clear();

            foreach (Process process in Process.GetProcesses())
            {
                if ((process.MainWindowHandle != nint.Zero)
                     && (!string.IsNullOrWhiteSpace(process.MainWindowTitle))
                            && Modules.Windows.IsWindowShowableOnOurTaskbar(process.MainWindowHandle)
                        )
                {
                    IntPtr hWnd = process.MainWindowHandle;

                    string windowTitle = process.MainWindowTitle;
                    if (!string.IsNullOrWhiteSpace(windowTitle))
                    {
                        Image icon = new Bitmap(1, 1);                      // workaround! Without this, we get the same icon as the last one!
                        icon = Icons.EnsureGetProcessIcon(process);
                        taskPane.Add(icon, windowTitle, hWnd, process.Id);
                    }
                }
            }

            taskPane.StartPosition = FormStartPosition.CenterScreen;
            taskPane.ShowDialog(this);
        }

        /// <summary>
        /// The "start" button was clicked. Show the program launcher!
        /// </summary>
        private void OnStartButtonClicked(object? sender, System.EventArgs e)
        {
            _programsLauncher.ShowDialog(this);
        }

        private TaskListPane taskPane = new();
        private CanvasProgramLauncher _programsLauncher = new();

        /// <summary>
        /// Calcuate the height of the taskbar for a given icon height
        /// </summary>
        public static int CalcHeight(IconSizesEnum iconSize) => Icons.ToPixels(iconSize.ToNextLargerSize()) + 6;
    }
}
