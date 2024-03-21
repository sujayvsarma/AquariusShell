using System.ComponentModel.DataAnnotations;

namespace AquariusShell.ConfigurationManagement.Constants
{
    /// <summary>
    /// Controls the display of captions accompanying an icon
    /// </summary>
    public enum IconCaptionDisplayEnum
    {
        /// <summary>
        /// Never show the caption
        /// </summary>
        [Display(Name = "Never", Description = "Never display captions even if available")]
        Never = 0,

        /// <summary>
        /// Always show the caption. If caption is not available, 
        /// a default string will be shown
        /// </summary>
        [Display(Name = "Always", Description = "Always display captions (use default when not available)")]
        Always,

        /// <summary>
        /// Show caption if available
        /// </summary>
        [Display(Name = "When available", Description = "Show captions for icons when available")]
        IfAvailable
    }
}
