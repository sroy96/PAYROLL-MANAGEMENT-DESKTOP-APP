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
    public partial class Puestos : Form
    {
        static string strCn = "Data Source=(localdb)\\v11.0;AttachDbFilename=Data Source=(localdb)\v11.0;AttachDbFilename=|DataDirectory|\\Payroller.mdf;Integrated Security=True";
        SqlConnection conexao = new SqlConnection(strCn);

        public Puestos()
        {
            InitializeComponent();
        }

        private void Puestos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'payrollerDataSet.Riesgos' table. You can move, or remove it, as needed.
            this.riesgosTableAdapter.Fill(this.payrollerDataSet.Riesgos);
            // TODO: This line of code loads data into the 'payrollerDataSet.Riesgos' table. You can move, or remove it, as needed.
            this.riesgosTableAdapter.Fill(this.payrollerDataSet.Riesgos);
            // TODO: This line of code loads data into the 'payrollerDataSet.Riesgos' table. You can move, or remove it, as needed.
            this.riesgosTableAdapter.Fill(this.payrollerDataSet.Riesgos);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Regex val = new Regex(@"[0-9]{1,9}(\.[0-9]{0,2})?$");

            if (val.IsMatch(txtMinimoSalario.Text) && val.IsMatch(txtMaximoSalario.Text))
            {

                if (Convert.ToDecimal(txtMaximoSalario.Text) >= Convert.ToDecimal(txtMinimoSalario.Text) && Convert.ToDouble(txtMaximoSalario.Text) > 0 && Convert.ToDouble(txtMinimoSalario.Text) > 0)
                {

                    string create = "insert into Puestos values ('" +
                    txtNombre.Text + "','" +
                    txtMaximoSalario.Text + "','" +
                    txtMinimoSalario.Text + "','" +
                    cbxNivelRiesgo.GetItemText(cbxNivelRiesgo.SelectedItem) + "')";

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
                            txtMaximoSalario.Clear();
                            txtMinimoSalario.Clear();
                            cbxNivelRiesgo.SelectedItem = null;
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
                    MessageBox.Show("La cantidad introducida es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Introduzca una cantidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMinimoSalario.Focus();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string read = "select * from Puestos where Nombre='" + this.txtNombre.Text + "'";
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
                    txtMaximoSalario.Text = DR.GetValue(2).ToString();
                    txtMinimoSalario.Text = DR.GetValue(3).ToString();
                    cbxNivelRiesgo.Text = DR.GetValue(4).ToString();
                }
                else
                {
                    MessageBox.Show("Registro no encontrado.");
                    txtID.Clear();
                    txtNombre.Clear();
                    txtMaximoSalario.Clear();
                    txtMinimoSalario.Clear();
                    cbxNivelRiesgo.SelectedItem = null;
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
            string update = "update Puestos set Nombre= '" + txtNombre.Text +
                "', MaximoSalario= '" + txtMaximoSalario.Text +
                "', MinimoSalario= '" + txtMinimoSalario.Text +
                "', ID_Riesgos= '" + cbxNivelRiesgo.GetItemText(cbxNivelRiesgo.SelectedItem) +
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
                    txtMaximoSalario.Clear();
                    txtMinimoSalario.Clear();
                    cbxNivelRiesgo.SelectedItem = null;
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
                string delete = "delete from Puestos where ID= " + txtID.Text;
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
                            txtMaximoSalario.Clear();
                            txtMinimoSalario.Clear();
                            cbxNivelRiesgo.SelectedItem = null;
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

        private void txtMaximoSalario_TextChanged_1(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtMaximoSalario.Text, "[^0-9]"))
            {
                MessageBox.Show("Introducir sólo números.");
                txtMaximoSalario.Text.Remove(txtMaximoSalario.Text.Length - 1);
            }
        }

        private void txtMinimoSalario_TextChanged_1(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtMinimoSalario.Text, "[^0-9]"))
            {
                MessageBox.Show("Introducir sólo números.");
                txtMinimoSalario.Text.Remove(txtMinimoSalario.Text.Length - 1);
            }
        }
    }
}