using System.Windows.Forms;

using AquariusShell.ConfigurationManagement.Settings;
using AquariusShell.Objects;

namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    /// <summary>
    /// Settings to configure <see cref="ConfigurationManagement.Settings.SettingsBrowserSettings"/>
    /// </summary>
    public partial class SettingsBrowserSettingsPage : UserControl, ISettingsPage
    {
        /// <summary>
        /// Persist changes
        /// </summary>
        public void MustApplySettings()
        {
            if (_settings.RequirePassword && string.IsNullOrWhiteSpace(tbLaunchPassword.Text) && string.IsNullOrWhiteSpace((string)tbLaunchPassword.Tag!))
            {
                MessageBox.Show("Please enter the password!", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbLaunchPassword.Focus();
                return;
            }

            if (_settings.AllowDisabledAppletsExecutionWithPassword && string.IsNullOrWhiteSpace(tbAppletLaunchPassword.Text) && string.IsNullOrWhiteSpace((string)tbAppletLaunchPassword.Tag!))
            {
                MessageBox.Show("Please enter the password!", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbAppletLaunchPassword.Focus();
                return;
            }

            _settings.ShowOnLauncher = chkShowAppOnLauncher.Checked;
            if (_settings.ShowOnLauncher)
            {
                if ((!string.IsNullOrWhiteSpace(pbLauncherIcon.ImageLocation)) || (!string.IsNullOrWhiteSpace(tbLauncherCaption.Text)))
                {
                    _settings.CustomButton = new()
                    {
                        IconPath = pbLauncherIcon.ImageLocation,
                        Caption = tbLauncherCaption.Text,
                        Command = string.Empty
                    };
                }
            }

            _settings.AllowDisabledAppletsExecutionWithPassword = chkAllowRunningCPLWithPassword.Checked;
            _settings.RequirePassword = chkRequirePasswordToLaunchSettingsBrowser.Checked;

            _settings.DisabledWin32Applets.Clear();
            foreach (NameValuePair<string> item in mngLstHiddenControlPanelApplets.SelectedItems)
            {
                _settings.DisabledWin32Applets.Add(item);
            }

            ConfigurationProvider<SettingsBrowserSettings>.Set(_settings);

            if (_settings.RequirePassword)
            {
                string pwd1 = (string.IsNullOrWhiteSpace(tbLaunchPassword.Text) ? (string)tbLaunchPassword.Tag! : tbLaunchPassword.Text);
                PasswordManagement.StorePassword(PasswordModuleNames.Shell, PasswordUsagePurposes.LaunchSettingsBrowser, pwd1);
            }

            if (_settings.AllowDisabledAppletsExecutionWithPassword)
            {
                string pwd2 = (string.IsNullOrWhiteSpace(tbAppletLaunchPassword.Text) ? (string)tbAppletLaunchPassword.Tag! : tbAppletLaunchPassword.Text);
                PasswordManagement.StorePassword(PasswordModuleNames.Shell, PasswordUsagePurposes.LaunchSettingsBrowser, pwd2);
            }
        }

        /// <summary>
        /// Load settings
        /// </summary>
        public void Reload()
        {
            _settings = ConfigurationProvider<SettingsBrowserSettings>.Get();
            chkShowAppOnLauncher.Checked = _settings.ShowOnLauncher;
            if (_settings.ShowOnLauncher)
            {
                if (_settings.CustomButton != default!)
                {
                    pbLauncherIcon.ImageLocation = _settings.CustomButton.IconPath;
                    tbLauncherCaption.Text = _settings.CustomButton.Caption;
                }
            }

            foreach (NameValuePair<string> item in _settings.DisabledWin32Applets)
            {
                mngLstHiddenControlPanelApplets.SelectedItems.Add(item);
            }

            chkAllowRunningCPLWithPassword.Checked = _settings.AllowDisabledAppletsExecutionWithPassword;
            chkRequirePasswordToLaunchSettingsBrowser.Checked = _settings.RequirePassword;

            if (_settings.AllowDisabledAppletsExecutionWithPassword)
            {
                tbAppletLaunchPassword.Tag = PasswordManagement.RetrievePassword(PasswordModuleNames.Shell, PasswordUsagePurposes.LaunchHiddenWindowsControlPanelApplet);
            }

            if (_settings.RequirePassword)
            {
                tbLaunchPassword.Tag = PasswordManagement.RetrievePassword(PasswordModuleNames.Shell, PasswordUsagePurposes.LaunchSettingsBrowser);
            }
        }

        /// <summary>
        /// Picturebox clicked - Show file dialog and find an icon
        /// </summary>
        private void pbLauncherIcon_Click(object sender, System.EventArgs e)
        {
            if (ofdFindLauncherIcon.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            pbLauncherIcon.ImageLocation = ofdFindLauncherIcon.FileName;
        }
        private void chkRequirePasswordToLaunchSettingsBrowser_CheckedChanged(object sender, System.EventArgs e)
        {
            tbLaunchPassword.Enabled = chkRequirePasswordToLaunchSettingsBrowser.Checked;
        }

        /// <summary>
        /// Checkbox changed, change state of the related textbox
        /// </summary>
        private void chkAllowRunningCPLWithPassword_CheckedChanged(object sender, System.EventArgs e)
        {
            tbAppletLaunchPassword.Enabled = chkAllowRunningCPLWithPassword.Checked;
        }

        /// <summary>
        /// Initialise
        /// </summary>
        public SettingsBrowserSettingsPage()
        {
            InitializeComponent();

            Reload();
        }

        private SettingsBrowserSettings _settings = default!;
    }
}
