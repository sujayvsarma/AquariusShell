using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace AquariusShell.Modules
{
    /// <summary>
    /// API definitions for manipulating window frames
    /// </summary>
    internal static partial class Windows
    {
        /// <summary>
        /// Brings the specified window to the top of the Z order. If the window is a top-level window, it is activated. 
        /// If the window is a child window, the top-level parent window associated with the child window is activated.
        /// </summary>
        /// <param name="hWnd">Handle to the window</param>
        /// <param name="fShutDown">[ignored] MUST be FALSE</param>
        /// <param name="fForce">True = force closing the window</param>
        /// <returns>TRUE if function succeeds</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EndTask(IntPtr hWnd, bool fShutDown, bool fForce);

        /// <summary>
        /// Get information about the specified window
        /// </summary>
        /// <param name="hWnd">Handle to window to get information about</param>
        /// <param name="wndInfo">Initialsed WINDOWINFO (remember to set the SIZE member within!)</param>
        /// <returns>True if call succeeded</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowInfo(IntPtr hWnd, ref WINDOWINFO wndInfo);

        /// <summary>
        /// Returns if the app that owns the window provided is in a hung/zombie state
        /// </summary>
        /// <param name="hWnd">Handle to the window</param>
        /// <returns>TRUE if the app is a zombie</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsHungAppWindow(IntPtr hWnd);

        /// <summary>
        /// Returns if the provided window is in an iconic or minimised state
        /// </summary>
        /// <param name="hWnd">Handle to the window</param>
        /// <returns>TRUE if the window is minimised</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsIconic(IntPtr hWnd);

        /// <summary>
        /// Checks if the provided handle belongs to a window
        /// </summary>
        /// <param name="hWnd">Handle to window to check</param>
        /// <returns>True if it is a window</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindow(IntPtr hWnd);

        /// <summary>
        /// Checks if the provided window is visible
        /// </summary>
        /// <param name="hWnd">Handle to window to check</param>
        /// <returns>True if window is visible</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);


        /// <summary>
        /// Brings the window and its associated thread/process to the foreground, assigns its the input and processing priority
        /// </summary>
        /// <param name="hWnd">Handle to the window</param>
        /// <returns>TRUE if the operation succeeds</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Get/set various system parameters
        /// </summary>
        /// <param name="uiAction">Action to perform (what to set/get)</param>
        /// <param name="uiParam">Parameter for uiAction function</param>
        /// <param name="pvParam">Rectangle to effect or returned</param>
        /// <param name="fWinIni">Result of function</param>
        /// <returns>True if action succeeded</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref WIN32RECT pvParam, uint fWinIni);

        /// <summary>
        /// Changes the size, position and Z-order of a window.
        /// </summary>
        /// <param name="hWnd">Handle to the window</param>
        /// <param name="hWndInsertAfterOrFlags">Handle to the window that would be higher than hWnd in the Z-order or a flag from SetWindowPosEnum enumeration</param>
        /// <param name="topLeftX">New position: Top-left corner X coordinate</param>
        /// <param name="topLeftY">New position: Top-left corner Y coordinate</param>
        /// <param name="width">New size: width of window</param>
        /// <param name="height">New size: height of window</param>
        /// <returns>TRUE if the operation succeeds</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfterOrFlags, int topLeftX, int topLeftY, int width, int height, SetWindowPosFlagsEnum uFlags);

        /// <summary>
        /// Show the given window with the provided command-flags
        /// </summary>
        /// <param name="hWnd">Handle to window</param>
        /// <param name="nCmdShow">Show command</param>
        /// <returns>True if operation succeeded</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommandsEnum nCmdShow);


        /// <summary>
        /// SystemParametersInfo command to set the Workarea bounds
        /// </summary>
        private static uint SPI_SETWORKAREA = 0x002F;

        /// <summary>
        /// A rectangle as used by Windows API
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WIN32RECT
        {
            /// <summary>
            /// Top-Left X
            /// </summary>
            public int Left;

            /// <summary>
            /// Top-left Y
            /// </summary>
            public int Top;

            /// <summary>
            /// Bottom-Right X
            /// </summary>
            public int Right;

            /// <summary>
            /// Bottom-Right Y
            /// </summary>
            public int Bottom;

            /// <summary>
            /// Turn it into a rectangle
            /// </summary>
            public Rectangle ToRectangle()
                => new()
                {
                    Location = new(Left, Top),
                    Size = new(Right - Left, Bottom - Top)
                };

            /// <summary>
            /// Import a rectangle
            /// </summary>
            /// <param name="rectangle">Rectangle to import</param>
            /// <returns>WIN32RECT</returns>
            public static WIN32RECT FromRectangle(Rectangle rectangle)
                => new()
                {
                    Left = rectangle.Left,
                    Top = rectangle.Top,
                    Right = rectangle.Right,
                    Bottom = rectangle.Bottom
                };
        }


        /// <summary>
        /// Window Info structure used by multiple window-manipulation functions
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWINFO
        {
            /// <summary>
            /// Size of this structure
            /// </summary>
            public uint cbSize;

            /// <summary>
            /// Bounds of the window (will be different from rcClient if Window Composition is enabled - is default)
            /// </summary>
            public WIN32RECT rcWindow;

            /// <summary>
            /// Bounds of the client-area of the window (will be different from rcWindow if Window Composition is enabled - is default)
            /// </summary>
            public WIN32RECT rcClient;

            /// <summary>
            /// Style of window (See WindowStylesEnum enumeration)
            /// </summary>
            public uint dwStyle;

            /// <summary>
            /// Extended style of window (See WindowExtendedStylesEnum enumeration)
            /// </summary>
            public uint dwExStyle;

            /// <summary>
            /// Status of the window (if is 0x0001, then window is ACTIVE, else NOT)
            /// </summary>
            public uint dwWindowStatus;

            /// <summary>
            /// Width of window border in pixels
            /// </summary>
            public uint cxWindowBorders;

            /// <summary>
            /// Height of window border in pixels
            /// </summary>
            public uint cyWindowBorders;

            /// <summary>
            /// The ATOM type of window (ignore value for our purposes)
            /// </summary>
            public ushort atomWindowType;

            /// <summary>
            /// Version of Windows that created this window (eh?)
            /// </summary>
            public ushort wCreatorVersion;
        }

        /// <summary>
        /// Constants used as Window Styles in WINDOWINFO
        /// </summary>
        [Flags]
        public enum WindowStylesEnum : uint
        {
            WS_BORDER = 0x00800000,
            WS_CAPTION = 0x00C00000,
            WS_CHILD = 0x40000000,
            WS_CHILDWINDOW = 0x40000000,
            WS_CLIPCHILDREN = 0x02000000,
            WS_CLIPSIBLINGS = 0x04000000,
            WS_DISABLED = 0x08000000,
            WS_DLGFRAME = 0x00400000,
            WS_GROUP = 0x00020000,
            WS_HSCROLL = 0x00100000,
            WS_ICONIC = 0x20000000,
            WS_MAXIMIZE = 0x01000000,
            WS_MAXIMIZEBOX = 0x00010000,
            WS_MINIMIZE = 0x20000000,
            WS_MINIMIZEBOX = 0x00020000,
            WS_OVERLAPPED = 0x00000000,
            WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
            WS_POPUP = 0x80000000,
            WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
            WS_SIZEBOX = 0x00040000,
            WS_SYSMENU = 0x00080000,
            WS_TABSTOP = 0x00010000,
            WS_THICKFRAME = 0x00040000,
            WS_TILED = 0x00000000,
            WS_TILEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
            WS_VISIBLE = 0x10000000,
            WS_VSCROLL = 0x00200000
        }

        /// <summary>
        /// Constants used as Window Extended Styles in WINDOWINFO
        /// </summary>
        [Flags]
        public enum WindowExtendedStylesEnum : uint
        {
            WS_EX_ACCEPTFILES = 0x00000010,
            WS_EX_APPWINDOW = 0x00040000,
            WS_EX_CLIENTEDGE = 0x00000200,
            WS_EX_COMPOSITED = 0x02000000,
            WS_EX_CONTEXTHELP = 0x00000400,
            WS_EX_CONTROLPARENT = 0x00010000,
            WS_EX_DLGMODALFRAME = 0x00000001,
            WS_EX_LAYERED = 0x00080000,
            WS_EX_LAYOUTRTL = 0x00400000,
            WS_EX_LEFT = 0x00000000,
            WS_EX_LEFTSCROLLBAR = 0x00004000,
            WS_EX_LTRREADING = 0x00000000,
            WS_EX_MDICHILD = 0x00000040,
            WS_EX_NOACTIVATE = 0x08000000,
            WS_EX_NOINHERITLAYOUT = 0x00100000,
            WS_EX_NOPARENTNOTIFY = 0x00000004,
            WS_EX_NOREDIRECTIONBITMAP = 0x00200000,
            WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE,
            WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST,
            WS_EX_RIGHT = 0x00001000,
            WS_EX_RIGHTSCROLLBAR = 0x00000000,
            WS_EX_RTLREADING = 0x00002000,
            WS_EX_STATICEDGE = 0x00020000,
            WS_EX_TOOLWINDOW = 0x00000080,
            WS_EX_TOPMOST = 0x00000008,
            WS_EX_TRANSPARENT = 0x00000020,
            WS_EX_WINDOWEDGE = 0x00000100
        }

        /// <summary>
        /// Flags passed in the hWndInsertAfterOrFlags parameter of SetWindowPos
        /// </summary>
        [Flags]
        public enum SetWindowPosInsertAfterFlagsEnum : int
        {
            /// <summary>
            /// At the bottom of the Z-order
            /// </summary>
            HWND_BOTTOM = 1,

            /// <summary>
            /// Above all non-topmost windows (behind the bottom-most top-most window)
            /// </summary>
            HWND_NOTOPMOST = -2,

            /// <summary>
            /// Top of the z-order
            /// </summary>
            HWND_TOP = 0,

            /// <summary>
            /// Above all non-topmost windows
            /// </summary>
            HWND_TOPMOST = -1
        }

        /// <summary>
        /// Flags passed in the uFlags parameter of SetWindowPos
        /// </summary>
        [Flags]
        public enum SetWindowPosFlagsEnum : int
        {
            /// <summary>
            /// Hides the window
            /// </summary>
            SWP_HIDEWINDOW = 0x0080,

            /// <summary>
            /// Do not activate window --- if not, window is activated and moved to top of z-order group
            /// </summary>
            SWP_NOACTIVATE = 0x0010,

            /// <summary>
            /// Do not move the window (ignore x & y parameters)
            /// </summary>
            SWP_NOMOVE = 0x0002,

            /// <summary>
            /// Do not reorder in Z-order
            /// </summary>
            SWP_NOREPOSITION = 0x0200,

            /// <summary>
            /// Do not resize (ignore width & height parameters)
            /// </summary>
            SWP_NOSIZE = 0x0001,

            /// <summary>
            /// Retain current z-order (ignore hWndInsertAfter)
            /// </summary>
            SWP_NOZORDER = 0x0004,

            /// <summary>
            /// Display the window
            /// </summary>
            SWP_SHOWWINDOW = 0x0040
        }

        /// <summary>
        /// Commands for ShowWindow()
        /// </summary>
        public enum ShowWindowCommandsEnum : int
        {
            /// <summary>
            /// Hide the window (Form.Hide())
            /// </summary>
            Hide = 0,

            /// <summary>
            /// Set to normal size
            /// </summary>
            Normal = 1,

            /// <summary>
            /// Minimise the window (does not hide it)
            /// </summary>
            Minimized = 2,

            /// <summary>
            /// Maximise the window
            /// </summary>
            Maximized = 3,

            /// <summary>
            /// Restore window to previous dimensions
            /// </summary>
            Restore = 9
        }
    }

}
