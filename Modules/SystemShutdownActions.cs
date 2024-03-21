using System;
using System.Diagnostics;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Various actions to shutdown/reboot the system
    /// </summary>
    internal static partial class SystemShutdownActions
    {
        /// <summary>
        /// Perform the action to shutdown/reboot the computer
        /// </summary>
        /// <param name="shutdownAction">Action to perform (only LogOff, Reboot and Shutdown make sense here!)</param>
        /// <param name="force">If set, forces the action</param>
        public static void PerformShutdownAction(WindowsShutdownActions shutdownAction, bool force)
        {
            if (shutdownAction == WindowsShutdownActions.Suspend)
            {
                Shell32.ExecuteRundll32Command("powrprof.dll,SetSuspendState");
                return;
            }

            if (shutdownAction == WindowsShutdownActions.Lock)
            {
                Shell32.ExecuteRundll32Command("user32.dll,LockWorkStation");
                return;
            }

            uint flags = shutdownAction switch
            {
                WindowsShutdownActions.LogOff => EWX_LOGOFF,
                WindowsShutdownActions.Reboot => EWX_REBOOT,
                WindowsShutdownActions.Shutdown => EWX_SHUTDOWN | EWX_POWEROFF
            };

            if (force)
            {
                flags |= EWX_FORCE;
            }


#pragma warning disable CA1806 // Do not ignore method results
            OpenProcessToken(Process.GetCurrentProcess().Handle, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, out nint hToken);

            TOKEN_PRIVILEGES tkp;
            tkp.PrivilegeCount = 1;
            tkp.Privileges.Attributes = SE_PRIVILEGE_ENABLED;

            LookupPrivilegeValue("", PRIVILEGE_NAME_SHUTDOWNWINDOWS, out tkp.Privileges.pLuid);

            AdjustTokenPrivileges(hToken, false, ref tkp, 0U, IntPtr.Zero, IntPtr.Zero);

            ExitWindowsEx(flags, 0);
#pragma warning restore CA1806 // Do not ignore method results
        }

    }
}
