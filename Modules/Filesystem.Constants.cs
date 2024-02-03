

namespace AquariusShell.Modules
{
    /// <summary>
    /// Constants for the Filesystem class
    /// </summary>
    internal static partial class Filesystem
    {
        /// <summary>
        /// Namespace of the Windows' Recycle Bin folder
        /// </summary>
        const int SHELL_NAMESPACE_RECYCLEBIN = 10;


        /// <summary>
        /// Names of columns in Recycle Bin
        /// </summary>
        public enum RecyclebinItemDetailColumnNames : int
        {
            /// <summary>
            /// Name of the file or folder
            /// </summary>
            FileName = 0,

            /// <summary>
            /// Original path (where it was deleted from)
            /// </summary>
            OriginalPath = 1,

            /// <summary>
            /// Date/time deleted at (this is a pre-formatted string!)
            /// </summary>
            DeletedAt = 2,

            /// <summary>
            /// Size of the file if it is a file, else we get a zero
            /// </summary>
            FileSize = 3,

            /// <summary>
            /// Pre-determined type of object ("folder" or type of file)
            /// </summary>
            TypeOfObjectWithFileType = 4,

            /// <summary>
            /// The recycle bin folder path. Eg: "C:\src\$RECYCLE.BIN\Recycle Bin"
            /// This will end with the text "Recycle Bin" which we would need to replace with our account SID
            /// </summary>
            RecyclebinFolder = 193,

            /// <summary>
            /// Fully qualified path within the Recycle Bin folder
            /// </summary>
            FullyQualifiedRecyclebinPath = 196

            // There are more constants possible, but above is all we find useful
        }
    }
}
