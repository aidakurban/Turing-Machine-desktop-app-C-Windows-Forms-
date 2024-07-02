using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing.Event
{
    public class BaseAlgInitEventArgs
    {
        public string[,] BaseAlg { get; set; }
        public BaseAlgInitEventArgs(string[,] baseAlg)
        {
            BaseAlg = baseAlg;
        }

    }
}
