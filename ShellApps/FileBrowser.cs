using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using AquariusShell.Runtime;

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
                catch
                {
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

            _historyList = new();
            _clipboardCurrentAction = ClipboardActionTypesEnum.None;
            _displayFlags = FileBrowserItemDisplayFlags.None;
            _editActionsOnListViewItemsIsDisabled = false;
            _listingState = ListViewListingStatesEnum.SpecialFolder;

            _activeTab = tpDefaultPage;
            _activeExplorer = lvDefaultFileBrowser;

            ilTabImages.Images.Add("COMPUTER", SystemIcons.GetStockIcon(StockIconId.DesktopPC));
            ilTabImages.Images.Add("DEVICES", SystemIcons.GetStockIcon(StockIconId.Printer));
            ilTabImages.Images.Add("RECYCLE_BIN", SystemIcons.GetStockIcon(StockIconId.Recycler));
            ilTabImages.Images.Add(ShellEnvironment.IMAGEKEY_FOLDER, SystemIcons.GetStockIcon(StockIconId.Folder));

            tpDefaultPage.Tag = 0;              // Tab Index
            tpAddNewPage.Tag = -1;              // This should never comeup!

            _tabwiseCurrentDirectory = new()
            {
                { 0, DIRECTORY_MYCOMPUTER }
            };
        }

        private TabPage _activeTab;
        private ListView _activeExplorer;
        private Dictionary<int, string> _tabwiseCurrentDirectory;

        private string? _preselectedItem = null;
        private readonly Stack<string> _historyList;
        private ClipboardActionTypesEnum _clipboardCurrentAction;
        private FileBrowserItemDisplayFlags _displayFlags;
        private ListViewListingStatesEnum _listingState;
        private bool _editActionsOnListViewItemsIsDisabled;

        private readonly string DIRECTORY_MYCOMPUTER;
    }

}