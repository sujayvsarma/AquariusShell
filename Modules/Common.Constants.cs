

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

using AquariusShell.Objects;

namespace AquariusShell.Modules
{

    /// <summary>
    /// Sizes of icons
    /// </summary>
    public enum IconSizesEnum : int
    {
        /// <summary>
        /// 16x16
        /// </summary>
        x16 = 16,

        /// <summary>
        /// 24x24
        /// </summary>
        x24 = 24,

        /// <summary>
        /// 32x32
        /// </summary>
        x32 = 32,

        /// <summary>
        /// 64x64
        /// </summary>
        x64 = 64
    }

    /// <summary>
    /// Actions related to Windows termination
    /// </summary>
    public enum WindowsShutdownActions
    {
        /// <summary>
        /// Exit Aquarius Shell, to a blank/black screen!
        /// </summary>
        [Display(Name = "Exit Aquarius Shell")]
        SimpleExit = 0,

        /// <summary>
        /// Exit Aquarius Shell and start Explorer with Explorer as the shell
        /// </summary>
        [Display(Name = "Switch to Windows Explorer shell")]
        SwitchToExplorer,

        /// <summary>
        /// Log off
        /// </summary>
        [Display(Name = "Log out")]
        LogOff,

        /// <summary>
        /// Reboot windows
        /// </summary>
        [Display(Name = "Reboot the computer")]
        Reboot,

        /// <summary>
        /// Shutdown windows
        /// </summary>
        [Display(Name = "Shutdown the computer")]
        Shutdown,

        /// <summary>
        /// Hibernate or sleep
        /// </summary>
        [Display(Name = "Hibernate or Sleep")]
        Suspend,

        /// <summary>
        /// Lock the computer
        /// </summary>
        [Display(Name = "Lock the computer")]
        Lock,
    }

    /// <summary>
    /// Method to check flags
    /// </summary>
    internal enum FlagCheckMethodEnum
    {
        /// <summary>
        /// A single flag needs to match
        /// </summary>
        AnyOf = 0,

        /// <summary>
        /// All flags must match
        /// </summary>
        AllOf = 1
    }

    /// <summary>
    /// Constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// All known Windows 10 control panel items
        /// </summary>
        public static readonly List<NameValuePair<string>> ALL_WINDOWS10_CONTROLPANEL_ITEMS = new()
        {
            new("About Windows", "shell32.dll,ShellAbout"),
            new("Add network location (wizard)", $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System),"shwebsvc.dll")},AddNetPlaceRunDll"),
            new("Add printer (wizard)", "shell32.dll,SHHelpShortcuts_RunDLL AddPrinter"),
            new("Add standard TCP/IP printer port (wizard)", "tcpmonui.dll,LocalAddPortUI"),
            new("Date and time", "shell32.dll,Control_RunDLL timedate.cpl"),
            new("Show/manage additional clocks", "shell32.dll,Control_RunDLL timedate.cpl,,1"),
            new("Desktop icons", "shell32.dll,Control_RunDLL desk.cpl,,0"),
            new("Device installation", $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System),"newdev.dll")},DeviceInternetSettingUi"),
            new("Device manager", "devmgr.dll DeviceManager_Execute"),
            new("Display", "shell32.dll,Control_RunDLL desk.cpl"),
            new("Ease of access (accessibility)", "shell32.dll,Control_RunDLL access.cpl"),
            new("Environment variables", "sysdm.cpl,EditEnvironmentVariables"),
            new("Windows explorer options", "shell32.dll,Options_RunDLL 0"),
            new("Fonts", "shell32.dll,SHHelpShortcuts_RunDLL FontsFolder"),
            new("Forgot password (wizard, needs a USB drive)", "keymgr.dll,PRShowSaveWizardExW"),
            new("Game controllers", "shell32.dll,Control_RunDLL joy.cpl"),
            new("File indexing", "shell32.dll,Control_RunDLL srchadmin.dll"),
            new("Infrared", "shell32.dll,Control_RunDLL irprops.cpl"),
            new("Internet explorer (legacy!)", "shell32.dll,Control_RunDLL inetcpl.cpl"),
            new("Keyboard", "shell32.dll,Control_RunDLL main.cpl @1"),
            new("Map network drive (wizard)", "shell32.dll,SHHelpShortcuts_RunDLL Connect"),
            new("Mouse", "shell32.dll,Control_RunDLL main.cpl"),
            new("Network connections", "shell32.dll,Control_RunDLL ncpa.cpl"),
            new("ODBC Datasources", "shell32.dll,Control_RunDLL odbccp32.cpl"),
            new("Offline files", "shell32.dll,Control_RunDLL cscui.dll"),
            new("Pen and touch", "shell32.dll,Control_RunDLL tabletpc.cpl"),
            new("Desktop background", "shell32.dll,Control_RunDLL desk.cpl,,2"),
            new("Power", "shell32.dll,Control_RunDLL powercfg.cpl"),
            new("Printers", "shell32.dll,SHHelpShortcuts_RunDLL PrintersFolder"),
            new("Programs and features", "shell32.dll,Control_RunDLL appwiz.cpl,,0"),
            new("Regional settings", "shell32.dll,Control_RunDLL intl.cpl"),
            new("Eject hardware", "shell32.dll,Control_RunDLL hotplug.dll"),
            new("Screensaver", "shell32.dll,Control_RunDLL desk.cpl,,1"),
            new("Security and maintenance", "shell32.dll,Control_RunDLL wscui.cpl"),
            new("Program defaults", "shell32.dll,Control_RunDLL appwiz.cpl,,3"),
            new("Network setup", "shell32.dll,Control_RunDLL netsetup.cpl"),
            new("Sound playback", "shell32.dll,Control_RunDLL mmsys.cpl,,0"),
            new("Sound recording", "shell32.dll,Control_RunDLL mmsys.cpl,,1"),
            new("System sounds", "shell32.dll,Control_RunDLL mmsys.cpl,,2"),
            new("Microphone and speaker for taking calls", "shell32.dll,Control_RunDLL mmsys.cpl,,3"),
            new("Speech", $"shell32.dll,Control_RunDLL {Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "Speech", "SpeechUX", "sapi.cpl")},,1"),
            new("Windows Start", "shell32.dll,Options_RunDLL 3"),
            new("Passwords", "keymgr.dll,KRShowKeyMgr"),
            new("View or change computer name, workgroup/domain", "shell32.dll,Control_RunDLL sysdm.cpl,,1"),
            new("System properties (Advanced)", "shell32.dll,Control_RunDLL sysdm.cpl,,3"),
            new("System protection (Restore points)", "shell32.dll,Control_RunDLL sysdm.cpl,,4"),
            new("Remote desktop and remote access", "shell32.dll,Control_RunDLL sysdm.cpl,,5"),
            new("Windows taskbar", "shell32.dll,Options_RunDLL 1"),
            new("Text and input languages", "shell32.dll,Control_RunDLL input.dll,,{C07337D3-DB2C-4D0B-9A93-B722A6C106E2}"),
            new("User accounts", "shell32.dll,Control_RunDLL nusrmgr.cpl"),
            new("Windows features", "shell32.dll,Control_RunDLL appwiz.cpl,,2"),
            new("Windows firewall", "shell32.dll,Control_RunDLL firewall.cpl"),
            new("Windows To Go - startup options", "pwlauncher.dll,ShowPortableWorkspaceLauncherConfigurationUX")
        };
    }
}

