using System;
using System.Drawing;
using System.Windows.Forms;

using AquariusShell.ConfigurationManagement.Settings;
using AquariusShell.Forms;
using AquariusShell.Modules;
using AquariusShell.Objects;

namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    /// <summary>
    /// Simply displays a list of Windows control panel items. When an item is clicked, it executes the applet.
    /// THIS IS NOT A TRUE "Settings" PAGE LIKE THE OTHERS IN THIS NAMESPACE/FOLDER!
    /// </summary>
    public partial class WindowsControlPanelListSettingsPage : UserControl, ISettingsPage
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public WindowsControlPanelListSettingsPage()
        {
            InitializeComponent();

            Reload();
        }


        /// <summary>
        /// Not implemented! Not applicable for this control!
        /// </summary>
        public void MustApplySettings()
        {
        }

        /// <summary>
        /// Load the items into the view
        /// </summary>
        public void Reload()
        {
            _settings = ConfigurationProvider<SettingsBrowserSettings>.Get();
            if (_settings.AllowDisabledAppletsExecutionWithPassword)
            {
                _launchPassword = PasswordManagement.RetrievePassword(PasswordModuleNames.Shell, PasswordUsagePurposes.LaunchHiddenWindowsControlPanelApplet);
            }

            foreach(NameValuePair<string> item in AquariusShell.Modules.Constants.ALL_WINDOWS10_CONTROLPANEL_ITEMS)
            {
                bool showApp = true, requirePassword = false;

                if (NameValuePair<string>.Contains(_settings.DisabledWin32Applets, item))
                {
                    showApp = false;

                    if (_settings.AllowDisabledAppletsExecutionWithPassword)
                    {
                        showApp = true;
                        requirePassword = true;
                    }
                }

                if (!showApp)
                {
                    continue;
                }

                ListViewItem lvi = new()
                {
                    Text = item.Text,
                    Tag = item.Value
                };

                if (requirePassword)
                {
                    lvi.ForeColor = Color.Red;
                }

                lvActiveFolderItems.Items.Add(lvi);
            }
        }

        /// <summary>
        /// Double-click on item, launch it
        /// </summary>
        private void lvActiveFolderItems_ItemActivate(object sender, EventArgs e)
        {
            if ((lvActiveFolderItems.SelectedItems[0].ForeColor == Color.Red) && (! string.IsNullOrWhiteSpace(_launchPassword)))
            {
                // require a password
                PopupTextInput input = new()
                {
                    Prompt = "Launching this applet requires a password. Please enter the password if you know it.",
                    IsCancellable = true
                };

                if (input.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                if (! _launchPassword.Equals(input.Value))
                {
                    MessageBox.Show("That is not the required password!", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string command = lvActiveFolderItems.SelectedItems[0].Tag!.ToString()!;
            Shell32.ExecuteRundll32Command(command);
        }


        private const string ControlPanelFolderId = "82A74AEB-AEB4-465C-A014-D097EE346D63";
        private readonly Guid ControlPanelFolderGuid = new(ControlPanelFolderId);
        private SettingsBrowserSettings _settings = default!;
        private string? _launchPassword;
       
    }
}
