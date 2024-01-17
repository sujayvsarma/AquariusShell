using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AquariusShell.Modules
{
    /// <summary>
    /// API that provides functionality by current object context (such as right-clicking on something)
    /// </summary>
    internal class ObjectContext
    {

        /// <summary>
        /// Find the program associated with the provided document or file.
        /// </summary>
        /// <param name="fileName">The full, valid and accessible path to the file or document.</param>
        /// <returns>Associated file. Null if there is no association. Throws one of several exceptions .</returns>
        /// <exception cref="System.IO.FileNotFoundException">Thrown if file or path was not found or is invalid.</exception>
        /// <exception cref="System.IO.IOException">If the file cannot be accessed because it is offline,etc</exception>
        /// <exception cref="OutOfMemoryException">If the file could not be processed due to memory insufficiency</exception>
        public static string? FindAssociatedProgram(string fileName)
        {
            int result = FindExecutable(fileName, null, out StringBuilder associatedExecutable);
            switch (result)
            {
                case 2: 
                    throw new System.IO.FileNotFoundException("File was not found at the specified location.", fileName);

                case 3:
                    throw new System.IO.FileNotFoundException("Path provided was not found or is invalid.", fileName);

                case 5:
                    throw new System.IO.IOException("File cannot be accessed. Perhaps it is offline?");

                case 8:
                    throw new OutOfMemoryException("File may be too large to load. Memory insufficient for operation");

                case 31:
                    return null;

                default:
                    return associatedExecutable.ToString();
            };
        }




        /// <summary>
        /// Find the executable associated with the provided document/file
        /// </summary>
        /// <param name="documentOrFilePath">Path to the document or file. Essentially what we need is the filename extension?</param>
        /// <param name="workingDirectory">[optional] Current working directory</param>
        /// <param name="associatedExecutable">[out] The associated executable</param>
        /// <returns>Error code. Greater than 32 is success.</returns>
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
        static extern int FindExecutable(string documentOrFilePath, string? workingDirectory, out StringBuilder associatedExecutable);
    }
}
