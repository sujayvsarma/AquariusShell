using System;
using System.IO;
using System.Windows.Forms;

using AquariusShell.ConfigurationManagement.Constants;
using AquariusShell.ConfigurationManagement.Settings;
using AquariusShell.Objects;
using AquariusShell.Runtime;

namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    /// <summary>
    /// Settings to configure <see cref="ConfigurationManagement.Settings.GlobalSettings"/>
    /// </summary>
    public partial class GlobalSettingsPage : UserControl, ISettingsPage
    {

        /// <summary>
        /// Notification from the SettingsBrowser to a settings page that it must now save any changes.
        /// </summary>
        public void MustApplySettings()
        {
            // The following settings are already persisted back into _settings by various event handlers below:
            // CobrandedIcon
            // CobrandedSplash
            // CacheDirectory
            // LogDirectory
            // IsLoggingEnabled

            _settings.CobrandedName = tbCobrandingName.Text.Trim();

            // We dont change existing logging settings if disabled.
            // they are simply not used :-)
            if (_settings.IsLoggingEnabled)
            {
                _settings.LogDirectory = tbLoggingDirectoryPath.Text.Trim();
                _settings.LogRolloverStrategy = Enum.Parse<LogFileRolloverStrategiesEnum>(cbLogRolloverStrategy.SelectedItem?.ToString() ?? LogFileRolloverStrategiesEnum.Daily.ToString());
                if (_settings.LogRolloverStrategy == LogFileRolloverStrategiesEnum.FileSize)
                {
                    if (! int.TryParse(tbLogFileMaxSizeBytes.Text, out int i))
                    {
                        i = -1;
                    }

                    _settings.LogFileMaximumSize = i;
                }

                LogEventsEnumFlags flags = LogEventsEnumFlags.None;
                for (int i = 0; i < cbLstLogEvents.CheckedIndices.Count; i++)
                {
                    NameValuePair<LogEventsEnumFlags> item = (NameValuePair<LogEventsEnumFlags>)cbLstLogEvents.Items[cbLstLogEvents.CheckedIndices[i]];
                    flags |= item.Value;
                }

                _settings.Events = flags;

                _settings.EnableMultiMonitorSupport = cbEnableMultiMonitorSupport.Checked;
                _settings.EnableVirtualDesktopSupport = cbEnableVirtualDesktopSupport.Checked;
            }

            ConfigurationProvider<GlobalSettings>.Set(_settings);
        }

        /// <summary>
        /// Reload settings from provider, don't apply what you have.
        /// </summary>
        public void Reload()
        {
            _settings = ConfigurationProvider<GlobalSettings>.Get();

            tbCobrandingName.Text = _settings.CobrandedName;

            if (!string.IsNullOrWhiteSpace(_settings.CobrandedIcon))
            {
                pbCobrandedIcon.ImageLocation = _settings.CobrandedIcon;
            }

            if (!string.IsNullOrWhiteSpace(_settings.CobrandSplashImage))
            {
                pbCobrandedSplash.ImageLocation = _settings.CobrandSplashImage;
            }

            tbCacheDirectoryPath.Text = _settings.CacheDirectory;

            chkIsLoggingEnabled.Checked = _settings.IsLoggingEnabled;
            foreach (LogFileRolloverStrategiesEnum strategyName in Enum.GetValues<LogFileRolloverStrategiesEnum>())
            {
                cbLogRolloverStrategy.Items.Add(strategyName.ToString());
            }

            foreach (LogEventsEnumFlags logEvent in Enum.GetValues<LogEventsEnumFlags>())
            {
                NameValuePair<LogEventsEnumFlags> nvp = new()
                {
                    Text = logEvent.GetEnumFriendlyName<LogEventsEnumFlags>(),
                    Value = logEvent
                };

                cbLstLogEvents.Items.Add(nvp);
            }

            tbLoggingDirectoryPath.Enabled = _settings.IsLoggingEnabled;
            btnLoggingDirectoryBrowse.Enabled = _settings.IsLoggingEnabled;
            cbLogRolloverStrategy.Enabled = _settings.IsLoggingEnabled;
            tbLogFileMaxSizeBytes.Enabled = _settings.IsLoggingEnabled;
            cbLstLogEvents.Enabled = _settings.IsLoggingEnabled;

            if (_settings.IsLoggingEnabled)
            {
                tbLoggingDirectoryPath.Text = _settings.LogDirectory;
                cbLogRolloverStrategy.SelectedIndex = cbLogRolloverStrategy.FindStringExact(_settings.LogRolloverStrategy.ToString());
                if (_settings.LogRolloverStrategy == LogFileRolloverStrategiesEnum.FileSize)
                {
                    tbLogFileMaxSizeBytes.Enabled = true;
                    tbLogFileMaxSizeBytes.Text = _settings.LogFileMaximumSize.ToString();
                }

                for (int i = 0; i < cbLstLogEvents.Items.Count; i++)
                {
                    NameValuePair<LogEventsEnumFlags> item = (NameValuePair<LogEventsEnumFlags>)cbLstLogEvents.Items[i];
                    cbLstLogEvents.SetItemChecked(
                            i,
                            (_settings.Events.HasFlag(item.Value) ? true : false)
                        );
                }
            }

            cbEnableMultiMonitorSupport.Checked = _settings.EnableMultiMonitorSupport;
            cbEnableVirtualDesktopSupport.Checked = _settings.EnableVirtualDesktopSupport;
        }

        /// <summary>
        /// Initialise
        /// </summary>
        public GlobalSettingsPage()
        {
            InitializeComponent();

            // Only to avoid CS8618
            // We set the value anyways in Reload() right below!
            _settings = default!;
            
            Reload();
        }

        /// <summary>
        /// Browse to select a new cobrand icon & update settings if changed
        /// </summary>
        private void pbCobrandedIcon_Click(object sender, EventArgs e)
        {
            ofdBrowseForCobrandImages.Filter = "All icon files (*.ico)|*.ico";
            ofdBrowseForCobrandImages.Title = "Select icon for Shell";

            if (!string.IsNullOrWhiteSpace(_settings.CobrandedIcon))
            {
                ofdBrowseForCobrandImages.InitialDirectory = Path.GetDirectoryName(_settings.CobrandedIcon);
                ofdBrowseForCobrandImages.FileName = Path.GetFileName(_settings.CobrandedIcon);
            }

            if (ofdBrowseForCobrandImages.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            pbCobrandedIcon.ImageLocation = ofdBrowseForCobrandImages.FileName;
            _settings.CobrandedIcon = ofdBrowseForCobrandImages.FileName;
        }

        /// <summary>
        /// Browse to select a new cobrand splash & update settings if changed
        /// </summary>
        private void pbCobrandedSplash_Click(object sender, EventArgs e)
        {
            ofdBrowseForCobrandImages.Filter = "All supported image files (*.jpg, *.jpeg, *.bmp, *.png)|*.jpg;*.jpeg; *.bmp;*.png";
            ofdBrowseForCobrandImages.Title = "Select splash image for Shell";

            if (!string.IsNullOrWhiteSpace(_settings.CobrandSplashImage))
            {
                ofdBrowseForCobrandImages.InitialDirectory = Path.GetDirectoryName(_settings.CobrandSplashImage);
                ofdBrowseForCobrandImages.FileName = Path.GetFileName(_settings.CobrandSplashImage);
            }

            if (ofdBrowseForCobrandImages.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            pbCobrandedSplash.ImageLocation = ofdBrowseForCobrandImages.FileName;
            _settings.CobrandSplashImage = ofdBrowseForCobrandImages.FileName;
        }

        /// <summary>
        /// Browse to select a new caching directory & update settings if changed
        /// </summary>
        private void btnCacheDirectoryBrowse_Click(object sender, EventArgs e)
        {
            fbdBrowseForDirectories.InitialDirectory = (string.IsNullOrWhiteSpace(_settings.CacheDirectory) ? ShellEnvironment.CacheDirectory : _settings.CacheDirectory);
            if (fbdBrowseForDirectories.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            tbCacheDirectoryPath.Text = fbdBrowseForDirectories.SelectedPath;
            _settings.CacheDirectory = fbdBrowseForDirectories.SelectedPath;
        }

        /// <summary>
        /// Browse to select a new logging directory & update settings if changed
        /// </summary>
        private void btnLoggingDirectoryBrowse_Click(object sender, EventArgs e)
        {
            fbdBrowseForDirectories.InitialDirectory = (string.IsNullOrWhiteSpace(_settings.LogDirectory) ? ShellEnvironment.LogDirectory : _settings.LogDirectory); ;
            if (fbdBrowseForDirectories.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            tbLoggingDirectoryPath.Text = fbdBrowseForDirectories.SelectedPath;
            _settings.LogDirectory = fbdBrowseForDirectories.SelectedPath;
        }

        /// <summary>
        /// Enable/disable logging, update sub-control states & update settings if changed
        /// </summary>
        private void chkIsLoggingEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsLoggingEnabled.Checked)
            {
                _settings.IsLoggingEnabled = true;

                tbLoggingDirectoryPath.Enabled = true;
                btnLoggingDirectoryBrowse.Enabled = true;
                cbLogRolloverStrategy.Enabled = true;
                

                tbLogFileMaxSizeBytes.Enabled = true;
                cbLstLogEvents.Enabled = true;
            }
            else
            {
                _settings.IsLoggingEnabled = false;

                tbLoggingDirectoryPath.Enabled = false;
                btnLoggingDirectoryBrowse.Enabled = false;
                cbLogRolloverStrategy.Enabled = false;
                tbLogFileMaxSizeBytes.Enabled = false;
                cbLstLogEvents.Enabled = false;
            }
        }

        private GlobalSettings _settings;
    }
}
