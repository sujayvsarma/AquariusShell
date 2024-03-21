using System;
using System.ComponentModel.DataAnnotations;

namespace AquariusShell.ConfigurationManagement.Constants
{
    /// <summary>
    /// Buttons on the File Browser app's toolbar
    /// </summary>
    [Flags]
    public enum FileBrowserToolbarButtonsEnumFlags : uint
    {
        /// <summary>
        /// None of the options
        /// </summary>
        [Display(Name = "None")]
        None = 0,

        /// <summary>
        /// Refresh button
        /// </summary>
        [Display(Name = "Refresh")]
        Refresh = 1,

        /// <summary>
        /// Home button
        /// </summary>
        [Display(Name = "Home")]
        Home = 2,

        /// <summary>
        /// Create New (dropdown) button
        /// </summary>
        [Display(Name = "Create new (folder or file)")]
        CreateNew = 4,

        /// <summary>
        /// Cut button
        /// </summary>
        [Display(Name = "Edit > Cut")]
        Cut = 8,

        /// <summary>
        /// Copy button
        /// </summary>
        [Display(Name = "Edit > Copy")]
        Copy = 16,

        /// <summary>
        /// Paste button
        /// </summary>
        [Display(Name = "Edit > Paste")]
        Paste = 32,

        /// <summary>
        /// Delete button
        /// </summary>
        [Display(Name = "Edit > Delete")]
        Delete = 64,

        /// <summary>
        /// Restore from Recyclebin button
        /// </summary>
        [Display(Name = "Restore from Deleted Items")]
        RestoreFromRecycleBin = 128,

        /// <summary>
        /// Change view mode (List, details...) button
        /// </summary>
        [Display(Name = "Change view mode (Large icon, small icon, detail view)")]
        ViewMode = 256,

        /// <summary>
        /// Show properties button
        /// </summary>
        [Display(Name = "Show item properties")]
        ShowProperties = 512,

        /// <summary>
        /// Close current tab button
        /// </summary>
        [Display(Name = "Close active tab (when using the tabbed browsing feature)")]
        CloseActiveTab = 1024,

        /// <summary>
        /// Open current tab in a new window button
        /// </summary>
        [Display(Name = "Open active tab in a new window (when using the tabbed browsing feature)")]
        OpenActiveTabInNewWindow = 2048,

        /// <summary>
        /// Open Command Prompt in current tab's location button
        /// </summary>
        [Display(Name = "Open Command Prompt in current directory")]
        OpenCommandPromptInActiveTabLocation = 4096,

        /// <summary>
        /// Both Refresh and Home buttons
        /// </summary>
        CombinedRefreshAndHome
            = Refresh | Home,

        /// <summary>
        /// All Edit actions (Cut, Copy, Paste and Delete)
        /// </summary>
        CombinedEditActions
            = Cut | Copy | Paste | Delete,

        /// <summary>
        /// All Recyclebin actions (Delete, Restore)
        /// </summary>
        CombinedRecycleBinActions
            = Delete | RestoreFromRecycleBin,

        /// <summary>
        /// All actions to do with current tab (Close, Open in New Window, Open Command Prompt)
        /// </summary>
        CombinedCurrentTabActions
            = CloseActiveTab | OpenActiveTabInNewWindow | OpenCommandPromptInActiveTabLocation,

        /// <summary>
        /// ALL the buttons
        /// </summary>
        All =
            CombinedRefreshAndHome | CombinedEditActions | RestoreFromRecycleBin | CombinedCurrentTabActions
    }

}
