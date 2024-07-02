using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Turing.Interface;

namespace Turing.MVPbase
{
    internal class Presenter
    {
        private readonly IModel model;
        private readonly IView view;
        TemporaryRibbon temporaryRibbon;
        public Presenter(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
            InitPresenter();
        }
        private void InitPresenter()
        {
            view.OnFileInitialized += View_OnFileInitialized;
            view.OnNewAlgInitialized += View_OnNewAlgInitialized;
            view.OnFileSaved += View_OnFileSaved;
            view.OnBaseAlgInitialized += View_OnBaseAlgInitialized;
            view.OnExecuteAlgStart += View_OnExecuteAlgStart;
            view.onStepClick += View_onStepClick;
            view.onTraceSave += View_onTraceSave;
            view.onTraceInit += View_onTraceInit;
            //model.OnErrorThrowed += Model_OnErrorThrowed;
        }

        private void View_onTraceInit(object? sender, Event.TraceInitEventArgs e)
        {
           string trace =  model.InitTrace(e.Filepath);
           view.openTF(trace);
        }

        private void View_onTraceSave(object? sender, Event.TraceSaveEventArgs e)
        {
            model.SaveTrace(e.Trace, e.FilPath);
        }

        private void View_onStepClick(object? sender, Event.ExecuteByStep e)
        {
            if (e.tr.algState != -1)
            {
                TemporaryRibbon tr = model.ExecuteByStep(e.tr);
                view.updateTR(tr);
                view.updateRibbon(tr.ribbon, tr.currentPosition);
                view.focusAlg(); 
            }
            else
            {
                MessageBox.Show("Алгоритм завершён!");
                view.changeFlagAuto();
                e.tr.ribbon = model.trimRibbom(e.tr.ribbon);
                view.updateRibbon(e.tr.ribbon);
                view.hideStep();
                if (!e.tr.traceSTR.Equals(""))
                    view.openTF(e.tr.traceSTR);
            }
        }

        private void Model_OnErrorThrowed(object? sender, Event.ErrorThrowedEventArgs e)
        {
            view.ShowErrorMessage(e.ErrorMessage);
        }

        private void View_OnExecuteAlgStart(object? sender, Event.ExecuteAlgEventArgs e)
        {
            string[] ribAndTrace = model.ExecuteAlg(e.trace, e.alg, e.ribbon) ;
            view.updateRibbon(ribAndTrace[0]);
            if (ribAndTrace[1].Length > 1)
            {
                view.openTF(ribAndTrace[1]);
            }
        }

        private void View_OnBaseAlgInitialized(object? sender, Event.BaseAlgInitEventArgs e)
        {
            model.BaseAlgInit(e.BaseAlg);
            view.UpdateAlghoritmGrid(model.currentAlg);
        }

        private void View_OnFileSaved(object? sender, Event.FileSaveEventArgs e)
        {
            model.currentAlg = e.Alg;
            model.SaveFile(e.FilPath);
        }

        private void View_OnNewAlgInitialized(object? sender, Event.NewAlgInitEvemtArgs e)
        {
            model.currentAlg = new string[5, 10];
            view.UpdateAlghoritmGrid(model.currentAlg);
        }

        private void View_OnFileInitialized(object sender, Event.FileInitEventArgs e)
        {
            model.algFilePath = e.FilePath;
            model.InitFile();
            view.UpdateAlghoritmGrid(model.currentAlg);
        }

    }
}
