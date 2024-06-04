using System.Collections.Generic;

using AquariusShell.ConfigurationManagement.Reflection;
using AquariusShell.Objects;

namespace AquariusShell.ConfigurationManagement.Settings
{
    /// <summary>
    /// Settings governing the use of the "Control Panel"
    /// </summary>
    [RegistryKeyName("SettingsBrowser")]
    internal class SettingsBrowserSettings : IAquariusShellSettings
    {
        /// <summary>
        /// Show the Settings Browser applet
        /// </summary>
        [RegistryValueName("ShowSettingsBrowser")]
        public bool ShowOnLauncher
        {
            get; set;

        } = false;

        /// <summary>
        /// Only if ShowOnLauncher is TRUE. Customization of the ShellApp icon on the launcher.
        /// </summary>
        [RegistryValueName("CustomButton")]
        public CustomButtonSettings CustomButton
        {
            get; set;

        } = new();

        /// <summary>
        /// Disabled Windows Control Panel applets
        /// </summary>
        [RegistryValueName("DisabledWin32Applets")]
        public List<NameValuePair<string>> DisabledWin32Applets
        {
            get; set;

        } = new();

        /// <summary>
        /// When set to TRUE, applets disabled in DisabledWin32Applets can be executed when a password 
        /// is provided. The unlock password is stored "elsewhere" for security reasons.
        /// </summary>
        [RegistryValueName("AllowDisabledAppletsExecutionWithPassword")]
        public bool AllowDisabledAppletsExecutionWithPassword
        {
            get; set;

        } = false;

        /// <summary>
        /// Require a password to operate the Settings Browser itself. 
        /// The unlock password is stored "elsewhere" for security reasons.
        /// </summary>
        [RegistryValueName("RequirePassword")]
        public bool RequirePassword
        {
            get; set;

        } = false;
    }
}
