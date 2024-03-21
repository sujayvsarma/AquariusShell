using AquariusShell.ConfigurationManagement.Constants;
using AquariusShell.ConfigurationManagement.Reflection;
using AquariusShell.Modules;

namespace AquariusShell.ConfigurationManagement.Settings
{
    /// <summary>
    /// Settings related to icons across the Shell
    /// </summary>
    [RegistryKeyName("Icons")]
    internal class IconSettings : IAquariusShellSettings
    {
        /// <summary>
        /// Size of an icon
        /// </summary>
        [RegistryValueName("Size")]
        public IconSizesEnum Size
        {
            get; set;

        } = IconSizesEnum.x24;

        /// <summary>
        /// Display of captions
        /// </summary>
        [RegistryValueName("CaptionDisplay")]
        public IconCaptionDisplayEnum CaptionDisplay
        {
            get; set;

        } = IconCaptionDisplayEnum.Never;


        /// <summary>
        /// The caption text when no caption is available 
        /// and CaptionDisplay is set to something other than Never.
        /// </summary>
        [RegistryValueName("DefaultCaption")]
        public string DefaultCaption
        {
            get; set;

        } = "(Unknown)";
    }
}
