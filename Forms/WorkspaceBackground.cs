using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using AquariusShell.ConfigurationManagement;
using AquariusShell.ConfigurationManagement.Settings;
using AquariusShell.Modules;
using AquariusShell.Runtime;

namespace AquariusShell.Forms
{
    /// <summary>
    /// Essentially the "desktop background"
    /// </summary>
    public partial class WorkspaceBackground : Form
    {

        /// <summary>
        /// Timer tick event. Shift images if required
        /// </summary>
        private async void backgroundChangerTimer_Tick(object sender, EventArgs e)
        {
            // the next tick should occur as per change interval
            backgroundChangerTimer.Stop();
            if ((!_settings.ShowBackgroundImage) || (_backgroundProvider == null))
            {
                this.BackgroundImage = null;
                return;
            }

            Image? image = await _backgroundProvider.RefreshOrGetNext();
            if (image != null)
            {
                this.BackgroundImage = image;

                // delete existing caches
                foreach(string cached in Directory.EnumerateFiles(ShellEnvironment.CacheDirectory, "desktop.*", SearchOption.TopDirectoryOnly))
                {
                    File.Delete(cached);
                }

                image.Save(Path.Combine(ShellEnvironment.CacheDirectory, $"desktop.{image.Tag!}"));
                Application.DoEvents();
            }

            backgroundChangerTimer.Interval = (int)TimeSpan.FromSeconds(_settings.BackgroundImageChangeInterval).TotalMilliseconds;
            backgroundChangerTimer.Start();
        }

        /// <summary>
        /// Form's DragEnter event. If user is dragging in a picture (PNG and JPEG only!), then 
        /// we change effects to indicate they can drop it on to us.
        /// </summary>
        private void WorkspaceBackground_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.Data != null) && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string? path = ((string[]?)e.Data.GetData(DataFormats.FileDrop))?[0];
                string? fileExtension = Path.GetExtension(path)?.ToLowerInvariant();
                if ((!string.IsNullOrWhiteSpace(path)) && _acceptableImageExtensions.Any(a => a.Equals(fileExtension)))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        /// <summary>
        /// Form's DragDrop event. If the user had dragged on a picture (PNG and JPEG only!), 
        /// we show that picture as the background, replacing whatever was shown earlier
        /// </summary>
        private void WorkspaceBackground_DragDrop(object sender, DragEventArgs e)
        {
            if ((e.Data != null) && (e.Effect == DragDropEffects.Copy))
            {
                string? path = ((string[]?)e.Data.GetData(DataFormats.FileDrop))?[0];
                string? fileExtension = Path.GetExtension(path)?.ToLowerInvariant();
                if ((!string.IsNullOrWhiteSpace(path)) && _acceptableImageExtensions.Any(a => a.Equals(fileExtension)))
                {
                    Image? pic = Image.FromFile(path);
                    if (pic != null)
                    {
                        this.BackgroundImage = pic;

                        // Timer is disabled if there is a custom-dropped image. 
                        // This will change only if the shell is restarted or the config refreshed, 
                        // because we have no other way for the user to signal to us to continue the previous carousel if any!
                        backgroundChangerTimer.Stop();
                    }
                }
            }
        }

        /// <summary>
        /// Form shown event. This form is shown only ONCE, so we can do a lot of "first-time only" things here!
        /// </summary>
        private void WorkspaceBackground_Shown(object sender, EventArgs e)
        {
            int taskbarHeight = Taskbar.CalcHeight(ShellEnvironment.ConfiguredSizeOfIcons);
            _taskbar.Size = new Size(ShellEnvironment.WorkareaBounds.Width, taskbarHeight);
            _taskbar.Location = new Point(0, ShellEnvironment.WorkareaBounds.Bottom - taskbarHeight - 9);
            _taskbar.Show(this);

            ShellEnvironment.TaskbarBounds = _taskbar.Bounds;

            // set ourselves as the bottom-most
            Modules.Windows.SetWorkareaAsBackgroundWindow(this.Handle, this.Size.Width, this.Size.Height);

            Rectangle newWorkArea = new()
            {
                Location = this.Location,
                Size = this.Size
            };
            Modules.Windows.SetWorkareaBounds(newWorkArea);

            // Now is a good time to get rid of the splash screen?
            if (_splashInstance != null)
            {
                _splashInstance.Close();

                try
                {
                    _splashInstance.Dispose();
                }
                catch { /* Eat if we get an ObjectDisposed exception */}
                _splashInstance = null;
            }
        }

        /// <summary>
        /// Though the form cannot be resized by the user, the screen res or monitor itself may be changed. 
        /// Update the global workarea bounds if that happens.
        /// </summary>
        private void WorkspaceBackground_ResizeEnd(object sender, EventArgs e)
        {
            ShellEnvironment.WorkareaBounds = this.Bounds;
        }

        /// <summary>
        /// Initialise
        /// </summary>
        /// <param name="splashInstance">Instance of the loaded and running Splash form (shown by Program.cs)</param>
        public WorkspaceBackground(Splash splashInstance)
        {
            InitializeComponent();

            _splashInstance = splashInstance;
            _loadedCacheFilePath = string.Empty;

            _settings = ConfigurationProvider<WorkspaceAreaSettings>.Get(true);
            ConfigurationProvider<WorkspaceAreaSettings>.ConfigurationUpdated += ConfigurationProvider_ConfigurationUpdated;

            this.BackColor = _settings.BackgroundColour;
            ShowCachedBackgroundImageIfExists();            

            ShellEnvironment.WorkArea = this;
            _taskbar = new();

            InitialiseBackgroundImageCarousel();
        }

        /// <summary>
        /// Initialise the background images system
        /// </summary>
        private void InitialiseBackgroundImageCarousel()
        {
            if (backgroundChangerTimer.Enabled)
            {
                backgroundChangerTimer.Enabled = false;
                backgroundChangerTimer.Stop();
            }

            if (_settings.ShowBackgroundImage)
            {
                switch (_settings.BackgroundImagesSource)
                {
                    case ConfigurationManagement.Constants.BackgroundImagesSourcesEnum.WebService:
                        if (_settings.BackgroundImageLocation.StartsWith("https://www.bing.com/HPImageArchive.aspx"))
                        {
                            _backgroundProvider = new BingImagesProvider()
                            {
                                ImageStoreLocation = _settings.BackgroundImageLocation
                            };
                        }
                        break;

                    case ConfigurationManagement.Constants.BackgroundImagesSourcesEnum.LocalFolder:
                        _backgroundProvider = new LocalFolderImagesProvider()
                        {
                            ImageStoreLocation = _settings.BackgroundImageLocation
                        };
                        break;
                }

                // This interval is only for the FIRST show, not the refresh cycle!
                backgroundChangerTimer.Interval = (int)TimeSpan.FromSeconds(3).TotalMilliseconds;
                backgroundChangerTimer.Enabled = true;
                backgroundChangerTimer.Start();
            }
            else
            {
                this.BackgroundImage = null;
            }
        }

        /// <summary>
        /// If settings allow it and a cached background image exists, then load that.
        /// </summary>
        private void ShowCachedBackgroundImageIfExists()
        {
            if (_settings.ShowBackgroundImage)
            {
                // check if we have a cached background. If we do, load it!
                string cachedBackground = Path.Combine(ShellEnvironment.CacheDirectory, "desktop.jpg");
                if (!File.Exists(cachedBackground))
                {
                    cachedBackground = Path.Combine(ShellEnvironment.CacheDirectory, "desktop.png");
                }

                if (File.Exists(cachedBackground))
                {
                    // we want to be able to replace the picture in our timer event later,
                    // so create a temporary copy
                    _loadedCacheFilePath = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(cachedBackground));
                    File.Copy(cachedBackground, _loadedCacheFilePath, true);

                    this.BackgroundImage = Image.FromFile(_loadedCacheFilePath);
                    Application.DoEvents();
                }
            }
        }


        /// <summary>
        /// Configuration updated event
        /// </summary>
        /// <param name="updatedSettings">Updated copy of settings</param>
        private void ConfigurationProvider_ConfigurationUpdated(IAquariusShellSettings updatedSettings)
        {
            _settings = (WorkspaceAreaSettings)updatedSettings;

            // Refresh what needs to be
            InitialiseBackgroundImageCarousel();
        }

        private WorkspaceAreaSettings _settings;
        private Splash? _splashInstance;
        private readonly Taskbar _taskbar;

        private string _loadedCacheFilePath;
        private IBackgroundImageProvider? _backgroundProvider;
        private readonly List<string> _acceptableImageExtensions = new() { ".png", ".jpg", ".jpeg" };
        
    }
}
