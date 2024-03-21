using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using AquariusShell.ConfigurationManagement;
using AquariusShell.ConfigurationManagement.Settings;
using AquariusShell.Modules;
using AquariusShell.Runtime;

namespace AquariusShell.ShellApps
{
    public partial class RunDialog : Form, IShellAppModule
    {

        #region IShellAppModule

        #region Properties

        /// <summary>
        /// The icon displayable for this module in the program launcher etc
        /// </summary>
        public Image LauncherOrTaskManagerIcon
        {
            get
            {
                _icon ??= Icon.ExtractIcon(
                                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "shell32.dll"),
                                24,                                                                                             // RUN icon
                                ShellEnvironment.ConfiguredSizeOfIconsInPixels)!
                                .ToBitmap();

                return _icon;
            }
        }
        private Image? _icon = null;

        /// <summary>
        /// The caption text for this in the program launcher etc
        /// </summary>
        public string Caption => "Open Program, Document or Website";

        /// <summary>
        /// The launch command for this module
        /// </summary>
        public string Command => _command;
        private static readonly string _command = $"{IShellAppModule.CommandSignifierPrefix}runUri";

        /// <summary>
        /// Instancing mode
        /// </summary>
        public ShellAppInstancingModeEnum InstancingMode => ShellAppInstancingModeEnum.Single;

        /// <summary>
        /// When set, this app is not shown on the Launcher UI
        /// </summary>
        public bool HideFromLauncher => false;

        #endregion

        #region Methods

        /// <summary>
        /// Evaluate the provided command and respond if this module can handle it.
        /// </summary>
        /// <param name="command">Command string to evaluate.</param>
        /// <param name="parameters">Any potential parameters for this command (context)</param>
        /// <returns>TRUE if this module can handle it.</returns>
        public bool HandlesCommand(string command, params string[] parameters)
            => command.Equals(_command, StringComparison.InvariantCultureIgnoreCase);

        /// <summary>
        /// Execute the module
        /// </summary>

        /// <param name="command">Command string</param>
        /// <param name="parentWindowHandle">Parent window. If NULL, sets to Workarea</param>
        /// <param name="parameters">Any parameters for this command (context)</param>
        public void Execute(string command, IWin32Window? parentWindowHandle, params string[] parameters)
        {
            if (_command.Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                // make it modal to the workarea!
                this.ShowDialog((parentWindowHandle ?? ShellEnvironment.WorkArea));

                // per MSDN, modal dialog forms should be disposed after use
                this.Dispose(true);
            }            
        }

        #endregion

        #endregion

        /// <summary>
        /// Initialise
        /// </summary>
        public RunDialog()
        {
            InitializeComponent();

            _settings = ConfigurationProvider<RunDialogSettings>.Get();

            pbRunIcon.Image = LauncherOrTaskManagerIcon;

            // Load the MRU
            cbURI.Items.Clear();

            if (_settings.ShowPreviouslyRunItemsList)
            {
                int startAt = 0, count = Int32.Parse(Win32Registry.Get("RunMRU", "count", "0")!.ToString()!);
                if (count > _settings.PreviouslyRunItemsListMaximumCount)
                {
                    startAt = count - _settings.PreviouslyRunItemsListMaximumCount;
                }

                for (int i = startAt; i < count; i++)
                {
                    string? item = (string?)Win32Registry.Get("RunMRU", i.ToString(), null);
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        cbURI.Items.Add(item);
                        foreach(string s in _settings.AlwaysAppendedURI)
                        {
                            if (s.Equals(item, StringComparison.InvariantCultureIgnoreCase))
                            {
                                _settings.AlwaysAppendedURI.Remove(s);
                                break;
                            }
                        }
                    }
                }
            }

            if ((_settings.AlwaysAppendedURI.Count > 0) || (! _settings.AllowBrowse) || (!_settings.AllowRunningNonMRI))
            {
                // Loop above if run, removes duplicates
                // If it didn't run (condition) then we are unique anyways!
                cbURI.Items.AddRange(_settings.AlwaysAppendedURI.ToArray());
            }

            cbURI.DropDownStyle = _settings.AllowRunningNonMRI ? ComboBoxStyle.DropDown : ComboBoxStyle.DropDownList;
            btnBrowse.Enabled = _settings.AllowBrowse;

            // positions!
            this.Location = new(
                    1,
                    ShellEnvironment.TaskbarBounds.Top - this.Height - 9
                );
        }

        #region Event Subscriptions

        /// <summary>
        /// Cancel clicked, close the form
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Browse to a program or document
        /// </summary>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdBrowse.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofdBrowse.FileName = "Untitled.txt";
            if (ofdBrowse.ShowDialog(this) == DialogResult.OK)
            {
                int sel = -1;
                for (int i = 0; i < cbURI.Items.Count; i++)
                {
                    if (((string)(cbURI.Items[i]!)).Equals(ofdBrowse.FileName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        sel = i;
                        break;
                    }
                }

                if (sel == -1)
                {
                    sel = cbURI.Items.Add(ofdBrowse.FileName);
                }

                cbURI.SelectedIndex = sel;
                cbURI.Text = ofdBrowse.FileName;
            }
        }

        /// <summary>
        /// Click event on the "Execute" button
        /// </summary>
        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbURI.Text))
            {
                MessageBox.Show("Please type in or select a program, file or website address to execute.", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Shell32.ExecuteOrLaunchTarget(cbURI.Text) != IntPtr.Zero)
            {
                bool skipStoreUri = false;
                Regex rex;
                foreach (string s in _settings.DoNotStoreURI)
                {
                    rex = new(s);
                    if (s.Equals(cbURI.Text, StringComparison.InvariantCultureIgnoreCase) || rex.Match(cbURI.Text).Success)
                    {
                        skipStoreUri = true;
                        break;
                    }
                }

                if (!skipStoreUri)
                {
                    // add to MRU
                    int count = Int32.Parse(Win32Registry.Get("RunMRU", "count", "0")!.ToString()!);
                    Win32Registry.Set("RunMRU", (count++).ToString(), cbURI.Text);
                    Win32Registry.Set("RunMRU", "count", count);
                }
            }

            this.Close();
        }

        /// <summary>
        /// Handles form closing, notify cache to refresh and dispose ourselves
        /// </summary>
        private void RunDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((e.CloseReason == CloseReason.UserClosing) && (AppClosed != null))
            {
                AppClosed(typeof(RunDialog));
            }
        }

        #endregion

        /// <summary>
        /// Notify that this app was closed by the user
        /// </summary>
        public event BuiltInAppClosed? AppClosed;

        private readonly RunDialogSettings _settings;
    }
}
