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
    public partial class Nominas : Form
    {
        static string strCn = "Data Source=(localdb)\\v11.0;AttachDbFilename=Data Source=(localdb)\v11.0;AttachDbFilename=|DataDirectory|\\Payroller.mdf;Integrated Security=True";
        SqlConnection conexao = new SqlConnection(strCn);

        public Nominas()
        {
            InitializeComponent();
        }

        private void Nominas_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'payrollerDataSet.Empleados' table. You can move, or remove it, as needed.
            this.empleadosTableAdapter.Fill(this.payrollerDataSet.Empleados);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string create = "insert into Nominas values ('" + cbxEmpleado.Text + "','" + txtSalario.Text + "','" + txtFecha.Text + "')";

            SqlCommand cmd = new SqlCommand(create, conexao);

            try
            {
                conexao.Open();

                int resultado;
                resultado = cmd.ExecuteNonQuery();

                if (resultado == 1)
                {
                    MessageBox.Show("Registro guardado.");
                    txtSalario.Clear();
                    cbxEmpleado.Focus();
                }

                cmd.Dispose();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string read = "SELECT (SELECT SUM(Monto) FROM Ingresos WHERE Empleado='" + this.cbxEmpleado.Text + "') - (SELECT SUM(Monto) FROM Deducciones WHERE Empleado='" + this.cbxEmpleado.Text + "')";
            SqlCommand cmd = new SqlCommand(read, conexao);
            SqlDataReader DR;

            try
            {
                conexao.Open();
                DR = cmd.ExecuteReader();
                if (DR.Read())
                {
                    txtSalario.Text = DR.GetValue(0).ToString();
                }

                else
                {
                    MessageBox.Show("Registro no encontrado.");
                    txtSalario.Clear();
                    cbxEmpleado.Focus();
                }
                DR.Close();
                cmd.Dispose();
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

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            string delete = "delete from Nominas where Salario= " + txtSalario.Text;
            SqlCommand cmd = new SqlCommand(delete, conexao);

            try
            {
                conexao.Open();
                int resultado;
                if (MessageBox.Show("¿Desea borrar el registro seleccionado?",
                "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    resultado = cmd.ExecuteNonQuery();

                    if (resultado == 1)
                    {
                        txtSalario.Clear();
                        cbxEmpleado.Focus();
                        MessageBox.Show("Registro borrado.");
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
        }
        }

