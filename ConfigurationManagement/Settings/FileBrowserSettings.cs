using System.Collections.Generic;
using AquariusShell.ConfigurationManagement.Constants;
using AquariusShell.ConfigurationManagement.Reflection;

namespace AquariusShell.ConfigurationManagement.Settings
{
    /// <summary>
    /// Settings for the File Browser
    /// </summary>
    [RegistryKeyName("ShellApps\\FileBrowser")]
    internal class FileBrowserSettings : IAquariusShellSettings
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
        /// Show captions on the toolbar buttons
        /// </summary>
        [RegistryValueName("ShowToolbarCaptions")]
        public bool ShowToolbarCaptions
        {
            get; set;

        } = false;

        /// <summary>
        /// Allow the user to jump to a new location by changing its value in the "Go to" field. 
        /// When FALSE, the field is still shown but will be readonly.
        /// </summary>
        [RegistryValueName("AllowJumpToAddress")]
        public bool AllowJumpToAddress
        {
            get; set;

        } = true;

        /// <summary>
        /// Enable tabbed browsing
        /// </summary>
        [RegistryValueName("EnableTabbedBrowsing")]
        public bool EnableTabbedBrowsing
        {
            get; set;

        } = true;

        /// <summary>
        /// Flags of all buttons that are enabled for use
        /// </summary>
        [RegistryValueName("EnabledButtons")]
        public FileBrowserToolbarButtonsEnumFlags EnabledButtons
        {
            get; set;

        } = FileBrowserToolbarButtonsEnumFlags.All;

        /// <summary>
        /// List of folders to hide
        /// </summary>
        [RegistryValueName("HiddenFolders")]
        public List<string> HiddenFolders
        {
            get; set;

        } = new();

        /// <summary>
        /// Show the Deleted Items icon
        /// </summary>
        [RegistryValueName("ShowDeletedItems")]
        public bool ShowDeletedItems
        {
            get; set;

        } = true;

    }

}
