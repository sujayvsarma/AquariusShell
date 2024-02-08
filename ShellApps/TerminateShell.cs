using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using AquariusShell.Controls;
using AquariusShell.Modules;
using AquariusShell.Properties;
using AquariusShell.Runtime;

namespace AquariusShell.ShellApps
{
    /// <summary>
    /// Handles presenting options to shutdown/restart/etc and then handling that choice
    /// </summary>
    public partial class TerminateShell : Form, IShellAppModule
    {

        #region IShellAppModule

        #region Properties

        /// <summary>
        /// The icon displayable for this module in the program launcher etc
        /// </summary>
        public Image LauncherOrTaskManagerIcon
        {
            get
            {
                if (_icon == null)
                {
                    _icon = new Bitmap(Resources.shutdown, ShellEnvironment.ConfiguredSizeOfIconsInPixels, ShellEnvironment.ConfiguredSizeOfIconsInPixels);
                }
                return _icon;
            }
        }
        private Image? _icon = null;

        /// <summary>
        /// The caption text for this in the program launcher etc
        /// </summary>
        public string Caption => "Terminate";

        /// <summary>
        /// The launch command for this module
        /// </summary>
        public string Command => _command;
        private static string _command = $"{IShellAppModule.CommandSignifierPrefix}sigkill";

        /// <summary>
        /// Instancing mode
        /// </summary>
        public ShellAppInstancingModeEnum InstancingMode => ShellAppInstancingModeEnum.Single;

        /// <summary>
        /// When set, this app is not shown on the Launcher UI
        /// </summary>
        public bool HideFromLauncher => false;

        #endregion

        #region Methods

        /// <summary>
        /// Evaluate the provided command and respond if this module can handle it.
        /// </summary>
        /// <param name="command">Command string to evaluate.</param>
        /// <param name="parameters">Any potential parameters for this command (context)</param>
        /// <returns>TRUE if this module can handle it.</returns>
        public bool HandlesCommand(string command, params string[] parameters)
            => command.Equals(_command, StringComparison.InvariantCultureIgnoreCase);

        /// <summary>
        /// Execute the module
        /// </summary>

        /// <param name="command">Command string</param>
        /// <param name="parentWindowHandle">Parent window. If NULL, sets to Workarea</param>
        /// <param name="parameters">Any parameters for this command (context)</param>
        public void Execute(string command, IWin32Window? parentWindowHandle, params string[] parameters)
        {
            if (_command.Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                // make it modal to the workarea!
                this.ShowDialog((parentWindowHandle ?? ShellEnvironment.WorkArea));

                // per MSDN, modal dialog forms should be disposed after use
                this.Dispose(true);
            }
        }

        #endregion

        #endregion

        /// <summary>
        /// Initialise
        /// </summary>
        public TerminateShell()
        {
            InitializeComponent();

            this.Icon = Icon.FromHandle((new Bitmap(Resources.shutdown, 16, 16)).GetHicon());
        }

        #region Event Subscriptions

        /// <summary>
        /// On form closing notify the workarea that we are closing which would then refresh the apps list
        /// </summary>
        private void TerminateShell_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((e.CloseReason == CloseReason.UserClosing) && (AppClosed != null))
            {
                AppClosed(typeof(TerminateShell));
            }
        }

        /// <summary>
        /// Cancel the dialog
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Perform the selected Exit action
        /// </summary>
        private void btnAction_Click(object sender, EventArgs e)
        {
            bool force = cbForce.Checked;
            bool switchToExplorer = false;

            WindowsShutdownActions actionType = WindowsShutdownActions.SimpleExit;
            if (rbAdvancedExitShell.Checked)
            {
                actionType = WindowsShutdownActions.SimpleExit;
            }
            else if (rbSwitchShell.Checked)
            {
                actionType = WindowsShutdownActions.SwitchToExplorer;
                switchToExplorer = true;
            }
            else if (rbLogOff.Checked)
            {
                actionType = WindowsShutdownActions.LogOff;
            }
            else if (rbReboot.Checked)
            {
                actionType = WindowsShutdownActions.Reboot;
                if (cbRebootSwitchToExplorer.Checked)
                {
                    switchToExplorer = true;
                }
            }
            else if (rbShutdown.Checked)
            {
                actionType = WindowsShutdownActions.Shutdown;
                if (cbShutdownSwitchToExplorer.Checked)
                {
                    switchToExplorer = true;
                }
            }

            if (switchToExplorer)
            {
                // re-register explorer as the shell
                Win32Registry.Set(Microsoft.Win32.RegistryHive.LocalMachine, "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "Shell", "explorer.exe");

                // move our registration into a backup key
                Win32Registry.Set(Microsoft.Win32.RegistryHive.LocalMachine, "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "Shell_aquarius", Application.ExecutablePath);
            }

            switch (actionType)
            {
                case WindowsShutdownActions.SimpleExit:
                    // rather dramatic!
                    Application.Exit();
                    break;

                case WindowsShutdownActions.SwitchToExplorer:
                    Shell32.ExecuteProgram(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "explorer.exe"), Shell32.ShellExecuteVerbsEnum.None);
                    Application.Exit();
                    break;

                default:
                    SystemShutdownActions.PerformShutdownAction(actionType, force);
                    Application.Exit();
                    break;
            }
        }

        #endregion

        /// <summary>
        /// Notify that this app was closed by the user
        /// </summary>
        public event BuiltInAppClosed? AppClosed;
    }
}
