using System;
using System.Diagnostics;
using System.Drawing;

using AquariusShell.Runtime;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Works with icons and bitmaps
    /// </summary>
    internal static partial class Icons
    {
        /// <summary>
        /// Extracts the icon associated with the target item (app/program, document/file or a URI)
        /// </summary>
        /// <param name="fullPathToTarget">Full path to target</param>
        /// <param name="size">Desired size of icon</param>
        /// <returns>The icon, or no-association icon</returns>
        public static Icon ExtractAssociatedIcon(string fullPathToTarget, IconSizesEnum? size = null)
        {
            Icon icon;
            try
            {
                // can sometimes throw an access denied
                icon = Icon.ExtractAssociatedIcon(fullPathToTarget) ?? SystemIcons.GetStockIcon(StockIconId.DocumentNoAssociation);
                if (size != null)
                {
                    icon = icon.Resize(size.Value);
                }
            }
            catch 
            {
                icon = SystemIcons.GetStockIcon(StockIconId.DocumentNoAssociation);
            }

            return icon;
        }

        /// <summary>
        /// Returns a possible icon for the given process. Tries several methods to get the icon.
        /// </summary>
        /// <param name="process">Process instance to get an icon for</param>
        /// <returns>An Image with the relevant icon. If one could not be found will return the [default] SystemIcons.Application.</returns>
        public static Image EnsureGetProcessIcon(Process process)
        {
            Icon? icon = null;
            try
            {
                icon = ExtractAssociatedIcon(process.MainModule!.FileName, ShellEnvironment.ConfiguredSizeOfIcons);
            }
            catch
            {
                string? processFileName = Kernel32.GetProcessFileName(process.Id);
                if (!string.IsNullOrWhiteSpace(processFileName))
                {
                    icon = ExtractAssociatedIcon(processFileName, ShellEnvironment.ConfiguredSizeOfIcons);
                }
            }

            return (icon ?? SystemIcons.Application).ToBitmap();
        }

        /// <summary>
        /// Change the size of the icon
        /// </summary>
        /// <param name="icon">Icon to resize</param>
        /// <param name="newSize">The new size desired</param>
        /// <returns>Icon resized</returns>
        public static Icon Resize(this Icon icon, IconSizesEnum newSize)
        {
            int px = newSize.ToPixels();
            return new(icon, new Size(px, px));
        }


        /// <summary>
        /// Get the size in pixels for the enum value
        /// </summary>
        /// <param name="size">Icon size enum value</param>
        /// <returns>Size in pixels</returns>
        public static int ToPixels(this IconSizesEnum size)
            => (int)size;

        /// <summary>
        /// Get the next smaller size
        /// </summary>
        /// <param name="size">Icon size to reduce from</param>
        /// <returns>Next smaller size or if not possible (already minimum) then returns 'size'</returns>
        public static IconSizesEnum ToNextSmallerSize(this IconSizesEnum size)
        {
            int proposedSize = ((int)size) / 2;
            if (Enum.IsDefined<IconSizesEnum>((IconSizesEnum)proposedSize))
            {
                return (IconSizesEnum)proposedSize;
            }

            return size;
        }

        /// <summary>
        /// Get the next larger size
        /// </summary>
        /// <param name="size">Icon size to expand from</param>
        /// <returns>Next larger size or if not possible (already maximum) then returns 'size'</returns>
        public static IconSizesEnum ToNextLargerSize(this IconSizesEnum size)
        {
            int proposedSize = ((int)size) * 2;
            if (Enum.IsDefined<IconSizesEnum>((IconSizesEnum)proposedSize))
            {
                return (IconSizesEnum)proposedSize;
            }

            return size;
        }
    }    
}
