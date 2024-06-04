using System;
using System.Windows.Forms;

using AquariusShell.ConfigurationManagement.Settings;

namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    /// <summary>
    /// Settings to configure <see cref="ConfigurationManagement.Settings.TaskbarSettings"/>
    /// </summary>
    public partial class TaskbarSettingsPage : UserControl, ISettingsPage
    {
        /// <summary>
        /// Save changes
        /// </summary>
        public void MustApplySettings()
        {
            if (rbBottom.Checked)
            {
                _settings.Location = Constants.TaskbarPositionsEnum.Bottom;
            }
            else if (rbTop.Checked)
            {
                _settings.Location = Constants.TaskbarPositionsEnum.Top;
            }
            else if (rbLeft.Checked)
            {
                _settings.Location = Constants.TaskbarPositionsEnum.Left;
            }
            else if (rbRight.Checked)
            {
                _settings.Location = Constants.TaskbarPositionsEnum.Right;
            }

            _settings.ShowTaskSwitcherButton = chkShowTaskSwitcher.Checked;
            _settings.ShowCaptions = chkShowCaptions.Checked;
            _settings.ShowClock = chkShowClock.Checked;
            if (_settings.ShowClock)
            {
                // Validate!
                try
                {
                    string str = DateTime.Now.ToString(tbClockFormat.Text);
                    tbClockPreview.Text = str;
                }
                catch
                {
                    MessageBox.Show("One or more tokens used in the 'Date and time display format' field is unknown or not supported. Please check and try again!");
                    tbClockFormat.Focus();
                    return;
                }

                _settings.ClockDisplayFormat = tbClockFormat.Text;
            }

            _settings.BackgroundColour = pbBackgroundColour.BackColor;
            _settings.TextColour = pbForegroundColour.BackColor;

            _settings.ShowAdditionalButtons = chkShowAdditionalButtons.Checked;

            ConfigurationProvider<TaskbarSettings>.Set(_settings);
        }

        /// <summary>
        /// Reload settings
        /// </summary>
        public void Reload()
        {
            _settings = ConfigurationProvider<TaskbarSettings>.Get();

            switch (_settings.Location)
            {
                case Constants.TaskbarPositionsEnum.Bottom:
                    rbBottom.Checked = true;
                    break;

                case Constants.TaskbarPositionsEnum.Top:
                    rbTop.Checked = true;
                    break;

                case Constants.TaskbarPositionsEnum.Left:
                    rbLeft.Checked = true;
                    break;

                case Constants.TaskbarPositionsEnum.Right:
                    rbRight.Checked = true;
                    break;
            }

            chkShowTaskSwitcher.Checked = _settings.ShowTaskSwitcherButton;
            chkShowCaptions.Checked = _settings.ShowCaptions;
            chkShowClock.Checked = _settings.ShowClock;
            if (_settings.ShowClock)
            {
                tbClockFormat.Text = _settings.ClockDisplayFormat;
                try
                {
                    string str = DateTime.Now.ToString(_settings.ClockDisplayFormat);
                    tbClockPreview.Text = str;
                }
                catch { }
            }

            pbBackgroundColour.BackColor = _settings.BackgroundColour;
            pbForegroundColour.BackColor = _settings.TextColour;

            chkShowAdditionalButtons.Checked = _settings.ShowAdditionalButtons;
        }

        /// <summary>
        /// Pick background colour
        /// </summary>
        private void pbBackgroundColour_Click(object sender, EventArgs e)
        {
            if (colColourPicker.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            _settings.BackgroundColour = colColourPicker.Color;
            pbBackgroundColour.BackColor = colColourPicker.Color;
        }

        /// <summary>
        /// Pick foreground colour
        /// </summary>
        private void pbForegroundColour_Click(object sender, EventArgs e)
        {
            if (colColourPicker.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            _settings.TextColour = colColourPicker.Color;
            pbForegroundColour.BackColor = colColourPicker.Color;
        }

        /// <summary>
        /// Preview date/time format string
        /// </summary>
        private void tbClockFormat_TextChanged(object sender, EventArgs e)
        {
            string format = tbClockFormat.Text;
            try
            {
                string str = DateTime.Now.ToString(format);
                tbClockPreview.Text = str;
            }
            catch { }
        }

        /// <summary>
        /// Initialise
        /// </summary>
        public TaskbarSettingsPage()
        {
            InitializeComponent();

            Reload();
        }

        private TaskbarSettings _settings = default!;
    }
}
