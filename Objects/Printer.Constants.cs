using System.ComponentModel.DataAnnotations;

namespace AquariusShell.Objects
{
    /// <summary>
    /// Constants used in printer definitions
    /// </summary>
    public partial class Printer
    {
        /// <summary>
        /// Type of printer
        /// </summary>
        public enum PrinterTypesEnum
        {
            /// <summary>
            /// Normal printer
            /// </summary>
            Regular = 0,

            /// <summary>
            /// Locally or network-shared printer
            /// </summary>
            Shared,

            /// <summary>
            /// Fax machine
            /// </summary>
            Fax,

            /// <summary>
            /// Remote, network printer
            /// </summary>
            Network
        }

        /// <summary>
        /// Status of printer
        /// </summary>
        public enum PrinterStatusEnum
        {
            /// <summary>
            /// Unknown
            /// </summary>
            [Display(Name = "Unknown")]
            Unknown = 0,

            /// <summary>
            /// In a working state
            /// </summary>
            [Display(Name = "Ready")]
            Ready,

            /// <summary>
            /// Active with error messages
            /// </summary>
            [Display(Name = "Ready, with errors")]
            ActiveWithErrors,

            /// <summary>
            /// Self-tests are in progress
            /// </summary>
            [Display(Name = "Self-test in progress...")]
            SelfTestInProgress,

            /// <summary>
            /// Performing a warm up (esp. Laser)
            /// </summary>
            [Display(Name = "Warming up...")]
            WarmingUp,

            /// <summary>
            /// Unavailable because it is switched off, offline or off duty
            /// </summary>
            [Display(Name = "Unavailable")]
            Unavailable,

            /// <summary>
            /// Reboot in progress
            /// </summary>
            [Display(Name = "Rebooting...")]
            Rebooting,

            /// <summary>
            /// Printer has been paused
            /// </summary>
            [Display(Name = "Paused")]
            JobsPaused,

            /// <summary>
            /// Not in a "ready" state
            /// </summary>
            [Display(Name = "Not ready")]
            OtherwiseNotReady,

            /// <summary>
            /// In a power-saving state
            /// </summary>
            [Display(Name = "Power saving mode")]
            InPowerSavingState,

            /// <summary>
            /// Services degraded
            /// </summary>
            [Display(Name = "Poor connection")]
            PoorNetworkConnectivity,

            /// <summary>
            /// Printer has requested paper be fed in manually 
            /// (problem with auto-feeds)
            /// </summary>
            [Display(Name = "Needs manual paper feed")]
            ManualPaperFeedRequested,

            /// <summary>
            /// Not installed
            /// </summary>
            [Display(Name = "Not installed")]
            NotInstalled,

            /// <summary>
            /// Has installation errors
            /// </summary>
            [Display(Name = "Reinstall me!")]
            NeedsReinstallation,

            /// <summary>
            /// Needs configuration to be performed
            /// </summary>
            [Display(Name = "Configure me!")]
            NeedsConfiguration,

            /// <summary>
            /// Printer has been uninstalled, but jobs are in progress
            /// </summary>
            [Display(Name = "Uninstalled. Waiting for jobs to complete...")]
            PendingDeletion,
        }

        /// <summary>
        /// Errors possible with a printer
        /// </summary>
        public enum PrinterErrorsEnum
        {
            /// <summary>
            /// Error state is not known
            /// </summary>
            [Display(Name = "Unknown")]
            Unknown = -1,

            /// <summary>
            /// No errors
            /// </summary>
            [Display(Name = "Ready")]
            NoError = 0,

            /// <summary>
            /// Low on paper
            /// </summary>
            [Display(Name = "Paper low")]
            PaperLow,

            /// <summary>
            /// No paper available in autoload bins
            /// </summary>
            [Display(Name = "Paper finished")]
            PaperOut,

            /// <summary>
            /// Low on toner/ink
            /// </summary>
            [Display(Name = "Ink/toner low")]
            TonerOrInkLow,

            /// <summary>
            /// Toner/ink is finished
            /// </summary>
            [Display(Name = "Ink/toner finished")]
            TonerOrInkOut,

            /// <summary>
            /// One or more of the printer's doors is open
            /// </summary>
            [Display(Name = "One or more doors open")]
            DoorOpen,

            /// <summary>
            /// Paper jam!
            /// </summary>
            [Display(Name = "Paper jammed!")]
            PaperJammed,

            /// <summary>
            /// Output tray is full
            /// </summary>
            [Display(Name = "Output tray is full")]
            OutTrayFull,

            /// <summary>
            /// Printer is offline
            /// </summary>
            [Display(Name = "Offline")]
            Offline,

            /// <summary>
            /// Servicing intervention required to repair or replace components
            /// </summary>
            [Display(Name = "Needs repairs")]
            ServicingRequired
        }
    }
}