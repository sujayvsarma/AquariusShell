
using System.Drawing;

namespace AquariusShell.Controls
{

    /// <summary>
    /// Event fired when an item displaying a filesystem item is clicked on
    /// </summary>
    /// <param name="caption">Caption on the item</param>
    /// <param name="targetPath">The target path of what the element was showing</param>
    /// <param name="icon">Icon that was displayed</param>
    public delegate void ItemClicked(string caption, string targetPath, Image? icon);

    /// <summary>
    /// Item added to an accordion
    /// </summary>
    /// <param name="item">Item that was added</param>
    public delegate void ItemAdded(AccordionItem item);

    /// <summary>
    /// Item removed from an accordion
    /// </summary>
    /// <param name="item">Item that was removed</param>
    public delegate void ItemRemoved(AccordionItem item);

}