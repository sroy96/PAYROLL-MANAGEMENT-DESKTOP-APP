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
using System.Text.RegularExpressions;

namespace Payroller
{
    public partial class Deducciones : Form
    {
        static string strCn = "Data Source=(localdb)\\v11.0;AttachDbFilename=Data Source=(localdb)\v11.0;AttachDbFilename=|DataDirectory|\\Payroller.mdf;Integrated Security=True";
        SqlConnection conexao = new SqlConnection(strCn);

        public Deducciones()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string create = "insert into Deducciones values ('" + 
               txtNombre.Text + "','" +
               cbxEmpleado.GetItemText(cbxEmpleado.SelectedItem) + "','" +
               cbxDeduccion.GetItemText(cbxDeduccion.SelectedItem) + "','" +
               cbxDependeSalario.GetItemText(cbxDependeSalario.SelectedItem) + "','" +
               cbxEstado.GetItemText(cbxEstado.SelectedItem) + "','" +
               txtFecha.Text + "','" +
               txtMonto.Text + "')";

            SqlCommand cmd = new SqlCommand(create, conexao);

            try
            {
                conexao.Open();

                int resultado;
                resultado = cmd.ExecuteNonQuery();

                if (resultado == 1)
                {
                    MessageBox.Show("Registro guardado.");
                    txtNombre.Clear();
                    cbxEmpleado.SelectedItem = null;
                    cbxDeduccion.SelectedItem = null;
                    cbxDependeSalario.SelectedItem = null;
                    cbxEstado.SelectedItem = null;
                    txtMonto.Clear();
                    txtNombre.Focus();
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
            string read = "select * from Deducciones where Nombre='" + this.txtNombre.Text + "'";
            SqlCommand cmd = new SqlCommand(read, conexao);
            SqlDataReader DR;

            try
            {
                conexao.Open();
                DR = cmd.ExecuteReader();
                if (DR.Read())
                {
                    txtID.Text = DR.GetValue(0).ToString();
                    txtNombre.Text = DR.GetValue(1).ToString();
                    cbxEmpleado.Text = DR.GetValue(2).ToString();
                    cbxDeduccion.Text = DR.GetValue(3).ToString();
                    cbxDependeSalario.Text = DR.GetValue(4).ToString();
                    cbxEstado.Text = DR.GetValue(5).ToString();
                    txtFecha.Text = DR.GetValue(6).ToString();
                    txtMonto.Text = DR.GetValue(7).ToString();
                }
                else
                {
                    MessageBox.Show("Registro no encontrado.");
                    txtNombre.Clear();
                    cbxEmpleado.SelectedItem = null;
                    cbxDeduccion.SelectedItem = null;
                    cbxDependeSalario.SelectedItem = null;
                    cbxEstado.SelectedItem = null;
                    txtMonto.Clear();
                    txtNombre.Focus();
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string update = "update Deducciones set Nombre= '" + txtNombre.Text +
                "', Empleado= '" + cbxEmpleado.GetItemText(cbxEmpleado.SelectedItem) +
                "', Deduccion= '" + cbxDeduccion.GetItemText(cbxDeduccion.SelectedItem) +
                "', DependeSalario= '" + cbxDependeSalario.GetItemText(cbxDependeSalario.SelectedItem) +
                "', Estado= '" + cbxEstado.GetItemText(cbxEstado.SelectedItem) +
                "', Fecha= '" + txtFecha.Text +
                "', Monto= '" + txtMonto.Text +
                "' where ID= " + txtID.Text;

            SqlCommand cmd = new SqlCommand(update, conexao);
            try
            {
                conexao.Open();
                int resultado;
                resultado = cmd.ExecuteNonQuery();

                if (resultado == 1)
                {
                    txtNombre.Clear();
                    cbxEmpleado.SelectedItem = null;
                    cbxDeduccion.SelectedItem = null;
                    cbxDependeSalario.SelectedItem = null;
                    cbxEstado.SelectedItem = null;
                    txtMonto.Clear();
                    txtNombre.Focus();
                    MessageBox.Show("Registro editado.");
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

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            string delete = "delete from Deducciones where ID= " + txtID.Text;
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
                        txtNombre.Clear();
                        cbxEmpleado.SelectedItem = null;
                        cbxDeduccion.SelectedItem = null;
                        cbxDependeSalario.SelectedItem = null;
                        cbxEstado.SelectedItem = null;
                        txtMonto.Clear();
                        txtNombre.Focus();
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

        private void Deducciones_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'payrollerDataSet.Empleados' table. You can move, or remove it, as needed.
            this.empleadosTableAdapter.Fill(this.payrollerDataSet.Empleados);
            // TODO: This line of code loads data into the 'payrollerDataSet.Empleados' table. You can move, or remove it, as needed.
            this.empleadosTableAdapter.Fill(this.payrollerDataSet.Empleados);

        }
    }
}
