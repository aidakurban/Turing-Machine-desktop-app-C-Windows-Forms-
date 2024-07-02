using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing.Event
{
    public class FileInitEventArgs
    {
        public string FilePath { get; set; }
        public FileInitEventArgs(string filePath)
        {
            FilePath = filePath;
        }
    }

}
