using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !="" && textBox2.Text != ""&& textBox3.Text != ""&& textBox4.Text != "")
            {
                textBox5.Text = "Apellido y Nombre: " + textBox1.Text + " " + textBox4.Text + "\r\n" + "Edad: " + textBox2.Text + "\r\n" + "Direccion: " + textBox3.Text;
                textBox1.BackColor = System.Drawing.SystemColors.Control;
                textBox2.BackColor = System.Drawing.SystemColors.Control;
                textBox3.BackColor = System.Drawing.SystemColors.Control;
                textBox4.BackColor = System.Drawing.SystemColors.Control;
            }
            if (textBox1.Text == "")
            textBox1.BackColor = Color.Red;
           if (textBox2.Text == "")
           textBox2.BackColor = Color.Red;
            if (textBox3.Text == "")
            textBox3.BackColor = Color.Red;
            if (textBox4.Text == "")
            textBox4.BackColor = Color.Red;
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
