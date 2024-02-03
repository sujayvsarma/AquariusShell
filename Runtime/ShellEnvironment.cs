using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

using AquariusShell.Forms;
using AquariusShell.Modules;
using AquariusShell.Objects;

namespace AquariusShell.Runtime
{
    /// <summary>
    /// Values we pickup and save for our own purposes
    /// </summary>
    internal static class ShellEnvironment
    {
        /// <summary>
        /// Get current user's SID
        /// </summary>
        public static string CurrentUserSID
        {
            get
            {
                if (_currentUserSid == null)
                {
                    SecurityIdentifier? sid = WindowsIdentity.GetCurrent().Owner;
                    if (sid != null)
                    {
                        _currentUserSid = sid.ToString();

                        if (sid.AccountDomainSid != null)
                        {
                            _currentUserSid = sid.AccountDomainSid.ToString();
                        }
                    }
                }

                return _currentUserSid;
            }
        }
        private static string? _currentUserSid = null;

        /// <summary>
        /// Directory where we can cache stuff
        /// </summary>
        public static string CacheDirectory
        {
            get
            {
                if (_cacheDirectory == null)
                {
                    _cacheDirectory = Path.Combine(Application.StartupPath, ".cache");
                    if (! Directory.Exists(_cacheDirectory))
                    {
                        Directory.CreateDirectory(_cacheDirectory);
                    }
                }
                return _cacheDirectory;
            }
        }
        private static string? _cacheDirectory = null;

        /// <summary>
        /// Directory where we can log stuff. Creates a new directory for every day.
        /// </summary>
        public static string LogDirectory
        {
            get
            {
                // cause a rollover if the date has changed
                if (DateOnly.FromDateTime(DateTime.Now) != _lastDate)
                {
                    _lastDate = DateOnly.FromDateTime(DateTime.Now);
                    _logDirectory = null;
                }

                if (_logDirectory == null)
                {
                    _lastDate = DateOnly.FromDateTime(DateTime.Now);
                    _logDirectory = Path.Combine(Application.StartupPath, ".logs", _lastDate.ToString("yyyy-mm-dd"));
                    if (!Directory.Exists(_logDirectory))
                    {
                        Directory.CreateDirectory(_logDirectory);
                    }
                }
                return _logDirectory;
            }
        }
        private static string? _logDirectory = null;
        private static DateOnly _lastDate;

        /// <summary>
        /// Verify that we have atleast one monitor
        /// </summary>
        public static bool HasAtleaseOneMonitor
            => (Screen.AllScreens.Length > 0);

        /// <summary>
        /// A non-null instance of PrimaryScreen. 
        /// </summary>
        public static Screen PrimaryScreenSafe => ((HasAtleaseOneMonitor && (Screen.PrimaryScreen != null)) ? Screen.PrimaryScreen : Screen.FromRectangle(new Rectangle(0, 0, 0, 0)));

        /// <summary>
        /// The location and size of the workarea.
        /// Set by the WorkspaceBackground form in its ResizeEnd [after resize is done] event
        /// </summary>
        public static Rectangle WorkareaBounds 
        {
            get => _waBounds;
            set
            {
                _waBounds = value;
                Win32Registry.Set("LocationsSizes", "Workarea", value.Stringify());
            } 
        }
        private static Rectangle _waBounds;

        /// <summary>
        /// The handle to the workarea's window
        /// </summary>
        public static WorkspaceBackground WorkArea { get; set; } = default!;

        /// <summary>
        /// The location and size of the taskbar.
        /// Set by the taskbar form in its ResizeEnd [after resize is done] & LocationChanged [when it is moved around] event
        /// </summary>
        public static Rectangle TaskbarBounds 
        { 
            get => _lBounds; 
            set
            {
                _lBounds = value;
                Win32Registry.Set("LocationsSizes", "Launcher", value.Stringify());
            }
        }
        private static Rectangle _lBounds;

        /// <summary>
        /// Sizes of icons. Can be configured.
        /// </summary>
        public static IconSizesEnum ConfiguredSizeOfIcons 
        { 
            get => _iconSz; 
            set
            {
                _iconSz = value;
                Win32Registry.Set("LocationsSizes", "IconSizes", value.ToString());
            }
        }
        private static IconSizesEnum _iconSz;

        /// <summary>
        /// Icon size dimension in pixels
        /// </summary>
        public static int ConfiguredSizeOfIconsInPixels
        {
            get
            {
                if (_iconDimension == 0)
                {
                    _iconDimension = ConfiguredSizeOfIcons switch
                    {
                        IconSizesEnum.x16 => 16,
                        IconSizesEnum.x24 => 24,
                        IconSizesEnum.x32 => 32,
                        IconSizesEnum.x64 => 64,

                        _ => 32 // default
                    };
                }

                return _iconDimension;
            }
        }
        private static int _iconDimension = 0;

        /// <summary>
        /// Cached list of shell apps (these cannot change without a change in ourselves)
        /// </summary>
        public static ShellAppsCache ShellApps
        {
            get
            {
                if (_shellApps == null)
                {
                    _shellApps = new();
                }

                return _shellApps;
            }
        }
        private static ShellAppsCache? _shellApps = null;

        /// <summary>
        /// Get a (cached) list of printers on system
        /// </summary>
        /// <param name="forceRefresh">If set, fetches information afresh</param>
        public static List<Printer> GetPrinters(bool forceRefresh = false)
        {
            if ((_printers.Count == 0) || forceRefresh)
            {
                // no Windows system will have zero printers!
                _printers = AquariusShell.Modules.Printers.GetLocalAndNetworkConnectedPrinters();
            }

            return _printers;
        }
        private static List<Printer> _printers = new();


        /// <summary>
        /// Key in the Windows registry where we store our settings
        /// </summary>
        public static string SHELL_REGISTRYKEY = "Software\\SujaySarma\\Shell";

        /// <summary>
        /// Clear all the heavy-weight caches we are holding on to, as we are about to terminate
        /// </summary>
        public static void ClearHeavyCachesForExit()
        {
            _shellApps = null;
            _printers.Clear();
            WorkArea = default!;
        }


        /// <summary>
        /// Initialise the static class
        /// </summary>
        static ShellEnvironment()
        {
            Screen defaultMonitor = PrimaryScreenSafe;

            // first load defaults. We are doing this into the backing variables as using the SETters will save the defaults into the REG!
            _iconSz = IconSizesEnum.x24;
            _waBounds = defaultMonitor.Bounds;

            int taskbarHeight = Taskbar.CalcHeight(IconSizesEnum.x24);
            _lBounds = new(
                    new Point(0, _waBounds.Bottom - taskbarHeight),
                    new Size(_waBounds.Width, taskbarHeight)
                );

            // now get the values stored in the registry and override the defaults:
            Rectangle temp = new();
            ((string)Win32Registry.Get("LocationsSizes", "Workarea", WorkareaBounds.Stringify())!).Unstringify(ref temp);
            ((string)Win32Registry.Get("LocationsSizes", "Launcher", TaskbarBounds.Stringify())!).Unstringify(ref temp);
            ConfiguredSizeOfIcons = Enum.Parse<IconSizesEnum>((string)Win32Registry.Get("LocationsSizes", "IconSizes", IconSizesEnum.x24.ToString())!);
        }
    }
}
