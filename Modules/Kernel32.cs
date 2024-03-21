using System;
using System.IO;
using System.Management;
using System.Text;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Functions from the Kernel32.dll
    /// </summary>
    internal static partial class Kernel32
    {
        /// <summary>
        /// Get the executable file name that started the given process
        /// </summary>
        /// <param name="pid">PID of the process</param>
        /// <returns>Executable file name or NULL</returns>
        public static string? GetProcessFileName(int pid)
        {
            int exeNameCapacity = 2000;
            StringBuilder exeName = new(exeNameCapacity);
            IntPtr hProcess = OpenProcess(ProcessAccessFlags.QueryLimitedInformation, false, pid);
            if (hProcess != IntPtr.Zero)
            {
                if (QueryFullProcessImageName(hProcess, 0, exeName, ref exeNameCapacity))
                {
                    return exeName.ToString();
                }
            }

            return null;
        }

        /// <summary>
        /// Enables compression on a file or folder
        /// </summary>
        /// <param name="fullPathToTarget">Full path to the file or folder</param>
        public static void EnableCompressionOnFileOrFolder(string fullPathToTarget)
        {
            int bytesReturned = 0;
            short inBuffer = COMPRESSION_FORMAT_DEFAULT;

            try
            {
                if (Directory.Exists(fullPathToTarget))
                {
                    // WMI needs path \s escaped twice (instead of '\\', '\\\\')!
                    string directoryPath = "Win32_Directory.Name=" + "'" + fullPathToTarget.Replace("\\", @"\\").TrimEnd('\\') + "'";
                    using (ManagementObject mgmt = new(directoryPath))
                    {
                        mgmt.InvokeMethod("Compress", null, null);
                    }
                }
                else
                {
                    using (FileStream stream = File.Open(fullPathToTarget, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
#pragma warning disable CA1806 // Do not ignore method results
                        DeviceIoControl(stream.SafeFileHandle.DangerousGetHandle(), FSCTL_SET_COMPRESSION, ref inBuffer, sizeof(short), IntPtr.Zero, 0, ref bytesReturned, IntPtr.Zero);
#pragma warning restore CA1806 // Do not ignore method results
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Removes/disables compression on a file or folder
        /// </summary>
        /// <param name="fullPathToTarget">Full path to the file or folder</param>
        public static void DisableCompressionOnFileOrFolder(string fullPathToTarget)
        {
            int bytesReturned = 0;
            short inBuffer = COMPRESSION_FORMAT_NONE;

            try
            {
                if (Directory.Exists(fullPathToTarget))
                {
                    // WMI needs path \s escaped twice (instead of '\\', '\\\\')!
                    string directoryPath = "Win32_Directory.Name=" + "'" + fullPathToTarget.Replace("\\", @"\\").TrimEnd('\\') + "'";
                    using (ManagementObject mgmt = new(directoryPath))
                    {
                        mgmt.InvokeMethod("Uncompress", null, null);
                    }
                }
                else
                {
                    using (FileStream stream = File.Open(fullPathToTarget, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
#pragma warning disable CA1806 // Do not ignore method results
                        DeviceIoControl(stream.SafeFileHandle.DangerousGetHandle(), FSCTL_SET_COMPRESSION, ref inBuffer, sizeof(short), IntPtr.Zero, 0, ref bytesReturned, IntPtr.Zero);
#pragma warning restore CA1806 // Do not ignore method results
                    }
                }
            }
            catch { }
        }
    }
}
