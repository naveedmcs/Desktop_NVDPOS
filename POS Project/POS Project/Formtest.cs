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

namespace POS_Project
{
    public partial class Formtest : Form
    {
        public Formtest()
        {
            InitializeComponent();
        }

       // public string cs = "Data Source =.\\SQLEXPRESS; Initial Catalog =testDB; Integrated Security = True"; // cs= connection string


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //string value = textBox1.Text;
            //if (value == "")
            //{

            //    ProductsSearch(value = "Jugaar");
            //}
            //else
            //{
            //    ProductsSearch(value);
            //}
        }

        //private void ProductsSearch(string value)
        //{
        //    try
        //    {
        //       string query = "SELECT *FROM Student WHERE(id Like '%" + value + "%' OR student Like '%" + value + "%')  ";
        //        SqlConnection con = new SqlConnection(cs);
        //        con.Open();
        //        SqlDataAdapter sda = new SqlDataAdapter(query, con);
        //        System.Data.DataTable dt = new System.Data.DataTable(); // used for datagrid view
        //        sda.Fill(dt);
        //        dataGridView1.DataSource = dt;
        //        con.Close();



        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        
    }
}
