using System.Collections.Generic;
using System.Drawing;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;

using AquariusShell.ConfigurationManagement.Settings;
using AquariusShell.Modules;
using AquariusShell.Objects;
using AquariusShell.Runtime;

namespace AquariusShell.ShellApps
{
    /// <summary>
    /// This is a specialised browser that deals with access control lists (ACLs) 
    /// of files/folders. We go beyond filesystem objects and store/provide access control 
    /// ability for other things as well.
    /// </summary>
    public partial class AccessControlBrowser : Form
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public AccessControlBrowser()
        {
            InitializeComponent();

            _settings = ConfigurationManagement.ConfigurationProvider<AccessControlBrowserSettings>.Get();

            // Adds all the "Drive" icons
            Icons.LoadDriveIcons(ilFileSystemImages);

            // Add the folder icon
            AddIconToImageLists(ShellEnvironment.IMAGEKEY_FOLDER, SystemIcons.GetStockIcon(StockIconId.Folder));
            _hierarchy = new();

            lbPrincipalsList.DisplayMember = "Caption";
            lbPrincipalsList.ValueMember = "Value";

            _currentUserSID = WindowsIdentity.GetCurrent().Owner!;
            _enumRightsValues = new[]
            {
                FileSystemRights.CreateDirectories,
                FileSystemRights.CreateFiles,
                FileSystemRights.ReadAttributes,
                FileSystemRights.ReadExtendedAttributes,
                FileSystemRights.ListDirectory,
                FileSystemRights.ReadPermissions,
                FileSystemRights.Delete,
                FileSystemRights.DeleteSubdirectoriesAndFiles,
                FileSystemRights.ChangePermissions,
                FileSystemRights.ExecuteFile,
                FileSystemRights.WriteAttributes,
                FileSystemRights.WriteExtendedAttributes
            };

            _type = ObjectTypes.None;
        }

        private readonly LinkedList<FileSystemNode> _hierarchy;
        private readonly SecurityIdentifier _currentUserSID;
        private readonly FileSystemRights[] _enumRightsValues;
        private readonly AccessControlBrowserSettings _settings = default!;

        private ObjectTypes _type;
    }
}
