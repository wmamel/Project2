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
        
        int numberofoperations = 1;

      
        string operationtype = "multiplication";
        
        double a;
        double b;
        string operationtype_string = "*";
        List<Tuple<double, double>> pairs = new List<Tuple<double, double>>();


        
        public double Calculate(double a, double b, string operationtype) 
        {
            double b1 = 0;
            switch (operationtype)
                {
                    case "multiplication": 

                        b1 = a * b;
                        
                        break;
                    case "division":
                        b1 = Divide(a,b);
                        break;
                             
                    case "exponentiation":


                        b1 = Math.Pow(a, b);
                                     
                        break;
                    case "subtraction": 


                        b1 = a - b;
                        
                        break;
                    default:

                        throw new System.InvalidCastException();
                        
                        break;
                }

            return b1;
            
            }

        private double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new System.DivideByZeroException();
            }
            return a/b;
        }

        private void Replicator(int numberofoperations)
        {
            double current_b; 
            
            for (int j = 0; j<numberofoperations; j++)

            {
                current_b = b;
                try
                {
                    b = Calculate(a, b, operationtype);
                    CombineAndSaveLog(j+1, numberofoperations, operationtype_string, a, current_b, b.ToString());

                }
                catch (DivideByZeroException e) 
                {
                    CombineAndSaveLog(j+1, numberofoperations, operationtype_string, a, current_b, " Divide by zero");
                }
                catch (InvalidCastException e)
                {
                    CombineAndSaveLog(j+1, numberofoperations, operationtype_string, a, current_b, " Incorrect calculation type");
                }
                catch (Exception e)
                {
                    SaveLog("i can't imagine what must happen to show this"); 
                }
                //you are only catching specific types of errors. What if a Null reference error happens?
                // WM:does this solve your comment?
                
               
            }

        }

 
        private void StartBT_Click(object sender, EventArgs e) 

        {
            pairs.Clear(); 
            if (File.Exists(PathTB.Text))
            {
                ReadXML(PathTB.Text);
                if (Int32.TryParse(OperationCountTB.Text, out numberofoperations))
                    {
                    if (pairs.Count > 0)
                    {
                        foreach (var pair in pairs)
                        {
                            a = pair.Item1;
                            b = pair.Item2;
                            Replicator(numberofoperations);
                        }

                    }
                    else
                    {
                        MessageBox.Show("XML doesn;t contain any valid pairs of 'a' and 'b' attributes");
                    }
                }
                else
                {
                    MessageBox.Show(String.Format("This: {0} is not an integer", OperationCountTB.Text)); 
                }
                

            }
            else
            {
                MessageBox.Show(String.Format("File under given path doesn't exist.\r\n{0}", PathTB));
            }




        }

        private void ReadXML(string path)
        {
            string logline ="Wartości w XML: \r\n";
            int count =0;
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
                                            // a exist but not a 'double' type
                                            }
                                        break;
                                        
                                    case "b":
                                        if (Double.TryParse(reader.Value, out valB))
                                        {
                                            bexist =true;
                                        }
                                        else
                                        {
                                            // b exist but not a 'double' type
                                        }
                                        break;
                                    }

                                }
                            if((bexist) & (aexist))// xml element contain a and b and both are 'double' type
                                {
                                count++;

                                pairs.Add(Tuple.Create(valA,valB));
                                logline+=String.Format("{0}: a={1}, b={2}\r\n", count, valA.ToString(), valB.ToString());
                                
                                }
                        
                        }
                        break;
                }
            }
        SaveLog(logline);    
        }


        
        private void CombineAndSaveLog(int operation_no, int numberofoperations, string operationtype_string, double a, double b, string wynik)
            {
                
                //and is missing some formatting
                //WM: What kind of formating?
                string logLine = $"Operacja : " + operation_no.ToString() + "/" + numberofoperations.ToString() +  " | " + a.ToString() + operationtype_string + b.ToString() +" = "+wynik;
                SaveLog(logLine);
   
            }
        private void SaveLog(string message) 
            {
            ErrorLogTB.AppendText(message + "\n");
            using (System.IO.StreamWriter file = 
                new System.IO.StreamWriter(Path.GetDirectoryName(PathTB.Text) + "\\log.txt", true))
                    {
                        file.WriteLine(message);
                    }
            }
         
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            operationtype = "multiplication";
            operationtype_string = "*";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            operationtype = "division";
            operationtype_string = "/";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            operationtype = "exponentiation";
            operationtype_string = "^";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            operationtype = "subtraction";
            operationtype_string = "-";
        }


    }
    





}
