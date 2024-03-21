using System.Collections.Generic;
using AquariusShell.ConfigurationManagement.Reflection;

namespace AquariusShell.ConfigurationManagement.Settings
{
    /// <summary>
    /// Additional buttons in the taskbar. Only shown if TaskbarSettings.ShowAdditionalButtons is TRUE!
    /// </summary>
    [RegistryKeyName("TaskbarAdditionalButtons")]
    internal class TaskbarAdditionalButtonsSettings : IAquariusShellSettings
    {
        /// <summary>
        /// Definition of custom buttons.
        /// Key: a token/identifier for the key; 
        /// Value: definition of the custom button
        /// </summary>
        [RegistryKeyPair]
        public Dictionary<string, CustomButtonSettings> CustomButtons
        {
            get;
            private set;

        } = new();

    }
}
