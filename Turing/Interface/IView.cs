using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turing.Event;

namespace Turing.Interface
{
    public  interface IView
    {
        event EventHandler<FileInitEventArgs> OnFileInitialized;
        event EventHandler<NewAlgInitEvemtArgs> OnNewAlgInitialized;
        event EventHandler<FileSaveEventArgs> OnFileSaved;
        event EventHandler<BaseAlgInitEventArgs> OnBaseAlgInitialized;
        public event EventHandler<ExecuteAlgEventArgs> OnExecuteAlgStart;
        public event EventHandler<ExecuteByStep> onStepClick;
        public event EventHandler<TraceSaveEventArgs> onTraceSave;
        public event EventHandler<TraceInitEventArgs> onTraceInit;
        void UpdateAlghoritmGrid(string[,] alg);
        public void updateRibbon(string ribbon);
        public void updateRibbon(string ribbon, int currentposition);
        public void focusAlg();
        void ShowErrorMessage(string message);
        public void openTF(string trace);
        public void updateTR(TemporaryRibbon newTr);
        public void hideStep();
        public void changeFlagAuto();
    }
}
