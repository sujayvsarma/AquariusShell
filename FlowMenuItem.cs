using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariusShell
{
    public class FlowMenuItem
    {

        public string Caption { get; set; } = string.Empty;


        public string Tooltip { get; set; } = string.Empty;


        public string Command { get; set; } = string.Empty;


        public Icon? Icon { get; set; }


        public bool IsDirectory { get; set; } = false;

    }
}
