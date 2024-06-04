using System;
using System.Windows.Forms;

namespace AquariusShell.Controls
{
    /// <summary>
    /// Defines a user controls that is a simple horizontal line of 1 pixel height
    /// </summary>
    public partial class HorizontalLine : UserControl
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public HorizontalLine()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On (Location, Size or Parent changed), redraw ourselves with 1 pixel height
        /// </summary>
        private void ResetDrawingParameters(object sender, EventArgs e)
        {
            this.Height = 1;             // always fixed
            this.Refresh();
        }
    }
}
