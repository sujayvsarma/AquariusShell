namespace AquariusShell.WindowsApi
{
    /// <summary>
    /// Perform various system/user shutdown actions
    /// </summary>
    public static class ShutdownActions
    {
        /// <summary>
        /// Shutdown Windows
        /// </summary>
        /// <param name="powerOff">If true, will poweroff after shutdown</param>
        /// <param name="force">If true, forces action</param>
        public static void Shutdown(bool powerOff = false, bool force = false)
        {
            PrivilegeOperations.GetRequiredPrivileges(Constants.PRIVILEGE_NAME_SHUTDOWNWINDOWS);
            User32.ExitWindowsEx(Constants.EWX_SHUTDOWN | (uint)(force ? Constants.EWX_FORCE : 0) | (uint)(powerOff ? Constants.EWX_POWEROFF : 0), 0);
        }

        /// <summary>
        /// Reboot the system
        /// </summary>
        /// <param name="force">If true, forces action</param>
        public static void Reboot(bool force = false)
        {
            PrivilegeOperations.GetRequiredPrivileges(Constants.PRIVILEGE_NAME_SHUTDOWNWINDOWS);
            User32.ExitWindowsEx(Constants.EWX_REBOOT | (uint)(force ? Constants.EWX_FORCE : 0), 0);
        }

        /// <summary>
        /// Logoff current user
        /// </summary>
        /// <param name="force">If true, forces action</param>
        public static void Logoff(bool force = false)
        {
            PrivilegeOperations.GetRequiredPrivileges(Constants.PRIVILEGE_NAME_SHUTDOWNWINDOWS);
            User32.ExitWindowsEx(Constants.EWX_LOGOFF | (uint)(force ? Constants.EWX_FORCE : 0), 0);
        }
    }
}