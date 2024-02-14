using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

using AquariusShell.Objects;
using AquariusShell.Runtime;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Operations on the file system (disks, folders, drives)
    /// </summary>
    internal static partial class Filesystem
    {

        /// <summary>
        /// Generate a name for a new shortcut
        /// </summary>
        /// <param name="target">Target of the shortcut (what will be launched or opened)</param>
        /// <param name="saveToPath">Path where the shortcut file would be saved</param>
        /// <returns>New name. Will be Empty string if there was a problem</returns>
        public static string GenerateNewShortcutName(string target, string saveToPath)
        {
            StringBuilder linkName = new(int.MaxValue);
            bool result = SHGetNewLinkInfo(target, saveToPath, out linkName, out bool isDuplicate, (uint)ShGetNewLinkInfoFlagsEnum.None);

            return (result ? linkName.ToString() : string.Empty);
        }

        /// <summary>
        /// Get a list of files in the recycle bin
        /// </summary>
        /// <returns>List of items, containing metadata about each item</returns>
        public static List<RecyclebinItem> GetFilesInRecycleBin()
        {
            List<RecyclebinItem> items = new();

            // We are using Dynamic COM because working with ShellAPI for this is way too tedious!
            Type shellAppType = Type.GetTypeFromProgID("Shell.Application")!;
            dynamic? shell = Activator.CreateInstance(shellAppType)!;
            if (shell != null)
            {
                dynamic? recyclebinFolder = shell.Namespace(SHELL_NAMESPACE_RECYCLEBIN);
                if (recyclebinFolder != null)
                {
                    dynamic? recyclebinContents = recyclebinFolder.Items();
                    if (recyclebinContents != null)
                    {
                        for (int i = 0; i < recyclebinContents.Count; i++)
                        {
                            dynamic? itemInFolder = recyclebinContents.Item(i);

                            // Result: "D:\src\$RECYCLE.BIN\Recycle Bin\helloworld.cs"
                            string rbPath = recyclebinFolder.GetDetailsOf(itemInFolder, RecyclebinItemDetailColumnNames.FullyQualifiedRecyclebinPath);

                            // Recycle bin for every folder gets its own randomised folder name.
                            // But the VISIBLE name for it is ALWAYS "Recycle Bin".
                            // However, we need the actual path behind that visible name... so, we resolve it
                            // RecyclebinItemDetailColumnNames.RecyclebinFolder = Give me the actual folder name for itemInFolder
                            // Result: "D:\src\$RECYCLE.BIN\S-X-Y-JHSDKJASDKAHSD"
                            string resolvedRbPath = recyclebinFolder.GetDetailsOf(itemInFolder, RecyclebinItemDetailColumnNames.RecyclebinFolder);

                            // Re-create the path for the item we enumerated earlier
                            // Result: "D:\src\$RECYCLE.BIN\S-X-Y-JHSDKJASDKAHSD\helloworld.cs"
                            string diskRbPath = Path.Combine(
                                    Path.GetDirectoryName(resolvedRbPath)!,
                                    ShellEnvironment.CurrentUserSID
                                );

                            diskRbPath = rbPath.Replace(resolvedRbPath, diskRbPath);

                            //Debug.WriteLine("--------------------");
                            //Debug.WriteLine($"File {i} : {recyclebinFolder.GetDetailsOf(itemInFolder, RecyclebinItemDetailColumnNames.FileName)}");
                            //for (int j = 0; j < 256; j++)
                            //{
                            //    string? value = recyclebinFolder.GetDetailsOf(itemInFolder, j);
                            //    Debug.WriteLine($"[{j}] = [{value}]");
                            //}
                            //Debug.WriteLine("--------------------");

                            RecyclebinItem item = new(
                                    recyclebinFolder.GetDetailsOf(itemInFolder, RecyclebinItemDetailColumnNames.FileName),
                                    recyclebinFolder.GetDetailsOf(itemInFolder, RecyclebinItemDetailColumnNames.OriginalPath),
                                    recyclebinFolder.GetDetailsOf(itemInFolder, RecyclebinItemDetailColumnNames.DeletedAt),
                                    recyclebinFolder.GetDetailsOf(itemInFolder, RecyclebinItemDetailColumnNames.FileSize),
                                    recyclebinFolder.GetDetailsOf(itemInFolder, RecyclebinItemDetailColumnNames.TypeOfObjectWithFileType),
                                    diskRbPath
                                );
                            items.Add(item);
                        }

                        // release COM object
                        recyclebinContents = null;
                    }

                    // release COM object
                    recyclebinFolder = null;
                }

                // release COM object
                shell = null;
            }

            return items;
        }

        /// <summary>
        /// Send a single file or directory to recycle bin
        /// </summary>
        /// <param name="fullyQualifiedPath">Fully qualified path to the file or directory to delete</param>
        /// <returns>True if operation succeeded</returns>
        public static bool SendItemToRecycleBin(string fullyQualifiedPath)
        {
            SHFILEOPSTRUCT ops = new()
            {
                hWndOwnerWindow = IntPtr.Zero,
                FunctionName = FileOperationFunctionNames.Delete,
                Flags = FileOperationFlags.AllowUndo | FileOperationFlags.DontShowProgress | FileOperationFlags.DontShowErrors | FileOperationFlags.NoConfirmation,
                SourceFileNames = fullyQualifiedPath + "\0\0",
                DestinationFileNames = null
            };

            int result = SHFileOperation(ref ops);
            return (result == 0);
        }


        /// <summary>
        /// Send files to recycle bin
        /// </summary>
        /// <param name="fullyQualifiedPaths">Collection of files/directories to delete</param>
        /// <returns>True if operation succeeded</returns>
        public static bool SendFilesToRecycleBin(IEnumerable<string> fullyQualifiedPaths)
        {
            SHFILEOPSTRUCT ops = new()
            {
                hWndOwnerWindow = IntPtr.Zero,
                FunctionName = FileOperationFunctionNames.Delete,
                Flags = FileOperationFlags.AllowUndo | FileOperationFlags.DontShowProgress | FileOperationFlags.DontShowErrors | FileOperationFlags.NoConfirmation,
                SourceFileNames = string.Join('\0', fullyQualifiedPaths) + "\0\0",
                DestinationFileNames = null
            };

            int result = SHFileOperation(ref ops);
            return (result == 0);
        }


        /// <summary>
        /// Empties the recycle bin on all fixed drives
        /// </summary>
        public static void EmptyRecycleBin()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Fixed)
                {
                    try
                    {
                        Shell32.ClearRecycleBin(drive.Name[0]);
                    }
                    catch
                    {
                        // eat and continue
                    }
                }
            }
        }

    }
}
