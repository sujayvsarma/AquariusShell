using System;
using System.Collections.Generic;
using System.Reflection;

using Microsoft.Win32;

namespace AquariusShell.ConfigurationManagement.Reflection
{
    /// <summary>
    /// Metadata collected about a business object
    /// </summary>
    internal class TypeMetadata
    {
        /// <summary>
        /// Name of the table for the object
        /// </summary>
        public RegistryKey Key { get; private set; } = default!;

        /// <summary>
        /// Parent table for the object
        /// </summary>
        public RegistryKey ParentKey { get; private set; } = default!;

        /// <summary>
        /// Other properties of the class
        /// </summary>
        public List<MemberInfo> Members { get; private set; } = [];

        /// <summary>
        /// Discover an object's metadata using reflection
        /// </summary>
        /// <typeparam name="TObject">Type of business object</typeparam>
        /// <returns>Type metadata</returns>
        /// <exception cref="TypeLoadException">Exceptions are thrown if object is missing key attributes or values</exception>
        public static TypeMetadata Discover<TObject>()
            where TObject : class
            => Discover(typeof(TObject));


        /// <summary>
        /// Discover an object's metadata using reflection
        /// </summary>
        /// <param name="TObject">Type of object</param>
        /// <returns>Type metadata</returns>
        /// <exception cref="TypeLoadException">Exceptions are thrown if object is missing key attributes or values</exception>
        public static TypeMetadata Discover(Type TObject)
        {
            Type classType = TObject;

            RegistryKeyNameAttribute? RegistryKeyNameAttribute = classType.GetCustomAttribute<RegistryKeyNameAttribute>(true);
            if ((RegistryKeyNameAttribute == default) || string.IsNullOrWhiteSpace(RegistryKeyNameAttribute.KeyName))
            {
                throw new TypeLoadException($"The type '{classType.Name}' does not have a valid [RegistryKeyName] attribute.");
            }

            TypeMetadata meta = new()
            {
                Key = RegistryKeyNameAttribute.GetRegistryKey(),
                ParentKey = RegistryKeyNameAttribute.GetParentKey()
            };

            foreach (MemberInfo member in classType.GetMembers(MEMBER_SEARCH_FLAGS))
            {
                RegistryValueNameAttribute? valueNameAttribute = member.GetCustomAttribute<RegistryValueNameAttribute>(true);
                if (valueNameAttribute != null)
                {
                    meta.Members.Add(member);
                    continue;
                }

                RegistryKeyPairAttribute? keyPairAttribute = member.GetCustomAttribute<RegistryKeyPairAttribute>(true);
                if (keyPairAttribute != null)
                {
                    Type type = member.GetFieldOrPropertyType();
                    if (type.IsGenericType)
                    {
                        Type gnType = type.GetGenericTypeDefinition();
                        if ((gnType == typeof(KeyValuePair<,>)) || (gnType == typeof(Dictionary<,>)))
                        {
                            Type keyType = type.GetGenericArguments()[0];
                            if (keyType == typeof(string))
                            {
                                meta.Members.Add(member);
                            }
                        }
                    }                    
                }
            }

            return meta;
        }

        private static readonly BindingFlags MEMBER_SEARCH_FLAGS = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        public const string ISDELETED_COLUMN_NAME = "IsDeleted";
    }
}
