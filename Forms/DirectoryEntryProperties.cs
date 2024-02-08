using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using AquariusShell.Controls;
using AquariusShell.Runtime;

namespace AquariusShell.Forms
{
    /// <summary>
    /// Displays properties of a Directory
    /// </summary>
    public partial class DirectoryEntryProperties : Form
    {
        /// <summary>
        /// Initialise
        /// </summary>
        private DirectoryEntryProperties()
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
                        "Hidden" => true,
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
        /// <param name="absolutePathFolder">Absolute path to the file</param>
        public DirectoryEntryProperties(string absolutePathFolder) : this()
        {
            _disableEvents = true;

            _dirInfo = new(absolutePathFolder);

            this.Text = $"{_dirInfo.Name} Properties";
            this.Icon = SystemIcons.GetStockIcon(StockIconId.Folder, ShellEnvironment.ConfiguredSizeOfIconsInPixels);

            pbFileTypeIcon.Image = this.Icon.ToBitmap();
            lblFileNameWithoutExtension.Text = Path.GetFileName(absolutePathFolder);
            lblLocation.Text = _dirInfo.Parent?.FullName ?? string.Empty;
            lblCreated.Text = _dirInfo.CreationTime.ToString("MMM dd, yyyy HH:mm:ss");
            lblLastModified.Text = _dirInfo.LastWriteTime.ToString("MMM dd, yyyy HH:mm:ss");
            lblLastAccessed.Text = _dirInfo.LastAccessTime.ToString("MMM dd, yyyy HH:mm:ss");

            foreach (FileAttributes attribute in Enum.GetValues<FileAttributes>())
            {
                if (_dirInfo.Attributes.HasFlag(attribute))
                {
                    _attributeCheckboxes[attribute.ToString()].Checked = true;
                }
            }

            foreach (KeyValuePair<string, string> meta in GetDirectoryMetadata())
            {
                lvMetadata.Items.Add(new ListViewItem(new string[] { meta.Key, meta.Value }));
            }

            _disableEvents = false;
        }

        #region Helper functions

        /// <summary>
        /// Gets the metadata associated with a file
        /// </summary>
        /// <returns>Dictionary of strings</returns>
        private Dictionary<string, string> GetDirectoryMetadata()
        {
            Dictionary<string, string> metadata = new();

            // Create a COM object for Shell.Application
            Type? shellType = Type.GetTypeFromProgID("Shell.Application");
            if (shellType != null)
            {
                dynamic? shell = Activator.CreateInstance(shellType);
                if (shell != null)
                {
                    dynamic folder = shell.NameSpace(_dirInfo.Parent?.FullName ?? _dirInfo.Root.FullName);
                    dynamic file = folder.ParseName(_dirInfo.Name);

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
        /// The file was affected because IT was changed other than by a simple update.
        /// For example: its attributes were changed, security modified or was deleted
        /// </summary>
        public event FileSystemItemAffected? DirectoryAffected;

        /// <summary>
        /// Attribute checkbox clicked to change its state
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
                    if (attributeToSetOrClear == FileAttributes.Hidden)
                    {
                        if (isSet)
                        {
                            _dirInfo.Attributes |= FileAttributes.Hidden;
                        }
                        else
                        {
                            _dirInfo.Attributes |= ~FileAttributes.Hidden;
                        }
                    }

                    OnDirectoryAffected();
                    _dirInfo = new(_dirInfo.FullName);

                    MessageBox.Show($"Attribute '{attributeName}' {(isSet ? "set" : "cleared")} successfully on directory '{_dirInfo.FullName}'", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unable to set attribute '{attributeName}' on directory '{_dirInfo.FullName}':{ex.Message}", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Raise the FileAffected event
        /// </summary>
        private void OnDirectoryAffected()
        {
            if (DirectoryAffected != null)
            {
                DirectoryAffected(_dirInfo.FullName);
            }
        }

        /// <summary>
        /// User clicked "Delete" button. Delete the directory, recursively.
        /// </summary>
        private void btnDeleteDirectory_Click(object sender, EventArgs e)
        {
            bool hasShiftPressed = Control.ModifierKeys.HasFlag(Keys.Shift);

            if (MessageBox.Show(
                    $"This will {(hasShiftPressed ? "send the directory and its contents to Deleted Items" : "permanently delete the directory and its contents")}! {Environment.NewLine}{Environment.NewLine}{_dirInfo.FullName}",
                    "Aquarius Shell",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                ) == DialogResult.Yes)
            {
                FileOperationWithProgress fo = new(_dirInfo.FullName);
                fo.Show(this);
                fo.DeleteSingleFileOrDirectoryContents(hasShiftPressed);

                // no longer relevant
                this.Close();

                OnDirectoryAffected();
            }
        }

        /// <summary>
        /// User clicked the "Move" button. Move the entire directory elsewhere.
        /// </summary>
        private void btnMoveDirectory_Click(object sender, EventArgs e)
        {
            fbdDestinationPicker.InitialDirectory = _dirInfo.FullName;
            if (fbdDestinationPicker.ShowDialog() != DialogResult.Cancel)
            {
                string destination = fbdDestinationPicker.SelectedPath;

                FileOperationWithProgress fo = new(_dirInfo.FullName, destination);
                fo.Show(this);
                fo.MoveSingleFileOrDirectoryContents();

                // no longer relevant
                this.Close();

                OnDirectoryAffected();
            }
        }

        /// <summary>
        /// User clicked the "Copy" button. Copy the entire directory elsewhere.
        /// </summary>
        private void btnCopyDirectory_Click(object sender, EventArgs e)
        {
            fbdDestinationPicker.InitialDirectory = _dirInfo.FullName;
            if (fbdDestinationPicker.ShowDialog() != DialogResult.Cancel)
            {
                string destination = fbdDestinationPicker.SelectedPath;

                FileOperationWithProgress fo = new(_dirInfo.FullName, destination);
                fo.Show(this);
                fo.CopySingleFileOrDirectoryContents();

                // no longer relevant
                this.Close();
            }
        }

        /// <summary>
        /// User clicked the "Manage security..." button. Show the ACL edit UI
        /// </summary>
        private void btnManageSecurity_Click(object sender, EventArgs e)
        {
            IShellAppModule? aclBrowser = ShellEnvironment.ShellApps.GetInstanceOf($"{IShellAppModule.CommandSignifierPrefix}aclbrowser");
            aclBrowser?.Execute(aclBrowser.Command, this, _dirInfo.FullName);

            //ManageSecurityLists secModifyForm = new(_dirInfo);
            //secModifyForm.Show(this);
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
        private DirectoryInfo _dirInfo = default!;
        private Dictionary<string, CheckBox> _attributeCheckboxes;
    }
}
