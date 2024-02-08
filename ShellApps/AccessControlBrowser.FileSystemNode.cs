using System.IO;
using System.Windows.Forms;

namespace AquariusShell.ShellApps
{

    /// <summary>
    /// Implementation of the FilesystemNode subclass of TreeNode
    /// </summary>
    public partial class AccessControlBrowser
    {
        /// <summary>
        /// A treenode, representing an object on the local filesystem
        /// </summary>
        public class FileSystemNode : TreeNode
        {

            /// <summary>
            /// If set, is a fake node and should not be used externally
            /// </summary>
            public bool IsFake { get; private set; }

            /// <summary>
            /// If is a drive/folder/an object that can expand to show children
            /// </summary>
            public bool IsExpandable { get; private set; } = false;

            /// <summary>
            /// Returns if the children have already been expanded
            /// </summary>
            public bool IsAlreadyEnumerated
            {
                get
                {
                    if (IsExpandable && (Nodes.Count == 1) && ((FileSystemNode)Nodes[0]).IsFake)
                    {
                        return false;
                    }

                    return true;
                }
            }

            /// <summary>
            /// Absolute path to the item
            /// </summary>
            public string AbsolutePath { get; set; } = string.Empty;

            /// <summary>
            /// Initialise
            /// </summary>
            private FileSystemNode() : base() { }

            /// <summary>
            /// Initialise
            /// </summary>
            /// <param name="caption">Display caption</param>
            /// <param name="iconKey">ImageKey for the displayed icon (should already have been added to attached imagelist)</param>
            /// <param name="fullPath">Full path to the file/directory/etc</param>
            public FileSystemNode(string caption, string iconKey, string fullPath)
                : base(caption)
            {
                ImageKey = iconKey;
                SelectedImageKey = iconKey;
                AbsolutePath = fullPath;

                if (Directory.Exists(fullPath))
                {
                    IsExpandable = true;

                    Nodes.Add(new FileSystemNode()
                    {
                        IsFake = true
                    });
                }
            }
        }


    }


}