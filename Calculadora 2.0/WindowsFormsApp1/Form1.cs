using System;
using System.IO;
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
        char signo = '.';
        int resultado = 0, numeroX=0;
        bool bd2 = true;
        bool saveme = true;
        
        private void Suma_Click(object sender, EventArgs e)
        {
            if (bd2==true)
            {
                signo = '+';
                numeroX = int.Parse(VisorCalculadora.Text);
                Operacion(signo, ref resultado, ref numeroX, ref bd2);
                VisorCalculadora.Clear();
                VisorCalculadora.Focus();
                
            }
            else if (bd2==false)
            {
                numeroX = int.Parse(VisorCalculadora.Text);
                Operacion(signo, ref resultado, ref numeroX, ref bd2);
                VisorCalculadora.Clear();
                VisorCalculadora.Focus();
                signo = '+';
            }
 
            
        }
      
        private void Resta_Click(object sender, EventArgs e)
        {
            if (bd2 == true)
            {
                signo = '-';
                numeroX = int.Parse(VisorCalculadora.Text);
                Operacion(signo, ref resultado, ref numeroX,  ref bd2);
                VisorCalculadora.Clear();
                VisorCalculadora.Focus();
                
            }

            else if (bd2 == false)
            {
                numeroX = int.Parse(VisorCalculadora.Text);
                Operacion(signo, ref resultado, ref numeroX, ref bd2);
                VisorCalculadora.Clear();
                VisorCalculadora.Focus();
                signo = '-';
            }
        }

        private void Multiplicacion_Click(object sender, EventArgs e)
        {
            
            if (bd2 == true)
            {
                signo = '*';
                numeroX = int.Parse(VisorCalculadora.Text);
                Operacion(signo, ref resultado, ref numeroX,ref bd2);
                VisorCalculadora.Clear();
                VisorCalculadora.Focus();
            }

            else if (bd2 == false)
            {
                numeroX = int.Parse(VisorCalculadora.Text);
                Operacion(signo, ref resultado, ref numeroX, ref bd2);
                VisorCalculadora.Clear();
                VisorCalculadora.Focus();
                signo = '*';
            }
        }

        void Operacion(char signardo, ref int resultado, ref int numeroX, ref bool bd2)
        {
            if (!bd2)
            {
                if (signo == '+')
                {
                    resultado += numeroX;

                }
                else if (signo == '-')
                {
                    resultado -= numeroX;

                }
                else if (signo == '*')
                {
                    resultado *= numeroX;

                }
                else if (signo == '/')
                {
                    resultado /= numeroX;

                }

            }
            else
            {
                if (signo == '+')
                {
                    resultado += numeroX;
                    bd2 = false;
                }

                else if (signo == '-')
                {
                    resultado -= numeroX;
                    bd2 = false;
                }

                else if (signo == '*')
                {
                    resultado += numeroX;
                    bd2 = false;
                }
                else if (signo == '/')
                {
                    resultado /= numeroX;
                    bd2 = false;
                }
            }
        }

            private void VisiorCalculadora_KeyDown(object sender, KeyEventArgs e)
        {
            VisorCalculadora.ReadOnly = false;
            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 ||
                e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Add || e.KeyCode == Keys.Subtract
                || e.KeyCode == Keys.Multiply || e.KeyCode == Keys.Divide || e.KeyCode == Keys.Enter)
            {
                if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 || e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                {
                    if (saveme == true)
                    {
                        VisorCalculadora.Text = "";
                        VisorCalculadora.SelectionStart = 1;
                        saveme = false;
                    }
                }
                else
                {
                    VisorCalculadora.SelectionStart = 0;
                }
                if (e.KeyCode == Keys.Add)
                {
                    if (bd2 == true)
                    {
                        signo = '+';
                        numeroX = int.Parse(VisorCalculadora.Text);
                        Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        VisorCalculadora.Clear();
                        VisorCalculadora.Focus();
                    }

                    else if (bd2 == false)
                    {
                        numeroX = int.Parse(VisorCalculadora.Text);
                        Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        VisorCalculadora.Clear();
                        VisorCalculadora.Focus();
                        signo = '+';
                    }
                }

                else if (e.KeyCode == Keys.Subtract)
                {
                    if (bd2 == true)
                    {
                        signo = '+';
                        numeroX = int.Parse(VisorCalculadora.Text);
                        Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        VisorCalculadora.Clear();
                        VisorCalculadora.Focus();
                    }

                    else if (bd2 == false)
                    {
                        numeroX = int.Parse(VisorCalculadora.Text);
                        Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        VisorCalculadora.Clear();
                        VisorCalculadora.Focus();
                        signo = '+';
                    }
                }

                else if (e.KeyCode == Keys.Multiply)
                {
                    if (bd2 == true)
                    {
                        signo = '*';
                        numeroX = int.Parse(VisorCalculadora.Text);
                        Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        VisorCalculadora.Clear();
                        VisorCalculadora.Focus();

                    }

                    else if (bd2 == false)
                    {
                        numeroX = int.Parse(VisorCalculadora.Text);
                        Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        VisorCalculadora.Clear();
                        VisorCalculadora.Focus();
                        signo = '*';
                    }
                }
                else if (e.KeyCode == Keys.Divide)
                {
                    if (bd2 == true)
                    {
                        signo = '/';
                        numeroX = int.Parse(VisorCalculadora.Text);
                        Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        VisorCalculadora.Clear();
                        VisorCalculadora.Focus();
                    }

                    else if (bd2 == false)
                    {
                        numeroX = int.Parse(VisorCalculadora.Text);
                        Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        VisorCalculadora.Clear();
                        VisorCalculadora.Focus();
                        signo = '/';
                    }
                }

                else if (e.KeyCode == Keys.Enter)
                {
                    if (signo == '+')
                    {
                        resultado += int.Parse(VisorCalculadora.Text);
                        MessageBox.Show(resultado.ToString());
                    }
                    else if (signo == '-')
                    {
                        resultado -= int.Parse(VisorCalculadora.Text);
                        MessageBox.Show(resultado.ToString());
                    }
                    else if (signo == '*')
                    {
                        resultado *= int.Parse(VisorCalculadora.Text);
                        MessageBox.Show(resultado.ToString());
                    }
                    else if (signo == '/')
                    {
                        resultado /= int.Parse(VisorCalculadora.Text);
                        MessageBox.Show("" + resultado);
                    }
                    else if (signo == '.')
                    {
                        MessageBox.Show(resultado.ToString());
                    }

                    VisorCalculadora.Clear();
                    resultado = 0;
                    VisorCalculadora.Text = "0";
                    VisorCalculadora.Focus();
                    bd2 = true;
                    saveme = true;
                }
                
            }
            else
            {
                e.SuppressKeyPress = true;
                VisorCalculadora.Text = "";
            }

        }
        private void Igual_Click(object sender, EventArgs e)
        {
            if (signo == '+')
            {
                resultado += int.Parse(VisorCalculadora.Text);
                MessageBox.Show("" + resultado);
            }
            else if(signo == '-')
            {
                resultado -= int.Parse(VisorCalculadora.Text);
                MessageBox.Show("" + resultado);
            }

            else if (signo == '*')
            {
                resultado *= int.Parse(VisorCalculadora.Text);
                MessageBox.Show("" + resultado);
            }

            else if (signo == '/')
            {
                resultado /= int.Parse(VisorCalculadora.Text);
                MessageBox.Show("" + resultado);
            }
            VisorCalculadora.Clear();
            resultado = 0;
            VisorCalculadora.Text = "";
            VisorCalculadora.Focus();
            bd2 = true;
        }
        private void ClearBox_Click(object sender, EventArgs e)
        {
            VisorCalculadora.Clear();
            resultado = 0;
            VisorCalculadora.Text = "0";
            bd2 = true;
            saveme = true;
        }
        private void VisorCalculadora_TextChanged(object sender, EventArgs e)
        {
            if (VisorCalculadora.Text=="*")
            {
                VisorCalculadora.Text = "";
            }
            else if (VisorCalculadora.Text == "+")
            {
                VisorCalculadora.Text = "";
            }
            else if (VisorCalculadora.Text == "/")
            {
                VisorCalculadora.Text = "";
            }
        }

        private void Division_Click(object sender, EventArgs e)
        {
            if (bd2 == true)
            {
                signo = '/';
                numeroX = int.Parse(VisorCalculadora.Text);
                Operacion(signo, ref resultado, ref numeroX, ref bd2);
                VisorCalculadora.Clear();
                VisorCalculadora.Focus();
            }

            else if (bd2 == false)
            {
                numeroX = int.Parse(VisorCalculadora.Text);
                Operacion(signo, ref resultado, ref numeroX, ref bd2);
                VisorCalculadora.Clear();
                VisorCalculadora.Focus();
                signo = '/';
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            VisorCalculadora.Focus();
        }


    }
}
