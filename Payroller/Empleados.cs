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
    public partial class Empleados : Form
    {
        static string strCn = "Data Source=(localdb)\\v11.0;AttachDbFilename=Data Source=(localdb)\v11.0;AttachDbFilename=|DataDirectory|\\Payroller.mdf;Integrated Security=True";
        SqlConnection conexao = new SqlConnection(strCn);

        public Empleados()
        {
            InitializeComponent();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'payrollerDataSet.Puestos' table. You can move, or remove it, as needed.
            this.puestosTableAdapter.Fill(this.payrollerDataSet.Puestos);
            // TODO: This line of code loads data into the 'payrollerDataSet.Departamentos' table. You can move, or remove it, as needed.
            this.departamentosTableAdapter.Fill(this.payrollerDataSet.Departamentos);
            // TODO: This line of code loads data into the 'payrollerDataSet.Departamentos' table. You can move, or remove it, as needed.
            this.departamentosTableAdapter.Fill(this.payrollerDataSet.Departamentos);
            // TODO: This line of code loads data into the 'payrollerDataSet.Puestos' table. You can move, or remove it, as needed.
            this.puestosTableAdapter.Fill(this.payrollerDataSet.Puestos);
        }

        public static bool validaCedula(string pCedula)
        {
            Regex sal = new Regex(@"[0-9]{1,9}(\.[0-9]{0,2})?$");

            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return true;
            else
                return false;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Regex val = new Regex(@"[a-zA-ZñÑ\s]{2,50}");
            Regex sal = new Regex(@"[0-9]{1,9}(\.[0-9]{0,2})?$");

            if (val.IsMatch(txtNombre.Text))
            {
                if (validaCedula(txtCedula.Text) == true && sal.IsMatch(txtCedula.Text))
                {


                    if (sal.IsMatch(txtSalarioMensual.Text))
                    {
                        if (Convert.ToDecimal(txtSalarioMensual.Text) > 0)
                        {

                            string create = "insert into Empleados values ('" +
                            txtCedula.Text + "','" +
                            txtNombre.Text + "','" +
                            txtSalarioMensual.Text + "','" +
                            cbxDepartamento.GetItemText(cbxDepartamento.SelectedItem) + "','" +
                            cbxPuesto.GetItemText(cbxPuesto.SelectedItem) + "')";

                            SqlCommand cmd = new SqlCommand(create, conexao);

                            try
                            {
                                conexao.Open();

                                int resultado;
                                resultado = cmd.ExecuteNonQuery();

                                if (resultado == 1)
                                {
                                    MessageBox.Show("Registro guardado.");
                                    txtCedula.Clear();
                                    txtNombre.Clear();
                                    txtSalarioMensual.Clear();
                                    cbxDepartamento.SelectedItem = null;
                                    cbxPuesto.SelectedItem = null;
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
                            MessageBox.Show("Cantidad introducida es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSalarioMensual.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cantidad introducida es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSalarioMensual.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Cédula no existe.");
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

            string read = "select * from Empleados where Nombre='" + this.txtNombre.Text + "'";
            SqlCommand cmd = new SqlCommand(read, conexao);
            SqlDataReader DR;

            try
            {
                conexao.Open();
                DR = cmd.ExecuteReader();
                if (DR.Read())
                {
                    txtID.Text = DR.GetValue(0).ToString();
                    txtCedula.Text = DR.GetValue(1).ToString();
                    txtNombre.Text = DR.GetValue(2).ToString();
                    txtSalarioMensual.Text = DR.GetValue(3).ToString();
                    cbxDepartamento.Text = DR.GetValue(4).ToString();
                    cbxPuesto.Text = DR.GetValue(5).ToString();
                }
                else
                {
                    MessageBox.Show("Registro no encontrado.");
                    txtID.Clear();
                    txtCedula.Clear();
                    txtNombre.Clear();
                    txtSalarioMensual.Clear();
                    cbxDepartamento.SelectedItem = null;
                    cbxPuesto.SelectedItem = null;
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
            string update = "update Empleados set Cedula= '" + txtCedula.Text +
                "', Nombre= '" + txtNombre.Text +
                "', SalarioMensual= '" + txtSalarioMensual.Text +
                "', Departamento= '" + cbxDepartamento.GetItemText(cbxDepartamento.SelectedItem) +
                "', Puesto= '" + cbxPuesto.GetItemText(cbxPuesto.SelectedItem) +
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
                    txtCedula.Clear();
                    txtNombre.Clear();
                    txtSalarioMensual.Clear();
                    cbxDepartamento.SelectedItem = null;
                    cbxPuesto.SelectedItem = null;
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
            string delete = "delete from Empleados where Nombre='" + this.txtNombre.Text + "'";
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
                        txtCedula.Clear();
                        txtNombre.Clear();
                        txtSalarioMensual.Clear();
                        cbxDepartamento.SelectedItem = null;
                        cbxPuesto.SelectedItem = null;
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

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Regex val = new Regex(@"^[A-Za-z]+$");
        }
        }
    }
