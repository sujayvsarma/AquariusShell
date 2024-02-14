using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

using AquariusShell.Modules;
using AquariusShell.Objects;
using AquariusShell.Runtime;

namespace AquariusShell.ShellApps
{
    /// <summary>
    /// All the method implementations
    /// </summary>
    partial class FileBrowser
    {
        /// <summary>
        /// Loads the view for the current directory (value of _currentDirectory field)
        /// </summary>
        private void LoadCurrentDirectoryView(string? newDirectory = null)
        {
            string currentTabDirectory = GetCurrentDirectoryForTab(_activeTab);
            if (newDirectory != null)
            {
                currentTabDirectory = newDirectory;
            }
            NoteCurrentDirectoryForTab(_activeTab, currentTabDirectory);

            _activeExplorer.Items.Clear();
            _activeExplorer.Groups.Clear();
            _activeExplorer.Columns.Clear();

            viewImagesLarge.Images.Clear();
            viewImagesSmall.Images.Clear();
            AddIconToImageLists(ShellEnvironment.IMAGEKEY_FOLDER, SystemIcons.GetStockIcon(StockIconId.Folder));
            AddIconToImageLists(IMAGEKEY_PARENTCONTAINER, SystemIcons.GetStockIcon(StockIconId.FolderOpen));

            _editActionsOnListViewItemsIsDisabled = true;
            _listingState = ListViewListingStatesEnum.SpecialFolder;

            if (currentTabDirectory == DIRECTORY_MYCOMPUTER)
            {
                LoadMyComputerView();
                tbJumpAddress.Text = "Computer";
            }
            else if (currentTabDirectory == PATHKEY_PRINTERS)
            {
                LoadPrintersList();
                tbJumpAddress.Text = "Printers";
            }
            else if (currentTabDirectory == PATHKEY_RECYCLEBIN)
            {
                LoadRecycleBinView();
                tbJumpAddress.Text = "Deleted items";
            }
            else
            {
                _editActionsOnListViewItemsIsDisabled = false;
                if (currentTabDirectory.StartsWith(Environment.GetFolderPath(Environment.SpecialFolder.Windows))
                        || currentTabDirectory.StartsWith(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles))
                        || currentTabDirectory.StartsWith(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86))
                        || currentTabDirectory.StartsWith(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles))
                        || currentTabDirectory.StartsWith(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86)))
                {
                    // Protect system directories   
                    _editActionsOnListViewItemsIsDisabled = true;
                }

                _listingState = ListViewListingStatesEnum.FileSystemDirectory;
                LoadFilesystemDirectory();

                tbJumpAddress.Text = currentTabDirectory;
            }

            if (! string.IsNullOrWhiteSpace(_preselectedItem))
            {
                foreach (ListViewItem item in _activeExplorer.Items)
                {
                    if (GetPathFromListViewItem(item) == _preselectedItem)
                    {
                        item.Selected = true;
                        break;
                    }
                }

                // This is a use-once thingy!
                _preselectedItem = null;
            }

            ResetToolbarAndContextMenu();
            SetActiveTabTitle();
        }

        /// <summary>
        /// Load the My Computer view
        /// </summary>
        private void LoadMyComputerView()
        {
            // Adds all the "Drive" icons
            Icons.LoadDriveIcons(viewImagesLarge, viewImagesSmall);

            // special items
            AddIconToImageLists(IMAGEKEY_RECYCLEBIN, SystemIcons.GetStockIcon(StockIconId.Recycler));
            AddIconToImageLists(IMAGEKEY_PRINTERS, SystemIcons.GetStockIcon(StockIconId.Printer));            

            // Groups
            _activeExplorer.Groups.AddRange(
                    new ListViewGroup[]
                    {
                        new ListViewGroup("Drives") { Name = "lvgDrives", CollapsedState = ListViewGroupCollapsedState.Expanded },
                        new ListViewGroup("Printers and Supported Device Groups") { Name = "lvgDevices", CollapsedState = ListViewGroupCollapsedState.Expanded },
                        new ListViewGroup("Windows System Objects") { Name = "lvgWinSys", CollapsedState = ListViewGroupCollapsedState.Expanded }
                    }
                );

            // Columns for Details view
            _activeExplorer.Columns.AddRange(
                    new ColumnHeader[]
                    {
                        new ColumnHeader() { Width = 240, Text = "Volume label" },
                        new ColumnHeader() { Width = 42, Text = "Drive", TextAlign = HorizontalAlignment.Center },
                        new ColumnHeader() { Width = 120, Text = "Format" },
                        new ColumnHeader() { Width = 120, Text = "Total size" },
                        new ColumnHeader() { Width = 120, Text = "Free space" }
                    }
                );

            // Load drives
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                string imageKey = Icons.GetImageKey(drive);
                ListViewItem driveIcon = default!;

                try
                {
                    driveIcon = AddItemToListView(
                            $"{drive.VolumeLabel}{Environment.NewLine}({drive.Name})",
                            imageKey,
                            drive.Name,
                                drive.Name,
                                drive.DriveFormat,
                                drive.TotalSize.FormatFileSize(),
                                drive.TotalFreeSpace.FormatFileSize()
                        );
                }
                catch(IOException)
                {
                    // Drive may not be formatted, but add it to our view nonetheless
                    driveIcon = AddItemToListView(
                            $"(Not Formatted) {Environment.NewLine}({drive.Name})",
                            imageKey,
                            drive.Name,
                                drive.Name,
                                "Not formatted",
                                "-",
                                "-"
                        );
                }

                driveIcon.Group = _activeExplorer.Groups["lvgDrives"];
            }

            // Recycle bin
            ListViewItem recycleBin = AddItemToListView(
                    "Deleted Items",
                    IMAGEKEY_RECYCLEBIN,
                    PATHKEY_RECYCLEBIN
                );
            recycleBin.Group = _activeExplorer.Groups["lvgWinSys"];

            // Printers
            ListViewItem printers = AddItemToListView(
                    "Installed printers",
                    IMAGEKEY_PRINTERS,
                    PATHKEY_PRINTERS
                );
            printers.Group = _activeExplorer.Groups["lvgDevices"];
        }

        /// <summary>
        /// Loads a regular filesystem directory into the view
        /// </summary>
        private void LoadFilesystemDirectory()
        {
            // Groups
            _activeExplorer.Groups.AddRange(
                    new ListViewGroup[]
                    {
                        new ListViewGroup("Directories") { Name = "lvgDirectories", CollapsedState = ListViewGroupCollapsedState.Expanded },
                        new ListViewGroup("Executable programs") { Name = "lvgExecutables", CollapsedState = ListViewGroupCollapsedState.Expanded },
                        new ListViewGroup("All other files") { Name = "lvgAllOtherFiles", CollapsedState = ListViewGroupCollapsedState.Expanded }
                    }
                );

            // Columns for Details view
            _activeExplorer.Columns.AddRange(
                    new ColumnHeader[]
                    {
                            new ColumnHeader() { Width = 240, Text = "Name" },
                            new ColumnHeader() { Width = 42, Text = "Sync", TextAlign = HorizontalAlignment.Center },
                            new ColumnHeader() { Width = 180, Text = "Type" },
                            new ColumnHeader() { Width = 120, Text = "Size", TextAlign = HorizontalAlignment.Right },
                            new ColumnHeader() { Width = 180, Text = "Last modified", TextAlign = HorizontalAlignment.Right }
                    }
                );

            // Set up the BACK icon
            string currentTabDirectory = GetCurrentDirectoryForTab(_activeTab);
            if (!string.IsNullOrWhiteSpace(currentTabDirectory))
            {
                DirectoryInfo? diParent = (new DirectoryInfo(currentTabDirectory)).Parent;
                if (diParent != null)
                {
                    ListViewItem backIcon = AddItemToListView(
                        "(..)",
                        IMAGEKEY_PARENTCONTAINER,
                        diParent.FullName,
                            string.Empty,
                            "Parent directory",
                            string.Empty,
                            string.Empty
                    );
                    backIcon.Group = _activeExplorer.Groups["Directories"];
                }
                else
                {
                    // We need to root this in My Computer
                    ListViewItem backIcon = AddItemToListView(
                        "(..)",
                        IMAGEKEY_PARENTCONTAINER,
                        DIRECTORY_MYCOMPUTER,
                            string.Empty,
                            "Parent directory",
                            string.Empty,
                            string.Empty
                    );
                    backIcon.Group = _activeExplorer.Groups["Directories"];
                }
            }
            else
            {
                // We are at drive root, parent is My Computer view!
                ListViewItem backIcon = AddItemToListView(
                    "(..)",
                    IMAGEKEY_PARENTCONTAINER,
                    DIRECTORY_MYCOMPUTER,
                        string.Empty,
                        "Parent directory",
                        string.Empty,
                        string.Empty
                );
                backIcon.Group = _activeExplorer.Groups["Directories"];
            }

            // Load directories first
            foreach (string directoryPath in Directory.GetDirectories(currentTabDirectory, "*.*", SearchOption.TopDirectoryOnly))
            {
                DirectoryInfo di = new(directoryPath);

                try
                {
                    // Do we need to hide Hidden/System or empty folders?
                    if ((di.Attributes.HasFlag(FileAttributes.Hidden) && (!_displayFlags.HasFlag(FileBrowserItemDisplayFlags.ShowHiddenItems)))
                        || (di.Attributes.HasFlag(FileAttributes.System) && (!_displayFlags.HasFlag(FileBrowserItemDisplayFlags.ShowSystemItems)))
                        || ((!Directory.EnumerateFileSystemEntries(directoryPath).Any()) && _displayFlags.HasFlag(FileBrowserItemDisplayFlags.HideEmptyFolders)))
                    {
                        continue;
                    }
                }
                catch
                {
                    // sometimes we get an access denied
                    continue;
                }

                ListViewItem folderIcon = AddItemToListView(
                        di.Name,
                        ShellEnvironment.IMAGEKEY_FOLDER,
                        di.FullName,
                            string.Empty,
                            "Directory",
                            string.Empty,
                            ((di.LastAccessTime > di.LastWriteTime) ? di.LastWriteTime : di.LastWriteTime).ToString("MMM dd, yyyy HH:mm:ss")
                    );
                folderIcon.Group = _activeExplorer.Groups["Directories"];
            }

            // Load files
            foreach (string filePath in Directory.GetFiles(currentTabDirectory, "*.*", SearchOption.TopDirectoryOnly))
            {
                FileInfo fi = new(filePath);

                try
                {
                    // Do we need to hide Hidden/System or empty files?
                    if ((fi.Attributes.HasFlag(FileAttributes.Hidden) && (!_displayFlags.HasFlag(FileBrowserItemDisplayFlags.ShowHiddenItems)))
                        || (fi.Attributes.HasFlag(FileAttributes.System) && (!_displayFlags.HasFlag(FileBrowserItemDisplayFlags.ShowSystemItems)))
                        || ((fi.Length == 0) && _displayFlags.HasFlag(FileBrowserItemDisplayFlags.HideZeroByteFiles)))
                    {
                        continue;
                    }
                }
                catch
                {
                    // sometimes we can hit an access denied
                    continue;
                }

                // If a file is marked Offline, it is usually a one-drive backed item that does not exist on disk.
                // Trying to fetch its icon would download the item!!!
                string imageKey = (fi.Attributes.HasFlag(FileAttributes.Offline) ? Icons.GetGenericFileIcon(viewImagesLarge, viewImagesSmall) : Icons.GetImageKey(fi.FullName, viewImagesLarge, viewImagesSmall));

                ListViewItem fileIcon = AddItemToListView(
                        fi.Name,
                        imageKey,
                        fi.FullName,
                            fi.Attributes.HasFlag(FileAttributes.Offline) ? "No" : "Yes",
                            Shell32.GetFileTypeName(fi.Extension, true),
                            fi.Length.FormatFileSize(),
                            ((fi.LastAccessTime > fi.LastWriteTime) ? fi.LastWriteTime : fi.LastWriteTime).ToString("MMM dd, yyyy HH:mm:ss")
                    );
                fileIcon.Group = _activeExplorer.Groups[(IsFileExecutable(fi.Extension) ? "lvgExecutables" : "lvgAllOtherFiles")];
            }
        }

        /// <summary>
        /// Load the recycle bin view
        /// </summary>
        private void LoadRecycleBinView()
        {
            // Columns for Details view
            _activeExplorer.Columns.AddRange(
                        new ColumnHeader[]
                        {
                            new ColumnHeader() { Width = 240, Text = "Name" },
                            new ColumnHeader() { Width = 180, Text = "Type" },
                            new ColumnHeader() { Width = 120, Text = "Size", TextAlign = HorizontalAlignment.Right },
                            new ColumnHeader() { Width = 180, Text = "Deleted at", TextAlign = HorizontalAlignment.Right },
                            new ColumnHeader() { Width = 240, Text = "Original path", TextAlign = HorizontalAlignment.Left }
                        }
                    );

            // Deleted items is homed in the My Computer view
            ListViewItem backIcon = AddItemToListView(
                    "(..)", 
                    IMAGEKEY_PARENTCONTAINER, 
                    DIRECTORY_MYCOMPUTER, 
                        "Parent directory", 
                        string.Empty, 
                        string.Empty
                );
            backIcon.Group = _activeExplorer.Groups["Directories"];

            // Load items in recycle bin
            // Enumeration is via a COM32 call!
            foreach (RecyclebinItem item in Filesystem.GetFilesInRecycleBin())
            {
                string fileNameExtension = Path.GetExtension(item.FileName);

                string imageKey = (item.FileType.Equals("FILE FOLDER", StringComparison.InvariantCultureIgnoreCase) 
                                        ? ShellEnvironment.IMAGEKEY_FOLDER 
                                        : Icons.GetImageKey(item.FileName, viewImagesLarge, viewImagesSmall)
                                    );

                ListViewItem fileIcon = AddItemToListView(
                        item.FileName, 
                        imageKey, 
                        $"{item.FullyQualifiedRecyclebinPath};{item.OriginalPath}", 
                            Shell32.GetFileTypeName(fileNameExtension, true),
                            item.Size,
                            item.DeletedAt,
                            item.OriginalPath
                    );
                fileIcon.Group = _activeExplorer.Groups[(IsFileExecutable(fileNameExtension) ? "lvgExecutables" : "lvgAllOtherFiles")];
            }

            if (_activeExplorer.Items.Count > 0)
            {
                // enable the DELETE toolbar and context items
                tsbEditDelete.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// Load list of printers
        /// </summary>
        private void LoadPrintersList()
        {
            // Columns for ListView
            _activeExplorer.Columns.AddRange(
                        new ColumnHeader[]
                        {
                            new ColumnHeader() { Width = 240, Text = "Name" },
                            new ColumnHeader() { Width = 240, Text = "Type" },
                            new ColumnHeader() { Width = 240, Text = "Status", TextAlign = HorizontalAlignment.Center }
                        }
                    );

            // This is a WMI call that will return at least one printer
            List<Printer> printers = ShellEnvironment.GetPrinters(true);

            // Icons for printers
            AddIconToImageLists("PRINTER", SystemIcons.GetStockIcon(StockIconId.Printer));
            AddIconToImageLists("FAX", SystemIcons.GetStockIcon(StockIconId.PrinterFax));
            AddIconToImageLists("NETPRINTER", SystemIcons.GetStockIcon(StockIconId.PrinterNet));

            foreach (Printer device in printers)
            {
                string imageKey, printerType;
                switch (device.Type)
                {
                    case Printer.PrinterTypesEnum.Fax:
                        imageKey = "FAX";
                        printerType = "Fax machine";
                        break;

                    case Printer.PrinterTypesEnum.Network:
                        imageKey = "NETPRINTER";
                        printerType = "Network printer";
                        break;

                    default:
                        imageKey = "PRINTER";
                        printerType = device.DriverName;
                        break;
                }

                AddItemToListView(device.Name, imageKey, device.Name, printerType, device.Status.GetEnumFriendlyName());
            }
        }

        /// <summary>
        /// Adds an item to the ListView
        /// </summary>
        /// <param name="text">Caption text</param>
        /// <param name="imageKey">ImageKey -- image should already have been added</param>
        /// <param name="objectFullPath">Full path to the object (to set up the Tag property)</param>
        /// <param name="otherColumnTextsInOrder">[Optional] Other subitems, in the correct order. Nulls and empty strings are allowed</param>
        /// <returns>The added item for further use by the caller</returns>
        private ListViewItem AddItemToListView(string text, string imageKey, string objectFullPath, params string?[]? otherColumnTextsInOrder)
        {
            ListViewItem icon = new()
            {
                Text = text,
                ImageKey = imageKey,
                Tag = objectFullPath
            };

            if ((otherColumnTextsInOrder != null) && (otherColumnTextsInOrder.Length > 0))
            {
                foreach(string? item in otherColumnTextsInOrder)
                {
                    icon.SubItems.Add(item);
                }
            }
            
            _activeExplorer.Items.Add(icon);
            return icon;
        }

        /// <summary>
        /// Modify the toolbar, removing or adding items that make sense for the current view
        /// </summary>
        private void ResetToolbarAndContextMenu()
        {
            // flip our flag so that it is more readable :-)
            string currentTabDirectory = GetCurrentDirectoryForTab(_activeTab);
            bool editActionsEnabled = !_editActionsOnListViewItemsIsDisabled;
            bool isRecycleBinFolder = (currentTabDirectory == PATHKEY_RECYCLEBIN);

            tsDDBNew.Enabled = editActionsEnabled;
            tsbEditCopy.Enabled = editActionsEnabled;
            tsbEditCut.Enabled = editActionsEnabled;
            tsbEditDelete.Enabled = editActionsEnabled;
            tsbEditPaste.Enabled = editActionsEnabled;

            copyToolStripMenuItem.Enabled = editActionsEnabled;
            cutToolStripMenuItem.Enabled = editActionsEnabled;
            deleteToolStripMenuItem.Enabled = editActionsEnabled;
            pasteToolStripMenuItem.Enabled = editActionsEnabled;

            // applicable everywhere except Recycle Bin
            tsbProperties.Enabled = (! isRecycleBinFolder);
            propertiesToolStripMenuItem.Enabled = (! isRecycleBinFolder);

            // only applicable for Recycle Bin
            tsbRecyclebinRestore.Enabled = isRecycleBinFolder;
            restoreToolStripMenuItem.Enabled = isRecycleBinFolder;
        }

        /// <summary>
        /// Add the given icon to both large and small imagelists
        /// </summary>
        /// <param name="key">Image key</param>
        /// <param name="icon">The icon image to add</param>
        private void AddIconToImageLists(string key, Icon icon)
        {
            viewImagesLarge.Images.Add(key, icon);
            viewImagesSmall.Images.Add(key, icon);
        }

        /// <summary>
        /// Gets the path that a listview item points to
        /// </summary>
        /// <param name="item">ListViewItem to decode</param>
        /// <returns>String path -- never null</returns>
        private string GetPathFromListViewItem(ListViewItem item)
            => (string)(item.Tag!);

        /// <summary>
        /// Returns if the given filename extension is a recognised executable type
        /// </summary>
        /// <param name="fileNameExtension">Filename extension to check</param>
        /// <returns>True if the file is believed to be an executable</returns>
        private bool IsFileExecutable(string fileNameExtension)
            => EXECUTABLEFILEEXTENSIONS.Contains(fileNameExtension.ToLowerInvariant());

        /// <summary>
        /// Navigate to the address in tbJumpAddress if it is a valid path
        /// </summary>
        private void ValidateAndNavigateToJumpAddress()
        {
            if (!string.IsNullOrWhiteSpace(tbJumpAddress.Text))
            {
                char[] iPN = Path.GetInvalidPathChars();
                foreach (char c in tbJumpAddress.Text)
                {
                    if (iPN.Contains(c))
                    {
                        MessageBox.Show($"The path entered '{tbJumpAddress.Text}' contains characters not allowed by the system.",
                            "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbJumpAddress.Focus();
                        return;
                    }
                }

                switch (tbJumpAddress.Text.ToUpper())
                {
                    case "COMPUTER":
                    case "MYCOMPUTER":
                    case "MY COMPUTER":
                        LoadCurrentDirectoryView(string.Empty);
                        break;

                    case "SETTINGS":
                    case "CONTROLPANEL":
                    case "CONTROL PANEL":
                    case "CONFIGURE":
                        //TODO: Open the Settings form!
                        break;

                    case "PRINTERS":
                    case "PRINT":
                        LoadCurrentDirectoryView(PATHKEY_PRINTERS);
                        break;

                    case "RECYCLEBIN":
                    case "RECYCLE BIN":
                    case "DELETED":
                    case "DELETEDITEMS":
                    case "DELETED ITEMS":
                        LoadCurrentDirectoryView(PATHKEY_RECYCLEBIN);
                        break;

                    default:
                        if (tbJumpAddress.Text.StartsWith("\\\\"))
                        {
                            //TODO: Network location (??)

                            MessageBox.Show($"The path entered '{tbJumpAddress.Text}' is a network location that is not currently supported by this Shell.",
                                "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbJumpAddress.Focus();
                        }
                        else if (Directory.Exists(tbJumpAddress.Text))
                        {
                            LoadCurrentDirectoryView(tbJumpAddress.Text);
                        }
                        else if (File.Exists(tbJumpAddress.Text))
                        {
                            Shell32.ExecuteOrLaunchTarget(tbJumpAddress.Text);
                        }
                        else
                        {
                            MessageBox.Show($"The path entered '{tbJumpAddress.Text}' does not match any known existing or secret locations on your system.",
                                "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbJumpAddress.Focus();
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Handle the Cut or Copy phase of a CCP flow
        /// </summary>
        private void HandleCutOrCopy(ClipboardActionTypesEnum action)
        {
            if (_activeExplorer.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select at least one item for this operation.", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StringCollection fileNamesList = new();
            Clipboard.Clear();
            foreach (ListViewItem item in _activeExplorer.SelectedItems)
            {
                fileNamesList.Add(GetPathFromListViewItem(item));
                if (action == ClipboardActionTypesEnum.Cut)
                {
                    item.ForeColor = SystemColors.InactiveCaptionText;
                }
            }
            Clipboard.SetFileDropList(fileNamesList);
            _clipboardCurrentAction = action;
        }

        /// <summary>
        /// Handle certain special key combinations
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // backspace
            if (keyData.HasFlag(Keys.Back))
            {
                // go up to the parent level. If we are at My PC, beep!
                string? jump = null;
                foreach(ListViewItem lv in _activeExplorer.Items)
                {
                    if (lv.Text == "(..)")
                    {
                        jump = GetPathFromListViewItem(lv);
                        break;
                    }
                }

                // dont look for string.Empty as My PC == Empty string!!!
                if (jump != null)
                {
                    LoadCurrentDirectoryView(jump);
                    return true;
                }

                SystemSounds.Exclamation.Play();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}