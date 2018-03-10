using Microsoft.Reporting.WinForms;
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
using System.Configuration;
namespace POS_Project
    
{
    public partial class PrintForm : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["Connect_DB"].ToString();
        public string CashReturn;
        public string TotalItems;
        public double CashReceived;
        public string CustomerName;
        protected override CreateParams CreateParams // form border shadow function
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        public PrintForm(string totalItems, double cashReceived,string cashReturn, string CustomerName )
        {
            InitializeComponent();
            this.CashReceived = cashReceived;
            this.CashReturn = cashReturn;
            this.TotalItems = totalItems;
            this.CustomerName = CustomerName;
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            ReceiveOrdersForm of = new ReceiveOrdersForm();
            ReportDataSource dsInvoice = new ReportDataSource("dsInvoice", getTable("SP_ReceiptInvoice"));

            ReportDataSource dsInvoiceDetails = new ReportDataSource("dsInvoiceDetails", getTable("SP_ReceiptInvoiceDetails"));
       
           reportViewer.LocalReport.DataSources.Add(dsInvoice);
           reportViewer.LocalReport.DataSources.Add(dsInvoiceDetails);
           ReportParameter[] p = new ReportParameter[9];
           p[0] = new ReportParameter("TotalItems",this.TotalItems);
           p[1] = new ReportParameter("Cash", this.CashReceived.ToString());
           p[2] = new ReportParameter("CashReturn", this.CashReturn);
           p[3] = new ReportParameter("ShopName", Properties.Settings.Default.ShopName);
           p[4] = new ReportParameter("ShopAddress", Properties.Settings.Default.ShopAddress);
           p[5] = new ReportParameter("ShopContact", Properties.Settings.Default.ShopContact);
           p[6] = new ReportParameter("ShopTermsAndConditions", Properties.Settings.Default.ShopTermsAndConditions);
           p[7] = new ReportParameter("ShopMessage", Properties.Settings.Default.ShopMessage);
           p[8] = new ReportParameter("CustomerName", this.CustomerName);

           this.reportViewer.LocalReport.SetParameters(p);
           this.reportViewer.RefreshReport();
        }

        private DataTable getTable(string StoreProcedure)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(StoreProcedure, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            return dt;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            reportViewer.PrintDialog();
        }
    }
}
