namespace AquariusShell.WindowsApi
{
    /// <summary>
    /// Various constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Name of the shutdown privilege
        /// </summary>
        public const string PRIVILEGE_NAME_SHUTDOWNWINDOWS = "SeShutdownPrivilege";

        /// <summary>
        /// Flag to enable the provided/required privilege
        /// </summary>
        public const short SE_PRIVILEGE_ENABLED = 2;

        /// <summary>
        /// Flag to demand adjustment of token's privileges
        /// </summary>
        public const short TOKEN_ADJUST_PRIVILEGES = 32;

        /// <summary>
        /// Flag to indicate we are querying the current state/value of a privilege
        /// </summary>
        public const short TOKEN_QUERY = 8;

        /// <summary>
        /// Log off the current user
        /// </summary>
        public const ushort EWX_LOGOFF = 0;

        /// <summary>
        /// Shutdown Windows and power off the computer if supported
        /// </summary>
        public const ushort EWX_POWEROFF = 0x00000008;

        /// <summary>
        /// Reboot the computer
        /// </summary>
        public const ushort EWX_REBOOT = 0x00000002;

        /// <summary>
        /// Reboot the computer with restart of applications
        /// </summary>
        public const ushort EWX_RESTARTAPPS = 0x00000040;

        /// <summary>
        /// Shutdown Windows
        /// </summary>
        public const ushort EWX_SHUTDOWN = 0x00000001;

        /// <summary>
        /// Force the logoff/shutdown or reboot action
        /// </summary>
        public const ushort EWX_FORCE = 0x00000004;
    }

}