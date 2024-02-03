
using System;
using System.Drawing;

namespace AquariusShell.Controls
{

    /// <summary>
    /// Event fired when an item displaying an IconWithLabel item is clicked on
    /// </summary>
    /// <param name="caption">Caption on the item</param>
    /// <param name="targetPath">The target path of what the element was showing</param>
    /// <param name="icon">Icon that was displayed</param>
    public delegate void ItemClicked(string caption, string targetPath, Image? icon);


    /// <summary>
    /// The app-list button was clicked
    /// </summary>
    /// <param name="hWnd">Handle to the window the button is for</param>
    /// <param name="pid">PID of the process attached to the window</param>
    public delegate void TasklistProcessButtonClicked(IntPtr hWnd, int pid);


    /// <summary>
    /// A directory was affected because one or more items within it were changed other than by a simple update. 
    /// For example: files were added, removed, hidden/unhidden.
    /// </summary>
    /// <param name="directoryAffected">The full path to the directory that was updated</param>
    public delegate void FileSystemLocationAffected(string directoryAffected);

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

}