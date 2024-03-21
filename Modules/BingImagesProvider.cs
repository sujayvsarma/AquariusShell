using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using AquariusShell.Objects;

using SujaySarma.Sdk.RestApi;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Retrieve images from Bing Images
    /// </summary>
    internal class BingImagesProvider : IBackgroundImageProvider
    {

        /// <summary>
        /// Get the latest image to be shown
        /// </summary>
        /// <returns>Image with the picture to be displayed, or NULL if none found</returns>
        public async Task<Image?> RefreshOrGetNext()
        {
            if (_imageLoaderRestApiClient == null)
            {
                throw new InvalidOperationException("RefresOrGetNext() called before setting 'ImageStoreLocation'.");
            }

            HttpResponseMessage bingApiResponse = await _imageLoaderRestApiClient.Get();
            if ((bingApiResponse != null) && (bingApiResponse.StatusCode == System.Net.HttpStatusCode.OK))
            {
                try
                {
                    BingImagesApiResponse? bingApiResponseDecoded = JsonSerializer.Deserialize<BingImagesApiResponse>(bingApiResponse.Content.ReadAsStream());
                    if ((bingApiResponseDecoded != null) && (bingApiResponseDecoded.Images.Count > 0) && (!_lastImagePath.Equals(bingApiResponseDecoded.Images[0].Url)))
                    {
                        bingApiSecondaryFetchClient = new()
                        {
                            Timeout = TimeSpan.FromSeconds(10)
                        };

                        try
                        {
                            HttpResponseMessage imageResourceLoadResponse = await bingApiSecondaryFetchClient.GetAsync($"https://www.bing.com{bingApiResponseDecoded.Images[0].Url}");
                            if ((imageResourceLoadResponse != null) && (imageResourceLoadResponse.StatusCode == System.Net.HttpStatusCode.OK))
                            {
                                Image? pic = Image.FromStream(imageResourceLoadResponse.Content.ReadAsStream());
                                if (pic != null)
                                {
                                    // cache it for next load
                                    // obviously we are expecting only jpg and png images to come down off Bing...
                                    ImageFormat format = ImageFormat.Jpeg;
                                    switch (imageResourceLoadResponse.Content.Headers.ContentType?.MediaType)
                                    {
                                        case "image/jpeg":
                                            _lastImageExtension = "jpg";
                                            format = ImageFormat.Jpeg;
                                            break;

                                        case "image/png":
                                            _lastImageExtension = "png";
                                            format = ImageFormat.Png;
                                            break;

                                        case "image/bmp":
                                            _lastImageExtension = "bmp";
                                            format = ImageFormat.Bmp;
                                            break;

                                        case "image/gif":
                                            _lastImageExtension = "gif";
                                            format = ImageFormat.Gif;
                                            break;

                                        default:
                                            // something else? We can't handle this!
                                            throw new Exception($"File format '{imageResourceLoadResponse.Content.Headers.ContentType?.MediaType}' is not supported.");
                                    }

                                    _lastImagePath = Path.GetTempFileName();
                                    pic.Save(_lastImagePath, format);
                                    pic.Tag = _lastImageExtension;
                                    return pic;
                                }
                            }
                        }
                        catch
                        {
                            // throw to outer
                            throw;
                        }
                    }
                }
                catch
                {
                    // garbage responses? Doesnt matter
                    if (!string.IsNullOrWhiteSpace(_lastImagePath))
                    {
                        Image? pic = Image.FromStream(File.Open(_lastImagePath, FileMode.Open, FileAccess.Read, FileShare.Read));
                        if (pic != null)
                        {
                            pic.Tag = _lastImageExtension;
                            return pic;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// URI (Path or Url) to the location the images are to be retrieved from
        /// </summary>
        public string ImageStoreLocation
        {
            get => _imageLoaderRestApiClient?.RequestUri?.ToString() ?? string.Empty;
            set
            {
                _imageLoaderRestApiClient = new()
                {
                    RequestTimeout = 30,
                    RequestUri = new Uri(value)
                };
            }
        }


        private RestApiClient? _imageLoaderRestApiClient;
        private HttpClient? bingApiSecondaryFetchClient = null;
        private string _lastImagePath = string.Empty, _lastImageExtension = string.Empty;
    }
}
