using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Project
{
    class MyAutoFunctions
    {
     public int GetValueOfStoreProcedure(string StoreProcedureName, string Connection)
        {
            SqlConnection con = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand(StoreProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            int value =   Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return value;


        }
      
        public string GetStringValueOfStoreProcedure(string StoreProcedureName, string Connection)
        {
           
                SqlConnection con = new SqlConnection(Connection);
                SqlCommand cmd = new SqlCommand(StoreProcedureName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                string value = cmd.ExecuteScalar().ToString();
                con.Close();
                return value;


           
        }

        
        public void InsertRecord(string Query, string Connection)
        {
            try {
                SqlConnection con = new SqlConnection(Connection);
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Message: Customer Information Has Been Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(SqlException ex)
            {
                MessageBox.Show("" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetRecordstoreProcedure(string StoreProcedureName, string Connection)
        {
            SqlConnection con = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand(StoreProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
         


        }
        public void SearchRecords(string StoreProcedureName, string Connection, string InputValue,DataGridView dgv)
        {
            SqlConnection con = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand(StoreProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@value",InputValue);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable(); // used for datagrid view
            sda.Fill(dt);
            dgv.DataSource = dt;
            con.Close();


        }
        public void ViewRecords(string StoreProcedureName, string Connection,  DataGridView dgv)
        {
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            SqlCommand cmd = new SqlCommand(StoreProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable(); // used for datagrid view
            sda.Fill(dt);
            dgv.DataSource = dt;
            con.Close();
        }


       
    }
}
