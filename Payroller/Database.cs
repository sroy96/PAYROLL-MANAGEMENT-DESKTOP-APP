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
    public partial class Database : Form
    {
        public Database()
        {
            InitializeComponent();
        }

        private void Database_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'payrollerDataSet.Deducciones' table. You can move, or remove it, as needed.
            this.deduccionesTableAdapter.Fill(this.payrollerDataSet.Deducciones);
            // TODO: This line of code loads data into the 'payrollerDataSet.Ingresos' table. You can move, or remove it, as needed.
            this.ingresosTableAdapter.Fill(this.payrollerDataSet.Ingresos);
            // TODO: This line of code loads data into the 'payrollerDataSet.Empleados' table. You can move, or remove it, as needed.
            this.empleadosTableAdapter.Fill(this.payrollerDataSet.Empleados);
            // TODO: This line of code loads data into the 'payrollerDataSet.Deducciones' table. You can move, or remove it, as needed.
            this.deduccionesTableAdapter.Fill(this.payrollerDataSet.Deducciones);
            // TODO: This line of code loads data into the 'payrollerDataSet.Ingresos' table. You can move, or remove it, as needed.
            this.ingresosTableAdapter.Fill(this.payrollerDataSet.Ingresos);


        }
    }
}
