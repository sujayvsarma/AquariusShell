using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using AquariusShell.Controls;
using AquariusShell.Runtime;

namespace AquariusShell.ShellApps
{
    /// <summary>
    /// The IShellAppModule implementation
    /// </summary>
    partial class FileBrowser : IShellAppModule
    {
        #region Properties

        /// <summary>
        /// The icon displayable for this module in the program launcher etc
        /// </summary>
        public Image LauncherOrTaskManagerIcon
        {
            get
            {
                if (_icon == null)
                {
                    _icon = SystemIcons.GetStockIcon(StockIconId.DesktopPC, ShellEnvironment.ConfiguredSizeOfIconsInPixels).ToBitmap();
                }

                return _icon;
            }
        }
        private Image? _icon = null;

        /// <summary>
        /// The caption text for this in the program launcher etc
        /// </summary>
        public string Caption => "File browser";

        /// <summary>
        /// The launch command for this module
        /// </summary>
        public string Command => _command;
        private static string _command = $"{IShellAppModule.CommandSignifierPrefix}file";

        /// <summary>
        /// Instancing mode
        /// </summary>
        public ShellAppInstancingModeEnum InstancingMode => ShellAppInstancingModeEnum.Multiple;

        /// <summary>
        /// When set, this app is not shown on the Launcher UI
        /// </summary>
        public bool HideFromLauncher => false;

        #endregion

        #region Methods

        /// <summary>
        /// Evaluate the provided command and respond if this module can handle it.
        /// </summary>
        /// <param name="command">Command string to evaluate.</param>
        /// <param name="parameters">Any potential parameters for this command (context)</param>
        /// <returns>TRUE if this module can handle it.</returns>
        public bool HandlesCommand(string command, params string[] parameters)
            => command.Equals(_command, StringComparison.InvariantCultureIgnoreCase);

        /// <summary>
        /// Execute the module
        /// </summary>

        /// <param name="command">Command string</param>
        /// <param name="parentWindowHandle">Parent window. If NULL, sets to Workarea</param>
        /// <param name="parameters">Any parameters for this command (context)</param>
        public void Execute(string command, IWin32Window? parentWindowHandle, params string[] parameters)
        {
            if (_command.Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(parameters[i]))
                    {
                        switch (i)
                        {
                            // 1st: Directory to start in
                            case 0:
                                if (Directory.Exists(parameters[i]))
                                {
                                    _currentDirectory = parameters[i];
                                }
                                break;

                            // 2nd: File or directory to show as selected
                            case 1:
                                if (Directory.Exists(parameters[i]))
                                {
                                    DirectoryInfo di = new(parameters[i]);
                                    if ((di.Attributes.HasFlag(FileAttributes.Hidden) && (!_displayFlags.HasFlag(FileBrowserItemDisplayFlags.ShowHiddenItems)))
                                        || (di.Attributes.HasFlag(FileAttributes.System) && (!_displayFlags.HasFlag(FileBrowserItemDisplayFlags.ShowSystemItems))))
                                    {
                                        MessageBox.Show("The target directory is of a type that is set to be hidden from you. Change the settings for 'File browser' before trying again.",
                                            "Aquarius Shell",
                                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        return;
                                    }

                                    if ((!Directory.EnumerateFileSystemEntries(parameters[i]).Any()) && _displayFlags.HasFlag(FileBrowserItemDisplayFlags.HideEmptyFolders))
                                    {
                                        MessageBox.Show("The target directory is empty and is set to be hidden from view. Change the settings for 'File browser' before trying again.",
                                            "Aquarius Shell",
                                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        return;
                                    }
                                }
                                else if (File.Exists(parameters[i]))
                                {
                                    FileInfo fi = new(parameters[i]);
                                    if ((fi.Attributes.HasFlag(FileAttributes.Hidden) && (!_displayFlags.HasFlag(FileBrowserItemDisplayFlags.ShowHiddenItems)))
                                        || (fi.Attributes.HasFlag(FileAttributes.System) && (!_displayFlags.HasFlag(FileBrowserItemDisplayFlags.ShowSystemItems))))
                                    {
                                        MessageBox.Show("The target file is of a type that is set to be hidden from you. Change the settings for 'File browser' before trying again.",
                                            "Aquarius Shell",
                                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        return;
                                    }

                                    if ((fi.Length == 0) && _displayFlags.HasFlag(FileBrowserItemDisplayFlags.HideZeroByteFiles))
                                    {
                                        MessageBox.Show("The target file is empty and is set to be hidden from view. Change the settings for 'File browser' before trying again.",
                                            "Aquarius Shell",
                                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        return;
                                    }
                                }

                                _preselectedItem = parameters[i];
                                break;
                        }
                    }
                }

                this.Show((parentWindowHandle ?? ShellEnvironment.WorkArea));
            }
        }

        #endregion

        /// <summary>
        /// Notify that this app was closed by the user
        /// </summary>
        public event BuiltInAppClosed? AppClosed = null;
    }
}