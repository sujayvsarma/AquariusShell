using System;
using System.Drawing;
using System.Windows.Forms;

namespace AquariusShell.Controls
{
    public partial class IconWithLabel : UserControl
    {

        #region Properties

        /// <summary>
        /// The image icon displayed on screen
        /// </summary>
        public Image? Icon
        {
            get => icon.Image;
            set => icon.Image = value;
        }

        /// <summary>
        /// Caption displayed under the icon
        /// </summary>
        public string Caption
        {
            get => iconLabel.Text;
            set => iconLabel.Text = value;
        }

        /// <summary>
        /// Path to the file sytem item being shown visually
        /// </summary>
        public string TargetPath { get; set; } = string.Empty;

        /// <summary>
        /// Get/set if this item is currently highlighted (currently under mouse hover or focus)
        /// </summary>
        public bool IsHighlighted { get; set; } = false;

        /// <summary>
        /// Get/set if this item is currently selected
        /// </summary>
        public bool IsSelected { get; set; } = false;

        #endregion

        #region Event Handlers

        /// <summary>
        /// Mouse enters any element of the UI
        /// </summary>
        private void UIElementMouseEnter(object sender, EventArgs e)
        {
            SetItemHighlighted();
        }

        /// <summary>
        /// Mouse leaves any element of the UI
        /// </summary>
        private void UIElementMouseLeave(object sender, EventArgs e)
        {
            ClearItemHighlight();
        }

        /// <summary>
        /// Click event on any area of the UI
        /// </summary>
        private void UIElementMouseClick(object sender, MouseEventArgs e)
        {
            if (!IsHighlighted)
            {
                SetItemHighlighted();
            }

            IsSelected = true;
            OnItemClicked();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Event - this item instance was clicked by the user
        /// </summary>
        public event ItemClicked? ItemClicked = null;
        

        /// <summary>
        /// Raise event for item clicked
        /// </summary>
        private void OnItemClicked()
        {
            if ((ItemClicked != null) && (ItemClicked.GetInvocationList().Length > 0))
            {
                ItemClicked(Caption, TargetPath, Icon);
            }
        }

        private void SetItemHighlighted()
        {
            IsHighlighted = true;
            layoutPanel.BackColor = Color.SteelBlue;
            layoutPanel.ForeColor = Color.White;
        }


        private void ClearItemHighlight()
        {
            IsHighlighted = false;
            layoutPanel.BackColor = Color.Transparent;
            layoutPanel.ForeColor = SystemColors.ControlText;
        }


        #endregion

        public IconWithLabel()
        {
            InitializeComponent();
        }

    }
}
