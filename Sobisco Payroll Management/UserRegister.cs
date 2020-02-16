using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;

namespace PayRoy.User
{
    public partial class UserRegister : Form
    {
        public UserRegister()
        {
            InitializeComponent();
          

        }

        private void UserRegister_Load(object sender, EventArgs e)
        {
            if (formMain.checkclick)
            {


                textBoxName.Text = "";
                textBoxbank.Text = "";
                textBoxAcc.Text = "";
                textBoxPFN.Text = "";
                textBoxESIN.Text = "";
                TextBoxPan.Text = "";
                textBoxUnN.Text = "";
                textBoxRegion.Text = "";
                textBoxDesig.Text = "";
                // JoiningBox.Text =Convert.ToDateTime(selectedRow.Cells[10].Value.ToString()).ToString("dd-mm-yyyy");
                textBoxDW.Text = "";
                textBoxPLV.Text = "";
                textBoxLWP.Text = "";
                textBoxPL.Text = "";
                textBoxSL.Text = "";
                textBoxBasic.Text = "";
                textBoxHRA.Text = "";
                textBoxEDU.Text = "";
                textBoxConve.Text = "";
                textBoxMed.Text = "";
                textBoxAllow.Text = "";
                textBoxPF.Text = "";
                textBoxESI.Text = "";
                textBoxITAX.Text = "";
                textBoxLoan.Text = "";
                textBoxPTAX.Text = "";
                textBoxSalaray.Text = "";
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
            if(formMain.boxclick)
            {
                this.ActiveControl = textBoxID;
                string id = formMain.val;


                SqliteDataAccess sql = new SqliteDataAccess();
                List<object> p = sql.userpop(id);
                var heading = ((IDictionary<string, object>)p[0]).Keys.ToArray();
                var details = ((IDictionary<string, object>)p[0]);
                textBoxID.Text = details[heading[0]].ToString();

                textBoxName.Text = details[heading[1]].ToString();
                textBoxbank.Text = details[heading[2]].ToString();
                textBoxAcc.Text = details[heading[3]].ToString();
                textBoxPFN.Text = details[heading[4]].ToString();
                textBoxESIN.Text = details[heading[5]].ToString();
                TextBoxPan.Text = details[heading[6]].ToString();
                textBoxUnN.Text = details[heading[7]].ToString();
                textBoxRegion.Text = details[heading[8]].ToString();
                textBoxDesig.Text = details[heading[9]].ToString();
                JoiningBox.Text = details[heading[10]].ToString();
                textBoxDW.Text = details[heading[11]].ToString();
                textBoxPLV.Text = details[heading[12]].ToString();
                textBoxLWP.Text = details[heading[13]].ToString();
                textBoxPL.Text = details[heading[14]].ToString();
                textBoxSL.Text = details[heading[15]].ToString();
                textBoxBasic.Text = details[heading[16]].ToString();
                textBoxHRA.Text = details[heading[17]].ToString();
                textBoxEDU.Text = details[heading[18]].ToString();
                textBoxConve.Text = details[heading[19]].ToString();
                textBoxMed.Text = details[heading[20]].ToString();
                textBoxAllow.Text = details[heading[21]].ToString();
                textBoxPF.Text = details[heading[22]].ToString();
                textBoxESI.Text = details[heading[23]].ToString();
                textBoxITAX.Text = details[heading[24]].ToString();
                textBoxLoan.Text = details[heading[25]].ToString();
                textBoxPTAX.Text = details[heading[26]].ToString();
                textBoxSalaray.Text = details[heading[27]].ToString();
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
               
            }
        }

        private void ClearData()
        {
            
        }

        private void TextBoxID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(textBoxID.Text.Length > 0)
                {
                    textBoxName.Focus();
                }
                else
                {
                    textBoxID.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxName.Text.Length > 0)
                {
                    textBoxbank.Focus();
                }
                else
                {
                    textBoxName.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxAcc.Text.Length > 0)
                {
                    textBoxPFN.Focus();
                }
                else
                {
                    textBoxAcc.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxPFN.Text.Length > 0)
                {
                  textBoxESIN.Focus();
                }
                else
                {
                    textBoxPFN.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxESIN.Text.Length > 0)
                {
                    TextBoxPan.Focus();
                }
                else
                {
                    textBoxESIN.Focus();
                }
            }


            if (e.KeyCode == Keys.Enter)
            {
                if (TextBoxPan.Text.Length > 0)
                {
                    textBoxDW.Focus();
                }
                else
                {
                    TextBoxPan.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxDW.Text.Length > 0)
                {
                 textBoxBasic.Focus();
                }
                else
                {
                    textBoxDW.Focus();
                }
            }


            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxBasic.Text.Length > 0)
                {
                 textBoxRegion.Focus();
                }
                else
                {
                    textBoxBasic.Focus();
                }
            }


            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxRegion.Text.Length > 0)
                {
                    textBoxDesig.Focus();
                }
                else
                {
                    textBoxRegion.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxDesig.Text.Length > 0)
                {
                    textBoxUnN.Focus();
                }
                else
                {
                    textBoxDesig.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxUnN.Text.Length > 0)
                {
                   textBoxPL.Focus();
                }
                else
                {
                    textBoxUnN.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxPL.Text.Length > 0)
                {
                    textBoxPL.Focus();
                }
                else
                {
                    textBoxPL.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxUnN.Text.Length > 0)
                {
                    textBoxPL.Focus();
                }
                else
                {
                    textBoxUnN.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxPL.Text.Length > 0)
                {
                    textBoxSL.Focus();
                }
                else
                {
                    textBoxPL.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxSL.Text.Length > 0)
                {
                    textBoxPLV.Focus();
                }
                else
                {
                    textBoxSL.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxPLV.Text.Length > 0)
                {
                    textBoxEDU.Focus();
                }
                else
                {
                    textBoxPLV.Focus();
                }
            }



            if (e.KeyCode == Keys.Enter)
            {
                if ( textBoxEDU.Text.Length > 0)
                {
                    textBoxConve.Focus();
                }
                else
                {
                    textBoxEDU.Focus();
                }
            }


            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxConve.Text.Length > 0)
                {
                    textBoxHRA.Focus();
                }
                else
                {
                    textBoxConve.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxHRA.Text.Length > 0)
                {
                   textBoxPF.Focus();
                }
                else
                {
                    textBoxHRA.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxPF.Text.Length > 0)
                {
                    textBoxESI.Focus();
                }
                else
                {
                    textBoxPF.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxESI.Text.Length > 0)
                {
                  textBoxPTAX.Focus();
                }
                else
                {
                    textBoxESI.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxPTAX.Text.Length > 0)
                {
                   textBoxITAX.Focus();
                }
                else
                {
                    textBoxPTAX.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxITAX.Text.Length > 0)
                {
                    textBoxLoan.Focus();
                }
                else
                {
                    textBoxITAX.Focus();
                }
            }


            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxLoan.Text.Length > 0)
                {
              textBoxLWP.Focus();
                }
                else
                {
                    textBoxLoan.Focus();
                }
            }


            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxLWP.Text.Length > 0)
                {
                   textBoxMed.Focus();
                }
                else
                {
                    textBoxLWP.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxMed.Text.Length > 0)
                {
                    textBoxAllow.Focus();
                }
                else
                {
                    textBoxMed.Focus();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxAllow.Text.Length > 0)
                {
                   JoiningBox.Focus();
                }
                else
                {
                    textBoxAllow.Focus();
                }
            }
        }


        private void TextBoxID_TextChanged(object sender, EventArgs e)
        {

        }

        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(textBoxID.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxID,"Provide Employee Id");

            }
            else if (string.IsNullOrEmpty(textBoxAcc.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxAcc, "Provide Account Number");
            }
            else if (string.IsNullOrEmpty(textBoxName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxName, "Provide Name");
            }
            else if (string.IsNullOrEmpty(TextBoxPan.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(TextBoxPan,"Provide Pan Number");
            }
            else if (string.IsNullOrEmpty(textBoxHRA.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxHRA, "Provide HRA");
            }
            else if (string.IsNullOrEmpty(textBoxRegion.Text))
            { 
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxRegion, "Provide Region");
            }

            else if (string.IsNullOrEmpty(textBoxPFN.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxPFN, "Provide PF Number");
            }
            else if (string.IsNullOrEmpty(textBoxESIN.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxESIN, "Provide PF Number");
            }
            else if (string.IsNullOrEmpty(textBoxPFN.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxPFN, "Provide PF Number");
            }
            else if (string.IsNullOrEmpty(textBoxDW.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxDW, "Provide DW Number");
            }
            else if (string.IsNullOrEmpty(textBoxBasic.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxBasic, "Provide PF Number");
            }
            else if (string.IsNullOrEmpty(textBoxDesig.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxDesig, "Provide PF Number");
            }

            else if (string.IsNullOrEmpty(textBoxUnN.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxUnN, "Provide PF Number");
            }
            else if (string.IsNullOrEmpty(textBoxPL.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxPL, "Provide Primary Leave");
            }
            else if (string.IsNullOrEmpty(textBoxSL.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxSL, "Provide sick Leave");
            }
            else if (string.IsNullOrEmpty(textBoxPLV.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxPLV, "Provide PLV");
            }
            else if (string.IsNullOrEmpty(textBoxEDU.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxEDU, "Provide Education allowance");
            }
            else if (string.IsNullOrEmpty(textBoxConve.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxConve, "Provide Conveyance Allowance");
            }
            else if (string.IsNullOrEmpty(textBoxHRA.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxHRA, "Provide HRA");
            }
            else if (string.IsNullOrEmpty(textBoxPF.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxPF, "Provide PF");
            }
            else if (string.IsNullOrEmpty(textBoxESI.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxESI, "Provide ESI");
            }
            else if (string.IsNullOrEmpty(textBoxPTAX.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxPTAX, "Provide PTAX");
            }
            else if (string.IsNullOrEmpty(textBoxITAX.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxITAX, "Provide Income Tax");
            }
            else if (string.IsNullOrEmpty(textBoxLoan.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxLoan, "Provide Loan Amount");
            }
            else if (string.IsNullOrEmpty(textBoxLWP.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxLWP, "Provide LWP");
            }
            else if (string.IsNullOrEmpty(textBoxMed.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxMed, "Provide Medical Allowance");
            }
            else if (string.IsNullOrEmpty(textBoxAllow.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxAllow, "Provide Special Allowance");
            }
            else if (string.IsNullOrEmpty(JoiningBox.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(JoiningBox, "Provide Joining Date");
            }
            else
            {
                errorProvider1.Clear();
                result = true;

            }
            return result;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            SqliteDataAccess val =new SqliteDataAccess();
            if (Validation())
            {
                Console.WriteLine("Validated");
                if (!val.check(textBoxID.Text))
                {
                    SqliteDataAccess sql = new SqliteDataAccess();
                    string id = textBoxID.Text;
                    string name = textBoxName.Text;
                    string bank = textBoxbank.Text;
                    string acc = textBoxAcc.Text;
                    string pfn = textBoxPFN.Text;

                    string esin = (textBoxESIN.Text);
                    string pan = TextBoxPan.Text;
                    string unn = (textBoxUnN.Text);
                    string region = textBoxRegion.Text;
                    string desig = textBoxDesig.Text;
                    string joining = JoiningBox.Text;
                    int dw = Convert.ToInt32(textBoxDW.Text);
                    int plv = Convert.ToInt32(textBoxPLV.Text);
                    int lwp = Convert.ToInt32(textBoxLWP.Text);
                    int pl = Convert.ToInt32(textBoxPL.Text);
                    int sl = Convert.ToInt32(textBoxSL.Text);
                    double basic = Convert.ToDouble(textBoxBasic.Text);
                    double hra = Convert.ToDouble(textBoxHRA.Text);
                    double edu = Convert.ToDouble(textBoxEDU.Text);
                    double conve = Convert.ToDouble(textBoxConve.Text);
                    double med = Convert.ToDouble(textBoxMed.Text);
                    double allw = Convert.ToDouble(textBoxAllow.Text);
                    double pf = Convert.ToDouble(textBoxPF.Text);
                    double esi = Convert.ToDouble(textBoxESI.Text);
                    double itax = Convert.ToDouble(textBoxITAX.Text);
                    double loan = Convert.ToDouble(textBoxLoan.Text);
                    double ptax = Convert.ToDouble(textBoxPTAX.Text);

                    sql.addbtn(id, name, bank, acc, pfn, esin, pan, unn, region, desig, joining, dw, plv, lwp, pl, sl, basic, hra, edu, conve, med, allw, pf, esi, itax, loan, ptax);
                    MessageBox.Show("Record Saved Successfully", MessageBoxIcon.Information.ToString());
                    //reloadData(id, name, bank, acc, pfn, esin, pan, unn, region, desig, joining, dw, plv, lwp, pl, sl, basic, hra, edu, conve, med, allw, pf, esi, itax, loan, ptax,SqliteDataAccess.vall);    
                    formMain f = new formMain();
                    f.loaddatas();
                }
                else
                {
                    MessageBox.Show("Employee Id Already Exists");
                }
                
            }
        }

        private void reloadData(string id, string name, string bank, string acc, string pfn, string esin, string pan, string unn, string region, string desig, 
            string joining, int dw, int plv, int lwp, int pl, int sl, double basic, double hra, double edu, double conve, double med, double allw, double pf, double esi,
            double itax, double loan, double ptax, double salary)
        {
            textBoxID.Text = id;
            textBoxName.Text = name;
            textBoxbank.Text = bank;
            textBoxAcc.Text = acc;
            textBoxPFN.Text = pfn;
            textBoxESIN.Text = esin;
            TextBoxPan.Text = pan;
            textBoxUnN.Text = unn;
            textBoxRegion.Text = region;
            textBoxDesig.Text = desig;
        
            textBoxDW.Text = dw.ToString();
            textBoxPLV.Text = plv.ToString();
            textBoxLWP.Text = lwp.ToString();
            textBoxPL.Text = pl.ToString();
            textBoxSL.Text = sl.ToString();
            textBoxBasic.Text = basic.ToString();
            textBoxHRA.Text = hra.ToString();
            textBoxEDU.Text = edu.ToString();
            textBoxConve.Text = conve.ToString();
            textBoxMed.Text = med.ToString();
            textBoxAllow.Text = allw.ToString();
            textBoxPF.Text = pf.ToString();
            textBoxESI.Text = esi.ToString();
            textBoxITAX.Text = itax.ToString();
            textBoxLoan.Text = loan.ToString();
            textBoxPTAX.Text = ptax.ToString();
            textBoxSalaray.Text = salary.ToString();
            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }
        public static bool updateclick = false;
        public bool IsClosed { get; private set; }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqliteDataAccess sql = new SqliteDataAccess();
            string id = textBoxID.Text;
            string name = textBoxName.Text;
            string bank = textBoxbank.Text;
            string acc = textBoxAcc.Text;
            string pfn = (textBoxPFN.Text);
            string esin = (textBoxESIN.Text);
            string pan = TextBoxPan.Text;
            string unn = (textBoxUnN.Text);
            string region = textBoxRegion.Text;
            string desig = textBoxDesig.Text;
            string joining = JoiningBox.Text;
            int dw = Convert.ToInt32(textBoxDW.Text);
            int plv = Convert.ToInt32(textBoxPLV.Text);
            int lwp = Convert.ToInt32(textBoxLWP.Text);
            int pl = Convert.ToInt32(textBoxPL.Text);
            int sl = Convert.ToInt32(textBoxSL.Text);
            double basic = Convert.ToDouble(textBoxBasic.Text);
            double hra = Convert.ToDouble(textBoxHRA.Text);
            double edu = Convert.ToDouble(textBoxEDU.Text);
            double conve = Convert.ToDouble(textBoxConve.Text);
            double med = Convert.ToDouble(textBoxMed.Text);
            double allw = Convert.ToDouble(textBoxAllow.Text);
            double pf = Convert.ToDouble(textBoxPF.Text);
            double esi = Convert.ToDouble(textBoxESI.Text);
            double  itax = Convert.ToDouble(textBoxITAX.Text);
            double loan = Convert.ToDouble(textBoxLoan.Text);
            double ptax = Convert.ToDouble(textBoxPTAX.Text);
            double esal = (basic + hra + conve + edu + med + allw) - (pf + esi + ptax + itax + (loan / 10));
            sql.updatebtn(id, name, bank, acc, pfn, esin, pan, unn, region, desig, joining, dw, plv, lwp, pl, sl, basic, hra, edu, conve, med, allw, pf, esi, itax, loan, ptax);
            MessageBox.Show("Record Updated Successfully", MessageBoxIcon.Information.ToString());
            reloadData(id, name, bank, acc, pfn, esin, pan, unn, region, desig, joining, dw, plv, lwp, pl, sl, basic, hra, edu, conve, med, allw, pf, esi, itax, loan, ptax, esal);
            updateclick = true;
            formMain f = new formMain();
            f.loaddatas();

        }

       

        public static string LoadConnnection(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            
        }

       
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqliteDataAccess s = new SqliteDataAccess();
            string eid = textBoxID.Text;
            s.deletebtn(eid);
            ClearData();
           
            MessageBox.Show("Deleted Successfully", MessageBoxIcon.Information.ToString());
        }

        private void Dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }


    

        private void PrintBtn_Click(object sender, EventArgs e)

        {
            string id = textBoxID.Text;
            string name = textBoxName.Text;
            string bank = textBoxbank.Text;
            string acc = textBoxAcc.Text;
            string pfn = (textBoxPFN.Text);
            string esin = (textBoxESIN.Text);
            string pan = TextBoxPan.Text;
            string unn = (textBoxUnN.Text);
            string region = textBoxRegion.Text;
            string desig = textBoxDesig.Text;
            string joining = JoiningBox.Text;
            string dw = (textBoxDW.Text);
            string plv = (textBoxPLV.Text);
            string lwp = (textBoxLWP.Text);
            string pl = (textBoxPL.Text);
            string sl = (textBoxSL.Text);
            string basic = (textBoxBasic.Text);
            string hra = (textBoxHRA.Text);
            string edu = (textBoxEDU.Text);
            string conve = (textBoxConve.Text);
            string med = (textBoxMed.Text);
            string allw = (textBoxAllow.Text);
            string pf = (textBoxPF.Text);
            string esi = (textBoxESI.Text);
            string itax = (textBoxITAX.Text);
            string loan = (textBoxLoan.Text);
            string ptax = (textBoxPTAX.Text);
            string esal = textBoxSalaray.Text;
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("./Slips/"+id+ DateTime.Now.ToString("dd-mm-yyyy") + ".pdf", FileMode.Create));
            doc.Open();
            string imageURL = "./download.png";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
            jpg.ScaleToFit(140f, 120f);
            jpg.Alignment = Element.ALIGN_LEFT;
            doc.Add(jpg);
            Paragraph para = new Paragraph("PAYROLL FOR THE MONTH OF -"+ String.Format("{0:MMMM}", DateTime.Now) 
                                            + " " + DateTime.Now.Year + "\n");
            doc.Add(para);
            Paragraph para1 = new Paragraph( "\n\n"); 
            doc.Add(para1);

            PdfPTable employeeTable = new PdfPTable(4);
            PdfPTable daysTableName = new PdfPTable(3);
            PdfPTable daysTableID = new PdfPTable(2);
            daysTableName.AddCell("DW - " + dw);
            daysTableName.AddCell("PLV - " + plv);
            daysTableName.AddCell("LWP - " + lwp);
            daysTableID.AddCell("PL - "+ pl);
            daysTableID.AddCell("SL- " + sl );
            employeeTable.AddCell("Employee Id");
            employeeTable.AddCell(id);
            employeeTable.AddCell("Region");
            employeeTable.AddCell(region);
            employeeTable.AddCell("Employee Name");
            employeeTable.AddCell(name);
            employeeTable.AddCell("Designation");
            employeeTable.AddCell(desig);
            employeeTable.AddCell("Bank Name");
            employeeTable.AddCell(bank);
            employeeTable.AddCell("Bank Account");
            employeeTable.AddCell(acc);
            employeeTable.AddCell("Joining Data");
            employeeTable.AddCell(joining);
            employeeTable.AddCell("PF Number");
            employeeTable.AddCell(pfn);
            employeeTable.AddCell("Days Details");
            employeeTable.AddCell(daysTableName);
            employeeTable.AddCell("ESI Number");
            employeeTable.AddCell(esin);
            employeeTable.AddCell("Leaves");
            employeeTable.AddCell(daysTableID);
            employeeTable.AddCell("PAN Number");
            employeeTable.AddCell(pan);
            employeeTable.AddCell("PL Details");


            

            Paragraph para2 = new Paragraph("\n\n");
            doc.Add(para2);

            PdfPTable table = new PdfPTable(2);
            PdfPTable internalTableDeduction = new PdfPTable(2);
            PdfPTable internalTableEarnings = new PdfPTable(3);
            PdfPTable totalEarningTable = new PdfPTable(2);
            PdfPTable totalDeductionTable = new PdfPTable(2);
            PdfPTable emptyTable = new PdfPTable(1);
            internalTableEarnings.AddCell("");
            internalTableEarnings.AddCell("Actual");
            internalTableEarnings.AddCell("Computed");
            internalTableEarnings.AddCell("HRA");
            internalTableEarnings.AddCell(hra);
            internalTableEarnings.AddCell(hra);
            internalTableEarnings.AddCell("Basic");
            internalTableEarnings.AddCell(basic);
            internalTableEarnings.AddCell(basic);
            internalTableEarnings.AddCell("Conveyance");
            internalTableEarnings.AddCell(conve);
            internalTableEarnings.AddCell(conve);
            internalTableEarnings.AddCell("Education");
            internalTableEarnings.AddCell(edu);
            internalTableEarnings.AddCell(edu);
            internalTableEarnings.AddCell("Medical");
            internalTableEarnings.AddCell(med);
            internalTableEarnings.AddCell(med);
            internalTableEarnings.AddCell("Special Allowance");
            internalTableEarnings.AddCell(allw);
            internalTableEarnings.AddCell(allw);

            totalEarningTable.AddCell("Total Earning");
            totalEarningTable.AddCell((double.Parse(hra) + double.Parse(allw) + double.Parse(med) + double.Parse(basic)  +
               double.Parse(edu) + double.Parse(conve)).ToString()
                );
            emptyTable.AddCell(" ");
            totalEarningTable.AddCell(emptyTable);

            totalDeductionTable.AddCell("Total Deduction");
            totalDeductionTable.AddCell((double.Parse(pf) + double.Parse(esi) + double.Parse(ptax) +
               double.Parse(itax) + double.Parse(loan)/ 10).ToString());
            totalDeductionTable.AddCell("Total Salary");
            totalDeductionTable.AddCell(textBoxSalaray.Text);

            internalTableDeduction.AddCell("");
            internalTableDeduction.AddCell("Computed");
            internalTableDeduction.AddCell("PF");
            internalTableDeduction.AddCell(pf);
            internalTableDeduction.AddCell("ESI");
            internalTableDeduction.AddCell(esi);
            internalTableDeduction.AddCell("P Tax");
            internalTableDeduction.AddCell(ptax);
            internalTableDeduction.AddCell("Income Tax");
            internalTableDeduction.AddCell(itax);
            internalTableDeduction.AddCell("loan");
            internalTableDeduction.AddCell(loan);
            internalTableDeduction.AddCell("");
            internalTableDeduction.AddCell("");


            table.AddCell("EARNINGS");
            table.AddCell("DEDUCTIONS");

            table.AddCell(internalTableEarnings);
            table.AddCell(internalTableDeduction);
            table.AddCell(totalEarningTable);
            table.AddCell(totalDeductionTable);

            doc.Add(employeeTable);
            doc.Add(new Paragraph("\n\n"));
            doc.Add(table);
            doc.Add(new Paragraph("\n\n"));
        //    doc.Add(new Paragraph("Salary Credited : " + NumberToWords(double.Parse(textBoxSalaray.Text))));
            doc.Close();
            MessageBox.Show("Pdf Created successfully!!");
            


        }


        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
    }
};
