using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace POS_Project
{
    public partial class ReorderProductsFrom : Form
    {

        private string cs = ConfigurationManager.ConnectionStrings["Connect_DB"].ToString(); // cs= connection string

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
        public ReorderProductsFrom()
        {
            InitializeComponent();
     
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void DisplayProductsToReorder()
        {

            string query = "SELECT pro.ProductName, pro.Weight, pro.TotalUnits as RemainingUnits, sup.SupplierName, Sup.PhoneNumber " +
                            "FROM Products as pro left outer JOIN Suppliers as sup ON pro.SupplierID_FK=sup.SupplierID where (pro.ReorderLevel>pro.TotalUnits and pro.Active='yes') or (pro.ReorderLevel=0 and pro.TotalUnits=0 and pro.Active='yes'); ";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            System.Data.DataTable dt = new System.Data.DataTable(); // used for datagrid view
            sda.Fill(dt);
            int count = 0;
            foreach (DataRow item in dt.Rows)
            {


                count++;
                int n = dgvReorderProducts.Rows.Add(); //datagridviewName total rows

                // dgvReorderProducts.Rows[n].Height = 25;
                //    dgvReorderProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dgvReorderProducts.Rows[n].Cells[0].Value = count;
                dgvReorderProducts.Rows[n].Cells[1].Value = item["ProductName"].ToString();
                dgvReorderProducts.Rows[n].Cells[2].Value = item["Weight"].ToString();
                dgvReorderProducts.Rows[n].Cells[3].Value = item["RemainingUnits"].ToString();
                dgvReorderProducts.Rows[n].Cells[4].Value = item["SupplierName"].ToString(); // amount format 200.00
                dgvReorderProducts.Rows[n].Cells[5].Value = item["PhoneNumber"].ToString();




                //gridview Formatting zebra color(odd even rows)
                if (n % 2 == 0)
                    dgvReorderProducts.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); //light gray
                else
                    dgvReorderProducts.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);//white
            }
            con.Close();
            lblTotalProducts.Text = Convert.ToString(count);
        }

        private void ReorderProductsForm_Load(object sender, EventArgs e)
        {
            
            DisplayProductsToReorder();
        }

       
    }
}
