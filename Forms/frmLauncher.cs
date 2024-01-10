using System.ComponentModel;
using System.Management;

using AquariusShell.Objects;

namespace AquariusShell
{
    /// <summary>
    /// Cascading start menu
    /// </summary>
    public partial class frmLauncher : Form
    {

        #region Properties

        /// <summary>
        /// A folder path. This instance will use the children of this path to 
        /// create the menu it displays.
        /// </summary>
        public string LoadPath
        {
            get;
            set;
        }

        /// <summary>
        /// Size of icons on the menu
        /// </summary>
        public IconSizeModes IconSize
        {
            get;
            set;
        }

        /// <summary>
        /// When set, acts as the first level launcher menu (contains the Run, Shutdown, etc)
        /// </summary>
        public bool IsPrimaryLauncher { get; set; } = false;


        #endregion

        #region Event Handlers

        /// <summary>
        /// Handle events from the keyboard
        /// </summary>
        private void HandleKeyboardEvents(object? sender, KeyEventArgs keyEventArgs)
        {
            if (_currentlyHighlightedMenuItem == -1)
            {
                _currentlyHighlightedMenuItem = 0;
                HighlightMenuRow(_menuItemsInOrder[_currentlyHighlightedMenuItem]);
            }

            switch (keyEventArgs.KeyCode)
            {
                case Keys.Escape:
                case Keys.Left:
                    this.Hide();
                    break;

                case Keys.Enter:
                    TableLayoutPanel tlp1 = _menuItemsInOrder[_currentlyHighlightedMenuItem];
                    ActivateMenuItemCommand(tlp1);
                    break;

                case Keys.Up:
                    ClearHighlightFromMenuRow(_menuItemsInOrder[_currentlyHighlightedMenuItem]);
                    _currentlyHighlightedMenuItem--;
                    if (_currentlyHighlightedMenuItem < 0)
                    {
                        _currentlyHighlightedMenuItem = _menuItemsInOrder.Count - 1;
                    }
                    HighlightMenuRow(_menuItemsInOrder[_currentlyHighlightedMenuItem]);
                    break;

                case Keys.Down:
                    ClearHighlightFromMenuRow(_menuItemsInOrder[_currentlyHighlightedMenuItem]);
                    _currentlyHighlightedMenuItem++;
                    if (_currentlyHighlightedMenuItem > (_menuItemsInOrder.Count - 1))
                    {
                        _currentlyHighlightedMenuItem = 0;
                    }
                    HighlightMenuRow(_menuItemsInOrder[_currentlyHighlightedMenuItem]);
                    break;

                case Keys.Right:
                    TableLayoutPanel tlp2 = _menuItemsInOrder[_currentlyHighlightedMenuItem];
                    CascadeMenuItem data = (CascadeMenuItem)tlp2.Tag!;

                    // We take action ONLY on directories and not on links!
                    if (data.IsContainer)
                    {
                        ActivateMenuItemCommand(tlp2);
                    }
                    break;
            }
        }


        private void OnItemMouseEnter(object? sender, EventArgs mouseEventArgs)
        {
            if (sender is Control ctl)
            {
                TableLayoutPanel? tlp = GetTableLayoutPanel(ctl);
                if (tlp != null)
                {
                    HighlightMenuRow(tlp);
                    _currentlyHighlightedMenuItem = GetTlpIndexFromDictionary(tlp);
                }
            }
        }

        private void OnItemMouseLeave(object? sender, EventArgs mouseEventArgs)
        {
            if (sender is Control ctl)
            {
                TableLayoutPanel? tlp = GetTableLayoutPanel(ctl);
                if (tlp != null)
                {
                    ClearHighlightFromMenuRow(tlp);
                    _currentlyHighlightedMenuItem = GetTlpIndexFromDictionary(tlp);
                }
            }
        }

        private void OnItemMouseClick(object? sender, EventArgs clickEventArgs)
        {
            if (sender is Control ctl)
            {
                TableLayoutPanel? tlp = GetTableLayoutPanel(ctl);
                if (tlp != null)
                {
                    ActivateMenuItemCommand(tlp);
                }
            }
        }

        private void NextLevel_ItemClicked(CascadeMenuItem menuItem)
        {
            this.Hide();

            if (ItemClicked != null)
            {
                ItemClicked(menuItem);
            }
            else
            {
                bool succeededLaunch = WindowsApi.Shell32.ExecuteUri(menuItem.FullPath);
                if (!succeededLaunch)
                {
                    MessageBox.Show($"Error launching: \"{menuItem.FullPath}\".\r\n\r\nWe could not figure out how to execute it!", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Event delegate for a click-event on a launcher item. This is only raised for 
        /// file/shortcut types and not for directory/container type of elements
        /// </summary>
        public event LauncherItemClicked ItemClicked = default!;


        /// <summary>
        /// Runs when the form is first loaded, load the items in the path and render the list
        /// </summary>
        private void frmLauncher_Load(object sender, EventArgs e)
        {
            // initial minimum height
            this.Height = 24;

            if (IsPrimaryLauncher)
            {
                ManagementObjectSearcher wmi = new("SELECT Caption FROM Win32_OperatingSystem");
                foreach (ManagementObject mo in wmi.Get())
                {
                    _windowsVersion = mo["Caption"]?.ToString() ?? ((Environment.OSVersion.Platform == PlatformID.Win32NT) ? "Windows " : "Linux ") + Environment.OSVersion.Version.ToString(2);
                    break;
                }

                Label versionLabel = new()
                {
                    BackColor = Color.SteelBlue,
                    Font = new Font("Calibri", 18F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(0, 0),
                    Margin = new Padding(5, 0, 5, 0),
                    Name = "lblWindowsVersionLabel",
                    Size = new Size(55, 384),
                    TabIndex = 0,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                versionLabel.Paint += OnWindowsVersionLabelPaint;
                this.Controls.Add(versionLabel);

                this.Width += versionLabel.Width;
                _menuItemOffset = versionLabel.Width + 4;

                LoadItemsFromPath(LoadPath);

                // Add the Windows control area
                Panel controlArea = new()
                {
                    Location = new(versionLabel.Width + 2, this.Controls[this.Controls.Count - 1].Bottom + 2),
                    Size = new(this.Width - (versionLabel.Width + 1) - 1, 32)
                };

                Label horizontalLine = new()
                {
                    Location = new(0, 0),
                    Size = new(controlArea.Width, 2),
                    BackColor = Color.Black
                };

                Label userName = new()
                {
                    Font = new Font("Segoe UI", 8F),
                    Dock = DockStyle.Top | DockStyle.Left,
                    Location = new(0, 3),
                    Size = new Size(135, 32),
                    Padding = new(8),
                    Text = $"{Environment.UserDomainName}\\{Environment.UserName}"
                };

                PictureBox runIcon = new()
                {
                    Image = WindowsApi.Shell32.ExtractIconFromShell32Dll(24, false)!.ToBitmap(),
                    Location = new((controlArea.Width - 64), 3),
                    Size = new(32, 32),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Cursor = Cursors.Hand
                };

                PictureBox shutDownIcon = new()
                {
                    Image = WindowsApi.Shell32.ExtractIconFromShell32Dll(27, false)!.ToBitmap(),
                    Location = new((controlArea.Width - 32), 3),
                    Size = new(32, 32),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Cursor = Cursors.Hand
                };

                userName.Width = (this.Width - versionLabel.Width - runIcon.Width - shutDownIcon.Width) - 4;

                controlArea.Controls.Add(horizontalLine);
                controlArea.Controls.Add(userName);
                controlArea.Controls.Add(runIcon);
                controlArea.Controls.Add(shutDownIcon);
                this.Controls.Add(controlArea);

                runIcon.Click += RunIcon_Click;
                shutDownIcon.Click += ShutDownIcon_Click;

                versionLabel.Height = this.Height;
                this.Width = versionLabel.Width + this.Controls[2].Width;
                this.Location = new(Runtime.Taskbar.Bounds.Left, Runtime.Taskbar.Bounds.Top - this.Height - 1);

            }
            else
            {
                LoadItemsFromPath(LoadPath);
            }
        }

        /// <summary>
        /// Paints the Windows version label on the first Launcher (START menu)
        /// </summary>
        private void OnWindowsVersionLabelPaint(object? sender, PaintEventArgs e)
        {
            SizeF clipSize = e.Graphics.VisibleClipBounds.Size;
            RectangleF drawFromRect = new(0, 0, clipSize.Height, clipSize.Width);

            e.Graphics.TranslateTransform(0, clipSize.Height);
            e.Graphics.RotateTransform(270);
            e.Graphics.DrawString(
                    _windowsVersion,
                    new Font("Calibri", 18F, FontStyle.Bold),
                    Brushes.White,
                    drawFromRect,
                    _versionStringFormat
                );
        }



        private void ShutDownIcon_Click(object? sender, EventArgs e)
        {
            this.Hide();

            frmShutdownTypeSelector shutdownTypeSelector = new();
            DialogResult result = shutdownTypeSelector.ShowDialog(this);
        }

        private void RunIcon_Click(object? sender, EventArgs e)
        {
            this.Hide();

            frmRunDialog run = new();
            run.ShowDialog(this);
        }

        #endregion

        public frmLauncher()
        {
            InitializeComponent();

            LoadPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
            IconSize = IconSizeModes.Icons24;

            _menuItemsInOrder = new();
        }

        /// <summary>
        /// Load all items from the provided path and add them to the launcher
        /// </summary>
        /// <param name="path">Path to process</param>
        private void LoadItemsFromPath(string path)
        {
            int dataItemIndex = 0;
            string[] includeExtensions =
            [
                ".lnk",
                ".url"
            ];

            foreach (string directory in path.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                dataItemIndex = ProcessDirectory(directory, dataItemIndex, includeExtensions);
            }


            if (dataItemIndex > 0)
            {
                // Each menu item is Mode-based tall, + 8 for top and bottom padding
                this.Height = (dataItemIndex * IconSize switch
                {
                    IconSizeModes.Icons16 => 16,
                    IconSizeModes.Icons32 => 32,
                    _ => 24
                }) + 8;
            }
            else
            {
                Label caption = new()
                {
                    Text = "(no items found)",
                    Font = new Font(new FontFamily("Segoe UI"), 8F),
                    BackColor = Color.Transparent,
                    AutoEllipsis = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = false,
                    Size = new(216, 24),
                    Margin = new(0),
                    Padding = new Padding(4, 2, 4, 2),
                    Enabled = false
                };
                this.Controls.Add(caption);
            }
        }

        /// <summary>
        /// Process directories and files in the provided path and add them to the launcher
        /// </summary>
        /// <param name="directory">The path to add items from</param>
        /// <param name="dataItemIndex">Data item index counter (from caller)</param>
        /// <param name="includeExtensions">File extensions to include (def: .url, .lnk)</param>
        /// <returns>New value for dataItemIndex</returns>
        private int ProcessDirectory(string directory, int dataItemIndex, string[] includeExtensions)
        {
            // do directories first
            foreach (string item in Directory.EnumerateDirectories(directory))
            {
                CascadeMenuItem menuitem = new(item);
                AddMenuItem(menuitem, dataItemIndex++);
            }

            // files...
            foreach (string item in Directory.EnumerateFiles(directory))
            {
                if (includeExtensions.Contains(Path.GetExtension(item)))
                {
                    CascadeMenuItem menuitem = new(item);
                    AddMenuItem(menuitem, dataItemIndex++);
                }
            }

            return dataItemIndex;
        }

        /// <summary>
        /// Add an item to the launcher's menu
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <param name="dataItemIndex">Data item index counter (from caller)</param>
        private void AddMenuItem(CascadeMenuItem item, int dataItemIndex)
        {
            int controlTop = 1;

            if (IsPrimaryLauncher)
            {
                controlTop = ((this.Controls.Count == 1) ? 1 : (this.Controls[this.Controls.Count - 1].Bottom + 1));
            }
            else
            {
                controlTop = ((this.Controls.Count == 0) ? 1 : (this.Controls[this.Controls.Count - 1].Bottom + 1));
            }

            int iconSize = IconSize switch
            {
                IconSizeModes.Icons16 => 16,
                IconSizeModes.Icons32 => 32,
                _ => 24
            };

            TableLayoutPanel menuLayoutPanel = new()
            {
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                Padding = new System.Windows.Forms.Padding(0),
                RowCount = 1,
                ColumnCount = 3,
                Location = new Point(_menuItemOffset, controlTop),
                Size = new Size(248, iconSize),
                Tag = item
            };

            menuLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            menuLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            menuLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));

            menuLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, (float)iconSize));

            if ((IconSize != IconSizeModes.NoIcons) && (item.Icon != null))
            {
                PictureBox icon = new()
                {
                    Image = item.Icon.ToBitmap(),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    MaximumSize = new(iconSize, iconSize),
                    BackColor = Color.Transparent,
                    Margin = new(0)
                };
                icon.MouseEnter += OnItemMouseEnter;
                icon.MouseLeave += OnItemMouseLeave;
                icon.Click += OnItemMouseClick;

                menuLayoutPanel.Controls.Add(icon, 0, 0);
            }

            Label caption = new()
            {
                Text = item.Text,
                Font = _labelFont,
                BackColor = Color.Transparent,
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true,
                MaximumSize = new(216, iconSize),
                Margin = new(0),
                Padding = new(4, 2, 4, 2)
            };
            caption.MouseEnter += OnItemMouseEnter;
            caption.MouseLeave += OnItemMouseLeave;
            caption.Click += OnItemMouseClick;

            menuLayoutPanel.Controls.Add(caption, 1, 0);

            if (item.IsContainer)
            {
                Label arrow = new()
                {
                    Text = ">",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = _labelFont,
                    BackColor = Color.Transparent,
                    Margin = new(0),
                    MaximumSize = new(iconSize, iconSize)
                };
                arrow.MouseEnter += OnItemMouseEnter;
                arrow.MouseLeave += OnItemMouseLeave;
                arrow.Click += OnItemMouseClick;

                menuLayoutPanel.Controls.Add(arrow, 2, 0);
            }

            menuLayoutPanel.MouseEnter += OnItemMouseEnter;
            menuLayoutPanel.MouseLeave += OnItemMouseLeave;
            menuLayoutPanel.Click += OnItemMouseClick;

            this.Controls.Add(menuLayoutPanel);
            _menuItemsInOrder.Add(dataItemIndex, menuLayoutPanel);
        }

        /// <summary>
        /// ATTEMPT to execute the appropriate action for the menu item that was (clicked or hit ENTER on). If it is a directory, 
        /// launches a submenu, otherwise executes the link.
        /// </summary>
        /// <param name="tlp">TableLayoutPanel at the menu item</param>
        /// <returns>True if the attempt was successful</returns>
        private bool ActivateMenuItemCommand(TableLayoutPanel tlp)
        {
            if (_previouslyLaunchedNextLevel != null)
            {
                _previouslyLaunchedNextLevel.Close();
                _previouslyLaunchedNextLevel = null;
            }

            CascadeMenuItem data = (CascadeMenuItem)tlp.Tag!;
            if (data.IsContainer)
            {
                frmLauncher nextLevel = new()
                {
                    LoadPath = data.FullPath,
                    IconSize = this.IconSize,
                    IsPrimaryLauncher = false
                };

                if (nextLevel.Height >= Screen.PrimaryScreen!.Bounds.Height)
                {
                    nextLevel.Height = (Screen.PrimaryScreen!.Bounds.Height - Runtime.Taskbar.Bounds.Height);
                    nextLevel.AutoScroll = true;
                }

                // distance from current item to bottom
                int dt = this.Top + tlp.Top;
                int vh = Runtime.Taskbar.Bounds.Top - dt;
                if (vh < nextLevel.Height)
                {
                    dt = Runtime.Taskbar.Bounds.Top - nextLevel.Height;
                }

                nextLevel.Location = new Point(this.Left + this.Width + 1, dt);
                nextLevel.ItemClicked += NextLevel_ItemClicked;

                _previouslyLaunchedNextLevel = nextLevel;
                nextLevel.Show(this);
            }
            else
            {
                this.Hide();

                if (ItemClicked != null)
                {
                    ItemClicked(data);
                }
            }

            return true;
        }
        private frmLauncher? _previouslyLaunchedNextLevel = null;

        /// <summary>
        /// Get index of TLP from the dictionary
        /// </summary>
        /// <param name="tlp">TLP</param>
        /// <returns>Index (non-zero) or -1 (not found)</returns>
        private int GetTlpIndexFromDictionary(TableLayoutPanel tlp)
        {
            KeyValuePair<int, TableLayoutPanel> itm = _menuItemsInOrder.FirstOrDefault(i => (i.Value == tlp));
            if (itm.Value != default)
            {
                return itm.Key;
            }

            return -1;
        }

        /// <summary>
        /// Get the table layout panel under the the provided control
        /// </summary>
        /// <param name="hitControl">A label or picture box or the TLP itself</param>
        /// <returns>TLP or Null</returns>
        private TableLayoutPanel? GetTableLayoutPanel(Control hitControl)
        {
            if ((hitControl is Label lbl) && (lbl.Parent is TableLayoutPanel tlp))
            {
                return tlp;
            }

            if ((hitControl is PictureBox pb) && (pb.Parent is TableLayoutPanel tlp2))
            {
                return tlp2;
            }

            if (hitControl is TableLayoutPanel tlp3)
            {
                return tlp3;
            }

            return null;
        }

        /// <summary>
        /// Shows the menu-row in a highlight
        /// </summary>
        /// <param name="menuItemRow">Reference to the TableLayoutPanel on the row</param>
        private void HighlightMenuRow(TableLayoutPanel menuItemRow)
        {
            menuItemRow.BackColor = Color.SteelBlue;
            menuItemRow.ForeColor = Color.White;
        }

        /// <summary>
        /// Removes the highlight from the menu-row
        /// </summary>
        /// <param name="menuItemRow">Reference to the TableLayoutPanel on the row</param>
        private void ClearHighlightFromMenuRow(TableLayoutPanel menuItemRow)
        {
            menuItemRow.BackColor = SystemColors.Control;
            menuItemRow.ForeColor = SystemColors.ControlText;
        }


        private Dictionary<int, TableLayoutPanel> _menuItemsInOrder;
        private Font _labelFont = new(new FontFamily("Segoe UI"), 8F);
        private int _menuItemOffset = 1, _currentlyHighlightedMenuItem = -1;
        private StringFormat _versionStringFormat = new() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        private string _windowsVersion = string.Empty;

    }


    /// <summary>
    /// The mode the launcher would work with
    /// </summary>
    public enum IconSizeModes
    {
        /// <summary>
        /// Folder/cascade menu with 32x32 icons
        /// </summary>
        Icons32 = 2,

        /// <summary>
        /// Folder/cascade menu with 24x24 icons
        /// </summary>
        Icons24 = 3,

        /// <summary>
        /// Folder/cascade menu with 16x16 icons
        /// </summary>
        Icons16 = 4,

        /// <summary>
        /// Folder/cascade menu without icons
        /// </summary>
        NoIcons = 5
    }

    /// <summary>
    /// Event delegate for a click-event on a launcher item. This is only raised for 
    /// file/shortcut types and not for directory/container type of elements
    /// </summary>
    /// <param name="menuItem">The menu data item that was clicked</param>
    public delegate void LauncherItemClicked(CascadeMenuItem menuItem);
}
