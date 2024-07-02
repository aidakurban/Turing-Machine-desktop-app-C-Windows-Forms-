using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing.Event
{
    public class FileSaveEventArgs
    {  
        public string FilPath { get; set; }
        public string[,] Alg { get; set; }
        public FileSaveEventArgs(string[,] alg, string filPath)
        {
            Alg = alg;
            FilPath = filPath;
        }
    }
}
