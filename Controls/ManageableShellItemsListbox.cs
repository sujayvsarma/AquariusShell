using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using AquariusShell.Dialogs;
using AquariusShell.Objects;

namespace AquariusShell.Controls
{
    /// <summary>
    /// Shows a Listbox control with buttons to Add/Edit/Delete the Windows Shell related items (files, apps, control panel items). 
    /// On clicking Add, the <see cref="ShellItemBrowser"> dialog is raised to allow the user to select an item.
    /// </summary>
    public partial class ManageableShellItemsListbox : UserControl
    {
        /// <summary>
        /// Colour of the listbox within the control
        /// </summary>
        public Color ListboxBackgroundColor
        {
            get => lstListBox.BackColor;
            set => lstListBox.BackColor = value;
        }

        /// <summary>
        /// Allow apps and programs to be selected
        /// </summary>
        public bool AllowSelectApps
        {
            get; set;

        } = false;

        /// <summary>
        /// Allows drives, directories and files to be selected
        /// </summary>
        public bool AllowSelectDrivesDirectoriesAndFiles
        {
            get; set;

        } = false;

        /// <summary>
        /// Allows control panel applets to be selected
        /// </summary>
        public bool AllowSelectControlPanelItems
        {
            get; set;

        } = false;

        /// <summary>
        /// Items selected by the user and currently listed in the listbox
        /// </summary>
        public List<NameValuePair<string>> SelectedItems
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                foreach (NameValuePair<string> item in _items)
                {
                    lstListBox.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Add items to the list
        /// </summary>
        /// <param name="items">Collection of strings to add</param>
        public void AddIems(IEnumerable<string> items)
        {
            foreach (string item in items)
            {
                NameValuePair<string> pair = new()
                {
                    Text = item,
                    Value = item
                };

                _items.Add(pair);
                lstListBox.Items.Add(pair);
            }
        }


        /// <summary>
        /// Initialise
        /// </summary>
        public ManageableShellItemsListbox()
        {
            InitializeComponent();

            _items = new();
        }

        /// <summary>
        /// Delete currently selected item from listbox
        /// </summary>
        private void DeleteSelectedItemFromListBox()
        {
            if (lstListBox.SelectedIndex != -1)
            {
                NameValuePair<string> oldText = (NameValuePair<string>)lstListBox.Items[lstListBox.SelectedIndex];
                _items.Remove(oldText);
                lstListBox.Items.Remove(oldText);
            }
        }

        /// <summary>
        /// Browse button clicked - show the picker
        /// </summary>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ShellItemBrowser shellBrowser = new(AllowSelectApps, AllowSelectDrivesDirectoriesAndFiles, AllowSelectControlPanelItems);
            if (shellBrowser.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            foreach (KeyValuePair<string, string> item in shellBrowser.SelectedItems)
            {
                NameValuePair<string> lstItem = new()
                {
                    Text = item.Key,
                    Value = item.Value
                };

                lstListBox.Items.Add(lstItem);
            }
        }

        /// <summary>
        /// If DEL key was pressed, delete selected item
        /// </summary>
        private void lstListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedItemFromListBox();
            }
        }

        /// <summary>
        /// Delete selected item
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedItemFromListBox();
        }

        /// <summary>
        /// Clear all items
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            _items.Clear();
            lstListBox.Items.Clear();
        }

        /// <summary>
        /// On ESC, clear the selection and edit field
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                lstListBox.SelectedIndex = -1;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private List<NameValuePair<string>> _items;
    }
}
