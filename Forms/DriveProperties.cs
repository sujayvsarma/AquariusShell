using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using AquariusShell.Controls;
using AquariusShell.Modules;
using AquariusShell.Runtime;

namespace AquariusShell.Forms
{
    /// <summary>
    /// Displays properties of a drive
    /// </summary>
    public partial class DriveProperties : Form
    {
        /// <summary>
        /// Initialise
        /// </summary>
        private DriveProperties()
        {
            InitializeComponent();

            _drive = default!;
        }

        /// <summary>
        /// Initialise
        /// </summary>
        /// <param name="drive">DriveInfo of the drive we wish to display</param>
        public DriveProperties(DriveInfo drive)
            : this()
        {
            _drive = drive;
            DisplayDiskInfo();
        }

        private void DisplayDiskInfo()
        {
            string driveTypeName;
            StockIconId imageKey;

            switch (_drive.DriveType)
            {
                case DriveType.CDRom:
                    imageKey = StockIconId.DriveCD;
                    driveTypeName = "Optical drive";
                    break;

                case DriveType.Fixed:
                    imageKey = StockIconId.DriveFixed;
                    driveTypeName = "Hard disk";
                    break;

                case DriveType.Network:
                    imageKey = (_drive.IsReady ? StockIconId.DriveNet : StockIconId.DriveNetDisabled);
                    driveTypeName = "Network-mapped drive";
                    break;

                case DriveType.Ram:
                    imageKey = StockIconId.DriveRam;
                    driveTypeName = "RAM disk";
                    break;

                case DriveType.Removable:
                    imageKey = StockIconId.DriveRemovable;
                    driveTypeName = "USB/removable drive";
                    break;

                default:
                    imageKey = StockIconId.DriveUnknown;
                    driveTypeName = "Unknown";
                    break;
            }

            pbDriveTypeIcon.Image = SystemIcons.GetStockIcon(imageKey).ToBitmap();
            lblTypeName.Text = driveTypeName;
            lblDriveLetter.Text = _drive.Name;

            try
            {
                lblDriveLabel.Text = _drive.VolumeLabel;
                lblDriveFormat.Text = _drive.DriveFormat;
                lblTotalSize.Text = _drive.TotalSize.FormatFileSize();
                lblTotalFreeSpace.Text = _drive.TotalFreeSpace.FormatFileSize();
                lblAvailableSpace.Text = _drive.AvailableFreeSpace.FormatFileSize();

                prgDriveSpaceUsage.Value = (int)Math.Ceiling(
                        ((double)(_drive.TotalSize - _drive.AvailableFreeSpace) / _drive.TotalSize) * 100
                    );
            }
            catch (IOException)
            {
                lblDriveLabel.Text = "Not formatted";
                lblDriveFormat.Text = "Unknown";
                lblTotalSize.Text = "-";
                lblTotalFreeSpace.Text = "-";
                lblAvailableSpace.Text = "-";
                prgDriveSpaceUsage.Value = 0;
            }

            if (DriveLetter == "C:")
            {
                btnInvokeTakeOffline.Enabled = false;
                btnInvokeFormatDisk.Enabled = false;
            }
        }

        /// <summary>
        /// Invoke CHKDSK. All versions of Windows run this on next reboot.
        /// </summary>
        private void btnInvokeCheckdisk_Click(object sender, EventArgs e)
        {
            if (_drive.Name == "C:\\")
            {
                // we can never scan this now.
                if (MessageBox.Show("The boot volume cannot be scanned now. We can schedule a check the next time you reboot your computer. Do you wish to schedule a scan on next reboot?",
                        "Aquarius Shell", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Shell32.ExecuteProgram(
                            Path.Combine(System32, "cmd.exe"), Shell32.ShellExecuteVerbsEnum.RunAs, false,
                                $"/c {Path.Combine(System32, "fsutil.exe")} dirty set c: && {Path.Combine(System32, "chkntfs.exe")} c: /c"
                        );
                }
            }
            else
            {
                Shell32.ExecuteProgram(Path.Combine(System32, "cmd.exe"), Shell32.ShellExecuteVerbsEnum.RunAs, false, "/k", Path.Combine(System32, "chkdsk.exe"), $"{DriveLetter}:", "/F");
            }
        }

        /// <summary>
        /// Invoke Defrag on the drive
        /// </summary>
        private void btnInvokeDefrag_Click(object sender, EventArgs e)
        {
            Shell32.ExecuteProgram(Path.Combine(System32, "cmd.exe"), Shell32.ShellExecuteVerbsEnum.RunAs, false, "/k", Path.Combine(System32, "defrag.exe"), $"{DriveLetter}:", "/F");
            _drive = new(_drive.Name);
            DisplayDiskInfo();
            OnDriveAffected();
        }

        /// <summary>
        /// Rename the drive volume
        /// </summary>
        private void btnInvokeRenameVolume_Click(object sender, EventArgs e)
        {
            PopupTextInput popupInput = new PopupTextInput()
            {
                Prompt = "New name of the volume"
            };

            if (popupInput.ShowDialog(this) == DialogResult.OK)
            {
                if ((_drive.DriveFormat == "NTFS") && (popupInput.Value.Length > 32))
                {
                    MessageBox.Show($"NTFS drives support volume labels of up to 32 characters only. Your label has {popupInput.Value.Length} characters.",
                            "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if ((_drive.DriveFormat != "NTFS") && (popupInput.Value.Length > 8))
                {
                    MessageBox.Show($"Non-NTFS drives support volume labels of up to 8 characters only. Your label has {popupInput.Value.Length} characters.",
                            "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                char[] iFN = Path.GetInvalidFileNameChars();
                foreach (char c in popupInput.Value)
                {
                    if (iFN.Contains(c))
                    {
                        MessageBox.Show($"The name entered '{popupInput.Value}' contains characters not allowed in volume names.",
                            "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // DO NOT quote the label string!
                int pid = Shell32.ExecuteProgram(Path.Combine(System32, "label.exe"), Shell32.ShellExecuteVerbsEnum.RunAs, false, $"{DriveLetter}:", popupInput.Value);
                System.Diagnostics.Process.GetProcessById(pid).WaitForExit();

                _drive = new(_drive.Name);
                DisplayDiskInfo();
                OnDriveAffected();
            }

            popupInput.Dispose();
        }

        /// <summary>
        /// Take the volume offline
        /// </summary>
        private void btnInvokeTakeOffline_Click(object sender, EventArgs e)
        {
            // This is the best way
            Shell32.ExecuteProgram("diskmgmt.msc", Shell32.ShellExecuteVerbsEnum.RunAs);
            this.Close();
        }

        /// <summary>
        /// Format the drive
        /// </summary>
        private void btnInvokeFormatDisk_Click(object sender, EventArgs e)
        {
            // Errr... ?
            if (MessageBox.Show("Are you sure? This will erase EVERYTHING on this disk drive!",
                        "Aquarius Shell", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // This Shell call creates a Modal dialog!
                Shell32.ShowFormatDiskDialog(DriveLetter, this.Handle);

                _drive = new(_drive.Name);
                DisplayDiskInfo();
                OnDriveAffected();
            }
        }

        /// <summary>
        /// Invoke the Manage Bitlocker UI
        /// </summary>
        private void btnInvokeManageBitlocker_Click(object sender, EventArgs e)
        {
            Shell32.ExecuteProgram(
                    Path.Combine(System32, "control.exe"),
                    Shell32.ShellExecuteVerbsEnum.RunAs,
                    false,
                    "/name", "Microsoft.BitLockerDriveEncryption", "/page", $"?InitialVolume=={DriveLetter}:"
                );
            this.Close();
        }

        /// <summary>
        /// Invoke form to manage security
        /// </summary>
        private void btnInvokeManageSecurity_Click(object sender, EventArgs e)
        {
            // we want the root directory of the drive:
            IShellAppModule? aclBrowser = ShellEnvironment.ShellApps.GetInstanceOf($"{IShellAppModule.CommandSignifierPrefix}aclbrowser");
            aclBrowser?.Execute(aclBrowser.Command, this, _drive.RootDirectory.FullName);

            //ManageSecurityLists secModifyForm = new(_drive.RootDirectory);
            //secModifyForm.Show(this);
        }

        /// <summary>
        /// The file was affected because IT was changed other than by a simple update.
        /// For example: its attributes were changed, security modified or was deleted
        /// </summary>
        public event FileSystemItemAffected? DriveAffected;

        /// <summary>
        /// Raise the FileAffected event
        /// </summary>
        private void OnDriveAffected()
        {
            if (DriveAffected != null)
            {
                DriveAffected(_drive.Name);
            }
        }

        /// <summary>
        /// Drive letter with colon
        /// </summary>
        private string DriveLetter => _drive.Name[..1].ToUpperInvariant();

        private string System32 = Environment.GetFolderPath(Environment.SpecialFolder.System);
        private DriveInfo _drive;
    }
}
