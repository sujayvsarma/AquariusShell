using System;
using System.Drawing;
using System.Windows.Forms;

namespace AquariusShell.Controls
{
    public partial class AccordionItem : UserControl
    {

        #region Properties

        /// <summary>
        /// The heading/caption for this item
        /// </summary>
        public string Heading
        {
            get => headerButton.Text;
            set => headerButton.Text = value;
        }

        /// <summary>
        /// If true, expands the item. Else it is in collapsed state.
        /// </summary>
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                ExpandCollapseHelper();
            }
        }
        private bool _isExpanded = true;

        /// <summary>
        /// Full path to load the child items from
        /// </summary>
        public string ItemsFolderPath
        {
            get => _itemsFolderPath;
            set
            {
                _itemsFolderPath = value;

                surface.ItemClicked -= IconOnSurface_ItemClicked;

                surface.DirectoryToLoad = _itemsFolderPath;
                surface.DisplayItems();

                surface.ItemClicked += IconOnSurface_ItemClicked;
            }
        }
        private string _itemsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        #endregion

        #region Methods

        /// <summary>
        /// Expand accordion item
        /// </summary>
        public void Expand()
        {
            if (!_isExpanded)
            {
                IsExpanded = true;
            }
        }

        /// <summary>
        /// Collapse accordion item
        /// </summary>
        public void Collapse()
        {
            if (_isExpanded)
            {
                IsExpanded = false;
            }
        }

        /// <summary>
        /// When there is only one item loaded into the parent accordion, call this function to 
        /// set this as the only one -- the button will not be expandable anymore.
        /// </summary>
        public void SetAsOnlyItem()
        {
            Expand();

            headerButton.ImageKey = string.Empty;
            headerButton.ImageList = null;
            headerButton.Font = new Font(headerButton.Font, FontStyle.Bold);
            headerButton.TextAlign = ContentAlignment.MiddleLeft;
            headerButton.Enabled = false;
        }


        private void ExpandCollapseHelper()
        {
            headerButton.ImageKey = (_isExpanded ? "DN" : "UP");

            if (_isExpanded)
            {
                this.Size = new(this.Width, _controlDesignHeight);
                surface.Size = new(surface.Size.Width, _surfaceDesignHeight);
            }
            else
            {
                this.Size = new(this.Width, this.Height - surface.Size.Height);
                surface.Size = new Size(surface.Size.Width, 0);                
            }

            this.Refresh();
        }

        #endregion

        public AccordionItem()
        {
            InitializeComponent();

            _controlDesignHeight = this.Size.Height;       // designed height of the control itself
            _surfaceDesignHeight = surface.Size.Height;    // designed height of just the surface
        }
        private int _surfaceDesignHeight, _controlDesignHeight;

        private void headerButton_Click(object sender, EventArgs e)
        {
            // set opposite state
            IsExpanded = !IsExpanded;
        }

        /// <summary>
        /// Event fired when a FilesystemIcon is clicked on
        /// </summary>
        /// <param name="caption">Caption on the item</param>
        /// <param name="targetPath">The target path of what the element was showing</param>
        /// <param name="icon">Icon that was displayed</param>
        private void IconOnSurface_ItemClicked(string caption, string targetPath, Image? icon)
        {
            if ((ItemClicked != null) && (ItemClicked.GetInvocationList().Length > 0))
            {
                ItemClicked(caption, targetPath, icon);
            }
        }

        private void AccordionItem_Resize(object sender, EventArgs e)
        {
            headerButton.Size = new(
                    this.ClientSize.Width - headerButton.Margin.Left - headerButton.Margin.Right - this.Padding.Right,
                    36  // 32x icon + 4px padding
                );

            surface.Location = new(
                    headerButton.Location.X,
                    headerButton.Location.Y + headerButton.Size.Height + surface.Padding.Top
                );

            if (IsExpanded)
            {
                surface.Size = new(
                        this.ClientSize.Width - surface.Margin.Right - surface.Margin.Left - this.Padding.Right,
                        this.ClientSize.Height - headerButton.Size.Height - surface.Margin.Top - surface.Margin.Bottom
                    );                

                surface.Refresh();

                _surfaceDesignHeight = surface.Size.Height;
            }
        }

        /// <summary>
        /// Event - this icon instance was clicked by the user
        /// </summary>
        public event ItemClicked? ItemClicked = null;
    }
}
