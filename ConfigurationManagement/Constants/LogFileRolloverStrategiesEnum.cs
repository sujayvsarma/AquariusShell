namespace AquariusShell.ConfigurationManagement.Constants
{
    /// <summary>
    /// Timespan over which the log file would rollover
    /// </summary>
    public enum LogFileRolloverStrategiesEnum
    {
        /// <summary>
        /// Every calendar day
        /// </summary>
        Daily = 0,

        /// <summary>
        /// On the first day of the month
        /// </summary>
        Monthly,

        /// <summary>
        /// When the file size exceeds the provided threshold
        /// </summary>
        FileSize
    }
}
