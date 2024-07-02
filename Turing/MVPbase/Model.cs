using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Turing.Event;
using Turing.Interface;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Turing.MVPbase
{
    internal class Model : IModel
    {
        public string[] ribbon { get; set; }
        public string algFilePath { get; set; }
        public string[,] currentAlg { get; set; }
        public Model()
        {

        }
        public void InitFile()
        {
            object deserialized = FileSystem.deserializeAlg(algFilePath);
            if (deserialized != null)
            {
                currentAlg = (string[,])deserialized;
            }
            else
            {
                currentAlg = new string[5, 10];
            }
        }
        public string InitTrace(string filePath)
        {
            object deserialized = FileSystem.deserializeTrace(filePath);
            if (deserialized != null)
            {

                return (string)deserialized;
            }
            else
                return "";
        }
        public void SaveFile(string filepath)
        {
            if (currentAlg != null)
            {
                FileSystem.serializeAlg(currentAlg, filepath);
            }
        }

        public void SaveTrace(string trace, string filepath)
        {
            if(trace != null)
            {
                FileSystem.serializeTrace(trace, filepath);
            }
        }
        public void BaseAlgInit(string[,] baseAlg)
        {
            currentAlg = baseAlg;
        }

        public string[] ExecuteAlg(bool trace, string[,] alg, string ribbon)
        {
            char[] ribonChar = (ribbon += "_").ToCharArray();
            char currentSymbol = ribonChar[0]; // Символ от которого идёт анализ(заменяется на новый после анализа клетки из алгоритма)
            int algRowByChar = -1; // 0 - '_' , 1 - '*', 2 - ',' , 3 - '#', 4 - '$'
            int algState = 0; // Изначально всегда 0
            int currentPosition = 0;
            char newSymbol = '-';
            string move = "";
            string traceStr = "";
            Stopwatch sw = new Stopwatch();
            int min = 0;
            while (algState != -1 & min == 0)
            {
                sw.Start();
                switch (currentSymbol)
                {
                    case '_':
                        algRowByChar = 0;
                        break;
                    case '*':
                        algRowByChar = 1;
                        break;
                    case ',':
                        algRowByChar = 2;
                        break;
                    case '#':
                        algRowByChar = 3;
                        break;
                    case '$':
                        algRowByChar = 4;
                        break;
                }
                Pars(alg[algRowByChar, algState], out newSymbol, out move, out algState);
                ribonChar[currentPosition] = newSymbol;
                if (currentPosition == ribbon.Length)                             // тк в мат условии лента бесконечная при достижении конца либо начала нужно добалять ещё 1 элемент
                {
                    char[] temporaryRib = new char[ribonChar.Length + 1];
                    for (int i = 0; i < ribonChar.Length; i++)
                    {
                        temporaryRib[i] = ribonChar[i];
                    }
                    temporaryRib[ribonChar.Length] = '_';
                    ribonChar = temporaryRib;
                }
                if (currentPosition == 0)//if (currentPosition == 0)
                {
                    char[] temporaryRib = new char[ribonChar.Length + 1];
                    for (int i = 0; i < ribonChar.Length; i++)
                    {
                        temporaryRib[i + 1] = ribonChar[i];
                    }
                    temporaryRib[0] = '_';
                    ribonChar = temporaryRib;
                    currentPosition++;
                }
                if (trace)
                {
                    ribbon = "";
                    int i = 0;
                    foreach (char c in ribonChar)
                    {
                        if (i == currentPosition)
                            ribbon += (algState + 1).ToString();
                        ribbon += c;
                        i++;
                    }
                    traceStr += ribbon + "\n";
                }
                currentPosition = move.Equals("rt") ? currentPosition + 1 : move.Equals("lt") ? currentPosition - 1 : currentPosition - currentPosition - 5;
                if (algState != -1)
                    currentSymbol = ribonChar[currentPosition];
                sw.Stop();
                min = sw.Elapsed.Minutes;
            }
            ribbon = "";
            if (min > 0)
                MessageBox.Show("Алгоритм завершён из-за истечения времени!");
            foreach (char c in ribonChar)
            {
                if (!c.Equals('_'))
                    ribbon += c;
            }
            string[] ribAndTrace = new string[2];
            ribAndTrace[0] = ribbon;
            ribAndTrace[1] = traceStr;
            return ribAndTrace;

        }

        public void Pars(string currentCell, out char newsymbol, out string move, out int currentState)
        {
            newsymbol = currentCell.IndexOf('_') != -1 ? '_' : currentCell.IndexOf('*') != -1 ? '*' :
               currentCell.IndexOf(',') != -1 ? ',' :
                   currentCell.IndexOf('#') != -1 ? '#' :                                                //try to find symbol from alphabet
                       currentCell.IndexOf('$') != -1 ? '$' : '-';
            if (newsymbol == '-')
                MessageBox.Show("Что-то не так и символ стал -");
            move = currentCell.IndexOf("rt") != -1 ? "rt" : currentCell.IndexOf("lt") != -1 ? "lt" : // try to find move
               currentCell.IndexOf("st") != -1 ? "st" : "rip";
            string take = "";
            for (int i = currentCell.IndexOf(move) + 2; i < currentCell.Length; i++)
            {
                if (Char.IsDigit(currentCell[i]))
                    take += currentCell[i];
            }
            currentState = Convert.ToInt32(take) - 1;
        }

        public TemporaryRibbon ExecuteByStep(TemporaryRibbon tr)
        {
            char[] ribonChar = tr.ribbon.ToCharArray();                                     /// tr содержит поля ribbon,  currentPosition    
            char newSymbol = '-';                                                                    /// alg, algRow, algState,   trace, traceSTR
            string move = "";
            int newState;
            switch (Convert.ToChar(ribonChar[tr.currentPosition]))
            {
                case '_':
                    tr.algRow = 0;
                    break;
                case '*':
                    tr.algRow = 1;
                    break;
                case ',':
                    tr.algRow = 2;
                    break;
                case '#':
                    tr.algRow = 3;
                    break;
                case '$':
                    tr.algRow = 4;
                    break;
            }
            Pars(tr.alg[tr.algRow, tr.algState], out newSymbol, out move, out newState);
            tr.algState = newState;
            ribonChar[tr.currentPosition] = newSymbol;
            if (tr.currentPosition == tr.ribbon.Length)                             // тк в мат условии лента бесконечная при достижении конца либо начала нужно добалять ещё 1 элемент
            {
                char[] temporaryRib = new char[ribonChar.Length + 1];
                for (int i = 0; i < ribonChar.Length; i++)
                {
                    temporaryRib[i] = ribonChar[i];
                }
                temporaryRib[ribonChar.Length] = '_';
                ribonChar = temporaryRib;
            }
            if (tr.currentPosition == 0)
            {
                char[] temporaryRib = new char[ribonChar.Length + 1];
                for (int i = 0; i < ribonChar.Length; i++)
                {
                    temporaryRib[i + 1] = ribonChar[i];
                }
                temporaryRib[0] = '_';
                ribonChar = temporaryRib;
                tr.currentPosition++;
            }
            if (tr.trace)
            {
                string rowInTrace = "";
                int i = 0;
                foreach (char c in ribonChar)
                {
                    if (i == tr.currentPosition)
                        rowInTrace += (tr.algState + 1).ToString();
                    rowInTrace += c;
                    i++;
                }
                tr.traceSTR += rowInTrace + "\n";
            }
            tr.currentPosition = move.Equals("rt") ? tr.currentPosition + 1 : move.Equals("lt") ? tr.currentPosition - 1 : tr.currentPosition; 
            switch (Convert.ToChar(ribonChar[tr.currentPosition]))
            {
                case '_':
                    tr.algRow = 0;
                    break;
                case '*':
                    tr.algRow = 1;
                    break;
                case ',':
                    tr.algRow = 2;
                    break;
                case '#':
                    tr.algRow = 3;
                    break;
                case '$':
                    tr.algRow = 4;
                    break;
            }
            tr.ribbon = "";
            foreach (char c in ribonChar)
            {
                tr.ribbon += c;
            }
            return tr;
        }
        public string trimRibbom(string ribbon)
        {
            char[] charRib = ribbon.ToCharArray();
            ribbon = "";
            foreach(char c in charRib)
            {
                if(!c.Equals('_'))
                    ribbon += c;
            }
            return ribbon;
        }
    }
}
