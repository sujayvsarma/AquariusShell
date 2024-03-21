using System;
using System.Drawing;
using System.Windows.Forms;

using AquariusShell.Forms;
using AquariusShell.Modules;
using AquariusShell.Runtime;

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

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(true);

            /*
            Splash splash = new Splash();
            splash.Show();

            // Wait for splash to load and show properly
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));

            // Do we have at least one monitor?
            if ((Screen.AllScreens.Length == 0) || (Screen.PrimaryScreen == null))
            {
                throw new ApplicationException("Cannot run this program on a system without a monitor!");
            }

            // Check if we are the shell, if not, prompt the user
            string currentShell = (string)Win32Registry.Get(Microsoft.Win32.RegistryHive.LocalMachine, CurrentShellActions.KEY_PATH, CurrentShellActions.VALUE_NAME, "explorer.exe")!;
            if (!currentShell.Equals(Application.ExecutablePath, StringComparison.InvariantCultureIgnoreCase))
            {
                if (MessageBox.Show("Aquarius Shell is not your current 'shell' application. Do you wish to set Aquarius Shell as your shell ?", "Aquarius Shell", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CurrentShellActions.SwitchToAquariusShell();
                }
            }

            Application.ApplicationExit += Application_ApplicationExit;

            // As the bottom-most window, this is started first
            Application.Run(new WorkspaceBackground(splash));
            */

            Application.Run(new Taskbar());
        }

        /// <summary>
        /// App Exit. Clear caches and memory, reset workarea bounds
        /// </summary>
        private static void Application_ApplicationExit(object? sender, EventArgs e)
        {
            ShellEnvironment.ClearHeavyCachesForExit();

            Rectangle newWorkArea = new()
            {
                X = 0,
                Y = 0,
                Height = ShellEnvironment.PrimaryScreenSafe.Bounds.Height,
                Width = ShellEnvironment.PrimaryScreenSafe.Bounds.Width
            };
            Modules.Windows.SetWorkareaBounds(newWorkArea);

            for (int f = (Application.OpenForms.Count - 1); f >= 0; f--)
            {
                Form? form = Application.OpenForms[f];
                if (form != null)
                {
                    form.Close();
                    form.Dispose();
                }
            }
        }
    }
}