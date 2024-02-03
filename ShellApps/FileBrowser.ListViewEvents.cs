using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using AquariusShell.Forms;
using AquariusShell.Modules;


namespace AquariusShell.ShellApps
{
    /// <summary>
    /// Only ListView events
    /// </summary>
    partial class FileBrowser
    {
        /// <summary>
        /// An item on the listview was double-clicked
        /// </summary>
        private void lvFileSystemView_ItemActivate(object sender, EventArgs e)
        {
            if (lvFileSystemView.SelectedItems.Count == 0)
            {
                return;
            }

            if (lvFileSystemView.SelectedItems.Count > 1)
            {
                MessageBox.Show("Please select only one item for this action.", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string path = GetPathFromListViewItem(lvFileSystemView.SelectedItems[0]);
            if ((_currentDirectory == PATHKEY_RECYCLEBIN) && (path != DIRECTORY_MYCOMPUTER))
            {
                // we cannot go into or launch things in recycle bin!
                // only action we allow is to .. out to the parent folder (My Computer)

                MessageBox.Show("You cannot do that here.", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (File.Exists(path))
            {
                Shell32.ExecuteOrLaunchTarget(path);
                return;
            }

            _historyList.Push(_currentDirectory);
            LoadCurrentDirectoryView(path);
        }

        /// <summary>
        /// Enter control dragging something
        /// </summary>
        private void lvFileSystemView_DragEnter(object sender, DragEventArgs e)
        {
            if ((!_editActionsOnListViewItemsIsDisabled) && (e.Data != null) && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // 32 is apparently keycode for ALT ??
                // ref: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.drageventargs.keystate?view=windowsdesktop-8.0 
                // (see the code sample)

                bool isCtrlKeyPressed = ((e.KeyState & 32) == 32);
                string[]? files = (string[]?)e.Data.GetData(DataFormats.FileDrop);
                if ((files != null) && (files.Length > 0))
                {
                    e.Effect = (isCtrlKeyPressed ? DragDropEffects.Copy : DragDropEffects.Move);
                    e.DropImageType = (isCtrlKeyPressed ? DropImageType.Copy : DropImageType.Move);
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Drop something onto the control
        /// </summary>
        private void lvFileSystemView_DragDrop(object sender, DragEventArgs e)
        {
            if ((!_editActionsOnListViewItemsIsDisabled) && (e.Data != null) && e.Data.GetDataPresent(DataFormats.FileDrop)
                && ((e.Effect == DragDropEffects.Copy) || (e.Effect == DragDropEffects.Move)))
            {
                string[]? files = (string[]?)e.Data.GetData(DataFormats.FileDrop);
                if ((files != null) && (files.Length > 0))
                {
                    FileOperationWithProgress doPasteOperation = new(_currentDirectory, files);
                    doPasteOperation.Show(this);
                    if (e.Effect == DragDropEffects.Move)
                    {
                        doPasteOperation.MoveSpecificFilesOrDirectories();
                    }
                    else
                    {
                        doPasteOperation.CopySpecificFilesOrDirectories();
                    }
                }
            }
        }

        /// <summary>
        /// Start dragging a ListViewITEM
        /// </summary>
        private void lvFileSystemView_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            if (_editActionsOnListViewItemsIsDisabled)
            {
                e.Action = DragAction.Cancel;
            }
        }

        /// <summary>
        /// Mouse button down - hide the context menu if shown
        /// </summary>
        private void lvFileSystemView_MouseDown(object sender, MouseEventArgs e)
        {
            if (cmsContextMenu.Visible)
            {
                cmsContextMenu.Hide();
            }
        }

        /// <summary>
        /// Mouse button up - show the context menu if required
        /// </summary>
        private void lvFileSystemView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem? item = lvFileSystemView.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    bool isAnyMenuItemEnabled = false;
                    foreach (ToolStripItem x in cmsContextMenu.Items)
                    {
                        if (x.Enabled)
                        {
                            isAnyMenuItemEnabled = true;
                            break;
                        }
                    }

                    if (isAnyMenuItemEnabled)
                    {
                        cmsContextMenu.Show(lvFileSystemView, new Point(e.X, e.Y), ToolStripDropDownDirection.BelowRight);
                    }
                }
            }
        }
    }
}