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
   
    public partial class ReceiveOrdersForm : Form
    {
        //Variables
     public   string InvoiceID = string.Empty;
     public   DateTime InvoiceDate;
     public   double grossTotal=0; 
     public   double netTotal=0;
     public   double cashReceived;
     public   double cash;
     public   string CashReturn;
     public   string totalItems;
     public   int discount = 0;
     public   string discountRemarks=string.Empty;
     public   string customerPhone=string.Empty;
     public   string CustomerName = string.Empty;
     public   string customerCity = string.Empty;
     public   string customerCNIC = string.Empty;
     public   string query;
     public   string barcode;
     public   string productName;
     public   string weight;
     public   int    availableQty;
     public   int    inputQty=0;
     public   int    customerCartQty = 0;
     public   double unitPrice;
     public   int ReceivedCash=0;
     public   string paymentMode = string.Empty;
     public string cs = ConfigurationManager.ConnectionStrings["Connect_DB"].ToString(); // cs= connection string
    
     

        








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
        public ReceiveOrdersForm()
        {
            InitializeComponent();
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            cBoxPayment.SelectedIndex = 1;
            cboxCustomerType.SelectedIndex = 0;
            lblTime.Text = DateTime.Now.ToString("h:mm tt");
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");

            GetCustomerPhone();
            GetInvoiceID();
        }

        private void GetCustomerPhone()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Phone FROM Customers", con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }
                    txtRCPhone.AutoCompleteCustomSource = MyCollection;
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnReceiveOrderBack_Click(object sender, EventArgs e)
        {
            
           
            this.Hide();
           
        }

      

        private void btnORdersAddNeewCustomerBack_Click(object sender, EventArgs e)
        {
           
        }

        #region  Search Products
        
        private void ProductsSearch(string value)
        {
           
            try
            {
                query = "SELECT top(5) Barcode, ProductName, Weight, TotalUnits, UnitPriceToSell  FROM Products WHERE(Barcode Like '%" + value + "%' OR ProductName Like '%" + value + "%') and(TotalUnits != 0)  ";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                System.Data.DataTable dt = new System.Data.DataTable(); // used for datagrid view
                sda.Fill(dt);
                dgvProductsDetails.DataSource = dt;
                con.Close();
                int totalProducts = dgvProductsDetails.Rows.Count;
         


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion


        private void ReceiveOrdersForm_Load(object sender, EventArgs e)
        {
           
      
        }
        private void txtOrdersProductSearch_TextChanged(object sender, EventArgs e)
        {
            string value = txtOrdersProductSearch.Text;
            if (value == "")
            {
                
                ProductsSearch(value="Jugaar");
                txtSaleUnits.Text ="0";
            }
            else
            {
                ProductsSearch(value);
            }
        }
        private void txtCustomerCartDiscount_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (lblCustomerCartGrossTotal.Text == string.Empty || lblCustomerCartGrossTotal.Text == "0")
                {
                    //do nothing
                }

               else
                {
                    int discount = (txtCustomerCartDiscount.Text == string.Empty) ? 0 : int.Parse(txtCustomerCartDiscount.Text);
                    grossTotal = double.Parse(lblCustomerCartGrossTotal.Text);
                    netTotal = grossTotal - discount;
                    lblCustomerCartNetTotal.Text = netTotal.ToString("N2");
                    pnlCustomerDiscount.Height = 122;
                    if (ReceivedCash > 0)
                    {
                        lblReturnCash.Text = (netTotal - ReceivedCash).ToString("N2");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void btnOrdersProductRemoveOneCart_Click(object sender, EventArgs e)
        {
           
            
          
        }

        private void dgvCustomerCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnOrdersRemoveAllCart_Click(object sender, EventArgs e)
        {
            grossTotal = 0;
            netTotal = 0;
            txtCustomerCartDiscount.Text = "";
            lblCustomerCartTotalProducts.Text = "0";
            txtOrdersProductSearch.Text = "";
            dgvCustomerCart.Rows.Clear();           
            lblCustomerCartGrossTotal.Text = "0";
            lblCustomerCartNetTotal.Text = "0";
            txtSaleUnits.Text = "0";
            lblCName.Text = string.Empty;
            lblCPhone.Text = string.Empty;
            
            lblReturnCash.Text="0";
            txtReceivedCash.Text ="";
           
          
            
            pnlCustomerDiscount.Height = 55;
            pnlViewCustomerInfo.Visible = false;
            cBoxPayment.SelectedIndex = 1;
            cboxCustomerType.SelectedIndex = 0;

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        public void GetInvoiceID()
        {
            MyAutoFunctions f = new MyAutoFunctions();
            object value=f.GetStringValueOfStoreProcedure("SP_GetInvoiceID", cs);
            txtInvoiceID.Text = value.ToString();
            txtInvoiceID.Enabled = false;
        }

        private void dgvProductDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                //  int index = e.RowIndex;  //get selected index row
                this.dgvProductsDetails.CurrentRow.Selected = true;
                int index = dgvProductsDetails.CurrentRow.Index;
                DataGridViewRow selectedRow = dgvProductsDetails.Rows[index];
                //get values selected row of girdview
                barcode = selectedRow.Cells[0].Value.ToString();
                productName = selectedRow.Cells[1].Value.ToString();
                weight = selectedRow.Cells[2].Value.ToString();
                availableQty = int.Parse(selectedRow.Cells[3].Value.ToString());
                unitPrice = double.Parse(selectedRow.Cells[4].Value.ToString());

                //enabled textbox and button product details
                txtSaleUnits.Enabled = true;
                txtSaleUnits.Text = "1";
                btnAddToCart.Enabled = true;

                lblProductTotalAmount.Text = (unitPrice).ToString("N2");

                //Set focus
                txtSaleUnits.Focus();
                txtSaleUnits.BackColor = Color.Aqua;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                inputQty = 0;
                customerCartQty = 0;
                bool Found = false;
                inputQty = int.Parse(txtSaleUnits.Text);
                //Prevent if input qty is 0
                if (inputQty !=0)
                {
                    if (dgvCustomerCart.Rows.Count > 0)
                    {


                        foreach (DataGridViewRow row in dgvCustomerCart.Rows)
                        {
                            //Check if the product barcode exists 
                            if (row.Cells[0].Value.ToString() == barcode)
                            {
                                customerCartQty = customerCartQty + Convert.ToInt32(row.Cells[3].Value.ToString());

                                if (availableQty < (customerCartQty + inputQty))
                                {
                                    MessageBox.Show("Maximum Quantity Limit is: " + availableQty + "\nRemaining Quantity in Stock is: " + (availableQty - customerCartQty), "Product Name: " + row.Cells[1].Value, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                                else
                                {
                                    row.Selected = true;
                                   // row.DefaultCellStyle.BackColor = Color.Yellow;

                                    //Update the Quantity and total price of the found row
                                    row.Cells[3].Value = (customerCartQty + inputQty);
                                    row.Cells[5].Value = ((customerCartQty + inputQty) * unitPrice).ToString("N2");
                                    Found = true;
                                }
                            }
                        }//end for each loop

                        if (Found == false)
                        {
                            if (availableQty < (inputQty))
                            {
                                MessageBox.Show("Maximum Qty Limit is:" + availableQty + "\nRemaining Quantity in Stock is: " + (availableQty - customerCartQty), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            { //Add the row to grid view for New item
                                dgvCustomerCart.Rows.Insert(0, barcode, productName, weight, txtSaleUnits.Text, unitPrice.ToString("N2"), lblProductTotalAmount.Text);
                                dgvCustomerCart.Rows[0].Selected = true;
                            }
                        }

                    }// end if= row is exists in gridview
                    else
                    {
                        if (availableQty < Convert.ToUInt32(txtSaleUnits.Text))
                        {
                            MessageBox.Show("Maximum Qty Limit is:" + availableQty + "", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {  //Add the row to grid view for the first time
                            dgvCustomerCart.Rows.Insert(0, barcode, productName, weight, txtSaleUnits.Text, unitPrice, lblProductTotalAmount.Text);
                            dgvCustomerCart.Rows[0].Selected = true;
                        }
                    }

                }//end if input qty
                   
                //Update Total Products in Customer Cart
                lblCustomerCartTotalProducts.Text = Convert.ToString(dgvCustomerCart.RowCount);
                //Gross Total=get Total units price
                grossTotal = grossTotal + double.Parse(lblProductTotalAmount.Text);
                lblCustomerCartGrossTotal.Text = grossTotal.ToString("N2"); 
                //Calculate Net Amount
                lblCustomerCartNetTotal.Text = grossTotal.ToString("N2");
                netTotal = grossTotal;
                //Clear SearchBox
                txtOrdersProductSearch.Text = string.Empty;
                txtSaleUnits.Text = string.Empty;
                btnAddToCart.Enabled = false;  
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txtSaleUnits_TextChanged(object sender, EventArgs e)
        {

            string saleUnits =txtSaleUnits.Text;
            if (saleUnits == "0" || saleUnits=="")
            lblProductTotalAmount.Text = "0";
            else
                try
                {
                 lblProductTotalAmount.Text = (Convert.ToDouble(saleUnits) * unitPrice).ToString("N2");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(""+ex.Message, "Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }


        }

        private void btnCustomerAddNew_Click(object sender, EventArgs e)
        {
            txtCustomerPhoneNumber.Text = (txtRCPhone.Text != string.Empty &&  txtRCPhone.TextLength==11) ? txtRCPhone.Text:"";
            nTabControlCustomerInvoice.SelectedIndex = 1;
        }

        private void btnCustomerSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "" || txtCustomerPhoneNumber.Text == "")
            {
                MessageBox.Show("Customer Information Can not be Saved!\nRequired Complete Information", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_InsertCustomer", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text);
                            cmd.Parameters.AddWithValue("@Phone", txtCustomerPhoneNumber.Text);
                            cmd.Parameters.AddWithValue("@NIC", txtCustomerNIC.Text);
                            cmd.Parameters.AddWithValue("@City", txtCustomerCity.Text);
                            cmd.Parameters.AddWithValue("@Address", txtCustomerAddress.Text);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Customer Information has been Saved", "Congrates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            pnlViewCustomerInfo.Visible = true;
                            lblCName.Text = txtCustomerName.Text;
                            lblCPhone.Text = customerPhone;
                            nTabControlCustomerInvoice.SelectedIndex = 0;
                            
                           
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,"Catch Exception",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
           
        }

        private void txtSaleUnits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            { e.Handled = true; }
        }

        private void txtReceivedCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            { e.Handled = true; }
        }

       

        private void txtCustomerCartDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            { e.Handled = true; }
        }

        private void dgvProductsDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {

                    //  int index = e.RowIndex;  //get selected index row
                    this.dgvProductsDetails.CurrentRow.Selected = true;
                    int index = dgvProductsDetails.CurrentRow.Index;
                    DataGridViewRow selectedRow = dgvProductsDetails.Rows[index];
                    //get values selected row of girdview
                    barcode = selectedRow.Cells[0].Value.ToString();
                    productName = selectedRow.Cells[1].Value.ToString();
                    weight = selectedRow.Cells[2].Value.ToString();
                    availableQty = int.Parse(selectedRow.Cells[3].Value.ToString());
                    unitPrice = double.Parse(selectedRow.Cells[4].Value.ToString());

                    //enabled textbox and button product details
                    txtSaleUnits.Enabled = true;
                    txtSaleUnits.Text = "1";
                    btnAddToCart.Enabled = true;

                    lblProductTotalAmount.Text = Convert.ToString(unitPrice);

                    //Set focus
                    txtSaleUnits.Focus();
                    txtSaleUnits.BackColor = Color.Aqua;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                e.Handled = true; //if you don't want the datagrid from hearing the enter pressed
            }
        }

        private void dgvProductsDetails_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtReceivedCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ReceivedCash = (txtReceivedCash.Text=="") ? 0: int.Parse(txtReceivedCash.Text);
                if (txtReceivedCash.Text=="")
                {

                    cBoxPayment.SelectedIndex = 1;
                    lblReturnCash.Text = "0";
                }
                else
                {
                    
                    if (netTotal <= Convert.ToInt32(txtReceivedCash.Text) )
                    {
                       MessageBox.Show("net:" + netTotal + "\ncash" + Convert.ToInt32(txtReceivedCash.Text));
                      lblReturnCash.Text = Convert.ToString(netTotal - Convert.ToInt32(txtReceivedCash.Text));
                        cBoxPayment.SelectedIndex = 0;
                    }
                    else
                    {
                        cBoxPayment.SelectedIndex = 1;
                        lblReturnCash.Text = "0";

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtCustomerPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            { e.Handled = true; }
        }

        private void txtCustomerNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            { e.Handled = true; }
        }

      

       
       

        private void btnOrderNewCustomer_Click(object sender, EventArgs e)
        {
            nTabControlCustomerInvoice.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nTabControlCustomerInvoice.SelectedIndex = 0;
           
        }

        private void linklblDiscount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }
      
        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            try
            {

                //for Inoice
               this.InvoiceID = txtInvoiceID.Text;//must
               this.InvoiceDate =DateTime.Now ; //must
               this.grossTotal = double.Parse(lblCustomerCartGrossTotal.Text);//must
               this.netTotal = double.Parse(lblCustomerCartNetTotal.Text);//must 
               this.cashReceived = (txtReceivedCash.Text == "") ? 0 : double.Parse(txtReceivedCash.Text);
               this.discount = (txtCustomerCartDiscount.Text==string.Empty)?0:Convert.ToInt32(txtCustomerCartDiscount.Text); //optional
               this.discountRemarks = txtDiscountRemarks.Text; //optional
               this.paymentMode = cBoxPayment.SelectedItem.ToString();
               this.totalItems= dgvCustomerCart.Rows.Count.ToString();
               this.cash = (txtReceivedCash.Text == "") ? 0 : double.Parse(txtReceivedCash.Text);
               this.CashReturn = (lblReturnCash.Text == "") ? "0" : lblReturnCash.Text;
                this.CustomerName = (lblCName.Text == "") ? "Walk in Customer" : lblCName.Text;

               
               
              

                if (lblCustomerCartGrossTotal.Text == "" || lblCustomerCartGrossTotal.Text == "0" && lblCustomerCartNetTotal.Text == "" || lblCustomerCartNetTotal.Text == "0")
                {
                    MessageBox.Show("Customer Cart Is Empty", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    //for Customer Loan
                    if ((cashReceived < netTotal) && (customerPhone != string.Empty) && customerPhone.Length==11)
                    {
                        //Confirmation
                        DialogResult response = MessageBox.Show("Are you sure want to save customer order information", "[Customer-Loan] Invoice ID=" + InvoiceID, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (response == DialogResult.Yes)
                        {
                            //save order details 
                            SaveInvoice(cashReceived);
                        }
                    }
                    else
                   if ((cashReceived < netTotal) && (customerPhone == string.Empty))
                    {
                       if( MessageBox.Show("Received cash is less than Net Amount\n-------\nIf you want to execute as Customer Loan then press 'Yes'","Invoice ID="+txtInvoiceID.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)==DialogResult.Yes)
                        cboxCustomerType.SelectedIndex = 1;
                        else
                        cboxCustomerType.SelectedIndex = 0; 
                    }
                    //for Visitor
                    if ((cashReceived >= netTotal) && (customerPhone == ""))
                    {
                        //Confirmation
                        DialogResult response = MessageBox.Show("Are you sure want to save customer order information ", "[Visitor] Invoice ID= " + txtInvoiceID.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (response == DialogResult.Yes)
                        {

                            //save order details
                            cashReceived = netTotal; 
                            SaveInvoice(cashReceived);
                       }
                    }


                    //registered and netCash Customer 
                    if ((cashReceived >= netTotal) && customerPhone != string.Empty)
                    {
                        //Confirmation
                        DialogResult response = MessageBox.Show("Are you sure want to save customer order information ", "[Registered] Invoice ID= " + txtInvoiceID.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (response == DialogResult.Yes)
                        {
                            cashReceived = netTotal;
                            SaveInvoice(netTotal);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Catch Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
         public void SaveInvoice( double CashReceived)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlTransaction transaction = con.BeginTransaction())
                {

                    try
                    {
                        //Stored Procedures
                        SqlCommand cmdInvoice = new SqlCommand("SP_InsertInvoice", con, transaction);
                        SqlCommand cmdInvoiceDetails = new SqlCommand("SP_InsertInvoiceDetails", con, transaction);
                        SqlCommand cmdPayment = new SqlCommand("SP_InsertPaymentReceived", con, transaction);
                        SqlCommand cmdMinusQty = new SqlCommand("SP_MinusQtyFromProducts", con, transaction);
                        ////Command Types
                        cmdInvoice.CommandType = CommandType.StoredProcedure;
                        cmdInvoiceDetails.CommandType = CommandType.StoredProcedure;
                        cmdPayment.CommandType = CommandType.StoredProcedure;
                        cmdMinusQty.CommandType = CommandType.StoredProcedure;
                        //Parammeteres Invoice table
                        cmdInvoice.Parameters.AddWithValue("@InvoiceID", InvoiceID);
                        cmdInvoice.Parameters.AddWithValue("@InvoiceDate", InvoiceDate);
                        cmdInvoice.Parameters.AddWithValue("@CustomerPhone", customerPhone);
                        cmdInvoice.Parameters.AddWithValue("@GrossTotal", grossTotal);
                        cmdInvoice.Parameters.AddWithValue("@NetTotal", netTotal);
                        cmdInvoice.Parameters.AddWithValue("@PaymentMode", paymentMode);
                        cmdInvoice.Parameters.AddWithValue("@Disocunt", discount);
                        cmdInvoice.Parameters.AddWithValue("Remarks", discountRemarks);
                        cmdInvoice.ExecuteNonQuery();

                        //Parameters InvoiceDetails Table (get ProductBarcode and qty and unit price from CustomerCart GridView)
                        for (int i = 0; i < dgvCustomerCart.Rows.Count; i++)
                        {
                            cmdInvoiceDetails.Parameters.Clear();
                            //      MessageBox.Show("barcode" + dgvCustomerCart.Rows[i].Cells[0].Value.ToString() + "UnitPrice" + dgvCustomerCart.Rows[i].Cells["UnitPriceC"].Value);
                            cmdInvoiceDetails.Parameters.AddWithValue("@InvoiceID_Fk", InvoiceID);
                            cmdInvoiceDetails.Parameters.AddWithValue("@ProductBarcode_Fk", dgvCustomerCart.Rows[i].Cells[0].Value.ToString());
                            cmdInvoiceDetails.Parameters.AddWithValue("@TotalUnits", dgvCustomerCart.Rows[i].Cells["TotalUnitsC"].Value);
                            cmdInvoiceDetails.Parameters.AddWithValue("@UnitPriceToSell", dgvCustomerCart.Rows[i].Cells["UnitPriceC"].Value);
                            cmdInvoiceDetails.ExecuteNonQuery();

                        }

                        //Parameters PaymentReceived Table
                        cmdPayment.CommandType = CommandType.StoredProcedure;
                        cmdPayment.Parameters.AddWithValue("@InvoiceID", InvoiceID);
                        cmdPayment.Parameters.AddWithValue("@Date", InvoiceDate);
                        cmdPayment.Parameters.AddWithValue("@Cash", CashReceived);
                        cmdPayment.ExecuteNonQuery();

                        //Parameters MinusQtyFrom Product Table =get ProductBarcode and qty and unit price from CustomerCart GridView
                        for (int i = 0; i < dgvCustomerCart.Rows.Count; i++)
                        {
                            cmdMinusQty.Parameters.Clear();
                            cmdMinusQty.Parameters.AddWithValue("@Barcode", dgvCustomerCart.Rows[i].Cells[0].Value.ToString());
                            cmdMinusQty.Parameters.AddWithValue("@Qty", int.Parse(dgvCustomerCart.Rows[i].Cells["TotalUnitsC"].Value.ToString()));
                            cmdMinusQty.ExecuteNonQuery();

                        }


                        //Execture Store Procedured

                        transaction.Commit();
                        // SaveInvoice(InvoiceID, InvoiceDate, grossTotal, netTotal, discount, cashReceived, paymentMode, dgvCustomerCart, discountRemarks, customerPhone);
                      //  MessageBox.Show("Success! Customer Invoice infromation has been saved ", "Invoice ID= " + txtInvoiceID.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PrintForm pf = new PrintForm(totalItems, cash, CashReturn,this.CustomerName); ;
                        pf.ShowDialog();
                        btnOrdersRemoveAllCart.PerformClick();
                        GetInvoiceID();
                }
                    catch (SqlException ex)
                {
                   // throw;
                    // transaction.Rollback();
                   MessageBox.Show(ex.Message, "Catch Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            }
        }
       

        private void cboxPhoneCustomerOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboxCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboxCustomerType.SelectedIndex)
            {
                case 0:
                    nTabControlCustomerInvoice.SelectedIndex = 0;
                    txtRCPhone.Text = "";
                    customerPhone = string.Empty;
                   
                break;
                case 1:
                    nTabControlCustomerInvoice.SelectedIndex = 2;
                    txtRCPhone.Text = "";
                    GetCustomerPhone();
                    break;

            }
        }

        private void btnDisc_Click(object sender, EventArgs e)
        {
        
            if(pnlCustomerDiscount.Height == 122)
            {
                pnlCustomerDiscount.Height = 55;
                btnDisc.Text = "+Discount";
            }
            else
            {
                pnlCustomerDiscount.Height =122;
                btnDisc.Text = "-Discount";

            }
          

        }

        private void btnRCBack_Click(object sender, EventArgs e)
        {
            txtCustomerPhoneNumber.Text =txtRCPhone.Text ;
            customerPhone = txtRCPhone.Text;

            if (customerPhone.Length == 11)
            {
                try
                {
                    //Check if customer is already registered 
                    using (SqlConnection con = new SqlConnection(cs))
                    {

                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT top(1) Name,Phone FROM Customers WHERE Phone ='" + customerPhone+"'", con))
                        {
                            var  reader = cmd.ExecuteReader();
                            //if exist
                            if (reader.Read())
                            {

                             MessageBox.Show("Information has been received","Registerd", MessageBoxButtons.OK,MessageBoxIcon.Information);
                                CustomerName = reader["Name"].ToString();
                                customerPhone = reader["Phone"].ToString();
                                lblCName.Text = CustomerName;
                                lblCPhone.Text = customerPhone;
                                nTabControlCustomerInvoice.SelectedIndex = 0;
                                pnlViewCustomerInfo.Visible = true;
                               
                            }
                            //not exist
                            else
                            {
                                  MessageBox.Show(" Customer Information is not exist against this Phone number: "+customerPhone, "Please Register Customer Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                  nTabControlCustomerInvoice.SelectedIndex = 1;

                                pnlViewCustomerInfo.Visible = false;
                                txtCustomerAddress.Text = string.Empty;
                                txtCustomerName.Text = string.Empty;
                                txtCustomerCity.Text = string.Empty;
                                txtCustomerNIC.Text = string.Empty;
                            }

                        }
                    }
                }//end if
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Incomplete Phone Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnRLBack_Click(object sender, EventArgs e)
        {
            nTabControlCustomerInvoice.SelectedIndex = 0;
        }

        private void dgvCustomerCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (this.dgvCustomerCart.SelectedRows.Count > 0)
            {
                int index = e.RowIndex;
                dgvCustomerCart.Rows.RemoveAt(index);

                //update grosstotal price calculate sum of price colum of datagridviewc
                 grossTotal= dgvCustomerCart.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["TotalUnitsPriceC"].Value));
                netTotal = grossTotal;
                lblCustomerCartGrossTotal.Text = grossTotal.ToString("N2");
                lblCustomerCartNetTotal.Text = grossTotal.ToString("N2");
                 
                txtCustomerCartDiscount.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please select one row");
            }
        }

        private void txtRCPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                btnRCBack.PerformClick();
            }
        }

        private void txtCustomerCartDiscount_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            { e.Handled = true; }
        }
    }
}
