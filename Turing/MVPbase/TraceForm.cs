using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turing.MVPbase
{
    public partial class TraceForm : Form
    {
        public TraceForm(string trace)
        {
            InitializeComponent();
            richTextBox1.Text = trace;
        }
        public string getTrace()
        {
            return richTextBox1.Text;
        }
    }
}
