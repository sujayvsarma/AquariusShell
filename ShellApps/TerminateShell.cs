using System;
using System.Drawing;
using System.Windows.Forms;

using AquariusShell.ConfigurationManagement;
using AquariusShell.ConfigurationManagement.Settings;
using AquariusShell.Modules;
using AquariusShell.Objects;
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
                _icon ??= new Bitmap(Resources.shutdown, ShellEnvironment.ConfiguredSizeOfIconsInPixels, ShellEnvironment.ConfiguredSizeOfIconsInPixels);
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
        private static readonly string _command = $"{IShellAppModule.CommandSignifierPrefix}sigkill";

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

            _settings = ConfigurationProvider<TerminateShellSettings>.Get();

            this.Icon = Icon.FromHandle((new Bitmap(Resources.shutdown, 16, 16)).GetHicon());

            cbShutdownSwitchToExplorer.Enabled = _settings.AllowSwitchToExplorer;
            cbShutdownAction.Items.Clear();

            foreach (WindowsShutdownActions action in Enum.GetValues<WindowsShutdownActions>())
            {
                if (action != WindowsShutdownActions.SwitchToExplorer)
                {
                    bool hasValue = _settings.AllowedActions.TryGetValue(action, out bool allowed);
                    if ((hasValue && allowed) || (!hasValue))
                    {
                        NameValuePair<WindowsShutdownActions> item = new(action.GetEnumFriendlyName(), action);
                        cbShutdownAction.Items.Add(item);
                    }
                }
            }
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
            if (cbShutdownAction.SelectedItem == default)
            {
                return;
            }

            NameValuePair<WindowsShutdownActions> selectedItem = (NameValuePair<WindowsShutdownActions>)cbShutdownAction.SelectedItem;

            if (cbShutdownSwitchToExplorer.Checked)
            {
                CurrentShellActions.SwitchToExplorer();
            }
            
            switch (selectedItem.Value)
            {
                case WindowsShutdownActions.SimpleExit:
                    // Dramatic
                    Application.Exit();
                    break;

                case WindowsShutdownActions.LogOff:
                case WindowsShutdownActions.Shutdown:
                case WindowsShutdownActions.Reboot:
                    SystemShutdownActions.PerformShutdownAction(selectedItem.Value, cbForce.Checked);
                    Application.Exit();
                    break;
            }
        }

        #endregion

        /// <summary>
        /// Notify that this app was closed by the user
        /// </summary>
        public event BuiltInAppClosed? AppClosed;

        private readonly TerminateShellSettings _settings;
    }
}
