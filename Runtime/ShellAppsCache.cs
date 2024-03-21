using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace AquariusShell.Runtime
{
    /// <summary>
    /// Cache of recognised shell apps
    /// </summary>
    internal class ShellAppsCache : IEnumerable<AppIconOrShortcut>
    {

        /// <summary>
        /// Release an app instance (because it was closed)
        /// </summary>
        /// <param name="command">The command matching the app</param>
        public void ReleaseAppInstance(string command)
        {
            _appInstances.Remove(command);
        }


        /// <summary>
        /// Get an instance of the app given the command
        /// </summary>
        /// <param name="command">The command</param>
        /// <returns>Instance of app or NULL</returns>
        public IShellAppModule? GetInstanceOf(string command)
        {
            AppIconOrShortcut? appReference = GetAppReferenceFromCommand(command);
            if (appReference != null)
            {
                if (_appInstances.TryGetValue(command, out IShellAppModule? value))
                {
                    if (appReference.InstancingMode == ShellAppInstancingModeEnum.Single)
                    {
                        return value;
                    }
                }

                IShellAppModule? instance = (IShellAppModule?)Activator.CreateInstance(appReference.ImplementingType);
                if ((instance != null) && (!_appInstances.ContainsKey(command)))
                {
                    instance.AppClosed += Instance_AppClosed;
                    _appInstances.Add(command, instance);
                }

                return instance;
            }

            return null;
        }

        /// <summary>
        /// Instance closed, remove it
        /// </summary>
        /// <param name="typeOfApp">The type of the app being closed</param>
        private void Instance_AppClosed(Type typeOfApp)
        {
            foreach(KeyValuePair<string, IShellAppModule> app in _appInstances)
            {
                if (app.Value.GetType() == typeOfApp)
                {
                    _appInstances.Remove(app.Key);
                    break;
                }
            }
        }

        /// <summary>
        /// Find the AppReference in the type cache from the given command
        /// </summary>
        /// <param name="command">Command received</param>
        /// <returns>App reference or NULL</returns>
        private AppIconOrShortcut? GetAppReferenceFromCommand(string command)
        {
            foreach(AppIconOrShortcut item in _discoveredAppTypesCache)
            {
                if (item.Command.Equals(command, StringComparison.InvariantCultureIgnoreCase))
                {
                    return item;
                }
            }

            return null;
        }


        /// <summary>
        /// Initialise
        /// </summary>
        public ShellAppsCache()
        {
            _discoveredAppTypesCache = new();
            _appInstances = new();

            Type IIshellApp = typeof(IShellAppModule);
            IEnumerable<Type> implementedShellApps = 
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                        .Where(t => (IIshellApp.IsAssignableFrom(t) && (!t.IsInterface)));

            foreach (Type t in implementedShellApps)
            {
                IShellAppModule? instance = (IShellAppModule?)Activator.CreateInstance(t);
                if (instance != null)
                {
                    _discoveredAppTypesCache.Add(new(
                            TypeName: t.FullName ?? t.Name,
                            ImplementingType: t,
                            AppName: (string)t.GetProperty("Caption")!.GetValue(instance)!,
                            Icon: (Image)t.GetProperty("LauncherOrTaskManagerIcon")!.GetValue(instance)!,
                            Command: (string)t.GetProperty("Command")!.GetValue(instance)!,
                            InstancingMode: (ShellAppInstancingModeEnum)t.GetProperty("InstancingMode")!.GetValue(instance)!,
                            ImageListKeyName: string.Empty,
                            HideFromLauncher: (bool)t.GetProperty("HideFromLauncher")!.GetValue(instance)!
                        ));
                }
                instance = null;
            }
        }


        #region IEnumerable

        /// <summary>
        /// Get the collection enumerator
        /// </summary>
        /// <returns>Enumerator for AppIconOrShortcuts</returns>
        public IEnumerator<AppIconOrShortcut> GetEnumerator()
            => _discoveredAppTypesCache.GetEnumerator();

        /// <summary>
        /// Get the collection enumerator
        /// </summary>
        /// <returns>IEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        #endregion

        private readonly List<AppIconOrShortcut> _discoveredAppTypesCache;
        private readonly Dictionary<string, IShellAppModule> _appInstances;
    }
}
