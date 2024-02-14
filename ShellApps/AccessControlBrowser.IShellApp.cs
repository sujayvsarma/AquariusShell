
using System;
using System.Drawing;
using System.Windows.Forms;

using AquariusShell.Controls;
using AquariusShell.Runtime;

namespace AquariusShell.ShellApps
{
    /// <summary>
    /// The IShellApp implementation
    /// </summary>
    public partial class AccessControlBrowser : IShellAppModule
    {
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
                    _icon = SystemIcons.GetStockIcon(StockIconId.Lock, ShellEnvironment.ConfiguredSizeOfIconsInPixels).ToBitmap();
                }

                return _icon;
            }
        }
        private Image? _icon = null;

        /// <summary>
        /// The caption text for this in the program launcher etc
        /// </summary>
        public string Caption => "Permissions browser";

        /// <summary>
        /// The launch command for this module
        /// </summary>
        public string Command => _command;
        private static string _command = $"{IShellAppModule.CommandSignifierPrefix}aclbrowser";

        /// <summary>
        /// Instancing mode
        /// </summary>
        public ShellAppInstancingModeEnum InstancingMode => ShellAppInstancingModeEnum.Multiple;

        /// <summary>
        /// When set, this app is not shown on the Launcher UI
        /// </summary>
        public bool HideFromLauncher => false;      //true;

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
                // If we were provided a parameter, it would be the context-path. Otherwise, we do the whole filesystem
                if ((parameters.Length > 0) && (!string.IsNullOrWhiteSpace(parameters[0])))
                {
                    // Load the contextual path
                    LoadContextPath(parameters[0]);
                }
                else
                {
                    // prep for lazy loading
                    LazyLoadInitialiseTree();
                }

                this.Show((parentWindowHandle ?? ShellEnvironment.WorkArea));
            }
        }

        #endregion

        /// <summary>
        /// Notify that this app was closed by the user
        /// </summary>
        public event BuiltInAppClosed? AppClosed = null;
    }
}