using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Helps in processing the command line
    /// </summary>
    internal class CommandLine
    {
        /// <summary>
        /// Parse the provided commandline and return the list of arguments
        /// </summary>
        /// <returns>List of arguments found. Empty if there were none. The first one will be the name of the app/program being launched if applicable</returns>
        public List<string> Parse()
        {
            IntPtr pointerToParsedArgumentsList = CommandLineToArgvW(
                    _originalCommandLine,
                    out int numberOfArgumentsFound
                );

            if (pointerToParsedArgumentsList == IntPtr.Zero)
            {
                return new();
            }

            try
            {
                List<string> args = new();

                for (int i = 0; i < numberOfArgumentsFound; i++)
                {
                    IntPtr pointerToCurrentArgument = Marshal.ReadIntPtr(pointerToParsedArgumentsList, (i * IntPtr.Size));
                    args.Add(Marshal.PtrToStringUni(pointerToCurrentArgument) ?? string.Empty);
                }

                // remove all empty strings
                args.RemoveAll(a => string.IsNullOrWhiteSpace(a));
                return args;
            }
            finally 
            {
                Marshal.FreeHGlobal(pointerToParsedArgumentsList);
            }
        }



        /// <summary>
        /// Initialise the CommandLine class
        /// </summary>
        /// <param name="commandLine">The command line to process</param>
        public CommandLine(string commandLine) 
        {
            _originalCommandLine = commandLine;
        }
        private string _originalCommandLine;


        /// <summary>
        /// CommandLineToArgvW function from Shell32.dll
        /// </summary>
        /// <param name="lpCmdLine">Original commandline that we need to parse</param>
        /// <param name="pNumArgs">[Out] Number of arguments found</param>
        /// <returns>POINTER to the list of arguments found. IntPtr.Zero if none.</returns>
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        static extern IntPtr CommandLineToArgvW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);
    }
}
