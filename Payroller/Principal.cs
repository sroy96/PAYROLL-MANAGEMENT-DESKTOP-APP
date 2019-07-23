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
    public partial class Principal : Form
    {
        public Principal()
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

        private void button5_Click(object sender, EventArgs e)
        {
            Ingresos ingresos = new Ingresos();
            ingresos.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Deducciones deducciones = new Deducciones();
            deducciones.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Reportes reportes = new Reportes();
            reportes.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Riesgos riesgos = new Riesgos();
            riesgos.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Nominas nominas = new Nominas();
            nominas.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to leave Payroller ? ", "Go Out", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'payrollerDataSet.Nominas' table. You can move, or remove it, as needed.
            this.nominasTableAdapter.Fill(this.payrollerDataSet.Nominas);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Consultas consultas = new Consultas();
            consultas.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Login_2 p2 = new Login_2();
            p2.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Database db = new Database();
            db.Show();
        }
    }
}
