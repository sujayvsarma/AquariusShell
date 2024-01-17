using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AquariusShell.Modules;

using static AquariusShell.Modules.Icons;

namespace AquariusShell.Controls
{
    public partial class IconListDisplaySurface : UserControl
    {

        #region Properties

        /// <summary>
        /// The full directory path that is to be loaded and displayed. Default is the current user's desktop. 
        /// This may be a semi-colon seperated list of directories (eg: "C:\Path\1;C:\Path\2;D:\This\One\Too"). 
        /// There are certain special path values as well, these are defined as constants.
        /// </summary>
        public string DirectoryToLoad
        {
            get; set;
        }

        /// <summary>
        /// The size of icons
        /// </summary>
        public IconSizesEnum IconSize
        {
            get; set;

        } = IconSizesEnum.x24;

        /// <summary>
        /// Show hidden files on the UI
        /// </summary>
        public bool IsHiddenFilesVisible { get; set; } = false;

        /// <summary>
        /// Show system files on the UI
        /// </summary>
        public bool IsSystemFilesVisible { get; set; } = false;

        #endregion

        #region Methods

        /// <summary>
        /// Loads items from the provided path and displays them
        /// </summary>
        public void DisplayItems()
        {
            flowLayout.Controls.Clear();

            _iconSizePixels = (int)IconSize;

            viewImages.Images.Clear();
            viewImages.ImageSize = new(_iconSizePixels, _iconSizePixels);
            viewImages.Images.Add(IMAGEKEY_FOLDER, SystemIcons.GetStockIcon(StockIconId.Folder, _iconSizePixels));

            foreach (string path in DirectoryToLoad.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                if (path.Equals(SPECIALPATH_COMPUTER) || path.Equals(Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)))
                {
                    LoadComputer();
                }
                else if (path.Equals(SPECIALPATH_CONTROLPANEL))
                {
                    LoadControlPanel();
                }
                else if (path.Equals(SPECIALPATH_PRINTERS))
                {
                    LoadPrinters();
                }
                else if (path.Equals(SPECIALPATH_DEVICES))
                {
                    LoadDevices();
                }
                else if (path.Equals(SPECIALPATH_NETWORK))
                {
                    LoadNetwork();
                }
                else
                {
                    // normal file system
                    LoadFilesystem(path);

                    fsWatcher.Path = path;
                    fsWatcher.NotifyFilter =
                        System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName
                        | System.IO.NotifyFilters.Attributes | System.IO.NotifyFilters.Size | System.IO.NotifyFilters.CreationTime;

                    fsWatcher.EnableRaisingEvents = true;
                }
            }
        }

        /// <summary>
        /// Loads the "My Computer" view
        /// </summary>
        private void LoadComputer()
        {
            // Drives
            StockIconId[] driveIcons =
            [
                StockIconId.Drive35,
                StockIconId.Drive525,
                StockIconId.DriveBD,
                StockIconId.DriveCD,
                StockIconId.DriveDVD,
                StockIconId.DriveHDDVD,
                StockIconId.DriveFixed,
                StockIconId.DriveNet,
                StockIconId.DriveNetDisabled,
                StockIconId.DriveRam,
                StockIconId.DriveRemovable,
                StockIconId.DriveUnknown,
                StockIconId.ClusteredDrive
            ];

            foreach (StockIconId id in driveIcons)
            {
                viewImages.Images.Add(id.ToString(), SystemIcons.GetStockIcon(id, _iconSizePixels));
            }

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                string imageKey = drive.DriveType switch
                {
                    DriveType.CDRom => StockIconId.DriveCD.ToString(),
                    DriveType.Fixed => StockIconId.DriveFixed.ToString(),
                    DriveType.Network => (drive.IsReady ? StockIconId.DriveNet.ToString() : StockIconId.DriveNetDisabled.ToString()),
                    DriveType.NoRootDirectory => StockIconId.DriveUnknown.ToString(),
                    DriveType.Ram => StockIconId.DriveRam.ToString(),
                    DriveType.Removable => StockIconId.DriveRemovable.ToString(),

                    _ => StockIconId.DriveUnknown.ToString()
                };

                IconWithLabel item = new()
                {
                    Caption = drive.VolumeLabel,
                    Icon = viewImages.Images[imageKey],
                    TargetPath = drive.Name,
                };

                _pathToIconMapping.Add(drive.Name, item);
                flowLayout.Controls.Add(item);
            }

            this.BackColor = SystemColors.Control;
            this.ForeColor = SystemColors.ControlText;
        }

        /// <summary>
        /// Loads the "Control Panel" view
        /// </summary>
        private void LoadControlPanel()
        {

        }

        /// <summary>
        /// Loads the "Printers" view
        /// </summary>
        private void LoadPrinters()
        {

        }

        /// <summary>
        /// Loads the "Devices" view
        /// </summary>
        private void LoadDevices()
        {

        }

        /// <summary>
        /// Loads the "Network" view
        /// </summary>
        private void LoadNetwork()
        {

        }

        /// <summary>
        /// Load items from a normal folder/directory
        /// </summary>
        /// <param name="path">The path to load from</param>
        private void LoadFilesystem(string path)
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                DirectoryInfo dirInfo = new(directory);

                if (((!IsHiddenFilesVisible) && dirInfo.Attributes.HasFlag(FileAttributes.Hidden))
                    || ((!IsSystemFilesVisible) && dirInfo.Attributes.HasFlag(FileAttributes.System)))
                {
                    continue;
                }

                AddIcon(dirInfo.FullName);
            }

            foreach (string file in Directory.GetFiles(path))
            {
                FileInfo fileInfo = new(file);

                if (((!IsHiddenFilesVisible) && fileInfo.Attributes.HasFlag(FileAttributes.Hidden))
                    || ((!IsSystemFilesVisible) && fileInfo.Attributes.HasFlag(FileAttributes.System)))
                {
                    continue;
                }

                AddIcon(fileInfo.FullName);
            }
        }

        /// <summary>
        /// Set the icon on a particular item by its filename extension or type
        /// </summary>
        /// <param name="item">Instance of IconWithLabel to modify</param>
        private void SetItemIconByExtension(IconWithLabel item)
        {
            string path = item.TargetPath;
            string imageKey;

            if (Directory.Exists(path))
            {
                imageKey = IMAGEKEY_FOLDER;
            }
            else
            {
                imageKey = Path.GetExtension(path).ToUpperInvariant();
                if (imageKey == ".LNK")
                {
                    imageKey = path.ToUpperInvariant();
                }

                if (!viewImages.Images.ContainsKey(imageKey))
                {
                    Icon? icon = Icons.ExtractAssociatedIcon(path, IconSize);
                    if (icon != null)
                    {
                        viewImages.Images.Add(imageKey, icon);
                    }
                }
            }

            item.Icon = viewImages.Images[imageKey];
        }

        /// <summary>
        /// Adds an icon for the given path, adds it to the screen and attaches required event handlers
        /// </summary>
        /// <param name="path">Full path to the target ITEM to add an icon for</param>
        /// <returns>The icon added with handlers etc already attached</returns>
        private IconWithLabel AddIcon(string path)
        {
            string keyString = GenerateItemKeyFromPath(path);
            IconWithLabel control;

            // add icon only if not already added
            if (_pathToIconMapping.ContainsKey(keyString))
            {
                // icon exists. If this is a folder, add incoming path to existing icon's target.
                // if this is a FILE and one of the paths is a user-specific one, use ONLY that!
                control = _pathToIconMapping[keyString];

                if (path.StartsWith(_userProfileRoot))
                {
                    control.TargetPath = path;
                }
                else
                {
                    control.TargetPath = string.Join(';', control.TargetPath, path);
                }
            }
            else
            {
                string extn = Path.GetExtension(path);
                control = new()
                {
                    Caption = $"{Path.GetFileNameWithoutExtension(path)}{(string.IsNullOrWhiteSpace(extn) ? string.Empty : $" ({extn})")}",
                    TargetPath = path
                };

                SetItemIconByExtension(control);

                flowLayout.Controls.Add(control);
                _pathToIconMapping.Add(keyString, control);

                control.ItemClicked += IconsWithLabels_ItemClicked;
            }            

            return control;
        }

        /// <summary>
        /// Generates the key string to be used with the _pathToIconMapping dictionary for either storage or retrieval
        /// </summary>
        /// <param name="path">Full path to item</param>
        /// <returns>Key string</returns>
        private string GenerateItemKeyFromPath(string path) => Path.GetFileName(path).Trim().Trim('.').ToUpperInvariant();

        #endregion


        /// <summary>
        /// Event fired when a FilesystemIcon is clicked on
        /// </summary>
        /// <param name="caption">Caption on the item</param>
        /// <param name="targetPath">The target path of what the element was showing</param>
        /// <param name="icon">Icon that was displayed</param>
        private void IconsWithLabels_ItemClicked(string caption, string targetPath, Image? icon)
        {
            if ((ItemClicked != null) && (ItemClicked.GetInvocationList().Length > 0))
            {
                ItemClicked(caption, targetPath, icon);
            }
        }

        private void OnFilesystemItemCreatedDeletedOrChanged(object sender, System.IO.FileSystemEventArgs e)
        {
            string keyString = GenerateItemKeyFromPath(e.FullPath);

            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Created:
                    AddIcon(e.FullPath);
                    break;

                case WatcherChangeTypes.Changed:
                    IconWithLabel? itemToUpdate = (_pathToIconMapping.ContainsKey(keyString) ? _pathToIconMapping[keyString] : null);
                    if (Directory.Exists(e.FullPath))
                    {
                        DirectoryInfo di = new(e.FullPath);

                        // Is hidden
                        if (di.Attributes.HasFlag(FileAttributes.Hidden))
                        {
                            // Show hidden, no icon > add it
                            if (IsHiddenFilesVisible && (itemToUpdate == null))
                            {
                                AddIcon(e.FullPath);
                            }
                            else if ((itemToUpdate != null) && (!IsHiddenFilesVisible))
                            {
                                // Hide hidden, is icon > remove it
                                flowLayout.Controls.Remove(itemToUpdate);
                            }
                        }
                        else if (di.Attributes.HasFlag(FileAttributes.System))
                        {
                            // Show system, no icon > add it
                            if (IsSystemFilesVisible&& (itemToUpdate == null))
                            {
                                AddIcon(e.FullPath);
                            }
                            else if ((itemToUpdate != null) && (!IsSystemFilesVisible))
                            {
                                // Hide system, is icon > remove it
                                flowLayout.Controls.Remove(itemToUpdate);
                            }
                        }
                    }
                    break;

                case WatcherChangeTypes.Deleted:
                    if (_pathToIconMapping.ContainsKey(keyString))
                    {
                        flowLayout.Controls.Remove(_pathToIconMapping[keyString]);
                    }
                    break;
            }
        }

        private void OnFilesystemItemRenamed(object sender, System.IO.RenamedEventArgs e)
        {
            string? oldDirectory = Path.GetDirectoryName(e.OldFullPath);
            string? newDirectory = Path.GetDirectoryName(e.FullPath);
            string? oldName = (string.IsNullOrWhiteSpace(e.OldName) ? null : Path.GetFileName(e.OldName));
            string? newName = Path.GetFileName(e.Name);

            if ((!string.IsNullOrWhiteSpace(newDirectory)) && (!string.IsNullOrWhiteSpace(newName)))
            {
                IconWithLabel control = _pathToIconMapping[GenerateItemKeyFromPath(e.OldFullPath)];
                if (oldDirectory != newDirectory)
                {
                    // no longer in scope of what we need to be showing
                    flowLayout.Controls.Remove(control);
                }
                else
                {
                    if (oldName != newName)
                    {
                        control.Caption = newName;
                        control.TargetPath = e.FullPath;
                        SetItemIconByExtension(control);
                    }
                }
            }
        }


        /// <summary>
        /// Initialise the surface
        /// </summary>
        public IconListDisplaySurface()
        {
            InitializeComponent();

            DirectoryToLoad = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }


        /// <summary>
        /// Event - this icon instance was clicked by the user
        /// </summary>
        public event ItemClicked? ItemClicked = null;


        private int _iconSizePixels = 16;
        private readonly Dictionary<string, IconWithLabel> _pathToIconMapping = new();
        private readonly string _userProfileRoot = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        private const string IMAGEKEY_FOLDER = "Folder";

        // Special path values that we interpret differently!
        public static string SPECIALPATH_COMPUTER = "__AQSHELL_COMPUTER";
        public static string SPECIALPATH_CONTROLPANEL = "__AQSHELL_CONTROLPANEL";
        public static string SPECIALPATH_PRINTERS = "__AQSHELL_PRINTERS";
        public static string SPECIALPATH_DEVICES = "__AQSHELL_DEVICES";
        public static string SPECIALPATH_NETWORK = "__AQSHELL_NETWORK";
    }
}
