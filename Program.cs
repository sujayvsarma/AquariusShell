using System;
using System.Diagnostics;
using System.Windows.Forms;

using AquariusShell.Forms;
using AquariusShell.Modules;



namespace AquariusShell
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Do we have at least one monitor?
            if ((Screen.AllScreens.Length == 0) || (Screen.PrimaryScreen == null))
            {
                throw new ApplicationException("Cannot run this program on a system without a monitor!");
            }

            // Check if we are the shell, if not, prompt the user
            string currentShell = (string)Win32Registry.Get(Microsoft.Win32.RegistryHive.LocalMachine, "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "Shell", "explorer.exe")!;
            if (!currentShell.Equals(Application.ExecutablePath, StringComparison.InvariantCultureIgnoreCase))
            {
                if (MessageBox.Show("Aquarius Shell is not your current 'shell' application. Do you wish to set Aquarius Shell as your shell ?", "Aquarius Shell", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Win32Registry.Set(Microsoft.Win32.RegistryHive.LocalMachine, "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "Shell_aquarius", currentShell);
                    Win32Registry.Set(Microsoft.Win32.RegistryHive.LocalMachine, "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "Shell", Application.ExecutablePath);

                    // kill Explorer
                    Process[] explorers = Process.GetProcessesByName("explorer.exe");
                    if (explorers.Length > 0)
                    {
                        Process shellOne = explorers[0];
                        foreach(Process explorer in explorers)
                        {
                            if (shellOne.Id > explorer.Id)
                            {
                                shellOne = explorer;
                            }
                        }

                        // don't kill entire tree as it would end everything including ourselves!
                        shellOne.Kill();
                    }
                }
            }

            // As the bottom-most window, this is started first
            Application.Run(new WorkspaceBackground());
        }
    }
}