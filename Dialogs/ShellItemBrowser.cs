using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using AquariusShell.Modules;
using AquariusShell.Objects;
using AquariusShell.Runtime;

using Microsoft.WindowsAPICodePack.Shell;

namespace AquariusShell.Dialogs
{
    /// <summary>
    /// Shows a specialist browser dialog that lets the user browse the filesystem, installed apps and control panel applets. 
    /// This dialog is typically raised from the <see cref="Controls.ManageableShellItemsListbox"/> and never directly.
    /// </summary>
    public partial class ShellItemBrowser : Form
    {
        /// <summary>
        /// The items that were selected by the user
        /// </summary>
        public Dictionary<string, string> SelectedItems
        {
            get
            {
                Dictionary<string, string> result = new();
                foreach(ListViewItem item in lvActiveFolderItems.SelectedItems)
                {
                    result.Add(
                            item.Text,
                            (string)item.Tag!
                        );
                }
                return result;
            }
        }

        /// <summary>
        /// Initialise
        /// </summary>
        /// <param name="allowSelectingApps">Allow apps and programs to be selected</param>
        /// <param name="allowSelectingFilesystemItems">Allows drives, directories and files to be selected</param>
        /// <param name="allowSelectingControlPanelApplets">Allows selecting Control Panel applets</param>
        public ShellItemBrowser(bool allowSelectingApps, bool allowSelectingFilesystemItems, bool allowSelectingControlPanelApplets)
        {
            InitializeComponent();

            Icons.LoadDriveIcons(imgLstTreeView);
            imgLstTreeView.Images.Add(ShellEnvironment.IMAGEKEY_FOLDER, SystemIcons.GetStockIcon(StockIconId.Folder));
            imgLstTreeView.Images.Add("Application", SystemIcons.GetStockIcon(StockIconId.Application));

            // Load treeview
            _disableTreeViewActivation = true;

            if (allowSelectingApps)
            {
                // Apps
                FileSystemNode appsNode = AddItemToTreeView(
                        null,
                        "Installed Programs and Apps",
                        "Application",
                        AppsAndProgramsFolderId
                    );

                // Apps cannot be enumerated. So, remove the fake node
                appsNode.Nodes.Clear();
            }

            if (allowSelectingControlPanelApplets)
            {
                // Control Panel appslets
                FileSystemNode appletsNode = AddItemToTreeView(
                        null,
                        "Windows Settings",
                        "Application",
                        "shell:ControlPanel"
                    );

                // Applets cannot be enumerated. So remove the fake node
                appletsNode.Nodes.Clear();
            }

            if (allowSelectingFilesystemItems)
            {
                // Drives
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    string imageKey = Icons.GetImageKey(drive);
                    try
                    {
                        AddItemToTreeView(
                                null,
                                $"{drive.VolumeLabel}{Environment.NewLine}({drive.Name})",
                                imageKey,
                                drive.Name
                            );
                    }
                    catch (IOException)
                    {
                        AddItemToTreeView(
                                null,
                                $"(Not Formatted) {Environment.NewLine}({drive.Name})",
                                imageKey,
                                drive.Name
                            );
                    }
                }
            }

            _disableTreeViewActivation = false;
        }

        /// <summary>
        /// TreeView after-select - Show files/items in the listview
        /// </summary>
        private void tvShellItemsTree_ShowSubItemsInListViewOnItemClick(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
            {
                return;
            }

            this.SetFormBusyState(true);

            lvActiveFolderItems.Items.Clear();
            lvActiveFolderItems.Columns.Clear();

            imgLstListView.Images.Clear();
            imgLstListView.Images.Add("Application", SystemIcons.GetStockIcon(StockIconId.Application));
            imgLstListView.Images.Add(ShellEnvironment.IMAGEKEY_GENERICFILE, SystemIcons.GetStockIcon(StockIconId.DocumentNoAssociation));

            string location = ((FileSystemNode)e.Node).AbsolutePath;
            lvActiveFolderItems.BeginUpdate();
            switch (location)
            {
                case AppsAndProgramsFolderId:
                    lvActiveFolderItems.View = View.LargeIcon;
                    EnumerateShellFolder(AppsAndProgramsFolderGuid);
                    break;

                case "shell:ControlPanel":
                    lvActiveFolderItems.View = View.Details;
                    lvActiveFolderItems.Columns.Add("Control panel applets", (lvActiveFolderItems.Width - ShellEnvironment.FORM_CONTROLS_MARGIN_EXTENTS));
                    lvActiveFolderItems.HeaderStyle = ColumnHeaderStyle.Nonclickable;
                    EnumerateControlPanel();
                    break;

                default:
                    lvActiveFolderItems.View = View.LargeIcon;
                    EnumerateFileSystem(location);
                    break;
            }

            lvActiveFolderItems.EndUpdate();

            this.SetFormBusyState(false);
        }

        /// <summary>
        /// TreeView before-expand - LazyLoad children
        /// </summary>
        private void tvShellItemsTree_LazyLoadChildrenOnExpandAttempt(object sender, TreeViewCancelEventArgs e)
        {
            if (_disableTreeViewActivation)
            {
                return;
            }

            if (e.Action == TreeViewAction.Expand)
            {
                // If we have a node that's a FileSystemNode that's expandable (is a directory node)
                // and its first child is a fake node, then....
                // PS: We would have added fake nodes to all directories to enable the TV to show a "+". (See FileSystemNode..ctor)
                if ((e.Node != null) && (e.Node is FileSystemNode fsn) && (!fsn.IsAlreadyEnumerated))
                {
                    fsn.Nodes.Clear();

                    if (Directory.Exists(fsn.AbsolutePath))
                    {
                        try
                        {
                            foreach (string subDirectory in Directory.GetDirectories(fsn.AbsolutePath, "*.*", SearchOption.TopDirectoryOnly))
                            {
                                // We dont hide any directories here
                                AddItemToTreeView(
                                        fsn,
                                        Path.GetFileName(subDirectory),
                                        ShellEnvironment.IMAGEKEY_FOLDER,
                                        subDirectory
                                    );
                            }
                        }
                        catch (Exception dex)
                        {
                            MessageBox.Show("Error loading directory: " + dex.Message, "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Cancel clicked, return cancel status and close the dialog
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Accept clicked, return accept status and close the dialog
        /// </summary>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Enumerate files in the provided location
        /// </summary>
        /// <param name="location">Absolute path to enumerate files under</param>
        private void EnumerateFileSystem(string location)
        {
            try
            {
                foreach (string file in Directory.GetFiles(location, "*.*", SearchOption.TopDirectoryOnly))
                {
                    try
                    {
                        FileInfo fi = new(file);
                        string imageKey = ((fi.Attributes.HasFlag(FileAttributes.Offline) || ((int)fi.Attributes >= ShellEnvironment.FILEATTRIBUTE_NOTONDISK))
                                            ? Icons.GetGenericFileIcon(imgLstListView) : Icons.GetImageKey(fi.FullName, imgLstListView));

                        ListViewItem icon = new()
                        {
                            Text = Path.GetFileName(file),
                            ImageKey = imageKey,
                            Tag = file
                        };
                        lvActiveFolderItems.Items.Add(icon);
                    }
                    catch
                    {
                        // Eat and continue
                    }
                }
            }
            catch (Exception outerLoopEx)
            {
                MessageBox.Show(outerLoopEx.Message, "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Enumerate objects in the provided shell folder
        /// </summary>
        /// <param name="folderId">Well Known Guid of the Shell Folder</param>
        private void EnumerateShellFolder(Guid folderId)
        {
            try
            {
                ShellObject AppsAndProgramsFolderReference = (ShellObject)KnownFolderHelper.FromKnownFolderId(folderId);
                foreach (ShellObject file in (IKnownFolder)AppsAndProgramsFolderReference)
                {
                    try
                    {
                        string imageKey = imgLstListView.Images.Count.ToString();
                        ShellThumbnail? thumbnail = file.Thumbnail;

                        Icon icon = SystemIcons.Application;
                        if (thumbnail != null)
                        {
                            thumbnail.FormatOption = ShellThumbnailFormatOption.IconOnly;
                            Bitmap bmp = thumbnail.LargeBitmap;
                            bmp.MakeTransparent();

                            icon = Icon.FromHandle(bmp.GetHicon());
                        }

                        imgLstListView.Images.Add(imageKey, Icons.Resize(icon, ShellEnvironment.ConfiguredSizeOfIcons).ToBitmap());

                        ListViewItem item = new()
                        {
                            Text = file.Name,
                            ImageKey = imageKey,
                            Tag = file.ParsingName
                        };
                        lvActiveFolderItems.Items.Add(item);
                    }
                    catch
                    {
                        // eat and continue
                    }
                }
            }
            catch (Exception shellOuterEx)
            {
                MessageBox.Show(shellOuterEx.Message, "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Enumerate items in the control panel
        /// </summary>
        private void EnumerateControlPanel()
        {
            foreach (NameValuePair<string> item in AquariusShell.Modules.Constants.ALL_WINDOWS10_CONTROLPANEL_ITEMS)
            {
                ListViewItem lvi = new()
                {
                    Text = item.Text,
                    Tag = item.Value
                };
                lvActiveFolderItems.Items.Add(lvi);
            }
        }


        /// <summary>
        /// Adds an item to the treeview
        /// </summary>
        /// <param name="parent">The parent node in the treeview. If NULL, adds to root</param>
        /// <param name="text">Caption text</param>
        /// <param name="imageKey">ImageKey -- image should already have been added</param>
        /// <param name="pathOrIdentifier">Full path to the object (to set up the Tag property)</param>
        /// <returns>The added item for further use by the caller</returns>
        private FileSystemNode AddItemToTreeView(FileSystemNode? parent, string text, string imageKey, string pathOrIdentifier)
        {
            FileSystemNode item = new(text, imageKey, pathOrIdentifier);
            if (parent == null)
            {
                tvShellItemsTree.Nodes.Add(item);
            }
            else
            {
                if (!parent.IsAlreadyEnumerated)
                {
                    parent.Nodes.Clear();
                }
                parent.Nodes.Add(item);
            }

            return item;
        }


        private const string AppsAndProgramsFolderId = "1e87508d-89c2-42f0-8a7e-645a0f50ca58";

        private readonly bool _disableTreeViewActivation = true;
        private readonly Guid AppsAndProgramsFolderGuid = new(AppsAndProgramsFolderId);
    }
}
