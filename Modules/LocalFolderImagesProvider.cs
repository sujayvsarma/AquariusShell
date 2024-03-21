using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Retrieve images from a local (or network) folder
    /// </summary>
    internal class LocalFolderImagesProvider : IBackgroundImageProvider
    {

        /// <summary>
        /// Get the latest image to be shown
        /// </summary>
        /// <returns>Image with the picture to be displayed, or NULL if none found</returns>
        public async Task<Image?> RefreshOrGetNext()
        {
            if (_imagesCache.Count == 0)
            {
                return null;
            }

            if (_imagesCache.Count == 1)
            {
                return Image.FromStream(File.Open(_imagesCache[0], new FileStreamOptions() { Access = FileAccess.Read, Share = FileShare.Read }));
            }

            int rnd = RandomNumberGenerator.GetInt32(0, _imagesCache.Count);

            Image image;
            try
            {
                image = Image.FromStream(File.Open(_lastImagePath, new FileStreamOptions() { Access = FileAccess.Read, Share = FileShare.Read }));
                image.Tag = Path.GetExtension(_lastImagePath).Trim('.');

                _lastImagePath = _imagesCache[rnd];
            }
            catch
            {
                image = Image.FromStream(File.Open(_lastImagePath, new FileStreamOptions() { Access = FileAccess.Read, Share = FileShare.Read }));
                image.Tag = Path.GetExtension(_lastImagePath).Trim('.');
            }

            // Simply to insist that this method is async. :-(
            await Task.Delay(1);

            return image;
        }

        /// <summary>
        /// URI (Path or Url) to the location the images are to be retrieved from
        /// </summary>
        public string ImageStoreLocation
        {
            get => _rootDirectoryPath;
            set
            {
                // could be a directory or a single file
                if (Directory.Exists(value) || (File.Exists(value) && _acceptableImageExtensions.Contains(Path.GetExtension(value))))
                {
                    _rootDirectoryPath = value;

                    _imagesCache.Clear();
                    if (Directory.Exists(_rootDirectoryPath))
                    {
                        int index = 0;
                        foreach (string imageFile in Directory.EnumerateFiles(_rootDirectoryPath, "*.*", SearchOption.AllDirectories))
                        {
                            if (_acceptableImageExtensions.Contains(Path.GetExtension(imageFile)))
                            {
                                _imagesCache.Add(index++, imageFile);
                            }
                        }
                    }
                    else
                    {
                        _imagesCache.Add(0, _rootDirectoryPath);
                    }
                }
                else
                {
                    throw new FileNotFoundException($"The path '{value}' was not found or is not currently accessible.");
                }
            }
        }

        private readonly Dictionary<int, string> _imagesCache = new();
        private readonly List<string> _acceptableImageExtensions = new() { ".png", ".jpg", ".jpeg" };
        private string _rootDirectoryPath = string.Empty, _lastImagePath = string.Empty;
    }
}
