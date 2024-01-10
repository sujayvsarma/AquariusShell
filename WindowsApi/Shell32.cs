using System.Diagnostics;

namespace AquariusShell.WindowsApi
{

    /// <summary>
    /// Shell32.dll functions
    /// </summary>
    public static class Shell32
    {

        /// <summary>
        /// Extract an icon from shell32.dll
        /// </summary>
        /// <param name="index">0-based index of the icon</param>
        /// <param name="smallIcon">If true, extracts the "small" version of this icon</param>
        /// <returns>Icon or Null</returns>
        public static Icon? ExtractIconFromShell32Dll(int index, bool smallIcon = false)
            // We are not actually using a Win32 API, as this is a cleaner and more managed way to do so!
            => Icon.ExtractIcon(_shell32_dllPath, index, smallIcon);

        /// <summary>
        /// Returns the icon associated with the particular item.
        /// </summary>
        /// <param name="path">Full path to the file or item to process</param>
        /// <returns>Icon or Null</returns>
        public static Icon? ExtractAssociatedIcon(string path)
            // We are not actually using a Win32 API, as this is a cleaner and more managed way to do so!
            => Icon.ExtractAssociatedIcon(path);


        /// <summary>
        /// Attempt to execute the provided path. Windows will know what to do with it.
        /// </summary>
        /// <param name="uri">The full path or URI to execute</param>
        /// <returns>True if Windows accepted the command, False if there was a problem</returns>
        public static bool ExecuteUri(string uri)
        {
            // We will try two ways. One is a direct execution:
            ProcessStartInfo startInfo = new(uri)
            {
                UseShellExecute = true,
                Verb = "open",
                ErrorDialog = false     // we want to try again below!
            };

            try
            {
                Process.Start(startInfo);
            }
            catch
            {
                // Try again using RunDLL32

                try
                {
                    startInfo = new("rundll32.exe", $"shell32.dll,{(uri.EndsWith(".cpl") ? "Control" : "OpenAs")}_RunDLL \"{uri}\"")
                    {
                        UseShellExecute = false,
                        ErrorDialog = false             // we show our own errors!
                    };

                    Process.Start(startInfo);
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }




        static Shell32()
        {
            _shell32_dllPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "shell32.dll");
        }
        private static string _shell32_dllPath = string.Empty;
    }
}