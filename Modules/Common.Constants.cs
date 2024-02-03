

namespace AquariusShell.Modules
{

    /// <summary>
    /// Sizes of icons
    /// </summary>
    public enum IconSizesEnum : int
    {
        /// <summary>
        /// 16x16
        /// </summary>
        x16 = 16,

        /// <summary>
        /// 24x24
        /// </summary>
        x24 = 24,

        /// <summary>
        /// 32x32
        /// </summary>
        x32 = 32,

        /// <summary>
        /// 64x64
        /// </summary>
        x64 = 64
    }

    /// <summary>
    /// Actions related to Windows termination
    /// </summary>
    public enum WindowsShutdownActions
    {
        /// <summary>
        /// Exit Aquarius Shell, to a blank/black screen!
        /// </summary>
        SimpleExit = 0,

        /// <summary>
        /// Exit Aquarius Shell and start Explorer with Explorer as the shell
        /// </summary>
        SwitchToExplorer,

        /// <summary>
        /// Log off
        /// </summary>
        LogOff,

        /// <summary>
        /// Reboot windows
        /// </summary>
        Reboot,

        /// <summary>
        /// Shutdown windows
        /// </summary>
        Shutdown
    }

    /// <summary>
    /// Method to check flags
    /// </summary>
    internal enum FlagCheckMethodEnum
    {
        /// <summary>
        /// A single flag needs to match
        /// </summary>
        AnyOf = 0,

        /// <summary>
        /// All flags must match
        /// </summary>
        AllOf = 1
    }
}

