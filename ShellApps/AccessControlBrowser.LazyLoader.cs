using System;
using System.IO;
using System.Windows.Forms;

using AquariusShell.Modules;
using AquariusShell.Runtime;

namespace AquariusShell.ShellApps
{
    /// <summary>
    /// Lazyloading the tree browser
    /// </summary>
    public partial class AccessControlBrowser
    {

        /// <summary>
        /// Loads the initial set of objects on the treeview
        /// </summary>
        private void LazyLoadInitialiseTree()
        {
            // The path that we would expand to is the "My Documents" view, so calculate its path
            string userProfileDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string[] partsOfThePath = userProfileDocumentsPath.Split(Path.DirectorySeparatorChar, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            string userProfileDocumentsDrive = $"{partsOfThePath[0]}\\";

            // Disable tree events
            _disableTreeViewActivation = true;

            // Adds all the "Drive" icons
            Icons.LoadDriveIcons(ilFileSystemImages);

            // The first thing we do, is load all the drives
            FileSystemNode? userProfileDocumentsDriveNode = null;
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                string imageKey = Icons.GetImageKey(drive);
                FileSystemNode node;
                try
                {
                    node = AddItemToTreeView(
                            null,
                            $"{drive.VolumeLabel}{Environment.NewLine}({drive.Name})",
                            imageKey,
                            drive.Name
                        );
                }
                catch (IOException)
                {
                    node = AddItemToTreeView(
                            null,
                            $"(Not Formatted) {Environment.NewLine}({drive.Name})",
                            imageKey,
                            drive.Name
                        );
                }

                if (drive.Name.Equals(userProfileDocumentsDrive, StringComparison.InvariantCultureIgnoreCase))
                {
                    userProfileDocumentsDriveNode = node;
                }
            }

            if (userProfileDocumentsDriveNode == null)
            {
                MessageBox.Show($"A drive or root path by the name '{userProfileDocumentsDrive}' could not be found.", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Now recursively load the home path,
            // but also load the immediate children of the directories we pass through
            _hierarchy.AddFirst(userProfileDocumentsDriveNode);
            string pathString = userProfileDocumentsDrive;
            FileSystemNode parentNode = userProfileDocumentsDriveNode;
            for (int i = 1; i < partsOfThePath.Length; i++)
            {
                pathString = Path.Combine(pathString, partsOfThePath[i]);
                FileSystemNode? existingNode = null;
                foreach (TreeNode item in parentNode.Nodes)
                {
                    if ((item is FileSystemNode fsn) && fsn.AbsolutePath.Equals(pathString))
                    {
                        existingNode = fsn;
                        _hierarchy.AddLast(existingNode);

                        break;
                    }
                }

                if (Directory.Exists(pathString))
                {
                    if (existingNode == null)
                    {
                        // We dont hide any files/directories here
                        parentNode = AddItemToTreeView(
                            parentNode,
                            Path.GetFileName(pathString),
                            ShellEnvironment.IMAGEKEY_FOLDER,
                            pathString
                        );

                        _hierarchy.AddLast(parentNode);
                    }

                    LazyLoadDirectory(parentNode, pathString);
                }
                else
                {
                    if (existingNode == null)
                    {
                        // We dont hide any files/directories here
                        AddItemToTreeView(
                            parentNode,
                            Path.GetFileName(pathString),
                            Icons.GetImageKey(pathString, ilFileSystemImages),
                            pathString
                        );
                    }
                }
            }

            // Enable tree events
            _disableTreeViewActivation = false;

        }



        /// <summary>
        /// (BeforeExpand)
        /// Lazy load child items
        /// </summary>
        private void TreeViewFileSystem_LazyLoadChildren(object sender, TreeViewCancelEventArgs e)
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
                if ((e.Node != null) && (e.Node is FileSystemNode fsn) && fsn.IsExpandable && (fsn.Nodes[0] is FileSystemNode firstChild) && firstChild.IsFake)
                {
                    fsn.Nodes.Clear();

                    // We dont hide any files/directories here
                    if (Directory.Exists(fsn.AbsolutePath))
                    {
                        if (!LazyLoadDirectory(fsn, fsn.AbsolutePath))
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Recursively lazy load the given directory
        /// </summary>
        /// <param name="parentNode">The parent node to attach to. NULL for no parent</param>
        /// <param name="directory">Path to the directory we are loading in this function</param>
        private bool LazyLoadDirectory(FileSystemNode? parentNode, string directory)
        {
            try
            {
                foreach (string subDirectory in Directory.GetDirectories(directory, "*.*", SearchOption.TopDirectoryOnly))
                {
                    // We dont hide any files/directories here
                    AddItemToTreeView(
                            parentNode,
                            Path.GetFileName(subDirectory),
                            ShellEnvironment.IMAGEKEY_FOLDER,
                            subDirectory
                        );
                }

                foreach (string file in Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly))
                {
                    // We dont hide any files/directories here
                    AddItemToTreeView(
                            parentNode,
                            Path.GetFileName(file),
                            Icons.GetImageKey(file, ilFileSystemImages),
                            file
                        );
                }
            }
            catch (Exception dex)
            {
                MessageBox.Show("Error loading directory: " + dex.Message, "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}