namespace AquariusShell.Modules
{
    /// <summary>
    /// Names of icons used in the File Browser module (things to do with disks, drives, folders, files, etc)
    /// </summary>
    public enum OobeFileBrowserObjectIconNamesEnum : uint
    {
        /// <summary>
        /// The computer itself
        /// </summary>
        Computer,

        /// <summary>
        /// The network accessible by this computer (network neighbourhood)
        /// </summary>
        NetworkNeighbourhood,

        /// <summary>
        /// Devices connected to this computer
        /// </summary>
        ConnectedDevices,

        /// <summary>
        /// Settings or control panel
        /// </summary>
        Settings,

        /// <summary>
        /// Administrative tools
        /// </summary>
        AdvancedAdministration,

        /// <summary>
        /// Recycle bin
        /// </summary>
        RecycleBin,

        /// <summary>
        /// Floppy drive
        /// </summary>
        FloppyDrive,

        /// <summary>
        /// Removeable drive of some nature (eg: USB, external)
        /// </summary>
        RemoveableDrive,

        /// <summary>
        /// Optical drive (CD, DVD, etc)
        /// </summary>
        OpticalDrive,

        /// <summary>
        /// Fixed drive (hard disk)
        /// </summary>
        FixedDrive,

        /// <summary>
        /// Remote drive (eg: OneDrive, Google Drive, etc)
        /// </summary>
        RemoteDrive,

        /// <summary>
        /// A folder that is empty and in "opened" state
        /// </summary>
        OpenedEmptyFolder,

        /// <summary>
        /// A folder that is empty and in "closed" state
        /// </summary>
        ClosedEmptyFolder,

        /// <summary>
        /// A folder that has stuff in it and in "opened" state
        /// </summary>
        OpenedFolderWithItems,

        /// <summary>
        /// A folder that has stuff in it and in "closed" state
        /// </summary>
        ClosedFolderWithItems,

        /// <summary>
        /// A file whose type is unknown to Windows
        /// </summary>
        FileOfUnknownType,

        /// <summary>
        /// A data/document file of a known type
        /// </summary>
        DocumentFileOfKnownType,

        /// <summary>
        /// An app or program executable
        /// </summary>
        ProgramFile,

        /// <summary>
        /// A configuration file (.ini, .reg, etc)
        /// </summary>
        ConfigurationFile,

        /// <summary>
        /// A file containing information about device installation (.inf)
        /// </summary>
        DeviceInstallationFile,

        /// <summary>
        /// A file that is explicitly named as "SETUP" or "INSTALL" and has an extension of .EXE, .CMD, .BAT, or .PS1
        /// </summary>
        SetupProgram
    }

}
