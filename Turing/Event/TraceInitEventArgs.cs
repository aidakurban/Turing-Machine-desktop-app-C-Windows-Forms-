using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing.Event
{
    public class TraceInitEventArgs
    {
        public string Filepath;
        public TraceInitEventArgs(string filepath)
        {
            Filepath = filepath;
        }
    }
}
