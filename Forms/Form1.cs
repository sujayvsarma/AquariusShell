using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AquariusShell.Controls;
using AquariusShell.Modules;

namespace AquariusShell.Forms
{
    /// <summary>
    /// This is a TEST form where we test out code, features, controls etc.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //accordionItem1.Width = this.ClientSize.Width - accordionItem1.Margin.Right - accordionItem1.Margin.Left;
            //accordionItem1.Height = this.ClientSize.Height - accordionItem1.Margin.Bottom - accordionItem1.Margin.Top;

            accordion1.Size = this.ClientSize;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //accordionItem1.Location = new(3, 3);
            //accordionItem1.Width = this.ClientSize.Width - accordionItem1.Margin.Right - accordionItem1.Margin.Left;
            //accordionItem1.Height = this.ClientSize.Height - accordionItem1.Margin.Bottom - accordionItem1.Margin.Top;

            //accordionItem1.Heading = "My documents";
            //accordionItem1.ItemsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //accordion1.Items.Add(
            //        new() 
            //        { 
            //            Heading = "My documents", 
            //            ItemsFolderPath = "D:\\Temp"
            //        }
            //    );

            //ExtractIconsFromAllKnownWindowsDLLs();

            accordion1.Items.Add(
                    new()
                    {
                        Heading = "Control Panel",
                        ItemsFolderPath = string.Join(';', Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms), Environment.GetFolderPath(Environment.SpecialFolder.Programs))
                    }
                );

            accordion1.AccordionItemClicked += Accordion1_AccordionItemClicked;
        }

        private void Accordion1_AccordionItemClicked(string caption, string targetPath, Image? icon)
        {
            throw new NotImplementedException();
        }


        private void ExtractIconsFromAllKnownWindowsDLLs()
        {
            string[] imageResourceFiles =
            [
                "shell32.dll",
                "imageres.dll",
                "pifmgr.dll",
                "accessibilitycpl.dll",
                "ddores.dll",
                "moricons.dll",
                "mmcndmgr.dll",
                "netcenter.dll",
                "netshell.dll",
                "networkexplorer.dll",
                "pnidui.dll",
                "sensorscpl.dll",
                "setupapi.dll",
                "wmploc.dll",
                "wpdshext.dll",
                "compstui.dll",
                "ieframe.dll",
                "dmdskres.dll",
                "dsuiext.dll",
                "mstscax.dll",
                "wiashext.dll",
                "comres.dll",
                "mstsc.dll",
                "actioncentercpl.dll",
                "aclui.dll",
                "autoplay.dll",
                "comctl32.dll",
                "filemgmt.dll",
                "ncpa.cpl",
                "url.dll",
                "xwizards.dll"
            ];

            int i = 0;

            foreach (string dllFileName in imageResourceFiles)
            {
                string shell32Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), $"{dllFileName}");
                if (File.Exists(shell32Path))
                {
                    string outputPath = Path.Combine("D:\\temp\\icons", Path.GetFileNameWithoutExtension(dllFileName));
                    if (!Directory.Exists(outputPath))
                    {
                        Directory.CreateDirectory(outputPath);
                    }

                    i = 0;
                    while (i < int.MaxValue)
                    {
                        Icon? icon = Icon.ExtractIcon(shell32Path, i, false);
                        if (icon == null)
                        {
                            break;
                        }

                        icon.ToBitmap().Save(Path.Combine(outputPath, $"{i.ToString().PadLeft(3, '0')}.ico"), ImageFormat.Icon);

                        //icon.Save(File.OpenWrite(Path.Combine(outputPath, $"{i.ToString().PadLeft(3, '0')}.ico")));
                        i++;
                    }
                }
            }

            string expath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "explorer.exe");
            string outpath = "D:\\temp\\icons\\explorer";
            if (!Directory.Exists(outpath))
            {
                Directory.CreateDirectory(outpath);
            }

            i = 0;
            while (i < int.MaxValue)
            {
                Icon? icon = Icon.ExtractIcon(expath, i, false);
                if (icon == null)
                {
                    break;
                }

                icon.Save(File.OpenWrite(Path.Combine(outpath, $"{i.ToString().PadLeft(3, '0')}.ico")));
                i++;
            }
        }
    }
}
