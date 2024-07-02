using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turing.Event;

namespace Turing.Interface
{
    public interface IModel
    {
        string algFilePath { get; set; }
        string[,] currentAlg { get; set; }
        void InitFile();
        string InitTrace(string filePath);
        void SaveFile(string filepath);
        void SaveTrace(string trace, string filepath);
        void BaseAlgInit(string[,] baseAlg);
        string[] ExecuteAlg(bool trace, string[,] alg, string ribbon);
        TemporaryRibbon ExecuteByStep(TemporaryRibbon tr);
        public string trimRibbom(string ribbon);
        // event EventHandler<ErrorThrowedEventArgs> OnErrorThrowed;
    }
}
