using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using AquariusShell.Forms;

namespace AquariusShell.ShellApps
{
    /// <summary>
    /// Toolbar and context menu events
    /// </summary>
    partial class FileBrowser
    {
        /// <summary>
        /// Show the My Computer view
        /// </summary>
        private void ToolstripButton_MyComputer_ClickEvent(object sender, EventArgs e)
        {
            if (_currentDirectory != DIRECTORY_MYCOMPUTER)
            {
                _historyList.Push(_currentDirectory);
            }
            LoadCurrentDirectoryView(DIRECTORY_MYCOMPUTER);
        }

        /// <summary>
        /// A drive item under My Computer was clicked
        /// </summary>
        private void ToolstripButton_DriveItem_ClickEvent(object? sender, EventArgs e)
        {
            _historyList.Push(_currentDirectory);
            LoadCurrentDirectoryView((string)(((ToolStripMenuItem)sender!).Tag!));
        }

        /// <summary>
        /// Create a new folder under the current folder
        /// </summary>
        private void ToolstripButton_CreateNewFolder_ClickEvent(object sender, EventArgs e)
        {
            PopupTextInput popupInput = new PopupTextInput()
            {
                Prompt = "Name of the folder"
            };

            if (popupInput.ShowDialog(this) == DialogResult.OK)
            {
                char[] iFN = Path.GetInvalidFileNameChars();
                foreach (char c in popupInput.Value)
                {
                    if (iFN.Contains(c))
                    {
                        MessageBox.Show($"The name entered '{popupInput.Value}' contains characters not allowed in file and directory names.",
                            "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                Directory.CreateDirectory(Path.Combine(_currentDirectory, popupInput.Value));
            }

            popupInput.Dispose();
            LoadCurrentDirectoryView();
        }

        /// <summary>
        /// Create a new file under the current folder
        /// </summary>
        private void ToolstripButton_CreateNewFile_ClickEvent(object sender, EventArgs e)
        {
            PopupTextInput popupInput = new PopupTextInput()
            {
                Prompt = "Name of the file with extension (eg: 'untitled.txt')"
            };

            if (popupInput.ShowDialog(this) == DialogResult.OK)
            {
                char[] iFN = Path.GetInvalidFileNameChars();
                foreach (char c in popupInput.Value)
                {
                    if (iFN.Contains(c))
                    {
                        MessageBox.Show($"The name entered '{popupInput.Value}' contains characters not allowed in file and directory names.",
                            "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // creates a 0-byte file
                using (FileStream fs = File.Create(Path.Combine(_currentDirectory, popupInput.Value)))
                {
                    fs.Flush();
                }
            }

            popupInput.Dispose();
            LoadCurrentDirectoryView();
        }

        /// <summary>
        /// ENTER pressed while in the jump address textbox, navigate there if it is a valid path
        /// </summary>
        private void JumpAddressTextbox_EnterKeyPressedEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidateAndNavigateToJumpAddress();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Clicked on the JUMP button, navigate to the path in the textbox if it is a valid path
        /// </summary>
        private void JumpAddressGoButton_ClickEvent(object sender, EventArgs e)
        {
            ValidateAndNavigateToJumpAddress();
        }

        /// <summary>
        /// CUT items
        /// </summary>
        private void ToolbarOrContextAction_CutItemsEvent(object sender, EventArgs e)
        {
            HandleCutOrCopy(ClipboardActionTypesEnum.Cut);
        }

        /// <summary>
        /// COPY items
        /// </summary>
        private void ToolbarOrContextAction_CopyItemsEvent(object sender, EventArgs e)
        {
            HandleCutOrCopy(ClipboardActionTypesEnum.Copy);
        }

        /// <summary>
        /// PASTE items
        /// </summary>
        private void ToolbarOrContextAction_PasteEvent(object sender, EventArgs e)
        {
            // Ensure:
            //  1. View is NOT readonly
            //  2. Listing is a regular filesystem directory (not a special folder!)
            //  3. We have something to paste
            //
            if ((!_editActionsOnListViewItemsIsDisabled) && (_listingState == ListViewListingStatesEnum.FileSystemDirectory) && Clipboard.ContainsFileDropList())
            {
                List<string> source = new();
                foreach (string? s in Clipboard.GetFileDropList())
                {
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        if (Directory.Exists(s) || File.Exists(s))
                        {
                            source.Add(s);
                        }
                    }
                }

                if (source.Count > 0)
                {
                    FileOperationWithProgress fileOperationWithProgress = new(_currentDirectory, source);
                    fileOperationWithProgress.Show(this);
                    switch (_clipboardCurrentAction)
                    {
                        case ClipboardActionTypesEnum.Copy:
                            fileOperationWithProgress.CopySpecificFilesOrDirectories();
                            break;

                        case ClipboardActionTypesEnum.Cut:
                            fileOperationWithProgress.MoveSpecificFilesOrDirectories();
                            break;
                    }

                    LoadCurrentDirectoryView();
                }
            }
        }

        /// <summary>
        /// DELETE items
        /// </summary>
        private void ToolbarOrContextAction_DeleteEvent(object sender, EventArgs e)
        {
            bool isPermanentDelete = Control.ModifierKeys.HasFlag(Keys.Shift);
            // Ensure:
            //  1. View is NOT readonly
            //  2. Listing is a regular filesystem directory (not a special folder!)
            //  3. We have something to delete
            //
            if ((!_editActionsOnListViewItemsIsDisabled) && (_listingState == ListViewListingStatesEnum.FileSystemDirectory) && (lvFileSystemView.SelectedItems.Count > 0))
            {
                List<string> source = new();
                foreach (ListViewItem item in lvFileSystemView.SelectedItems)
                {
                    source.Add(GetPathFromListViewItem(item));
                }

                if (source.Count > 0)
                {
                    FileOperationWithProgress fileOperationWithProgress = new(_currentDirectory, source);
                    fileOperationWithProgress.Show(this);
                    fileOperationWithProgress.DeleteSpecificFilesOrDirectories(isPermanentDelete);

                    LoadCurrentDirectoryView();
                }
            }
        }

        /// <summary>
        /// Show Properties box event
        /// </summary>
        private void ToolbarOrContextAction_ShowPropertiesBoxEvent(object sender, EventArgs e)
        {
            if (lvFileSystemView.SelectedItems.Count != 1)
            {
                MessageBox.Show("You must select exactly one item for this action.", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string path = GetPathFromListViewItem(lvFileSystemView.SelectedItems[0]);
            if ((path.Length != 3) && Directory.Exists(path))
            {
                // Directory's properties
                DirectoryEntryProperties dirProps = new(path);
                dirProps.ShowDialog(this);
                dirProps.Dispose();

                dirProps.DirectoryAffected += PropertiesBox_ExplorerLocationAffected;
            }
            else if (File.Exists(path))
            {
                // File's properties
                FileEntryProperties filProps = new(path);
                filProps.ShowDialog(this);
                filProps.Dispose();

                filProps.FileAffected += PropertiesBox_ExplorerLocationAffected;
            }
            else if (_currentDirectory == PATHKEY_PRINTERS)
            {
                // Printer properties
                try
                {
                    Modules.Printers.OpenPrinterSettingsDialog(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error showing printer properties: " + ex.Message, "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (_currentDirectory == DIRECTORY_MYCOMPUTER)
            {
                //  Drive's properties, but item could be non-drive (eg: Recycle bin itself or the "Printers" item)
                if ((path != PATHKEY_PRINTERS) && (path != PATHKEY_RECYCLEBIN))
                {
                    // a drive!
                    DriveInfo drive = DriveInfo.GetDrives().First(d => (d.Name == path));
                    
                    DriveProperties drvProps = new(drive);
                    drvProps.ShowDialog(this);
                    drvProps.Dispose();

                    drvProps.DriveAffected += PropertiesBox_ExplorerLocationAffected;
                }
            }
            else
            {
                // ???
            }
        }

        /// <summary>
        /// Event from a File/Directory/Drive properties box signalling that the Explorer view should refresh itself
        /// </summary>
        /// <param name="itemAffected">The particular item affected</param>
        private void PropertiesBox_ExplorerLocationAffected(string itemAffected)
        {
            LoadCurrentDirectoryView();
        }

        /// <summary>
        /// Refresh view event
        /// </summary>
        private void ToolbarOrContextAction_RefreshViewEvent(object sender, EventArgs e)
        {
            LoadCurrentDirectoryView();
        }

        /// <summary>
        /// Restore item(s) from Recycle Bin
        /// </summary>
        private void ToolbarOrContextAction_RestoreFromRecycleBinEvent(object sender, EventArgs e)
        {
            // Key is recyclebin path, Value is original path
            Dictionary<string, string> sourceDestinationPathMaps = new();

            if (lvFileSystemView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvFileSystemView.SelectedItems)
                {
                    string[] pair = ((string)(item.Tag!)).Split(';');
                    sourceDestinationPathMaps.Add(pair[0], pair[1]);
                }
            }
            else
            {
                // all items!
                foreach (ListViewItem item in lvFileSystemView.Items)
                {
                    string[] pair = ((string)(item.Tag!)).Split(';');
                    sourceDestinationPathMaps.Add(pair[0], pair[1]);
                }
            }

            foreach (string recycleBinItem in sourceDestinationPathMaps.Keys)
            {
                FileOperationWithProgress fowp = new(recycleBinItem, sourceDestinationPathMaps[recycleBinItem]);
                fowp.Show(this);

                //TODO: We need to write a specific method to handle recycle bin ??
                fowp.MoveSpecificFilesOrDirectories();
            }

            LoadCurrentDirectoryView();
        }

        /// <summary>
        /// Show large icon view
        /// </summary>
        private void largeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvFileSystemView.BeginUpdate();
            lvFileSystemView.View = View.LargeIcon;
            lvFileSystemView.EndUpdate();
        }

        /// <summary>
        /// Show small icons view
        /// </summary>
        private void smallIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvFileSystemView.BeginUpdate();
            lvFileSystemView.View = View.SmallIcon;
            lvFileSystemView.EndUpdate();
        }

        /// <summary>
        /// Show details view
        /// </summary>
        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvFileSystemView.BeginUpdate();
            lvFileSystemView.View = View.Details;
            lvFileSystemView.EndUpdate();
        }
    }
}