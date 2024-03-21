namespace AquariusShell.ConfigurationManagement.Constants
{
    /// <summary>
    /// The source folder or location type for Workarea background images
    /// </summary>
    public enum BackgroundImagesSourcesEnum
    {
        /// <summary>
        /// A folder on the local system. 
        /// Can also be a network share as long as we have anonymous read access to it.
        /// </summary>
        LocalFolder = 0,

        /// <summary>
        /// A web/API service URL
        /// </summary>
        WebService
    }
}
