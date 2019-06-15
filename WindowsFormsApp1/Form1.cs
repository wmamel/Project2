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
        
        int OperationType = 1;
        //OperationType = 1;
        int a;
        double b;


        public enum Operation
        {
            Mnozenia,
            Dzielenie,
            Potegowanie,
            Odejmowanie
        }
        public double Licz(int a, double b, int OperationType)
        {
            switch (OperationType)
                {
                    case 1: //mnozenie
                       // MessageBox.Show("1");
                        b = a * b;
                        break;
                    case 2: // dzielenie
                       // MessageBox.Show("2");
                        b = a / b;
                        break;
                    case 3:// potegowanie
                       // MessageBox.Show("3");
                        b = Math.Pow(a, b);
                        break;
                    case 4: //odejmowanie
                       // MessageBox.Show("4");
                        b = a - b;
                        break;
                    default:

                        MessageBox.Show("incorrect operation type");
                        break;
                }
            
            return b;
            
            }
        private void replicator(int Ilosc_operacji)
        {
            for (int j = 0; j<Ilosc_operacji; j++)

            {
                b = Licz(a, b, OperationType);
                MessageBox.Show(b.ToString());
            }

        }

 
        private void button1_Click(object sender, EventArgs e)

        {
             a = 2;
             b = 3;
            if (Int32.TryParse(OperationCount.Text, out Ilosc_operacji))
                {
                replicator(Ilosc_operacji);
                //MessageBox.Show(Ilosc_operacji.ToString());
                //Ilosc_operacji = Int32.Parse(OperationCount.Text);
            }
            else
            {
                MessageBox.Show("Podana wartośc nie jest liczbą całkowitą");
            }
            

            //Zadanie(1, 1, Enum.GetNames(typeof(Operation),3), Ilosc_operacji);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            OperationType = 1;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            OperationType = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            OperationType = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            OperationType = 4;
        }

        
    }
    





}
