using System;

namespace AquariusShell.ConfigurationManagement.Reflection
{
    /// <summary>
    /// Configure the registry value name a specific setting value is stored into
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class RegistryValueNameAttribute : Attribute
    {
        /// <summary>
        /// Name of the value
        /// </summary>
        public string ValueName
        {
            get;
            private set;

        } = string.Empty;

        /// <summary>
        /// Configure the registry value name a specific setting value is stored into
        /// </summary>
        /// <param name="valueName">Name of the value</param>
        public RegistryValueNameAttribute(string valueName)
        {
            if (string.IsNullOrWhiteSpace(valueName))
            {
                throw new ArgumentNullException(nameof(valueName), "Must provide valid string");
            }

            ValueName = valueName;
        }
    }

}
