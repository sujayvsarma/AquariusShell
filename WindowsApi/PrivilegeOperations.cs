using System.Diagnostics;

namespace AquariusShell.WindowsApi
{
    /// <summary>
    /// Wrapper class to work with privilege adjustments
    /// </summary>
    public static class PrivilegeOperations
    {
        /// <summary>
        /// Acquire the required privilege from the NTExec
        /// </summary>
        /// <param name="privilegeName">Name of privilege to demand/acquire</param>
        public static void GetRequiredPrivileges(string privilegeName)
        {
            IntPtr hToken;
            TOKEN_PRIVILEGES tkp;

            AdvancedApi32.OpenProcessToken(Process.GetCurrentProcess().Handle, Constants.TOKEN_ADJUST_PRIVILEGES | Constants.TOKEN_QUERY, out hToken);

            tkp.PrivilegeCount = 1;
            tkp.Privileges.Attributes = Constants.SE_PRIVILEGE_ENABLED;
            AdvancedApi32.LookupPrivilegeValue("", privilegeName, out tkp.Privileges.pLuid);

            AdvancedApi32.AdjustTokenPrivileges(hToken, false, ref tkp,0U, IntPtr.Zero, IntPtr.Zero);
        }
    }
}