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
   public partial class ProductCategoryForm : Form
    {
        #region Variables
        public string cs = ConfigurationManager.ConnectionStrings["Connect_DB"].ToString();
            string query;
        int totalProductCategories;
        #endregion
        ComboBox cbox;

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
        public ProductCategoryForm( ComboBox cbox)
        {
            this.cbox = cbox;
            InitializeComponent();
        }

        private void ProductCategoryForm_Load(object sender, EventArgs e)
        {
            DisplayCategories();
        }

        private void btnCategoryAddNew_Click(object sender, EventArgs e)
        {
            txtCategoryID.Text = "";
            txtCategoryName.Text = "";
            txtCategoryComments.Text = "";

            //show Save  button
            btnCategorySave.Visible = true;
            //hide form buttons Advance User access
            btnCategoryDelete.Visible = false;
            btnCategoryUpdate.Visible = false;

            dgvCategories.Rows.Clear();

            DisplayCategories(); // display records in datagrid view
            //set Focus
            txtCategoryName.Focus();
        }

        private void btnCategorySave_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text == "")
            {
                MessageBox.Show("Failure: Category Information Can not be Saved!\nRequired Complete Information", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                try
                {

                    string catgoryName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCategoryName.Text.ToLower());



                    query = "insert into Categories(Name,Comments) values(@name,@comments)";
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", catgoryName);
                    cmd.Parameters.AddWithValue("@comments", txtCategoryComments.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Success: Category Information Has Been Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //empty textBoxes after saving information
                    btnCategoryAddNew_Click(this, null);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }//end else
        }

        private void btnCategoryDelete_Click(object sender, EventArgs e)
        {
            string id = txtCategoryID.Text;

            if (MessageBox.Show("Are you sure want to delet all Products againt this  Catgory   Id : " + id, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                query = " DELETE FROM Products WHERE CategoryID_FK IN(SELECT CategoryID FROM Categories WHERE CategoryID ='" + id + "'); DELETE FROM Categories WHERE CategoryID ='" + id + "'";



                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                //empty textBoxes after delete information
                btnCategoryAddNew_Click(this, null);
               

            }

        }

        private void btnCategoryUpdate_Click(object sender, EventArgs e)
        {

            string id = txtCategoryID.Text; // get id 
            //format text into tilte case
            string categoryName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCategoryName.Text.ToLower());
            if (txtCategoryName.Text == "")
            {
                MessageBox.Show("Cannot Update Because no Information is provided/incomplete: ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                if (MessageBox.Show("Are you sure want to Update this Record of Category Id: " + id, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    query = "update  Categories set Name=@Name, Comments=@comments where CategoryID ='" + id + "'";
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", categoryName);
                    cmd.Parameters.AddWithValue("@comments", txtCategoryComments.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //empty textBoxes after Update information
                    btnCategoryAddNew_Click(this, null);

                }
            }
        }
        //Display Categories
        private void DisplayCategories()
        {
            totalProductCategories = 0;
            try
            {
                query = "select Name, Comments  from Categories";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                System.Data.DataTable dt = new System.Data.DataTable(); // used for datagrid view
                sda.Fill(dt);
                //  dgvSupplier.DataSource = dt;  
                foreach (DataRow item in dt.Rows)
                {
                    int n = dgvCategories.Rows.Add(); //datagridviewName total rows

                    dgvCategories.Rows[n].Height = 30;
                    dgvCategories.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvCategories.Rows[n].Cells[0].Value = item["Name"].ToString();
                    dgvCategories.Rows[n].Cells[1].Value = item["Comments"].ToString();

                    //gridview Formatting zebra color(odd even rows)
                    if (n % 2 == 0)
                    {
                        dgvCategories.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); ;//light gray
                    }
                    else
                    {
                        dgvCategories.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);//white
                    }
                }
                con.Close();
                totalProductCategories = dgvCategories.Rows.Count;
                lblTotalCategories.Text = Convert.ToString(totalProductCategories); //datagridviewName

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //category selected-row cell click
        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                // hide button save
                btnCategorySave.Visible = false;
                //show update and delete button
                btnCategoryDelete.Visible = true;
                btnCategoryUpdate.Visible = true;

                int index = e.RowIndex; // get selected row index
                DataGridViewRow selectedRow = dgvCategories.Rows[index];
                string categoryName = selectedRow.Cells[0].Value.ToString();
                query = "select *from Categories where Name='" + categoryName + "'"; ;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {   //get value from databae and intialize to textboxs
                    txtCategoryID.Text = reader["CategoryID"].ToString();
                    txtCategoryName.Text = reader["Name"].ToString();
                    txtCategoryComments.Text = reader["Comments"].ToString();
                    reader.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CategorySearch(string value)
        {
            totalProductCategories = 0;
            try
            {
                query = "SELECT Name, Comments FROM Categories WHERE Name Like '%" + value + "%' OR Comments Like '%" + value + "%'";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                System.Data.DataTable dt = new System.Data.DataTable(); // used for datagrid view
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dgvCategories.Rows.Add(); //datagridviewName total rows

                    dgvCategories.Rows[n].Height = 30;
                    dgvCategories.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvCategories.Rows[n].Cells[0].Value = item["Name"].ToString();
                    dgvCategories.Rows[n].Cells[1].Value = item["Comments"].ToString();

                    //gridview Formatting zebra color(odd even rows)
                    if (n % 2 == 0)
                    {
                        dgvCategories.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); ;//light gray
                    }
                    else
                    {
                        dgvCategories.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);//white
                    }
                }
                con.Close();
                totalProductCategories = dgvCategories.Rows.Count;
                lblTotalCategories.Text = Convert.ToString(totalProductCategories);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
           
            LoadProductCategoriesComboBox();
             this.Hide();
            
        }

        public void LoadProductCategoriesComboBox()
        {
            string query = "select CategoryID, Name from Categories order by CategoryID desc";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Categories");
            cbox.ValueMember = "CategoryID";
            cbox.DisplayMember = "Name";
            cbox.DataSource = ds.Tables["Categories"];
            con.Close();



        }
        private void txtCategorySearch_TextChanged(object sender, EventArgs e)
        {

            //BindingSource bs = new BindingSource();
            //bs.DataSource = dgvCategories.DataSource;
            //bs.Filter =string.Format("Category Name LIKE '%{0}%'", txtCategorySearch.Text);
            //dgvCategories.DataSource = bs;

            string value = txtCategorySearch.Text;
            if (value == "")
            {
                dgvCategories.Rows.Clear();
                dgvCategories.Refresh();
                DisplayCategories();
            }
            else
            {

                dgvCategories.Rows.Clear();
                dgvCategories.Refresh();
                CategorySearch(value);
            }
        }

        private void btnMinimize_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Z && e.Control)
            {
                
                btnMinimize.PerformClick();
            }
        }
    }
}
