using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int Ilosc_operacji = 1;
        int OperationType = new int();

        public enum Operation
        {
            Mnozenia,
            Dzielenie,
            Potegowanie,
            Odejmowanie
        }
        public double Zadanie(int a, int b, Operation Operacja, int Ilosc_operacji)
        {
            return a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zadanie(1, 1, Enum.GetNames(typeof(Operation),3), Ilosc_operacji);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            OperationType = 1;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            OperationType = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            OperationType = 1;
        }
    }
    





}
