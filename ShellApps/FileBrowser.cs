using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AquariusShell.ShellApps
{
    /// <summary>
    /// Our own File Browser (like Windows Explorer)
    /// </summary>
    public partial class FileBrowser : Form
    {

        #region Form Events

        /// <summary>
        /// Form load, time to load everything that was set up in the "Execute()" method
        /// </summary>
        private void FileBrowser_Load(object sender, EventArgs e)
        {
            // My Computer dropdown. Populate with drives:
            tssbMyComputer.DropDownItems.Clear();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                StockIconId imageKey = drive.DriveType switch
                {
                    DriveType.CDRom => StockIconId.DriveCD,
                    DriveType.Fixed => StockIconId.DriveFixed,
                    DriveType.Network => (drive.IsReady ? StockIconId.DriveNet : StockIconId.DriveNetDisabled),
                    DriveType.NoRootDirectory => StockIconId.DriveUnknown,
                    DriveType.Ram => StockIconId.DriveRam,
                    DriveType.Removable => StockIconId.DriveRemovable,

                    _ => StockIconId.DriveUnknown
                };

                string volLabel;
                try
                {
                    volLabel = drive.VolumeLabel;
                }
                catch {
                    volLabel = "UNFORMATTED!";
                }

                ToolStripMenuItem driveItem = new(
                        $"{volLabel} ({drive.Name})",
                        SystemIcons.GetStockIcon(imageKey).ToBitmap(),
                        ToolstripButton_DriveItem_ClickEvent
                    )
                {
                    Tag = drive.Name
                };

                tssbMyComputer.DropDownItems.Add(driveItem);
            }

            LoadCurrentDirectoryView();
        }

        /// <summary>
        /// Handles form closing, notify cache to refresh and dispose ourselves
        /// </summary>
        private void FileBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((e.CloseReason == CloseReason.UserClosing) && (AppClosed != null))
            {
                AppClosed(typeof(FileBrowser));
            }
        }

        #endregion

        /// <summary>
        /// Initialise
        /// </summary>
        public FileBrowser()
        {
            InitializeComponent();

            DIRECTORY_MYCOMPUTER = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            _currentDirectory = DIRECTORY_MYCOMPUTER;
            _historyList = new();
            _clipboardCurrentAction = ClipboardActionTypesEnum.None;
            _displayFlags = FileBrowserItemDisplayFlags.None;
            _editActionsOnListViewItemsIsDisabled = false;
            _listingState = ListViewListingStatesEnum.SpecialFolder;
        }

        private string? _preselectedItem = null;
        private string _currentDirectory;
        private readonly Stack<string> _historyList;
        private ClipboardActionTypesEnum _clipboardCurrentAction;
        private FileBrowserItemDisplayFlags _displayFlags;
        private ListViewListingStatesEnum _listingState;
        private bool _editActionsOnListViewItemsIsDisabled;

        private readonly string DIRECTORY_MYCOMPUTER;
    }

}