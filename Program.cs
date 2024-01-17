using System;
using System.Windows.Forms;

using AquariusShell.Forms;



namespace AquariusShell
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            //// Do we have at least one monitor?
            //if ((Screen.AllScreens.Length == 0) || (Screen.PrimaryScreen == null))
            //{
            //    throw new ApplicationException("Cannot run this program on a system without a monitor!");
            //}

            //// As the bottom-most window, this is started first
            Application.Run(new Form1());
        }
    }
}