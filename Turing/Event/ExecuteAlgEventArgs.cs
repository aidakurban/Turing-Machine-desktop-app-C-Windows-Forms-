using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing.Event
{
    public class ExecuteAlgEventArgs
    {
        public string mide { get; set; }
        public int speed { get; set;}
        public bool trace { get; set; }
        public string[,] alg { get; set; }
        public string ribbon { get; set; }
        public ExecuteAlgEventArgs(string mide, int speed, bool trace, string[,] alg, string ribbon)
        {
            this.mide = mide;
            this.speed = speed;
            this.trace = trace;
            this.alg = alg;
            this.ribbon = ribbon;
        }
    }
}
