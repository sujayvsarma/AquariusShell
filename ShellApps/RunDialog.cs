using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using AquariusShell.Controls;
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
                if (_icon == null)
                {
                    _icon = Icon.ExtractIcon(
                                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "shell32.dll"),
                                24,                                                                                             // RUN icon
                                ShellEnvironment.ConfiguredSizeOfIconsInPixels)!
                                .ToBitmap();
                }

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
        private static string _command = $"{IShellAppModule.CommandSignifierPrefix}runUri";

        /// <summary>
        /// Instancing mode
        /// </summary>
        public ShellAppInstancingModeEnum InstancingMode => ShellAppInstancingModeEnum.Single;

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
        /// <param name="parameters">Any parameters for this command (context)</param>
        public void Execute(string command, params string[] parameters)
        {
            if (_command.Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                // make it modal to the workarea!
                this.ShowDialog(ShellEnvironment.WorkArea);

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

            pbRunIcon.Image = LauncherOrTaskManagerIcon;

            // Load the MRU
            cbURI.Items.Clear();

            int count = Int32.Parse(Win32Registry.Get("RunMRU", "count", "0")!.ToString()!);
            for (int i = 0; i < count; i++)
            {
                string? item = (string?)Win32Registry.Get("RunMRU", i.ToString(), null);
                if (! string.IsNullOrWhiteSpace(item))
                {
                    cbURI.Items.Add(item);
                }
            }

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
                // add to MRU
                int count = Int32.Parse(Win32Registry.Get("RunMRU", "count", "0")!.ToString()!);
                Win32Registry.Set("RunMRU", (count++).ToString(), cbURI.Text);
                Win32Registry.Set("RunMRU", "count", count);
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
    }
}
