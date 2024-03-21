
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Win32 API definitions for Kernel32
    /// </summary>
    internal static partial class Kernel32
    {
        /// <summary>
        /// Get the error code for the last error set
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        static extern uint GetLastError();

        /// <summary>
        /// Open a process and return its handle
        /// </summary>
        /// <param name="processAccess">Access level required</param>
        /// <param name="bInheritHandle">If true, then inherits the handle</param>
        /// <param name="processId">The PID of the process</param>
        /// <returns>Process handle</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

        /// <summary>
        /// Query the image name of the specified process
        /// </summary>
        /// <param name="hProcess">Handle to the process (from OpenProcess())</param>
        /// <param name="dwFlags">Access flags</param>
        /// <param name="lpExeName">The returned information (file name of process executable)</param>
        /// <param name="lpdwSize">Size of the lpExeName buffer</param>
        /// <returns>True if operation succeeded</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool QueryFullProcessImageName(IntPtr hProcess, int dwFlags, [Out] StringBuilder lpExeName, ref int lpdwSize);

        /// <summary>
        /// Perform a low-level DEVICE I/O operation
        /// </summary>
        /// <param name="hDevice">Handle to device or file</param>
        /// <param name="ioControlCode">The control to perform on the device/file</param>
        /// <param name="inBuffer">Inward buffer, typically the operation code</param>
        /// <param name="inBufferSize">Size of inBuffer</param>
        /// <param name="outBuffer">Output buffer if an output is expected</param>
        /// <param name="outBufferSize">Size of output buffer</param>
        /// <param name="bytesReturned">Number of bytes returned by the operation</param>
        /// <param name="overlapped">Handle to an overlapped operation</param>
        /// <returns>Result code</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        static extern int DeviceIoControl(IntPtr hDevice, int ioControlCode, ref short inBuffer, int inBufferSize, IntPtr outBuffer, int outBufferSize, ref int bytesReturned, IntPtr overlapped);

        /// <summary>
        /// FSCTL constant to set compression state
        /// </summary>
        static readonly int FSCTL_SET_COMPRESSION = 0x9C040;

        /// <summary>
        /// Set compression format to default (LZNT1)
        /// </summary>
        static readonly short COMPRESSION_FORMAT_DEFAULT = 1;

        /// <summary>
        /// Set no compression (remove compression)
        /// </summary>
        static readonly short COMPRESSION_FORMAT_NONE = 0;


        /// <summary>
        /// Flags to access process information
        /// </summary>
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            /// <summary>
            /// Tells the kernel we want only basic information
            /// </summary>
            QueryLimitedInformation = 0x00001000

            // there are more constants that we are not interested in
        }
    }
}
