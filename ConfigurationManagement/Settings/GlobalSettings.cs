using AquariusShell.ConfigurationManagement.Constants;
using AquariusShell.ConfigurationManagement.Reflection;

namespace AquariusShell.ConfigurationManagement.Settings
{
    /// <summary>
    /// Settings for the shell itself
    /// </summary>
    [RegistryKeyName("Global")]
    internal class GlobalSettings : IAquariusShellSettings
    {

        /// <summary>
        /// The co-branded name for the shell
        /// </summary>
        [RegistryValueName("CobrandedName")]
        public string CobrandedName
        {
            get; set;

        } = "Aquarius Shell";

        /// <summary>
        /// The icon for the shell, must be absolute path to a .ICO file!
        /// </summary>
        [RegistryValueName("CobrandedIcon")]
        public string CobrandedIcon
        {
            get; set;

        } = string.Empty;

        /// <summary>
        /// The splash image that is displayed on startup. Must be absolute path to a valid .JPG/.PNG/.BMP file!
        /// </summary>
        [RegistryValueName("CobrandedSplashImage")]
        public string CobrandSplashImage
        {
            get; set;

        } = string.Empty;

        /// <summary>
        /// (Absolute Path) Directory for the Shell to store cached data/files etc
        /// </summary>
        [RegistryValueName("CacheDirectory")]
        public string CacheDirectory
        {
            get; set;

        } = string.Empty;

        /// <summary>
        /// Get/set whether logging is enabled
        /// </summary>
        [RegistryValueName("IsLoggingEnabled")]
        public bool IsLoggingEnabled
        {
            get; set;

        } = false;


        /// <summary>
        /// (Absolute Path) Directory for the Shell to store log files
        /// </summary>
        [RegistryValueName("LogDirectory")]
        public string LogDirectory
        {
            get; set;

        } = string.Empty;

        /// <summary>
        /// Timespan over which the log file would rollover
        /// </summary>
        [RegistryValueName("LogRolloverStrategy")]
        public LogFileRolloverStrategiesEnum LogRolloverStrategy
        {
            get; set;

        } = LogFileRolloverStrategiesEnum.Daily;

        /// <summary>
        /// If Strategy is by file size, then this sets the maximum size threshold. 
        /// This value is IGNORED for all other settings of the strategy.
        /// </summary>
        [RegistryValueName("LogFileMaximumSize")]
        public int LogFileMaximumSize
        {
            get; set;

        } = -1;

        /// <summary>
        /// Bitmask of events to log
        /// </summary>
        [RegistryValueName("Events")]
        public LogEventsEnumFlags Events
        {
            get; set;

        } = LogEventsEnumFlags.None;

        /// <summary>
        /// Enable multiple monitor support
        /// </summary>
        [RegistryValueName("EnableMultiMonitorSupport")]
        public bool EnableMultiMonitorSupport
        {
            get; set;

        } = false;

        /// <summary>
        /// Enable virtual desktop support
        /// </summary>
        [RegistryValueName("EnableVirtualDesktopSupport")]
        public bool EnableVirtualDesktopSupport
        {
            get; set;

        } = false;

    }


}
