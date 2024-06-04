using System;

using AquariusShell.ConfigurationManagement.Reflection;

namespace AquariusShell.ConfigurationManagement.Settings
{
    /// <summary>
    /// Settings to support multi-monitor systems
    /// </summary>
    [RegistryKeyName("WorkspaceArea\\MonitorSettings")]
    internal class MonitorSettings : IAquariusShellSettings
    {
        /// <summary>
        /// A unique identifier for the screen
        /// </summary>
        [RegistryValueName("ScreenId")]
        public Guid ScreenId { get; set; }

        /// <summary>
        /// The name of the screen by Windows (Screens.AllScreens[x].DevicName)
        /// </summary>
        [RegistryValueName("DeviceName")]
        public string DeviceName { get; set; } = string.Empty;

        /// <summary>
        /// We will only use those monitors that are enabled for our use
        /// </summary>
        [RegistryValueName("IsEnabled")]
        public bool IsEnabled { get; set; } = true;

    }
}
