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
    public partial class Departamentos : Form
    {
        static string strCn = "Data Source=(localdb)\\v11.0;AttachDbFilename=Data Source=(localdb)\v11.0;AttachDbFilename=|DataDirectory|\\Payroller.mdf;Integrated Security=True";
        SqlConnection conexao = new SqlConnection(strCn);

        public Departamentos()
        {
            InitializeComponent();
        }

        private void Departamentos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'payrollerDataSet.Empleados' table. You can move, or remove it, as needed.
            this.empleadosTableAdapter.Fill(this.payrollerDataSet.Empleados);
            // TODO: This line of code loads data into the 'payrollerDataSet.Empleados' table. You can move, or remove it, as needed.
            this.empleadosTableAdapter.Fill(this.payrollerDataSet.Empleados);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Regex val = new Regex(@"[a-zA-ZñÑ\s]{2,50}");

            if (val.IsMatch(txtNombre.Text))
            {
                if (val.IsMatch(txtUbicacionFisica.Text))
                {

                    string create = "insert into Departamentos values ('" +
                    txtNombre.Text + "','" +
                    txtUbicacionFisica.Text + "','" +
                    cbxEmpleado.GetItemText(cbxEmpleado.SelectedItem) + "')";

                    SqlCommand cmd = new SqlCommand(create, conexao);

                    try
                    {
                        conexao.Open();

                        int resultado;
                        resultado = cmd.ExecuteNonQuery();

                        if (resultado == 1)
                        {
                            MessageBox.Show("Registro guardado.");
                            txtID.Clear();
                            txtNombre.Clear();
                            txtUbicacionFisica.Clear();
                            cbxEmpleado.SelectedItem = null;
                            txtID.Focus();
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
                else
                {
                    MessageBox.Show("Sólo puede introducir letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUbicacionFisica.Focus();
                }
            }
            else
            {
                MessageBox.Show("Sólo puede introducir letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string read = "select * from Departamentos where Nombre='" + this.txtNombre.Text + "'";
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
                    txtUbicacionFisica.Text = DR.GetValue(2).ToString();
                    cbxEmpleado.Text = DR.GetValue(3).ToString();
                }
                else
                {
                    MessageBox.Show("Registro no encontrado.");
                    txtID.Clear();
                    txtNombre.Clear();
                    txtUbicacionFisica.Clear();
                    cbxEmpleado.SelectedItem = null;
                    txtID.Focus();
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
            string update = "update Departamentos set Nombre= '" + txtNombre.Text +
                "', Ubicacion= '" + txtUbicacionFisica.Text +
                "', ResponsableArea= '" + cbxEmpleado.GetItemText(cbxEmpleado.SelectedItem) +
                "' where ID= " + txtID.Text;

            SqlCommand cmd = new SqlCommand(update, conexao);
            try
            {
                conexao.Open();
                int resultado;
                resultado = cmd.ExecuteNonQuery();

                if (resultado == 1)
                {
                    txtID.Clear();
                    txtNombre.Clear();
                    txtUbicacionFisica.Clear();
                    cbxEmpleado.SelectedItem = null;
                    txtID.Focus();
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
            {
                string delete = "delete from Departamentos where ID= " + txtID.Text;
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
                            txtID.Clear();
                            txtNombre.Clear();
                            txtUbicacionFisica.Clear();
                            cbxEmpleado.SelectedItem = null;
                            txtID.Focus();
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
}