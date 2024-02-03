

using System;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Constants to deal with Printers
    /// </summary>
    internal static partial class Printers
    {
        /// <summary>
        /// Printer attributes
        /// </summary>
        [Flags]
        public enum PrinterAttributesEnum : uint
        {
            None = 0,
            SpoolJobsBeforePrinting = 1,
            NoSpooling = 2,
            IsDefaultPrinter = 4,
            IsSharedPrinter = 8,
            IsNetworkPrinter = 16,
            IsHidden = 32,
            IsLocalPrinter = 64,
            HoldQueuedMismatchedDocuments = 128,
            KeepJobsAfterPrinting = 256,
            CompleteSpooledBeforeUnspooledJobs = 512,
            CanWorkOffline = 1024,
            BidiPrinting = 2048,
            MustSpoolRawJobs = 4096,
            IsActiveDirectoryPublishedPrinter = 8192,
            IsFaxPrinter = 16384,
            IsRedirectedTerminalServerPrinter = 32768
        }

        /// <summary>
        /// Status of a printer
        /// </summary>
        public enum PrinterStatusEnum : uint
        {
            Other = 1,
            Unknown = 2,
            Running = 3,
            HasWarnings = 4,
            SelfTestMode = 5,
            NotApplicable = 6,
            PoweredOff = 7,
            Offline = 8,
            OffDuty = 9,
            Degraded = 10,
            NotInstalled = 11,
            InstallationError = 12,
            PowerSaveEnteredCurrentlyUnknown = 13,
            PowerSaveLowPower = 14,
            PowerSaveStandby = 15,
            Rebooting = 16,
            PowerSaveWithWarnings = 17,
            Paused = 18,
            NotReady = 19,
            NotConfigured = 20,
            QuietMode = 21
        }


        /// <summary>
        /// Error states of a printer
        /// </summary>
        public enum PrinterErrorsEnum : ushort
        {
            Unknown = 0,
            Other,
            NoError,
            LowPaper,
            PaperOut,
            LowToner,
            TonerOut,
            DoorOpen,
            PaperJammed,
            Offline,
            ServicingRequired,
            OutTrayFull
        }
    }
}