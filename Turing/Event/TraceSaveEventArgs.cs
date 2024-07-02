using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing.Event
{
    public class TraceSaveEventArgs
    {
        public string FilPath { get; set; }
        public string Trace { get; set; }

        public TraceSaveEventArgs(string path, string trace) 
        { 
            FilPath = path;
            Trace = trace;
        }
    }
}
