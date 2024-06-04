using System;
using System.Windows.Forms;

namespace AquariusShell.Forms
{
    /// <summary>
    /// Shows a small custom popup dialog to accept an input value
    /// </summary>
    public partial class PopupTextInput : Form
    {

        #region Properties

        /// <summary>
        /// The prompt to show
        /// </summary>
        public string Prompt
        {
            get => lblPrompt.Text;
            set => lblPrompt.Text = value;
        }

        /// <summary>
        /// The value input by the user
        /// </summary>
        public string Value
        {
            get => tbInputValue.Text;
            set => tbInputValue.Text = value;
        }

        /// <summary>
        /// If set, then the Cancel button is shown - otherwise not.
        /// </summary>
        public bool IsCancellable
        {
            get => btnCancel.Visible;
            set => btnCancel.Visible = value;
        }

        #endregion

        /// <summary>
        /// Initialise
        /// </summary>
        public PopupTextInput()
        {
            InitializeComponent();

            IsCancellable = true;
        }

        /// <summary>
        /// Form cancelled
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Accept button clicked. Validate the input before closing the form
        /// </summary>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbInputValue.Text))
            {
                MessageBox.Show("Enter a value.", "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbInputValue.Focus();
                return;
            }

            this.Close();
        }
    }
}
