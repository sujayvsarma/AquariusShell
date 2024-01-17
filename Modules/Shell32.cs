using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Functions quaintly shell32 in nature
    /// </summary>
    internal static class Shell32
    {

        /// <summary>
        /// Shows the Windows "About" box suitably modified with our text
        /// </summary>
        public static void ShowAboutWindow()
        {
            ShellAbout(
                    IntPtr.Zero,
                    "Windows powered by Aquarius Shell",
                    "Aquarius Shell (c) 2024. Sujay V. Sarma. All rights reserved.",
                    IntPtr.Zero
                );
        }

        /// <summary>
        /// Empty the recycle bin
        /// </summary>
        /// <param name="driveLetter">Letter of the drive to delete on</param>
        public static void ClearRecycleBin(char driveLetter)
        {
            string driveRootedPath = $"{driveLetter}:\\";
            SHEmptyRecycleBin(IntPtr.Zero, driveRootedPath, (uint)RecycleBinFlagsEnum.SilentMode);
        }


        /// <summary>
        /// Executes a program or launches the document/file in the associated program
        /// </summary>
        /// <param name="fullPathToTarget">Fully qualified path to the target document, file or app</param>
        /// <param name="verb">The verb or action to perform on the target</param>
        /// <returns>Handle to the process generated. Will be IntPtr.Zero if operation failed.</returns>
        public static IntPtr ExecuteOrLaunchTarget(string fullPathToTarget, ShellExecuteVerbsEnum verb = ShellExecuteVerbsEnum.Open)
        {
            Process? process = TryExecutingUsingShellAssociation(fullPathToTarget, verb);
            if (process == null)
            {
                process = TryExecutingUsingRunDll(fullPathToTarget);
            }

            if (process != null)
            {
                return process.Handle;
            }

            // if we still have a problem, it is something we cannot solve.
            return IntPtr.Zero;
        }

        /// <summary>
        /// Try executing using ShellExecute. This would work for regular programs,apps and documents that have file associations.
        /// </summary>
        /// <param name="fullPathToTarget">Full path to target file,applet, etc</param>
        /// <param name="verb">The verb or action to perform on the target</param>
        /// <returns>Process if we managed to start one, else NULL</returns>
        private static Process? TryExecutingUsingShellAssociation(string fullPathToTarget, ShellExecuteVerbsEnum verb)
        {
            ProcessStartInfo startInfo = new(fullPathToTarget)
            {
                UseShellExecute = true,                             // leverages the Shell's association/discovery process to decide what to do
                Verb = verb.ToString(),                             // What to do with it
                ErrorDialog = false                                 // we will handle ourselves
            };
            Process? process = null;

            try
            {
                process = Process.Start(startInfo);
            }
            catch
            {
            }

            return process;
        }

        /// <summary>
        /// Try executing using rundll32's execution mechanism. This would work for control panel items, for instance.
        /// </summary>
        /// <param name="fullPathToTarget">Full path to target file,applet, etc</param>
        /// <returns>Process if we managed to start one, else NULL</returns>
        private static Process? TryExecutingUsingRunDll(string fullPathToTarget)
        {
            ProcessStartInfo startInfo = new(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "rundll32.exe"),
                    $"shell32.dll,{(fullPathToTarget.EndsWith(".cpl") ? "Control" : "OpenAs")}_RunDLL \"{fullPathToTarget}\""
            )
            {
                UseShellExecute = false,                    // though we are calling shell32.dll, we want to use RunDll and not Execute
                ErrorDialog = false                         // we will handle ourselves
            };
            Process? process = null;

            try
            {
                process = Process.Start(startInfo);
            }
            catch
            {
            }

            return process;
        }



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
        /// Verbs used to execute/launch files or programs
        /// </summary>
        public enum ShellExecuteVerbsEnum
        {
            /// <summary>
            /// Default, open it
            /// </summary>
            Open,

            /// <summary>
            /// Launch in edit mode
            /// </summary>
            Edit,

            /// <summary>
            /// Find the target
            /// </summary>
            Find,

            /// <summary>
            /// Prints the target
            /// </summary>
            Print,

            /// <summary>
            /// Display the Properties box for the target
            /// </summary>
            Properties,     //TODO: We want to replace this with our own when we implement our own file explorer system

            /// <summary>
            /// Elevate or alterate login with UAC consent-flow
            /// </summary>
            RunAs
        }

        /// <summary>
        /// Flags for recycle bin operations
        /// </summary>
        public enum RecycleBinFlagsEnum : uint
        {
            /// <summary>
            /// No confirmation ("Do you want to delete...") will be displayed
            /// </summary>
            NoConfirmation = 1,

            /// <summary>
            /// No clearance progress UX will be displayed
            /// </summary>
            NoProgressUI = 2,

            /// <summary>
            /// No sound will be played on completion of deletion
            /// </summary>
            NoSoundOnCompletion = 4,

            /// <summary>
            /// Completely silent mode
            /// </summary>
            SilentMode = NoConfirmation | NoProgressUI | NoSoundOnCompletion
        }
    }
}
