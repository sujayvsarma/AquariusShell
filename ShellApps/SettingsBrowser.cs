using System;
using System.Drawing;
using System.Windows.Forms;

using AquariusShell.ConfigurationManagement.SettingsPages;
using AquariusShell.Properties;
using AquariusShell.Runtime;

namespace AquariusShell.ShellApps
{
    public partial class SettingsBrowser : Form, IShellAppModule
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
                _icon ??= new Bitmap(Resources.properties_settings_gears, ShellEnvironment.ConfiguredSizeOfIconsInPixels, ShellEnvironment.ConfiguredSizeOfIconsInPixels);
                return _icon;
            }
        }
        private Image? _icon = null;

        /// <summary>
        /// The caption text for this in the program launcher etc
        /// </summary>
        public string Caption => "Configure shell";

        /// <summary>
        /// The launch command for this module
        /// </summary>
        public string Command => _command;
        private static readonly string _command = $"{IShellAppModule.CommandSignifierPrefix}aqShellConfig";

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

        /// <summary>
        /// Notify that this app was closed by the user
        /// </summary>
        public event BuiltInAppClosed? AppClosed;

        #endregion

        public SettingsBrowser()
        {
            InitializeComponent();

            currentPage = null;
        }

        private void tvSettingsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            pnlSettingsPageHost.Controls.Clear();

            // Load the settings page and show it
            switch (e.Node!.Name)
            {
                case "tvnGlobal":
                    GlobalSettingsPage globalSettingsPage = new();
                    pnlSettingsPageHost.Controls.Add(globalSettingsPage);
                    currentPage = globalSettingsPage;
                    break;

                case "tvnGlobalIcons":
                    GlobalIconSettingsPage globalIconSettingsPage = new();
                    pnlSettingsPageHost.Controls.Add(globalIconSettingsPage);
                    currentPage = globalIconSettingsPage;
                    break;

                case "tvnTaskbar":
                    TaskbarSettingsPage taskbarSettingsPage = new();
                    pnlSettingsPageHost.Controls.Add(taskbarSettingsPage);
                    currentPage = taskbarSettingsPage;
                    break;

                case "tvnTaskbarCustomButtons":
                    TaskbarAdditionalButtonsSettingsPage taskbarAdditionalButtonsSettingsPage = new();
                    pnlSettingsPageHost.Controls.Add(taskbarAdditionalButtonsSettingsPage);
                    currentPage = taskbarAdditionalButtonsSettingsPage;
                    break;

                case "tvnLauncher":
                    ProgramLauncherSettingsPage programLauncherSettingsPage = new();
                    pnlSettingsPageHost.Controls.Add(programLauncherSettingsPage);
                    currentPage = programLauncherSettingsPage;
                    break;

                case "tvnShellAppsFileBrowser":
                    FileBrowserSettingsPage fileBrowserSettingsPage = new();
                    pnlSettingsPageHost.Controls.Add(fileBrowserSettingsPage);
                    currentPage = fileBrowserSettingsPage;
                    break;

                case "tvnShellAppsFileBrowserDFFProperties":
                    FilesystemPropertyPageSettingsPage filesystemPropertyPageSettingsPage = new();
                    pnlSettingsPageHost.Controls.Add(filesystemPropertyPageSettingsPage);
                    currentPage = filesystemPropertyPageSettingsPage;
                    break;

                case "tvnShellAppsAclBrowser":
                    AclBrowserSettingsPage aclBrowserSettingsPage = new();
                    pnlSettingsPageHost.Controls.Add(aclBrowserSettingsPage);
                    currentPage = aclBrowserSettingsPage;
                    break;

                case "tvnShellAppsRun":
                    RunDialogSettingsPage runDialogSettingsPage = new();
                    pnlSettingsPageHost.Controls.Add(runDialogSettingsPage);
                    currentPage = runDialogSettingsPage;
                    break;

                case "tvnShellAppsTerminateShell":
                    TerminateShellSettingsPage terminateShellSettingsPage = new();
                    pnlSettingsPageHost.Controls.Add(terminateShellSettingsPage);
                    currentPage = terminateShellSettingsPage;
                    break;

                case "tvnShellAppsWorkspace":
                    WorkspaceAreaSettingsPage workspaceAreaSettingsPage = new();
                    pnlSettingsPageHost.Controls.Add(workspaceAreaSettingsPage);
                    currentPage = workspaceAreaSettingsPage;
                    break;

                case "tvnSettingsBrowser":
                    SettingsBrowserSettingsPage settingsBrowserSettingsPage = new();
                    pnlSettingsPageHost.Controls.Add(settingsBrowserSettingsPage);
                    currentPage = settingsBrowserSettingsPage;
                    break;


                case "tvnWindowsControlPanel":
                    // This is not a traditional "settings" page
                    WindowsControlPanelListSettingsPage windowsControlPanelListSettingsPage = new();
                    pnlSettingsPageHost.Controls.Add(windowsControlPanelListSettingsPage);
                    currentPage = windowsControlPanelListSettingsPage;
                    break;
            }
        }

        /// <summary>
        /// Close the form
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResetPageToDefaults_Click(object sender, EventArgs e)
        {
            // Send the page reset event
        }

        private void btnApplyPage_Click(object sender, EventArgs e)
        {
            // Send the page apply event
            currentPage?.MustApplySettings();
        }

        /// <summary>
        /// Notify app closure
        /// </summary>
        private void SettingsBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppClosed?.Invoke(typeof(SettingsBrowser));
        }

        private ISettingsPage? currentPage = null;
    }
}
