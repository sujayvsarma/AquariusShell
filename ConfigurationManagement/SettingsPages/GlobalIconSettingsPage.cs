using System;
using System.Windows.Forms;

using AquariusShell.ConfigurationManagement.Constants;
using AquariusShell.ConfigurationManagement.Settings;
using AquariusShell.Objects;
using AquariusShell.Runtime;

namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    /// <summary>
    /// Settings to configure <see cref="ConfigurationManagement.Settings.IconSettings"/>
    /// </summary>
    public partial class GlobalIconSettingsPage : UserControl, ISettingsPage
    {
        /// <summary>
        /// Persist changes
        /// </summary>
        public void MustApplySettings()
        {
            if (rb16.Checked)
            {
                _settings.Size = Modules.IconSizesEnum.x16;
            }
            else if (rb24.Checked)
            {
                _settings.Size = Modules.IconSizesEnum.x24;
            }
            else if (rb32.Checked)
            {
                _settings.Size = Modules.IconSizesEnum.x32;
            }
            else if (rb64.Checked)
            {
                _settings.Size = Modules.IconSizesEnum.x64;
            }

            if (cmbCaptionDisplayOption.SelectedIndex != -1)
            {
                NameValuePair<IconCaptionDisplayEnum> item = (NameValuePair<IconCaptionDisplayEnum>)cmbCaptionDisplayOption.Items[cmbCaptionDisplayOption.SelectedIndex]!;
                _settings.CaptionDisplay = item.Value;
            }

            _settings.DefaultCaption = tbDefaultCaptionText.Text.Trim();

            ConfigurationProvider<IconSettings>.Set(_settings);
        }

        /// <summary>
        /// Reload settings from registry
        /// </summary>
        public void Reload()
        {
            _settings = ConfigurationProvider<IconSettings>.Get();

            cmbCaptionDisplayOption.Items.Clear();
            foreach(IconCaptionDisplayEnum option in Enum.GetValues<IconCaptionDisplayEnum>())
            {
                NameValuePair<IconCaptionDisplayEnum> icde = new()
                {
                    Text = option.GetEnumFriendlyName<IconCaptionDisplayEnum>(),
                    Value = option
                };

                cmbCaptionDisplayOption.Items.Add(icde);
            }

            switch (_settings.Size)
            {
                case Modules.IconSizesEnum.x16:
                    rb16.Checked = true;
                    break;

                case Modules.IconSizesEnum.x24:
                    rb24.Checked = true;
                    break;

                case Modules.IconSizesEnum.x32:
                    rb32.Checked = true;
                    break;

                case Modules.IconSizesEnum.x64:
                    rb64.Checked = true;
                    break;
            }

            cmbCaptionDisplayOption.SelectedIndex = cmbCaptionDisplayOption.FindStringExact(_settings.CaptionDisplay.GetEnumFriendlyName<IconCaptionDisplayEnum>());
            tbDefaultCaptionText.Text = _settings.DefaultCaption.Trim();
        }

        /// <summary>
        /// Initialise
        /// </summary>
        public GlobalIconSettingsPage()
        {
            InitializeComponent();

            Reload();
        }


        private IconSettings _settings = default!;
    }
}
