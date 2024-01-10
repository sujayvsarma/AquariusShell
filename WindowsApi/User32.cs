using System.Runtime.InteropServices;

namespace AquariusShell.WindowsApi
{
    /// <summary>
    /// user32.dll functions
    /// </summary>
    public static class User32
    {
        /// <summary>
        /// Logoff, shutdown or reboot Windows
        /// </summary>
        /// <param name="uFlags">Type of shutdown</param>
        /// <param name="dwReason">Reason for the shutdown if applicable</param>
        /// <returns>Result of operation</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ExitWindowsEx(uint uFlags, uint dwReason);

        /// <summary>
        /// Bring the window pointed to by hWnd to the foreground
        /// </summary>
        /// <param name="hWnd">Window handle to set to foreground</param>
        /// <returns>Result of operation</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern long SetForegroundWindow(long hWnd);

        /// <summary>
        /// Checks to see if the provided Window is minimised (iconic)
        /// </summary>
        /// <param name="hWnd">Window handle to check</param>
        /// <returns>True if it is</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool IsIconic(long hWnd);

        /// <summary>
        /// Show or hide a window
        /// </summary>
        /// <param name="hWnd">Window handle to set to foreground</param>
        /// <param name="showMode">Mode to show the window in</param>
        /// <returns>Result of operation</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern long ShowWindow(long hWnd, int showMode);

        /// <summary>
        /// Get information about various Windows
        /// </summary>
        /// <param name="hWnd">Window handle</param>
        /// <param name="windowInfo">(returned, by ref)Window information</param>
        /// <returns>True/false of exec status</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowInfo(IntPtr hWnd, ref WINDOWINFO windowInfo);

        /// <summary>
        /// Get/set various system parameters
        /// </summary>
        /// <param name="uiAction">The action to perform (what to get or set)</param>
        /// <param name="uiParam">A combination parameter to uiAction</param>
        /// <param name="pvParam">The rectangle that was affected or returned</param>
        /// <param name="fWinIni">Result</param>
        /// <returns>True if action succeeded</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref RECT pvParam, uint fWinIni);


        /// <summary>
        /// Set window position
        /// </summary>
        /// <param name="hWnd">Handle to the window to position</param>
        /// <param name="hWndInsertAfter">(Optional) Handle to window to insert the window (hWnd) after OR a value from <see cref="SetWindowPosInsertAfterFlagsEnum"/></param>
        /// <param name="left">New window X-coordinate in pixels</param>
        /// <param name="top">New window Y-coordinate in pixels</param>
        /// <param name="width">New width in pixels</param>
        /// <param name="height">New height in pixels</param>
        /// <param name="dwFlags">Sizing and positioning flags</param>
        /// <returns>True if action succeeded</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr  hWndInsertAfter, int left, int top, int width, int height, uint dwFlags);


        /// <summary>
        /// Enums for ShowWindow
        /// </summary>
        public enum ShowWindowModesEnum
        {
            HideAndSwitchFocus = 0,
            
            RestorePreviousSizeAndShow = 1,

            ActivateAsMinimisedWindow = 2,

            Maxmise = 3,

            RestorePreviousSizeWithoutActivation = 4,

            ShowWithCurrentSizeAndPosition = 5,

            MinimiseAndSwitchFocus = 6,

            MinimiseWithoutActivation = 7,

            ShowWithCurrentSizeAndPositionWithoutActivation = 8,

            RestoreToPreviousSizeAndPosition = 9,

            SetShowStateToProcessStartParams = 10,

            ForceMinimise = 11
        }

        /// <summary>
        /// Structure containing Window information from GetWindowInfo()
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWINFO
        {
            public uint SizeOfThisStructure;
            public RECT WindowRect;
            public RECT ClientRect;
            public uint Style;
            public uint StyleExtended;
            public uint Status;
            public uint WindowBorderWidth;
            public uint WindowBorderHeight;
            public int AtomWindowType;
            public int CreatorAppWindowsVersion;
        }

        /// <summary>
        /// Structure with a rectangle
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        /// <summary>
        /// Values of window styles we are interested in
        /// </summary>
        public enum WindowStylesInterestedFlagsEnum
        {
            /// <summary>
            /// A window with this set in the Style must never be shown on the taskbar
            /// </summary>
            DONTSHOWONTASKBAR = 0x08000000,

            /// <summary>
            /// Parameter to pass to SystemParametersInfo() to SET the working area
            /// </summary>
            SPI_SETWORKAREA = 0x002F
        }

        /// <summary>
        /// Well-known z-order placeholders for use with SetWindowPos()
        /// </summary>
        public enum SetWindowPosInsertAfterFlagsEnum
        {
            /// <summary>
            /// Above all non-top most, just behind all the top-most
            /// </summary>
            FirstNonTopMost = -2,

            /// <summary>
            /// Above all non-top most, as a top window, retains top status even when minimised
            /// </summary>
            AboveNonTopMostAsTopEvenMinimised = -1,

            /// <summary>
            /// The top-most window by z-order
            /// </summary>
            TopMost = 0,

            /// <summary>
            /// The bottom-most window by z-order
            /// </summary>
            BottomMost = 2
        }

        /// <summary>
        /// Flag values for SetWindowPos()
        /// </summary>
        public enum SetWindowPosFlagsEnum
        {
            /// <summary>
            /// Hide the window
            /// </summary>
            HideWindow = 0x0080,

            /// <summary>
            /// If not provided will activate the window and moved to top of z-order sub-queue
            /// </summary>
            DontActivate = 0x0010,

            /// <summary>
            /// Ignore X,Y coordinates in SetWindowPos(), leave the window where it is
            /// </summary>
            DontMove = 0x0002,

            /// <summary>
            /// Ignore CX, CY parameters in SetWindowPos(), leave the window the same SIZE as currently
            /// </summary>
            DontResize = 0x0001,

            /// <summary>
            /// Ignore hWndInsertAfter, do not reposition in z-order sub-queue
            /// </summary>
            RetainCurrentZOrder = 0x0004,

            /// <summary>
            /// Show the window on screen
            /// </summary>
            ShowWindow = 0x0040
        }
    }
}