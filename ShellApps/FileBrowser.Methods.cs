using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
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
            if (newDirectory != null)
            {
                _currentDirectory = newDirectory;
            }

            lvFileSystemView.Items.Clear();
            lvFileSystemView.Groups.Clear();
            lvFileSystemView.Columns.Clear();

            viewImagesLarge.Images.Clear();
            viewImagesSmall.Images.Clear();

            AddIconToImageLists(IMAGEKEY_FOLDER, SystemIcons.GetStockIcon(StockIconId.Folder));
            AddIconToImageLists(IMAGEKEY_PARENTCONTAINER, SystemIcons.GetStockIcon(StockIconId.FolderOpen));

            if (_currentDirectory == DIRECTORY_MYCOMPUTER)
            {
                _editActionsOnListViewItemsIsDisabled = true;
                _listingState = ListViewListingStatesEnum.SpecialFolder;
                ResetToolbarAndContextMenu();
                LoadMyComputerView();

                tbJumpAddress.Text = "Computer";
            }
            else if (_currentDirectory == PATHKEY_PRINTERS)
            {
                _editActionsOnListViewItemsIsDisabled = true;
                _listingState = ListViewListingStatesEnum.SpecialFolder;
                ResetToolbarAndContextMenu();
                LoadPrintersList();

                tbJumpAddress.Text = "Printers";
            }
            else if (_currentDirectory == PATHKEY_RECYCLEBIN)
            {
                _editActionsOnListViewItemsIsDisabled = true;
                _listingState = ListViewListingStatesEnum.SpecialFolder;
                ResetToolbarAndContextMenu();
                LoadRecycleBinView();

                tbJumpAddress.Text = "Deleted items";
            }
            else
            {
                _editActionsOnListViewItemsIsDisabled = false;
                if (_currentDirectory.StartsWith(Environment.GetFolderPath(Environment.SpecialFolder.Windows))
                        || _currentDirectory.StartsWith(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles))
                        || _currentDirectory.StartsWith(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86))
                        || _currentDirectory.StartsWith(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles))
                        || _currentDirectory.StartsWith(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86)))
                {
                    // Protect system directories
                    _editActionsOnListViewItemsIsDisabled = true;
                }

                _listingState = ListViewListingStatesEnum.FileSystemDirectory;
                ResetToolbarAndContextMenu();
                LoadFilesystemDirectory();

                tbJumpAddress.Text = _currentDirectory;
            }
        }

        /// <summary>
        /// Load the My Computer view
        /// </summary>
        private void LoadMyComputerView()
        {
            // Adds all the "Drive" icons
            foreach (StockIconId iconId in Enum.GetValues<StockIconId>())
            {
                string id = iconId.ToString();
                if (id.StartsWith("Drive") || id.EndsWith("Drive"))
                {
                    AddIconToImageLists(id, SystemIcons.GetStockIcon(iconId));
                }
            }

            AddIconToImageLists(IMAGEKEY_RECYCLEBIN, SystemIcons.GetStockIcon(StockIconId.Recycler));
            AddIconToImageLists(IMAGEKEY_PRINTERS, SystemIcons.GetStockIcon(StockIconId.Printer));            

            lvFileSystemView.Groups.AddRange(
                    new ListViewGroup[]
                    {
                        new ListViewGroup("Drives") { Name = "lvgDrives", CollapsedState = ListViewGroupCollapsedState.Expanded },
                        new ListViewGroup("Printers and Supported Device Groups") { Name = "lvgDevices", CollapsedState = ListViewGroupCollapsedState.Expanded },
                        new ListViewGroup("Windows System Objects") { Name = "lvgWinSys", CollapsedState = ListViewGroupCollapsedState.Expanded }
                    }
                );

            lvFileSystemView.Columns.AddRange(
                    new ColumnHeader[]
                    {
                        new ColumnHeader() { Width = 240, Text = "Volume label" },
                        new ColumnHeader() { Width = 42, Text = "Drive", TextAlign = HorizontalAlignment.Center },
                        new ColumnHeader() { Width = 120, Text = "Format" },
                        new ColumnHeader() { Width = 120, Text = "Total size" },
                        new ColumnHeader() { Width = 120, Text = "Free space" }
                    }
                );

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

                driveIcon.Group = lvFileSystemView.Groups["lvgDrives"];
            }

            ListViewItem recycleBin = AddItemToListView(
                    "Deleted Items",
                    IMAGEKEY_RECYCLEBIN,
                    PATHKEY_RECYCLEBIN
                );
            recycleBin.Group = lvFileSystemView.Groups["lvgWinSys"];

            ListViewItem printers = AddItemToListView(
                    "Installed printers",
                    IMAGEKEY_PRINTERS,
                    PATHKEY_PRINTERS
                );
            printers.Group = lvFileSystemView.Groups["lvgDevices"];
        }

        /// <summary>
        /// Loads a regular filesystem directory into the view
        /// </summary>
        private void LoadFilesystemDirectory()
        {
            if (_listingState == ListViewListingStatesEnum.FileSystemDirectory)
            {
                lvFileSystemView.Groups.AddRange(
                    new ListViewGroup[]
                    {
                        new ListViewGroup("Directories") { Name = "lvgDirectories", CollapsedState = ListViewGroupCollapsedState.Expanded },
                        new ListViewGroup("Executable programs") { Name = "lvgExecutables", CollapsedState = ListViewGroupCollapsedState.Expanded },
                        new ListViewGroup("All other files") { Name = "lvgAllOtherFiles", CollapsedState = ListViewGroupCollapsedState.Expanded }
                    }
                );

                lvFileSystemView.Columns.AddRange(
                        new ColumnHeader[]
                        {
                            new ColumnHeader() { Width = 240, Text = "Name" },
                            new ColumnHeader() { Width = 42, Text = "Sync", TextAlign = HorizontalAlignment.Center },
                            new ColumnHeader() { Width = 180, Text = "Type" },
                            new ColumnHeader() { Width = 120, Text = "Size", TextAlign = HorizontalAlignment.Right },
                            new ColumnHeader() { Width = 180, Text = "Last modified", TextAlign = HorizontalAlignment.Right }
                        }
                    );
            }

            DirectoryInfo? diParent = (new DirectoryInfo(_currentDirectory)).Parent;
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
                backIcon.Group = lvFileSystemView.Groups["Directories"];
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
                backIcon.Group = lvFileSystemView.Groups["Directories"];
            }

            foreach (string directoryPath in Directory.GetDirectories(_currentDirectory, "*.*", SearchOption.TopDirectoryOnly))
            {
                DirectoryInfo di = new(directoryPath);

                // Do we need to hide Hidden/System or empty folders?
                if ((di.Attributes.HasFlag(FileAttributes.Hidden) && (!_displayFlags.HasFlag(FileBrowserItemDisplayFlags.ShowHiddenItems))) 
                    || (di.Attributes.HasFlag(FileAttributes.System) && (!_displayFlags.HasFlag(FileBrowserItemDisplayFlags.ShowSystemItems)))
                    || ((!Directory.EnumerateFileSystemEntries(directoryPath).Any()) && _displayFlags.HasFlag(FileBrowserItemDisplayFlags.HideEmptyFolders)))
                {
                    continue;
                }

                ListViewItem folderIcon = AddItemToListView(
                        di.Name,
                        IMAGEKEY_FOLDER,
                        di.FullName,
                            string.Empty,
                            "Directory",
                            string.Empty,
                            ((di.LastAccessTime > di.LastWriteTime) ? di.LastWriteTime : di.LastWriteTime).ToString("MMM dd, yyyy HH:mm:ss")
                    );
                folderIcon.Group = lvFileSystemView.Groups["Directories"];
            }

            foreach (string filePath in Directory.GetFiles(_currentDirectory, "*.*", SearchOption.TopDirectoryOnly))
            {
                FileInfo fi = new(filePath);

                // Do we need to hide Hidden/System or empty files?
                if ((fi.Attributes.HasFlag(FileAttributes.Hidden) && (!_displayFlags.HasFlag(FileBrowserItemDisplayFlags.ShowHiddenItems)))
                    || (fi.Attributes.HasFlag(FileAttributes.System) && (!_displayFlags.HasFlag(FileBrowserItemDisplayFlags.ShowSystemItems)))
                    || ((fi.Length == 0) && _displayFlags.HasFlag(FileBrowserItemDisplayFlags.HideZeroByteFiles)))
                {
                    continue;
                }

                string imageKey = Path.GetExtension(fi.FullName).ToUpperInvariant();
                if (imageKey == ".LNK")
                {
                    // each .lnk will have its own icon, based on its target
                    int linkItemsCount = 0;
                    foreach (string? s in viewImagesLarge.Images.Keys)
                    {
                        if ((!string.IsNullOrWhiteSpace(s)) && (s.EndsWith(".LNK")))
                        {
                            linkItemsCount++;
                        }
                    }

                    imageKey = $"{linkItemsCount}.LNK";
                }

                if (!viewImagesLarge.Images.ContainsKey(imageKey))
                {
                    Icon icon = Icons.ExtractAssociatedIcon(filePath);
                    AddIconToImageLists(imageKey, icon);
                }

                ListViewItem fileIcon = AddItemToListView(
                        fi.Name,
                        imageKey,
                        fi.FullName,
                            fi.Attributes.HasFlag(FileAttributes.Offline) ? "No" : "Yes",
                            Shell32.GetFileTypeName(fi.Extension, true),
                            fi.Length.FormatFileSize(),
                            ((fi.LastAccessTime > fi.LastWriteTime) ? fi.LastWriteTime : fi.LastWriteTime).ToString("MMM dd, yyyy HH:mm:ss")
                    );
                fileIcon.Group = lvFileSystemView.Groups[(IsFileExecutable(fi.Extension) ? "lvgExecutables" : "lvgAllOtherFiles")];
            }
        }

        /// <summary>
        /// Load the recycle bin view
        /// </summary>
        private void LoadRecycleBinView()
        {
            lvFileSystemView.Columns.AddRange(
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
            backIcon.Group = lvFileSystemView.Groups["Directories"];

            foreach (RecyclebinItem item in Filesystem.GetFilesInRecycleBin())
            {
                string fileNameExtension = Path.GetExtension(item.FileName);
                string imageKey = (item.FileType.Equals("FILE FOLDER", StringComparison.InvariantCultureIgnoreCase) ? IMAGEKEY_FOLDER : fileNameExtension.ToUpperInvariant());
                if (imageKey == ".LNK")
                {
                    // each .lnk will have its own icon, based on its target
                    int linkItemsCount = 0;
                    foreach (string? s in viewImagesLarge.Images.Keys)
                    {
                        if ((!string.IsNullOrWhiteSpace(s)) && (s.EndsWith(".LNK")))
                        {
                            linkItemsCount++;
                        }
                    }

                    imageKey = $"{linkItemsCount}.LNK";
                }

                if (!viewImagesLarge.Images.ContainsKey(imageKey))
                {
                    Icon icon = Icons.ExtractAssociatedIcon(item.FileName);
                    AddIconToImageLists(imageKey, icon);
                }

                ListViewItem fileIcon = AddItemToListView(
                        item.FileName, 
                        imageKey, 
                        $"{item.FullyQualifiedRecyclebinPath};{item.OriginalPath}", 
                            Shell32.GetFileTypeName(fileNameExtension, true),
                            item.Size,
                            item.DeletedAt,
                            item.OriginalPath
                    );
                fileIcon.Group = lvFileSystemView.Groups[(IsFileExecutable(fileNameExtension) ? "lvgExecutables" : "lvgAllOtherFiles")];
            }
        }

        /// <summary>
        /// Load list of printers
        /// </summary>
        private void LoadPrintersList()
        {
            lvFileSystemView.Columns.AddRange(
                        new ColumnHeader[]
                        {
                            new ColumnHeader() { Width = 240, Text = "Name" },
                            new ColumnHeader() { Width = 240, Text = "Type" },
                            new ColumnHeader() { Width = 240, Text = "Status", TextAlign = HorizontalAlignment.Center }
                        }
                    );

            List<Printer> printers = ShellEnvironment.GetPrinters(true);

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
            
            lvFileSystemView.Items.Add(icon);
            return icon;
        }

        /// <summary>
        /// Modify the toolbar, removing or adding items that make sense for the current view
        /// </summary>
        private void ResetToolbarAndContextMenu()
        {
            bool editActionsEnabled = !_editActionsOnListViewItemsIsDisabled;
            bool isRecycleBinFolder = (_currentDirectory == PATHKEY_RECYCLEBIN);

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
            if (lvFileSystemView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select at least one item for this operation.", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StringCollection fileNamesList = new();
            Clipboard.Clear();
            foreach (ListViewItem item in lvFileSystemView.SelectedItems)
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

    }
}