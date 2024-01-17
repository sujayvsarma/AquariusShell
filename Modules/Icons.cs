using System.Drawing;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Works with icons and bitmaps
    /// </summary>
    internal static class Icons
    {
        /// <summary>
        /// Extracts the icon associated with the target item (app/program, document/file or a URI)
        /// </summary>
        /// <param name="fullPathToTarget">Full path to target</param>
        /// <param name="size">Desired size of icon</param>
        /// <returns>The icon, or NULL if not found</returns>
        public static Icon? ExtractAssociatedIcon(string fullPathToTarget, IconSizesEnum size)
        {
            Icon? icon = null;
            try
            {
                // can sometimes throw an access denied
                icon = Icon.ExtractAssociatedIcon(fullPathToTarget);

                if (icon != null)
                {
                    int rz = (int)size;
                    icon = new(icon, new Size(rz, rz));
                }
            }
            catch { }

            return icon;
        }
    }



    /// <summary>
    /// Sizes of icons
    /// </summary>
    public enum IconSizesEnum
    {
        /// <summary>
        /// 16x16
        /// </summary>
        x16 = 16,

        /// <summary>
        /// 24x24
        /// </summary>
        x24 = 24,

        /// <summary>
        /// 32x32
        /// </summary>
        x32 = 32,

        /// <summary>
        /// 64x64
        /// </summary>
        x64 = 64
    }
}
