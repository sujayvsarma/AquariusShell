using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

using AquariusShell.Runtime;

using Microsoft.Win32;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Functions quaintly shell32 in nature
    /// </summary>
    internal static partial class Shell32
    {

        /// <summary>
        /// Shows the Windows "About" box suitably modified with our text
        /// </summary>
        public static void ShowWindowsAboutDialog()
        {
            ShellAbout(
                    ShellEnvironment.WorkArea.Handle,
                    "Windows enhanced by Aquarius Shell",
                    $"Aquarius Shell (c) {DateTime.Now.Year}. Sujay V. Sarma. All rights reserved.",
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
        /// Show the "Format Disk" dialog box
        /// </summary>
        /// <param name="driveName">Drive name (can be in any of formats: "C:\", "C:", "C" )</param>
        /// <param name="parentWindowHandle">Handle of the parent window. This CANNOT be IntPtr.Zero and must be a valid window!</param>
        public static void ShowFormatDiskDialog(string driveName, IntPtr parentWindowHandle)
        {
            char driveLetter = driveName[0];
            uint driveIndex = (uint)(driveLetter - 'A');

            SHFormatDrive(parentWindowHandle, driveIndex);
        }


        /// <summary>
        /// Execute a program directly
        /// </summary>
        /// <param name="executablePath">Full executable path</param>
        /// <param name="verb">Verb to send. Set to None for no verb</param>
        /// <param name="quietMode">Quiet mode -- no windows to be created</param>
        /// <param name="arguments">List of arguments to pass into the program</param>
        /// <returns>PID of the process or -1</returns>
        public static int ExecuteProgram(string executablePath, ShellExecuteVerbsEnum verb = ShellExecuteVerbsEnum.None, bool quietMode = false, params string[] arguments)
        {
            ProcessStartInfo startInfo = new(executablePath);
            if (verb != ShellExecuteVerbsEnum.None)
            {
                startInfo.Verb = verb.ToString().ToLower();
            }
            if (quietMode)
            {
                startInfo.CreateNoWindow = true;
            }

            if ((arguments != null) && (arguments.Length > 0))
            {
                startInfo.Arguments = string.Join(' ', arguments.Where(a => (! string.IsNullOrWhiteSpace(a))));
            }

            Process? process = null;
            try
            {
                process = Process.Start(startInfo);
            }
            catch
            {
            }

            return ((process == null) ? -1 : process.Id);
        }

        /// <summary>
        /// Execute a program directly
        /// </summary>
        /// <param name="executablePath">Full executable path</param>
        /// <param name="workingDirectory">The working directory to set</param>
        /// <param name="verb">Verb to send. Set to None for no verb</param>
        /// <param name="quietMode">Quiet mode -- no windows to be created</param>
        /// <param name="arguments">List of arguments to pass into the program</param>
        /// <returns>PID of the process or -1</returns>
        public static int ExecuteProgramWithWorkingDirectory(string executablePath, string workingDirectory, ShellExecuteVerbsEnum verb = ShellExecuteVerbsEnum.None, bool quietMode = false, params string[] arguments)
        {
            ProcessStartInfo startInfo = new(executablePath)
            {
                WorkingDirectory = workingDirectory,
                UseShellExecute = false
            };

            if (verb != ShellExecuteVerbsEnum.None)
            {
                startInfo.Verb = verb.ToString().ToLower();
            }
            if (quietMode)
            {
                startInfo.CreateNoWindow = true;
            }

            if ((arguments != null) && (arguments.Length > 0))
            {
                startInfo.Arguments = string.Join(' ', arguments.Where(a => (!string.IsNullOrWhiteSpace(a))));
            }

            Process? process = null;
            try
            {
                process = Process.Start(startInfo);
            }
            catch
            {
            }

            return ((process == null) ? -1 : process.Id);
        }




        /// <summary>
        /// Executes a program or launches the document/file in the associated program
        /// </summary>
        /// <param name="fullPathToTarget">Fully qualified path to the target document, file or app</param>
        /// <param name="verb">The verb or action to perform on the target</param>
        /// <param name="runSilently">If set, creates no windows</param>
        /// <returns>Handle to the process generated. Will be IntPtr.Zero if operation failed.</returns>
        public static IntPtr ExecuteOrLaunchTarget(string fullPathToTarget, ShellExecuteVerbsEnum verb = ShellExecuteVerbsEnum.Open, bool runSilently = false)
        {
            Process? process = TryExecutingUsingShellAssociation(fullPathToTarget, verb, runSilently);
            if (process == null)
            {
                process = TryExecutingUsingRunDll(fullPathToTarget, verb, runSilently);
            }

            if (process != null)
            {
                return process.Handle;
            }

            // if we still have a problem, it is something we cannot solve.
            return IntPtr.Zero;
        }

        /// <summary>
        /// Execute a RunDLL command
        /// </summary>
        /// <param name="parameters">Parameters for the command</param>
        /// <returns>True if the call succeeded</returns>
        public static bool ExecuteRundll32Command(params string[] parameters)
        {
            ProcessStartInfo startInfo = new(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "rundll32.exe"),
                    string.Join(' ', parameters.Where(s => (! string.IsNullOrWhiteSpace(s))))
            )
            {
                UseShellExecute = false,                    // though we are calling shell32.dll, we want to use RunDll and not Execute
                ErrorDialog = false                         // we will handle ourselves
            };

            try
            {
                Process? process = Process.Start(startInfo);
                if (process == null)
                {
                    throw new Exception("Could not start process.");
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the name of the type for the provided filename extension
        /// </summary>
        /// <param name="fileNameOrExtension">The full path/name of the file or just the extension (.txt)</param>
        /// <param name="isOnlyExtension">Set to TRUE if only the extension portion has been specified.</param>
        /// <returns>The name of the file type</returns>
        public static string GetFileTypeName(string fileNameOrExtension, bool isOnlyExtension = false)
        {
            string fileNameExtension = (isOnlyExtension ? fileNameOrExtension : Path.GetExtension(fileNameOrExtension));
            if (!fileNameExtension.StartsWith('.'))
            {
                fileNameExtension = $".{fileNameExtension}";
            }

            string typeName = $"{fileNameExtension.Trim('.').ToUpper()} file";

            RegistryKey? extensionKey = Registry.ClassesRoot.OpenSubKey(fileNameExtension);
            if (extensionKey != null)
            {
                string? lookupKeyName = extensionKey.GetValue(string.Empty)?.ToString();
                if (!string.IsNullOrWhiteSpace(lookupKeyName))
                {
                    RegistryKey? lookupKey = Registry.ClassesRoot.OpenSubKey(lookupKeyName);
                    if (lookupKey != null)
                    {
                        typeName = lookupKey.GetValue(string.Empty)?.ToString() ?? typeName;
                    }
                }

                extensionKey.Close();
            }

            return typeName;
        }

        /// <summary>
        /// Try executing using ShellExecute. This would work for regular programs,apps and documents that have file associations.
        /// </summary>
        /// <param name="fullPathToTarget">Full path to target file,applet, etc</param>
        /// <param name="verb">The verb or action to perform on the target</param>
        /// <param name="runSilently">If set, creates no windows</param>
        /// <returns>Process if we managed to start one, else NULL</returns>
        private static Process? TryExecutingUsingShellAssociation(string fullPathToTarget, ShellExecuteVerbsEnum verb, bool runSilently = false)
        {
            ProcessStartInfo startInfo = new(fullPathToTarget)
            {
                CreateNoWindow = runSilently,
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
        /// <param name="verb">The verb or action to perform on the target</param>
        /// <param name="runSilently">If set, creates no windows</param>
        /// <returns>Process if we managed to start one, else NULL</returns>
        private static Process? TryExecutingUsingRunDll(string fullPathToTarget, ShellExecuteVerbsEnum verb, bool runSilently = false)
        {
            ProcessStartInfo startInfo = new(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "rundll32.exe"),
                    $"shell32.dll,{(fullPathToTarget.EndsWith(".cpl") ? "Control" : "OpenAs")}_RunDLL \"{fullPathToTarget}\""
            )
            {
                CreateNoWindow = runSilently,
                UseShellExecute = false,                    // though we are calling shell32.dll, we want to use RunDll and not Execute
                Verb = verb.ToString(),                             // What to do with it
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
    }
}
