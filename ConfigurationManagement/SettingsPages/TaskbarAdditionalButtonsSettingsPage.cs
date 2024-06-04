using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using AquariusShell.ConfigurationManagement.Settings;
using AquariusShell.Modules;
using AquariusShell.Objects;
using AquariusShell.Runtime;

namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    /// <summary>
    /// Settings to configure <see cref="ConfigurationManagement.Settings.TaskbarAdditionalButtonsSettings"/>
    /// </summary>
    public partial class TaskbarAdditionalButtonsSettingsPage : UserControl, ISettingsPage
    {
        /// <summary>
        /// Persist settings
        /// </summary>
        public void MustApplySettings()
        {
            // All settings have been collected already in the Add, Edit, Delete buttons
            ConfigurationProvider<TaskbarAdditionalButtonsSettings>.Set(_settings);
        }

        /// <summary>
        /// Reload settings
        /// </summary>
        public void Reload()
        {
            _settings = ConfigurationProvider<TaskbarAdditionalButtonsSettings>.Get();

            IconSettings iconSettings = ConfigurationProvider<IconSettings>.Get();
            _definedButtonSize = iconSettings.Size.ToNextLargerSize().ToPixels();

            _currentEditItem = string.Empty;

            List<string> garbageEntries = new();
            foreach (KeyValuePair<string, CustomButtonSettings> item in _settings.CustomButtons)
            {
                bool hasIcon = ((!string.IsNullOrWhiteSpace(item.Value.IconPath)) ? true : false)
                    , hasCaption = ((!string.IsNullOrWhiteSpace(item.Value.Caption)) ? true : false);

                if ((!hasIcon) && (!hasCaption))
                {
                    // garbage entry
                    garbageEntries.Add(item.Key);
                    continue;
                }

                DrawButton(item.Key);
            }

            // clear garbage so we don't persist them
            if (garbageEntries.Count > 0)
            {
                TaskbarAdditionalButtonsSettings garbage = new();
                foreach (string item in garbageEntries)
                {
                    garbage.CustomButtons.Add(item, new());
                    _settings.CustomButtons.Remove(item);
                }

                ConfigurationProvider<TaskbarAdditionalButtonsSettings>.Delete(garbage);
            }
        }

        /// <summary>
        /// Clear the edit fields
        /// </summary>
        private void ClearEditControls()
        {
            _currentEditItem = string.Empty;
            pbButtonIcon.Image = null;
            tbCaption.Text = string.Empty;
            cmbBuiltInCommands.SelectedIndex = -1;
            tbCustomCommand.Text = string.Empty;
            tbCustomCommand.Enabled = false;
        }

        /// <summary>
        /// Draw the button referenced by the provided key
        /// </summary>
        /// <param name="key">Key in the CustomButtons dictionary</param>
        private void DrawButton(string key)
        {
            string controlName = $"btnDef{key}";

            Control[] matches = flpDefinedButtons.Controls.Find(controlName, false);
            if (matches.Length > 0)
            {
                Button existingButton = (Button)matches[0];
                if (existingButton != null)
                {
                    flpDefinedButtons.Controls.Remove(existingButton);
                }
            }

            if (!_settings.CustomButtons.TryGetValue(key, out CustomButtonSettings? value))
            {
                return;
            }

            CustomButtonSettings item = value;

            bool hasIcon = ((!string.IsNullOrWhiteSpace(item.IconPath)) ? true : false)
                    , hasCaption = ((!string.IsNullOrWhiteSpace(item.Caption)) ? true : false);

            Button customButton = new()
            {
                Name = controlName,
                Tag = item.Command,
                Size = new Size(_definedButtonSize, _definedButtonSize)
            };

            if (hasIcon)
            {
                customButton.Image = new Bitmap(Bitmap.FromFile(item.IconPath!), ShellEnvironment.ConfiguredSizeOfIconsInPixels, ShellEnvironment.ConfiguredSizeOfIconsInPixels);
                customButton.ImageAlign = ContentAlignment.MiddleCenter;
            }

            if (hasCaption)
            {
                customButton.Text = item.Caption!;
                customButton.TextAlign = ContentAlignment.MiddleCenter;
            }

            if (hasIcon && hasCaption)
            {
                customButton.TextImageRelation = TextImageRelation.ImageAboveText;

                // Enlarge to (hopefully!) accomadate both the icon and caption
                customButton.Size = new Size(_definedButtonSize + 24, _definedButtonSize + 24);
            }

            customButton.Click += ExistingCustomButtonDefinition_Click;
            flpDefinedButtons.Controls.Add(customButton);
        }

        /// <summary>
        /// Clicked on an existing custom button definition. Show it in the edit controls above it
        /// </summary>
        private void ExistingCustomButtonDefinition_Click(object? sender, EventArgs e)
        {
            Button button = (Button)sender!;
            _currentEditItem = button.Name[6..];

            pbButtonIcon.ImageLocation = _settings.CustomButtons[_currentEditItem].IconPath;
            tbCaption.Text = _settings.CustomButtons[_currentEditItem].Caption;
            int cmdIndex = -1;
            for (int i = 0; i < cmbBuiltInCommands.Items.Count; i++)
            {
                NameValuePair<string> item = (NameValuePair<string>)cmbBuiltInCommands.Items[i]!;
                if (item.Value!.Equals(_settings.CustomButtons[_currentEditItem].Command, StringComparison.InvariantCultureIgnoreCase))
                {
                    cmdIndex = i;
                    break;
                }
            }
            if (cmdIndex == -1)
            {
                // The last item!
                cmbBuiltInCommands.SelectedIndex = cmbBuiltInCommands.Items.Count - 1;

                tbCustomCommand.Enabled = true;
                tbCustomCommand.Text = _settings.CustomButtons[_currentEditItem].Command;
            }
            else
            {
                cmbBuiltInCommands.SelectedIndex = cmdIndex;
                tbCustomCommand.Enabled = false;
            }
        }

        /// <summary>
        /// Select icon for button
        /// </summary>
        private void pbButtonIcon_Click(object sender, EventArgs e)
        {
            if (ofdPickButtonIcon.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            pbButtonIcon.ImageLocation = ofdPickButtonIcon.FileName;
        }

        /// <summary>
        /// Command dropdown list clicked. If user selects the "Custom command" option, enable the textbox for it
        /// </summary>
        private void cmbBuiltInCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbCustomCommand.Enabled = false;
            if (cmbBuiltInCommands.SelectedIndex > -1)
            {
                NameValuePair<string> item = (NameValuePair<string>)cmbBuiltInCommands.Items[cmbBuiltInCommands.SelectedIndex]!;

                // the option for custom command has an empty string as its value
                if (string.IsNullOrWhiteSpace(item.Value))
                {
                    tbCustomCommand.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Delete button definition
        /// </summary>
        private void btnDeleteButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_currentEditItem))
            {
                _settings.CustomButtons.Remove(_currentEditItem);

                // Since we have already removed it, 
                // this will cause the button to be deleted
                DrawButton(_currentEditItem);
            }

            ClearEditControls();
        }

        /// <summary>
        /// Update existing button definition
        /// </summary>
        private void btnUpdateButton_Click(object sender, EventArgs e)
        {
            if (_currentEditItem == string.Empty)
            {
                // Add it instead
                btnAddButton_Click(sender, e);
                return;
            }

            CustomButtonSettings? buttonSettings = PopulateFromEditControls();
            if (buttonSettings == null)
            {
                return;
            }

            _settings.CustomButtons[_currentEditItem] = buttonSettings;
            DrawButton(_currentEditItem);
            ClearEditControls();
        }

        /// <summary>
        /// Add a new button definition using the values in the edit controls
        /// </summary>
        private void btnAddButton_Click(object sender, EventArgs e)
        {
            if (_currentEditItem != string.Empty)
            {
                btnUpdateButton_Click(sender, e);
                return;
            }

            _currentEditItem = Guid.NewGuid().ToString("n");
            CustomButtonSettings? buttonSettings = PopulateFromEditControls();
            if (buttonSettings == null)
            {
                return;
            }

            _settings.CustomButtons.Add(_currentEditItem, buttonSettings);
            DrawButton(_currentEditItem);
            ClearEditControls();
        }

        /// <summary>
        /// Create a CustomButtonSettings from current edit control values
        /// </summary>
        /// <returns>CustomButtonSettings</returns>
        private CustomButtonSettings? PopulateFromEditControls()
        {
            string command = tbCustomCommand.Text;
            if ((cmbBuiltInCommands.SelectedIndex >= 0) && (cmbBuiltInCommands.SelectedIndex < (cmbBuiltInCommands.Items.Count - 1)))
            {
                command = ((NameValuePair<string>)cmbBuiltInCommands.SelectedItem!).Value ?? string.Empty;
            }

            if ((string.IsNullOrWhiteSpace(pbButtonIcon.ImageLocation) && string.IsNullOrWhiteSpace(tbCaption.Text)) || string.IsNullOrWhiteSpace(command))
            {
                MessageBox.Show("A button must have (either an icon or a caption), and a command!");
                return null;
            }

            return new()
            {
                Command = command,
                IconPath = pbButtonIcon.ImageLocation,
                Caption = tbCaption.Text
            };
        }

        /// <summary>
        /// Initialise
        /// </summary>
        public TaskbarAdditionalButtonsSettingsPage()
        {
            InitializeComponent();

            cmbBuiltInCommands.Items.Clear();
            foreach (AppIconOrShortcut item in ShellEnvironment.ShellApps)
            {
                NameValuePair<string> cmd = new()
                {
                    Text = item.AppName,
                    Value = item.Command
                };

                cmbBuiltInCommands.Items.Add(cmd);
            }

            cmbBuiltInCommands.Items.Add(new NameValuePair<string>()
            {
                Text = "Other custom command...",
                Value = string.Empty
            });

            tbCustomCommand.Enabled = false;

            Reload();
        }

        private string _currentEditItem = string.Empty;
        private TaskbarAdditionalButtonsSettings _settings = default!;
        private int _definedButtonSize = 16;
    }
}
