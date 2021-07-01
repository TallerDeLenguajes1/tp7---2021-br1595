using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tp7
{
    public partial class Form1 : Form
    {
        Calculadora Calcular = new Calculadora();
        LinkedList<string> lista;
        public Form1()
        {
            InitializeComponent();
            //KeyPreview = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Checkeo("*");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Checkeo("/");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Checkeo("-");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Checkeo("+");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Resultado();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Checkeo(".");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void Escribir(string Dato)
        {
            bool Contiene = EsIgual(Dato);

            if ((textBox1.Text.Contains("+") || textBox1.Text.Contains("-") || textBox1.Text.Contains("*") || textBox1.Text.Contains("/")) && Contiene)
            {
                Resultado();
            }
            else
            {
                textBox1.Text += Dato;
            }
        }

        public bool EsIgual(String Dato)
        {
            bool Contiene = false;
            switch (Dato)
            {
                case "+":
                case "*":
                case "/":
                case ".":
                    Contiene = true;
                    break;
                case "-":
                    if (textBox1.Text[0] == '-' && textBox1.Text.Length == 1)
                    {
                        Contiene = false;
                    }
                    else
                    {
                        Contiene = true;
                    }
                    break;
                default:
                    break;
            }

            return Contiene;
        }

        public void Resultado()
        {
            string Auxiliar = textBox1.Text;
            string[] Variable;
            if (textBox1.Text.Length != 0)
            {
                if (textBox1.Text[0] == '-')
                {
                    Variable = textBox1.Text.Split(new Char[] { '+', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
                }
                else
                {
                    Variable = textBox1.Text.Split(new Char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
                }
                if (Variable.GetLength(0) > 1)
                {
                    textBox1.Clear();
                    char Signo = Convert.ToChar(Auxiliar[Variable[0].Length]);

                    Calcular.Numero1 = float.Parse(Variable[0]);
                    Calcular.Numero2 = float.Parse(Variable[1]);


                    switch (Calcular.Operando)
                    {
                        case '+':
                            Calcular.Resultado = Calcular.Suma();
                            textBox1.Text = Convert.ToString(Calcular.Resultado);
                            break;
                        case '-':
                            Calcular.Resultado = Calcular.Resta();
                            textBox1.Text = Convert.ToString(Calcular.Resultado);
                            break;
                        case '*':
                            Calcular.Resultado = Calcular.Multiplicacion();
                            textBox1.Text = Convert.ToString(Calcular.Resultado);
                            break;
                        case '/':
                            if (Calcular.Numero2 != 0)
                            {
                                Calcular.Resultado = Calcular.Division();
                                textBox1.Text = Convert.ToString(Calcular.Resultado);
                            }
                            else
                            {
                                textBox1.Text = "ERROR";
                            }
                            break;
                        default:
                            break;
                    }
                    Calcular.DiaHora = DateTime.Now;
                    CrearEntrada(Convert.ToString(Calcular.Numero1) + Calcular.Operando + Convert.ToString(Calcular.Numero2) + Convert.ToString(Calcular.Resultado) + "-->" + Convert.ToString(Calcular.DiaHora));

                    Calcular = new Calculadora();
                }
                else
                {
                    textBox1.Clear();
                    textBox1.Text += Auxiliar;
                }

            }
        }
        /*
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '1':
                    button7.PerformClick();
                    break;
                case '2':
                    button8.PerformClick();
                    break;
                case '3':
                    button9.PerformClick();
                    break;
                case '4':
                    button4.PerformClick();
                    break;
                case '5':
                    button5.PerformClick();
                    break;
                case '6':
                    button6.PerformClick();
                    break;
                case '7':
                    button1.PerformClick();
                    break;
                case '8':
                    button2.PerformClick();
                    break;
                case '9':
                    button3.PerformClick();
                    break;
                case '0':
                    button10.PerformClick();
                    break;
                case '+':
                    button13.PerformClick();
                    break;
                case '-':
                    button14.PerformClick();
                    break;
                case '/':
                    button16.PerformClick();
                    break;
                case '*':
                    button15.PerformClick();
                    break;
                case '.':
                    button11.PerformClick();
                    break;
                default:
                    break;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                button12.PerformClick();
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Delete))
            {
                button17.PerformClick();
            }
        }*/
        public void Checkeo(String Dato)
        {
            int Auxiliar;
            Calcular.Posicion = textBox1.Text.Length;
            if (Calcular.Posicion - 1 < 1)
            {
                if (Dato == "-")
                {
                    textBox1.Text += Dato;
                }
            }
            else
            {
                Calcular.Operando = Convert.ToChar(Dato);
                Auxiliar = Calcular.Posicion - 1;

                if (EsIgual(Dato) && (
                    (Calcular.Operando == '+' && (textBox1.Text[Auxiliar] == '+' || textBox1.Text[Auxiliar] == '*' || textBox1.Text[Auxiliar] == '/' || textBox1.Text[Auxiliar] == '.' || textBox1.Text[Auxiliar] == '-')) ||
                    (Calcular.Operando == '/' && (textBox1.Text[Auxiliar] == '+' || textBox1.Text[Auxiliar] == '*' || textBox1.Text[Auxiliar] == '/' || textBox1.Text[Auxiliar] == '.' || textBox1.Text[Auxiliar] == '-')) ||
                    (Calcular.Operando == '*' && (textBox1.Text[Auxiliar] == '+' || textBox1.Text[Auxiliar] == '*' || textBox1.Text[Auxiliar] == '/' || textBox1.Text[Auxiliar] == '.' || textBox1.Text[Auxiliar] == '-')) ||
                    (Calcular.Operando == '-' && Calcular.Posicion > 1) && (textBox1.Text[Auxiliar] == '+' || textBox1.Text[Auxiliar] == '*' || textBox1.Text[Auxiliar] == '/' || textBox1.Text[Auxiliar] == '.' || textBox1.Text[Auxiliar] == '-')) ||
                    (Calcular.Operando == '.' && Calcular.Posicion > 1) && (textBox1.Text[Auxiliar] == '+' || textBox1.Text[Auxiliar] == '*' || textBox1.Text[Auxiliar] == '/' || textBox1.Text[Auxiliar] == '.' || textBox1.Text[Auxiliar] == '-'))
                {
                    textBox1.Text.TrimEnd(new Char[] { '+', '-', '*', '/', '.' });
                    textBox1.Text += Dato;
                }
                else
                {
                    Escribir(Dato);
                }
            }
        }

        private void CrearEntrada(string text)
        {
            lista.AddFirst(text);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}



