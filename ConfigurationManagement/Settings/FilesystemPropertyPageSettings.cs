using AquariusShell.ConfigurationManagement.Reflection;

namespace AquariusShell.ConfigurationManagement.Settings
{
    /// <summary>
    /// Settings to control the 
    /// </summary>
    [RegistryKeyName("FilesystemPropertyPageSettings")]
    internal class FilesystemPropertyPageSettings : IAquariusShellSettings
    {

        /// <summary>
        /// Allow directory or file to be deleted
        /// </summary>
        [RegistryValueName("AllowDelete")]
        public bool AllowDelete
        {
            get; set;

        } = true;

        /// <summary>
        /// Allow bypassing Deleted Items (recycle bin) to permanently delete (holding SHIFT). 
        /// When FALSE, items are always sent to Deleted Items
        /// </summary>
        [RegistryValueName("AllowBypassDeletedItems")]
        public bool AllowBypassDeletedItems
        {
            get; set;

        } = true;

        /// <summary>
        /// Allow directory or file to be copied
        /// </summary>
        [RegistryValueName("AllowCopy")]
        public bool AllowCopy
        {
            get; set;

        } = true;

        /// <summary>
        /// Allow unsafe files to be unblocked
        /// </summary>
        [RegistryValueName("AllowUnblockDownloadedFiles")]
        public bool AllowUnblockDownloadedFiles
        {
            get; set;

        } = true;

        /// <summary>
        /// Allow directory or file to be moved
        /// (only possible if Copy and Delete are allowed)
        /// </summary>
        public bool AllowMove
            => AllowCopy && AllowDelete;

        /// <summary>
        /// Allow changing directory and file attributes
        /// </summary>
        [RegistryValueName("AllowChangeAttributes")]
        public bool AllowChangeAttributes
        {
            get; set;

        } = true;

        /// <summary>
        /// Allow the user to turn file/directory compression ON/OFF 
        /// (AllowChangeAttributes must be TRUE as well)
        /// </summary>
        [RegistryValueName("AllowChangeCompressionSettings")]
        public bool AllowChangeCompressionSettings
        {
            get; set;

        } = true;

        /// <summary>
        /// Allow the user to format all drives
        /// </summary>
        [RegistryValueName("AllowFormatAnyDrive")]
        public bool AllowFormatAnyDrive
        {
            get; set;

        } = false;

        /// <summary>
        /// Allow the user to format removable (USB) drives
        /// </summary>
        [RegistryValueName("AllowFormatRemovableDrives")]
        public bool AllowFormatRemovableDrives
        {
            get; set;

        } = true;

        /// <summary>
        /// Allow the user to rename a disk, directory or file
        /// </summary>
        [RegistryValueName("AllowRename")]
        public bool AllowRename
        {
            get; set;

        } = false;

        /// <summary>
        /// Allow the user to take a disk offline
        /// </summary>
        [RegistryValueName("AllowTakeDiskOffline")]
        public bool AllowTakeDiskOffline
        {
            get; set;

        } = false;

        /// <summary>
        /// Allow the user to change bitlocker settings
        /// </summary>
        [RegistryValueName("AllowChangeBitlockerSettings")]
        public bool AllowChangeBitlocker
        {
            get; set;

        } = false;
    }
}
