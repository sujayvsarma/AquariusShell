using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Win32 API Definitions
    /// </summary>
    internal static partial class Filesystem
    {
        /// <summary>
        /// Generates a name for a shortcut or link
        /// </summary>
        /// <param name="linkTargetPath">The file,program,url or other target to link to</param>
        /// <param name="pathWhereShortcutWillBeStored">The full path to the folder where the new shortcut file will be stored</param>
        /// <param name="proposedShortcutName">[Out] The generated shortcut name</param>
        /// <param name="duplicateShortcut">[Out] True when this is a shortcut to a shortcut, generating a "copy" operation when it will be actually created.</param>
        /// <param name="flags">One or more flags</param>
        /// <returns></returns>
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        extern static bool SHGetNewLinkInfo(string linkTargetPath, string pathWhereShortcutWillBeStored, out StringBuilder proposedShortcutName, out bool duplicateShortcut, ShGetNewLinkInfoFlagsEnum flags);

        /// <summary>
        /// Perform a file operation via Shell
        /// </summary>
        /// <param name="lpFileOp">The Shell File Ops Struct</param>
        /// <returns>Success/failure codes</returns>
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        static extern int SHFileOperation(ref SHFILEOPSTRUCT lpFileOp);

        /// <summary>
        /// Structure with metadata for the SHFileOperation API
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHFILEOPSTRUCT
        {
            /// <summary>
            /// Handle of window associated with operation
            /// </summary>
            public IntPtr hWndOwnerWindow;

            /// <summary>
            /// What operation to perform
            /// </summary>
            public FileOperationFunctionNames FunctionName;        // Operation to perform

            /// <summary>
            /// One or more fully qualified source files. 
            /// Terminate each file with a single NULL 
            /// and End of buffer with double-NULL sequence
            /// </summary>
            public string? SourceFileNames;     // Source file(s) or directory

            /// <summary>
            /// Fully qualified destination file or directory name. 
            /// NULL if NOT used (eg: DELETE)
            /// Terminate end of buffer with double-NULL 
            /// Destination need not exist for Copy/Move (system will create) 
            /// Multiple destination files if fFlags has FOF_MULTIDESTFILES
            /// </summary>
            public string? DestinationFileNames;

            /// <summary>
            /// Flags
            /// </summary>
            public FileOperationFlags Flags;

            /// <summary>
            /// On return if this is TRUE, some file operations were aborted by user 
            /// (eg: Skip existing files)
            /// </summary>
            public bool IsAnyOperationsAborted;

            /// <summary>
            /// If fFlags has WANTMAPPINGHANDLE, contains a name-map
            /// </summary>
            public IntPtr NameMappingsStructure;

            /// <summary>
            /// Ppointer to title of a progress dialog box.
            /// Null-terminated 
            /// Only if fFlags has SIMPLEPROGRESS
            /// </summary>
            public string? ProgressbarTitle;
        }

        /// <summary>
        /// The SHFileOperation function to perform
        /// </summary>
        public enum FileOperationFunctionNames : int
        {
            /// <summary>
            /// Move items
            /// </summary>
            Move = 0x0001,

            /// <summary>
            /// Copy items
            /// </summary>
            Copy = 0x0002,

            /// <summary>
            /// Delete items
            /// </summary>
            Delete = 0x0003,

            /// <summary>
            /// Rename items
            /// </summary>
            Rename = 0x0004
        }

        /// <summary>
        /// Flags to control SHFileOperation functionality
        /// </summary>
        [Flags]
        public enum FileOperationFlags : int
        {
            /// <summary>
            /// Allow Undo (for Delete, sends item to Recycle Bin)
            /// </summary>
            AllowUndo = 0x0040,

            /// <summary>
            /// Do not ask for confirmation
            /// </summary>
            NoConfirmation = 0x0200,

            /// <summary>
            /// Do not show error messages
            /// </summary>
            DontShowErrors = 0x0400,

            /// <summary>
            /// Run in silent/quiet mode, with no UI at all
            /// </summary>
            DontShowProgress = 0x0800
        }

        /// <summary>
        /// Flags for SHGetNewLinkInfo()
        /// </summary>
        [Flags]
        public enum ShGetNewLinkInfoFlagsEnum : uint
        {
            /// <summary>
            /// None of the flags
            /// </summary>
            None = 0,

            /// <summary>
            /// Target is a PIDL
            /// </summary>
            TargetIsPIDL = 1,

            /// <summary>
            /// Do not check for uniqueness of name before generation
            /// </summary>
            SkipUniqueChecks = 2,

            /// <summary>
            /// Prefix shortcut name with "Shortcut to..."
            /// </summary>
            PrefixShortcutTo = 4,

            /// <summary>
            /// Do not add the ".lnk" filename extension
            /// </summary>
            DoNotAddLNKFileExtension = 8,

            /// <summary>
            /// Use non-localised names for the file name
            /// </summary>
            UseNonLocalisedNames = 10,

            /// <summary>
            /// Use the ".url" filename extension for web urls
            /// </summary>
            UseURLFileExtension = 20
        }
    }
}
