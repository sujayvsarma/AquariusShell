

namespace AquariusShell.ShellApps
{
    /// <summary>
    /// Constants for the form
    /// </summary>
    public partial class AccessControlBrowser
    {
        /// <summary>
        /// Image key for "Folder" icons
        /// </summary>
        const string IMAGEKEY_FOLDER = "_AQSHELL_FOLDER";

        /// <summary>
        /// Display name for unresolved account SIDs
        /// </summary>
        const string UNRESOLVED_ACCOUNT_NAME = "Reserved System Account";

        /// <summary>
        /// Type of object we are handling
        /// </summary>
        enum ObjectTypes
        {
            /// <summary>
            /// None or not applicable at this time
            /// </summary>
            None,

            /// <summary>
            /// Filesystem directory
            /// </summary>
            Directory,

            /// <summary>
            /// Filesystem file
            /// </summary>
            File
        }


        /// <summary>
        /// An item that can be added to a listbox
        /// </summary>
        /// <param name="Caption">The display caption</param>
        /// <param name="Value">The internal value of the item</param>
        public record ListItem(
                string Caption,
                object? Value
            );

    }
}