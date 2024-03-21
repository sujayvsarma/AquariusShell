using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using AquariusShell.Modules;

namespace AquariusShell.Forms
{
    public partial class TaskListPane : Form
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public TaskListPane()
        {
            InitializeComponent();
            _map = new();
        }

        /// <summary>
        /// Clear all tasks added
        /// </summary>
        public void Clear()
        {
            lvTaskListImages.Images.Clear();
            lvTasksList.Items.Clear();
            _map.Clear();
        }

        /// <summary>
        /// Add a process to the task pane
        /// </summary>
        /// <param name="icon">Icon for the process</param>
        /// <param name="title">Main window title</param>
        /// <param name="hWnd">hWnd of the window</param>
        /// <param name="pid">Process ID</param>
        public void Add(Image icon, string title, IntPtr hWnd, int pid)
        {
            string imageKey = pid.ToString();
            lvTaskListImages.Images.Add(imageKey, icon);
            ListViewItem item = new()
            {
                ImageKey = imageKey,
                Text = title,
                Tag = hWnd
            };

            lvTasksList.Items.Add(item);
            _map.Add(hWnd, item);
        }

        /// <summary>
        /// Remove a process from the taskpane
        /// </summary>
        /// <param name="hWnd">Handle to the window</param>
        public void Remove(IntPtr hWnd)
        {
            ListViewItem? item = _map[hWnd];
            if ((item != null) && (item != default))
            {
                lvTasksList.Items.Remove(item);
                _map.Remove(hWnd);
            }
        }

        #region Event Subscriptions

        private void lvTasksList_ItemActivate(object sender, EventArgs e)
        {
            this.Close();

            ListViewItem item = lvTasksList.SelectedItems[0];
            IntPtr hWnd = (IntPtr)item.Tag!;

            if (!Modules.Windows.SwitchToWindow(hWnd))
            {
                if (MessageBox.Show("The app did not appear to respond normally. Would you like to attempt to terminate it?", "Aquarius Shell", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (Modules.Windows.TerminateAppIfWindowHung(hWnd))
                    {
                        Remove(hWnd);
                    }
                    else
                    {
                        MessageBox.Show("The app did not respond to termination instruction. Please wait a few moments to see if it works normally again.", "Aquarius Shell", MessageBoxButtons.OK);
                    }
                }
            }
        }

        /// <summary>
        /// Handle ESC keypress to dismiss the window
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnCloseLauncher_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private readonly Dictionary<IntPtr, ListViewItem> _map;
    }
}
