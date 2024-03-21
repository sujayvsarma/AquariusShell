using System.Drawing;

using AquariusShell.ConfigurationManagement.Constants;
using AquariusShell.ConfigurationManagement.Reflection;

namespace AquariusShell.ConfigurationManagement.Settings
{
    /// <summary>
    /// Settings related to the Taskbar
    /// </summary>
    [RegistryKeyName("Taskbar")]
    internal class TaskbarSettings : IAquariusShellSettings
    {
        /// <summary>
        /// Location (default: Bottom)
        /// </summary>
        [RegistryValueName("Location")]
        public TaskbarPositionsEnum Location
        {
            get; set;

        } = TaskbarPositionsEnum.Bottom;

        /// <summary>
        /// Show the button for the task switcher (ALT+TAB)
        /// </summary>
        [RegistryValueName("ShowTaskSwitcherButton")]
        public bool ShowTaskSwitcherButton
        {
            get; set;

        } = true;

        /// <summary>
        /// Show additional buttons (OFF by default). When set, also set the TaskbarAdditionalButtons settings!
        /// </summary>
        [RegistryValueName("ShowAdditionalButtons")]
        public bool ShowAdditionalButtons
        {
            get; set;

        } = false;

        /// <summary>
        /// Show captions/text on the buttons displayed. Colour of text will be the TextColour set in this settings!
        /// </summary>
        [RegistryValueName("ShowCaptions")]
        public bool ShowCaptions
        {
            get; set;

        } = false;

        /// <summary>
        /// Show the clock.
        /// </summary>
        [RegistryValueName("ShowClock")]
        public bool ShowClock
        {
            get; set;

        } = true;

        /// <summary>
        /// Format string for clock display
        /// </summary>
        [RegistryValueName("ClockDisplayFormat")]
        public string ClockDisplayFormat
        {
            get; set;

        } = "MMM dd, yyyy HH:mm";


        /// <summary>
        /// Background colour of the taskbar
        /// </summary>
        [RegistryValueName("BackgroundColour")]
        public Color BackgroundColour
        {
            get; set;

        } = Color.SteelBlue;

        /// <summary>
        /// Colour of any text shown on the taskbar itself. Relevant if ShowCaptions is set.
        /// </summary>
        [RegistryValueName("TextColour")]
        public Color TextColour
        {
            get; set;

        } = Color.White;

    }
}
