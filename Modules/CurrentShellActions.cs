using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Actions to switch the current shell
    /// </summary>
    internal static class CurrentShellActions
    {

        /// <summary>
        /// Change Shell to Windows Explorer
        /// </summary>
        public static void SwitchToExplorer()
        {
            Win32Registry.Set(Microsoft.Win32.RegistryHive.LocalMachine, KEY_PATH, VALUE_NAME, WIN32_DEFAULT_SHELL_PATH);
            Shell32.ExecuteProgram(WIN32_DEFAULT_SHELL_PATH);
        }

        /// <summary>
        /// Change Shell to ourselves. Also kills Windows Explorer if running.
        /// </summary>
        public static void SwitchToAquariusShell()
        {
            Win32Registry.Set(Microsoft.Win32.RegistryHive.LocalMachine, KEY_PATH, VALUE_NAME, AQUARIUS_SHELL_PATH);

            // kill Explorer
            Process[] explorers = Process.GetProcessesByName(EXPLORER_PROCESS_NAME);
            if (explorers.Length > 0)
            {
                Process shellOne = explorers[0];
                foreach (Process explorer in explorers)
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

        /// <summary>
        /// Initialise
        /// </summary>
        static CurrentShellActions()
        {
            WIN32_DEFAULT_SHELL_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), EXPLORER_PROCESS_NAME);
            AQUARIUS_SHELL_PATH = Application.ExecutablePath;
        }

        internal static string KEY_PATH = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon";
        internal static string VALUE_NAME = "Shell";
        internal static string EXPLORER_PROCESS_NAME = "explorer.exe";
        private static readonly string WIN32_DEFAULT_SHELL_PATH;
        private static readonly string AQUARIUS_SHELL_PATH;
    }
}
