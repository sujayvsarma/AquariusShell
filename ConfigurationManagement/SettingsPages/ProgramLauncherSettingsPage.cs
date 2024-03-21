using System.Windows.Forms;

using AquariusShell.ConfigurationManagement.Settings;
using AquariusShell.Objects;

namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    public partial class ProgramLauncherSettingsPage : UserControl, ISettingsPage
    {
        /// <summary>
        /// Persist settings
        /// </summary>
        public void MustApplySettings()
        {
            if (_settings.PasswordProtectedPrograms.Count > 0)
            {
                if ((tbPassword.Tag == null) && string.IsNullOrWhiteSpace(tbPassword.Text))
                {
                    MessageBox.Show("Password is required.", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbPassword.Focus();
                    return;
                }

                if (! string.IsNullOrWhiteSpace(tbPassword.Text))
                {
                    PasswordManagement.StorePassword(PasswordModuleNames.Shell, PasswordUsagePurposes.LaunchPasswordProtectedApp, tbPassword.Text);
                }

                // We don't need to store the password if it's in the tag (it was already stored earlier!)
            }

            _settings.ShowSearchBox = chkShowSearchBox.Checked;

            _settings.HiddenPrograms.Clear();
            foreach(NameValuePair<string> item in mngLstHiddenItems.Items)
            {
                _settings.HiddenPrograms.Add(item);
            }

            _settings.PasswordProtectedPrograms.Clear();
            foreach (NameValuePair<string> item in mngLstRequirePasswordItems.Items)
            {
                _settings.PasswordProtectedPrograms.Add(item);
            }

            ConfigurationProvider<CanvasLauncherSettings>.Set(_settings);
        }

        /// <summary>
        /// Load settings
        /// </summary>
        public void Reload()
        {
            _settings = ConfigurationProvider<CanvasLauncherSettings>.Get();

            chkShowSearchBox.Checked = _settings.ShowSearchBox;
            foreach(NameValuePair<string> item in _settings.HiddenPrograms)
            {
                mngLstHiddenItems.Items.Add(item);
            }

            foreach (NameValuePair<string> item in _settings.PasswordProtectedPrograms)
            {
                mngLstRequirePasswordItems.Items.Add(item);
            }

            tbPassword.Tag = null;
            if (_settings.PasswordProtectedPrograms.Count > 0)
            {
                // fetch password
                tbPassword.Tag = PasswordManagement.RetrievePassword(PasswordModuleNames.Shell, PasswordUsagePurposes.LaunchPasswordProtectedApp);
            }
        }


        /// <summary>
        /// Initialise
        /// </summary>
        public ProgramLauncherSettingsPage()
        {
            InitializeComponent();

            mngLstHiddenItems.AllowSelectApps = true;
            mngLstHiddenItems.AllowSelectDrivesDirectoriesAndFiles = true;

            mngLstRequirePasswordItems.AllowSelectApps = true;
            mngLstRequirePasswordItems.AllowSelectDrivesDirectoriesAndFiles = true;
            Reload();
        }

        private CanvasLauncherSettings _settings = default!;
    }
}
