using System;
using System.Windows.Forms;

namespace AquariusShell.Controls
{
    public partial class HorizontalLine : UserControl
    {
        public HorizontalLine()
        {
            InitializeComponent();
        }

        private void ResetDrawingParameters(object sender, EventArgs e)
        {
            this.Height = 1;             // always fixed
            this.Refresh();
        }
    }
}
