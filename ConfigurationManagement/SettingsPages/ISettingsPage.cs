namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    /// <summary>
    /// Interface that all settings pages implement
    /// </summary>
    public interface ISettingsPage
    {

        /// <summary>
        /// Notification from the SettingsBrowser to a settings page that it must now save any changes.
        /// </summary>
        void MustApplySettings();

        /// <summary>
        /// Reload settings from provider, don't apply what you have.
        /// </summary>
        void Reload();

    }
}
