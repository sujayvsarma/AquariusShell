namespace AquariusShell.Objects
{
    /// <summary>
    /// Item for the cascading menu used in frmLauncher.
    /// </summary>
    public class CascadeMenuItem
    {
        /// <summary>
        /// The text or caption to display
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// The full path to the directory or file this item points to
        /// </summary>
        public string FullPath { get; set; } = string.Empty;

        /// <summary>
        /// The icon to display. NULL if one was not found.
        /// </summary>
        public Icon? Icon { get; set; } = null;

        /// <summary>
        /// When TRUE means it will have children (and a further cascade level)
        /// </summary>
        public bool IsContainer { get; set; } = false;


        public CascadeMenuItem(string path)
        {
            Text = System.IO.Path.GetFileNameWithoutExtension(path);
            FullPath = path;
            if (Directory.Exists(path))
            {
                IsContainer = true;
                Icon = WindowsApi.Shell32.ExtractIconFromShell32Dll(4, false);
            }
            else
            {
                IsContainer = false;
                Icon = WindowsApi.Shell32.ExtractAssociatedIcon(path);
            }
        }

    }
}
