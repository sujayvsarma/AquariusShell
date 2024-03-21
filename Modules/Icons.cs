using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
            switch (size)
            {
                case IconSizesEnum.x16:
                    return IconSizesEnum.x24;

                case IconSizesEnum.x24:
                    return IconSizesEnum.x32;

                case IconSizesEnum.x32:
                case IconSizesEnum.x64:
                    return IconSizesEnum.x64;
            }

            return size;
        }

        /// <summary>
        /// Load icons for a all known drive types into the given ImageList controls
        /// </summary>
        /// <param name="imageLists">Array of ImageList to load the icons into</param>
        public static void LoadDriveIcons(params ImageList[] imageLists)
        {
            foreach (StockIconId iconId in Enum.GetValues<StockIconId>())
            {
                string id = iconId.ToString();
                if (id.StartsWith("Drive") || id.EndsWith("Drive"))
                {
                    foreach (ImageList list in imageLists)
                    {
                        list.Images.Add(id, SystemIcons.GetStockIcon(iconId));
                    }
                }
            }
        }

        /// <summary>
        /// Get the image key associated with a drive
        /// </summary>
        /// <param name="drive">Drive to get the key for</param>
        /// <returns>Image key</returns>
        public static string GetImageKey(DriveInfo drive)
            => drive.DriveType switch
            {
                DriveType.CDRom => StockIconId.DriveCD.ToString(),
                DriveType.Fixed => StockIconId.DriveFixed.ToString(),
                DriveType.Network => (drive.IsReady ? StockIconId.DriveNet.ToString() : StockIconId.DriveNetDisabled.ToString()),
                DriveType.NoRootDirectory => StockIconId.DriveUnknown.ToString(),
                DriveType.Ram => StockIconId.DriveRam.ToString(),
                DriveType.Removable => StockIconId.DriveRemovable.ToString(),

                _ => StockIconId.DriveUnknown.ToString()
            };


        /// <summary>
        /// Get the image key associated with a file or directory (by path). The image is added to the 
        /// provided ImageLists if it is not already present!
        /// </summary>
        /// <param name="filePath">Absolute path to file or directory</param>
        /// <param name="imageLists">Array of ImageList controls on the form</param>
        /// <returns>The associated image key</returns>
        public static string GetImageKey(string filePath, params ImageList[] imageLists)
        {
            string imageKey;
            if (Directory.Exists(filePath))
            {
                imageKey = ShellEnvironment.IMAGEKEY_FOLDER;
            }
            else
            {
                imageKey = Path.GetExtension(filePath).ToUpperInvariant();
                if ((imageKey == ".LNK") || (imageKey == ".EXE"))
                {
                    // each .lnk/.exe will have its own icon, based on its target

                    int groupItemsCount = 0;
                    foreach (string? s in imageLists[0].Images.Keys)
                    {
                        if ((!string.IsNullOrWhiteSpace(s)) && (s.EndsWith(imageKey)))
                        {
                            groupItemsCount++;
                        }
                    }

                    imageKey = $"{groupItemsCount}{imageKey}";
                }

                Icon icon = ExtractAssociatedIcon(filePath);
                foreach (ImageList list in imageLists)
                {
                    if (!list.Images.ContainsKey(imageKey))
                    {
                        try
                        {
                            list.Images.Add(imageKey, icon);
                        }
                        catch {
                            imageKey = ShellEnvironment.IMAGEKEY_GENERICFILE;
                        }
                    }
                }
            }

            return imageKey;
        }

        /// <summary>
        /// Get a "generic file" icon
        /// </summary>
        /// <param name="imageLists">ImageLists to add the icon to if not already</param>
        /// <returns>Imagekey (hard-coded: <see cref="ShellEnvironment.IMAGEKEY_GENERICFILE"/>)</returns>
        public static string GetGenericFileIcon(params ImageList[] imageLists)
        {
            string imageKey = ShellEnvironment.IMAGEKEY_GENERICFILE;

            Icon icon = SystemIcons.GetStockIcon(StockIconId.DocumentNoAssociation);
            foreach (ImageList list in imageLists)
            {
                if (!list.Images.ContainsKey(imageKey))
                {
                    list.Images.Add(imageKey, icon);
                }
            }

            return imageKey;
        }
    }
}
