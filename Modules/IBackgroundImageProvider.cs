using System.Drawing;
using System.Threading.Tasks;

namespace AquariusShell.Modules
{

    /// <summary>
    /// Interface to be implemented by a module that provides images for the Shell's background
    /// </summary>
    internal interface IBackgroundImageProvider
    {
        /// <summary>
        /// Get the latest image to be shown
        /// </summary>
        /// <returns>Image with the picture to be displayed, or NULL if none found</returns>
        Task<Image?> RefreshOrGetNext();

        /// <summary>
        /// URI (Path or Url) to the location the images are to be retrieved from
        /// </summary>
        string ImageStoreLocation { get; set; }

    }
}
