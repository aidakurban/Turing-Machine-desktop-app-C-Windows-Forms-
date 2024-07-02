using Turing.Interface;
using Turing.MVPbase;

namespace Turing
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            View view = new View();
            IView iview = view;
            IModel model = new Model();
            Presenter presenter = new Presenter(model, iview);
            try
            {
                Application.Run(view);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}