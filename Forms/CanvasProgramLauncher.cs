using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using AquariusShell.ConfigurationManagement;
using AquariusShell.ConfigurationManagement.Settings;
using AquariusShell.Modules;
using AquariusShell.Objects;
using AquariusShell.Runtime;

using Microsoft.WindowsAPICodePack.Shell;

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
        /// Enumerate items to display
        /// </summary>
        private void EnumerateWindowsProgramsItems()
        {
            imgListWindowsAppIcons.Images.Clear();
            _allWindowsApps.Clear();

            Size sz = new(ShellEnvironment.ConfiguredSizeOfIconsInPixels * 2, ShellEnvironment.ConfiguredSizeOfIconsInPixels * 2);
            foreach (ShellObject file in (IKnownFolder)AppsAndProgramsFolderReference)
            {
                if (IsAppVisible(file.Name, file.ParsingName))
                {
                    string imageKey = imgListWindowsAppIcons.Images.Count.ToString();
                    ShellThumbnail? thumbnail = file.Thumbnail;

                    Icon icon = SystemIcons.Application;
                    if (thumbnail != null)
                    {
                        thumbnail.FormatOption = ShellThumbnailFormatOption.IconOnly;
                        Bitmap bmp = thumbnail.LargeBitmap;
                        bmp.MakeTransparent();

                        icon = Icon.FromHandle(bmp.GetHicon());
                    }

                    imgListWindowsAppIcons.Images.Add(imageKey, Icons.Resize(icon, ShellEnvironment.ConfiguredSizeOfIcons).ToBitmap());

                    ListViewItem item = new()
                    {
                        Text = file.Name,
                        ImageKey = imageKey,
                        Tag = file.ParsingName
                    };
                    item.Bounds.Inflate(sz);

                    _allWindowsApps.Add(item);
                }
            }
        }

        /// <summary>
        /// Enumerate our shell apps for list
        /// </summary>
        private void EnumerateShellApps()
        {
            imgListShellAppIcons.Images.Clear();
            lvShellApps.Items.Clear();

            // Add Shell Apps
            foreach (AppIconOrShortcut shellApp in ShellEnvironment.ShellApps)
            {
                if ((!shellApp.HideFromLauncher) && IsAppVisible(shellApp.AppName, shellApp.Command))
                {
                    string imageKey = imgListShellAppIcons.Images.Count.ToString();
                    imgListShellAppIcons.Images.Add(imageKey, shellApp.Icon!);
                    ListViewItem item = new()
                    {
                        Text = shellApp.AppName,
                        ImageKey = imageKey,
                        Tag = shellApp.Command
                    };
                    lvShellApps.Items.Add(item);
                }
            }
        }


        /// <summary>
        /// Apply launcher settings
        /// </summary>
        private void ApplySettings()
        {
            this.SetFormBusyState(true);

            EnumerateShellApps();
            EnumerateWindowsProgramsItems();

            this.SetFormBusyState(false);
            
            FilterWindowsAppsList();
            tbWinProgsSearchBox.Visible = _settings.ShowSearchBox;
        }


        #region Event Subscriptions

        /// <summary>
        /// Double-click on ShellApps icon
        /// </summary>
        private void lvShellApps_ItemActivate(object sender, EventArgs e)
        {
            string shellAppCommand = lvShellApps.SelectedItems[0].Tag!.ToString()!;
            if (IsPasswordRequired(lvShellApps.SelectedItems[0].Text, shellAppCommand))
            {
                PopupTextInput input = new()
                {
                    Prompt = "Launching this app, program or file requires a password. Please enter the password if you know it.",
                    IsCancellable = true
                };

                if (input.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                if (!PasswordManagement.VerifyPassword(PasswordModuleNames.Shell, PasswordUsagePurposes.LaunchPasswordProtectedApp, input.Value))
                {
                    MessageBox.Show("That is not the required password!", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            this.Hide();

            // we are set to SINGLE select mode
            IShellAppModule? app = ShellEnvironment.ShellApps.GetInstanceOf(shellAppCommand);
            app?.Execute(shellAppCommand, ShellEnvironment.WorkArea);
        }

        /// <summary>
        /// Double-click on WindowsApps icon
        /// </summary>
        private void lvWindowsApps_ItemActivate(object sender, EventArgs e)
        {
            string command = lvWindowsApps.SelectedItems[0].Tag!.ToString()!;
            if (IsPasswordRequired(lvWindowsApps.SelectedItems[0].Text, command))
            {
                PopupTextInput input = new()
                {
                    Prompt = "Launching this app, program or file requires a password. Please enter the password if you know it.",
                    IsCancellable = true
                };

                if (input.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                if (!PasswordManagement.VerifyPassword(PasswordModuleNames.Shell, PasswordUsagePurposes.LaunchPasswordProtectedApp, input.Value))
                {
                    MessageBox.Show("That is not the required password!", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            this.Hide();

            // we are set to SINGLE select mode
            Shell32.ExecuteProgram("explorer.exe", Shell32.ShellExecuteVerbsEnum.None, false, $"shell:appsFolder\\{command}");
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

                case >= Keys.A and <= Keys.Z:
                case >= Keys.D0 and <= Keys.D9:
                case >= Keys.NumPad0 and <= Keys.NumPad9:
                    // send the keystroke to the textbox
                    if ((! tbWinProgsSearchBox.Focused) || (msg.HWnd != tbWinProgsSearchBox.Handle))
                    {                        
                        if ((keyData >= Keys.A) && (keyData <= Keys.Z))
                        {
                            tbWinProgsSearchBox.Text = ((char)('A' + (keyData - (int)Keys.A))).ToString();
                        }
                        else if ((keyData >= Keys.D0) && (keyData <= Keys.D9))
                        {
                            tbWinProgsSearchBox.Text = (keyData - (int)Keys.D0).ToString();
                        }
                        else if ((keyData >= Keys.NumPad0) && (keyData <= Keys.NumPad9))
                        {
                            tbWinProgsSearchBox.Text = (keyData - (int)Keys.NumPad0).ToString();
                        }

                        tbWinProgsSearchBox.SelectionStart = tbWinProgsSearchBox.Text.Length;
                        tbWinProgsSearchBox.SelectionLength = 0;
                        tbWinProgsSearchBox.Focus();
                    }
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Handles searching for (Windows-only) apps from the textbox on the panel
        /// </summary>
        private void tbWinProgsSearchBox_TextChanged(object? sender, EventArgs e)
        {
            FilterWindowsAppsList(tbWinProgsSearchBox.Text);            
        }

        /// <summary>
        /// App or Program deleted
        /// </summary>
        private void AppsAndProgramsFolderWatcher_ItemDeleted(object? sender, ShellObjectChangedEventArgs e)
        {
            EnumerateWindowsProgramsItems();
            FilterWindowsAppsList();
        }

        /// <summary>
        /// App or Program added
        /// </summary>
        private void AppsAndProgramsFolderWatcher_ItemCreated(object? sender, ShellObjectChangedEventArgs e)
        {
            EnumerateWindowsProgramsItems();
            FilterWindowsAppsList();
        }

        /// <summary>
        /// Configuration updated
        /// </summary>
        /// <param name="updatedSettings">Copy of updated settings</param>
        private void ConfigurationProvider_ConfigurationUpdated(IAquariusShellSettings updatedSettings)
        {
            _settings = (CanvasLauncherSettings)updatedSettings;
            ApplySettings();
        }

        #endregion


        /// <summary>
        /// Initialise
        /// </summary>
        public CanvasProgramLauncher()
        {
            InitializeComponent();

            _settings = ConfigurationProvider<CanvasLauncherSettings>.Get();
            ConfigurationProvider<CanvasLauncherSettings>.ConfigurationUpdated += ConfigurationProvider_ConfigurationUpdated;

            AppsAndProgramsFolderReference = (ShellObject)KnownFolderHelper.FromKnownFolderId(AppsAndProgramsFolderId);
            AppsAndProgramsFolderWatcher = new ShellObjectWatcher(AppsAndProgramsFolderReference, true);
            AppsAndProgramsFolderWatcher.ItemCreated += AppsAndProgramsFolderWatcher_ItemCreated;
            AppsAndProgramsFolderWatcher.ItemDeleted += AppsAndProgramsFolderWatcher_ItemDeleted;

            ApplySettings();
        }

        /// <summary>
        /// Filter the Windows Apps list
        /// </summary>
        /// <param name="filterString">Filter string</param>
        private void FilterWindowsAppsList(string filterString = "")
        {
            bool isEmpty = string.IsNullOrWhiteSpace(filterString);

            this.SetFormBusyState(true);

            lvWindowsApps.BeginUpdate();
            lvWindowsApps.Items.Clear();
            if (isEmpty)
            {
                foreach (ListViewItem item in _allWindowsApps)
                {
                    lvWindowsApps.Items.Add(item);
                }
            }
            else
            {
                foreach (ListViewItem item in _allWindowsApps)
                {
                    string targetPath = item.Tag!.ToString()!;
                    string resolvedShortcutPath = ResolveShortcut(targetPath);

                    if (item.Text.Contains(filterString, StringComparison.InvariantCultureIgnoreCase)
                        || targetPath.Contains(filterString, StringComparison.InvariantCultureIgnoreCase)
                        || ((resolvedShortcutPath != string.Empty) && resolvedShortcutPath.Contains(filterString, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        lvWindowsApps.Items.Add(item);
                    }
                }
            }
            lvWindowsApps.EndUpdate();
            this.SetFormBusyState(false);

            Application.DoEvents(); // give ourselves a chance to repaint
        }


        /// <summary>
        /// Returns if an app described by the provided attributes is visible
        /// </summary>
        /// <param name="attributes">App name, path, shortcut name etc</param>
        /// <returns>True if app is visible</returns>
        private bool IsAppVisible(params string[] attributes)
        {
            foreach(NameValuePair<string> hidden in _settings.HiddenPrograms)
            {
                foreach(string attrib in attributes)
                {
                    if (attrib.Equals(hidden.Value!, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return false;
                    }

                    if (Path.IsPathFullyQualified(attrib))
                    {
                        string directoryName = Path.GetDirectoryName(attrib)!, fileName = Path.GetFileName(attrib);
                        if (directoryName.StartsWith(hidden.Value!, StringComparison.InvariantCultureIgnoreCase) || fileName.Equals(hidden.Value!, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return false;
                        }
                    }

                    Regex r = new(hidden.Value!);
                    if (r.IsMatch(attrib))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Returns if an app described by the provided attributes requires a password before it can be launched
        /// </summary>
        /// <param name="attributes">App name, path, shortcut name, etc</param>
        /// <returns>True if app requires a launch password</returns>
        private bool IsPasswordRequired(params string[] attributes)
        {
            foreach (NameValuePair<string> requiresPassword in _settings.PasswordProtectedPrograms)
            {
                foreach (string attrib in attributes)
                {
                    if (attrib.Equals(requiresPassword.Value!, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return true;
                    }

                    if (Path.IsPathFullyQualified(attrib))
                    {
                        string directoryName = Path.GetDirectoryName(attrib)!, fileName = Path.GetFileName(attrib);
                        if (directoryName.StartsWith(requiresPassword.Value!, StringComparison.InvariantCultureIgnoreCase) || fileName.Equals(requiresPassword.Value!, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return true;
                        }
                    }

                    Regex r = new(requiresPassword.Value!);
                    if (r.IsMatch(attrib))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Resolve a shortcut and retrieve its target path
        /// </summary>
        /// <param name="shortcutPath">Path to a shortcut (.lnk) file</param>
        /// <returns>The resolved shortcut</returns>
        private string ResolveShortcut(string shortcutPath)
        {
            string result = shortcutPath;
            if (!shortcutPath.EndsWith(".lnk", StringComparison.InvariantCultureIgnoreCase))
            {
                return shortcutPath;
            }

            if (_wscript_Shell == null)
            {
                try
                {
                    Type? shType = Type.GetTypeFromProgID("WScript.Shell");
                    if (shType != null)
                    {
                        _wscript_Shell = Activator.CreateInstance(shType);
                    }
                }
                catch { }
            }

            if (_wscript_Shell != null)
            {
                dynamic? wsShortcut;
                try
                {
                    wsShortcut = _wscript_Shell.CreateShortcut(shortcutPath);
                    result = wsShortcut.TargetPath;
                }
                catch
                {                    
                }

#pragma warning disable IDE0059 // unnecessary assignment
                wsShortcut = null;
#pragma warning restore IDE0059 // unnecessary assignment
            }

            return result;
        }


        private dynamic? _wscript_Shell = null;
        private readonly List<ListViewItem> _allWindowsApps = new();
        private CanvasLauncherSettings _settings;

        const int FORM_WIDTH = 800, FORM_HEIGHT = 600;


        private readonly Guid AppsAndProgramsFolderId = new("1e87508d-89c2-42f0-8a7e-645a0f50ca58");
        private readonly ShellObject AppsAndProgramsFolderReference;
        private readonly ShellObjectWatcher AppsAndProgramsFolderWatcher;
    }
}
