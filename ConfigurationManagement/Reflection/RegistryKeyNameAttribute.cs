using System;
using AquariusShell.Runtime;

using Microsoft.Win32;

namespace AquariusShell.ConfigurationManagement.Reflection
{
    /// <summary>
    /// Configure the registry key this setting is stored into
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class RegistryKeyNameAttribute : Attribute
    {
        /// <summary>
        /// RegistryHive for the settings.
        /// Default: CurrentUser
        /// </summary>
        public RegistryHive Hive
        {
            get; set;

        } = RegistryHive.CurrentUser;

        /// <summary>
        /// The root-path of the key. Do NOT terminate with "\".
        /// (eg: "Software\\SujaySarma\\Shell")
        /// </summary>
        public string ParentKeyPath
        {
            get; set;

        } = ShellEnvironment.SHELL_REGISTRYKEY;

        /// <summary>
        /// Name of the key for this setting/configuration
        /// </summary>
        public string KeyName
        {
            get; private set;

        } = string.Empty;

        /// <summary>
        /// Configure the registry key this setting is stored into
        /// </summary>
        /// <param name="keyName">Name of the key for this setting/configuration</param>
        public RegistryKeyNameAttribute(string keyName)
        {
            if (string.IsNullOrWhiteSpace(keyName))
            {
                throw new ArgumentNullException(nameof(keyName), "Must provide valid string");
            }

            KeyName = keyName;
        }

        /// <summary>
        /// Attempts to open the registry key indicated by the settings here. If the key does not 
        /// already exist, it is created.
        /// </summary>
        /// <returns>RegistryKey</returns>
        public RegistryKey GetRegistryKey()
        {
            RegistryKey rootKey = RegistryKey.OpenBaseKey(Hive, RegistryView.Default);

            string subKeyPath = $"{ParentKeyPath}\\{KeyName}";
            RegistryKey? subKey = rootKey.OpenSubKey(subKeyPath, writable: true);
            subKey ??= rootKey.CreateSubKey(subKeyPath, writable: true);

            return subKey;
        }

        /// <summary>
        /// Attempts to open the Parent key of the registry key indicated by the settings here. 
        /// If the key does not already exist, it is created.
        /// </summary>
        /// <returns>RegistryKey</returns>
        public RegistryKey GetParentKey()
        {
            RegistryKey rootKey = RegistryKey.OpenBaseKey(Hive, RegistryView.Default);

            string fullSubKeyPath = $"{ParentKeyPath}\\{KeyName}";
            string subKeyPath = fullSubKeyPath[..fullSubKeyPath.LastIndexOf('\\')];

            RegistryKey? subKey = rootKey.OpenSubKey(subKeyPath, writable: true);
            subKey ??= rootKey.CreateSubKey(subKeyPath, writable: true);

            return subKey;
        }
    }
}
