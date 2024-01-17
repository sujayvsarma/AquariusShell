using System.Windows.Forms;

namespace AquariusShell.Controls
{
    public partial class Accordion : UserControl
    {

        #region Properties

        /// <summary>
        /// Items in the accordion
        /// </summary>
        public AccordionItemCollection Items
        {
            get;

        } = [];

        #endregion


        public Accordion()
        {
            InitializeComponent();

            Items.AccordionItemAdded += Items_AccordionItemAdded;
            Items.AccordionItemRemoved += Items_AccordionItemRemoved;
        }

        private void Items_AccordionItemRemoved(AccordionItem item)
        {
            itemsContainerPanel.Controls.Remove(item);

            addPointY -= item.Height - item.Margin.Bottom;
        }

        private void Items_AccordionItemAdded(AccordionItem item)
        {
            item.Location = new(addPointX, addPointY);
            item.Size = new(this.ClientSize.Width - this.Padding.Right - this.Padding.Left, item.Height);

            if (Items.Count > 1)
            {
                item.IsExpanded = false;
            }

            item.ItemClicked += Item_ItemClicked;
            itemsContainerPanel.Controls.Add(item);

            addPointY += item.Height + item.Margin.Bottom;
        }

        private void Item_ItemClicked(string caption, string targetPath, System.Drawing.Image? icon)
        {
            if (AccordionItemClicked != null)
            {
                AccordionItemClicked(caption, targetPath, icon);
            }
        }

        private int addPointX = 3, addPointY = 3;

        /// <summary>
        /// Raised when an item on the accordion is clicked
        /// </summary>
        public event ItemClicked? AccordionItemClicked;
    }
}
