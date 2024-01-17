namespace AquariusShell.Modules
{
    /// <summary>
    /// Names of types of devices (that we have icons for in Windows resource files). 
    /// This is not exhaustive and only contains the items we ALLOW the user to see and configure
    /// </summary>
    public enum OobeDeviceTypeNamesEnum : uint
    {
        #region Drives

        /// <summary>
        /// 5.25" floppy disk
        /// </summary>
        FloppyDisk525,

        /// <summary>
        /// 3.5" floppy disk
        /// </summary>
        FloppyDisk35,

        /// <summary>
        /// ZIP drive
        /// </summary>
        ZipDrive,

        /// <summary>
        /// Network-folder mapped drive
        /// </summary>
        NetworkDrive,

        /// <summary>
        /// Disconnected network-mapped drive
        /// </summary>
        DisconnectedDrive,

        /// <summary>
        /// Optical drive
        /// </summary>
        OpticalDrive,

        /// <summary>
        /// RAM disk
        /// </summary>
        RAMDrive,

        /// <summary>
        /// A drive that supports cards such as the SD card
        /// </summary>
        CardDrive,

        #endregion

        #region Printers and Fax Machines

        /// <summary>
        /// Printer
        /// </summary>
        Printer,

        /// <summary>
        /// Default printer
        /// </summary>
        DefaultPrinter,

        /// <summary>
        /// Scanner
        /// </summary>
        Scanner,

        /// <summary>
        /// Fax machine
        /// </summary>
        FaxMachine,

        /// <summary>
        /// A device that may have a printer and scanner
        /// </summary>
        MultifunctionPrintAndScanDevice,

        /// <summary>
        /// Still camera (when you connect still cameras for file copy)
        /// </summary>
        StillCamera,

        /// <summary>
        /// Video-capable camera (also webcams)
        /// </summary>
        VideoCamera,

        /// <summary>
        /// Web cam
        /// </summary>
        Webcamera,

        #endregion

        #region Network devices

        /// <summary>
        /// Modem
        /// </summary>
        Modem,

        /// <summary>
        /// Device that holds a telecom SIM
        /// </summary>
        SimDevice,

        /// <summary>
        /// A dongle that provides network connectivity (usually mobile or Wi-Fi)
        /// </summary>
        NetworkDongle,

        /// <summary>
        /// Wired (LAN) network
        /// </summary>
        WiredNetwork,

        /// <summary>
        /// Wireless (Wi-Fi) network
        /// </summary>
        WirelessNetwork,

        /// <summary>
        /// Mobile network (through a SIM or dongle)
        /// </summary>
        MobileNetwork,

        #endregion

        #region Sound devices

        /// <summary>
        /// Speakers
        /// </summary>
        Speaker,

        /// <summary>
        /// Set of headphones, without a microphone (or unknown)
        /// </summary>
        Headphone,

        /// <summary>
        /// A standalone microphone
        /// </summary>
        Microphone,

        /// <summary>
        /// Set of headphone with a microphone attached or built-in
        /// </summary>
        HeadphoneWithMicrophone,

        #endregion
    }

}
