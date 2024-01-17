using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariusShell.Modules
{
    /// <summary>
    /// Describes an icon that is present as a resource in an OOBE (Windows) DLL
    /// </summary>
    /// <param name="PathToResourceFILE">Absolute path to the DLL or EXE file to load the resource from </param>
    /// <param name="Index">Zero-based index into the <see cref="PathToResourceFILE"/> file</param>
    internal record OobeIcon(string PathToResourceFILE, int Index)
    {
    }

}
