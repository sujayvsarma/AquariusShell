using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Reflection;

namespace AquariusShell.Runtime
{
    /// <summary>
    /// Perform toString actions on different types of objects
    /// </summary>
    internal static class StringifyExtensions
    {
        /// <summary>
        /// Returns ("tx,ty,bx,by")
        /// </summary>
        /// <param name="rect">Rectangle to stringify</param>
        /// <returns>String</returns>
        public static string Stringify(this Rectangle rect)
            => $"{rect.Left},{rect.Top},{rect.Width},{rect.Height}";

        /// <summary>
        /// Returns ("w,h")
        /// </summary>
        /// <param name="size">Size to stringify</param>
        /// <returns></returns>
        public static string Stringify(this Size size)
            => $"{size.Width},{size.Height}";

        /// <summary>
        /// Convert size to a human readable format
        /// </summary>
        /// <param name="size">Size as a long</param>
        /// <returns>String with the human readable form</returns>
        public static string FormatFileSize(this long size)
        {
            string[] sizeNames = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            int order = 0;
            double s = size;
            while ((s >= 1024) && (order < sizeNames.Length - 1))
            {
                order++;
                s /= 1024;
            }

            return $"{Math.Round(s, 2)} {sizeNames[order]}";
        }


        /// <summary>
        /// Parse a previously stringified string and return the original object
        /// </summary>
        /// <param name="stringifiedString">Previously stringified string</param>
        /// <param name="rect">[ref, out] The rectangle to fill</param>
        public static void Unstringify(this string stringifiedString, ref Rectangle rect)
        {
            int index = 0;
            foreach(string s in stringifiedString.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                if (Int32.TryParse(s, out int i))
                {
                    switch (index)
                    {
                        case 0: rect.X = i; break;
                        case 1: rect.Y = i; break;
                        case 2: rect.Width = i; break;
                        case 3: rect.Height = i; break;
                    }
                }

                index++;
            }
        }

        /// <summary>
        /// Parse a previously stringified string and return the original object
        /// </summary>
        /// <param name="stringifiedString">Previously stringified string</param>
        /// <param name="size">[ref, out] The size to fill</param>
        /// <returns>Object instance</returns>
        public static void Unstringify(this string stringifiedString, ref Size size)
        {
            int index = 0;
            foreach (string s in stringifiedString.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                if (Int32.TryParse(s, out int i))
                {
                    switch (index)
                    {
                        case 0: size.Width = i; break;
                        case 1: size.Height = i; break;
                    }
                }

                index++;
            }
        }


        /// <summary>
        /// Get the display text for an Enum value
        /// </summary>
        /// <typeparam name="TEnum">An Enum type</typeparam>
        /// <param name="value">Value to get the description text for</param>
        /// <returns>Display text</returns>
        public static string GetEnumFriendlyName<TEnum>(this TEnum value)
            where TEnum : Enum
        {
            string v = value.ToString();

            FieldInfo? fieldInfo = typeof(TEnum).GetField(v);
            if (fieldInfo == default)
            {
                return "Unknown value";
            }

            DisplayAttribute? description = fieldInfo.GetCustomAttribute<DisplayAttribute>();
            if (!string.IsNullOrWhiteSpace(description?.Name))
            {
                return description.Name;
            }

            return Enum.GetName(typeof(TEnum), value) ?? v;
        }
    }
}
