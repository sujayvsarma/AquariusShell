using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using AquariusShell.Modules;
using AquariusShell.Runtime;

namespace AquariusShell.Forms
{
    /// <summary>
    /// Performs file/directory Copy,Move and Delete operations along with a progress display
    /// </summary>
    public partial class FileOperationWithProgress : Form
    {

        #region Properties

        /// <summary>
        /// Current folder we are copying or moving or deleting from
        /// </summary>
        public string CurrentSourceFolder
        {
            set => lblSource.Text = value;
        }

        /// <summary>
        /// The current folder we are copying or moving to
        /// </summary>
        public string CurrentDestinationFolder
        {
            set => lblDestination.Text = value;
        }

        /// <summary>
        /// The filename or name of the file or directory we are processing
        /// </summary>
        public string CurrentItemName
        {
            set => lblCurrentFileName.Text = value;
        }

        /// <summary>
        /// Size of current item
        /// </summary>
        public long CurrentItemSize
        {
            set => lblCurrentFileSize.Text = ((value <= 0) ? "-" : value.FormatFileSize());
        }

        /// <summary>
        /// Set the value and caption for the progress bar
        /// </summary>
        public (int value, string caption) Progress
        {
            set
            {
                prgOperationProgress.Value = value.value;
                prgOperationProgressLabel.Text = value.caption;
            }
        }

        /// <summary>
        /// If set, operation cannot be cancelled and the Cancel button will be removed.
        /// </summary>
        public bool CannotCancel
        {
            get => _cannotCancel;
            set
            {
                _cannotCancel = value;
                if (_cannotCancel)
                {
                    btnCancelOperation.Visible = false;
                }
            }
        }
        private bool _cannotCancel = false;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialise
        /// </summary>
        private FileOperationWithProgress()
        {
            InitializeComponent();

            _filesList = new();
            _baseSourcePath = string.Empty;
            _baseDestinationPath = string.Empty;
            _baseDeletePath = string.Empty;
        }

        /// <summary>
        /// Copy or move files from one location to another
        /// </summary>
        /// <param name="source">Source file or directory (full path)</param>
        /// <param name="destination">Destination directory. If source is a file then the filename may be present as part of this path (but only filenames with extensions are allowed!)</param>
        public FileOperationWithProgress(string source, string destination) 
            : this()
        {
            _baseSourcePath = source.Trim(Path.DirectorySeparatorChar);
            _baseDestinationPath = destination.Trim(Path.DirectorySeparatorChar);
            _filesList.Add("*.*");
        }

        /// <summary>
        /// Delete a file or directory
        /// </summary>
        /// <param name="pathOfFileOrDirectoryToDelete">Full path to the file or directory to delete</param>
        public FileOperationWithProgress(string pathOfFileOrDirectoryToDelete) 
            : this()
        {
            _baseDeletePath = pathOfFileOrDirectoryToDelete.Trim(Path.DirectorySeparatorChar);
            _filesList.Add("*.*");

            CurrentDestinationFolder = "Oblivion";
        }

        /// <summary>
        /// Copy or move files from one location to another OR delete them
        /// </summary>
        /// <param name="destination">Destination directory (must be a directory!)</param>
        /// <param name="listOfFiles">List of specific files to delete, copy or move</param>
        public FileOperationWithProgress(string destination, params string[] listOfFiles)
            : this()
        {
            _baseDestinationPath = destination.Trim(Path.DirectorySeparatorChar);
            _filesList.AddRange(listOfFiles);
        }

        /// <summary>
        /// Copy or move files from one location to another OR delete them
        /// </summary>
        /// <param name="destination">Destination directory (must be a directory!)</param>
        /// <param name="listOfFiles">List of specific files to delete, copy or move</param>
        public FileOperationWithProgress(string destination, IEnumerable<string> listOfFiles)
            : this()
        {
            _baseDestinationPath = destination.Trim(Path.DirectorySeparatorChar);
            _filesList.AddRange(listOfFiles);
        }

        #endregion

        #region Operation cancellation

        /// <summary>
        /// Cancel the operation
        /// </summary>
        private void btnCancelOperation_Click(object sender, EventArgs e)
        {
            _isCancelled = true;
        }
        private bool _isCancelled = false;

        #endregion

        #region Operation methods

        /// <summary>
        /// Perform the copy operation on a single file or an entire directory
        /// </summary>
        public void CopySingleFileOrDirectoryContents()
        {
            CurrentSourceFolder = _baseSourcePath;
            CurrentDestinationFolder = _baseDestinationPath;
            Application.DoEvents();

            try
            {
                List<string> subdirectoriesOrderedByName = Directory.GetDirectories(_baseSourcePath, "*.*", SearchOption.AllDirectories).OrderBy(p => p.ToLowerInvariant()).ToList();
                if (subdirectoriesOrderedByName.Count > 0)
                {
                    this.Text = "Creating directories...";
                    CurrentItemSize = 0;
                    Application.DoEvents();

                    for (int i = 0; i < subdirectoriesOrderedByName.Count; i++)
                    {
                        if (_isCancelled)
                        {
                            break;
                        }

                        int progressPercent = (int)Math.Ceiling(((double)i / subdirectoriesOrderedByName.Count) * 100);
                        Progress = (value: progressPercent, caption: $"{i} / {subdirectoriesOrderedByName.Count}");
                        Application.DoEvents();

                        string subDirectoryPath = subdirectoriesOrderedByName[i].Replace(_baseSourcePath, string.Empty).Trim(Path.DirectorySeparatorChar);
                        string parsedDestinationPath = Path.Combine(_baseDestinationPath, subDirectoryPath);

                        CurrentItemName = subDirectoryPath;
                        Application.DoEvents();

                        if (!Directory.Exists(parsedDestinationPath))
                        {
                            Directory.CreateDirectory(parsedDestinationPath);
                        }
                    }

                    Progress = (value: 0, caption: "Waiting for files...");
                    Application.DoEvents();

                }

                if (!_isCancelled)
                {
                    List<string> filesOrderedByName = Directory.GetFiles(_baseSourcePath, "*.*", SearchOption.AllDirectories).OrderBy(p => p.ToLowerInvariant()).ToList();
                    if (filesOrderedByName.Count > 0)
                    {
                        this.Text = "Copying files...";
                        Application.DoEvents();

                        for (int i = 0; i < filesOrderedByName.Count; i++)
                        {
                            if (_isCancelled)
                            {
                                break;
                            }

                            int progressPercent = (int)Math.Ceiling(((double)i / filesOrderedByName.Count) * 100);
                            Progress = (value: progressPercent, caption: $"{i} / {filesOrderedByName.Count}");
                            Application.DoEvents();

                            string filePath = filesOrderedByName[i].Replace(_baseSourcePath, string.Empty).Trim(Path.DirectorySeparatorChar);
                            string parsedDestinationpath = Path.Combine(_baseDestinationPath, filePath);

                            CurrentItemName = filePath;
                            CurrentItemSize = (new FileInfo(filesOrderedByName[i])).Length;
                            Application.DoEvents();

                            File.Copy(filesOrderedByName[i], parsedDestinationpath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // We don't retry anything.
                MessageBox.Show(ex.Message, "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CurrentItemName = string.Empty;
            CurrentDestinationFolder = string.Empty;
            CurrentItemSize = 0;
            Progress = (value: 100, caption: "Operation Complete!");
            Application.DoEvents();

            this.Close();
        }

        /// <summary>
        /// Copy specific files/directories
        /// </summary>
        public void CopySpecificFilesOrDirectories()
        {
            try
            {
                this.Text = "Copying files...";
                Application.DoEvents();

                for(int i = 0; i < _filesList.Count; i++)
                {
                    if (_isCancelled)
                    {
                        break;
                    }

                    int progressPercent = (int)Math.Ceiling(((double)i / _filesList.Count) * 100);
                    Progress = (value: progressPercent, caption: $"{i} / {_filesList.Count}");
                    Application.DoEvents();

                    if (Directory.Exists(_filesList[i]))
                    {
                        FileOperationWithProgress subOperation = new(_filesList[i], _baseDestinationPath)
                        {
                            // Set this as cancelling that copy cannot cancel THIS copy, it is not as a modal box... 
                            CannotCancel = true
                        };
                        subOperation.Show(this);
                        subOperation.CopySingleFileOrDirectoryContents();
                    }
                    else
                    {
                        string fileName = Path.GetFileName(_filesList[i]);
                        string parsedDestinationPath = Path.Combine(_baseDestinationPath, fileName);

                        CurrentSourceFolder = Path.GetDirectoryName(_filesList[i]) ?? string.Empty;
                        CurrentDestinationFolder = _baseDestinationPath;
                        CurrentItemName = fileName;
                        CurrentItemSize = (new FileInfo(_filesList[i])).Length;
                        Application.DoEvents();

                        File.Copy(_filesList[i], parsedDestinationPath);
                    }
                }
            }
            catch (Exception ex)
            {
                // We don't retry anything.
                MessageBox.Show(ex.Message, "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CurrentSourceFolder = string.Empty;
            CurrentDestinationFolder = string.Empty;
            CurrentItemName = string.Empty;
            CurrentItemSize = 0;
            Progress = (value: 100, caption: "Operation Complete!");
            Application.DoEvents();

            this.Close();
        }

        /// <summary>
        /// Perform the move operation on a single file or an entire directory
        /// </summary>
        public void MoveSingleFileOrDirectoryContents()
        {
            CurrentSourceFolder = _baseSourcePath;
            CurrentDestinationFolder = _baseDestinationPath;
            Application.DoEvents();

            try
            {
                List<string> subdirectoriesOrderedByName = Directory.GetDirectories(_baseSourcePath, "*.*", SearchOption.AllDirectories).OrderBy(p => p.ToLowerInvariant()).ToList();
                if (subdirectoriesOrderedByName.Count > 0)
                {
                    this.Text = "Creating directories...";
                    CurrentItemSize = 0;
                    for (int i = 0; i < subdirectoriesOrderedByName.Count; i++)
                    {
                        if (_isCancelled)
                        {
                            break;
                        }

                        int progressPercent = (int)Math.Ceiling(((double)i / subdirectoriesOrderedByName.Count) * 100);
                        Progress = (value: progressPercent, caption: $"{i} / {subdirectoriesOrderedByName.Count}");

                        string subDirectoryPath = subdirectoriesOrderedByName[i].Replace(_baseSourcePath, string.Empty).Trim(Path.DirectorySeparatorChar);
                        string parsedDestinationPath = Path.Combine(_baseDestinationPath, subDirectoryPath);

                        CurrentItemName = subDirectoryPath;
                        if (!Directory.Exists(parsedDestinationPath))
                        {
                            Directory.CreateDirectory(parsedDestinationPath);
                        }
                    }

                    Progress = (value: 0, caption: "Waiting for files...");
                }

                if (!_isCancelled)
                {
                    List<string> filesOrderedByName = Directory.GetFiles(_baseSourcePath, "*.*", SearchOption.AllDirectories).OrderBy(p => p.ToLowerInvariant()).ToList();
                    if (filesOrderedByName.Count > 0)
                    {
                        this.Text = "Moving files...";
                        Application.DoEvents();

                        for (int i = 0; i < filesOrderedByName.Count; i++)
                        {
                            if (_isCancelled)
                            {
                                break;
                            }

                            int progressPercent = (int)Math.Ceiling(((double)i / filesOrderedByName.Count) * 100);
                            Progress = (value: progressPercent, caption: $"{i} / {filesOrderedByName.Count}");
                            Application.DoEvents();


                            string filePath = filesOrderedByName[i].Replace(_baseSourcePath, string.Empty).Trim(Path.DirectorySeparatorChar);
                            string parsedDestinationpath = Path.Combine(_baseDestinationPath, filePath);

                            CurrentItemName = filePath; CurrentItemSize = (new FileInfo(filesOrderedByName[i])).Length;
                            Application.DoEvents();

                            File.Copy(filesOrderedByName[i], parsedDestinationpath);
                            File.Delete(filesOrderedByName[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // We don't retry anything.
                MessageBox.Show(ex.Message, "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CurrentItemName = string.Empty;
            CurrentDestinationFolder = string.Empty;
            CurrentItemSize = 0;
            Progress = (value: 100, caption: "Operation Complete!");
            Application.DoEvents();


            this.Close();
        }

        /// <summary>
        /// Move specific files/directories
        /// </summary>
        public void MoveSpecificFilesOrDirectories()
        {
            try
            {
                this.Text = "Moving files...";
                Application.DoEvents();

                for (int i = 0; i < _filesList.Count; i++)
                {
                    if (_isCancelled)
                    {
                        break;
                    }

                    int progressPercent = (int)Math.Ceiling(((double)i / _filesList.Count) * 100);
                    Progress = (value: progressPercent, caption: $"{i} / {_filesList.Count}");
                    Application.DoEvents();

                    if (Directory.Exists(_filesList[i]))
                    {
                        FileOperationWithProgress subOperation = new(_filesList[i], _baseDestinationPath)
                        {
                            // Set this as cancelling that move cannot cancel THIS move, it is not as a modal box... 
                            CannotCancel = true
                        };
                        subOperation.Show(this);
                        subOperation.MoveSingleFileOrDirectoryContents();
                    }
                    else
                    {
                        string fileName = Path.GetFileName(_filesList[i]);
                        string parsedDestinationPath = Path.Combine(_baseDestinationPath, fileName);

                        CurrentSourceFolder = Path.GetDirectoryName(_filesList[i]) ?? string.Empty;
                        CurrentDestinationFolder = _baseDestinationPath;
                        CurrentItemName = fileName;
                        CurrentItemSize = (new FileInfo(_filesList[i])).Length;
                        Application.DoEvents();

                        File.Copy(_filesList[i], parsedDestinationPath);
                        File.Delete(_filesList[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                // We don't retry anything.
                MessageBox.Show(ex.Message, "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CurrentSourceFolder = string.Empty;
            CurrentDestinationFolder = string.Empty;
            CurrentItemName = string.Empty;
            CurrentItemSize = 0;
            Progress = (value: 100, caption: "Operation Complete!");
            Application.DoEvents();

            this.Close();
        }

        /// <summary>
        /// Perform the delete operation on a single file or an entire directory
        /// </summary>
        /// <param name="bypassRecycleBin">If set, bypasses Recycle Bin</param>
        public void DeleteSingleFileOrDirectoryContents(bool bypassRecycleBin)
        {
            CurrentSourceFolder = _baseDeletePath;
            CurrentItemSize = 0;
            Application.DoEvents();

            try
            {
                List<string> filesAndDirectoriesOrderedByNameReversed = Directory.GetFileSystemEntries(_baseDeletePath, "*.*", SearchOption.AllDirectories)
                                                                            .OrderByDescending(p => p.ToLowerInvariant()).ToList();
                for (int i = 0; i < filesAndDirectoriesOrderedByNameReversed.Count; i++)
                {
                    if (_isCancelled)
                    {
                        break;
                    }

                    int progressPercent = (int)Math.Ceiling(((double)i / filesAndDirectoriesOrderedByNameReversed.Count) * 100);
                    Progress = (value: progressPercent, caption: $"{i} / {filesAndDirectoriesOrderedByNameReversed.Count}");

                    CurrentItemName = filesAndDirectoriesOrderedByNameReversed[i];
                    
                    if (Directory.Exists(filesAndDirectoriesOrderedByNameReversed[i]))
                    {
                        CurrentItemSize = 0;
                        Application.DoEvents();

                        if (bypassRecycleBin)
                        {
                            Directory.Delete(filesAndDirectoriesOrderedByNameReversed[i], false);
                        }
                        else
                        {
                            Filesystem.SendItemToRecycleBin(filesAndDirectoriesOrderedByNameReversed[i]);
                        }
                    }
                    else
                    {
                        CurrentItemSize = (new FileInfo(filesAndDirectoriesOrderedByNameReversed[i])).Length;
                        Application.DoEvents();

                        if (bypassRecycleBin)
                        {
                            File.Delete(filesAndDirectoriesOrderedByNameReversed[i]);
                        }
                        else
                        {
                            Filesystem.SendItemToRecycleBin(filesAndDirectoriesOrderedByNameReversed[i]);
                        }                        
                    }
                    
                }
            }
            catch (Exception ex)
            {
                // We don't retry anything.
                MessageBox.Show(ex.Message, "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            CurrentSourceFolder = string.Empty;
            CurrentDestinationFolder = string.Empty;
            CurrentItemName = string.Empty;
            CurrentItemSize = 0;
            Progress = (value: 100, caption: "Operation Complete!");
            Application.DoEvents();


            this.Close();
        }

        /// <summary>
        /// Delete specific files/directories
        /// </summary>
        /// <param name="bypassRecycleBin">If set, bypasses Recycle Bin</param>
        public void DeleteSpecificFilesOrDirectories(bool bypassRecycleBin)
        {
            try
            {
                this.Text = "Deleting files...";
                Application.DoEvents();

                for (int i = 0; i < _filesList.Count; i++)
                {
                    if (_isCancelled)
                    {
                        break;
                    }

                    int progressPercent = (int)Math.Ceiling(((double)i / _filesList.Count) * 100);
                    Progress = (value: progressPercent, caption: $"{i} / {_filesList.Count}");
                    Application.DoEvents();

                    if (Directory.Exists(_filesList[i]))
                    {
                        FileOperationWithProgress subOperation = new(_filesList[i])
                        {
                            // Set this as cancelling that delete cannot cancel THIS delete, it is not as a modal box... 
                            CannotCancel = true
                        };
                        subOperation.Show(this);
                        subOperation.DeleteSingleFileOrDirectoryContents(bypassRecycleBin);
                    }
                    else
                    {
                        string fileName = Path.GetFileName(_filesList[i]);
                        string parsedDestinationPath = Path.Combine(_baseDestinationPath, fileName);

                        CurrentSourceFolder = Path.GetDirectoryName(_filesList[i]) ?? string.Empty;
                        CurrentDestinationFolder = "Oblivion";
                        CurrentItemName = fileName;
                        CurrentItemSize = 0;
                        Application.DoEvents();

                        if (bypassRecycleBin)
                        {
                            File.Delete(_filesList[i]);
                        }
                        else
                        {
                            Filesystem.SendItemToRecycleBin(_filesList[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // We don't retry anything.
                MessageBox.Show(ex.Message, "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CurrentSourceFolder = string.Empty;
            CurrentDestinationFolder = string.Empty;
            CurrentItemName = string.Empty;
            CurrentItemSize = 0;
            Progress = (value: 100, caption: "Operation Complete!");
            Application.DoEvents();

            this.Close();
        }

        #endregion

        private List<string> _filesList;
        private string _baseSourcePath, _baseDestinationPath, _baseDeletePath;
    }
}
