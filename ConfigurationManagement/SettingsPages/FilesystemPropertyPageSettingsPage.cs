using System.Windows.Forms;

using AquariusShell.ConfigurationManagement.Settings;

namespace AquariusShell.ConfigurationManagement.SettingsPages
{
    /// <summary>
    /// Settings to configure <see cref="ConfigurationManagement.Settings.FilesystemPropertyPageSettings"/>
    /// </summary>
    public partial class FilesystemPropertyPageSettingsPage : UserControl, ISettingsPage
    {
        /// <summary>
        /// Persist settings
        /// </summary>
        public void MustApplySettings()
        {
            _settings.AllowDelete = chkDelete.Checked;
            _settings.AllowBypassDeletedItems = chkDeletePermanent.Checked;
            _settings.AllowCopy = chkCopy.Checked;
            _settings.AllowUnblockDownloadedFiles = chkUnblock.Checked;
            _settings.AllowChangeAttributes = chkChangeAttributes.Checked;
            _settings.AllowChangeCompressionSettings = chkChangeCompression.Checked;
            _settings.AllowFormatAnyDrive = chkFormatAny.Checked;
            _settings.AllowFormatRemovableDrives = chkFormatUsb.Checked;
            _settings.AllowRename = chkAllowRename.Checked;
            _settings.AllowTakeDiskOffline = chkTakeDiskOffline.Checked;
            _settings.AllowChangeBitlocker = chkModifyBitlocker.Checked;

            ConfigurationProvider<FilesystemPropertyPageSettings>.Set(_settings);
        }

        /// <summary>
        /// Load settings
        /// </summary>
        public void Reload()
        {
            _settings = ConfigurationProvider<FilesystemPropertyPageSettings>.Get();

            chkDelete.Checked = _settings.AllowDelete;
            chkDeletePermanent.Checked = _settings.AllowBypassDeletedItems;
            chkCopy.Checked = _settings.AllowCopy;
            chkUnblock.Checked = _settings.AllowUnblockDownloadedFiles;
            chkChangeAttributes.Checked = _settings.AllowChangeAttributes;
            chkChangeCompression.Checked = _settings.AllowChangeCompressionSettings;
            chkFormatAny.Checked = _settings.AllowFormatAnyDrive;
            chkFormatUsb.Checked = _settings.AllowFormatRemovableDrives;
            chkAllowRename.Checked = _settings.AllowRename;
            chkTakeDiskOffline.Checked = _settings.AllowTakeDiskOffline;
            chkModifyBitlocker.Checked = _settings.AllowChangeBitlocker;
        }

        /// <summary>
        /// Initialise
        /// </summary>
        public FilesystemPropertyPageSettingsPage()
        {
            InitializeComponent();

            Reload();
        }


        private FilesystemPropertyPageSettings _settings = default!;
    }
}
