using System;
using System.Windows.Forms;

using AquariusShell.ConfigurationManagement.Constants;
using AquariusShell.ConfigurationManagement.Settings;
using AquariusShell.Objects;
using AquariusShell.Runtime;

namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    /// <summary>
    /// Settings to configure <see cref="ConfigurationManagement.Settings.FileBrowserSettings"/>
    /// </summary>
    public partial class FileBrowserSettingsPage : UserControl, ISettingsPage
    {
        /// <summary>
        /// Persist settings
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
                        Command = tbInitialDirectory.Text
                    };
                }
            }

            _settings.ShowToolbarCaptions = chkShowCaptionsOnToolbar.Checked;
            _settings.AllowJumpToAddress = chkAllowJumpToAddress.Checked;
            _settings.EnableTabbedBrowsing = chkEnableTabbedBrowsing.Checked;
            _settings.ShowDeletedItems = chkShowDeletedItems.Checked;

            _settings.EnabledButtons = 0;
            foreach (NameValuePair<FileBrowserToolbarButtonsEnumFlags> flagPair in lstEnabledButtons.SelectedItems)
            {
                _settings.EnabledButtons |= flagPair.Value;
            }

            _settings.HiddenFolders = [];
            foreach (NameValuePair<string> folderPair in mngLstHiddenPaths.SelectedItems)
            {
                _settings.HiddenFolders.Add(folderPair.Value!);
            }

            ConfigurationProvider<FileBrowserSettings>.Set(_settings);
        }

        /// <summary>
        /// Load settings
        /// </summary>
        public void Reload()
        {
            lstEnabledButtons.Items.Clear();

            _settings = ConfigurationProvider<FileBrowserSettings>.Get();

            chkShowAppOnLauncher.Checked = _settings.ShowOnLauncher;
            if (_settings.ShowOnLauncher)
            {
                if (_settings.CustomButton != default!)
                {
                    pbLauncherIcon.ImageLocation = _settings.CustomButton.IconPath;
                    tbLauncherCaption.Text = _settings.CustomButton.Caption;
                    tbInitialDirectory.Text = _settings.CustomButton.Command;
                }
            }

            chkShowCaptionsOnToolbar.Checked = _settings.ShowToolbarCaptions;
            chkAllowJumpToAddress.Checked = _settings.AllowJumpToAddress;
            chkEnableTabbedBrowsing.Checked = _settings.EnableTabbedBrowsing;
            chkShowDeletedItems.Checked = _settings.ShowDeletedItems;

            foreach (FileBrowserToolbarButtonsEnumFlags buttonFlag in Enum.GetValues<FileBrowserToolbarButtonsEnumFlags>())
            {
                if ((buttonFlag == FileBrowserToolbarButtonsEnumFlags.All) || buttonFlag.ToString().StartsWith("Combined"))
                {
                    break;
                }

                NameValuePair<FileBrowserToolbarButtonsEnumFlags> item = new()
                {
                    Text = buttonFlag.GetEnumFriendlyName(),
                    Value = buttonFlag
                };

                int index = lstEnabledButtons.Items.Add(item);

                if (_settings.EnabledButtons.HasFlag(item.Value))
                {
                    lstEnabledButtons.SetSelected(index, true);
                }
            }

            mngLstHiddenPaths.AddIems(_settings.HiddenFolders);
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
        /// Browse button clicked, find a directory
        /// </summary>
        private void btnBrowseForInitialDirectory_Click(object sender, EventArgs e)
        {
            if (fbdFindInitialDirectoryPath.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            tbInitialDirectory.Text = fbdFindInitialDirectoryPath.SelectedPath;
        }

        /// <summary>
        /// Initialise
        /// </summary>
        public FileBrowserSettingsPage()
        {
            InitializeComponent();

            mngLstHiddenPaths.AllowSelectApps = false;
            mngLstHiddenPaths.AllowSelectDrivesDirectoriesAndFiles = true;
            Reload();
        }

        private FileBrowserSettings _settings = default!;
    }
}
