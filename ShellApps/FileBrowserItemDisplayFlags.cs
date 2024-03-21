using System;

namespace AquariusShell.ShellApps
{
    /// <summary>
    /// Flags that control how things get displayed
    /// </summary>
    [Flags]
    public enum FileBrowserItemDisplayFlags
    {
        /// <summary>
        /// No flags are set
        /// </summary>
        None = 0,

        /// <summary>
        /// Show items with the hidden attribute
        /// </summary>
        ShowHiddenItems = 0b0000_0001,

        /// <summary>
        /// Show items with the system attribute
        /// </summary>
        ShowSystemItems = 0b0000_0010,

#pragma warning disable CA1069  // Two enums having same values (this is on purpose!)

        /// <summary>
        /// Hide files with a 0-byte size
        /// </summary>
        HideZeroByteFiles = 0b0000_0100,

        /// <summary>
        /// Hide folders that have nothing in them 
        /// (folders with hidden files or nested empty folders will still be shown!)
        /// </summary>
        HideEmptyFolders = 0b0000_0100,

#pragma warning restore CA1069  // Two enums having same values

        /// <summary>
        /// Show all items including hidden, system and zero-size
        /// </summary>
        ShowAllItems = ShowHiddenItems | ShowSystemItems
    }

}