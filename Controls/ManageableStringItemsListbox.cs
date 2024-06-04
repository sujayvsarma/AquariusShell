using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AquariusShell.Controls
{
    /// <summary>
    /// Shows a listbox control with Add/Edit/Delete buttons to manage strings.
    /// </summary>
    public partial class ManageableStringItemsListbox : UserControl
    {

        /// <summary>
        /// When set, ensures that items added are unique
        /// </summary>
        public bool KeepItemsUnique 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// List of strings added. This is repopulated everytime, caller MUST cache!
        /// </summary>
        public List<string> StringList
        {
            get
            {
                List<string> list = new();
                foreach(string item in lstListBox.Items)
                {
                    list.Add(item);
                }

                return list;
            }
        }

        /// <summary>
        /// Add items to the list
        /// </summary>
        /// <param name="items">Items to add</param>
        /// <param name="skipDuplicates">When true, skips duplicates. Else will add duplicates as well</param>
        public void AddItems(IEnumerable<string> items, bool skipDuplicates)
        {
            if (skipDuplicates)
            {
                List<string> existingItems = StringList;
                foreach (string item in items)
                {
                    if (existingItems.Any(e => e.Equals(item, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        continue;
                    }

                    existingItems.Add(item);
                    lstListBox.Items.Add(item);
                }
            }
            else
            {
                foreach (string item in items)
                {
                    lstListBox.Items.Add(item);
                }
            }
        }


        /// <summary>
        /// Initialise
        /// </summary>
        public ManageableStringItemsListbox()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Add/Update button clicked. Add the item or update the selected item.
        /// Updation is via delete+add
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string item = tbAddEditItem.Text.Trim();

            if (KeepItemsUnique)
            {
                foreach(string listItem in lstListBox.Items)
                {
                    if (listItem.Equals(item, StringComparison.InvariantCultureIgnoreCase))
                    {
                        MessageBox.Show($"List already contains '{item}'.", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbAddEditItem.Focus();
                        return;
                    }
                }
            }

            if (btnAdd.Text == "&Update")
            {
                if (lstListBox.SelectedItem != null)
                {
                    lstListBox.Items.Remove(lstListBox.SelectedItem);
                }
            }

            lstListBox.Items.Add(item);
        }

        /// <summary>
        /// Clear the listbox
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            lstListBox.Items.Clear();
        }

        /// <summary>
        /// Delete the selected item (if any) from the list
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstListBox.SelectedItem != null)
            {
                lstListBox.Items.Remove(lstListBox.SelectedItem);
            }
        }

        /// <summary>
        /// User selected an item from the list, set the value to the text field and update the button
        /// </summary>
        private void lstListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstListBox.SelectedIndex == -1)
            {
                tbAddEditItem.Text = string.Empty;
                btnAdd.Text = "&Add";
            }
            else
            {
                tbAddEditItem.Text = (string)lstListBox.SelectedItem!;
                btnAdd.Text = "&Update";
            }
        }

        /// <summary>
        /// Handle ESC key to clear selection
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                lstListBox.SelectedIndex = -1;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
