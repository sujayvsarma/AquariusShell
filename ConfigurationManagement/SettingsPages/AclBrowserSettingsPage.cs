using System;
using System.Windows.Forms;

using AquariusShell.ConfigurationManagement.Constants;
using AquariusShell.ConfigurationManagement.Settings;

namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    public partial class AclBrowserSettingsPage : UserControl, ISettingsPage
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
                        Command = string.Empty
                    };
                }
            }

            _settings.AllowTakeOwnership = chkPrincipalAllowTakeOwnership.Checked;
            _settings.AllowReplaceOwnerWithPrincipal = chkPrincipalReplaceOwner.Checked;
            _settings.AllowDeletePrincipal = chkPrincipalDelete.Checked;
            _settings.AllowEditPrincipal = chkPrincipalEdit.Checked;
            _settings.AllowAddPrincipal = chkPrincipalAdd.Checked;

            _settings.AllowSettingAllowAcls = chkAclAllow.Checked;
            _settings.AllowSettingDenyAcls = chkAclDeny.Checked;
            _settings.AllowSettingDirectoryInheritedAcls = chkAclCi.Checked;
            _settings.AllowSettingObjectInheritedAcls = chkAclOi.Checked;
            _settings.AllowSettingStandaloneAcls = chkAclStandalone.Checked;

            ConfigurationProvider<AccessControlBrowserSettings>.Set(_settings);
        }

        /// <summary>
        /// Load settings
        /// </summary>
        public void Reload()
        {
            _settings = ConfigurationProvider<AccessControlBrowserSettings>.Get();

            chkShowAppOnLauncher.Checked = _settings.ShowOnLauncher;
            if (_settings.ShowOnLauncher)
            {
                if (_settings.CustomButton != default!)
                {
                    pbLauncherIcon.ImageLocation = _settings.CustomButton.IconPath;
                    tbLauncherCaption.Text = _settings.CustomButton.Caption;
                }
            }

            chkPrincipalAllowTakeOwnership.Checked = _settings.AllowTakeOwnership;
            chkPrincipalReplaceOwner.Checked = _settings.AllowReplaceOwnerWithPrincipal;
            chkPrincipalDelete.Checked = _settings.AllowDeletePrincipal;
            chkPrincipalEdit.Checked = _settings.AllowEditPrincipal;
            chkPrincipalAdd.Checked = _settings.AllowAddPrincipal;

            chkAclAllow.Checked = _settings.AllowSettingAllowAcls;
            chkAclDeny.Checked = _settings.AllowSettingDenyAcls;
            chkAclCi.Checked = _settings.AllowSettingDirectoryInheritedAcls;
            chkAclOi.Checked = _settings.AllowSettingObjectInheritedAcls;
            chkAclStandalone.Checked = _settings.AllowSettingStandaloneAcls;
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
        /// Initialise
        /// </summary>
        public AclBrowserSettingsPage()
        {
            InitializeComponent();

            Reload();
        }


        private AccessControlBrowserSettings _settings = default!;
    }
}
