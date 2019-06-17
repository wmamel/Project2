using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;


namespace WindowsFormsApp1
{
    
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //nothing in Polish in your code. Never. Ever. Especially in SDL.
        int Ilosc_operacji = 1;

       //consistency in naming - either Pascal case or camel case, or separating words with underscore.
        int OperationType = 1;
        //OperationType = 1;
        double a;
        double b;
        string OperationType_string = "*";
        List<Tuple<double, double>> pairs = new List<Tuple<double, double>>();


        //again, nothing in Polish
        public double Licz(double a, double b, int OperationType) //again - consistency in casing
        {
            double b1 = 0;
            switch (OperationType)
                {
                    case 1: //mnozenie <-- using numbers and adding comments is risky and error prone (imagine having 30 types of operations) (also, comments in English)
                       // MessageBox.Show("1"); 
                        b1 = a * b;
                        //return (double)b;
                        break;
                    case 2: // dzielenie
                        b1 = Dzielenie(a,b);
                        break;
                             
                    case 3:// potegowanie
                       // MessageBox.Show("3"); //do not leave unused/old code - remove it
                        b1 = Math.Pow(a, b);
                        //return (double)b;                           
                        break;
                    case 4: //odejmowanie
                       // MessageBox.Show("4");
                        b1 = a - b;
                        //return (double)b;
                        break;
                    default:

                        throw new System.InvalidCastException();
                        
                        break;
                }
            //SaveLog(operation_no, Ilosc_operacji)
            return b1;
            
            }

        private double Dzielenie(double a, double b)
        {
            if (b==0)     //use brackets with IFs, loops and others
                throw new System.DivideByZeroException(); //good:)
            return a/b;
        }

        private void replicator(int Ilosc_operacji)
        {
            double current_b; 
            
            for (int j = 0; j<Ilosc_operacji; j++)

            {
                current_b = b;
                try
                {
                    b = Licz(a, b, OperationType);
                    SaveLog(j+1, Ilosc_operacji, OperationType_string, a, current_b, b.ToString());

                }
                catch (DivideByZeroException e) 
                {
                    SaveLog(j+1, Ilosc_operacji, OperationType_string, a, current_b, " dzielenie przez zero");
                }
                catch (InvalidCastException e)
                {
                    SaveLog(j+1, Ilosc_operacji, OperationType_string, a, current_b, " nieprawidłowy typ działania - zhackowałeś UI");
                }
                //you are only catching specific types of errors. What if a Null reference error happens?
                
               // MessageBox.Show(b.ToString());
            }

        }

 
        private void button1_Click(object sender, EventArgs e) //what is button1? it makes sense to add proper name to button (e.g. StartButton) and to method (e.g. StartButton_Click)

        {
            pairs.Clear(); //czyszczenie listy <-- quite unnecessary comment, no need to add such comments
            if (File.Exists(PathTB.Text))
            {
                ReadXML(PathTB.Text);
                if (Int32.TryParse(OperationCountTB.Text, out Ilosc_operacji))
                    {
                  //  replicator(Ilosc_operacji);
                    //MessageBox.Show(Ilosc_operacji.ToString());
                    //Ilosc_operacji = Int32.Parse(OperationCount.Text);
                    if (pairs.Count>0)
                        {
                            foreach (var pair in pairs)
                            {
                                a = pair.Item1;
                                b = pair.Item2;
                                replicator(Ilosc_operacji);
                            }

                        }
                    else //brackets
                        MessageBox.Show("Brak prawidłowych wartosci w XML");
                }
                else
                {
                    MessageBox.Show("Podana wartośc nie jest liczbą całkowitą"); //when saying 'something is wrong', it is good to include the details on what is wrong, and the provided value
                }
                

            }
            else
            {
                MessageBox.Show("podana ścieżka jest nieprawidłowa");//when saying 'something is wrong', it is good to include the details on what is wrong, and the provided value
            }




        }

        private void ReadXML(string path)
        {
            string logline ="Wartości w XML: \r\n";
            int licznik =0;
            Boolean aexist = false;
            Boolean bexist =false;
            double valA = 0;
            double valB = 0;
            XmlTextReader reader = new XmlTextReader (path); //XmlTextReader should be disposed
                //if there are problems with XML, app will crash 
            while (reader.Read()) 
            {
                switch (reader.NodeType) 
                {
                    case XmlNodeType.Element:
                        if(reader.Name=="value")
                        {
                            aexist=false;
                            bexist=false;
                            
                            while (reader.MoveToNextAttribute())
                                {
                                switch (reader.Name)
                                    {
                                    case "a":
                                        if (Double.TryParse(reader.Value, out valA))
                                            {
                                            aexist =true;
                                            }
                                        else
                                            {
                                            // a istnieje ale nie jest 'double"
                                            }
                                        break;
                                        
                                    case "b":
                                        if (Double.TryParse(reader.Value, out valB))
                                        {
                                            bexist =true;
                                        }
                                        else
                                        {
                                            // b istnieje  ale nie jest 'double"
                                        }
                                        break;
                                    }

                                }
                            if((bexist) & (aexist))// dany element ma a i b oraz obydwa pasuja do double
                                {
                                licznik++;

                                pairs.Add(Tuple.Create(valA,valB));
                                logline+=String.Format("{0}: a={1}, b={2}\r\n", licznik, valA.ToString(), valB.ToString());
                                
                                }
                        
                        }
                        break;// if(reader.Name=="value")
                }//switch
            }//while (reader.Read()) 
        SaveLog(logline);    
        }


        //these two logging methods could be improved so they leverage from each other instead of duplicating code
        private void SaveLog(int operation_no, int Ilosc_operacji, string OperationType_string, double a, double b, string wynik)
            {
                //your log box is editable, should be read only...
                //and is missing some formatting
                string logLine = $"Operacja : " + operation_no.ToString() + "/" + Ilosc_operacji.ToString() +  " | " + a.ToString() + OperationType_string + b.ToString() +" = "+wynik;
                ErrorLogTB.AppendText(logLine + "\n");
                using (System.IO.StreamWriter file = 
                new System.IO.StreamWriter(Path.GetDirectoryName(PathTB.Text) + "\\log.txt", true))
                    {
                        file.WriteLine(logLine);
                    }
            }
        private void SaveLog(string a) //do not use single letter variable names
            {
            ErrorLogTB.AppendText(a + "\n");
            using (System.IO.StreamWriter file = 
                new System.IO.StreamWriter(Path.GetDirectoryName(PathTB.Text) + "\\log.txt", true))
                    {
                        file.WriteLine(a);
                    }
            }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            OperationType = 1;
            OperationType_string = "*";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            OperationType = 2;
            OperationType_string = "/";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            OperationType = 3;
            OperationType_string = "^";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            OperationType = 4;
            OperationType_string = "-";
        }

        
    }
    





}
