using System.Text.Json.Serialization;

namespace AquariusShell.ConfigurationManagement.Settings
{
    /// <summary>
    /// A custom button that is displayed somewhere...
    /// </summary>
    /// <remarks>
    ///     This is not a true "Settings" class. It is used a Property/type within other settings.
    /// </remarks>
    public class CustomButtonSettings
    {
        /// <summary>
        /// Path to the icon to be displayed on the button. 
        /// Can be any Windows supported picture format.
        /// </summary>
        [JsonPropertyName("icon")]
        public string? IconPath
        {
            get; set;

        } = null;

        /// <summary>
        /// Caption to be displayed on the button
        /// </summary>
        [JsonPropertyName("caption")]
        public string? Caption
        {
            get; set;

        } = null;

        /// <summary>
        /// The Shell command or a recognisable Windows command or the absolute path to an executable.
        /// </summary>
        [JsonPropertyName("command")]
        public string Command
        {
            get; set;

        } = string.Empty;

    }
}
