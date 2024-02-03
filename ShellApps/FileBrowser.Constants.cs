
namespace AquariusShell.ShellApps
{
    /// <summary>
    /// Hold all the constants, enums, etc
    /// </summary>
    partial class FileBrowser
    {
        /// <summary>
        /// Filename extensions for executables
        /// </summary>
        readonly string[] EXECUTABLEFILEEXTENSIONS = new string[]
        {
            ".bat", ".cmd", ".ps1",
            ".exe"
        };

        /// <summary>
        /// Image key for "Folder" icons
        /// </summary>
        const string IMAGEKEY_FOLDER = "_AQSHELL_FOLDER";

        /// <summary>
        /// Image key for the item that shows an "up to parent"
        /// </summary>
        const string IMAGEKEY_PARENTCONTAINER = "_AQSHELL_PARENT";

        /// <summary>
        /// Image key for recycle bin
        /// </summary>
        const string IMAGEKEY_RECYCLEBIN = "_AQSHELL_RECYCLEBIN";
        const string PATHKEY_RECYCLEBIN = "recyclebin:";

        /// <summary>
        /// Image key for printers
        /// </summary>
        const string IMAGEKEY_PRINTERS = "_AQSHELL_PRINTERS";
        const string PATHKEY_PRINTERS = "print:";

        /// <summary>
        /// Type of action from clipboard
        /// </summary>
        private enum ClipboardActionTypesEnum
        {
            /// <summary>
            /// No action
            /// </summary>
            None = 0,

            /// <summary>
            /// Copy
            /// </summary>
            Copy,

            /// <summary>
            /// Cut
            /// </summary>
            Cut
        }


        /// <summary>
        /// What is the listview listing currently?
        /// </summary>
        private enum ListViewListingStatesEnum
        {
            /// <summary>
            /// A special folder (My Computer, Printers, etc)
            /// </summary>
            SpecialFolder = 0,

            /// <summary>
            /// A regular directory
            /// </summary>
            FileSystemDirectory
        }
    }
}