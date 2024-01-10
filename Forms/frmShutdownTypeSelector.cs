namespace AquariusShell
{
    public partial class frmShutdownTypeSelector : Form
    {
        public frmShutdownTypeSelector()
        {
            InitializeComponent();
        }

        private void btnCancelShutdownAction_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoShutdownAction_Click(object sender, EventArgs e)
        {
            this.Hide();
            bool force = ModifierKeys.HasFlag(Keys.Control);

            //queue the shutdown action with Windows
            if (rbShutdown.Checked)
            {
                WindowsApi.ShutdownActions.Shutdown(force);
            }
            else if (rbReboot.Checked)
            {
                WindowsApi.ShutdownActions.Reboot(force);
            }
            else if (rbLogOff.Checked)
            {
                WindowsApi.ShutdownActions.Logoff(force);
            }

            Application.Exit();
        }
    }
}
