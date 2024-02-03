using System;
using System.Collections.Generic;
using System.Management;

using AquariusShell.Objects;

namespace AquariusShell.Modules
{
    /// <summary>
    /// API to deal with printers (spooler)
    /// </summary>
    internal static partial class Printers
    {

        /// <summary>
        /// Get information about local and network printers
        /// </summary>
        /// <returns>List of printers</returns>
        public static List<Printer> GetLocalAndNetworkConnectedPrinters()
        {
            List<Printer> printers = new();

            // We are using WMI here as the API and Registry methods are way too complicated!
            // and WMI does the same thing as getting it from the registry anyway!
            ManagementObjectSearcher wmi = new("SELECT * FROM Win32_Printer");
            ManagementObjectCollection results = wmi.Get();
            foreach (ManagementObject item in results)
            {
                Printer device = new();

                foreach (PropertyData property in item.Properties)
                {
                    switch (property.Name)
                    {

                        case "Name":
                            device.Name = (string)(property.Value ?? string.Empty);
                            break;

                        case "Comment":
                            device.Comment = (string)(property.Value ?? string.Empty);
                            break;

                        case "Description":
                            device.Description = (string)(property.Value ?? string.Empty);
                            break;

                        case "DriverName":
                            device.DriverName = (string)(property.Value ?? string.Empty);
                            break;

                        case "Attributes":
                            PrinterAttributesEnum attrib = (PrinterAttributesEnum)(property.Value ?? PrinterAttributesEnum.None);

                            if (attrib.HasFlag(PrinterAttributesEnum.IsDefaultPrinter))
                            {
                                device.IsDefaultPrinter = true;
                            }

                            if (attrib.HasFlag(PrinterAttributesEnum.IsFaxPrinter))
                            {
                                device.Type = Printer.PrinterTypesEnum.Fax;
                            }
                            else if (attrib.HasFlag(PrinterAttributesEnum.IsSharedPrinter))
                            {
                                device.Type = Printer.PrinterTypesEnum.Shared;
                            }
                            else if (attrib.HasFlag(PrinterAttributesEnum.IsNetworkPrinter))
                            {
                                device.Type = Printer.PrinterTypesEnum.Network;
                            }

                            break;

                        case "Availability":
                            PrinterStatusEnum apiStatus = (PrinterStatusEnum)(property.Value ?? PrinterStatusEnum.Unknown);
                            device.Status = apiStatus switch
                            {
                                PrinterStatusEnum.Running => Printer.PrinterStatusEnum.Ready,
                                PrinterStatusEnum.HasWarnings => Printer.PrinterStatusEnum.ActiveWithErrors,
                                PrinterStatusEnum.SelfTestMode => Printer.PrinterStatusEnum.SelfTestInProgress,
                                PrinterStatusEnum.PoweredOff or PrinterStatusEnum.Offline or PrinterStatusEnum.OffDuty => Printer.PrinterStatusEnum.Unavailable,
                                PrinterStatusEnum.Degraded => Printer.PrinterStatusEnum.PoorNetworkConnectivity,
                                PrinterStatusEnum.NotInstalled => Printer.PrinterStatusEnum.NotInstalled,
                                PrinterStatusEnum.InstallationError => Printer.PrinterStatusEnum.NeedsReinstallation,
                                PrinterStatusEnum.PowerSaveEnteredCurrentlyUnknown or PrinterStatusEnum.PowerSaveLowPower or PrinterStatusEnum.PowerSaveStandby or PrinterStatusEnum.PowerSaveWithWarnings => Printer.PrinterStatusEnum.InPowerSavingState,
                                PrinterStatusEnum.Rebooting => Printer.PrinterStatusEnum.Rebooting,
                                PrinterStatusEnum.Paused => Printer.PrinterStatusEnum.JobsPaused,
                                PrinterStatusEnum.NotReady => Printer.PrinterStatusEnum.OtherwiseNotReady,
                                PrinterStatusEnum.NotConfigured => Printer.PrinterStatusEnum.NeedsConfiguration,

                                _ => Printer.PrinterStatusEnum.Unknown
                            };
                            break;

                        case "AveragePagesPerMinute":
                            device.AveragePPM = (uint)(property.Value ?? 0);
                            break;

                        case "DefaultPaperType":
                            device.DefaultPaperType = (string)(property.Value ?? string.Empty);
                            break;

                        case "DetectedErrorState":
                            PrinterErrorsEnum errCode = (PrinterErrorsEnum)(property.Value ?? PrinterErrorsEnum.NoError);
                            device.ErrorCode = errCode switch
                            {
                                PrinterErrorsEnum.NoError => Printer.PrinterErrorsEnum.NoError,
                                PrinterErrorsEnum.LowPaper => Printer.PrinterErrorsEnum.PaperLow,
                                PrinterErrorsEnum.PaperOut => Printer.PrinterErrorsEnum.PaperOut,
                                PrinterErrorsEnum.LowToner => Printer.PrinterErrorsEnum.TonerOrInkLow,
                                PrinterErrorsEnum.TonerOut => Printer.PrinterErrorsEnum.TonerOrInkOut,
                                PrinterErrorsEnum.DoorOpen => Printer.PrinterErrorsEnum.DoorOpen,
                                PrinterErrorsEnum.PaperJammed => Printer.PrinterErrorsEnum.PaperJammed,
                                PrinterErrorsEnum.OutTrayFull => Printer.PrinterErrorsEnum.OutTrayFull,
                                PrinterErrorsEnum.Offline => Printer.PrinterErrorsEnum.Offline,
                                PrinterErrorsEnum.ServicingRequired => Printer.PrinterErrorsEnum.ServicingRequired,

                                _ => Printer.PrinterErrorsEnum.Unknown
                            };
                            break;

                        case "HorizontalResolution":
                            device.HorizontalDPI = (uint)(property.Value ?? 0);
                            break;

                        case "VerticalResolution":
                            device.VerticalDPI = (uint)(property.Value ?? 0);
                            break;


                        case "InstallDate":
                            device.InstalledOn = (DateTime)(property.Value ?? default(DateTime));
                            break;

                        case "Location":
                            device.PhysicalLocation = (string)(property.Value ?? string.Empty);
                            break;

                        case "PortName":
                            device.Ports = ((string)(property.Value ?? string.Empty)).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                            break;

                        case "StartTime":
                            device.AvailableFrom = (DateTime)(property.Value ?? default(DateTime));
                            break;

                        case "UntilTime":
                            device.AvailableUntil = (DateTime)(property.Value ?? default(DateTime));
                            break;
                    }
                }

                printers.Add(device);
            }

            return printers;
        }

        /// <summary>
        /// Open the settings dialog for the given printer
        /// </summary>
        /// <param name="printerName">Name of the printer as retrieved by <see cref="GetLocalAndNetworkConnectedPrinters"/> (Printer.Name)</param>
        /// <param name="hWnd">Handle of the printers view form</param>
        public static void OpenPrinterSettingsDialog(string printerName)
        {
            Shell32.ExecuteRundll32Command(
                    "printui.dll,PrintUIEntry", 
                        "/p",                           // show properties box
                        "/n", $"\"{printerName}\""      // name of the printer to show the dialog for
                );
        }
    }


}
