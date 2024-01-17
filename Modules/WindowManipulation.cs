using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Functions that create, destroy, query or manipulate the windows in Windows
    /// </summary>
    internal static class WindowManipulation
    {

        /// <summary>
        /// Returns all visible windows of a given process
        /// </summary>
        /// <param name="mainWindowHandle">hWnd of the main window for the process</param>
        /// <returns>List of IntPtrs, handles to the child windows. <paramref name="mainWindowHandle"/> is only added to if it is visible!</returns>
        public static List<IntPtr> GetAllVisibleWindows(IntPtr mainWindowHandle)
        {
            List<IntPtr> handles = new();

            IntPtr hWnd = mainWindowHandle;
            while (hWnd != IntPtr.Zero)
            {
                if (IsWindowVisible(hWnd))
                {
                    handles.Add(hWnd);
                }

                hWnd = GetWindow(hWnd, (int)GetWindowConstantsEnum.NextWindow);
            }

            return handles;
        }

        /// <summary>
        /// Get the title/text associated with the given window
        /// </summary>
        /// <param name="hWnd">Handle to the window</param>
        /// <returns>Title/text. Empty string if no title could be retrieved</returns>
        public static string GetWindowTitle(IntPtr hWnd)
        {
            int titleLength = GetWindowTextLength(hWnd);
            StringBuilder buffer = new(titleLength);

            int bytesCopied = GetWindowText(hWnd, buffer, buffer.Capacity);
            if ((bytesCopied == 0) || (buffer.Length == 0))
            {
                return string.Empty;
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Get the icon associated with the program running the provided window handle
        /// </summary>
        /// <param name="hWnd">Window handle to get the icon for</param>
        /// <param name="size">Size of the desired icon</param>
        /// <returns>Icon as retrieved or NULL</returns>
        public static Icon? GetWindowIcon(IntPtr hWnd, IconSizesEnum size)
        {
            uint threadId = GetWindowThreadProcessId(hWnd, out uint processId);
            if ((threadId != 0) && (processId != 0))
            {
                Process actualProcess = Process.GetProcessById((int)processId);
                if (actualProcess.MainModule != null)
                {
                    return Icons.ExtractAssociatedIcon(actualProcess.MainModule.FileName, size);
                }
            }            

            return null;
        }



        /// <summary>
        /// Retrieve reference to a Window
        /// </summary>
        /// <param name="hWnd">Handle to the Window</param>
        /// <param name="uCmd">Command-constant on what to retrieve</param>
        /// <returns>Reference to window retrieved</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        /// <summary>
        /// Checks if the provided window is visible
        /// </summary>
        /// <param name="hWnd">Handle to window to check</param>
        /// <returns>True if window is visible</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>
        /// Returns the length of the title of a given window
        /// </summary>
        /// <param name="hWnd">Handle to the window to get the title-length of</param>
        /// <returns>Length, not including the null-terminator</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        /// <summary>
        /// Returns the title/text of the given window
        /// </summary>
        /// <param name="hWnd">Handle to the window</param>
        /// <param name="lpString">[in, out] Pointer to the buffer that would receive the title text</param>
        /// <param name="nMaxCount">Size of the buffer provided</param>
        /// <returns>Number of bytes filled into the <paramref name="lpString"/> buffer</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// Get the process Id of the owner of the thread that holds the provided window
        /// </summary>
        /// <param name="hWnd">Handle to (probably) the main window</param>
        /// <param name="processId">[out] PID of the thread-process that owns that window</param>
        /// <returns>PID of the thread that created the window</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        /// <summary>
        /// Constants for GetWindow()
        /// </summary>
        enum GetWindowConstantsEnum
        {
            FirstWindow = 0,
            LastWindow = 0,
            NextWindow = 2,
            PreviousWindow = 3,
            OwnerOfCurrentWindow = 4,
            ChildOfCurrentWindow = 5,
            EnabledPopupWindowUnderWindow = 6
        }

    }
}
