using System.Collections.Generic;

using AquariusShell.ConfigurationManagement.Reflection;
using AquariusShell.Modules;

namespace AquariusShell.ConfigurationManagement.Settings
{
    /// <summary>
    /// Settings controlling the system shutdown actions
    /// </summary>
    [RegistryKeyName("ShellApps\\TerminateShell")]
    internal class TerminateShellSettings : IAquariusShellSettings
    {
        /// <summary>
        /// Allows the option to switch to Windows Explorer, either on next reboot or 
        /// as part of the Shell Exit
        /// </summary>
        [RegistryValueName("AllowSwitchToExplorer")]
        public bool AllowSwitchToExplorer
        {
            get; set;

        } = true;

        /// <summary>
        /// Allowed shutdown actions
        /// </summary>
        [RegistryKeyPair]
        public Dictionary<WindowsShutdownActions, bool> AllowedActions
        {
            get; set;

        } = new();
    }
}
