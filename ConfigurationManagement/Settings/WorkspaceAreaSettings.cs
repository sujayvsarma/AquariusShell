using System;
using System.Drawing;

using AquariusShell.ConfigurationManagement.Constants;
using AquariusShell.ConfigurationManagement.Reflection;

namespace AquariusShell.ConfigurationManagement.Settings
{
    /// <summary>
    /// Settings for the workspace area (desktop background)
    /// </summary>
    /// <remarks>
    ///     In a future version when we add virtual desktop support, this should be "per desktop", 
    ///     allowing us to have different settings for different desktops :-)
    /// </remarks>
    [RegistryKeyName("WorkspaceArea")]
    internal class WorkspaceAreaSettings : IAquariusShellSettings
    {
        /// <summary>
        /// Desktop's background colour when no image is displayed
        /// </summary>
        [RegistryValueName("BackgroundColour")]
        public Color BackgroundColour
        {
            get; set;

        } = Color.SteelBlue;

        /// <summary>
        /// When set, shows a background image. See further 'Background...' settings to identify what is shown.
        /// </summary>
        [RegistryValueName("ShowBackgroundImage")]
        public bool ShowBackgroundImage
        {
            get; set;

        } = true;

        /// <summary>
        /// Source folder or API URL for background images
        /// </summary>
        [RegistryValueName("BackgroundImagesSource")]
        public BackgroundImagesSourcesEnum BackgroundImagesSource
        {
            get; set;

        } = BackgroundImagesSourcesEnum.WebService;

        /// <summary>
        /// Interval in SECONDS between background image changes.
        /// </summary>
        [RegistryValueName("BackgroundImageChangeInterval")]
        public int BackgroundImageChangeInterval
        {
            get; set;

        } = (int)TimeSpan.FromHours(24).TotalSeconds;

        /// <summary>
        /// The actual folder or API URL from where to retrieve the images
        /// </summary>
        [RegistryValueName("BackgroundImageLocation")]
        public string BackgroundImageLocation
        {
            get; set;

        } = DEFAULT_BING_IMAGES_URL;

        /// <summary>
        /// Show the Windows Desktop's icons on our workarea. 
        /// Default: OFF
        /// </summary>
        [RegistryValueName("ShowWindowsDesktopIcons")]
        public bool ShowWindowsDesktopIcons
        {
            get; set;

        } = false;

        /// <summary>
        /// Url to Bing Images powered "wallpaper of the day"
        /// </summary>
        public static string DEFAULT_BING_IMAGES_URL = $"https://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1&mkt={System.Globalization.CultureInfo.CurrentUICulture.IetfLanguageTag}";
    }
}
