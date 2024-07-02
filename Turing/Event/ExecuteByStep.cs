using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing.Event
{
    public class ExecuteByStep
    {
        public TemporaryRibbon tr { get; set; }
        public ExecuteByStep(TemporaryRibbon tr)
        {
            this.tr = tr;
        }
    }
}
