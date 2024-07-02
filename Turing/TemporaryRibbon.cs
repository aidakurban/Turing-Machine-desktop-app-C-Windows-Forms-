using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace Turing
{
    public class TemporaryRibbon
    {
        public string ribbon { get; set; }
        public int currentPosition { get; set; }
        public string[,] alg {  get; set; }
        public int algState { get; set; }

        public int algRow { get; set; }
        public bool trace {  get; set; }
        public string traceSTR { get; set; }
        public TemporaryRibbon (string ribbon, int currentPosition, int algState, int algRow, bool trace, string[,] alg, string traceSTR)
        {
            this.ribbon = ribbon;
            this.currentPosition = currentPosition;
            this.algState = algState;
            this.algRow = algRow;
            this.trace = trace;
            this.alg = alg;
            this.traceSTR = traceSTR;
        }
    }
}
