using System;
using System.Drawing;
using System.Windows.Forms;

using AquariusShell.ConfigurationManagement.Constants;
using AquariusShell.ConfigurationManagement.Settings;
using AquariusShell.Objects;

namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    /// <summary>
    /// Settings to configure <see cref="ConfigurationManagement.Settings.WorkspaceAreaSettings"/>
    /// </summary>
    public partial class WorkspaceAreaSettingsPage : UserControl, ISettingsPage
    {
        /// <summary>
        /// Persist settings
        /// </summary>
        public void MustApplySettings()
        {
            // background colour already set using the tb/pb
            _settings.ShowBackgroundImage = chkShowBackgroundImage.Checked;
            if (_settings.ShowBackgroundImage)
            {
                _settings.BackgroundImagesSource = cmbBackgroundImageSource.SelectedIndex switch
                {
                    0 => BackgroundImagesSourcesEnum.LocalFolder,
                    _ => BackgroundImagesSourcesEnum.WebService
                };

                switch (_settings.BackgroundImagesSource)
                {
                    case BackgroundImagesSourcesEnum.LocalFolder:
                        _settings.BackgroundImageLocation = tbLocalFolderSourceLocation.Text;
                        break;

                    default:
                        _settings.BackgroundImageLocation = WorkspaceAreaSettings.DEFAULT_BING_IMAGES_URL;
                        break;
                }

                _settings.BackgroundImageChangeInterval = (int)tbPictureChangeInterval.Value * cmbBackgroundChangeIntervalUnits.SelectedIndex switch
                {
                    0 => 1,
                    1 => 60,
                    2 => (60 * 60),
                    3 => (60 * 60 * 24)
                };
            }

            _settings.ShowWindowsDesktopIcons = chkShowIconsOnDesktop.Checked;

            ConfigurationProvider<WorkspaceAreaSettings>.Set(_settings);
        }

        /// <summary>
        /// Load settings
        /// </summary>
        public void Reload()
        {
            _settings = ConfigurationProvider<WorkspaceAreaSettings>.Get();

            pbBackgroundColour.BackColor = _settings.BackgroundColour;
            tbBackgroundColourHex.Text = ColorTranslator.ToHtml(_settings.BackgroundColour);
            chkShowBackgroundImage.Checked = _settings.ShowBackgroundImage;
            chkShowIconsOnDesktop.Checked = _settings.ShowWindowsDesktopIcons;

            if (_settings.ShowBackgroundImage)
            {
                cmbBackgroundImageSource.SelectedIndex = _settings.BackgroundImagesSource switch
                {
                    BackgroundImagesSourcesEnum.LocalFolder => 0,
                    _ => 1
                };

                tbPictureChangeInterval.Value = _settings.BackgroundImageChangeInterval;
                if (_settings.BackgroundImageChangeInterval <= 60)
                {
                    // seconds
                    cmbBackgroundChangeIntervalUnits.SelectedIndex = 0;
                }
                else if (_settings.BackgroundImageChangeInterval <= 3600)
                {
                    // minutes
                    cmbBackgroundChangeIntervalUnits.SelectedIndex = 1;
                }
                else if (_settings.BackgroundImageChangeInterval < 86400)
                {
                    // hours
                    cmbBackgroundChangeIntervalUnits.SelectedIndex = 2;
                }
                else
                {
                    // days
                    cmbBackgroundChangeIntervalUnits.SelectedIndex = 2;
                }

                if (_settings.BackgroundImagesSource == BackgroundImagesSourcesEnum.LocalFolder)
                {
                    tbLocalFolderSourceLocation.Text = _settings.BackgroundImageLocation;
                }
            }
        }


        /// <summary>
        /// Colour tile colour changed. Update the settings object and the text field
        /// </summary>
        private void pbBackgroundColour_Click(object sender, EventArgs e)
        {
            if (clrDlgPickBackgroundColour.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            // after...
            pbBackgroundColour.BackColor = clrDlgPickBackgroundColour.Color;
            _settings.BackgroundColour = clrDlgPickBackgroundColour.Color;
            tbBackgroundColourHex.Text = ColorTranslator.ToHtml(_settings.BackgroundColour);
        }

        /// <summary>
        /// Colour textbox value changed. Update the colour tile and the settings object
        /// </summary>
        private void tbBackgroundColourHex_TextChanged(object sender, EventArgs e)
        {
            string settingsHtmlColour = ColorTranslator.ToHtml(_settings.BackgroundColour);
            if (tbBackgroundColourHex.Text != settingsHtmlColour)
            {
                try
                {
                    _settings.BackgroundColour = ColorTranslator.FromHtml(tbBackgroundColourHex.Text);
                }
                catch
                {
                    MessageBox.Show("That is not a valid colour!", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbBackgroundColourHex.Focus();
                    return;
                }
                pbBackgroundColour.BackColor = _settings.BackgroundColour;
            }
        }

        /// <summary>
        /// Image source type changed. Enable/disable controls
        /// </summary>
        private void cmbBackgroundImageSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbBackgroundImageSource.SelectedIndex)
            {
                case 0:
                    tbLocalFolderSourceLocation.Enabled = true;
                    btnBackgroundImageFolderBrowse.Enabled = true;
                    break;

                default:
                    tbLocalFolderSourceLocation.Enabled = false;
                    btnBackgroundImageFolderBrowse.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// Background image enabled/disabled. Enable/disable other controls
        /// </summary>
        private void chkShowBackgroundImage_CheckedChanged(object sender, EventArgs e)
        {
            switch (chkShowBackgroundImage.Checked)
            {
                case true:
                    cmbBackgroundImageSource.Enabled = true;
                    tbPictureChangeInterval.Enabled = true;
                    cmbBackgroundChangeIntervalUnits.Enabled = true;
                    if (_settings.BackgroundImagesSource == BackgroundImagesSourcesEnum.LocalFolder)
                    {
                        tbLocalFolderSourceLocation.Enabled = true;
                        btnBackgroundImageFolderBrowse.Enabled = true;
                    }
                    break;

                default:
                    cmbBackgroundImageSource.Enabled = false;
                    tbPictureChangeInterval.Enabled = false;
                    cmbBackgroundChangeIntervalUnits.Enabled = false;
                    tbLocalFolderSourceLocation.Enabled = false;
                    btnBackgroundImageFolderBrowse.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// Browse button clicked. Show folder browser, update settings object
        /// </summary>
        private void btnBackgroundImageFolderBrowse_Click(object sender, EventArgs e)
        {
            if (fbdFolders.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            _settings.BackgroundImageLocation = fbdFolders.SelectedPath;
            tbLocalFolderSourceLocation.Text = fbdFolders.SelectedPath;
        }


        /// <summary>
        /// Initialise
        /// </summary>
        public WorkspaceAreaSettingsPage()
        {
            InitializeComponent();

            cmbBackgroundImageSource.Items.Clear();
            NameValuePair<BackgroundImagesSourcesEnum>[] sources =
            [
                new("Local directory", BackgroundImagesSourcesEnum.LocalFolder),
                new("Bing daily wallpaper service", BackgroundImagesSourcesEnum.WebService)
            ];

            cmbBackgroundImageSource.Items.AddRange(sources);

            Reload();
        }

        private WorkspaceAreaSettings _settings = default!;
    }
}
