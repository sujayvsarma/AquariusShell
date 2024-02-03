using System;
using System.Runtime.InteropServices;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Win32 API definitions for Shell32
    /// </summary>
    internal static partial class Shell32
    {
        /// <summary>
        /// Show the shell's about window
        /// </summary>
        /// <param name="parentWindowHandle">[Optional] Window handle to a parent window, can be Null</param>
        /// <param name="titleText">[Optional] Title text to display</param>
        /// <param name="otherStuff">[Optional] Text is displayed below the main copyright message in the space that is usually left blank</param>
        /// <param name="icon">[Optional] Icon to display instead of Windows</param>
        /// <returns>True if successful</returns>
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        extern static bool ShellAbout(IntPtr parentWindowHandle, string? titleText, string? otherStuff, IntPtr icon);

        /// <summary>
        /// Empty the recycle bin on one or more drives
        /// </summary>
        /// <param name="parentWindowHandle">Handle to a parent window if required</param>
        /// <param name="rootPathToRecyclebinHostDrive">Drive-rooted path to the drive on which to clear the recycle bin (eg: "C:\"). If NULL, empties the bin on ALL drives attached.</param>
        /// <param name="flags">Flags to control behaviour</param>
        /// <returns></returns>
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        extern static int SHEmptyRecycleBin(IntPtr parentWindowHandle, string? rootPathToRecyclebinHostDrive, uint flags);

        /// <summary>
        /// Shows the Format Drive dialog box
        /// </summary>
        /// <param name="parentWindowHandle">Handle of the parent window. This CANNOT be IntPtr.Zero and must be a valid window!</param>
        /// <param name="driveIndex">0-based index of the drive (A is 0, B is 1,...)</param>
        /// <param name="formatId">Format ID. Currently, 0xFFFF is the only valid value</param>
        /// <param name="options">Options that would be preselected in the dialog</param>
        /// <returns>Completion or error code</returns>
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        extern static int SHFormatDrive(IntPtr parentWindowHandle, uint driveIndex, uint formatId = 0xFFFF, ShFormatDriveOptions options = ShFormatDriveOptions.None);


        /// <summary>
        /// Structure for Shell's SHGetFileInfo call
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            /// <summary>
            /// Handle to the file type icon
            /// </summary>
            public IntPtr hIcon;

            /// <summary>
            /// Index of icon in system image list
            /// </summary>
            public int iIcon;

            /// <summary>
            /// Array of attributes of the file
            /// </summary>
            public uint Attributes;

            /// <summary>
            /// Display name of hte file
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string DisplayName;

            /// <summary>
            /// Type name of the file
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string TypeName;


            public SHFILEINFO()
            {
                hIcon = IntPtr.Zero;
                iIcon = 0;
                Attributes = 0;
                DisplayName = string.Empty;
                TypeName = string.Empty;
            }
        }

        /// <summary>
        /// Options for the SHFormatDrive
        /// </summary>
        public enum ShFormatDriveOptions : uint 
        {
            /// <summary>
            /// No options
            /// </summary>
            None = 0,

            /// <summary>
            /// Quickformat is pre-selected
            /// </summary>
            QuickFormat = 1,

            /// <summary>
            /// Create a bootable disk is pre-selected
            /// </summary>
            BootDisk = 2
        }
    }

}
