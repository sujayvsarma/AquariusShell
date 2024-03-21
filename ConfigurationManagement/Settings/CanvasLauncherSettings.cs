using System.Collections.Generic;

using AquariusShell.ConfigurationManagement.Reflection;
using AquariusShell.Objects;

namespace AquariusShell.ConfigurationManagement.Settings
{
    /// <summary>
    /// Settings related to the Canvas-style programs launcher
    /// </summary>
    [RegistryKeyName("CanvasLauncher")]
    internal class CanvasLauncherSettings : IAquariusShellSettings
    {
        /// <summary>
        /// List of programs hidden from the launcher. This can be specific programs (incl. filenames) or 
        /// their parent [shortcut OR target] paths. RegEx patterns are accepted.
        /// </summary>
        [RegistryValueName("HiddenPrograms")]
        public List<NameValuePair<string>> HiddenPrograms
        {
            get; set;

        } = new();

        /// <summary>
        /// Programs protected by a password. Password is stored "elsewhere" for security reasons. If the user 
        /// attempts to launch one of these, they will be prompted for a password. This can be specific programs 
        /// (incl. filenames) or their parent [shortcut OR target] paths. RegEx patterns are accepted.
        /// </summary>
        [RegistryValueName("PasswordProtectedPrograms")]
        public List<NameValuePair<string>> PasswordProtectedPrograms
        {
            get; set;

        } = new();

        /// <summary>
        /// Show the field to search through the displayed programs
        /// </summary>
        [RegistryValueName("ShowSearchBox")]
        public bool ShowSearchBox
        {
            get; set;

        } = true;

    }
}
