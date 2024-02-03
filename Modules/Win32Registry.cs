using AquariusShell.Runtime;

using Microsoft.Win32;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Query or store items in the Windows registry
    /// </summary>
    internal static class Win32Registry
    {

        /// <summary>
        /// Get the value of a registry key from within the Aquarius Shell forest
        /// </summary>
        /// <param name="path">Path in the forest (do not prefix the path from AquariusShellEnvironment.SHELL_REGISTRYKEY !)</param>
        /// <param name="valueName">Name of the value-key</param>
        /// <param name="defaultValue">Value to return if the key or path was not found</param>
        /// <returns>Value of the key</returns>
        public static object? Get(string path, string valueName, object? defaultValue = null)
            => Get(RegistryHive.CurrentUser, $"{ShellEnvironment.SHELL_REGISTRYKEY}\\{path}", valueName, defaultValue);

        /// <summary>
        /// Set the value of a registry key from within the Aquarius Shell forest. Applicable path/key are created if they do not exist.
        /// </summary>
        /// <param name="path">Path in the forest (do not prefix the path from AquariusShellEnvironment.SHELL_REGISTRYKEY !)</param>
        /// <param name="valueName">Name of the value-key</param>
        /// <param name="value">Value to set. Setting NULL deletes the value!</param>
        /// <returns>True if operation was successful</returns>
        public static bool Set(string path, string valueName, object? value = null)
            => Set(RegistryHive.CurrentUser, $"{ShellEnvironment.SHELL_REGISTRYKEY}\\{path}", valueName, value);

        /// <summary>
        /// Get the value of a registry key
        /// </summary>
        /// <param name="hive">Hive to get the value from</param>
        /// <param name="path">The path within the hive</param>
        /// <param name="valueName">Name of the value</param>
        /// <param name="defaultValue">Default value to return if one was not found (default: NULL)</param>
        /// <returns>Value</returns>
        public static object? Get(RegistryHive hive, string path, string valueName, object? defaultValue = null)
        {
            try
            {
                return Registry.GetValue($"{hive.ToRegistryIdentifier()}\\{path}", valueName, defaultValue);
            }
            catch { }
            return defaultValue;
        }

        /// <summary>
        /// Set the value of a registry key
        /// </summary>
        /// <param name="hive">Hive to set the value into</param>
        /// <param name="path">The path within the hive</param>
        /// <param name="valueName">Name of the value. If NULL, deletes the key</param>
        /// <param name="value">Value to set. If NULL, deletes the value from the registry</param>
        /// <returns>True if operation succeeded</returns>
        public static bool Set(RegistryHive hive, string path, string? valueName, object? value)
        {
            try
            {
                if (valueName == null)
                {
                    RegistryKey regKeyM = hive switch
                    {
                        RegistryHive.ClassesRoot => Registry.ClassesRoot,
                        RegistryHive.Users => Registry.Users,
                        RegistryHive.LocalMachine => Registry.LocalMachine,
                        RegistryHive.CurrentConfig => Registry.CurrentConfig,

                        _ => Registry.CurrentUser
                    };

                    regKeyM.DeleteSubKeyTree(path);
                }
                else if (value == null)
                {
                    RegistryKey regKeyM = hive switch
                    {
                        RegistryHive.ClassesRoot => Registry.ClassesRoot,
                        RegistryHive.Users => Registry.Users,
                        RegistryHive.LocalMachine => Registry.LocalMachine,
                        RegistryHive.CurrentConfig => Registry.CurrentConfig,

                        _ => Registry.CurrentUser
                    };

                    RegistryKey? regKey = regKeyM.OpenSubKey(path);
                    if (regKey != null)
                    {
                        regKey.DeleteValue(valueName);
                        regKey.Close();
                    }

                    regKeyM.Close();
                }
                else
                {
                    Registry.SetValue($"{hive.ToRegistryIdentifier()}\\{path}", valueName, value);
                }
                return true;
            }
            catch { }

            return false;
        }

        /// <summary>
        /// Transcribe a key enum to its string equivalent
        /// </summary>
        /// <param name="hive">Enum value of Registry hive name</param>
        /// <returns>String equivalent name of the registry hive</returns>
        private static string ToRegistryIdentifier(this RegistryHive hive)
            => hive switch
            {
                RegistryHive.ClassesRoot => "HKEY_CLASSES_ROOT",
                RegistryHive.CurrentUser => "HKEY_CURRENT_USER",
                RegistryHive.Users => "HKEY_USERS",
                RegistryHive.LocalMachine => "HKEY_LOCAL_MACHINE",
                RegistryHive.CurrentConfig => "HKEY_CURRENT_CONFIG",

                _ => "HKEY_CURRENT_USER"
            };
    }
}
