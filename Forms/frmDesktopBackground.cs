using AquariusShell.WindowsApi;

namespace AquariusShell.Forms
{
    public partial class frmDesktopBackground : Form
    {
        public frmDesktopBackground()
        {
            InitializeComponent();
        }

        private void frmDesktopBackground_Shown(object sender, EventArgs e)
        {
            Rectangle desktop = Screen.PrimaryScreen!.Bounds;           // App startup made sure we have a screen
            this.SetBounds(0, 0, desktop.Width, desktop.Height);
            this.BackColor = Color.SteelBlue;

            // Set as full screen & bottom most
            User32.SetWindowPos(
                    this.Handle,
                    (int)User32.SetWindowPosInsertAfterFlagsEnum.BottomMost,
                    0, 0, desktop.Width, desktop.Height,
                    (int)(User32.SetWindowPosFlagsEnum.DontActivate | User32.SetWindowPosFlagsEnum.DontResize | User32.SetWindowPosFlagsEnum.DontMove)
                );


            lvDesktopIcons.View = View.Tile;
            lvDesktopIcons.Alignment = ListViewAlignment.Top;
            lvDesktopIcons.SetBounds(0, 0, this.Width, this.Height);

            iconsList.Images.Add(
                    "FOLDER",
                    Shell32.ExtractIconFromShell32Dll(4, false)!.ToBitmap()     // directory
                );

            foreach(string item in Directory.EnumerateFileSystemEntries(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)))
            {
                if (Directory.Exists(item))
                {
                    ListViewItem lvItem = new(Path.GetFileNameWithoutExtension(item))
                    {
                        ImageKey = "FOLDER"
                    };
                    lvDesktopIcons.Items.Add(lvItem);
                }
                else
                {
                    string extn = Path.GetExtension(item).TrimStart('.').ToUpper();
                    bool hasIcon = iconsList.Images.ContainsKey(extn);
                    if (! hasIcon)
                    {
                        Icon? icon = Shell32.ExtractAssociatedIcon(item);
                        if (icon != null)
                        {
                            iconsList.Images.Add(
                                    extn,
                                    icon
                                );

                            hasIcon = true;
                        }
                    }

                    ListViewItem lvItem = new(Path.GetFileName(item));
                    if (hasIcon)
                    {
                        lvItem.ImageKey = extn;
                    }
                    lvDesktopIcons.Items.Add(lvItem);
                }
            }

            lvDesktopIcons.View = View.LargeIcon;

            frmTaskbar taskbar = new();
            taskbar.Show(this);
        }
    }
}
