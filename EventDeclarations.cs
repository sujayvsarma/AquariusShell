
using System;

using AquariusShell.ConfigurationManagement.Settings;

namespace AquariusShell
{

    /// <summary>
    /// A filesystem item (file or directory) was affected because IT was changed other than by a simple update.
    /// For example: its attributes were changed, security modified or was deleted
    /// </summary>
    /// <param name="itemAffected">The full path to the file or directory that was updated</param>
    public delegate void FileSystemItemAffected(string itemAffected);

    /// <summary>
    /// A built-in app was launched and then closed by the user. This would result in its cached instance being 
    /// clobbered in AquariusShellEnvironment. This event lets us know that this happened so that we can refresh 
    /// the stored instance.
    /// </summary>
    /// <param name="typeOfApp">Type of the OOb app that was closed</param>
    public delegate void BuiltInAppClosed(Type typeOfApp);


    /// <summary>
    /// Notification to settings-consumer forms that one or more settings values have changed.
    /// </summary>
    /// <param name="updatedSettings">Copy of the updated settings</param>
    internal delegate void SettingsChanged(IAquariusShellSettings updatedSettings);

}