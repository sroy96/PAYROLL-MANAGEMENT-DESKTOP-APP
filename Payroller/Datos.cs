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
    public partial class Datos : Form
    {
        static string strCn = "Data Source=(localdb)\\v11.0;AttachDbFilename=Data Source=(localdb)\v11.0;AttachDbFilename=|DataDirectory|\\Payroller.mdf;Integrated Security=True";
        SqlConnection conexao = new SqlConnection(strCn);

        public Datos()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Regex val = new Regex(@"[a-zA-ZñÑ\s]{2,50}");

            if (val.IsMatch(txtNombre.Text))
            {
                string create = "insert into Datos values ('" +
                txtNombre.Text + "','" +
                txtDescripcion.Text + "')";

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
                        txtDescripcion.Clear();
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
            else
            {
                MessageBox.Show("Sólo puede introducir letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string read = "select * from Datos where Nombre='" + this.txtNombre.Text + "'";
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
                    txtDescripcion.Text = DR.GetValue(2).ToString();
                }
                else
                {
                    MessageBox.Show("Registro no encontrado.");
                    txtNombre.Clear();
                    txtDescripcion.Clear();
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
            string update = "update Datos set Nombre= '" + txtNombre.Text + "', Direccion= '" + txtDescripcion.Text + "' where ID= " + txtID.Text;
            SqlCommand cmd = new SqlCommand(update, conexao);
            try
            {
                conexao.Open();
                int resultado;
                resultado = cmd.ExecuteNonQuery();

                if (resultado == 1)
                {
                    txtNombre.Clear();
                    txtDescripcion.Clear();
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
            {
                string delete = "delete from Datos where ID= " + txtID.Text;
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
                            txtDescripcion.Clear();
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
