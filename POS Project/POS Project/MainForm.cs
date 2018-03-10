using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.Reporting.WinForms;
using System.Configuration;

namespace POS_Project
{
    public partial class MainForm : Form
    {
        #region variables 
        string cs = ConfigurationManager.ConnectionStrings["Connect_DB"].ToString(); // cs= connection string
        string userName = "Defualt";
        string email = string.Empty;
        string password = string.Empty;
        string userStatus = string.Empty;
        private  string query = string.Empty;
        string thisDay = DateTime.Now.ToString("yyyy-MM-dd");
        //string getDateTimeNow = DateTime.Now.ToString(@"dd\/MM\/yyyy h\:mm tt");
        
        //customers
        private string customerName, customerID, customerPhone, customerCity, customerAddress, customerComments, customerTotals;
        //Stock

        private int totalProducts=0;
        //Product Categories

        

        #endregion

        #region MainForm override Function and Cunstructor
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        public MainForm(/*string userStatus,string username*/)
        {
            InitializeComponent();
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            //userName = username;
            //  tsUserName.Text =username;
            // tsUserStatus.Text ="Loggedin As "+userStatus;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
           // TODO: This line of code loads data into the 'POSNayaSaveraDBDataSet.ViewAllStockIn' table. You can move, or remove it, as needed.
            //this.ViewAllStockInTableAdapter.Fill(this.POSNayaSaveraDBDataSet.ViewAllStockIn);
            // TODO: This line of code loads data into the 'POSNayaSaveraDBDataSet.ViewProductsToReorder' table. You can move, or remove it, as needed.
        //    this.ViewProductsToReorderTableAdapter.Fill(this.POSNayaSaveraDBDataSet.ViewProductsToReorder);
            lblHeader.Text = "Welcome To Point Of Sale System ";

           
            LoadProductCategoriesComboBox();
            LoadProductSuppliersComboBox();

            this.RvProductsToReorder.RefreshReport();
        }

        #endregion

        #region ControlBox buttons Minimize and Close 
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You sure to want to close Application", "closeApp", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // The user wants to exit the application. Close everything down.
                System.Windows.Forms.Application.Exit();
            }

        }
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Properties.Resources.darkclosehover;

        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Properties.Resources.darkclosedefualt;
        }


        private void btnMinimize_MouseEnter(object sender, EventArgs e)
        {
            btnMinimize.BackgroundImage = Properties.Resources.darkminimizehover;
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.BackgroundImage = Properties.Resources.darkminimizedefualt;
        }
        #endregion
        #region Supplier Form GotFocus and LostFocus
        private void txtSupplierCompanyName_Enter(object sender, EventArgs e)
        {
            txtSupplierCompanyName.BackColor = Color.LightBlue;
        }


        private void txtSupplierCompanyName_Leave(object sender, EventArgs e)
        {
            txtSupplierCompanyName.BackColor = Color.White;

        }

        private void txtSupplierName_Enter(object sender, EventArgs e)
        {
            txtSupplierName.BackColor = Color.LightBlue;
        }

        private void txtSupplierName_Leave(object sender, EventArgs e)
        {
            txtSupplierName.BackColor = Color.White;
        }

        private void txtSupplierPhone_Enter(object sender, EventArgs e)
        {
            txtSupplierPhone.BackColor = Color.LightBlue;
        }

        private void txtSupplierPhone_Leave(object sender, EventArgs e)
        {
            txtSupplierPhone.BackColor = Color.White;
        }

        private void txtSupplierEmail_Enter(object sender, EventArgs e)
        {
            txtSupplierEmail.BackColor = Color.LightBlue;
        }

        private void txtSupplierEmail_Leave(object sender, EventArgs e)
        {
            txtSupplierEmail.BackColor = Color.White;
        }

      

        private void txtSupplierCity_Leave(object sender, EventArgs e)
        {
            txtSupplierCity.BackColor = Color.White;
        }

        private void txtSupplierCity_Enter(object sender, EventArgs e)
        {
            txtSupplierCity.BackColor = Color.LightBlue;
        }

       

        
        private void txtSupplierAddress_Enter(object sender, EventArgs e)
        {
            txtSupplierAddress.BackColor = Color.LightBlue;
        }

        private void txtSupplierAddress_Leave(object sender, EventArgs e)
        {
            txtSupplierAddress.BackColor = Color.White;
        }

        private void txtSupplierComments_Enter(object sender, EventArgs e)
        {
            txtSupplierComments.BackColor = Color.LightBlue;
        }

        private void txtSupplierComments_Leave(object sender, EventArgs e)
        {
            txtSupplierComments.BackColor = Color.White;
        }
        #endregion
        #region tabControlMDI Actions on Selected tab
        private void tabControlMDI_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlMDI.SelectedIndex)
            {
                case 0:
                    lblHeader.Text = "Welcome to Point Of Sale System ";
                    break;
                case 1:
                    lblHeader.Text = "Manage Supplier";

                    //mange button visibilty in Addnew Button
                    btnSupplierAddNew_Click(this, null);


                    break;
                case 2:
                    lblHeader.Text = "Manage Customers";
                    //mange button visibilty in Addnew Button
                    btnCustomerAddNew_Click(this, null);



                    break;
                case 3:
                    lblHeader.Text = "Manage Stock";
                    //mange button visibilty in Addnew Button
                   
                    

                    break;
                case 4:
                    lblHeader.Text = "Manage Employees";
                    break;
                case 5:
                    lblHeader.Text = "Manage Expenses";
                    DisplayExpenses();
                    break;
                case 6:
                    lblHeader.Text = "Manage Settings";
                    break;
                case 7:
                    lblHeader.Text = "Manage sales and Order Details";
                    break;
                case 8:
                    lblHeader.Text = "Create/Restore Backup";
                    break;
                default:
                    {
                        lblHeader.Text = "Welcome To Point Of Sale System ";
                        break;
                    }
            }
        }
        #endregion




        #region Supplier Tab Page
        //Supplier AddNew
        private void btnSupplierAddNew_Click(object sender, EventArgs e)
        {
            //empty textBoxes
            txtSupplierCompanyName.Text = ""; txtSuplierID.Text = "";
            txtSupplierName.Text = ""; txtSupplierPhone.Text = "";
        //    txtSupplierEmail.Text = ""; txtSupplierAccountNumber.Text = "";
            txtSupplierCity.Text = ""; txtSupplierAddress.Text = ""; txtSupplierComments.Text = "";
            picBoxSupplierPhoto.Image = Properties.Resources.NoImage;
      
            //hide buttons
            btnSupplierUpdate.Visible = false;
           
            //show buttons
            btnSupplierSave.Visible = true;
            //set focus
            txtSupplierCompanyName.Focus();
            dgvSuppliers.Refresh();
      
            DisplaySuppliers();
        }
        //load photo into picturebox and convert photo to binary
        #region supplier load photo and convert photo
        //supplier upload photo
        private void btnSupplierUploadPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please Select Supplier Photo ";
            ofd.Filter = "Image Files (*.jpeg;*.png;*.jpg)|*.jpeg;*.png;*.jpg";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picBoxSupplierPhoto.Image = new Bitmap(ofd.FileName);
            }
        }
        //supplier convert photo to byte/binary
        private byte[] SaveSupplierPhoto()
        {
            MemoryStream ms = new MemoryStream();
            picBoxSupplierPhoto.Image.Save(ms, picBoxSupplierPhoto.Image.RawFormat);
            return ms.GetBuffer();
        }
        #endregion
        //1 supplier Save,delete,Update,
        #region Suppliers Save, display, Update and Delete 
        //2 supplier-save
        private void btnSupplierSave_Click(object sender, EventArgs e)
        {

            if (txtSupplierCompanyName.Text == "" || txtSupplierName.Text == "" || txtSupplierPhone.Text == ""
                || txtSupplierEmail.Text == ""  || txtSupplierCity.Text == ""
                || txtSupplierAddress.Text == "" || txtSupplierComments.Text == "")
            {
                MessageBox.Show("Failure: Supplier Information Can not be Saved!\nRequired Complete Information", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {

                    string supplierName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtSupplierName.Text.ToLower());
                    string supplierCompanyName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtSupplierCompanyName.Text.ToLower());


                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("InsertSupplier", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SupplierName", supplierName);
                    cmd.Parameters.AddWithValue("@CompanyName", supplierCompanyName);
                    cmd.Parameters.AddWithValue("@Phone", txtSupplierPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtSupplierEmail.Text);
                  //  cmd.Parameters.AddWithValue("@Account", txtSupplierAccountNumber.Text);
                    cmd.Parameters.AddWithValue("@City", txtSupplierCity.Text);
                   
                    cmd.Parameters.AddWithValue("@Address", txtSupplierAddress.Text);
                    cmd.Parameters.AddWithValue("@Comments", txtSupplierComments.Text);
                    cmd.Parameters.AddWithValue("@EntryDate", thisDay); //add current date
                  
                    cmd.Parameters.AddWithValue("@Photo", SaveSupplierPhoto()); // picture by method
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Success: Supplier Information Has Been Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //empty textBoxes after saving information
                    btnSupplierAddNew_Click(this, null);
                    //reload datagridview
                    dgvSuppliers.Rows.Clear();
                    dgvSuppliers.Refresh();
                    DisplaySuppliers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }//end else
        }//end btn saveSupplier
        //3 supplier-update
        private void btnSupplierUpdate_Click(object sender, EventArgs e)
        {
            string id = txtSuplierID.Text; // get id supplier
            //format text into tilte case
            string supplierName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtSupplierName.Text.ToLower());
            string supplierCompanyName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtSupplierCompanyName.Text.ToLower());

            if (MessageBox.Show("Are you sure want to Update this Record of Supplier Id: " + id, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                query = "update  Suppliers set SupplierName=@Name, CompanyName=@company, PhoneNumber=@phone, EmailAddress=@email, City=@city,  Address=@address, Comments=@comments, Date=@date, Photo=@photo where SupplierID ='" + id + "'";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", supplierName);
                cmd.Parameters.AddWithValue("@company", supplierCompanyName);
                cmd.Parameters.AddWithValue("@phone", txtSupplierPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtSupplierEmail.Text);
          //      cmd.Parameters.AddWithValue("@account", txtSupplierAccountNumber.Text);
                cmd.Parameters.AddWithValue("@city", txtSupplierCity.Text);
                
                cmd.Parameters.AddWithValue("@address", txtSupplierAddress.Text);
                cmd.Parameters.AddWithValue("@comments", txtSupplierComments.Text);
                cmd.Parameters.AddWithValue("@date", thisDay);
                cmd.Parameters.AddWithValue("@savedBy", "Admin");// add value by userStatus
                cmd.Parameters.AddWithValue("@photo", SaveSupplierPhoto());
                cmd.ExecuteNonQuery();
                con.Close();
                //empty textBoxes after Update information
                btnSupplierAddNew_Click(this, null);
                

            }
        }
        // supplier display callingMethod
        private void DisplaySuppliers()
        {
            try
            {
                MyAutoFunctions f = new MyAutoFunctions();
                f.ViewRecords("ViewSupplierBasicDetails",cs ,dgvSuppliers);
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        // supplier selected row gridview to textboxes
        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // hide button save
                btnSupplierSave.Visible = false;
                //show update and delete button
                btnSupplierUpdate.Visible = true;

                int index = e.RowIndex;
                DataGridViewRow selectedRow = dgvSuppliers.Rows[index];
                string phone = selectedRow.Cells[1].Value.ToString();
                query = "select *from Suppliers where phoneNumber ='" + phone + "'"; ;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtSuplierID.Text = reader["SupplierID"].ToString();
                    txtSupplierName.Text = reader["SupplierName"].ToString();
                    txtSupplierCompanyName.Text = reader["CompanyName"].ToString();
                    txtSupplierEmail.Text = reader["EmailAddress"].ToString();
                    txtSupplierPhone.Text = reader["PhoneNumber"].ToString();
            //        txtSupplierAccountNumber.Text = reader["AccountNumber"].ToString();
                    txtSupplierCity.Text = reader["City"].ToString();
                  ///  cmboxSupplierState.DisplayMember = reader["State"].ToString();
                  //  cmboxSupplierState.ValueMember = reader["State"].ToString();

                    txtSupplierAddress.Text = reader["Address"].ToString();
                    txtSupplierComments.Text = reader["Comments"].ToString();

                    //getting photo 
                    byte[] picbyte = reader["Photo"] as byte[] ?? null;
                    if (picbyte != null)
                    {
                        MemoryStream mstream = new MemoryStream(picbyte);
                        picBoxSupplierPhoto.Image = System.Drawing.Image.FromStream(mstream);
                        {
                            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(mstream);
                        }
                    }

                    reader.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //supplier-delete
        private void btnSupplierDelete_Click(object sender, EventArgs e)
        {
            string id = txtSuplierID.Text;

            if (MessageBox.Show("Are you sure want to delet this Record of Supplier Id: " + id, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                query = "delete from Suppliers where SupplierID ='" + id + "'";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                //empty textBoxes after delete information
                btnSupplierAddNew_Click(this, null);


            }
        }
        #endregion // end Suppliers-action
        #region Supplier search
        //suppliear-search
        private void SearchSupplier(string value)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand("SearchSupplierBasicDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@value",value);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable(); // used for datagrid view
                sda.Fill(dt);
                dgvSuppliers.DataSource = dt;
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void txtSearchSupplier_TextChanged(object sender, EventArgs e)
        {
            string value = txtSearchSupplier.Text;
            if (value == "")
            {
                DisplaySuppliers();
            }
            else
            {
                SearchSupplier(value);
            }
        }

        #endregion
        #region supplier PrintGridView

        private void btnSuppliersPrintGridView_Click(object sender, EventArgs e)
        {
            try
            {
                // Print Grid View
                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Company Name\nlist of Suppliers ";
                printer.SubTitle = string.Format("Date {0}", DateTime.Now.Date.ToString("dd/MM/yyyy"));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "nenoSoft [nvd.mcs@gmail.com]";
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dgvSuppliers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
        // button move to next to tab
        private void btnSupplierGetReports_Click(object sender, EventArgs e)
        {
            

        }
        #endregion

        #region SupplierReport tab 

        #region Display SuppliersReport and Backbutton
        private void ViewSuppliersFullDetail(ComboBox cbox)
        {
            try
            {
                
                string sp = "ViewSupplierFullDetailsTop100";
                switch (cbox.SelectedIndex)
                {
                    case 0:
                        sp = "ViewSupplierFullDetailsTop100";
                        break;
                    case 1:
                        sp = "ViewSupplierFullDetailsTop300";
                        break;
                    case 2:
                        sp = "ViewSupplierFullDetailsTop500";
                        break;
                    case 3:
                        sp = "ViewSupplierFullDetails";
                        break;
                    
                }

                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(sp,con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable(); // used for datagrid view
                sda.Fill(dt);
                dgvSuppliersFullView.DataSource = dt;
                con.Close();

                foreach (DataGridViewRow row in dgvSuppliersFullView.Rows)
                {
                    row.Cells[0].Value = false;
                }



                lblTotalSupplierReport.Text = Convert.ToString(dgvSuppliersFullView.Rows.Count);


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnSupplierReportBack_Click(object sender, EventArgs e)
        {
            nTabControlSupplier.SelectedIndex = 0;
       
          

        }


        #endregion

        #region SupplierDeleteSelected
        private void btnSuppliersReportDeleteSelects_Click(object sender, EventArgs e)
        {
            List<string> selectedItem = new List<string>();
           
            int totalrowsSelected = 0;
            foreach (DataGridViewRow row in this.dgvSuppliersFullView.Rows)
            {

                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    string id = row.Cells[2].Value.ToString(); // get phoneNumber as ID of Row
                    selectedItem.Add(id); //If checked adding it to the list
                    totalrowsSelected++;
                    MessageBox.Show("id" + id);
                }
            }
      
            if (totalrowsSelected == 0)
            {
                MessageBox.Show("There is Not Selected any Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else {
                if (MessageBox.Show("Are you sure want to delet selected Records\nTotal Selected Records: " + totalrowsSelected, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    try
                    {
                        foreach (string s in selectedItem) //using foreach loop to delete the records stored in list.  
                        {
                            SqlCommand cmd = new SqlCommand("delete from Suppliers where PhoneNumber='" + s + "'", con);
                            int result = cmd.ExecuteNonQuery();
                        }
                    }
                    catch(SqlException ex)
                    {
                      DialogResult re=  MessageBox.Show(ex.Message+"\nDo You Still Want to Delete Records?","Message",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                        if(re==DialogResult.Yes)
                        {
                            foreach (string s in selectedItem) //using foreach loop to delete the records stored in list.  
                            {
                                SqlCommand cmd = new SqlCommand("delete from Suppliers where PhoneNumber='" + s + "'", con);
                                int result = cmd.ExecuteNonQuery();
                            }
                        }
                    }
                   
                    con.Close();
                 
                    dgvSuppliersFullView.Refresh();
                    ViewSuppliersFullDetail(cBoxViewTopSuppliers);
                 
                    lblTotalSupplierReport.Text = Convert.ToString(dgvSuppliersFullView.Rows.Count);
                }
                else
                {
                    dgvSuppliersFullView.ClearSelection();
                }
            }//end else
        }//end method








        #endregion

        #region supplierReport Search Supplier
        private void txtSupplierReportSearch_TextChanged(object sender, EventArgs e)
        {
            string value = txtSupplierReportSearch.Text;
            if (value == "")
            {
                ViewSuppliersFullDetail(cBoxViewTopSuppliers);
            }
            else
            {
                MyAutoFunctions f = new MyAutoFunctions();
                f.SearchRecords("SearchSupplierFullDetail", cs, value, dgvSuppliersFullView);
                lblTotalSupplierReport.Text = dgvSuppliersFullView.Rows.Count.ToString();
            }

        }
        private void SearchSupplierReport(string value)
        {
            try
            {
                query = "SELECT SupplierName, PhoneNumber, EmailAddress, CompanyName, AccountNumber, City, Date, Address FROM Suppliers WHERE CompanyName Like '%" + value + "%' OR PhoneNumber Like '%" + value + "%' OR EmailAddress Like '%" + value + "%' OR SupplierName Like '%" + value + "%' OR City Like '%" + value + "%' OR Date Like '%" + value + "%'";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                System.Data.DataTable dt = new System.Data.DataTable(); // used for datagrid view
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dgvSuppliersFullView.Rows.Add();
                    dgvSuppliersFullView.Rows[n].Height = 30;
                    dgvSuppliersFullView.Rows[n].Cells[0].Value = "false";
                    dgvSuppliersFullView.Rows[n].Cells[1].Value = item["SupplierName"].ToString();
                    dgvSuppliersFullView.Rows[n].Cells[2].Value = item["PhoneNumber"].ToString();
                    dgvSuppliersFullView.Rows[n].Cells[3].Value = item["EmailAddress"].ToString();
                    dgvSuppliersFullView.Rows[n].Cells[4].Value = item["CompanyName"].ToString();
                    dgvSuppliersFullView.Rows[n].Cells[5].Value = item["AccountNumber"].ToString();
                    dgvSuppliersFullView.Rows[n].Cells[6].Value = item["City"].ToString();
                    dgvSuppliersFullView.Rows[n].Cells[7].Value = item["Address"].ToString();
                    dgvSuppliersFullView.Rows[n].Cells[8].Value = item["Date"].ToString();

                    //gridview Formatting zebra color(odd even rows)
                    if (n % 2 == 0)
                    {
                        dgvSuppliersFullView.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); ;//light gray
                    }
                    else
                    {
                        dgvSuppliersFullView.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);//white
                    }
                }
                lblTotalSupplierReport.Text = Convert.ToString(dgvSuppliersFullView.Rows.Count);
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
       

        #endregion







        #region Customers TabPage
        // customer-addnew
        private void btnCustomerAddNew_Click(object sender, EventArgs e)
        {
            customerID = txtCustomerID.Text = "";
            customerName = txtCustomerName.Text = "";
            customerPhone = txtCustomerPhoneNumber.Text = "";
            customerCity = txtCustomerCity.Text = "";
            customerAddress = txtCustomerAddress.Text = "";
       
            // show button
            btnCustomerSave.Visible = true;
            //hide form buttons
            btnCustomerDelete.Visible = false;
            btnCustomerUpdate.Visible = false;
            //refresh and reload gridview 
            dgvCustomers.Rows.Clear();
            dgvCustomers.Refresh();
            DisplayCustomers(); // display records in datagrid view
            //set Focus
            txtCustomerName.Focus();
        }

        //customer-save
        private void btnCustomerSave_Click(object sender, EventArgs e)
        {
            customerName = txtCustomerName.Text;
            customerPhone = txtCustomerPhoneNumber.Text;
            customerCity = txtCustomerCity.Text;
            customerAddress = txtCustomerAddress.Text;
      
            if (customerName == "" || customerPhone == "")
            {
                MessageBox.Show("Failure: Supplier Information Can not be Saved!\nRequired Complete Information", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                try
                {

                    customerName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(customerName.ToLower());
                    customerCity = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCustomerCity.Text.ToLower());


                    query = "insert into Customers(Name,Phone,City,Address,Comments) values(@name,@phone,@city,@address,@comments)";
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", customerName);
                    cmd.Parameters.AddWithValue("@phone", customerPhone);
                    cmd.Parameters.AddWithValue("@city", customerCity);
                    cmd.Parameters.AddWithValue("@address", customerAddress);
                    cmd.Parameters.AddWithValue("@comments", customerComments);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Message: Customer Information Has Been Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //empty textBoxes after saving information
                    btnCustomerAddNew_Click(this, null);
                    //reload datagridview
                    dgvCustomers.Rows.Clear();
                    dgvCustomers.Refresh();
                    DisplayCustomers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }//end else
        }

        //customer-view
        private void DisplayCustomers()
        {
            try
            {
                query = "select Name, Phone, City, Address  from Customers order by CustomerID desc";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                System.Data.DataTable dt = new System.Data.DataTable(); // used for datagrid view
                sda.Fill(dt);
                //  dgvSupplier.DataSource = dt;  
                foreach (DataRow item in dt.Rows)
                {
                    int n = dgvCustomers.Rows.Add(); //datagridviewName total rows

                    dgvCustomers.Rows[n].Height = 30;
                    dgvCustomers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvCustomers.Rows[n].Cells[0].Value = item["Name"].ToString();
                    dgvCustomers.Rows[n].Cells[1].Value = item["Phone"].ToString();
                    dgvCustomers.Rows[n].Cells[2].Value = item["City"].ToString();
                    dgvCustomers.Rows[n].Cells[3].Value = item["Address"].ToString();
                    //gridview Formatting zebra color(odd even rows)
                    if (n % 2 == 0)
                    {
                        dgvCustomers.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); ;//light gray
                    }
                    else
                    {
                        dgvCustomers.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);//white
                    }
                }
                con.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //customer-search
        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            string value = txtCustomerSearch.Text;
            if (value == "")
            {
                dgvCustomers.Rows.Clear();
                dgvCustomers.Refresh();
                DisplayCustomers();
            }
            else
            {

                dgvCustomers.Rows.Clear();
                dgvCustomers.Refresh();
                CustomerSearch(value);
            }
        }

        //customer-search-method
        private void CustomerSearch(string value)
        {
            try
            {
                query = "SELECT Name, Phone, City, Address FROM Customers WHERE Name Like '%" + value + "%' OR Phone Like '%" + value + "%' OR City Like '%" + value + "%' OR Address Like '%" + value + "%'";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                System.Data.DataTable dt = new System.Data.DataTable(); // used for datagrid view
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dgvCustomers.Rows.Add(); //datagridviewName total rows

                    dgvCustomers.Rows[n].Height = 30;
                    dgvCustomers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvCustomers.Rows[n].Cells[0].Value = item["Name"].ToString();
                    dgvCustomers.Rows[n].Cells[1].Value = item["Phone"].ToString();
                    dgvCustomers.Rows[n].Cells[2].Value = item["City"].ToString();
                    dgvCustomers.Rows[n].Cells[3].Value = item["Address"].ToString();
                    //gridview Formatting zebra color(odd even rows)
                    if (n % 2 == 0)
                    {
                        dgvCustomers.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); ;//light gray
                    }
                    else
                    {
                        dgvCustomers.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);//white
                    }
                }
                con.Close();
;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //selected-row gridview to textBoxes
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // hide button save
                btnCustomerSave.Visible = false;
                //show update and delete button
                btnCustomerDelete.Visible = true;
                btnCustomerUpdate.Visible = true;

                int index = e.RowIndex; // get selected row index
                DataGridViewRow selectedRow = dgvCustomers.Rows[index];
                string phone = selectedRow.Cells[1].Value.ToString();
                query = "select *from Customers where Phone='" + phone + "'"; ;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {   //get value from databae and intialize to textboxs
                    txtCustomerID.Text = reader["CustomerID"].ToString();
                    txtCustomerName.Text = reader["Name"].ToString();
                    txtCustomerPhoneNumber.Text = reader["Phone"].ToString();
                    txtCustomerCity.Text = reader["City"].ToString();
                    txtCustomerAddress.Text = reader["Address"].ToString();
                    txtSupplierCity.Text = reader["City"].ToString();
                    reader.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //customer-delete
        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
            string id = txtCustomerID.Text;


            if (MessageBox.Show("Are you sure want to delet this Record of Customer Id: " + id, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                query = "delete from Customers where CustomerID ='" + id + "'";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                //empty textBoxes after delete information
                btnCustomerAddNew_Click(this, null);
                //reload datagridview
                dgvCustomers.Rows.Clear();
                //   dgvCustomers.Refresh();
                DisplayCustomers();

            }
        }
        //Custpmer-update
        private void btnCustomerUpdate_Click(object sender, EventArgs e)
        {
            string id = txtCustomerID.Text; // get id 
                                            //format text into tilte case

            customerName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCustomerName.Text.ToLower());
            customerCity = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCustomerCity.Text.ToLower());

            if (MessageBox.Show("Are you sure want to Update this Record of Customer Id: " + id, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                query = "update  Customers set Name=@Name, Phone=@phone, City=@city, Address=@Address, Comments=@comments where CustomerID ='" + id + "'";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", customerName);
                cmd.Parameters.AddWithValue("@phone", txtCustomerPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@city", customerCity);
                cmd.Parameters.AddWithValue("@Address", txtCustomerAddress.Text);
  
                cmd.ExecuteNonQuery();
                con.Close();
                //empty textBoxes after Update information
                btnSupplierAddNew_Click(this, null);
                //clear grid after update
                dgvCustomers.Rows.Clear();
                // reload grid after update
                DisplayCustomers();

            }

        }
        //customer-report printGridvView
        private void btnCustomerPrintGridView_Click(object sender, EventArgs e)
        {
            try
            {
                // Print Grid View
                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Company Name\nlist of Customers ";
                printer.SubTitle = string.Format("Date {0}", DateTime.Now.Date.ToString("dd/MM/yyyy"));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "nenoSoft [nvd.mcs@gmail.com]";
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dgvCustomers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //customer-report-ExportExcel
        private void btnCustomerExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
            //    Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            //    if (xlApp == null)
            //    {
            //        MessageBox.Show("Excel is not properly installed!!");
            //        return;
            //    }


            //    Excel.Workbook xlWorkBook;
            //    Excel.Worksheet xlWorkSheet;
            //    object misValue = System.Reflection.Missing.Value;

            //    xlWorkBook = xlApp.Workbooks.Add(misValue);
            //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //    xlWorkSheet.Cells[1, 1] = "Name";
            //    xlWorkSheet.Cells[1, 2] = "Phone";
            //    xlWorkSheet.Cells[1, 3] = "City";
            //    xlWorkSheet.Cells[1, 4] = "Address";


            //    for (int row = 2; row <= dgvCustomers.Rows.Count; row++)
            //    {
            //        for (int col = 0; col <= 3; col++)
            //        {
            //            xlWorkSheet.Cells[row, col + 1] = dgvCustomers.Rows[row - 2].Cells[col].Value.ToString();
            //        }
            //    }
            //    System.Windows.Forms.SaveFileDialog saveDlg = new System.Windows.Forms.SaveFileDialog();
            //    saveDlg.InitialDirectory = @"C:\";
            //    saveDlg.Filter = "Excel files (*.xls)|*.xls";
            //    saveDlg.FileName = "List Of Customers-" + thisDay;
            //    saveDlg.FilterIndex = 0;
            //    saveDlg.RestoreDirectory = true;
            //    saveDlg.Title = "Export Excel File To";
            //    if (saveDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        string path = saveDlg.FileName;
            //        xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //        xlWorkBook.Close(true, misValue, misValue);
            //        xlApp.Quit();

            //        Marshal.ReleaseComObject(xlWorkSheet);
            //        Marshal.ReleaseComObject(xlWorkBook);
            //        Marshal.ReleaseComObject(xlApp);

            //        MessageBox.Show("You can find the file Path:" + path, "Success:Excel file created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }
        #endregion
        #region Manage Product Category Page
  
        //category btnAddNew
      
       


       
       
       

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(lockedEditProduct !=true)
            {

                try
                {
                    // hide button save
                    btnSaveProduct.Visible = false;
                    //show update and delete button
                    checkBoxProductStatus.Enabled = true;
                
                    btnProductUpdate.Visible = true;

                    //panel product info show

                    checkBoxProductStatus.Enabled = true;
                    LoadProductCategoriesComboBox();
                    LoadProductSuppliersComboBox();
                    int index = e.RowIndex; // get selected row index
                    DataGridViewRow selectedRow = dgvProducts.Rows[index];
                    //Get Select Row Barcode( Must be Uniquer Value)
                    string productBarcode = selectedRow.Cells[0].Value.ToString();
                    query = "select *from Products where Barcode='" + productBarcode + "'"; ;
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {   //get value from databae and intialize to textboxs
                        txtProductBarcode.Text = reader["Barcode"].ToString();

                        //Show Entry Date in Date Time Picker
                        string EntryDate = reader["EntryDate"].ToString();
                        DateTime EntryDateObj = DateTime.Parse(EntryDate);
                        dateTimePickerProductEntryDate.Value = EntryDateObj;


                        txtProductID.Text = reader["ProductID"].ToString();

                        txtProductName.Text = reader["ProductName"].ToString();
                        txtProductWeight.Text = reader["Weight"].ToString();
                        txtProductTotalUnits.Text = reader["TotalUnits"].ToString();
                        double unitPriceActual = double.Parse(reader["UnitPriceActual"].ToString());
                        txtProductUnitPriceActual.Text = unitPriceActual.ToString("0.00");

                        double unitPriceToSell = double.Parse(reader["UnitPriceToSell"].ToString());
                        txtProductUnitPriceToSell.Text = unitPriceToSell.ToString("0.00");



                        cmboxProductCategory.SelectedValue = Convert.ToInt32(reader["CategoryID_FK"]);
                        cmBoxSeason.SelectedItem = reader["Season"].ToString();

                        cmBoxProductSuppliers.SelectedValue = Convert.ToInt32(reader["SupplierID_FK"]);
                        txtProductReorderLevel.Text = reader["ReorderLevel"].ToString();

                        txtProductComments.Text = reader["Comments"].ToString();

                        string status = reader["Active"].ToString();
                        if (status == "yes")
                            checkBoxProductStatus.Checked = true;
                        else
                            checkBoxProductStatus.Checked = false;


                        reader.Close();
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }//end locked if

        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            string id = txtProductID.Text;

            if (MessageBox.Show("Are you sure want to delet this Record of Product Id: " + id + "\nOnce You delete this record, you can not recover.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                query = "delete from Products where ProductID ='" + id + "'";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                //Reset Form and ProductsGridView after delete information
                btnProductAddNew_Click(this, null);


            }

        }

        private void btnProductUpdate_Click(object sender, EventArgs e)
        {
            string id = txtProductID.Text; // get id 
            string productActive;
            if (checkBoxProductStatus.Checked == true)
            {
                productActive = "yes";
            }
            else
            {
                productActive = "no";
            }
               
               
            // Check if Product Form Value is Missing
            if (txtProductBarcode.Text == "" || txtProductName.Text == "" || txtProductUnitPriceActual.Text == "" || txtProductTotalUnits.Text == "" || txtProductReorderLevel.Text == "" || txtProductWeight.Text == "" || txtProductUnitPriceToSell.Text=="")
            {
                MessageBox.Show("Failure: Product Information Can not be Saved!\nRequired Complete Information", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Confirm if User Want to Update this record
                if (MessageBox.Show("Are you sure want to Update this Record of Product Id: " + id, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    

                        try
                        {
                            //----------------Update Products
                            //Uformat text into tilte case
                            string productName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtProductName.Text.ToLower());

                            query = "update  Products set Barcode=@barcode, EntryDate=@entryDate, ProductName=@productName, Weight=@weight, TotalUnits=@totalUnits, UnitPriceActual=@unitPriceActual, UnitPriceToSell=@unitPriceToSell, ReorderLevel=@reorderLevel, Comments=@comments, SupplierID_FK=@supplierID, CategoryID_FK=@categoryID, Season=@season, SavedBy=@savedBy, Active=@active where ProductID ='" + id + "'";
                            SqlConnection con = new SqlConnection(cs);
                            con.Open();
                            SqlCommand cmd = new SqlCommand(query, con);
                            //Error-info @varibale name invalid column name            | 13-fields
                            cmd.Parameters.AddWithValue("@barcode", txtProductBarcode.Text);
                            cmd.Parameters.AddWithValue("@supplierID", cmBoxProductSuppliers.SelectedValue);
                            cmd.Parameters.AddWithValue("@categoryID", cmboxProductCategory.SelectedValue);
                            cmd.Parameters.AddWithValue("@season", cmBoxSeason.SelectedItem);
                            cmd.Parameters.AddWithValue("@productName", productName);
                            cmd.Parameters.AddWithValue("@weight", txtProductWeight.Text);
                            cmd.Parameters.AddWithValue("@totalUnits", txtProductTotalUnits.Text);
                            cmd.Parameters.AddWithValue("@unitPriceActual", txtProductUnitPriceActual.Text);
                            cmd.Parameters.AddWithValue("@unitPricetoSell", txtProductUnitPriceToSell.Text);
                            cmd.Parameters.AddWithValue("@reorderLevel", txtProductReorderLevel.Text);
                            cmd.Parameters.AddWithValue("@comments", txtProductComments.Text);
                            cmd.Parameters.AddWithValue("@entryDate", dateTimePickerProductEntryDate.Value.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@savedBy", userName);
                            cmd.Parameters.AddWithValue("@active", productActive);
                            cmd.ExecuteNonQuery();
                            con.Close();
                           //empty textBoxes after Update information
                           btnProductAddNew_Click(this, null);
                       }
                        catch (Exception ex)
                        {
                        MessageBox.Show("A Record against this  Barcode '" + txtProductBarcode.Text + "' is Already Exist.\nPlease Enter Unique Barcode", "Message [Unique Constraint]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }








                }// end if 

            }//end else
        }//end method

        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            string value = txtProductSearch.Text;

            //BindingSource bs = new BindingSource();
            //bs.DataSource = dgvProducts.DataSource;
            //MessageBox.Show("E:" + dgvProducts.Columns[0].HeaderText);
            //bs.Filter = string.Format("{0} like '%{1}%'", dgvProducts.Columns[0].HeaderText, value);
            //dgvProducts.DataSource = bs;
            if (value == "")
            {
                // dgvProducts.Rows.Clear();
              //    dgvProducts.Refresh();
                DisplayProducts();
                btnDgvProductsBack.PerformClick();

            }
            else
            {

               DsProductsbasicInfo.Clear();
               // dgvProducts.Refresh();
                SearchProduct(value);
            }
        }

        private void SearchProduct(string value)
        {
            int totalProductstoReorder = 0;

            try
            {
                query = "select Barcode,ProductName, Weight, TotalUnits,SupplierName,UnitPriceActual,FORMAT(EntryDate,'dd-MM-yyyy') as EntryDate,Active from Products join Suppliers on SupplierID_FK=SupplierID where Barcode like '%" + value + "%' OR ProductName like '%" + value + "%' OR SupplierName like '%" + value + "%' Or Active like '%" + value+ "%' Or Weight like '%" + value+"%'  order by (ProductID) desc";
                SqlConnection con = new SqlConnection(cs);
               
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                con.Open();
                sda.Fill(ds, "Products");
                con.Close();
                dgvProducts.AutoGenerateColumns = false;
                //dgvProducts.Columns[0].DataPropertyName = "Barcode";
                //dgvProducts.Columns[1].DataPropertyName = "ProductName";
                //dgvProducts.Columns[2].DataPropertyName = "Weight";
                //dgvProducts.Columns[3].DataPropertyName = "TotalUnits";
                //dgvProducts.Columns[4].DataPropertyName = "SupplierName";
                //dgvProducts.Columns[5].DataPropertyName = "EntryDate";
                //dgvProducts.Columns[6].DataPropertyName = "Active";
                //binding data with dgv
                dgvProducts.DataSource = ds;

                dgvProducts.DataMember = "Products";
                dgvProductsTotalRecords = dgvProducts.Rows.Count.ToString();
             
                lblTotalProductsToReorderValue.Text = Convert.ToString(totalProductstoReorder);
                lblTotalProducts.Text = Convert.ToString(dgvProductsTotalRecords); //datagridviewName
               

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnProductPrintList_Click(object sender, EventArgs e)
        {
            try
            {
                // Print Grid View
                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Company Name\nlist of Products ";
                printer.SubTitle = string.Format("Date {0}", DateTime.Now.Date.ToString("dd/MM/yyyy"));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "nenoSoft [nvd.mcs@gmail.com]";
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dgvProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

       

        private void LoadCategoriesComboxBox(ComboBox cbox)
        {
            //cbox.Items.Clear();
            string query = "select * from Categories";
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
      


        private void btnProductExportExcel_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            //    if (xlApp == null)
            //    {
            //        MessageBox.Show("Excel is not properly installed!!");
            //        return;
            //    }


            //    Excel.Workbook xlWorkBook;
            //    Excel.Worksheet xlWorkSheet;
            //    object misValue = System.Reflection.Missing.Value;

            //    xlWorkBook = xlApp.Workbooks.Add(misValue);
            //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //    Excel.Range chartRange;
            //    Excel.Range formatRange;

             
            //    xlWorkSheet.get_Range("a1", "g2").Merge();
            //    chartRange = xlWorkSheet.get_Range("a1", "g2");  // Chart Range  =>Merge top two Rows  g= column number=7 g(2)=  means row number is 2
            //    chartRange.FormulaR1C1 = "Report List Of Products";
            //    chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(169, 208, 142));// Background Color
            //    chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(88, 89, 88)); // Fore Color
            //    chartRange.HorizontalAlignment = 3;
            //    chartRange.VerticalAlignment = 2;
            //    chartRange.Font.Size = 20;
            //    chartRange.Font.Bold = true;

                 
            //    chartRange=xlWorkSheet.get_Range("a3","g3");
            //    chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(169, 208, 142));// Background Color
            //    chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DimGray); // Fore Color
            //    chartRange.Font.Bold = true;
            //    xlWorkSheet.Cells[3, 1] = "Shope:";
            //    xlWorkSheet.Cells[3, 2] = "ABC";
            //    formatRange = xlWorkSheet.get_Range("g3");
            //    formatRange.NumberFormat = "dd-MM-yyyy";
            //    formatRange = xlWorkSheet.get_Range("f3");
            //    formatRange.HorizontalAlignment = 1;
            //    formatRange = xlWorkSheet.get_Range("e3");
            //    formatRange.HorizontalAlignment = 1;
            //    xlWorkSheet.Cells[3, 6] = "Date:";
            //    xlWorkSheet.Cells[3, 7] = thisDay;

            //    formatRange = xlWorkSheet.get_Range("a4", "g4");
            //    chartRange = xlWorkSheet.get_Range("a4", "g4");// Row Heading
            //  //  formatRange.Columns.Width(15);
            //    chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 176, 80));
            //    chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            //    chartRange.HorizontalAlignment = 3;
            //    chartRange.VerticalAlignment = 2;
            //    chartRange.Font.Bold = true;




            //    //row=1 
            //    xlWorkSheet.Cells[4, 1] = "Barcode ";
            //    xlWorkSheet.Cells[4, 2] = "Product Name";
            //    xlWorkSheet.Cells[4, 3] = "Weight";
            //    xlWorkSheet.Cells[4, 4] = "Total Units";
            //    xlWorkSheet.Cells[4, 5] = "UnitPriceActual";
            //    xlWorkSheet.Cells[4, 6] = "UnitPrice ToSell";
            //    xlWorkSheet.Cells[4, 7] = "Reorder Level";
            //    int col=0 , row=0;
            //    for ( row = 5; row-4 <= dgvProducts.Rows.Count; row++)
            //    {
            //        for ( col = 1; col <= 7; col++)
            //        {
            //            xlWorkSheet.Cells[row, col] = dgvProducts.Rows[row - 5].Cells[col-1].Value.ToString();
            //        }
            //    }
            //    xlWorkSheet.Cells[3, 4] = "Total Products:";
            //    xlWorkSheet.Cells[3, 5] = row-5;

            //    chartRange = xlWorkSheet.get_Range("a5", "g"+row);// Row Heading
           
            //    chartRange.HorizontalAlignment = 3;
            //    chartRange.VerticalAlignment = 3;

            //    System.Windows.Forms.SaveFileDialog saveDlg = new System.Windows.Forms.SaveFileDialog();
            //    saveDlg.InitialDirectory = @"C:\";
            //    saveDlg.Filter = "Excel files (*.xls)|*.xls";
            //    saveDlg.FileName = "List Of Products";
            //    saveDlg.FilterIndex = 0;
            //    saveDlg.RestoreDirectory = true;
            //    saveDlg.Title = "Export Excel File To";
            //    if (saveDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        string path = saveDlg.FileName;
            //        xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //        xlWorkBook.Close(true, misValue, misValue);
            //        xlApp.Quit();

            //        Marshal.ReleaseComObject(xlWorkSheet);
            //        Marshal.ReleaseComObject(xlWorkBook);
            //        Marshal.ReleaseComObject(xlApp);

            //        MessageBox.Show("You can find the file Path:" + path, "Success:Excel file created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnProductAdvanceViewDeleteSelected_Click(object sender, EventArgs e)
        {
            List<string> selectedItem = new List<string>();
            DataGridViewRow drow = new DataGridViewRow();
            int totalrowsSelected = 0;

            for (int i = 0; i <= dgvProductsFullView.Rows.Count - 1; i++)
            {
                drow = dgvProductsFullView.Rows[i];
                if (Boolean.Parse(drow.Cells[0].Value.ToString())) //checking if  checked or not.  
                {
                    string id = drow.Cells[1].Value.ToString(); // get Barcode as ID of Row
                    selectedItem.Add(id); //If checked adding it to the list
                    totalrowsSelected++;
                }
            }
            if (totalrowsSelected == 0)
            {
                MessageBox.Show("There is Not Selected any Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else {
                if (MessageBox.Show("Are you sure want to delet selected Records, You can not Restore After Deleting\nTotal Selected Records: " + totalrowsSelected, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    foreach (string s in selectedItem) //using foreach loop to delete the records stored in list.  
                    {
                        SqlCommand cmd = new SqlCommand("delete from Products where Barcode='" + s + "'", con);
                        int result = cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    dgvProductsFullView.Rows.Clear();
                    dgvProductsFullView.Refresh();
                    
                    lblProductFullViewTotalProducts.Text = Convert.ToString(dgvProductsFullView.Rows.Count);
                }
                else
                {
                   
                }
            }//end else
        }

        private void btnPOSReceiveOrder_Click(object sender, EventArgs e)
        {
           // this.IsMdiContainer = true;
            ReceiveOrdersForm orderForm = new ReceiveOrdersForm();
          
            orderForm.ShowDialog();
           
        }

        private void btnProductsAdvanceViewExcelExport_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            //    if (xlApp == null)
            //    {
            //        MessageBox.Show("Excel is not properly installed!!");
            //        return;
            //    }


            //    Excel.Workbook xlWorkBook;
            //    Excel.Worksheet xlWorkSheet;
            //    object misValue = System.Reflection.Missing.Value;

            //    xlWorkBook = xlApp.Workbooks.Add(misValue);
            //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //    //row=1 
            //    xlWorkSheet.Cells[1, 1] = "Barcode ";
            //    xlWorkSheet.Cells[1, 2] = "Product Name";
            //    xlWorkSheet.Cells[1, 3] = "Weight";
            //    xlWorkSheet.Cells[1, 4] = "Total Units";
            //    xlWorkSheet.Cells[1, 5] = "Unit Price";
            //    xlWorkSheet.Cells[1, 6] = "Total Units Price";
            //    xlWorkSheet.Cells[1, 7] = "Category";
            //    xlWorkSheet.Cells[1, 8] = "Supplier";
            //    xlWorkSheet.Cells[1, 9] = "Season";
            //    xlWorkSheet.Cells[1, 10] = "Date";
            //    xlWorkSheet.Cells[1, 11] = "Reorder Level";

            //    for (int row = 2; row <= dgvProductsFullView.Rows.Count+1; row++)
            //    {
            //        for (int col = 1; col <= 11; col++)
            //        {
            //            xlWorkSheet.Cells[row, col] = dgvProductsFullView.Rows[row-2].Cells[col].Value.ToString();
            //        }
            //    }
            //    System.Windows.Forms.SaveFileDialog saveDlg = new System.Windows.Forms.SaveFileDialog();
            //    saveDlg.InitialDirectory = @"C:\";
            //    saveDlg.Filter = "Excel files (*.xls)|*.xls";
            //    saveDlg.FilterIndex = 0;
            //    saveDlg.FileName = "List Of Products-"+thisDay;
            //    saveDlg.RestoreDirectory = true;
            //    saveDlg.Title = "Export Excel File To";
            //    if (saveDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        string path = saveDlg.FileName;
            //        xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //        xlWorkBook.Close(true, misValue, misValue);
            //        xlApp.Quit();

            //        Marshal.ReleaseComObject(xlWorkSheet);
            //        Marshal.ReleaseComObject(xlWorkBook);
            //        Marshal.ReleaseComObject(xlApp);

            //        MessageBox.Show("You can find the file Path:" + path, "Success:Excel file created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void cmBoxProductAdvanceViewCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nTabControlStock_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalProducts2_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void lblProductTotalQuantity_Click(object sender, EventArgs e)
        {

        }

        private void lblProductTotalPriceHeading_Click(object sender, EventArgs e)
        {

        }

        private void lblProductTotalPrice_Click(object sender, EventArgs e)
        {

        }
        public static void BackupDatabase(string backUpFileSavePath,string serverName,string dbName)
        {
            ServerConnection con = new ServerConnection(@serverName);
            Server server = new Server(con);
            Backup source = new Backup();
            source.Action = BackupActionType.Database;
            source.Database =dbName;
 
            BackupDeviceItem destination = new BackupDeviceItem(backUpFileSavePath, DeviceType.File);
            source.Devices.Add(destination);
            source.SqlBackup(server);
            con.Disconnect();
        }

        private void btnBackupSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                System.Windows.Forms.SaveFileDialog saveDlg = new System.Windows.Forms.SaveFileDialog();
                
                saveDlg.Filter = "Database Backup files (*.bak)|*.bak";
                saveDlg.FilterIndex = 0;
                saveDlg.FileName = "POSNayaSaveraDB";
                saveDlg.RestoreDirectory = true;
                saveDlg.Title = "Save Database Backup with name POSNayaSaveraDB";
                if (saveDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = saveDlg.FileName;
                    BackupDatabase(path,txtBackupSeverName.Text,txtBackupDatabaseName.Text);
                    
                    MessageBox.Show("Backup has been Saved Successfully ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message,"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dbBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
           
        }

        private void dbBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            if(e.Error !=null)
            {
               
            }
        }

        private void btnExpenseAddNew_Click(object sender, EventArgs e)
        {

            dateTimePickerExpenseDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtExpenseAmount.Text = "";
            txtExpenseID.Text = "";
            txtExpenseDetails.Text = "";
            comboBoxExpenseType.SelectedIndex = 1;
            //show Save  button
           btnExpenseSave.Visible = true;
            //hide form buttons Advance User access
        //    btnExpenseDelete.Visible = false;
        //    btnExpenseUpdate.Visible = false;

            dgvExpenses.Rows.Clear();

            DisplayExpenses(); // display records in datagrid view
            //set Focus
            dateTimePickerExpenseDate.Focus();
        }

        private void DisplayExpenses()
        {
          int  totalListOfExpenses= 0;
            try
            {
                query = "select ExpenseID,Date,Type, Amount, Details  from Expenses";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                System.Data.DataTable dt = new System.Data.DataTable(); // used for datagrid view
                sda.Fill(dt);
               
                foreach (DataRow item in dt.Rows)
                {
                    int n = dgvExpenses.Rows.Add(); //datagridviewName total rows

                    dgvExpenses.Rows[n].Height = 25;
                 //   dgvExpenses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvExpenses.Rows[n].Cells[0].Value = item["ExpenseID"].ToString();
                    
                    string EntryDate = item["Date"].ToString();
                    DateTime expenseDate = DateTime.Parse(EntryDate);
                    dgvExpenses.Rows[n].Cells[1].Value = expenseDate.ToString("dd-MM-yyyy");

                    dgvExpenses.Rows[n].Cells[2].Value = item["Type"].ToString();

                    Double expenseAmount = double.Parse(item["Amount"].ToString());
                    dgvExpenses.Rows[n].Cells[3].Value = expenseAmount.ToString("0.00");
                    dgvExpenses.Rows[n].Cells[4].Value = item["Details"].ToString();

                    //gridview Formatting zebra color(odd even rows)
                    if (n % 2 == 0)
                    {
                        dgvExpenses.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); ;//light gray
                    }
                    else
                    {
                        dgvExpenses.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);//white
                    }
                }
                con.Close();
                totalListOfExpenses = dgvExpenses.Rows.Count;
                lblTotalListOfExpenses.Text = Convert.ToString(totalListOfExpenses); //datagridviewName

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void RestoreDatabase(string filepath,string serverName, string dbName )
        {
            ServerConnection con = new ServerConnection(serverName);
            Server server = new Server(con);
            Restore destination = new Restore();
            destination.Action = RestoreActionType.Database;
            destination.Database = dbName;
            BackupDeviceItem source = new BackupDeviceItem(filepath, DeviceType.File);
            destination.Devices.Add(source);
            destination.ReplaceDatabase = true;
            destination.SqlRestore(server);
        }

        private void btnRestoreBackup_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Database Backup files (*.bak)|*.bak";
            ofd.FilterIndex = 0;
            ofd.FileName = "POSNayaSaveraDB";
            ofd.RestoreDirectory = true;
   
            ofd.Title = "Select Backup File with name POSNayaSaveraDB to Restore";
            try {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = ofd.FileName;

                    RestoreDatabase(path, txtBackupSeverName.Text, txtBackupDatabaseName.Text);

                    MessageBox.Show("Backup has been Restore Successfully ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            nTabControlSettings.SelectedIndex = 1;
        }

        private void panel36_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void txtSupplierPhone_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            { 
                e.Handled = true; // if char is digit then accept 
            //    errorSuccess.Clear();
            //    errorWarning.SetError(txtSupplierPhone, "Accept Only Numbers");
            }
            else
            {
           
           //     errorSuccess.SetError(txtSupplierPhone, "okk");
            //    errorWarning.Clear();
            }
        }

        private void txtSupplierCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            else
            {
                //satement 
            }
        }

        private void txtSupplierName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;

                }
        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalProductsToReorder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ReorderProductsFrom rf = new ReorderProductsFrom();
            rf.ShowDialog();
        }








        #endregion


        //////////////----------------------------------------------------------------------////////////////////////
        ///------------------------------- Products Page-----------------------------------------------------------          
        //////////////---------------------------------------------------------------------////////////////////////



        #region Stock TabPage
        #region Products Page
        //Products AddNew
        private void btnProductAddNew_Click(object sender, EventArgs e)
        {
            startrow = 0;
            //Reset Properties  of Product Form
            //-------------------------------------------------
            txtProductBarcode.Text = "";
            dateTimePickerProductEntryDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtProductID.Text = "";

            txtProductName.Text = "";
            txtProductWeight.Text = "";

            txtProductTotalUnits.Text = "";
            txtProductUnitPriceActual.Text = "";
            txtProductUnitPriceToSell.Text = "";
            
            cmboxProductCategory.SelectedIndex = 0;
            cmBoxSeason.SelectedIndex = 4;
            
            cmBoxProductSuppliers.SelectedIndex = 0;
            txtProductReorderLevel.Text = Properties.Settings.Default.ReorderLevel;

            txtProductComments.Text = "";
            checkBoxProductStatus.Enabled = false;
            checkBoxProductStatus.Checked = true;
           //-----------------------------------------------
            
            //Show buttons
            btnSaveProduct.Visible = true;
            //hide form buttons
           
            btnProductUpdate.Visible = false;
            
            //set Focus
            txtProductBarcode.Focus();
            //load gridview
            btnDgvProductsBack.PerformClick();
        }

       

        private void btnProductsFullViewBack_Click(object sender, EventArgs e)
        {
            nTabControlStock.SelectedIndex = 0;
            btnProductAddNew.PerformClick();
        }

        private void btnSettingsUpdateCompanyDetails_Click(object sender, EventArgs e)
        {

        }

        private void txtProductTotalUnits_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back ))
            {
                e.Handled = true;
            }
        }

        private void txtProductUnitPriceActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar=='.' ))
            {
                e.Handled = true;
            }
        }

        private void txtProductUnitPriceToSell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtProductReorderLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back ))
            {
                e.Handled = true;
            }
        }

        private void btnExpenseSave_Click(object sender, EventArgs e)
        {
            if (txtExpenseDetails.Text == ""|| txtExpenseAmount.Text=="")
            {
                MessageBox.Show("Expense Information Can not be Saved!\nRequired Complete Information", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                try
                {

                   

                    query = "insert into Expenses(Date,Type,Amount,Details ) values(@date,@type,@amount,@details)";
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@date", dateTimePickerExpenseDate.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@type",comboBoxExpenseType.SelectedItem);
                    cmd.Parameters.AddWithValue("@amount", txtExpenseAmount.Text);
                    cmd.Parameters.AddWithValue("@details", txtExpenseDetails.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Congratulations: Expense Information Has Been Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //empty textBoxes after saving information
                    btnExpenseAddNew_Click(this, null);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }//end else
        }

        private void btnExpenseUpdate_Click(object sender, EventArgs e)
        {
            string id = txtExpenseID.Text; // get id 
           
            if (txtExpenseAmount.Text == "" || txtExpenseDetails.Text=="")
            {
                MessageBox.Show("Cannot Update Because no Information is provided/incomplete: ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                if (MessageBox.Show("Are you sure want to Update this Record of Expense Id: " + id, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    query = "update  Expenses set Date=@date, Type=@type, Amount=@amount, Details=@details where ExpenseID ='" + id + "'";
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@date", dateTimePickerExpenseDate.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@type", comboBoxExpenseType.SelectedItem);
                    cmd.Parameters.AddWithValue("@amount", txtExpenseAmount.Text);
                    cmd.Parameters.AddWithValue("@details", txtExpenseDetails.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //empty textBoxes after Update information
                    btnExpenseAddNew_Click(this, null);

                }
            }
        }

        private void dgvExpenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // hide button save
                btnExpenseSave.Visible = false;
                //show update and delete button
            //    btnExpenseDelete.Visible = true;
            //    btnExpenseUpdate.Visible = true;

                int index = e.RowIndex; // get selected row index
                DataGridViewRow selectedRow = dgvExpenses.Rows[index];
                string id = selectedRow.Cells[0].Value.ToString();
                query = "select *from Expenses where ExpenseID='" + id + "'"; ;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {   //get value from databae and intialize to textboxs
                    txtExpenseID.Text = reader["ExpenseID"].ToString();

                    DateTime getExpenseDate = DateTime.Parse(reader["Date"].ToString());
                    dateTimePickerExpenseDate.Value = getExpenseDate;

                    comboBoxExpenseType.SelectedItem = reader["Type"].ToString();

                    double expenseAmount =double.Parse( reader["Amount"].ToString());
                    txtExpenseAmount.Text = expenseAmount.ToString("0.00");

                    txtExpenseDetails.Text = reader["Details"].ToString();

                    reader.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExpenseDelete_Click(object sender, EventArgs e)
        {
            string id = txtExpenseID.Text;

            if (MessageBox.Show("Are you sure want to delete record against this Expense Id: " + id, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                query = "Delete Expenses where ExpenseID=' "+id+"' ";


                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                //empty textBoxes after delete information
                btnExpenseAddNew_Click(this, null);


            }
        }

        private void txtExpensesSearch_TextChanged(object sender, EventArgs e)
        {
            string value = txtExpensesSearch.Text;
            if (value == "")
            {
                dgvExpenses.Rows.Clear();

                dgvExpenses.Refresh();
                DisplayExpenses();
            }
            else
            {
                dgvExpenses.Rows.Clear();
                dgvExpenses.Refresh();
                ExpneseSearch(value);
            }
        }

        private void ExpneseSearch(string value)
        {

            int totalListOfExpenses = 0;
            try
            {
                query = "select ExpenseID,Date,Type, Amount, Details  from Expenses WHERE Date Like '%" + value + "%' OR Type Like '%" + value + "%'";
          
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                System.Data.DataTable dt = new System.Data.DataTable(); // used for datagrid view
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dgvExpenses.Rows.Add(); //datagridviewName total rows

                    dgvExpenses.Rows[n].Height = 25;
                    //   dgvExpenses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvExpenses.Rows[n].Cells[0].Value = item["ExpenseID"].ToString();

                    string EntryDate = item["Date"].ToString();
                    DateTime expenseDate = DateTime.Parse(EntryDate);
                    dgvExpenses.Rows[n].Cells[1].Value = expenseDate.ToString("dd-MM-yyyy");

                    dgvExpenses.Rows[n].Cells[2].Value = item["Type"].ToString();

                    Double expenseAmount = double.Parse(item["Amount"].ToString());
                    dgvExpenses.Rows[n].Cells[3].Value = expenseAmount.ToString("0.00");
                    dgvExpenses.Rows[n].Cells[4].Value = item["Details"].ToString();

                    //gridview Formatting zebra color(odd even rows)
                    if (n % 2 == 0)
                    {
                        dgvExpenses.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); ;//light gray
                    }
                    else
                    {
                        dgvExpenses.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);//white
                    }
                }
                con.Close();
                totalListOfExpenses = dgvExpenses.Rows.Count;
                lblTotalListOfExpenses.Text = Convert.ToString(totalListOfExpenses); //datagridviewName

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }



          
        }

        private void txtProductFullViewSearch_TextChanged(object sender, EventArgs e)
        {
            string value = txtProductFullViewSearch.Text;
            if (value == "")
            {
              //  dgvProductsFullView.Rows.Clear();
                dgvProductsFullView.Refresh();
          
            }
            else
            {

             //  dgvProductsFullView.Rows.Clear();
                dgvProductsFullView.Refresh();
                SearchProductFullView(value);
            }
        }

        private void SearchProductFullView(string value)
        {
            int totalProductstoReorder = 0;

            try
            {
                SqlConnection con = new SqlConnection(cs);
               SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SaerchInViewAllStockIn";
                cmd.Parameters.Add("@value", SqlDbType.VarChar, 50).Value = value;

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable(); // used for datagrid view
                sda.Fill(dt);
                dgvProductsFullView.AutoGenerateColumns = false;
                dgvProductsFullView.DataSource = dt;
                con.Close();
                totalProducts = dgvProductsFullView.Rows.Count;
                lblProductFullViewTotalProducts.Text = Convert.ToString(totalProducts); //datagridviewName
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInsertNewProductMenu_Click(object sender, EventArgs e)
        {
            nTabControlStock.SelectedIndex = 1;
            btnProductAddNew.PerformClick();
           

        }

        bool lockedEditProduct=true;
        private void btnInsertNewProductMenu_MouseEnter(object sender, EventArgs e)
        {
            btnInsertNewProductMenu.ForeColor = Color.FromArgb(89, 169, 222);
            lockedEditProduct = true;
        }

        private void btnInsertNewProductMenu_MouseLeave(object sender, EventArgs e)
        {
            btnInsertNewProductMenu.ForeColor = Color.White;
        }

        private void btnEditProductMenu_MouseEnter(object sender, EventArgs e)
        {
            btnEditProductMenu.ForeColor = Color.FromArgb(89, 169, 222);
        }

        private void btnEditProductMenu_MouseLeave(object sender, EventArgs e)
        {
            btnEditProductMenu.ForeColor = Color.White;
        }

        private void btnViewProductMenu_MouseEnter(object sender, EventArgs e)
        {
            btnViewProductMenu.ForeColor = Color.FromArgb(89, 169, 222);
        }

        private void btnViewProductMenu_MouseLeave(object sender, EventArgs e)
        {
            btnViewProductMenu.ForeColor = Color.White;
        }

        private void btnBackProductForm_Click(object sender, EventArgs e)
        {
            nTabControlStock.SelectedIndex = 0;
            
        }

        private void btnEditProductMenu_Click(object sender, EventArgs e)
        {
            lockedEditProduct = false;
            nTabControlStock.SelectedIndex = 1;
            btnDgvProductsBack.PerformClick();
            btnSaveProduct.Visible = false;
            btnSupplierAddNew.Visible = false;
        }

        private void btnViewProductMenu_Click(object sender, EventArgs e)
        {
           
            
            nTabControlStock.SelectedIndex = 2;
            cmBoxViewStockInBy.SelectedIndex = 0;
          
        }





        //load Categories Method
        public void LoadProductCategoriesComboBox( )
        {
            try
            {
                string query = "select CategoryID, Name from Categories order by CategoryID desc";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Categories");
                cmboxProductCategory.ValueMember = "CategoryID";
                cmboxProductCategory.DisplayMember = "Name";
                cmboxProductCategory.DataSource = ds.Tables["Categories"];
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        

        }
        private void LoadProductSuppliersComboBox()
        {
            try
            {
                string query = "select SupplierID,SupplierName from Suppliers order by SupplierID desc";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Suppliers");
                cmBoxProductSuppliers.ValueMember = "SupplierID";
                cmBoxProductSuppliers.DisplayMember = "SupplierName";
                cmBoxProductSuppliers.DataSource = ds.Tables["Suppliers"];
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int startrow = 0;
        int CountPage = 0;
        int RowsPerPage = 16;
        int totalrecords;
        int totalPage;
        private void btnDgvProductsBack_Click(object sender, EventArgs e)
        {
            DisplayProducts();
            totalrecords = int.Parse(dgvProductsTotalRecords);
            totalPage = totalrecords / RowsPerPage;

            if (totalrecords % RowsPerPage != 0)
               totalPage= totalPage+1;
            //--------------------------------
            CountPage --;
            startrow = startrow - RowsPerPage;
            if (startrow <= 0)
            {
                startrow = 0;
                CountPage = 1;
            }
             DsProductsbasicInfo.Clear();
            SdaGetProductsbasicInfo.Fill(DsProductsbasicInfo, startrow, RowsPerPage, "Products");
            lblDgvProductsPages.Text = string.Format("Page {0} of {1}", CountPage,totalPage);

        }

        private void btnDgvProductsNext_Click(object sender, EventArgs e)
        {
            //----------------------page counter
            totalrecords = int.Parse(dgvProductsTotalRecords);
            totalPage = totalrecords / RowsPerPage;
            CountPage++;
            if (totalrecords % RowsPerPage != 0)
                totalPage = totalPage + 1;
            //------------------------------------


            startrow = startrow + RowsPerPage;
           if (startrow > int.Parse(dgvProductsTotalRecords))
            {
                CountPage=1;
                startrow = 0;
            }
            DsProductsbasicInfo.Clear();
            SdaGetProductsbasicInfo.Fill(DsProductsbasicInfo, startrow, RowsPerPage, "Products");
            lblDgvProductsPages.Text = string.Format("Page {0} of {1}", CountPage, totalPage);


        }



        //product Save/Insert
        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            // Check If Form Fields or Empty then display Warning message
            if (txtProductBarcode.Text == "" || txtProductName.Text == "" || txtProductUnitPriceActual.Text == "" || txtProductTotalUnits.Text == "" || txtProductReorderLevel.Text == "" || txtProductWeight.Text == "" || txtProductUnitPriceToSell.Text == "" )
            {
                MessageBox.Show("Failure: Product Information Can not be Saved!\nRequired Complete Information", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

               try
                {

                    string ProductActive;
                    if (checkBoxProductStatus.Checked == true)
                    {
                        ProductActive = "yes";
                    }
                    else
                    {
                        ProductActive = "no";
                    }

                    string productName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtProductName.Text.ToLower());
                    query = "insert into Products(Barcode,EntryDate,ProductName, Weight, TotalUnits, UnitPriceActual, UnitPriceToSell, CategoryID_FK, Season, SupplierID_FK, ReorderLevel,  Comments,SavedBy,Active ) values('" + txtProductBarcode.Text + "','" + dateTimePickerProductEntryDate.Value.ToString("yyyy-MM-dd") + "','" + productName + "','" + txtProductWeight.Text + "','" + txtProductTotalUnits.Text + "','" + txtProductUnitPriceActual.Text + "','" + txtProductUnitPriceToSell.Text + "','" + cmboxProductCategory.SelectedValue + "','" +cmBoxSeason.SelectedItem + "','" + cmBoxProductSuppliers.SelectedValue + "','" + txtProductReorderLevel.Text + "','" + txtProductComments.Text + "','" + userName + "','"+ProductActive+"')";
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                 
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Success: Product Information Has Been Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Reset Form and GridView Refresh after saving information
                   btnProductAddNew_Click(this, null);
                  

               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message+"");
               }
            }//end else
        }

        private void cmBoxViewStockInBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                int value = cmBoxViewStockInBy.SelectedIndex;
                switch (value)
                {
                    case 0:
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ViewDailyStockIn";
                        break;
                    case 1:
                        //weekly
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ViewWeeklyStockIn";
                        break;
                    case 2:
                        //do Monthly
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ViewMonthlyStockIn";
                        break;
                    case 3:
                        // "Active"
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ViewActiveStockIn";
                        break;
                    case 4:
                        // "Deactive"
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ViewDeactiveStockIn";
                        break;
                    case 5:
                        // "All"
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ViewAllStockIn";
                        break;

                    default:
                        //All
                        break;
                }


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable(); // used for datagrid view
              
                sda.Fill(dt);
                dgvProductsFullView.AutoGenerateColumns = false;
                dgvProductsFullView.DataSource = dt;
                con.Close();
                totalProducts = dgvProductsFullView.Rows.Count;
                lblProductFullViewTotalProducts.Text = Convert.ToString(totalProducts); //datagridviewName

            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBackReoderToProductsMenu_Click(object sender, EventArgs e)
        {
            nTabControlStock.SelectedIndex = 0;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            nTabControlStock.SelectedIndex = 3;
            RvProductsToReorder.LocalReport.Refresh();
        }

        private void nTabControlStock_Enter(object sender, EventArgs e)
        {
           
        }

        private void btnReportsStockIn_Click(object sender, EventArgs e)
        {
            nTabControlStock.SelectedIndex = 4;
        }

        private void btnBackReportStockin_Click(object sender, EventArgs e)
        {
            nTabControlStock.SelectedIndex = 0;
        }

        private void btnStockInSearchBetween_Click(object sender, EventArgs e)
        {
            string dtFrom = dtStockInFrom.Value.ToString("yyyy-MM-dd");
            string dtTo = dtStockInTo.Value.ToString("yyyy-MM-dd");
            SqlConnection con = new SqlConnection(cs);
            System.Data.DataTable dt = new System.Data.DataTable();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("ViewStockInBetween", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@dtFrom", dtFrom);
                cmd.Parameters.AddWithValue("@dtTo", dtTo);
                SqlDataAdapter sda = new SqlDataAdapter(cmd); // execute cmd 
                sda.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


           RvStockin.Visible = true;
         //  RvStockin.LocalReport.ReportPath = "StockInBetweenReport.rdlc";
            Microsoft.Reporting.WinForms.LocalReport report = new Microsoft.Reporting.WinForms.LocalReport();
            report.ReportEmbeddedResource = "StockInBetweenReport.rdlc";
            RvStockin.LocalReport.DataSources.Clear();
           RvStockin.LocalReport.DataSources.Add(new ReportDataSource("StockInBetweenDataSet", dt));
           RvStockin.RefreshReport();
          
        }

        private void btnNewSupplierMenu_Click(object sender, EventArgs e)
        {
            nTabControlSupplier.SelectedIndex = 1;
            btnSupplierUpdate.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            nTabControlSupplier.SelectedIndex = 0;
        }

        private void btnSearchSupplierMenu_Click(object sender, EventArgs e)
        {
            nTabControlSupplier.SelectedIndex = 2;
            cBoxViewTopSuppliers.SelectedIndex = 0;
            ViewSuppliersFullDetail(cBoxViewTopSuppliers);
            
        }

        private void dgvSuppliersFullView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnProductAddNewSupplier_Click_1(object sender, EventArgs e)
        {
            nTabControlStock.SelectedIndex = 5;
        }

        private void btnEditSupplierMenu_Click(object sender, EventArgs e)
        {
            btnSupplierUpdate.Visible = true;
            btnSupplierSave.Visible = false;
        }

        private void btnProductFullViewDeleteSelected_Click(object sender, EventArgs e)
        {

        }

        private void cBoxViewTopSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewSuppliersFullDetail(cBoxViewTopSuppliers);
        }

        private void btnSettingReorder_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ReorderLevel = txtReorderLevelSettings.Text;
            Properties.Settings.Default.Save();

        }

        private void btnSupplierBackStock_Click(object sender, EventArgs e)
        {
            nTabControlStock.SelectedIndex = 1;
        }

        private void cmboxProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ViewProductsToReorderBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void btnProductAddNewCategory_Click(object sender, EventArgs e)
        {
            

                // display your dialog somehow:
                ProductCategoryForm categoryForm = new ProductCategoryForm(cmboxProductCategory);
                
                categoryForm.StartPosition = FormStartPosition.CenterParent;
                categoryForm.ShowDialog();
         
           
        }

        private void btnProductAddNewSupplier_Click(object sender, EventArgs e)
        {
            tabControlMDI.SelectedIndex = 1;
        }
        //Dsplay products
        SqlDataAdapter SdaGetProductsbasicInfo;
        DataSet DsProductsbasicInfo;
        string dgvProductsTotalRecords;
        private void DisplayProducts()
        {
            try
            {

             
                lblTotalProductsToReorderValue.Text = "";
                query = "select ProductID,Barcode, ProductName, Weight, TotalUnits,UnitPriceActual,SupplierName,Active, FORMAT(EntryDate,'dd-MM-yyyy') as EntryDate from Products join Suppliers on SupplierID_FK=SupplierID ORDER BY CONVERT(DATE, EntryDate) desc ";
                SqlConnection con = new SqlConnection(cs);
                
                SdaGetProductsbasicInfo = new SqlDataAdapter(query, con);
                DsProductsbasicInfo = new DataSet();
                con.Open();
                SdaGetProductsbasicInfo.Fill(DsProductsbasicInfo, "Products");
                con.Close();
                dgvProducts.AutoGenerateColumns = false;
                //dgvProducts.Columns[0].DataPropertyName = "Barcode";
                //dgvProducts.Columns[1].DataPropertyName = "ProductName";
                //dgvProducts.Columns[2].DataPropertyName = "Weight";
                //dgvProducts.Columns[3].DataPropertyName = "TotalUnits";
                //dgvProducts.Columns[4].DataPropertyName = "SupplierName";
                //dgvProducts.Columns[5].DataPropertyName = "EntryDate";
                //dgvProducts.Columns[6].DataPropertyName = "Active";
                //binding data with dgv
                dgvProducts.DataSource = DsProductsbasicInfo;
                dgvProducts.DataMember = "Products";

                dgvProductsTotalRecords = dgvProducts.Rows.Count.ToString(); 
                DsProductsbasicInfo.Clear();


                MyAutoFunctions obj1 = new MyAutoFunctions();
                int totalProductstoReoder =obj1.GetValueOfStoreProcedure("TotalProductsToReorder", cs);
                lblTotalProductsToReorderValue.Text = Convert.ToString(totalProductstoReoder);
                lblTotalProducts.Text = Convert.ToString(dgvProductsTotalRecords); //datagridviewNam

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
       
        #endregion
        #endregion






    }// end MainForm
}//NameSpace
