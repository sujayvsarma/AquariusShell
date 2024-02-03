using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AquariusShell.Objects
{
    /// <summary>
    /// Container response from the Bing image of the day web service
    /// </summary>
    public class BingImagesApiResponse
    {
        /// <summary>
        /// Array of images. Requesting just IOD will return only one element in this.
        /// </summary>
        [JsonPropertyName("images")]
        public List<ImageMetadata> Images { get; set; } = new();
    }

    /// <summary>
    /// A single entry in the "images" array of <see cref="BingImagesApiResponse"/>
    /// </summary>
    public class ImageMetadata
    {
        /// <summary>
        /// Url to the image
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Copyright message
        /// </summary>
        [JsonPropertyName("copyright")]
        public string Copyright { get; set; } = string.Empty;

        /// <summary>
        /// Url to the copyright notice on the web
        /// </summary>
        [JsonPropertyName("copyrightlink")]
        public string CopyrightLink { get; set; } = string.Empty;

        /// <summary>
        /// Title or name of the image
        /// </summary>
        [JsonPropertyName("title")]
        public string title { get; set; } = string.Empty;

    }
}
