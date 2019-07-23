using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Payroller
{
    public partial class Principal_2 : Form
    {
        static string strCn = "Data Source=(localdb)\\v11.0;AttachDbFilename=Data Source=(localdb)\v11.0;AttachDbFilename=|DataDirectory|\\Payroller.mdf;Integrated Security=True";
        SqlConnection conexao = new SqlConnection(strCn);

        public Principal_2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empleados empleados = new Empleados();
            empleados.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Departamentos departamentos = new Departamentos();
            departamentos.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Puestos puestos = new Puestos();
            puestos.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Riesgos riesgos = new Riesgos();
            riesgos.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas salir de Payroller?", "Salir", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string delete = "TRUNCATE TABLE Deducciones";
            SqlCommand cmd = new SqlCommand(delete, conexao);

            try
            {
                conexao.Open();
                int resultado;
                if (MessageBox.Show("¿Desea borrar los registros?",
                "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    resultado = cmd.ExecuteNonQuery();

                    if (resultado == 1)
                    {
                        MessageBox.Show("Registros borrados.");
                    }
                    cmd.Dispose();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                conexao.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
                try
            {
                string sSQL = "select * from Nominas order by Salario";
                SqlDataAdapter oda = new SqlDataAdapter(sSQL, conexao);
                DataTable oTb = new DataTable();
                oTb.TableName = "Nominas.xml";
                oda.Fill(oTb);
                oTb.WriteXml(@oTb.TableName, true);
                conexao.Close();
                MessageBox.Show("XML generado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al escribir el XML." + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Datos em = new Datos();
            em.Show();
        }
    }
}
