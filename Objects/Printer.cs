using System;
using System.Text;

using AquariusShell.Modules;

namespace AquariusShell.Objects
{
    /// <summary>
    /// Information about an installed or connected printer
    /// </summary>
    public partial class Printer
    {

        /// <summary>
        /// Name of the printer
        /// </summary>
        public string Name
        {
            get; set;

        } = string.Empty;

        /// <summary>
        /// Administrator's comment
        /// </summary>
        public string Comment
        {
            get; set;
        } = string.Empty;

        /// <summary>
        /// Description about the printer
        /// </summary>
        public string Description
        {
            get; set;
        } = string.Empty;

        /// <summary>
        /// Name of the driver attached to the device
        /// </summary>
        public string DriverName
        {
            get; set;
        } = string.Empty;

        /// <summary>
        /// Is this the default printer
        /// </summary>
        public bool IsDefaultPrinter
        {
            get; set;
        } = false;

        /// <summary>
        /// Type of printer
        /// </summary>
        public PrinterTypesEnum Type
        {
            get; set;
        } = PrinterTypesEnum.Regular;

        /// <summary>
        /// Status of printer
        /// </summary>
        public PrinterStatusEnum Status
        {
            get; set;
        } = PrinterStatusEnum.Unknown;

        /// <summary>
        /// Average PPM if available
        /// </summary>
        public uint AveragePPM
        {
            get; set;
        } = 0;
        
        /// <summary>
        /// Default paper type used
        /// </summary>
        public string DefaultPaperType 
        { 
            get; set; 
        } = string.Empty;

        /// <summary>
        /// If printer is in errored state, the error code
        /// </summary>
        public PrinterErrorsEnum ErrorCode 
        { 
            get; set; 
        } = PrinterErrorsEnum.NoError;
        
        /// <summary>
        /// Horizontal DPI
        /// </summary>
        public uint HorizontalDPI 
        { 
            get; set; 
        } = 0;
        
        /// <summary>
        /// Vertical DPI
        /// </summary>
        public uint VerticalDPI 
        { 
            get; set; 
        } = 0;

        /// <summary>
        /// Combined DPI as a string
        /// </summary>
        public string DpiString => $"{HorizontalDPI}x{VerticalDPI} dpi";
        
        /// <summary>
        /// Installation date
        /// </summary>
        public DateTime InstalledOn 
        { 
            get; set; 
        } = default!;
        
        /// <summary>
        /// Physical location of the printer
        /// </summary>
        public string PhysicalLocation 
        { 
            get; set; 
        } = string.Empty;
        
        /// <summary>
        /// Ports attached to
        /// </summary>
        public string[] Ports 
        { 
            get; set; 
        } = Array.Empty<string>();

        /// <summary>
        /// Available from date/time
        /// </summary>
        public DateTime AvailableFrom 
        { 
            get; set; 
        } = default!;
        
        /// <summary>
        /// Available to date/time
        /// </summary>
        public DateTime AvailableUntil 
        { 
            get; set; 
        } = default!;

        /// <summary>
        /// Availability as a string
        /// </summary>
        public string AvailabilityString
        {
            get
            {
                StringBuilder av = new();
                if (AvailableFrom == default!)
                {
                    if (AvailableUntil == default!)
                    {
                        av.Append("Always available");
                    }
                    else
                    {
                        av.Append($"Until {AvailableUntil:HH:mm}");
                    }
                }
                else
                {
                    if (AvailableUntil == default!)
                    {
                        av.Append($"From {AvailableFrom:HH:mm}");
                    }
                    else
                    {
                        av.Append($"{AvailableFrom:HH:mm} to {AvailableUntil:HH:mm}");
                    }
                }

                return av.ToString();
            }
        }
    }
}
