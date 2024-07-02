using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Diagnostics;
using System.Security;
using System.Windows.Forms;
using Turing.Event;
using Turing.Interface;
using Turing.MVPbase;
using Turing.Properties;

namespace Turing
{
    public partial class View : Form, IView
    {
        private string[,] addtiton = { {"_ rt 1", "_ lt 3", "", "","" },
            { "* rt 1", "* rt 2", " _ st 0", "", ""},
            {"* rt 2","","","","" } };
        private string[,] NOD = {{"_ rt 1", "* rt 3", "_ rt 11", "_ rt 5", "_ rt 5", "_ lt 8", "_ lt 7", "_ lt 8", "_ lt 10", "_ rt 3", "_ st 0"},
                                {"* lt 2", "* lt 2", "_  rt 4", "* rt 4", "_ rt 6", "* lt 7", "* lt 2", "* lt 9", "* lt 9", "* lt 2", "* rt 11" },
                                {"","","","_ rt 5","","","","","","",""} };
        private TraceForm tf;
        private TemporaryRibbon tr;
        private bool flagAuto = true;

        public event EventHandler<FileInitEventArgs> OnFileInitialized;
        public event EventHandler<NewAlgInitEvemtArgs> OnNewAlgInitialized;
        public event EventHandler<FileSaveEventArgs> OnFileSaved;
        public event EventHandler<BaseAlgInitEventArgs> OnBaseAlgInitialized;
        public event EventHandler<ExecuteAlgEventArgs> OnExecuteAlgStart;
        public event EventHandler<ExecuteByStep> onStepClick;
        public event EventHandler<TraceSaveEventArgs> onTraceSave;
        public event EventHandler<TraceInitEventArgs> onTraceInit;
        public View()
        {
            InitializeComponent();
            operatingMideComboBox.SelectedIndex = 0;
            operandsTypeComboBox.SelectedIndex = 0;
            for (int i = 0; i < 20; i++)
            {
                ribbonGridView.Columns.Add("Column1", (i + 1).ToString()); // Создает 20 столбцов
                ribbonGridView.Columns[i].Width = 35; // Ширина столбца 35 пикселей
            }
            ribbonGridView.Rows.Add(1);
            ribbonGridView.AllowUserToAddRows = false;


            for (int i = 1; i <= 10; i++)
            {
                AlgorithGridView.Columns.Add("Column" + i, "Q" + i); //Создает 10 столбцov       
                AlgorithGridView.Columns[i - 1].Width = 60;
            }

            AlgorithGridView.Rows.Add(5);
            AlgorithGridView.Rows[0].HeaderCell.Value = "_";
            AlgorithGridView.Rows[1].HeaderCell.Value = "*";
            AlgorithGridView.Rows[2].HeaderCell.Value = ",";
            AlgorithGridView.Rows[3].HeaderCell.Value = "%";
            AlgorithGridView.Rows[4].HeaderCell.Value = "$";
            AlgorithGridView.AllowUserToAddRows = false;
        }
        public void UpdateAlghoritmGrid(string[,] alg)
        {
            int dgvRows = Convert.ToInt32(AlgorithGridView.Rows.Count);
            AlgorithGridView.Rows.Clear();                                 // Очищение всех значений Agv
            AlgorithGridView.RowCount = dgvRows;
            AlgorithGridView.Rows[0].HeaderCell.Value = "_";
            AlgorithGridView.Rows[1].HeaderCell.Value = "*";
            AlgorithGridView.Rows[2].HeaderCell.Value = ",";
            AlgorithGridView.Rows[3].HeaderCell.Value = "%";
            AlgorithGridView.Rows[4].HeaderCell.Value = "$";

            int algColumns = Convert.ToInt32(alg.GetLength(1));
            int dvgColumns = Convert.ToInt32(AlgorithGridView.Columns.Count);
            if (algColumns > dvgColumns)                                       // Нужно если размер алгоритма больше двг
            {
                for (int i = dvgColumns; i < algColumns; i++)
                {
                    AlgorithGridView.Columns.Add("Columns" + (i + 1), "Q" + (i + 1));
                    AlgorithGridView.Columns[i].Width = 60;
                }
            }
            if (algColumns < dvgColumns)
            {
                for (int i = 0; i < (dvgColumns - algColumns); i++)
                {
                    AlgorithGridView.Columns.RemoveAt(AlgorithGridView.ColumnCount - 1);
                }

            }
            for (int i = 0; i < alg.GetLength(0); i++) //rows                            Заполнение новыми данными
            {
                for (int j = 0; j < alg.GetLength(1); j++) //columns
                {
                    AlgorithGridView[j, i].Value = alg[i, j]; // j i = i j да, это работает так
                }
            }
        }
        private async void выполнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int speed = speedTrackBar.Enabled == true ? speedTrackBar.Value : -1;
            string mide = operatingMideComboBox.SelectedItem.ToString();
            bool trace = traceCheckBox.Checked;

            string[,] alg = new string[AlgorithGridView.RowCount, AlgorithGridView.ColumnCount];

            bool stateZero = false;
            for (int i = 0; i < AlgorithGridView.RowCount; i++) //rows                            
            {
                for (int j = 0; j < AlgorithGridView.ColumnCount; j++) //columns
                {
                    if (AlgorithGridView[j, i].Value != null)
                    {
                        alg[i, j] = AlgorithGridView[j, i].Value.ToString();
                        if (alg[i, j].IndexOf("0") != -1)
                            stateZero = true;
                    }
                    else
                        alg[i, j] = " ";
                }
            }
            if (!stateZero)
                MessageBox.Show("Данный алгоритм не имеет перехода в состояние 0!");
            else
            {
                bool commaCheck = false;
                string ribbon = "";
                string curr = "";
                for (int i = 0; i < ribbonGridView.ColumnCount; i++)
                {
                    if (ribbonGridView[i, 0].Value != null)
                    {
                        ribbon += ribbonGridView[i, 0].Value.ToString();

                        if (ribbonGridView[i, 0].Value.ToString().Contains(','))
                            commaCheck = true;
                    }
                    else
                        ribbon += "_";
                }
                if (commaCheck)
                {
                    switch (mide)
                    {
                        case "Мгновенный результат":
                            OnExecuteAlgStart?.Invoke(this, new ExecuteAlgEventArgs("sad", speed, trace, alg, ribbon));
                            break;
                        case "Пошаговый":
                            stepButton.Visible = true;
                            tr = new TemporaryRibbon(ribbon,0,0,0, trace, alg, "");
                            MessageBox.Show("Данные загружены! \nДля выполнения шагов используйте кнопку 'Шаг'!");
                            break;
                        case "Автоматический":
                            int maxtime = (AlgorithGridView.RowCount * 10 + ribbonGridView.RowCount);
                            tr = new TemporaryRibbon(ribbon, 0, 0, 0, trace, alg, "");
                            int algSpeed = speedTrackBar.Value == 1? 2000: speedTrackBar.Value == 2? 1000 : 500;
                            Stopwatch sw = new Stopwatch();
                            int sec = 0;
                            while (sec < maxtime & flagAuto)
                            {
                                sw.Start();
                                await Task.Delay(algSpeed);
                                onStepClick?.Invoke(this, new ExecuteByStep(tr));
                                sw.Stop();
                                sec = sw.Elapsed.Seconds;
                            }
                            if (sec >= maxtime)
                                MessageBox.Show("Алгоритм завершён из-за истечения времени!" + sec);
                            changeFlagAuto();
                            break;
                    }
                }
                else
                    MessageBox.Show("На ленте нет ',' следовательно число одно, а их должно быть 2!");
            }
        }

        public void updateRibbon(string ribbon)
        {
            if (ribbon.Length > 500)
            {
                MessageBox.Show("Результат больше максимального размера ленты!");

            }
            else
            {
                if (ribbon.Length > ribbonGridView.ColumnCount)
                {
                    for (int i = ribbonGridView.ColumnCount; i < ribbon.Length; i++)
                    {
                        ribbonGridView.Columns.Add("Column1", (i + 1).ToString());
                        ribbonGridView.Columns[i].Width = 35;
                    }
                }
                int currentRows = ribbonGridView.RowCount;
                ribbonGridView.Rows.Clear();
                ribbonGridView.RowCount = currentRows;
                for (int i = 0; i < ribbon.Length; i++)
                {
                    ribbonGridView[i, 0].Value = ribbon[i].ToString();
                }
            }
        }

        private void ribbonLenTextBox_KeyPress(object sender, KeyPressEventArgs e) // Длина ленты, операнды 1 и 2 позвояют вводить только цифры и backspace
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != 8)) e.Handled = true;
            else
                return;
        }


        private void operatingMideComboBox_DropDownClosed(object sender, EventArgs e) // Доступность элементов при разных значениях режима работы
        {
            if (operatingMideComboBox.SelectedItem != null)
                switch (operatingMideComboBox.SelectedItem.ToString())
                {
                    case "Мгновенный результат": // Если мгновенный результат, то ползунок скорости недоступен и шаг не виден
                        stepButton.Visible = false;
                        speedTrackBar.Enabled = false;
                        break;
                    case "Пошаговый": // Если пошаговый то ползунок скорости недоступен и шаг виден
                        speedTrackBar.Enabled = false;
                        break;
                    case "Автоматический":// Если автоматический то ползунок скорости доступен и шаг не виден
                        stepButton.Visible = false;
                        speedTrackBar.Enabled = true;
                        break;
                }
        }

        private void operandsTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) // Доступность элементов при разных значениях задания операндов
        {
            switch (operandsTypeComboBox.SelectedItem.ToString())
            {
                case "На ленте": // Если на ленте, то операнд1 и 2 не видны, а лента становится изменяемой
                    operand1_Label.Visible = false;
                    operand2_Label.Visible = false;
                    operand1_TextBox.Visible = false;
                    operand2_TextBox.Visible = false;
                    ribbonGridView.ReadOnly = false;
                    break;
                case "В числовом виде": // Если в числовом виде, то операнд1 и 2 видны, а лента становится неизменяемой
                    operand1_Label.Visible = true;
                    operand2_Label.Visible = true;
                    operand1_TextBox.Visible = true;
                    operand2_TextBox.Visible = true;
                    ribbonGridView.ReadOnly = true;
                    break;
            }
        }

        private void acceptConfigButton_Click(object sender, EventArgs e)
        {
            if (ribbonLenTextBox.Text == "" || Convert.ToInt32(ribbonLenTextBox.Text) < 20 || Convert.ToInt32(ribbonLenTextBox.Text) > 500)
            {
                MessageBox.Show("Размер ленты должен быть от 20 до 500!");
            }
            else
            {
                int ribLen = Convert.ToInt32(ribbonLenTextBox.Text);
                int op1 = operand1_TextBox.Text == "" ? 0 : Convert.ToInt32(operand1_TextBox.Text);
                int op2 = operand2_TextBox.Text == "" ? 0 : Convert.ToInt32(operand2_TextBox.Text);
                if (ribbonGridView.ColumnCount < ribLen)
                {
                    for (int i = ribbonGridView.ColumnCount; i < ribLen; i++)
                    {
                        ribbonGridView.Columns.Add("Column1", (i + 1).ToString());
                        ribbonGridView.Columns[i].Width = 35;
                    }
                }
                else
                {
                    if (op1 + op2 + 1 > ribLen)
                    {
                        MessageBox.Show("Лента слишком короткая для вывода текущих операндов!");
                        operand1_TextBox.Text = "";
                        operand2_TextBox.Text = "";
                        int currentRows = ribbonGridView.RowCount;
                        ribbonGridView.Rows.Clear();
                        ribbonGridView.RowCount = currentRows;
                    }
                    for (int i = ribbonGridView.ColumnCount; i > ribLen; i--)
                    {
                        ribbonGridView.Columns.RemoveAt(i - 1);
                    }
                }
            }
        }

        private void rightAddButton_Click(object sender, EventArgs e)
        {
            if (AlgorithGridView.ColumnCount <= 19)
            {
                string[,] alg = new string[AlgorithGridView.RowCount, AlgorithGridView.ColumnCount];
                int columnNumber = AlgorithGridView.CurrentCell.ColumnIndex;
                for (int i = 0; i < AlgorithGridView.RowCount; i++) //rows                            Заполнение новыми данными
                {
                    for (int j = 0; j < AlgorithGridView.ColumnCount; j++) //columns
                    {
                        if (AlgorithGridView[j, i].Value != null)
                            alg[i, j] = AlgorithGridView[j, i].Value.ToString();
                        else
                            alg[i, j] = "";
                    }
                }
                alg = reWritealg(alg, columnNumber, 2);
                UpdateAlghoritmGrid(alg);
            }
            else
                MessageBox.Show("Максимальное количество состояний 20!");
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (AlgorithGridView.ColumnCount >= 4)
            {
                string[,] alg = new string[AlgorithGridView.RowCount, AlgorithGridView.ColumnCount];
                int columnNumber = AlgorithGridView.CurrentCell.ColumnIndex;
                for (int i = 0; i < AlgorithGridView.RowCount; i++) //rows                            Заполнение новыми данными
                {
                    for (int j = 0; j < AlgorithGridView.ColumnCount; j++) //columns
                    {
                        if (AlgorithGridView[j, i].Value != null)
                            alg[i, j] = AlgorithGridView[j, i].Value.ToString();
                        else
                            alg[i, j] = "";
                    }
                }
                UpdateAlghoritmGrid(reWritealg(alg, columnNumber, 3));
            }
            else
                MessageBox.Show("Минимальное количество состояний 3!");
        }

        private void operand2_TextBox_KeyPress(object sender, KeyPressEventArgs e) //В операнд 2 можно вводить только цифры и backspace
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
            {
                e.Handled = true;
                ribbonGridView.Rows.Clear();
                int operand2 = Convert.ToInt32(operand2_TextBox.Text);

            }
        }

        private void operand1_TextBox_KeyPress(object sender, KeyPressEventArgs e) //В операнд 1 можно вводить только цифры и backspace
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = getFilePath("alg файлы (*.alg)|*.alg", @"Algs");
            if (filepath != null)
            {
                try
                {
                    OnFileInitialized?.Invoke(this, new FileInitEventArgs(filepath));
                    alghoritmTextBox.Text = filepath.Split('\\').Last();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Не удалось открыть файл!");
                }
            }
            AlgorithGridView.ReadOnly = false;
            LeftAddButton.Enabled = true;
            rightAddButton.Enabled = true;
            deleteButton.Enabled = true;
        }


        private void сложениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnBaseAlgInitialized?.Invoke(this, new BaseAlgInitEventArgs(addtiton));
            alghoritmTextBox.Text = "Addition";
            AlgorithGridView.ReadOnly = true;
            LeftAddButton.Enabled = false;
            rightAddButton.Enabled = false;
            deleteButton.Enabled = false;
        }
        public string getFilePath(string filter, string format)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + format,
                Filter = filter,
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            return null;
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnNewAlgInitialized?.Invoke(this, new NewAlgInitEvemtArgs());
            alghoritmTextBox.Text = "";
            AlgorithGridView.ReadOnly = false;
            LeftAddButton.Enabled = true;
            rightAddButton.Enabled = true;
            deleteButton.Enabled = true;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[,] alg = new string[AlgorithGridView.RowCount, AlgorithGridView.ColumnCount];
            for (int i = 0; i < alg.GetLength(0); i++) //rows                            Заполнение новыми данными
            {
                for (int j = 0; j < alg.GetLength(1); j++) //columns
                {
                    if (AlgorithGridView[j, i].Value != null)
                    {
                        alg[i, j] = AlgorithGridView[j, i].Value.ToString() + ";";
                    }
                    else
                        alg[i, j] = " ;";
                }
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"Algs",
                Filter = "alg файлы (*.alg)|*.alg"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = saveFileDialog.FileName;
                OnFileSaved?.Invoke(this, new FileSaveEventArgs(alg, filepath));
            }
        }

        private void LeftAddButton_Click(object sender, EventArgs e)
        {
            if (AlgorithGridView.ColumnCount <= 19)
            {
                string[,] alg = new string[AlgorithGridView.RowCount, AlgorithGridView.ColumnCount];
                int columnNumber = AlgorithGridView.CurrentCell.ColumnIndex;
                for (int i = 0; i < AlgorithGridView.RowCount; i++) //rows                            Заполнение новыми данными
                {
                    for (int j = 0; j < AlgorithGridView.ColumnCount; j++) //columns
                    {
                        if (AlgorithGridView[j, i].Value != null)
                            alg[i, j] = AlgorithGridView[j, i].Value.ToString();
                        else
                            alg[i, j] = "";
                    }
                }
                alg = reWritealg(alg, columnNumber, 1);
                UpdateAlghoritmGrid(alg);
            }
            else
                MessageBox.Show("Максимальное количество состояний 20!");
        }

        private string[,] reWritealg(string[,] alg, int currentPosition, int action) // action может быть: 1-добавление слева, 2  - добавление справа, 3 -удаление
        {
            string[,] newAlg = new string[5, action < 3 ? alg.GetLength(1) + 1 : alg.GetLength(1) - 1];
            for (int i = 0; i < 5; i++)
            {
                switch (action)
                {
                    case 1:
                        for (int j = 0; j <= currentPosition; j++)
                        {
                            newAlg[i, j] = alg[i, j];
                        }
                        newAlg[i, currentPosition] = "";
                        for (int j = currentPosition; j < alg.GetLength(1); j++)
                        {
                            newAlg[i, j + 1] = alg[i, j];
                        }
                        break;
                    case 2:
                        for (int j = 0; j <= currentPosition; j++)
                        {
                            newAlg[i, j] = alg[i, j];
                        }
                        newAlg[i, currentPosition + 1] = "";
                        for (int j = currentPosition + 1; j < alg.GetLength(1); j++)
                        {
                            newAlg[i, j + 1] = alg[i, j];
                        }
                        break;
                    case 3:
                        for (int j = 0; j < alg.GetLength(1); j++)
                        {
                            if (j < currentPosition)
                            {
                                newAlg[i, j] = alg[i, j];
                            }
                            else if (j > currentPosition)
                            {
                                newAlg[i, j - 1] = alg[i, j];
                            }
                        }
                        break;
                }
            }
            return newAlg;
        }

        private void operand1_TextBox_TextChanged(object sender, EventArgs e)
        {
            ribbonGridView.Rows.Clear();
            ribbonGridView.RowCount = 1;
            int oper1 = 0;
            int oper2 = 0;
            if (operand1_TextBox.Text != "")
            {
                oper1 = Convert.ToInt32(operand1_TextBox.Text);
            }
            if (operand2_TextBox.Text != "")
            {
                oper2 = Convert.ToInt32(operand2_TextBox.Text);
            }
            if (oper1 + oper2 < ribbonGridView.ColumnCount)
            {
                for (int i = 0; i < oper1; i++)
                {

                    ribbonGridView[i, 0].Value = '*';
                }
                if (oper1 > 0)
                    ribbonGridView[oper1, 0].Value = ',';
                if (oper2 > 0)
                    for (int i = oper1 > 0 ? 1 : 0; i < (oper1 > 0 ? oper2 + 1 : oper2); i++)
                    {
                        ribbonGridView[i + oper1, 0].Value = '*';
                    }
            }
            else
            {
                MessageBox.Show("Превышено значение длины ленты!");
                ribbonGridView.Rows.Clear();
                ribbonGridView.RowCount = 1;
            }
        }


        private void ribbonGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (ribbonGridView[e.ColumnIndex, e.RowIndex].Value != null)
            {
                string currentCellValue = ribbonGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (currentCellValue != "*" && currentCellValue != "_" && currentCellValue != "," && currentCellValue != "%" && currentCellValue != "$" && currentCellValue != " ")
                {
                    ribbonGridView[e.ColumnIndex, e.RowIndex].Value = "";
                    MessageBox.Show("В ячейке может быть только '*' ',' '_'  '%' '$' ' '!");
                }
            }
        }
        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            onStepClick?.Invoke(this, new ExecuteByStep(tr));
        }

        private void нОДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnBaseAlgInitialized?.Invoke(this, new BaseAlgInitEventArgs(NOD));
            alghoritmTextBox.Text = "GCD";
            AlgorithGridView.ReadOnly = true;
            LeftAddButton.Enabled = false;
            rightAddButton.Enabled = false;
            deleteButton.Enabled = false;
        }

        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = getFilePath("tr файлы (*.tr)|*.tr", @"Trace");
            if (filepath != null)
            {
                try
                {
                    onTraceInit?.Invoke(this, new TraceInitEventArgs(filepath));
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Не удалось открыть файл!");
                }
            }
        }
        public void openTF(string trace)
        {
            tf = new TraceForm(trace);
            tf.Show();
        }

        private void declineConfigButton_Click(object sender, EventArgs e)
        {
            ribbonLenTextBox.Text = "20";
            traceCheckBox.Checked = false;
            speedTrackBar.Enabled = false;
            operatingMideComboBox.SelectedIndex = 0;
            stepButton.Visible = false;
            operand1_TextBox.Visible = false;
            operand2_TextBox.Visible = false;
            operandsTypeComboBox.SelectedIndex = 0;


            OnNewAlgInitialized?.Invoke(this, new NewAlgInitEvemtArgs());
            alghoritmTextBox.Text = "";
            AlgorithGridView.ReadOnly = false;
            LeftAddButton.Enabled = true;
            rightAddButton.Enabled = true;
            deleteButton.Enabled = true;
        }

        private void сохранениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"Trace",
                Filter = "tr файлы (*.tr)|*.tr"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = saveFileDialog.FileName;
                onTraceSave?.Invoke(this, new TraceSaveEventArgs(filepath, tf.getTrace()));
            }
        }

        private void оРазработчикахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevelopersInfo di = new DevelopersInfo();
            di.Show();
        }

        private void AlgorithGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (AlgorithGridView[e.ColumnIndex, e.RowIndex].Value != null)
            {
                string currentCellValue = AlgorithGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (!FileSystem.CheckAlg(currentCellValue, AlgorithGridView.ColumnCount))
                    AlgorithGridView[e.ColumnIndex, e.RowIndex].Value = "";
            }
        }

        private void оСистемеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"help.html";
            System.Diagnostics.Process.Start(path);
        }

        public void updateTR(TemporaryRibbon newTr)
        {
            tr = newTr;
        }

        public void updateRibbon(string ribbon, int currentposition)
        {
            if (ribbon.Length > 500)
            {
                MessageBox.Show("Результат больше максимального размера ленты!");

            }
            else
            {
                if (ribbon.Length > ribbonGridView.ColumnCount)
                {
                    for (int i = ribbonGridView.ColumnCount; i < ribbon.Length; i++)
                    {
                        ribbonGridView.Columns.Add("Column1", (i + 1).ToString());
                        ribbonGridView.Columns[i].Width = 35;
                    }
                }
                int currentRows = ribbonGridView.RowCount;
                ribbonGridView.Rows.Clear();
                ribbonGridView.RowCount = currentRows;
                for (int i = 0; i < ribbon.Length; i++)
                {
                    ribbonGridView[i, 0].Value = ribbon[i].ToString();
                    ribbonGridView[i, 0].Selected = false;
                }
                ribbonGridView[currentposition, 0].Selected = true;
            }
        }
        public void focusAlg()
        {
            for (int i = 0; i < AlgorithGridView.RowCount; i++) //rows                            
            {
                for (int j = 0; j < AlgorithGridView.ColumnCount; j++) //columns
                {
                    AlgorithGridView[j, i].Selected = false;
                }
            }
            if (tr.algState > -1)
            {
                AlgorithGridView[tr.algState, tr.algRow].Selected = true;
            }
        }

        public void hideStep()
        {
            stepButton.Visible = false;
            AlgorithGridView[0, 0].Selected = true;
        }
        public void changeFlagAuto()
        {
            flagAuto = !flagAuto;
        }
    }
}