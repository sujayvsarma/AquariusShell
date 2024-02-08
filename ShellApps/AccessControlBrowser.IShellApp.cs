
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AquariusShell.Controls;
using AquariusShell.Modules;
using AquariusShell.Runtime;

namespace AquariusShell.ShellApps
{
    /// <summary>
    /// The IShellApp implementation
    /// </summary>
    public partial class AccessControlBrowser : IShellAppModule
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
                    _icon = SystemIcons.GetStockIcon(StockIconId.Lock, ShellEnvironment.ConfiguredSizeOfIconsInPixels).ToBitmap();
                }

                return _icon;
            }
        }
        private Image? _icon = null;

        /// <summary>
        /// The caption text for this in the program launcher etc
        /// </summary>
        public string Caption => "Permissions browser";

        /// <summary>
        /// The launch command for this module
        /// </summary>
        public string Command => _command;
        private static string _command = $"{IShellAppModule.CommandSignifierPrefix}aclbrowser";

        /// <summary>
        /// Instancing mode
        /// </summary>
        public ShellAppInstancingModeEnum InstancingMode => ShellAppInstancingModeEnum.Multiple;

        /// <summary>
        /// When set, this app is not shown on the Launcher UI
        /// </summary>
        public bool HideFromLauncher => true;

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
                // param#0 should be the path we want to show (from a context menu)
                if ((parameters.Length > 0) && (!string.IsNullOrWhiteSpace(parameters[0])))
                {
                    // Recursively load the items upto and including the provided path.
                    string[] path = parameters[0].Split(Path.DirectorySeparatorChar, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                    // path[0] would be the drive label ("C:"), let's \\ it
                    path[0] = $"{path[0]}\\";
                    DriveInfo? parentDrive = DriveInfo.GetDrives().FirstOrDefault(d => (d.Name == path[0]));
                    FileSystemNode? parentNode = null;

                    _disableTreeViewActivation = true;

                    if (parentDrive != null)
                    {
                        string imageKey = parentDrive.DriveType switch
                        {
                            DriveType.CDRom => StockIconId.DriveCD.ToString(),
                            DriveType.Fixed => StockIconId.DriveFixed.ToString(),
                            DriveType.Network => (parentDrive.IsReady ? StockIconId.DriveNet.ToString() : StockIconId.DriveNetDisabled.ToString()),
                            DriveType.NoRootDirectory => StockIconId.DriveUnknown.ToString(),
                            DriveType.Ram => StockIconId.DriveRam.ToString(),
                            DriveType.Removable => StockIconId.DriveRemovable.ToString(),

                            _ => StockIconId.DriveUnknown.ToString()
                        };

                        try
                        {
                            parentNode = AddItemToTreeView(
                                    null,
                                    $"{parentDrive.VolumeLabel}{Environment.NewLine}({parentDrive.Name})",
                                    imageKey,
                                    parentDrive.Name
                                );
                        }
                        catch (IOException)
                        {
                            parentNode = AddItemToTreeView(
                                    null,
                                    $"(Not Formatted) {Environment.NewLine}({parentDrive.Name})",
                                    imageKey,
                                    parentDrive.Name
                                );
                        }
                    }

                    if (parentNode == null)
                    {
                        MessageBox.Show($"A drive or root path by the name '{path[0]}' could not be found.", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // populate our hierarchy LL
                    _hierarchy.AddFirst(parentNode);

                    // Load up our path, recursively
                    string pathString = path[0];
                    for (int i = 1; i < path.Length; i++)
                    {
                        pathString = Path.Combine(pathString, path[i]);

                        string currentPathSegment = pathString.ToString(), imageKey;
                        if (Directory.Exists(currentPathSegment))
                        {
                            imageKey = IMAGEKEY_FOLDER;
                        }
                        else
                        {
                            imageKey = Path.GetExtension(path[i]).ToUpperInvariant();
                            if (imageKey == ".LNK")
                            {
                                // each .lnk will have its own icon, based on its target
                                int linkItemsCount = 0;
                                foreach (string? s in ilFileSystemImages.Images.Keys)
                                {
                                    if ((!string.IsNullOrWhiteSpace(s)) && (s.EndsWith(".LNK")))
                                    {
                                        linkItemsCount++;
                                    }
                                }

                                imageKey = $"{linkItemsCount}.LNK";
                            }

                            if (!ilFileSystemImages.Images.ContainsKey(imageKey))
                            {
                                Icon icon = Icons.ExtractAssociatedIcon(currentPathSegment);
                                AddIconToImageLists(imageKey, icon);
                            }
                        }

                        parentNode = AddItemToTreeView(
                                parentNode,
                                path[i],
                                imageKey,
                                currentPathSegment
                            );

                        // populate our hierarchy LL
                        _hierarchy.AddLast(parentNode);
                    }

                    // clear the last node's children if we have them
                    if (parentNode.IsExpandable)
                    {
                        parentNode.Nodes.Clear();
                    }

                    _disableTreeViewActivation = false;
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