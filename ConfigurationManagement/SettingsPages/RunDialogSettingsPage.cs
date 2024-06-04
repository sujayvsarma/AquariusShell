using System;
using System.Windows.Forms;

using AquariusShell.ConfigurationManagement.Settings;

namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    /// <summary>
    /// Settings to configure <see cref="ConfigurationManagement.Settings.RunDialogSettings"/>
    /// </summary>
    public partial class RunDialogSettingsPage : UserControl, ISettingsPage
    {
        /// <summary>
        /// Persist changes
        /// </summary>
        public void MustApplySettings()
        {
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

            _settings.AllowBrowse = chkShowBrowseButton.Checked;
            _settings.ShowPreviouslyRunItemsList = chkStoreMRU.Checked;
            _settings.AllowRunningNonMRI = chkMRUIsReadonly.Checked;
            _settings.PreviouslyRunItemsListMaximumCount = (int)tbMaxUriLength.Value;
            _settings.DoNotStoreURI = mngLstNeverStoreUri.StringList;
            _settings.AlwaysAppendedURI = mngLstAlwaysAppendUri.StringList;

            ConfigurationProvider<RunDialogSettings>.Set(_settings);
        }

        /// <summary>
        /// Load settings
        /// </summary>
        public void Reload()
        {
            _settings = ConfigurationProvider<RunDialogSettings>.Get();

            chkShowAppOnLauncher.Checked = _settings.ShowOnLauncher;
            if (_settings.ShowOnLauncher)
            {
                if (_settings.CustomButton != default!)
                {
                    pbLauncherIcon.ImageLocation = _settings.CustomButton.IconPath;
                    tbLauncherCaption.Text = _settings.CustomButton.Caption;
                }
            }

            chkShowBrowseButton.Checked = _settings.AllowBrowse;
            chkStoreMRU.Checked = _settings.ShowPreviouslyRunItemsList;
            chkMRUIsReadonly.Checked = _settings.AllowRunningNonMRI;
            tbMaxUriLength.Value = _settings.PreviouslyRunItemsListMaximumCount;
            mngLstNeverStoreUri.AddItems(_settings.DoNotStoreURI, true);
            mngLstAlwaysAppendUri.AddItems(_settings.AlwaysAppendedURI, true);
        }

        /// <summary>
        /// Picturebox clicked - Show file dialog and find an icon
        /// </summary>
        private void pbLauncherIcon_Click(object sender, EventArgs e)
        {
            if (ofdFindLauncherIcon.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            pbLauncherIcon.ImageLocation = ofdFindLauncherIcon.FileName;
        }

        /// <summary>
        /// Max Uri value changed. Validate!
        /// </summary>
        private void tbMaxUriLength_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)tbMaxUriLength.Value;
            if ((value < -1) || (value > 255))
            {
                MessageBox.Show("Value cannot be less than -1 or more than 255.", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbMaxUriLength.Focus();
                return;
            }
        }

        /// <summary>
        /// Initialise
        /// </summary>
        public RunDialogSettingsPage()
        {
            InitializeComponent();
        }

        private RunDialogSettings _settings = default!;
    }
}
