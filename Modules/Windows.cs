using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

using AquariusShell.Runtime;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Functions that create, destroy, query or manipulate the windows in Windows
    /// </summary>
    internal static partial class Windows
    {
        /// <summary>
        /// When a running task is focus-toggled in the workarea, it is restored and focus is set on it if it was previously minimised, else 
        /// it is minimised. This function performs the checks and carries out the relevant action.
        /// </summary>
        /// <param name="hWndMainWindow">Handle to the process's main window (what is listed on the app/task list)</param>
        /// <returns>True if action succeeded. False -- would usually result in the task being removed from our tasklist.</returns>
        public static bool ToggleWindowShown(IntPtr hWndMainWindow)
        {
            if (IsWindowVisible(hWndMainWindow))
            {
                if (IsIconic(hWndMainWindow))
                {
                    if (ShowWindow(hWndMainWindow, ShowWindowCommandsEnum.Restore) && SetForegroundWindow(hWndMainWindow))
                    {
                        return true;
                    }
                }
                else
                {
                    if (ShowWindow(hWndMainWindow, ShowWindowCommandsEnum.Minimized))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Restore the given window (if required) and bring it to the front
        /// </summary>
        /// <param name="hWndMainWindow">Handle to the process's main window (what's listed on the app/task list)</param>
        /// <returns>True if action succeeded.</returns>
        public static bool SwitchToWindow(IntPtr hWndMainWindow)
        {
            if (IsWindowVisible(hWndMainWindow))
            {
                if (IsIconic(hWndMainWindow))
                {
                    if (!ShowWindow(hWndMainWindow, ShowWindowCommandsEnum.Restore))
                    {
                        return false;
                    }
                }

                return SetForegroundWindow(hWndMainWindow);
            }

            return false;
        }


        /// <summary>
        /// Kills the task associated with the provided window handle if it is in a hung/zombie state
        /// </summary>
        /// <param name="hWnd">Handle to the window</param>
        /// <returns>TRUE if operation was successful</returns>
        public static bool TerminateAppIfWindowHung(IntPtr hWnd)
        {
            if (IsHungAppWindow(hWnd))
            {
                return EndTask(hWnd, false, true);
            }

            return false;
        }       

        /// <summary>
        /// Performs all relevant checks to ensure that our Taskbar should show this window.
        /// </summary>
        /// <param name="hWnd">Handle to window to test</param>
        /// <returns>True if we must show this window</returns>
        public static bool IsWindowShowableOnOurTaskbar(IntPtr hWnd)
        {
            if (IsWindow(hWnd))
            {
                WINDOWINFO wi = new()
                {
                    cbSize = (uint)Marshal.SizeOf<WINDOWINFO>()
                };

                if (GetWindowInfo(hWnd, ref wi))
                {
                    if (
                            (!wi.dwStyle.HasFlag(
                                FlagCheckMethodEnum.AnyOf, new uint[]
                                {
                                    (uint)WindowStylesEnum.WS_CHILD,
                                    (uint)WindowStylesEnum.WS_DISABLED,
                                    (uint)WindowStylesEnum.WS_POPUPWINDOW
                                }))
                            && (!wi.dwExStyle.HasFlag(
                                FlagCheckMethodEnum.AnyOf, new uint[] 
                                { 
                                    (uint)WindowExtendedStylesEnum.WS_EX_NOACTIVATE,
                                    (uint)WindowExtendedStylesEnum.WS_EX_DLGMODALFRAME,
                                    (uint)WindowExtendedStylesEnum.WS_EX_PALETTEWINDOW,
                                    (uint)WindowExtendedStylesEnum.WS_EX_TOOLWINDOW
                                }))
                            && wi.rcClient.ToRectangle().IsWithinRect(ShellEnvironment.WorkareaBounds)
                       )
                    {
                        return true;
                    }
                }
            }

            // default answer is NO
            return false;
        }

        /// <summary>
        /// Set the workarea background as the bottom-most window in the z-order
        /// </summary>
        /// <param name="workareaHandle">Handle to the workarea form</param>
        /// <param name="width">Width of the form</param>
        /// <param name="height">Height of the form</param>
        public static void SetWorkareaAsBackgroundWindow(IntPtr workareaHandle, int width, int height)
        {
            SetWindowPos(
                    workareaHandle,
                    new IntPtr((int)SetWindowPosInsertAfterFlagsEnum.HWND_BOTTOM),
                    0, 0, width, height,
                    SetWindowPosFlagsEnum.SWP_NOACTIVATE | SetWindowPosFlagsEnum.SWP_NOSIZE | SetWindowPosFlagsEnum.SWP_NOMOVE
                );

            // for each running process, if there is a window, bring it above ourselves
            // We need to do this if we are not the default shell and something else was running before we got here!
            foreach (Process process in Process.GetProcesses())
            {
                if ((process.MainWindowHandle != nint.Zero)
                     && (!string.IsNullOrWhiteSpace(process.MainWindowTitle))
                            && Modules.Windows.IsWindowShowableOnOurTaskbar(process.MainWindowHandle)
                        )
                {
                    SetForegroundWindow(process.MainWindowHandle);
                }
            }
        }

        /// <summary>
        /// Returns if the smallerRect is within the largerRect
        /// </summary>
        /// <param name="smallerRect">Smaller rectange of space (eg: an app window)</param>
        /// <param name="largerRect">Larger rectangle of space (eg: screen, desktop, etc)</param>
        /// <returns>True if smallerRect lies within the largerRect</returns>
        public static bool IsWithinRect(this Rectangle smallerRect, Rectangle largerRect)
        {
            if (((smallerRect.Left >= largerRect.Left) || (smallerRect.Right <= largerRect.Right))
                && ((smallerRect.Top >= largerRect.Top) || (smallerRect.Bottom <= largerRect.Bottom)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Set the desktop's work area
        /// </summary>
        /// <param name="workAreaBounds">Boundaries of the new workarea</param>
        /// <returns>True if the call succeeded</returns>
        public static bool SetWorkareaBounds(Rectangle workAreaBounds)
        {
            Win32Rectangle rect = Win32Rectangle.FromRectangle(workAreaBounds);
            return SystemParametersInfo(SPI_SETWORKAREA, 0, ref rect, 0);
        }       
    }
}
