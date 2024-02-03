using System;
using System.Drawing;

namespace AquariusShell.Runtime
{
    /// <summary>
    /// An item in the ShellAppsCache
    /// </summary>
    /// <param name="TypeName">Name of type of item</param>
    /// <param name="ImplementingType">Type implementing this app</param>
    /// <param name="AppName">Name or caption for the app</param>
    /// <param name="Icon">Icon for the app</param>
    /// <param name="Command">Command to invoke the app</param>
    /// <param name="InstancingMode">Type of instancing</param>
    /// <param name="ImageListKeyName">(Optional) Name of the key in an accompanying ImageList</param>
    public record AppIconOrShortcut
        (
            string TypeName,
            Type ImplementingType,
            string AppName,
            Image? Icon,
            string Command,
            ShellAppInstancingModeEnum InstancingMode,
            string ImageListKeyName = ""
        );
}
