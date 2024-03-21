using System;

namespace AquariusShell.ConfigurationManagement.Reflection
{
    /// <summary>
    /// Value name and value pair configuration. Use this on KeyValuePair and Dictionary style properties. 
    /// The Key of the KVP/Dict will be used as the Value Name and the Value as the registry value's value.
    /// 
    /// NOTE: Setting this on a KeyValuePair will be the undesirable side-effect of populating a RANDOM key/value 
    /// into it!
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class RegistryKeyPairAttribute : Attribute
    {
    }

}
