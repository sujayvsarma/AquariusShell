using System.Data;
using System.Diagnostics;

using Microsoft.Win32;

namespace AquariusShell
{
    public partial class frmRunDialog : Form
    {
        public frmRunDialog()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            KickOffApplicationOrAction(cbOpenURI.Text);
            this.Hide();

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdBrowseDialog.ShowDialog(this);
            this.Hide();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            string uri = ofdBrowseDialog.FileName;
            if (!File.Exists(uri))
            {
                MessageBox.Show($"Error launching: \"{uri}\".\r\n\r\nThe file, app or location could not be found!", "Run...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            KickOffApplicationOrAction(uri);
            this.Hide();
        }

        private void frmRunDialog_Shown(object sender, EventArgs e)
        {
            Icon = WindowsApi.Shell32.ExtractIconFromShell32Dll(24, false);
            Location = new Point(0, Runtime.Taskbar.Bounds.Top - this.Height);

            RegistryKey? mruListKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\RunMRU");
            if (mruListKey != null)
            {
                string order = string.Empty;
                Dictionary<string, string> list = new();
                foreach(string keyName in mruListKey.GetValueNames())
                {
                    string? value = mruListKey.GetValue(keyName)?.ToString();
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        if (keyName.Equals("MRUList"))
                        {
                            order = value;
                        }
                        else
                        {
                            list.Add(keyName, value.TrimEnd('1', '\\'));
                        }
                    }
                }

                List<string> mru = new();
                if (order == string.Empty)
                {
                    mru = list.Select(l => l.Value).ToList();
                }
                else
                {
                    foreach(char o in order)
                    {
                        string os = o.ToString();
                        if (list.ContainsKey(os))
                        {
                            mru.Add(list[os]);
                        }
                    }
                }

                cbOpenURI.Items.AddRange(mru.ToArray());
            }
        }

        private void KickOffApplicationOrAction(string uri)
        {
            ProcessStartInfo startInfo = new (uri)
            {
                UseShellExecute = true,
                Verb = "open",
                ErrorDialog = false     // we want to try again below!
            };

            try
            {
                Process.Start(startInfo);
            }
            catch { 
                // Try again using RunDLL32

                try
                {
                    startInfo = new("rundll32.exe", $"shell32.dll,{(uri.EndsWith(".cpl") ? "Control" : "OpenAs")}_RunDLL \"{uri}\"")
                    {
                        UseShellExecute = false,
                        ErrorDialog = false             // we show our own errors!
                    };

                    Process.Start(startInfo);
                }
                catch
                {
                    MessageBox.Show($"Error launching: \"{uri}\".\r\n\r\nWe could not figure out how to launch it!", "Run...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
