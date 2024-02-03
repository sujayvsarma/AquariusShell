using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using AquariusShell.Controls;
using AquariusShell.Modules;
using AquariusShell.Runtime;

namespace AquariusShell.Forms
{
    /// <summary>
    /// This is a variation of the programs-list launcher that appears in HTML-Canvas style 
    /// on the horizontal-edge of the screen. 
    /// 
    /// Right now, we support only aligning it to the RIGHT hand edge. If in future we add RTL support 
    /// through this app, then we should allow this to dock on the LEFT edge of the screen as well. 
    /// </summary>
    public partial class CanvasProgramLauncher : Form
    {
        /// <summary>
        /// Where this launcher should be positioned
        /// </summary>
        public CanvasProgramLauncherPositionsEnum Position
        {
            get;
            set;

        } = CanvasProgramLauncherPositionsEnum.Right;


        /// <summary>
        /// Initialise
        /// </summary>
        public CanvasProgramLauncher()
        {
            InitializeComponent();

            tbWinProgsSearchBox.AutoCompleteCustomSource = new();
            tbWinProgsSearchBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbWinProgsSearchBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            prgGlobalFilesWatcher.EnableRaisingEvents = false;
            prgUserFilesWatcher.EnableRaisingEvents = false;

            int itemKey = 0;

            // Add Shell Apps
            foreach (AppIconOrShortcut shellApp in ShellEnvironment.ShellApps)
            {
                string imageKey = itemKey.ToString();
                lvAppsListIcons32.Images.Add(imageKey, shellApp.Icon!);
                ListViewItem item = new()
                {
                    Text = shellApp.AppName,
                    ImageKey = imageKey,
                    Tag = shellApp.Command
                };
                lvShellApps.Items.Add(item);
                itemKey++;
            }

            // Add Windows Apps
            // we must re-enumerate to account for any programs that were installed or uninstalled since the last time
            List<string> items = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms), "*.*", SearchOption.AllDirectories)
                                       .Union(Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Programs), "*.*", SearchOption.AllDirectories))
                                            .OrderBy(itm => Path.GetFileNameWithoutExtension(itm))
                                                .ThenBy(itm => Path.GetDirectoryName(itm))
                                                    .ToList();

            prgGlobalFilesWatcher.Path = Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms);
            prgUserFilesWatcher.Path = Environment.GetFolderPath(Environment.SpecialFolder.Programs);

            foreach (string launchableItem in items)
            {
                if (programShortcutFileExtensions.Contains(Path.GetExtension(launchableItem)))
                {
                    string imageKey = itemKey.ToString();
                    lvAppsListIcons32.Images.Add(imageKey, (Icons.ExtractAssociatedIcon(launchableItem, ShellEnvironment.ConfiguredSizeOfIcons) ?? SystemIcons.Application).ToBitmap());
                    ListViewItem item = new()
                    {
                        Text = Path.GetFileNameWithoutExtension(launchableItem),
                        ImageKey = imageKey,
                        Tag = launchableItem
                    };
                    _allItems.Add(item);
                    itemKey++;
                }
            }

            // cause the text-changed event to fire
            tbWinProgsSearchBox.Text = string.Empty;
            tbWinProgsSearchBox_TextChanged(tbWinProgsSearchBox, new EventArgs());

            prgGlobalFilesWatcher.EnableRaisingEvents = true;
            prgUserFilesWatcher.EnableRaisingEvents = true;
        }

        #region Event Subscriptions

        /// <summary>
        /// Load, we only set the sizes and positions on screen. All essential "load" activity happens in the constructor
        /// </summary>
        private void CanvasProgramLauncher_Load(object sender, EventArgs e)
        {
            if (Position == CanvasProgramLauncherPositionsEnum.Right)
            {
                this.SetBounds(
                        ShellEnvironment.WorkareaBounds.Right - this.Width - 2,
                        ShellEnvironment.WorkareaBounds.Top - 1,
                        this.Width,
                        ShellEnvironment.WorkareaBounds.Height - ShellEnvironment.TaskbarBounds.Height - 2
                    );
            }
            else if (Position == CanvasProgramLauncherPositionsEnum.Left)
            {
                this.SetBounds(
                        ShellEnvironment.WorkareaBounds.Left + 1,
                        ShellEnvironment.WorkareaBounds.Top - 1,
                        this.Width,
                        ShellEnvironment.WorkareaBounds.Height - ShellEnvironment.TaskbarBounds.Height - 2
                    );
            }

            panelAquariusShellApps.Width = this.Width - 6;
            btnAquariusShellAppsAccordionHeader.Width = panelAquariusShellApps.Width - 6;
            btnCloseLauncher.Left = btnAquariusShellAppsAccordionHeader.Width - btnCloseLauncher.Width;
            lvShellApps.Width = btnAquariusShellAppsAccordionHeader.Width - 6;

            lvWindowsApps.SetBounds(
                    lvWindowsApps.Left, lvWindowsApps.Top,
                    accordionPanel.Width - 6,
                    accordionPanel.Height - panelAquariusShellApps.Height - tbWinProgsSearchBox.Height - 22
                );

            // Save the boundaries of everything
            boundaries = new()
            {
                { panelAquariusShellApps.Name, panelAquariusShellApps.Bounds },
                { lvShellApps.Name, lvShellApps.Bounds },
                { lvWindowsApps.Name, lvWindowsApps.Bounds }
            };
        }

        /// <summary>
        /// Double-click on ShellApps icon
        /// </summary>
        private void lvShellApps_ItemActivate(object sender, EventArgs e)
        {
            this.Hide();

            // we are set to SINGLE select mode
            string shellAppCommand = lvShellApps.SelectedItems[0].Tag!.ToString()!;
            IShellAppModule? app = ShellEnvironment.ShellApps.GetInstanceOf(shellAppCommand);
            if (app != null)
            {
                app.Execute(shellAppCommand);
            }
        }

        /// <summary>
        /// Double-click on WindowsApps icon
        /// </summary>
        private void lvWindowsApps_ItemActivate(object sender, EventArgs e)
        {
            this.Hide();

            // we are set to SINGLE select mode
            Shell32.ExecuteProgram(lvWindowsApps.SelectedItems[0].Tag!.ToString()!);
        }

        /// <summary>
        /// On ESC key, close launcher
        /// </summary>
        private void btnCloseLauncher_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Handle ESC keypress to dismiss the window
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape or Keys.LWin or Keys.RWin:
                    this.Hide();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// User clicked on the "Aquarius Apps" header (accordion). So we do the expand/collapse toggle, 
        /// moving the Windows Apps panel up or down as well
        /// </summary>
        private void btnAquariusShellAppsAccordionHeader_Click(object sender, EventArgs e)
        {
            if (btnAquariusShellAppsAccordionHeader.ImageKey == "DN")
            {
                // COLLAPSE
                btnAquariusShellAppsAccordionHeader.ImageKey = "UP";

                int heightDecrease = panelAquariusShellApps.Size.Height - lvShellApps.Size.Height;

                panelAquariusShellApps.Size = new(panelAquariusShellApps.Size.Width, heightDecrease);
                lvShellApps.Size = new(lvShellApps.Size.Width, 0);
                lvWindowsApps.Size = new(lvWindowsApps.Width, accordionPanel.Height - panelAquariusShellApps.Height - tbWinProgsSearchBox.Height - 27);
            }
            else
            {
                btnAquariusShellAppsAccordionHeader.ImageKey = "DN";

                Rectangle rect = boundaries[lvShellApps.Name];
                lvShellApps.Size = new(rect.Width, rect.Height);

                rect = boundaries[panelAquariusShellApps.Name];
                panelAquariusShellApps.Size = new(rect.Width, rect.Height);

                rect = boundaries[lvWindowsApps.Name];
                lvWindowsApps.Size = new(rect.Width, rect.Height);
            }
        }

        /// <summary>
        /// Handles searching for (Windows-only) apps from the textbox on the panel
        /// </summary>
        private void tbWinProgsSearchBox_TextChanged(object sender, EventArgs e)
        {
            string search = tbWinProgsSearchBox.Text;
            bool isEmpty = string.IsNullOrWhiteSpace(search);

            lvWindowsApps.BeginUpdate();
            lvWindowsApps.Items.Clear();
            if (isEmpty)
            {
                foreach (ListViewItem item in _allItems)
                {
                    lvWindowsApps.Items.Add(item);
                }
            }
            else
            {
                dynamic? wsShell = null;
                try
                {
                    Type? shType = Type.GetTypeFromProgID("WScript.Shell");
                    if (shType != null)
                    {
                        wsShell = Activator.CreateInstance(shType);
                    }
                }
                catch { }

                foreach (ListViewItem item in _allItems)
                {
                    string targetPath = item.Tag!.ToString()!;
                    string resolvedShortcutPath = string.Empty;

                    if (targetPath.EndsWith(".lnk", StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (wsShell != null)
                        {
                            dynamic? wsShortcut;
                            try
                            {
                                wsShortcut = wsShell.CreateShortcut(targetPath);
                                resolvedShortcutPath = wsShortcut.TargetPath;

                                wsShortcut = null;
                            }
                            finally
                            {
                                wsShortcut = null;
                            }
                        }
                    }

                    if (item.Text.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                        || targetPath.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                        || ((resolvedShortcutPath != string.Empty) && resolvedShortcutPath.Contains(search, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        lvWindowsApps.Items.Add(item);
                    }
                }

                wsShell = null;
            }
            lvWindowsApps.EndUpdate();
            Application.DoEvents(); // give ourselves a chance to repaint
        }

        /// <summary>
        /// New shortcut created
        /// </summary>
        private void prgFilesWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (programShortcutFileExtensions.Contains(Path.GetExtension(e.FullPath)))
            {
                if (programShortcutFileExtensions.Contains(Path.GetExtension(e.FullPath)))
                {
                    string imageKey = lvAppsListIcons32.Images.Count.ToString();
                    lvAppsListIcons32.Images.Add(imageKey, (Icons.ExtractAssociatedIcon(e.FullPath, ShellEnvironment.ConfiguredSizeOfIcons) ?? SystemIcons.Application).ToBitmap());
                    ListViewItem item = new()
                    {
                        Text = Path.GetFileNameWithoutExtension(e.FullPath),
                        ImageKey = imageKey,
                        Tag = e.FullPath
                    };
                    lvWindowsApps.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Shortcut deleted
        /// </summary>
        private void prgFilesWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            foreach (ListViewItem item in lvWindowsApps.Items)
            {
                if (item.Tag!.ToString()!.Equals(e.FullPath, StringComparison.InvariantCultureIgnoreCase))
                {
                    lvWindowsApps.Items.Remove(item);
                    return;
                }
            }
        }

        #endregion

        private List<ListViewItem> _allItems = new();
        private Dictionary<string, Rectangle> boundaries = default!;
        private readonly string[] programShortcutFileExtensions = [".lnk", ".url"];
    }

    /// <summary>
    /// Possible positions where the CanvasProgramLauncher can be shown
    /// </summary>
    public enum CanvasProgramLauncherPositionsEnum
    {
        /// <summary>
        /// Right-hand edge of the screen
        /// </summary>
        Right = 0,

        /// <summary>
        /// Left-hand edge of the screen
        /// </summary>
        Left
    }
}
