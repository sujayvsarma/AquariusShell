using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.Json;

using Microsoft.Win32;


namespace AquariusShell.ConfigurationManagement.Reflection
{
    /// <summary>
    /// Reflection utilities
    /// </summary>
    internal static class ReflectionUtils
    {

        /// <summary>
        /// Get the value of a property or field
        /// </summary>
        /// <typeparam name="TObject">Type of object</typeparam>
        /// <param name="instance">Instance of object</param>
        /// <param name="member">Member property or field</param>
        /// <returns>Value of property or field or NULL</returns>
        public static object? GetValue<TObject>(TObject? instance, MemberInfo member)
            where TObject : class
        {
            object? value = null;
            if (member is FieldInfo field)
            {
                value = field.GetValue(field.IsStatic ? null : instance);
            }
            else if (member is PropertyInfo property)
            {
                // properties are never 'static'
                value = property.GetValue(instance);
            }

            return value;
        }

        /// <summary>
        /// Set the value of a property or field
        /// </summary>
        /// <param name="instance">Instance of object</param>
        /// <param name="member">Member property or field</param>
        /// <param name="value">Value to set</param>
        public static void SetValue(object instance, MemberInfo member, object? value)
        {
            if (member is FieldInfo field)
            {
                value = CoerceFromRegistryValue(value, field.FieldType);
                field.SetValue(instance, value);
            }
            else if (member is PropertyInfo property)
            {
                value = CoerceFromRegistryValue(value, property.PropertyType);
                property.SetValue(instance, value);
            }
        }

        /// <summary>
        /// Cooerce a value from EDM to a CLR type 
        /// </summary>
        /// <param name="value">Value from Edm</param>
        /// <param name="targetClrType">The target CLR type to convert to</param>
        /// <returns>Cooerced value</returns>        
        [return: NotNullIfNotNull(nameof(value))]
        public static object? CoerceFromRegistryValue(object? value, Type targetClrType)
        {
            if (value == default)
            {
                return default;
            }

            Type sourceRegistryType = value.GetType();
            Type? actualClrType = Nullable.GetUnderlyingType(targetClrType);
            Type destinationClrType = actualClrType ?? targetClrType;

            if (!sourceRegistryType.FullName!.Equals(destinationClrType.FullName, StringComparison.Ordinal))
            {
                // we need to convert
                return ConvertTo(destinationClrType, value);
            }
            return value;
        }

        /// <summary>
        /// Convert between types
        /// </summary>
        /// <param name="destinationType">CLR Type of destination</param>
        /// <param name="value">The value to convert</param>
        /// <returns>The converted value</returns>
        public static object ConvertTo(Type destinationType, object value)
        {
            //NOTE: value is not null -- already been checked by caller before calling here

            TypeConverter converter = TypeDescriptor.GetConverter(destinationType);
            if ((converter != null) && converter.CanConvertFrom(value.GetType()))
            {
                return converter.ConvertFrom(value)!;
            }

            if (destinationType.IsEnum)
            {
                if (value is int intVal)
                {
                    return intVal;
                }
            }

            if (destinationType == typeof(Color))
            {
                if (value is int colourHex)
                {
                    return Color.FromArgb(colourHex);
                }
            }

            // Adding support for new .NET types DateOnly and TimeOnly
            if (value is DateTimeOffset dto)
            {
                if (destinationType == typeof(DateTime))
                {
                    return dto.UtcDateTime;
                }

                if (destinationType == typeof(DateOnly))
                {
                    return new DateOnly(dto.Year, dto.Month, dto.Day);
                }

                if (destinationType == typeof(TimeOnly))
                {
                    return new TimeOnly(dto.Hour, dto.Minute, dto.Second);
                }

                return dto;
            }
            else if (value is DateTime dt)
            {
                if (destinationType == typeof(DateTimeOffset))
                {
                    return new DateTimeOffset(dt);
                }

                if (destinationType == typeof(DateOnly))
                {
                    return new DateOnly(dt.Year, dt.Month, dt.Day);
                }

                if (destinationType == typeof(TimeOnly))
                {
                    return new TimeOnly(dt.Hour, dt.Minute, dt.Second);
                }

                return dt;
            }

            // see if type has a Parse static method
            MethodInfo[] methods = destinationType.GetMethods(BindingFlags.Public | BindingFlags.Static);
            if ((methods != null) && (methods.Length > 0))
            {
                Type sourceType = ((value == null) ? typeof(object) : value.GetType());
                foreach (MethodInfo m in methods)
                {
                    if (m.Name.Equals("Parse"))
                    {
                        ParameterInfo? p = m.GetParameters()?[0];
                        if ((p != null) && (p.ParameterType == sourceType))
                        {
                            return m.Invoke(null, [value])!;
                        }
                    }
                    else if (m.Name.Equals("TryParse"))
                    {
                        ParameterInfo? p = m.GetParameters()?[0];
                        if ((p != null) && (p.ParameterType == sourceType))
                        {
                            object?[]? parameters = [value, null];
                            bool? tpResult = (bool?)m.Invoke(null, parameters);
                            return ((tpResult.HasValue && tpResult.Value) ? parameters[1] : default!)!;
                        }
                    }
                }
            }

            if (value is string potentialJson)
            {
                try
                {
                    // Jsonised?
                    return JsonSerializer.Deserialize(potentialJson, destinationType) ?? default!;
                }
                catch
                {
                    // this will throw below
                }
            }

            throw new TypeLoadException($"Could not find type converters for '{destinationType.Name}' type.");
        }

        /// <summary>
        /// Get the underlying CLR data type of the property or field
        /// </summary>
        /// <param name="member">Property or field</param>
        /// <returns>Type information</returns>
        public static Type GetFieldOrPropertyType(this MemberInfo member)
        {
            if (member is FieldInfo field)
            {
                return field.FieldType;
            }

            if (member is PropertyInfo property)
            {
                return property.PropertyType;
            }

            throw new InvalidOperationException($"Cannot determine data type for member '{member.Name}' of type '{member.MemberType}'.");
        }

        /// <summary>
        /// Populate an object
        /// </summary>
        public static object? Populate(Type tObject)
        {
            TypeMetadata metadata = TypeMetadata.Discover(tObject);
            object? instance = Activator.CreateInstance(tObject);
            if (instance == null)
            {
                return null;
            }

            List<string> keyValueNames = [.. metadata.Key.GetValueNames()];
            MemberInfo? keyPairMember = null;
            Type? keyPairMemberType = null;

            foreach (MemberInfo member in metadata.Members)
            {
                RegistryValueNameAttribute? valueNameAttribute = member.GetCustomAttribute<RegistryValueNameAttribute>();
                if ((valueNameAttribute != null) && keyValueNames.Any(k => k.Equals(valueNameAttribute.ValueName)))
                {
                    object value = metadata.Key.GetValue(valueNameAttribute.ValueName) ?? default!;
                    SetValue(instance, member, value);
                    keyValueNames.Remove(valueNameAttribute.ValueName);
                }
                else
                {
                    RegistryKeyPairAttribute? keyPairAttribute = member.GetCustomAttribute<RegistryKeyPairAttribute>();
                    if (keyPairAttribute != null)
                    {
                        if (keyPairMember != null)
                        {
                            throw new TypeLoadException($"Object '{tObject.Name}' has more than one property or field of type 'RegistryKeyPair'. Only ONE is permitted.");
                        }

                        keyPairMemberType = GetFieldOrPropertyType(member);
                        if (keyPairMemberType.IsGenericType)
                        {
                            keyPairMemberType = keyPairMemberType.GetGenericTypeDefinition();
                            if ((keyPairMemberType == typeof(KeyValuePair<,>)) || (keyPairMemberType == typeof(Dictionary<,>)))
                            {
                                keyPairMember = member;
                            }
                        }
                    }
                }
            }

            if ((keyPairMember != null) && (keyPairMemberType != null))
            {
                if (keyPairMemberType == typeof(KeyValuePair<,>))
                {
                    FieldInfo? keyField = keyPairMemberType.GetField("Key");
                    FieldInfo? valueField = keyPairMemberType.GetField("Value");
                    if ((keyField != null) && (valueField != null))
                    {
                        string selectedKeyName = keyValueNames[0];
                        SetValue(instance, keyField, selectedKeyName);

                        object value = metadata.Key.GetValue(selectedKeyName) ?? default!;
                        SetValue(instance, valueField, value);
                    }
                }
                else if (keyPairMemberType == typeof(Dictionary<,>))
                {
                    // We need the generic defs from original type, not the TypeDef!
                    Type originalDictionaryType = GetFieldOrPropertyType(keyPairMember);
                    Type[] pairTypes = originalDictionaryType.GetGenericArguments();
                    Type keyType = pairTypes[0], valueType = pairTypes[1];

                    var dict = Activator.CreateInstance(originalDictionaryType);
                    
                    MethodInfo dictionaryAddMethod = originalDictionaryType.GetMethod("Add")!;
                    foreach (string subKeyName in keyValueNames)
                    {
                        object value = metadata.Key.GetValue(subKeyName) ?? default!;
                        _ = dictionaryAddMethod.Invoke(
                                dict,
                                [
                                    CoerceFromRegistryValue(subKeyName, keyType)!,
                                    CoerceFromRegistryValue(value, valueType)!
                                ]
                            );
                    }

                    SetValue(instance, keyPairMember, dict);
                }
            }


            return instance;
        }

        /// <summary>
        /// Persist an object
        /// </summary>
        /// <typeparam name="TObject">CLR type of object</typeparam>
        /// <param name="instance">Instance of object with values, to persist</param>
        public static void Persist<TObject>(TObject instance)
            where TObject : class
        {
            TypeMetadata metadata = TypeMetadata.Discover<TObject>();
            foreach (MemberInfo member in metadata.Members)
            {
                RegistryValueNameAttribute? valueNameAttribute = member.GetCustomAttribute<RegistryValueNameAttribute>(true);
                if (valueNameAttribute != null)
                {
                    object? value = ReflectionUtils.GetValue<TObject>(instance, member);
                    actuallyPersist(metadata.Key, valueNameAttribute.ValueName, value);

                    continue;
                }

                RegistryKeyPairAttribute? keyPairAttribute = member.GetCustomAttribute<RegistryKeyPairAttribute>(true);
                if (keyPairAttribute != null)
                {
                    object? regKeyPairItemInstance = ReflectionUtils.GetValue<TObject>(instance, member);
                    if (regKeyPairItemInstance != null)
                    {
                        // Easiest way is to get Json to do stuff for us
                        string jsonised = JsonSerializer.Serialize(regKeyPairItemInstance);
                        Dictionary<string, object> dictised = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonised)!;

                        // Now we split strategy!
                        Type kvpOrDict = member.GetFieldOrPropertyType();
                        if (kvpOrDict.IsGenericType)
                        {
                            kvpOrDict = kvpOrDict.GetGenericTypeDefinition();
                            if (kvpOrDict == typeof(KeyValuePair<,>))
                            {
                                // We will have two entries:
                                string valueName = (string)dictised["Key"];
                                object? value = dictised["Value"];

                                actuallyPersist(metadata.Key, valueName, value);
                            }
                            else if (kvpOrDict == typeof(Dictionary<,>))
                            {
                                foreach (KeyValuePair<string, object> item in dictised)
                                {
                                    actuallyPersist(metadata.Key, item.Key, item.Value);
                                }
                            }
                        }
                    }
                }
            }

            // Actually do the persisting thing
            //  key         - the key to persist into
            //  valueName   - Name of the Value entry
            //  value       - the value itself
            static void actuallyPersist(RegistryKey key, string valueName, object? value)
            {
                RegistryValueKind kind;
                if (value is string str)
                {
                    kind = (str.Contains('%') ? RegistryValueKind.ExpandString : RegistryValueKind.String);
                    key.SetValue(valueName, str, kind);
                }
                else if (value is int i)
                {
                    kind = RegistryValueKind.DWord;
                    key.SetValue(valueName, i, kind);
                }
                else if (value is uint ui)
                {
                    kind = RegistryValueKind.DWord;
                    key.SetValue(valueName, ui, kind);
                }
                else if (value is short sh)
                {
                    kind = RegistryValueKind.DWord;
                    key.SetValue(valueName, sh, kind);
                }
                else if (value is ushort ush)
                {
                    kind = RegistryValueKind.DWord;
                    key.SetValue(valueName, ush, kind);
                }
                else if (value is long l)
                {
                    kind = RegistryValueKind.QWord;
                    key.SetValue(valueName, l, kind);
                }
                else if (value is ulong ul)
                {
                    kind = RegistryValueKind.QWord;
                    key.SetValue(valueName, ul, kind);
                }
                else if (value is bool b)
                {
                    kind = RegistryValueKind.String;
                    key.SetValue(valueName, (b ? "true" : "false"), kind);
                }
                else if ((value is DateTime) || (value is DateOnly) || (value is TimeOnly) || (value is DateTimeOffset) || (value is Guid))
                {
                    kind = RegistryValueKind.String;
                    key.SetValue(valueName, value.ToString()!, kind);
                }
                else if (value is Color color)
                {
                    kind = RegistryValueKind.DWord;
                    key.SetValue(valueName, color.ToArgb(), kind);
                }
                else if (value is Enum)
                {
                    // Serialise enums as strings
                    kind = RegistryValueKind.String;
                    key.SetValue(valueName, value.ToString()!, kind);
                }
                else
                {
                    // What are we? Store as Json-serialised.
                    kind = RegistryValueKind.String;
                    key.SetValue(valueName, JsonSerializer.Serialize(value: value, options: _jsonOptions), kind);
                }
            }
        }

        /// <summary>
        /// Delete all values for the provided object
        /// </summary>
        /// <typeparam name="TObject">CLR type of object</typeparam>
        /// <param name="instance">Instance of object with information to be deleted</param>
        /// <param name="deleteTopLevelKey">(Default: FALSE) When set, deletes the key for 'TObject'</param>
        public static void Delete<TObject>(TObject instance, bool deleteTopLevelKey = false)
            where TObject : class
        {
            TypeMetadata metadata = TypeMetadata.Discover<TObject>();

            if (deleteTopLevelKey)
            {
                string keyName = metadata.Key.Name.Replace(metadata.ParentKey.Name, "");
                metadata.ParentKey.DeleteSubKeyTree(keyName, throwOnMissingSubKey: false);

                return;
            }

            foreach (MemberInfo member in metadata.Members)
            {
                RegistryValueNameAttribute? valueNameAttribute = member.GetCustomAttribute<RegistryValueNameAttribute>(true);
                if (valueNameAttribute != null)
                {
                    metadata.Key.DeleteValue(valueNameAttribute.ValueName);
                    continue;
                }

                RegistryKeyPairAttribute? registryKeyPairAttribute = member.GetCustomAttribute<RegistryKeyPairAttribute>(true);
                if (registryKeyPairAttribute != null)
                {
                    object? regKeyPairItemInstance = ReflectionUtils.GetValue<TObject>(instance, member);
                    if (regKeyPairItemInstance != null)
                    {
                        // Easiest way is to get Json to do stuff for us
                        string jsonised = JsonSerializer.Serialize(regKeyPairItemInstance);
                        Dictionary<string, object> dictised = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonised)!;

                        // Now we split strategy!
                        Type kvpOrDict = member.GetFieldOrPropertyType();
                        if (kvpOrDict.IsGenericType)
                        {
                            kvpOrDict = kvpOrDict.GetGenericTypeDefinition();
                            if (kvpOrDict == typeof(KeyValuePair<,>))
                            {
                                metadata.Key.DeleteValue((string)dictised["Key"]);
                            }
                            else if (kvpOrDict == typeof(Dictionary<,>))
                            {
                                foreach (KeyValuePair<string, object> item in dictised)
                                {
                                    metadata.Key.DeleteValue(item.Key);
                                }
                            }
                        }
                    }
                }
            }
        }


        static readonly JsonSerializerOptions _jsonOptions = new()
        {
            AllowTrailingCommas = false,
            WriteIndented = false
        };
    }

}
