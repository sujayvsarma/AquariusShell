using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Operations on the file system (disks, folders, drives)
    /// </summary>
    internal static class Filesystem
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
        /// Checks if the given directory has at least ONE of the given attributes
        /// </summary>
        /// <param name="directory">DirectoryInfo</param>
        /// <param name="attributes">Attributes to check for</param>
        /// <returns>True if atleast one was found</returns>
        public static bool HasAnyOf(this DirectoryInfo directory, params FileAttributes[] attributes)
        {
            foreach(FileAttributes attr in attributes )
            {
                if (directory.Attributes.HasFlag(attr))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if the given file has at least ONE of the given attributes
        /// </summary>
        /// <param name="file">FileInfo</param>
        /// <param name="attributes">Attributes to check for</param>
        /// <returns>True if atleast one was found</returns>
        public static bool HasAnyOf(this FileInfo file, params FileAttributes[] attributes)
        {
            foreach (FileAttributes attr in attributes)
            {
                if (file.Attributes.HasFlag(attr))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if the given directory has ALL of the given attributes
        /// </summary>
        /// <param name="directory">DirectoryInfo</param>
        /// <param name="attributes">Attributes to check for</param>
        /// <returns>False if at least one was NOT found</returns>
        public static bool HasAllOf(this DirectoryInfo directory, params FileAttributes[] attributes)
        {
            foreach (FileAttributes attr in attributes)
            {
                if (!directory.Attributes.HasFlag(attr))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the given file has at least ONE of the given attributes
        /// </summary>
        /// <param name="file">FileInfo</param>
        /// <param name="attributes">Attributes to check for</param>
        /// <returns>False if at least one was NOT found</returns>
        public static bool HasAllOf(this FileInfo file, params FileAttributes[] attributes)
        {
            foreach (FileAttributes attr in attributes)
            {
                if (!file.Attributes.HasFlag(attr))
                {
                    return false;
                }
            }

            return true;
        }



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
        extern static bool SHGetNewLinkInfo(string linkTargetPath, string pathWhereShortcutWillBeStored, out StringBuilder proposedShortcutName, out bool duplicateShortcut, uint flags);

        /// <summary>
        /// Flags for SHGetNewLinkInfo()
        /// </summary>
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
