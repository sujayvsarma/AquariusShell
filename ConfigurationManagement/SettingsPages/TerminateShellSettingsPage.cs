using System.Windows.Forms;

using AquariusShell.ConfigurationManagement.Settings;
using AquariusShell.Modules;

namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    public partial class TerminateShellSettingsPage : UserControl, ISettingsPage
    {
        /// <summary>
        /// Persist changes
        /// </summary>
        public void MustApplySettings()
        {
            _settings.AllowSwitchToExplorer = chkAllowSwitchToExplorer.Checked;

            _settings.AllowedActions[WindowsShutdownActions.SimpleExit] = chkShellExit.Checked;
            _settings.AllowedActions[WindowsShutdownActions.LogOff] = chkLogOff.Checked;
            _settings.AllowedActions[WindowsShutdownActions.Reboot] = chkReboot.Checked;
            _settings.AllowedActions[WindowsShutdownActions.Shutdown] = chkShutdown.Checked;

            ConfigurationProvider<TerminateShellSettings>.Set(_settings);
        }

        /// <summary>
        /// Reload settings
        /// </summary>
        public void Reload()
        {
            _settings = ConfigurationProvider<TerminateShellSettings>.Get();

            chkAllowSwitchToExplorer.Checked = _settings.AllowSwitchToExplorer;
            
            chkShellExit.Checked = _settings.AllowedActions.ContainsKey(WindowsShutdownActions.SimpleExit)
                && _settings.AllowedActions[WindowsShutdownActions.SimpleExit];

            chkLogOff.Checked = _settings.AllowedActions.ContainsKey(WindowsShutdownActions.LogOff)
                && _settings.AllowedActions[WindowsShutdownActions.LogOff];

            chkReboot.Checked = _settings.AllowedActions.ContainsKey(WindowsShutdownActions.Reboot)
                && _settings.AllowedActions[WindowsShutdownActions.Reboot];

            chkShutdown.Checked = _settings.AllowedActions.ContainsKey(WindowsShutdownActions.Shutdown)
                && _settings.AllowedActions[WindowsShutdownActions.Shutdown];
        }

        /// <summary>
        /// Initialise
        /// </summary>
        public TerminateShellSettingsPage()
        {
            InitializeComponent();
            Reload();
        }

        private TerminateShellSettings _settings = default!;
    }
}
