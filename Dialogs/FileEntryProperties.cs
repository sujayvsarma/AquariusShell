using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using AquariusShell.Controls;
using AquariusShell.Modules;
using AquariusShell.Runtime;

using Microsoft.Win32;

namespace AquariusShell.Forms
{
    /// <summary>
    /// Displays properties for a file
    /// </summary>
    public partial class FileEntryProperties : Form
    {

        /// <summary>
        /// Initialise
        /// </summary>
        private FileEntryProperties()
        {
            InitializeComponent();

            _disableEvents = true;

            layoutAttributesList.HorizontalScroll.Maximum = 0;
            layoutAttributesList.VerticalScroll.Visible = true;
            layoutAttributesList.AutoScroll = true;

            _attributeCheckboxes = new();
            foreach (string attribute in Enum.GetNames<FileAttributes>())
            {
                CheckBox cb = new()
                {
                    Text = attribute switch
                    {
                        "IntegrityStream" => "Data integrity guaranteed",
                        "NoScrubData" => "Content integrity data is not scrubbed",
                        "NotContentIndexed" => "Do not index content",
                        "ReadOnly" => "Read-only",
                        "ReparsePoint" => "Reparse point",
                        "SparseFile" => "Sparse file (large file, mostly empty)",

                        _ => attribute
                    },
                    TextAlign = ContentAlignment.MiddleLeft,
                    Enabled = attribute switch
                    {
                        "Archive" or "Compressed" or "Encrypted" or "Hidden" or "ReadOnly" => true,
                        _ => false
                    },

                    Size = new(layoutAttributesList.ClientSize.Width - 10, 24),
                    Padding = new(1),
                    Margin = new(1),
                    Tag = attribute
                };

                if (cb.Enabled)
                {
                    cb.CheckedChanged += AttributeChanged;
                }

                layoutAttributesList.Controls.Add(cb);
                _attributeCheckboxes.Add(attribute, cb);
            }

            _disableEvents = false;
        }

        /// <summary>
        /// Initialise
        /// </summary>
        /// <param name="absolutePathFile">Absolute path to the file</param>
        public FileEntryProperties(string absolutePathFile) : this()
        {
            _disableEvents = true;

            _fileInfo = new(absolutePathFile);

            string fileNameExtension = Path.GetExtension(absolutePathFile);
            string typeName = Shell32.GetFileTypeName(fileNameExtension, true);

            this.Text = $"{_fileInfo.Name} Properties";
            this.Icon = Icon.ExtractAssociatedIcon(absolutePathFile) ?? SystemIcons.GetStockIcon(StockIconId.DocumentNoAssociation, ShellEnvironment.ConfiguredSizeOfIconsInPixels);

            pbFileTypeIcon.Image = this.Icon.ToBitmap();
            lblFileNameWithoutExtension.Text = Path.GetFileName(absolutePathFile);
            lblLocation.Text = _fileInfo.DirectoryName;
            lblTypeName.Text = typeName;
            lblSize.Text = _fileInfo.Length.FormatFileSize();
            lblCreated.Text = _fileInfo.CreationTime.ToString("MMM dd, yyyy HH:mm:ss");
            lblLastModified.Text = _fileInfo.LastWriteTime.ToString("MMM dd, yyyy HH:mm:ss");
            lblLastAccessed.Text = _fileInfo.LastAccessTime.ToString("MMM dd, yyyy HH:mm:ss");

            foreach (FileAttributes attribute in Enum.GetValues<FileAttributes>())
            {
                if (_fileInfo.Attributes.HasFlag(attribute))
                {
                    _attributeCheckboxes[attribute.ToString()].Checked = true;
                }
            }

            _unsafeFileStreamFile = $"{absolutePathFile}:Zone.Identifier:$DATA";
            if (File.Exists(_unsafeFileStreamFile))
            {
                StringBuilder zInfo = new();
                string[] lines = File.ReadAllLines(_unsafeFileStreamFile);
                foreach (string line in lines)
                {
                    if (line.StartsWith("ZoneId="))
                    {
                        switch (line.Replace("ZoneId=", string.Empty))
                        {
                            case "0": zInfo.Append("this machine"); break;
                            case "1": zInfo.Append("another machine on your local network"); break;
                            case "2": zInfo.Append("a website in your 'Trusted Zones' list"); break;
                            case "3": zInfo.Append("a website on the Internet"); break;
                            case "4": zInfo.Append("a website in your 'Restricted sites' list"); break;
                        }
                    }

                    if (line.StartsWith("HostUrl="))
                    {
                        zInfo.Append(" (").Append(line.Replace("HostUrl=", string.Empty)).Append(")");
                    }
                }

                btnUnblockFileOrManageAcl.Tag = zInfo.ToString();
                btnUnblockFileOrManageAcl.Text = "&Unblock";
            }
            else
            {
                _unsafeFileStreamFile = null;

                btnUnblockFileOrManageAcl.Tag = null;
                btnUnblockFileOrManageAcl.Text = "&Security...";
            }

            foreach (KeyValuePair<string, string> meta in GetFileMetadata())
            {
                lvMetadata.Items.Add(new ListViewItem(new string[] { meta.Key, meta.Value }));
            }

            _disableEvents = false;
        }


        #region Helper functions

        /// <summary>
        /// Get all associations of this file's type
        /// </summary>
        /// <param name="extension">Filename Extension</param>
        /// <returns>List of string names</returns>
        private List<string> GetFileAssociations(string extension)
        {
            List<string> associations = new();

            RegistryKey? typeKey = Registry.ClassesRoot.OpenSubKey(extension);
            if (typeKey != null)
            {
                string? appName = typeKey.GetValue(string.Empty)?.ToString();
                if (!string.IsNullOrWhiteSpace(appName))
                {
                    associations.Add(GetAssociationFriendlyName(appName));
                }

                foreach (string subKeyName in typeKey.GetSubKeyNames())
                {
                    if (subKeyName == "OpenWithProgIds")
                    {
                        RegistryKey? openWithKey = typeKey.OpenSubKey(subKeyName);
                        if (openWithKey != null)
                        {
                            foreach (string valueName in openWithKey.GetValueNames())
                            {
                                if (valueName != string.Empty)
                                {
                                    associations.Add(GetAssociationFriendlyName(valueName));
                                }
                            }

                            openWithKey.Close();
                        }
                    }
                }

                typeKey.Close();
            }

            return associations;
        }

        /// <summary>
        /// Get the friendly name for an file type association
        /// </summary>
        /// <param name="associationName">Name of the top-level association</param>
        /// <returns>Friendly name if one exists</returns>
        private string GetAssociationFriendlyName(string associationName)
        {
            string friendlyName = associationName;
            RegistryKey? assocClassName = Registry.ClassesRoot.OpenSubKey(associationName);
            if (assocClassName != null)
            {
                friendlyName = assocClassName.GetValue(string.Empty)?.ToString() ?? associationName;
                assocClassName.Close();
            }

            return friendlyName;
        }

        /// <summary>
        /// Gets the metadata associated with a file
        /// </summary>
        /// <returns>Dictionary of strings</returns>
        private Dictionary<string, string> GetFileMetadata()
        {
            Dictionary<string, string> metadata = new();

            // Create a COM object for Shell.Application
            Type? shellType = Type.GetTypeFromProgID("Shell.Application");
            if (shellType != null)
            {
                dynamic? shell = Activator.CreateInstance(shellType);
                if (shell != null)
                {
                    dynamic folder = shell.NameSpace(_fileInfo.DirectoryName);
                    dynamic file = folder.ParseName(_fileInfo.Name);

                    // Loop through the file properties and display them
                    for (int i = 0; i < 100; i++)
                    {
                        string propertyName = folder.GetDetailsOf(null, i);
                        string propertyValue = folder.GetDetailsOf(file, i);

                        if (!string.IsNullOrWhiteSpace(propertyValue))
                        {
                            metadata.Add(propertyName, propertyValue);
                        }
                    }

                    Marshal.FinalReleaseComObject(file);
                    Marshal.FinalReleaseComObject(folder);
                }

                Marshal.FinalReleaseComObject(shell);
            }

            return metadata;
        }

        #endregion

        #region General Tab Events

        /// <summary>
        /// Is actually the CheckedChanged event of all our ATTRIBUTE checkboxes
        /// </summary>
        private void AttributeChanged(object? sender, EventArgs e)
        {
            if ((!_disableEvents) && (sender is CheckBox cb))
            {
                string attributeName = (string)cb.Tag!;
                bool isSet = cb.Checked;
                try
                {
                    FileAttributes attributeToSetOrClear = Enum.Parse<FileAttributes>(attributeName);
                    if (isSet)
                    {
                        switch (attributeToSetOrClear)
                        {
                            case FileAttributes.Compressed:
                                Kernel32.EnableCompressionOnFileOrFolder(_fileInfo.FullName);
                                break;

                            case FileAttributes.Encrypted:
                                File.Encrypt(_fileInfo.FullName);
                                break;

                            default:
                                // we need to set all current + the new attribute. Otherwise we get strange attributes!
                                File.SetAttributes(_fileInfo.FullName, _fileInfo.Attributes | attributeToSetOrClear);
                                OnFileAffected();
                                break;
                        }
                    }
                    else
                    {
                        switch (attributeToSetOrClear)
                        {
                            case FileAttributes.Compressed:
                                Kernel32.DisableCompressionOnFileOrFolder(_fileInfo.FullName);
                                break;

                            case FileAttributes.Encrypted:
                                File.Decrypt(_fileInfo.FullName);
                                break;

                            default:
                                // we need to set all attributes EXCEPT the current one (bit & with complimentof (~) attrib)
                                File.SetAttributes(_fileInfo.FullName, _fileInfo.Attributes & ~attributeToSetOrClear);
                                OnFileAffected();
                                break;
                        }
                    }
                    _fileInfo = new(_fileInfo.FullName);

                    MessageBox.Show($"Attribute '{attributeName}' {(isSet ? "set" : "cleared")} successfully on file '{_fileInfo.FullName}'", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unable to set attribute '{attributeName}' on file '{_fileInfo.FullName}':{ex.Message}", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// The file was affected because IT was changed other than by a simple update.
        /// For example: its attributes were changed, security modified or was deleted
        /// </summary>
        public event FileSystemItemAffected? FileAffected;

        /// <summary>
        /// Raise the FileAffected event
        /// </summary>
        private void OnFileAffected()
        {
            if (FileAffected != null)
            {
                FileAffected(_fileInfo.FullName);
            }
        }

        /// <summary>
        /// Delete the file, permanently.
        /// </summary>
        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            bool hasShiftPressed = Control.ModifierKeys.HasFlag(Keys.Shift);

            if (MessageBox.Show(
                    $"This will {(hasShiftPressed ? "send the file to Deleted Items" : "permanently delete the file")}! {Environment.NewLine}{Environment.NewLine}{_fileInfo.FullName}",
                    "Aquarius Shell",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                ) == DialogResult.Yes)
            {
                FileOperationWithProgress fo = new(_fileInfo.FullName);
                fo.Show(this);
                fo.DeleteSingleFileOrDirectoryContents(hasShiftPressed);

                // no longer relevant
                this.Close();

                OnFileAffected();
            }
        }

        /// <summary>
        /// Move the file elsewhere.
        /// </summary>
        private void btnMoveFile_Click(object sender, EventArgs e)
        {
            sfdFileCopyMoveDestinationPicker.InitialDirectory = _fileInfo.DirectoryName;
            sfdFileCopyMoveDestinationPicker.FileName = _fileInfo.FullName;
            if (sfdFileCopyMoveDestinationPicker.ShowDialog() != DialogResult.Cancel)
            {
                string destination = sfdFileCopyMoveDestinationPicker.FileName;

                FileOperationWithProgress fo = new(_fileInfo.FullName, destination);
                fo.Show(this);
                fo.MoveSingleFileOrDirectoryContents();


                // no longer relevant
                this.Close();

                OnFileAffected();
            }
        }

        /// <summary>
        /// Copy the file elsewhere.
        /// </summary>
        private void btnCopyFile_Click(object sender, EventArgs e)
        {
            sfdFileCopyMoveDestinationPicker.InitialDirectory = _fileInfo.DirectoryName;
            sfdFileCopyMoveDestinationPicker.FileName = _fileInfo.FullName;
            if (sfdFileCopyMoveDestinationPicker.ShowDialog() != DialogResult.Cancel)
            {
                string destination = sfdFileCopyMoveDestinationPicker.FileName;

                FileOperationWithProgress fo = new(_fileInfo.FullName, destination);
                fo.Show(this);
                fo.CopySingleFileOrDirectoryContents();
            }
        }

        /// <summary>
        /// Unblock the file / mark the file as "safe" by removing its alternate stream. 
        /// OR for unblocked files, manage it's security ACLs
        /// </summary>
        private void btnUnblockFileOrManageAcl_Click(object sender, EventArgs e)
        {
            string? origin = (string?)btnUnblockFileOrManageAcl.Tag!;
            if (origin != null)
            {
                // UNBLOCK MODE!

                if (MessageBox.Show(
                        $"This file is set as 'unsafe' by Windows as it originated {origin}." + Environment.NewLine + Environment.NewLine +
                        $"Unblocking this file may result in any viruses/worms/trojans in this file to be executed which may cause harm to your data and computer." + Environment.NewLine + Environment.NewLine +
                        $"Do you wish to unblock this file?",
                        "Aquarius Shell",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    ) == DialogResult.Yes)
                {
                    File.Delete(_unsafeFileStreamFile!);

                    btnUnblockFileOrManageAcl.Tag = null;
                    btnUnblockFileOrManageAcl.Text = "&Security...";
                }
            }
            else
            {
                // SECURITY MODE!
                IShellAppModule? aclBrowser = ShellEnvironment.ShellApps.GetInstanceOf($"{IShellAppModule.CommandSignifierPrefix}aclbrowser");
                aclBrowser?.Execute(aclBrowser.Command, this, _fileInfo.FullName);
            }
        }

        #endregion

        /// <summary>
        /// Close by ESCAPE
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

        private bool _disableEvents = false;
        private FileInfo _fileInfo = default!;
        private string? _unsafeFileStreamFile = null;
        private Dictionary<string, CheckBox> _attributeCheckboxes;
    }
}
