
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using AquariusShell.Modules;
using AquariusShell.Runtime;

namespace AquariusShell.ShellApps
{
    /// <summary>
    /// Tabbed browser implementation
    /// </summary>
    public partial class FileBrowser
    {
        /// <summary>
        /// (Fired when a Tab is just clicked)
        /// A tab was clicked. If it is the New Tab page, then a new tab is added, homed in My Computer or 
        /// whatever was the configuration
        /// </summary>
        private void TabPageBeforeClicked_AddNewTabOrRefreshView(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == null)
            {
                return;
            }

            if (e.TabPage == tpAddNewPage)
            {
                TabPage newPage = new();
                
                tabbedPageId++;

                ListView lvBrowser = new()
                {
                    Activation = ItemActivation.TwoClick,
                    AllowDrop = true,
                    BorderStyle = BorderStyle.None,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 8F),
                    FullRowSelect = true,
                    LabelEdit = true,
                    LargeImageList = viewImagesLarge,
                    Location = new Point(3, 3),
                    Name = $"lvFileSystemView{tabbedPageId.ToString().PadLeft(3, '0')}",
                    ShowItemToolTips = true,
                    Size = new Size(934, 505),
                    SmallImageList = viewImagesSmall,
                    TabIndex = 3,
                    UseCompatibleStateImageBehavior = false
                };

                lvBrowser.ItemActivate += lvActiveFileExplorer_ItemActivate;
                lvBrowser.DragEnter += lvActiveFileExplorer_DragEnter;
                lvBrowser.DragDrop += lvActiveFileExplorer_DragDrop;
                lvBrowser.QueryContinueDrag += lvActiveFileExplorer_QueryContinueDrag;
                lvBrowser.MouseDown += lvActiveFileExplorer_MouseDown;
                lvBrowser.MouseUp += lvActiveFileExplorer_MouseUp;

                newPage.Controls.Add(lvBrowser);

                // Make it the 2nd last tab
                int tabIndex = tbTabbedPages.TabPages.Count - 1;
                newPage.Tag = tabIndex;
                tbTabbedPages.TabPages.Insert(tabIndex, newPage);

                _activeTab = newPage;
                _activeExplorer = lvBrowser;
                _tabwiseCurrentDirectory.Add(tabIndex, DIRECTORY_MYCOMPUTER);

                // set focus to this tab
                tbTabbedPages.SelectedIndex = tabIndex;
            }
            else
            {
                _activeTab = e.TabPage;
                _activeExplorer = (ListView)e.TabPage.Controls[0];
            }

            // This is activated on the _activeExplorer which also makes it a refresh
            // also: this ensures that the toolbar & context menus are set correctly for the new tab
            LoadCurrentDirectoryView();
        }

        /// <summary>
        /// Close active tab
        /// </summary>
        private void tspCloseActiveTab_Click(object sender, EventArgs e)
        {
            if (_activeTab != null)
            {
                // When there are only 2 tabs (default+New) and Default is being closed, close the window!
                if (tbTabbedPages.TabPages.Count == 2)
                {
                    this.Close();
                    return;
                }

                // Remove the tab
                int tabIndex = (int)_activeTab.Tag!;
                int setFocusToTabIndex;
                if (tabIndex > 0)
                {
                    // Current tab is not 1st tab
                    // set focus on PREVIOUS tab
                    setFocusToTabIndex = tabIndex - 1;
                }
                else
                {
                    // Current tab IS 1st tab
                    // set focus on NEXT tab
                    setFocusToTabIndex = 1;
                }

                tbTabbedPages.TabPages.Remove(_activeTab);

                // adjust tab indexes
                Dictionary<int, string> newDirectory = new();
                for(int i = 0; i < tbTabbedPages.TabPages.Count - 1; i++)
                {
                    int index = (int)tbTabbedPages.TabPages[i].Tag!;
                    newDirectory.Add(i, _tabwiseCurrentDirectory[index]);

                    tbTabbedPages.TabPages[i].Tag = i;
                }

                // Refresh the tab directory
                _tabwiseCurrentDirectory.Clear();
                foreach(KeyValuePair<int, string> item in newDirectory)
                {
                    _tabwiseCurrentDirectory.Add(item.Key, item.Value);
                }

                _activeTab = tbTabbedPages.TabPages[setFocusToTabIndex];
                _activeExplorer = (ListView)_activeTab.Controls[0];

                // refresh
                LoadCurrentDirectoryView();
            }
        }

        /// <summary>
        /// Open the current tab as a new window
        /// </summary>
        private void tsbOpenTabNewWindow_Click(object sender, EventArgs e)
        {
            // We use ShellAppExecute for this!
            IShellAppModule newWindow = ShellEnvironment.ShellApps.GetInstanceOf(this.Command)!;
            newWindow.Execute(
                    this.Command, 
                    ShellEnvironment.WorkArea, 
                    GetCurrentDirectoryForTab(_activeTab)
                );
        }

        /// <summary>
        /// Make a note of the current directory for the given tab
        /// </summary>
        /// <param name="tab">Tab to note the directory for</param>
        /// <param name="currentDirectory">Current directory for the tab</param>
        private void NoteCurrentDirectoryForTab(TabPage tab, string currentDirectory)
        {
            int tabIndex = (int)tab.Tag!;
            _tabwiseCurrentDirectory[tabIndex] = currentDirectory;
        }

        /// <summary>
        /// Returns the current directory for a tab
        /// </summary>
        /// <param name="tab">Tab to get the directory for</param>
        /// <returns>The current directory stored</returns>
        private string GetCurrentDirectoryForTab(TabPage tab)
        {
            int tabIndex = (int)tab.Tag!;
            return _tabwiseCurrentDirectory[tabIndex];
        }


        /// <summary>
        /// Set the title text for the active tab
        /// </summary>
        private void SetActiveTabTitle()
        {
            string currentTabDirectory = GetCurrentDirectoryForTab(_activeTab);
            string imageKey = ShellEnvironment.IMAGEKEY_FOLDER;

            if (_listingState == ListViewListingStatesEnum.SpecialFolder)
            {
                if (currentTabDirectory == DIRECTORY_MYCOMPUTER)
                {
                    // See FileBrowser..ctor
                    imageKey = "COMPUTER";
                }
                else if (currentTabDirectory == PATHKEY_PRINTERS)
                {
                    // See FileBrowser..ctor
                    imageKey = "DEVICES";
                }
                else if (currentTabDirectory == PATHKEY_RECYCLEBIN)
                {
                    // See FileBrowser..ctor
                    imageKey = "RECYCLE_BIN";
                }

                _activeTab.Text = tbJumpAddress.Text;
            }
            else
            {
                if (currentTabDirectory.Length <= 12)
                {
                    _activeTab.Text = currentTabDirectory;
                }
                else
                {
                    // get only the final portion of the path
                    _activeTab.Text = System.IO.Path.GetFileName(currentTabDirectory);
                }
            }

            _activeTab.ImageKey = imageKey;

            // Workaround for text centering but in Fixed-sized items on TabControls
            tbTabbedPages.ItemSize = new Size(tbTabbedPages.ItemSize.Width, tbTabbedPages.ItemSize.Height);
        }

        /// <summary>
        /// Open location of current tab in a terminal window
        /// </summary>
        private void tsbOpenInTerminal_Click(object sender, EventArgs e)
        {
            string workingDirectoryForCommand = GetCurrentDirectoryForTab(_activeTab);

            // If active tab is showing an impossible location, start in MyDocs.
            if ((workingDirectoryForCommand == DIRECTORY_MYCOMPUTER) || (workingDirectoryForCommand == PATHKEY_PRINTERS) || (workingDirectoryForCommand == PATHKEY_RECYCLEBIN))
            {
                workingDirectoryForCommand = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            Shell32.ExecuteProgramWithWorkingDirectory(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "cmd.exe"),
                    workingDirectoryForCommand,
                    Shell32.ShellExecuteVerbsEnum.Open,
                    false                    
                );
        }


        private int tabbedPageId = 0;
    }
}