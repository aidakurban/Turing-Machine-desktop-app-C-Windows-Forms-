namespace Turing
{
    partial class View
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AlgorithGridView = new DataGridView();
            menuStrip1 = new MenuStrip();
            алгоритмToolStripMenuItem = new ToolStripMenuItem();
            создатьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            базовыйToolStripMenuItem = new ToolStripMenuItem();
            сложениеToolStripMenuItem = new ToolStripMenuItem();
            нОДToolStripMenuItem = new ToolStripMenuItem();
            загрузитьToolStripMenuItem = new ToolStripMenuItem();
            трассаToolStripMenuItem = new ToolStripMenuItem();
            просмотрToolStripMenuItem = new ToolStripMenuItem();
            сохранениеToolStripMenuItem = new ToolStripMenuItem();
            выполнитьToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            оСистемеToolStripMenuItem = new ToolStripMenuItem();
            оРазработчикахToolStripMenuItem = new ToolStripMenuItem();
            ribbonGridView = new DataGridView();
            groupBox1 = new GroupBox();
            label11 = new Label();
            label1 = new Label();
            deleteButton = new Button();
            rightAddButton = new Button();
            LeftAddButton = new Button();
            ribbonLabel = new Label();
            operand1_Label = new Label();
            operand2_Label = new Label();
            operand1_TextBox = new TextBox();
            operand2_TextBox = new TextBox();
            groupBox2 = new GroupBox();
            declineConfigButton = new Button();
            acceptConfigButton = new Button();
            speedTrackBar = new TrackBar();
            traceCheckBox = new CheckBox();
            alghoritmTextBox = new TextBox();
            operatingMideComboBox = new ComboBox();
            operandsTypeComboBox = new ComboBox();
            ribbonLenTextBox = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            stepButton = new Button();
            ((System.ComponentModel.ISupportInitialize)AlgorithGridView).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ribbonGridView).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)speedTrackBar).BeginInit();
            SuspendLayout();
            // 
            // AlgorithGridView
            // 
            AlgorithGridView.BackgroundColor = SystemColors.Control;
            AlgorithGridView.Location = new Point(23, 58);
            AlgorithGridView.Name = "AlgorithGridView";
            AlgorithGridView.RowHeadersWidth = 50;
            AlgorithGridView.RowTemplate.Height = 25;
            AlgorithGridView.Size = new Size(694, 169);
            AlgorithGridView.TabIndex = 0;
            AlgorithGridView.CellEndEdit += AlgorithGridView_CellEndEdit;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { алгоритмToolStripMenuItem, трассаToolStripMenuItem, выполнитьToolStripMenuItem, справкаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1072, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // алгоритмToolStripMenuItem
            // 
            алгоритмToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { создатьToolStripMenuItem, сохранитьToolStripMenuItem, базовыйToolStripMenuItem, загрузитьToolStripMenuItem });
            алгоритмToolStripMenuItem.Name = "алгоритмToolStripMenuItem";
            алгоритмToolStripMenuItem.Size = new Size(74, 20);
            алгоритмToolStripMenuItem.Text = "Алгоритм";
            // 
            // создатьToolStripMenuItem
            // 
            создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            создатьToolStripMenuItem.Size = new Size(133, 22);
            создатьToolStripMenuItem.Text = "Создать";
            создатьToolStripMenuItem.Click += создатьToolStripMenuItem_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(133, 22);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // базовыйToolStripMenuItem
            // 
            базовыйToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сложениеToolStripMenuItem, нОДToolStripMenuItem });
            базовыйToolStripMenuItem.Name = "базовыйToolStripMenuItem";
            базовыйToolStripMenuItem.Size = new Size(133, 22);
            базовыйToolStripMenuItem.Text = "Базовый";
            // 
            // сложениеToolStripMenuItem
            // 
            сложениеToolStripMenuItem.Name = "сложениеToolStripMenuItem";
            сложениеToolStripMenuItem.Size = new Size(131, 22);
            сложениеToolStripMenuItem.Text = "Сложение";
            сложениеToolStripMenuItem.Click += сложениеToolStripMenuItem_Click;
            // 
            // нОДToolStripMenuItem
            // 
            нОДToolStripMenuItem.Name = "нОДToolStripMenuItem";
            нОДToolStripMenuItem.Size = new Size(131, 22);
            нОДToolStripMenuItem.Text = "НОД";
            нОДToolStripMenuItem.Click += нОДToolStripMenuItem_Click;
            // 
            // загрузитьToolStripMenuItem
            // 
            загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            загрузитьToolStripMenuItem.Size = new Size(133, 22);
            загрузитьToolStripMenuItem.Text = "Загрузить";
            загрузитьToolStripMenuItem.Click += загрузитьToolStripMenuItem_Click;
            // 
            // трассаToolStripMenuItem
            // 
            трассаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { просмотрToolStripMenuItem, сохранениеToolStripMenuItem });
            трассаToolStripMenuItem.Name = "трассаToolStripMenuItem";
            трассаToolStripMenuItem.Size = new Size(56, 20);
            трассаToolStripMenuItem.Text = "Трасса";
            // 
            // просмотрToolStripMenuItem
            // 
            просмотрToolStripMenuItem.Name = "просмотрToolStripMenuItem";
            просмотрToolStripMenuItem.Size = new Size(141, 22);
            просмотрToolStripMenuItem.Text = "Просмотр";
            просмотрToolStripMenuItem.Click += просмотрToolStripMenuItem_Click;
            // 
            // сохранениеToolStripMenuItem
            // 
            сохранениеToolStripMenuItem.Name = "сохранениеToolStripMenuItem";
            сохранениеToolStripMenuItem.Size = new Size(141, 22);
            сохранениеToolStripMenuItem.Text = "Сохранение";
            сохранениеToolStripMenuItem.Click += сохранениеToolStripMenuItem_Click;
            // 
            // выполнитьToolStripMenuItem
            // 
            выполнитьToolStripMenuItem.Name = "выполнитьToolStripMenuItem";
            выполнитьToolStripMenuItem.Size = new Size(81, 20);
            выполнитьToolStripMenuItem.Text = "Выполнить";
            выполнитьToolStripMenuItem.Click += выполнитьToolStripMenuItem_Click;
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { оСистемеToolStripMenuItem, оРазработчикахToolStripMenuItem });
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(65, 20);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // оСистемеToolStripMenuItem
            // 
            оСистемеToolStripMenuItem.Name = "оСистемеToolStripMenuItem";
            оСистемеToolStripMenuItem.Size = new Size(168, 22);
            оСистемеToolStripMenuItem.Text = "О системе";
            оСистемеToolStripMenuItem.Click += оСистемеToolStripMenuItem_Click;
            // 
            // оРазработчикахToolStripMenuItem
            // 
            оРазработчикахToolStripMenuItem.Name = "оРазработчикахToolStripMenuItem";
            оРазработчикахToolStripMenuItem.Size = new Size(168, 22);
            оРазработчикахToolStripMenuItem.Text = "О разработчиках";
            оРазработчикахToolStripMenuItem.Click += оРазработчикахToolStripMenuItem_Click;
            // 
            // ribbonGridView
            // 
            ribbonGridView.AllowUserToDeleteRows = false;
            ribbonGridView.AllowUserToResizeColumns = false;
            ribbonGridView.AllowUserToResizeRows = false;
            ribbonGridView.BackgroundColor = SystemColors.Control;
            ribbonGridView.ColumnHeadersHeight = 20;
            ribbonGridView.Location = new Point(12, 51);
            ribbonGridView.MultiSelect = false;
            ribbonGridView.Name = "ribbonGridView";
            ribbonGridView.RowHeadersWidth = 20;
            ribbonGridView.RowTemplate.Height = 25;
            ribbonGridView.Size = new Size(717, 77);
            ribbonGridView.TabIndex = 2;
            ribbonGridView.CellEndEdit += ribbonGridView_CellEndEdit;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(deleteButton);
            groupBox1.Controls.Add(rightAddButton);
            groupBox1.Controls.Add(LeftAddButton);
            groupBox1.Controls.Add(AlgorithGridView);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 160);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(735, 300);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Алгоритм";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(434, 23);
            label11.Name = "label11";
            label11.Size = new Size(105, 25);
            label11.TabIndex = 8;
            label11.Text = "Состояния";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(23, 23);
            label1.Name = "label1";
            label1.Size = new Size(86, 25);
            label1.TabIndex = 4;
            label1.Text = "Алфавит\r";
            // 
            // deleteButton
            // 
            deleteButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            deleteButton.Location = new Point(594, 233);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(123, 56);
            deleteButton.TabIndex = 3;
            deleteButton.Text = "Удалить состояние";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // rightAddButton
            // 
            rightAddButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            rightAddButton.Location = new Point(210, 233);
            rightAddButton.Name = "rightAddButton";
            rightAddButton.Size = new Size(148, 56);
            rightAddButton.TabIndex = 2;
            rightAddButton.Text = "Добавить состояние справа";
            rightAddButton.UseVisualStyleBackColor = true;
            rightAddButton.Click += rightAddButton_Click;
            // 
            // LeftAddButton
            // 
            LeftAddButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            LeftAddButton.Location = new Point(23, 233);
            LeftAddButton.Name = "LeftAddButton";
            LeftAddButton.Size = new Size(140, 56);
            LeftAddButton.TabIndex = 1;
            LeftAddButton.Text = "Добавить состояние слева";
            LeftAddButton.UseVisualStyleBackColor = true;
            LeftAddButton.Click += LeftAddButton_Click;
            // 
            // ribbonLabel
            // 
            ribbonLabel.AutoSize = true;
            ribbonLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ribbonLabel.Location = new Point(12, 23);
            ribbonLabel.Name = "ribbonLabel";
            ribbonLabel.Size = new Size(64, 25);
            ribbonLabel.TabIndex = 4;
            ribbonLabel.Text = "Лента";
            // 
            // operand1_Label
            // 
            operand1_Label.AutoSize = true;
            operand1_Label.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            operand1_Label.Location = new Point(23, 137);
            operand1_Label.Name = "operand1_Label";
            operand1_Label.Size = new Size(83, 20);
            operand1_Label.TabIndex = 5;
            operand1_Label.Text = "Операнд 1";
            operand1_Label.Visible = false;
            // 
            // operand2_Label
            // 
            operand2_Label.AutoSize = true;
            operand2_Label.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            operand2_Label.Location = new Point(263, 137);
            operand2_Label.Name = "operand2_Label";
            operand2_Label.Size = new Size(83, 20);
            operand2_Label.TabIndex = 6;
            operand2_Label.Text = "Операнд 2";
            operand2_Label.Visible = false;
            // 
            // operand1_TextBox
            // 
            operand1_TextBox.Location = new Point(112, 135);
            operand1_TextBox.Name = "operand1_TextBox";
            operand1_TextBox.Size = new Size(100, 23);
            operand1_TextBox.TabIndex = 7;
            operand1_TextBox.Visible = false;
            operand1_TextBox.Click += operand1_TextBox_TextChanged;
            operand1_TextBox.TextChanged += operand1_TextBox_TextChanged;
            operand1_TextBox.KeyPress += operand1_TextBox_KeyPress;
            // 
            // operand2_TextBox
            // 
            operand2_TextBox.Location = new Point(362, 135);
            operand2_TextBox.Name = "operand2_TextBox";
            operand2_TextBox.Size = new Size(100, 23);
            operand2_TextBox.TabIndex = 8;
            operand2_TextBox.Visible = false;
            operand2_TextBox.TextChanged += operand1_TextBox_TextChanged;
            operand2_TextBox.KeyPress += operand2_TextBox_KeyPress;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(declineConfigButton);
            groupBox2.Controls.Add(acceptConfigButton);
            groupBox2.Controls.Add(speedTrackBar);
            groupBox2.Controls.Add(traceCheckBox);
            groupBox2.Controls.Add(alghoritmTextBox);
            groupBox2.Controls.Add(operatingMideComboBox);
            groupBox2.Controls.Add(operandsTypeComboBox);
            groupBox2.Controls.Add(ribbonLenTextBox);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(748, 51);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(324, 318);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Настройки";
            // 
            // declineConfigButton
            // 
            declineConfigButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            declineConfigButton.Location = new Point(219, 267);
            declineConfigButton.Name = "declineConfigButton";
            declineConfigButton.Size = new Size(81, 34);
            declineConfigButton.TabIndex = 13;
            declineConfigButton.Text = "Сброс";
            declineConfigButton.UseVisualStyleBackColor = true;
            declineConfigButton.Click += declineConfigButton_Click;
            // 
            // acceptConfigButton
            // 
            acceptConfigButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            acceptConfigButton.Location = new Point(26, 267);
            acceptConfigButton.Name = "acceptConfigButton";
            acceptConfigButton.Size = new Size(104, 34);
            acceptConfigButton.TabIndex = 12;
            acceptConfigButton.Text = "Применить";
            acceptConfigButton.UseVisualStyleBackColor = true;
            acceptConfigButton.Click += acceptConfigButton_Click;
            // 
            // speedTrackBar
            // 
            speedTrackBar.Enabled = false;
            speedTrackBar.LargeChange = 1;
            speedTrackBar.Location = new Point(158, 146);
            speedTrackBar.Maximum = 3;
            speedTrackBar.Minimum = 1;
            speedTrackBar.Name = "speedTrackBar";
            speedTrackBar.Size = new Size(125, 45);
            speedTrackBar.TabIndex = 11;
            speedTrackBar.Value = 1;
            // 
            // traceCheckBox
            // 
            traceCheckBox.AutoSize = true;
            traceCheckBox.Location = new Point(158, 238);
            traceCheckBox.Name = "traceCheckBox";
            traceCheckBox.Size = new Size(15, 14);
            traceCheckBox.TabIndex = 10;
            traceCheckBox.UseVisualStyleBackColor = true;
            // 
            // alghoritmTextBox
            // 
            alghoritmTextBox.Location = new Point(158, 75);
            alghoritmTextBox.Name = "alghoritmTextBox";
            alghoritmTextBox.ReadOnly = true;
            alghoritmTextBox.Size = new Size(153, 23);
            alghoritmTextBox.TabIndex = 9;
            // 
            // operatingMideComboBox
            // 
            operatingMideComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            operatingMideComboBox.FormattingEnabled = true;
            operatingMideComboBox.Items.AddRange(new object[] { "Мгновенный результат", "Пошаговый", "Автоматический" });
            operatingMideComboBox.Location = new Point(158, 117);
            operatingMideComboBox.Name = "operatingMideComboBox";
            operatingMideComboBox.Size = new Size(153, 23);
            operatingMideComboBox.TabIndex = 8;
            operatingMideComboBox.DropDownClosed += operatingMideComboBox_DropDownClosed;
            // 
            // operandsTypeComboBox
            // 
            operandsTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            operandsTypeComboBox.FormattingEnabled = true;
            operandsTypeComboBox.Items.AddRange(new object[] { "На ленте", "В числовом виде" });
            operandsTypeComboBox.Location = new Point(190, 193);
            operandsTypeComboBox.Name = "operandsTypeComboBox";
            operandsTypeComboBox.Size = new Size(121, 23);
            operandsTypeComboBox.TabIndex = 7;
            operandsTypeComboBox.SelectedIndexChanged += operandsTypeComboBox_SelectedIndexChanged;
            // 
            // ribbonLenTextBox
            // 
            ribbonLenTextBox.Location = new Point(158, 39);
            ribbonLenTextBox.Name = "ribbonLenTextBox";
            ribbonLenTextBox.Size = new Size(100, 23);
            ribbonLenTextBox.TabIndex = 6;
            ribbonLenTextBox.Text = "20";
            ribbonLenTextBox.KeyPress += ribbonLenTextBox_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(5, 229);
            label8.Name = "label8";
            label8.Size = new Size(71, 25);
            label8.TabIndex = 5;
            label8.Text = "Трасса";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(5, 191);
            label7.Name = "label7";
            label7.Size = new Size(184, 25);
            label7.TabIndex = 4;
            label7.Text = "Задание операндов";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(5, 146);
            label6.Name = "label6";
            label6.Size = new Size(93, 25);
            label6.TabIndex = 3;
            label6.Text = "Скорость";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(5, 117);
            label5.Name = "label5";
            label5.Size = new Size(140, 25);
            label5.TabIndex = 2;
            label5.Text = "Режим работы";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(5, 75);
            label4.Name = "label4";
            label4.Size = new Size(95, 25);
            label4.TabIndex = 1;
            label4.Text = "Алгоритм";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 34);
            label3.Name = "label3";
            label3.Size = new Size(124, 25);
            label3.TabIndex = 0;
            label3.Text = "Длина ленты";
            // 
            // stepButton
            // 
            stepButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            stepButton.Location = new Point(547, 132);
            stepButton.Name = "stepButton";
            stepButton.Size = new Size(127, 30);
            stepButton.TabIndex = 10;
            stepButton.Text = "Шаг";
            stepButton.UseVisualStyleBackColor = true;
            stepButton.Visible = false;
            stepButton.Click += stepButton_Click;
            // 
            // View
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1072, 461);
            Controls.Add(stepButton);
            Controls.Add(groupBox2);
            Controls.Add(operand2_TextBox);
            Controls.Add(operand1_TextBox);
            Controls.Add(operand2_Label);
            Controls.Add(operand1_Label);
            Controls.Add(ribbonLabel);
            Controls.Add(groupBox1);
            Controls.Add(ribbonGridView);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "View";
            Text = "Машина Тьюринга";
            ((System.ComponentModel.ISupportInitialize)AlgorithGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ribbonGridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)speedTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView AlgorithGridView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem алгоритмToolStripMenuItem;
        private ToolStripMenuItem трассаToolStripMenuItem;
        private ToolStripMenuItem выполнитьToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private DataGridView ribbonGridView;
        private GroupBox groupBox1;
        private Button deleteButton;
        private Button rightAddButton;
        private Button LeftAddButton;
        private Label ribbonLabel;
        private Label operand1_Label;
        private Label operand2_Label;
        private TextBox operand1_TextBox;
        private TextBox operand2_TextBox;
        private GroupBox groupBox2;
        private Label label4;
        private Label label3;
        private Label label5;
        private TextBox ribbonLenTextBox;
        private Label label8;
        private Label label7;
        private Label label6;
        private CheckBox traceCheckBox;
        private TextBox alghoritmTextBox;
        private ComboBox operatingMideComboBox;
        private ComboBox operandsTypeComboBox;
        private TrackBar speedTrackBar;
        private Button acceptConfigButton;
        private Button stepButton;
        private ToolStripMenuItem создатьToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem базовыйToolStripMenuItem;
        private ToolStripMenuItem загрузитьToolStripMenuItem;
        private ToolStripMenuItem просмотрToolStripMenuItem;
        private ToolStripMenuItem сохранениеToolStripMenuItem;
        private ToolStripMenuItem оСистемеToolStripMenuItem;
        private ToolStripMenuItem оРазработчикахToolStripMenuItem;
        private Button declineConfigButton;
        private ToolStripMenuItem сложениеToolStripMenuItem;
        private ToolStripMenuItem нОДToolStripMenuItem;
        private Label label11;
        private Label label1;
    }
}