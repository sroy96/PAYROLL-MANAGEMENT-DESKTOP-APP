using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroller
{
    public partial class Login_2 : Form
    {
        public Login_2()
        {
            InitializeComponent();
        }

        private void Login_2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "123")
            {
                Principal_2 p = new Principal_2();
                p.Show();
                this.Hide();
            }

            else if (textBox1.Text == "")
            {
                MessageBox.Show("Introducir contraseña.");
            }

            else
            {
                MessageBox.Show("Contraseña incorrecta.");
            }
        }
    }
    }