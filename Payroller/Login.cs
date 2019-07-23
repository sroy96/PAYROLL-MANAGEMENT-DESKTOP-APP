using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AesEncDec;
using System.IO;

namespace Payroller
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


        private void LoginUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginUsuario.Text.Length < 3 || LoginClave.Text.Length < 5)
            {
                MessageBox.Show("Credenciales muy cortos.");
            }
            else
            {
                string dir = LoginUsuario.Text;
                if (!Directory.Exists("data\\" + dir))
                    MessageBox.Show("Not Exist.", dir);
                else
                {
                    var sr = new StreamReader("data\\" + dir + "\\data.ls");

                    string encusr = sr.ReadLine();
                    string encpass = sr.ReadLine();
                    sr.Close();

                    string decusr = AesCryp.Decrypt(encusr);
                    string decpass = AesCryp.Decrypt(encpass);

                    if (decusr == LoginUsuario.Text && decpass == LoginClave.Text)
                    {
                        MessageBox.Show("Welcom to Payroller!", decusr);
                        Principal p = new Principal();
                        p.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Credenciales incorrectos.");
                    }

                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

       

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RegistrarUsuario.Text.Length < 3 || RegistrarClave.Text.Length < 5)
            {
                MessageBox.Show("Password is Too Small.");
            }
            else
            {
                string dir = RegistrarUsuario.Text;
                Directory.CreateDirectory("data\\" + dir);

                var sw = new StreamWriter("data\\" + dir + "\\data.ls");

                string encusr = AesCryp.Encrypt(RegistrarUsuario.Text);
                string encpass = AesCryp.Encrypt(RegistrarClave.Text);

                sw.WriteLine(encusr);
                sw.WriteLine(encpass);
                sw.Close();

                MessageBox.Show("User has been registered successfully", RegistrarUsuario.Text);

            }
        }

        private void RegistrarUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}

                
    

