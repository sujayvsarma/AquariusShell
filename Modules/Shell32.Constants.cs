
namespace AquariusShell.Modules
{
    /// <summary>
    /// Constants for Shell32
    /// </summary>
    internal static partial class Shell32
    {
        /// <summary>
        /// Verbs used to execute/launch files or programs
        /// </summary>
        public enum ShellExecuteVerbsEnum
        {
            /// <summary>
            /// Don't send a verb
            /// </summary>
            None,

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
            Properties, 

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
