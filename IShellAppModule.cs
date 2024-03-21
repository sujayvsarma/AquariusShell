using System.Drawing;
using System.Windows.Forms;

namespace AquariusShell
{
    /// <summary>
    /// Any form or class implementing this is an internal "app". Such apps are listed on the 
    /// program launcher and can be run independently.
    /// </summary>
    internal interface IShellAppModule
    {
        /// <summary>
        /// The icon displayable for this module in the program launcher etc
        /// </summary>
        public Image LauncherOrTaskManagerIcon { get; }

        /// <summary>
        /// The caption text for this in the program launcher etc
        /// </summary>
        public string Caption { get; }

        /// <summary>
        /// The launch command for this module
        /// </summary>
        public string Command { get; }

        /// <summary>
        /// Type of instancing
        /// </summary>
        public ShellAppInstancingModeEnum InstancingMode { get; }

        /// <summary>
        /// When set, this app is not shown on the Launcher UI
        /// </summary>
        public bool HideFromLauncher { get; }


        /// <summary>
        /// Evaluate the provided command and respond if this module can handle it.
        /// </summary>
        /// <param name="command">Command string to evaluate.</param>
        /// <param name="parameters">Any potential parameters for this command (context)</param>
        /// <returns>TRUE if this module can handle it.</returns>
        public bool HandlesCommand(string command, params string[] parameters);

        /// <summary>
        /// Execute the module
        /// </summary>
        /// <param name="command">Command string</param>
        /// <param name="parentWindowHandle">Parent window. If NULL, sets to Workarea</param>
        /// <param name="parameters">Any parameters for this command (context)</param>
        public void Execute(string command, IWin32Window? parentWindowHandle, params string[] parameters);


        /// <summary>
        /// If a command/path is prefixed by this, it means it is a command.
        /// </summary>
        public static readonly string CommandSignifierPrefix = "::";

        /// <summary>
        /// Notify that this app was closed by the user
        /// </summary>
        event BuiltInAppClosed AppClosed;
    }

    /// <summary>
    /// Type of instancing for a ShellApp
    /// </summary>
    public enum ShellAppInstancingModeEnum
    {
        /// <summary>
        /// Single instance, new instance cannot be created until existing instance is cleared
        /// </summary>
        Single = 0,

        /// <summary>
        /// Multiple, parallel instances may run
        /// </summary>
        Multiple
    }
}
