namespace AquariusShell.Modules
{
    /// <summary>
    /// Names of icons for various actions
    /// </summary>
    public enum OobeActionNamesEnum : uint
    {
        /// <summary>
        /// Create a new item
        /// </summary>
        New,

        /// <summary>
        /// Copy (clipboard)
        /// </summary>
        Copy,

        /// <summary>
        /// Cut (clipboard)
        /// </summary>
        Cut,

        /// <summary>
        /// Paste (clipboard)
        /// </summary>
        Paste,

        /// <summary>
        /// Delete item to recycle bin
        /// </summary>
        DeleteToRecycleBin,

        /// <summary>
        /// Delete item bypassing recycle bin or permanently
        /// </summary>
        DeletePermanently,

        /// <summary>
        /// Undo last operation
        /// </summary>
        Undo,

        /// <summary>
        /// Redo last operation
        /// </summary>
        Redo,

        /// <summary>
        /// Transfer an item to a new location using copy. 
        /// This is different from clipboard-copy which just "notes" the item
        /// </summary>
        TransferByCopy,

        /// <summary>
        /// Transfer an item to a new location using move.
        /// This is different from clipboard-cut which just "notes" the item
        /// </summary>
        TransferByMove,

        /// <summary>
        /// Show the information panel (Properties) about selected object(s)
        /// </summary>
        ShowInfoPanel,

        /// <summary>
        /// Configure the target (if possible, eg: a device)
        /// </summary>
        Configure,

        /// <summary>
        /// Attempt to print the target (if possible, only files!)
        /// </summary>
        Print,

        /// <summary>
        /// Attempt to install the target (typically if an INF or SETUP.EXE is selected)
        /// </summary>
        Install,

        /// <summary>
        /// Attempt to uninstall the target (if possible: devices, apps)
        /// </summary>
        Uninstall,

        /// <summary>
        /// Backup the device -- when connected to a remote drive folder
        /// </summary>
        Backup,

        /// <summary>
        /// See version history for a backed up item -- when connected to a remote drive folder
        /// </summary>
        SeeVersionHistory,

        /// <summary>
        /// Restore a particular version from backup -- when connected to a remote drive folder
        /// </summary>
        RestoreVersion,

        /// <summary>
        /// Refresh the view or item information
        /// </summary>
        Refresh
    }

}
