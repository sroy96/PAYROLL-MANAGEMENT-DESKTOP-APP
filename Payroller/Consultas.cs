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
    public partial class Consultas : Form
    {
        public Consultas()
        {
            InitializeComponent();
        }

        private void Consultas_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'payrollerDataSet.Nominas' table. You can move, or remove it, as needed.
            this.nominasTableAdapter.Fill(this.payrollerDataSet.Nominas);
            // TODO: This line of code loads data into the 'payrollerDataSet.Nominas' table. You can move, or remove it, as needed.
            this.nominasTableAdapter.Fill(this.payrollerDataSet.Nominas);

        }

        //Consultar con la tabla Nominas.
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            PayrollerDataSet dataset = new PayrollerDataSet();
            dataset.BeginInit();
            PayrollerDataSetTableAdapters.NominasTableAdapter filtrofecha = new PayrollerDataSetTableAdapters.NominasTableAdapter();
            filtrofecha.datatime(dataset.Nominas, Convert.ToDateTime(desde.Text), Convert.ToDateTime(hasta.Text));
            dgvConsulta.DataSource = dataset.Nominas;
        }
    }
           
            
    }


