using System.Collections.Generic;

using AquariusShell.ConfigurationManagement.Reflection;

namespace AquariusShell.ConfigurationManagement.Settings
{
    /// <summary>
    /// Settings for the Run dialog
    /// </summary>
    [RegistryKeyName("ShellApps\\RunDialog")]
    internal class RunDialogSettings : IAquariusShellSettings
    {
        /// <summary>
        /// Show the app on the launcher
        /// </summary>
        [RegistryValueName("ShowOnLauncher")]
        public bool ShowOnLauncher
        {
            get; set;

        } = true;

        /// <summary>
        /// Only if ShowOnLauncher is TRUE. Customization of the ShellApp icon on the launcher.
        /// </summary>
        [RegistryValueName("CustomButton")]
        public CustomButtonSettings CustomButton
        {
            get; set;

        } = new();

        /// <summary>
        /// Show the previously run history (dropdown)
        /// </summary>
        [RegistryValueName("ShowPreviouslyRunItemsList")]
        public bool ShowPreviouslyRunItemsList
        {
            get; set;

        } = true;

        /// <summary>
        /// Maximum number of items to show in the previously run list. 
        /// Negative numbers mean "unlimited" or "everything"
        /// Zero means "nothing" (same as setting ShowPreviouslyRunItemsList to FALSE.
        /// </summary>
        [RegistryValueName("PreviouslyRunItemsListMaximumCount")]
        public int PreviouslyRunItemsListMaximumCount
        {
            get; set;

        } = -1;

        /// <summary>
        /// Any URI matching one of the (RegEx) patterns in this list will not be 
        /// stored in the Run History. These may be absolute paths or RegEx patterns.
        /// </summary>
        [RegistryValueName("DoNotStoreURI")]
        public List<string> DoNotStoreURI
        {
            get; set;

        } = new();

        /// <summary>
        /// The URI in this list are always ensured in the history list. Use it to show 
        /// commonly run items. These need to be actual absolute paths and NOT patterns!
        /// </summary>
        [RegistryValueName("AlwaysAppendedURI")]
        public List<string> AlwaysAppendedURI
        {
            get; set;

        } = new();

        /// <summary>
        /// If FALSE, the user can only pick from the MRU list and 
        /// cannot browse to or type their own.
        /// </summary>
        [RegistryValueName("AllowRunningNonMRI")]
        public bool AllowRunningNonMRI
        {
            get; set;

        } = true;

        /// <summary>
        /// Show the Browse button to browse to and select an item to run
        /// </summary>
        [RegistryValueName("AllowBrowse")]
        public bool AllowBrowse
        {
            get; set;

        } = true;
    }
}
