using System;
using System.ComponentModel.DataAnnotations;

namespace AquariusShell.ConfigurationManagement.Constants
{
    /// <summary>
    /// The kind of events that would be logged into the log file
    /// </summary>
    [Flags]
    public enum LogEventsEnumFlags : int
    {
        /// <summary>
        /// No events
        /// </summary>
        [Display(Name = "None", Description = "No events")]
        None = 0,

        /// <summary>
        /// Perform log entry before something is attempted
        /// </summary>
        [Display(Name = "Before event", Description = "Before an action is attempted")]
        BeforeEvent = 1,

        /// <summary>
        /// Perform log entry after something is attempted
        /// </summary>
        [Display(Name = "After event", Description = "After an action has been attempted")]
        AfterEvent = 2,

        /// <summary>
        /// Log successful operation
        /// </summary>
        [Display(Name = "Operation success", Description = "Successful operations")]
        OperationSuccess = 4,

        /// <summary>
        /// Log operation failures (errors)
        /// </summary>
        [Display(Name = "Operation failure", Description = "Failed operations")]
        OperationFailure = 8,

        /// <summary>
        /// Launches of an app
        /// </summary>
        [Display(Name = "Application launch", Description = "Launching any app, program, file or Url")]
        AppLaunch = 256,

        /// <summary>
        /// That an application is alive
        /// </summary>
        [Display(Name = "Application run duration", Description = "Duration an application was running")]
        AppAliveTime = 512,

        /// <summary>
        /// That an application was in focus (in foreground)
        /// </summary>
        [Display(Name = "Application active usage duration", Description = "Duration an application was actively being used")]
        AppInFocusTime = 1024,

        /// <summary>
        /// That an app was removed from focus (sent to back, minimised, closed)
        /// </summary>
        [Display(Name = "Application backgrounding attempts", Description = "Actions that cause an app or program to lose focus (minimise, go behind other apps, etc)")]
        AppOutOfFocusEvents = 2048,

        /// <summary>
        /// A drive, directory or folder was accessed. 
        /// (Directly by the user)
        /// </summary>
        [Display(Name = "Drive, directory or file access", Description = "Accessing any filesystem location directly")]
        FilesystemLocationAccess = 4096,

        /// <summary>
        /// File/directory was copied
        /// </summary>
        [Display(Name = "File or directory copy", Description = "Copying a file or directory")]
        ObjectCopy = 8192,

        /// <summary>
        /// File/directory moved
        /// </summary>
        [Display(Name = "File or directory move", Description = "Moving a file or directory")]
        ObjectMove = 16384,

        /// <summary>
        /// File/directory deleted
        /// </summary>
        [Display(Name = "File or directory deletion", Description = "Delete a file or directory")]
        ObjectDelete = 32768,

        /// <summary>
        /// Deleted items was cleared
        /// </summary>
        [Display(Name = "Deleted items cleared", Description = "Clearing the Deleted Items collection")]
        DeletedItemsCleared = 65536,

        /// <summary>
        /// Unsecure file was unblocked
        /// </summary>
        [Display(Name = "Unblocking at risk files", Description = "Unblocking files downloaded from the internet")]
        UnsecureFileUnblocked = 131072,

        /// <summary>
        /// Directory/file attributes changed
        /// </summary>
        [Display(Name = "File attributes changed", Description = "Changing directory or file attributes")]
        AttributesChanged = 262144,

        /// <summary>
        /// Directory/file security changed
        /// </summary>
        [Display(Name = "Directory or file security changed", Description = "Modifying permissions on a directory or file")]
        SecurityChanged = 524288,

        /// <summary>
        /// Switched to Windows Explorer
        /// </summary>
        [Display(Name = "Switch to Windows Explorer Shell", Description = "Changing the default shell as Windows Explorer")]
        SwitchToWindowsExplorer = 268435456,

        /// <summary>
        /// System reboot
        /// </summary>
        [Display(Name = "System reboot", Description = "Rebooting the computer")]
        ShellExitReboot = 536870912,

        /// <summary>
        /// System shutdown
        /// </summary>
        [Display(Name = "System shutdown", Description = "Shutting down the computer")]
        ShellExitShutdown = 1073741824,

        /// <summary>
        /// Simple shell exit
        /// </summary>
        [Display(Name = "Shell exit", Description = "Exiting this shell")]
        ShellExitSimple = 2147483646
    }


}
