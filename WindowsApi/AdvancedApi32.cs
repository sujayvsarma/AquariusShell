using System.Runtime.InteropServices;

namespace AquariusShell.WindowsApi
{
    /// <summary>
    /// Calls from advapi32.dll
    /// </summary>
    public static class AdvancedApi32
    {
        /// <summary>
        /// Open the process token to examine for attributes
        /// </summary>
        /// <param name="ProcessHandle">Process handle</param>
        /// <param name="DesiredAccess">The access level desired</param>
        /// <param name="TokenHandle">[out] The token for the process</param>
        /// <returns>Result code</returns>
        [DllImport("advapi32.dll")]
        public static extern int OpenProcessToken(IntPtr ProcessHandle, int DesiredAccess, out IntPtr TokenHandle);

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
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AdjustTokenPrivileges(IntPtr TokenHandle, [MarshalAs(UnmanagedType.Bool)] bool DisableAllPrivileges, ref TOKEN_PRIVILEGES NewState, UInt32 BufferLength, IntPtr PreviousState, IntPtr ReturnLength);

        /// <summary>
        /// Look up the value of the privilege for by its name
        /// </summary>
        /// <param name="lpSystemName">Name of the (sub)system</param>
        /// <param name="lpName">Name of the privilege</param>
        /// <param name="lpLuid">[out] The value of the privilege required</param>
        /// <returns>Result code</returns>
        [DllImport("advapi32.dll")]
        public static extern int LookupPrivilegeValue(string lpSystemName, string lpName, out LUID lpLuid);
    }
}