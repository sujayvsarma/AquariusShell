using System.Diagnostics;
using System.Runtime.InteropServices;

using AquariusShell.WindowsApi;

namespace AquariusShell
{
    public partial class frmTaskbar : Form
    {
        public frmTaskbar()
        {
            InitializeComponent();
        }

        private void frmTaskbar_Shown(object sender, EventArgs e)
        {
            tmrClock.Enabled = true;
        }

        private void frmTaskbar_Load(object sender, EventArgs e)
        {
            Rectangle desktop = Screen.PrimaryScreen!.Bounds;           // App startup made sure we have a screen
            this.SetBounds(0, desktop.Height - 41, desktop.Width, 40);

            User32.RECT bounds = new()
            {
                Left = 0,
                Top = 0,
                Right = Screen.PrimaryScreen!.Bounds.Right,
                Bottom = (Screen.PrimaryScreen!.Bounds.Bottom - this.Height)
            };
            User32.SystemParametersInfo((int)User32.WindowStylesInterestedFlagsEnum.SPI_SETWORKAREA, 0, ref bounds, 0);

            btnStartMenu.Location = new(5, 4);
            Runtime.Taskbar.Bounds = this.Bounds;

            InitialiseStartMenu();
        }

        private void frmTaskbar_FormClosing(object sender, FormClosingEventArgs e)
        {
            // restore the working area

            User32.RECT bounds = new()
            {
                Left = 0,
                Top = 0,
                Right = Screen.PrimaryScreen!.Bounds.Right,
                Bottom = Screen.PrimaryScreen!.Bounds.Bottom
            };

            User32.SystemParametersInfo((int)User32.WindowStylesInterestedFlagsEnum.SPI_SETWORKAREA, 0, ref bounds, 0);
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("MMM dd, yyyy HH:mm");

            List<Process> processes = Process.GetProcesses().ToList();
            List<nint> currentProcessMainWindowHandles = processes.Select(p => p.MainWindowHandle).ToList();

            // Windows that were open before but are not in the current process handle list
            List<KeyValuePair<nint, Button>> x = _taskButtons.Except(_taskButtons.Where(i => currentProcessMainWindowHandles.Any(h => h == i.Key))).ToList();

            foreach (KeyValuePair<nint, Button> itm in x)
            {

                taskbuttonsPanel.Controls.Remove(itm.Value);
                _taskButtons.Remove(itm.Key);
            }

            // .OrderByDescending(p => p.StartTime) <-- access denied usually, but should be granted once we are a full shell ??
            foreach (Process process in Process.GetProcesses())
            {
                if ((process.MainWindowHandle != IntPtr.Zero) && (!string.IsNullOrWhiteSpace(process.MainWindowTitle)) && (!_taskButtons.ContainsKey(process.MainWindowHandle)))
                {
                    User32.WINDOWINFO wi = new();
                    wi.SizeOfThisStructure = (uint)Marshal.SizeOf(wi);

                    User32.GetWindowInfo(process.MainWindowHandle, ref wi);

                    if ((wi.StyleExtended & (long)User32.WindowStylesInterestedFlagsEnum.DONTSHOWONTASKBAR) != 0)
                    {
                        continue;
                    }

                    Bitmap? bitmap = Icon.ExtractAssociatedIcon(process.MainModule!.FileName)?.ToBitmap();
                    if (bitmap != null)
                    {
                        bitmap = new(bitmap, 24, 24);

                        Button taskButton = new()
                        {
                            Size = new(240, this.Height),
                            AutoSize = false,
                            Font = new(new FontFamily("Segoe UI"), 8),
                            AutoEllipsis = true,
                            Text = process.MainWindowTitle,
                            TextAlign = ContentAlignment.MiddleLeft,
                            ImageAlign = ContentAlignment.MiddleLeft,
                            TextImageRelation = TextImageRelation.ImageBeforeText,
                            Image = bitmap,

                            Tag = process.Id
                        };

                        taskButton.Click += TaskButton_Click;

                        taskbuttonsPanel.Controls.Add(taskButton);
                        _taskButtons.Add(process.MainWindowHandle, taskButton);
                    }
                }
            }
        }
        private Dictionary<nint, Button> _taskButtons = new();

        private void TaskButton_Click(object? sender, EventArgs e)
        {
            int pid = (int)((Button)sender!).Tag!;
            Process? process = Process.GetProcessById(pid);
            if (process != null)
            {
                long hWnd = process.MainWindowHandle.ToInt64();

                if (User32.IsIconic(hWnd))
                {
                    // if windows is minimised, bring it up
                    User32.ShowWindow(hWnd, (int)User32.ShowWindowModesEnum.RestorePreviousSizeAndShow);
                    User32.SetForegroundWindow(hWnd);
                }
                else
                {
                    // if it is currently in focus, minimise it
                    User32.ShowWindow(hWnd, (int)User32.ShowWindowModesEnum.MinimiseAndSwitchFocus);
                }
            }
        }


        private void btnStartMenu_Click(object sender, EventArgs e)
        {
            if (_startMenu.Visible)
            {
                _startMenu.Hide();
                return;
            }

            _startMenu.Show(this);
        }

        private void InitialiseStartMenu()
        {
            _startMenu = new()
            {
                // height of startmenu is fixed at 384px
                //Location = new Point(this.Location.X, (this.Location.Y - 384 - 1)),

                LoadPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms),
                IconSize = IconSizeModes.Icons24,
                IsPrimaryLauncher = true
            };

            _startMenu.ItemClicked += _startMenu_ItemClicked;
        }

        private void _startMenu_ItemClicked(Objects.CascadeMenuItem menuItem)
        {
            bool succeededLaunch = WindowsApi.Shell32.ExecuteUri(menuItem.FullPath);
            if (!succeededLaunch)
            {
                MessageBox.Show($"Error launching: \"{menuItem.FullPath}\".\r\n\r\nWe could not figure out how to execute it!", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private frmLauncher _startMenu = default!;
    }
}
