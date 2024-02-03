using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Windows.Forms;

using AquariusShell.Modules;
using AquariusShell.Objects;
using AquariusShell.Runtime;

using SujaySarma.Sdk.RestApi;

namespace AquariusShell.Forms
{
    /// <summary>
    /// Essentially the "desktop background"
    /// </summary>
    public partial class WorkspaceBackground : Form
    {
        public WorkspaceBackground()
        {
            InitializeComponent();

            _loadedCacheFilePath = string.Empty;

            // check if we have a cached background. If we do, load it!
            string cachedBackground = Path.Combine(ShellEnvironment.CacheDirectory, "desktop.jpg");
            if (!File.Exists(cachedBackground))
            {
                cachedBackground = Path.Combine(ShellEnvironment.CacheDirectory, "desktop.png");
            }

            if (File.Exists(cachedBackground))
            {
                // we want to be able to replace the picture in our timer event below,
                // so create a temporary copy
                _loadedCacheFilePath = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(cachedBackground));
                File.Copy(cachedBackground, _loadedCacheFilePath, true);

                this.BackgroundImage = Image.FromFile(_loadedCacheFilePath);
                Application.DoEvents();
            }

            ShellEnvironment.WorkArea = this;
            _taskbar = new();
            _bingApiClient = new()
            {
                RequestTimeout = 30,
                RequestUri = new Uri($"https://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1&mkt={System.Globalization.CultureInfo.CurrentUICulture.IetfLanguageTag}")
            };
        }

        private async void backgroundChangerTimer_Tick(object sender, EventArgs e)
        {
            // the next tick should occur 30 mins from now
            backgroundChangerTimer.Stop();
            backgroundChangerTimer.Interval = (int)TimeSpan.FromMinutes(30).TotalMilliseconds;

            HttpResponseMessage bingApiResponse = await _bingApiClient.Get();
            if ((bingApiResponse != null) && (bingApiResponse.StatusCode == System.Net.HttpStatusCode.OK))
            {
                try
                {
                    BingImagesApiResponse? bingApiResponseDecoded = await JsonSerializer.DeserializeAsync<BingImagesApiResponse>(bingApiResponse.Content.ReadAsStream());
                    if ((bingApiResponseDecoded != null) && (bingApiResponseDecoded.Images.Count > 0) && (!_lastImagePath.Equals(bingApiResponseDecoded.Images[0].Url)))
                    {
                        _httpClient = new()
                        {
                            Timeout = TimeSpan.FromSeconds(10)
                        };

                        try
                        {
                            HttpResponseMessage imageResourceLoadResponse = await _httpClient.GetAsync($"https://www.bing.com{bingApiResponseDecoded.Images[0].Url}");
                            if ((imageResourceLoadResponse != null) && (imageResourceLoadResponse.StatusCode == System.Net.HttpStatusCode.OK))
                            {
                                Image? pic = Image.FromStream(imageResourceLoadResponse.Content.ReadAsStream());
                                if (pic != null)
                                {
                                    this.BackgroundImage = pic;
                                    Application.DoEvents();

                                    // cache it for next load
                                    // obviously we are expecting only jpg and png images to come down off Bing...
                                    string fileExtension = ((imageResourceLoadResponse.Content.Headers.ContentType?.MediaType == "image/jpeg") ? "jpg" : "png");

                                    // delete existing caches
                                    File.Delete(Path.Combine(ShellEnvironment.CacheDirectory, "desktop.jpg"));
                                    File.Delete(Path.Combine(ShellEnvironment.CacheDirectory, "desktop.png"));
#pragma warning disable CS8509
                                    pic.Save(
                                        Path.Combine(ShellEnvironment.CacheDirectory, $"desktop.{fileExtension}"),
                                        format: fileExtension switch
                                        {
                                            "jpg" => ImageFormat.Jpeg,
                                            "png" => ImageFormat.Png,
                                        }
                                    );
#pragma warning restore CS8509

                                    // only change this once everything is successful
                                    _lastImagePath = bingApiResponseDecoded.Images[0].Url;
                                }
                            }
                        }
                        catch
                        {
                            // timeouts usually. Doesnt matter.
                        }
                    }
                }
                catch
                {
                    // garbage responses? Doesnt matter
                }
            }

            backgroundChangerTimer.Start();
        }

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

                        _lastImagePath = path;
                        backgroundChangerTimer.Stop();
                    }
                }
            }
        }

        private void WorkspaceBackground_Shown(object sender, EventArgs e)
        {
            backgroundChangerTimer.Interval = (int)TimeSpan.FromSeconds(3).TotalMilliseconds;   // 3 seconds is good for things to load up a bit
            backgroundChangerTimer.Enabled = true;
            backgroundChangerTimer.Start();

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
        }

        private void WorkspaceBackground_ResizeEnd(object sender, EventArgs e)
        {
            ShellEnvironment.WorkareaBounds = this.Bounds;
        }

        private void WorkspaceBackground_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShellEnvironment.ClearHeavyCachesForExit();

            Rectangle newWorkArea = new()
            {
                Location = ShellEnvironment.PrimaryScreenSafe.Bounds.Location,
                Size = ShellEnvironment.PrimaryScreenSafe.Bounds.Size
            };
            Modules.Windows.SetWorkareaBounds(newWorkArea);
        }


        private Taskbar _taskbar;
        private List<string> _acceptableImageExtensions = new() { ".png", ".jpg", ".jpeg" };
        private string _lastImagePath = string.Empty, _loadedCacheFilePath;
        private RestApiClient _bingApiClient;
        private HttpClient? _httpClient = null;        
    }
}
