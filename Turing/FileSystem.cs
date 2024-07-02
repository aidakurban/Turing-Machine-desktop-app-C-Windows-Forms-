using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design.Behavior;

namespace Turing
{
    internal class FileSystem
    {
        public static string[,] deserializeAlg(string filepath)
        {
            if (filepath != null)
            {
                StreamReader sr = new StreamReader(filepath);
                string line = sr.ReadLine();
                int cols = line.ToCharArray().Count(c => c == ';');
                string[,] alg = new string[5, cols];
                int j = 0;
                line = sr.ReadLine();
                bool flag = true;
                while (line != null && flag)
                {
                    for (int i = 0; i < alg.GetLength(1); i++)
                    {
                        alg[j, i] = line.Substring(0, line.IndexOf(";"));
                        if (alg[j,i].Replace(" ","").Length > 0)
                            flag = CheckAlg(alg[j, i], cols);
                        if (!flag)
                        {
                            sr.Close();
                            return null;
                        }
                        line = line.Substring(line.IndexOf(";") + 1);
                    }
                    j++;
                    line = sr.ReadLine();

                }
                sr.Close();
                return alg;
            }
            return null;
        }

        public static void serializeAlg(string[,] alg, string filepath)
        {
            if (alg != null)
            {
                StreamWriter sw = new StreamWriter(filepath);
                string line = "";
                for(int i=0; i< alg.GetLength(1); i++)
                {
                    line += "Q" + (i + 1) + "; ";
                }
                sw.WriteLine(line);
                line = "";
                for(int i=0; i < alg.GetLength(0); i++)
                {
                    for(int j=0; j < alg.GetLength(1); j++)
                    {
                        line += alg[i, j];
                    }
                    sw.WriteLine(line);
                    line = "";
                }
                sw.Close();
            }
        }

        public static void serializeTrace(string trace, string filepath)
        {
            if (trace != null)
            {
                StreamWriter sw = new StreamWriter(filepath);
                sw.Write(trace);
                sw.Close();
            }
        }
        public static string deserializeTrace(string filepath)
        {
            if (filepath != null)
            {
                StreamReader sr = new StreamReader(filepath);
                string trace = sr.ReadToEnd();
                sr.Close();
                return trace;
            }
            return null;
        }

        public static bool CheckAlg(string currentCell, int columnNumber)
        {
            
            char newsymbol = currentCell.IndexOf('_') != -1 ? '_' : currentCell.IndexOf('*') != -1 ? '*' :
               currentCell.IndexOf(',') != -1 ? ',' :
                   currentCell.IndexOf('#') != -1 ? '#' :                                                //try to find symbol from alphabet
                       currentCell.IndexOf('$') != -1 ? '$' : '-';
            if (newsymbol.Equals('-'))
            {
                MessageBox.Show("Не найден символ замены в строке!\nДоступые символы '_' '*' ',' '$' '%'");
                return false;
            }
            else
            {
                string move = currentCell.IndexOf("rt") != -1 ? "rt" : currentCell.IndexOf("lt") != -1 ? "lt" : // try to find move
                               currentCell.IndexOf("st") != -1 ? "st" : "rip";
                if (move.Equals("rip"))
                {
                    MessageBox.Show("Не найдена команда движения курсора!\nДоступные команды: 'st' 'lt' 'rt'");
                    return false;
                }
                else
                {
                    string take = "";
                    for (int i = currentCell.IndexOf(move) + 2; i < currentCell.Length; i++)
                    {
                        if (Char.IsDigit(currentCell[i]))
                            take += currentCell[i];
                    }
                    try
                    {
                        int zxc = Convert.ToInt32(take);
                        if (zxc - 1 > columnNumber)
                        {
                            MessageBox.Show("Переход в состояние для которого нет столбца!");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не найден переход в иное состояние!");
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
