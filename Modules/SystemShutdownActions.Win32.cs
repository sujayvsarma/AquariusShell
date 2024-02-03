using System;
using System.Runtime.InteropServices;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Win32 API definitions to shutdown/reboot the system
    /// </summary>
    internal static partial class SystemShutdownActions
    {
        /// <summary>
        /// Logoff, shutdown or reboot Windows
        /// </summary>
        /// <param name="uFlags">Type of shutdown</param>
        /// <param name="dwReason">Reason for the shutdown if applicable</param>
        /// <returns>Result of operation</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        static extern int ExitWindowsEx(uint uFlags, uint dwReason);

        /// <summary>
        /// Open the process token to examine for attributes
        /// </summary>
        /// <param name="ProcessHandle">Process handle</param>
        /// <param name="DesiredAccess">The access level desired</param>
        /// <param name="TokenHandle">[out] The token for the process</param>
        /// <returns>Result code</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        static extern int OpenProcessToken(IntPtr ProcessHandle, int DesiredAccess, out IntPtr TokenHandle);

        /// <summary>
        /// Adjust privileges for the provided process token
        /// </summary>
        /// <param name="TokenHandle">Process token from OpenProcessToken()</param>
        /// <param name="DisableAllPrivileges">Set to disable all privileges</param>
        /// <param name="NewState">New state desired for the token</param>
        /// <param name="BufferLength">Length of the buffer provided for NewState</param>
        /// <param name="PreviousState">Pointer to previous state</param>
        /// <param name="ReturnLength">Length of the buffer returned</param>
        /// <returns>Result code</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AdjustTokenPrivileges(IntPtr TokenHandle, [MarshalAs(UnmanagedType.Bool)] bool DisableAllPrivileges, ref TOKEN_PRIVILEGES NewState, UInt32 BufferLength, IntPtr PreviousState, IntPtr ReturnLength);

        /// <summary>
        /// Look up the value of the privilege for by its name
        /// </summary>
        /// <param name="lpSystemName">Name of the (sub)system</param>
        /// <param name="lpName">Name of the privilege</param>
        /// <param name="lpLuid">[out] The value of the privilege required</param>
        /// <returns>Result code</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        static extern int LookupPrivilegeValue(string lpSystemName, string lpName, out LUID lpLuid);

        /// <summary>
        /// Flag to demand adjustment of token's privileges
        /// </summary>
        const short TOKEN_ADJUST_PRIVILEGES = 32;

        /// <summary>
        /// Flag to indicate we are querying the current state/value of a privilege
        /// </summary>
        const short TOKEN_QUERY = 8;

        /// <summary>
        /// Flag to enable the provided/required privilege
        /// </summary>
        const short SE_PRIVILEGE_ENABLED = 2;

        /// <summary>
        /// Name of the shutdown privilege
        /// </summary>
        const string PRIVILEGE_NAME_SHUTDOWNWINDOWS = "SeShutdownPrivilege";

        /// <summary>
        /// Log off the current user
        /// </summary>
        const ushort EWX_LOGOFF = 0;

        /// <summary>
        /// Shutdown Windows and power off the computer if supported
        /// </summary>
        const ushort EWX_POWEROFF = 0x00000008;

        /// <summary>
        /// Reboot the computer
        /// </summary>
        const ushort EWX_REBOOT = 0x00000002;

        /// <summary>
        /// Reboot the computer with restart of applications
        /// </summary>
        const ushort EWX_RESTARTAPPS = 0x00000040;

        /// <summary>
        /// Shutdown Windows
        /// </summary>
        const ushort EWX_SHUTDOWN = 0x00000001;

        /// <summary>
        /// Force the logoff/shutdown or reboot action
        /// </summary>
        const ushort EWX_FORCE = 0x00000004;

        /// <summary>
        /// LUID structure used with privilege operations
        /// </summary>
        public struct LUID
        {
            public int LowPart;
            public int HighPart;
        }

        /// <summary>
        /// LUID structure used with privilege operations
        /// </summary>
        public struct LUID_AND_ATTRIBUTES
        {
            public LUID pLuid;
            public int Attributes;
        }

        /// <summary>
        /// Privilege lookup/demand structure
        /// </summary>
        public struct TOKEN_PRIVILEGES
        {
            public int PrivilegeCount;
            public LUID_AND_ATTRIBUTES Privileges;
        }
    }

}
