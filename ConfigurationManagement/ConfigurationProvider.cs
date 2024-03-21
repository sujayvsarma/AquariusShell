using System;
using System.Text.Json;

using AquariusShell.ConfigurationManagement.Reflection;
using AquariusShell.ConfigurationManagement.Settings;

namespace AquariusShell.ConfigurationManagement
{
    /// <summary>
    /// Wraps/Encapsulates the process of fetching and persisting configuration
    /// </summary>
    /// <typeparam name="TSettings">Type of settings object. Must implement IAquariusShellSettings interface!</typeparam>
    internal static class ConfigurationProvider<TSettings>
        where TSettings : class, IAquariusShellSettings
    {

        /// <summary>
        /// Retrieve settings
        /// </summary>
        /// <param name="refresh">(Default: OFF) Gets latest information from the registry</param>
        /// <returns>Populated instance of the settings</returns>
        public static TSettings Get(bool refresh = false)
        {
            if (refresh)
            {
                _settingsCache = (IAquariusShellSettings)ReflectionUtils.Populate(typeof(TSettings))!;
            }

            return (TSettings)_settingsCache;
        }

        /// <summary>
        /// Persist the settings to the registry
        /// </summary>
        /// <param name="settings">Instance with settings to persist</param>
        public static void Set(TSettings settings)
        {
            _settingsCache = settings;

            // persist to Registry
            ReflectionUtils.Persist<TSettings>(settings);

            ConfigurationUpdated?.Invoke(settings);
        }

        /// <summary>
        /// Delete the given settings from registry
        /// </summary>
        /// <param name="settings">Settings to delete</param>
        public static void Delete(TSettings settings)
        {
            _settingsCache = default!;

            ReflectionUtils.Delete<TSettings>(settings);
            ConfigurationUpdated?.Invoke(_settingsCache);
        }


        /// <summary>
        /// Notification to settings-consumer forms that one or more settings values have changed.
        /// </summary>
        public static event SettingsChanged? ConfigurationUpdated;



        /// <summary>
        /// Initialise. Loads and caches all settings
        /// </summary>
        static ConfigurationProvider()
        {
            IAquariusShellSettings? instance = (IAquariusShellSettings?)ReflectionUtils.Populate(typeof(TSettings)) 
                ?? throw new ArgumentException($"Type '{typeof(TSettings).Name}' does not implement IAquariusShellSettings.");
            _settingsCache = instance;
        }

        private static IAquariusShellSettings _settingsCache;


        /// <summary>
        /// Json serialisation options
        /// </summary>
        internal static JsonSerializerOptions _jsonOptions = new()
        {
            AllowTrailingCommas = false,
            WriteIndented = false
        };
    }
}
