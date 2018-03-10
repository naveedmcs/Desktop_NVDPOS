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
using System.Net; // internet network 
using System.Net.Mail; //used for sending email

namespace POS_Project
{
    public partial class LoginForm : Form
    {
        #region variables 
        public  string cs = "Data Source =.\\SQLEXPRESS; Initial Catalog = POSNayaSaveraDB; Integrated Security = True"; // cs= connection string
                string userName = string.Empty;
                string email = string.Empty;
                string password = string.Empty;
                string userStatus = string.Empty;
                string query = string.Empty;
        #endregion

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
        public LoginForm()
        {
            InitializeComponent();
            #region transparent labels on imageConntrol
            lblCompanyName.Parent = picBoxFormBg;
            lblCompanyName.BackColor = Color.Transparent;
            lblCompanyDetails.Parent = picBoxFormBg;
            lblCompanyDetails.BackColor = Color.Transparent;
            #endregion
           // this.UseWaitCursor = true;

        }
       
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // if textbox is empty then ask to provide details
            if (txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please provide Email and Password","User Account Login",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            else
            {
                // fetch data from database comaper with user input if true then login else login failed
                try
                {
                    email = txtEmail.Text;
                    password = txtPassword.Text;
                    query = "SELECT Status, Name FROM Users Where Email=@email and Password=@password";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@email",email);
                    cmd.Parameters.AddWithValue("@password",password);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();

                    int count = ds.Tables[0].Rows.Count;

                    if (ds != null && count == 1)
                    {
                        // store values to variables from database fields
                       
                        userName = ds.Tables[0].Rows[0]["Name"].ToString();
                        userStatus = ds.Tables[0].Rows[0]["Status"].ToString();

                        MessageBox.Show("User Status:" + userStatus+ "\nLogin Successful!", "User Account Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Hide();
                        if (userStatus == "Admin") //case sensitve
                        {
                            MainForm mf = new MainForm(/*userStatus, userName*/);
                            this.Hide();
                            mf.ShowDialog();
                        }
                        else if (userStatus == "Employee") //case sensitive
                        {
                            MainForm mf = new MainForm(/*userStatus, userName*/);
                            this.Hide();
                            mf.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email or Password incorrect, Please Try agian!","User Account Login",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // output the error to see what's going on
                    MessageBox.Show(ex.Message);
                }
            }
           

        }

   
        private void linklblForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // if textbox is empty then ask to provide details
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please provide Valid Registered Email");
                return;
            }
            else
            {
               sendPasswordRecoveryEmail();
                this.UseWaitCursor = true;
            }
           
        }

        void sendPasswordRecoveryEmail() // password recovery function
        {

            if (!string.IsNullOrEmpty(email))
            {
                NetworkCredential login;
                SmtpClient client;
                MailMessage msg;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You sure to want to close Application", "closeApp", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // The user wants to exit the application. Close everything down.
                Application.Exit();
            }

        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Properties.Resources.closehover;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Properties.Resources.closedefualt;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMinimize_MouseEnter(object sender, EventArgs e)
        {
            btnMinimize.BackgroundImage = Properties.Resources.minimizehover;
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.BackgroundImage = Properties.Resources.minimize;
        }

        private void lblLinkForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nTabControlLogin.SelectedIndex = 1;
        }

        private void linklblUserLoginBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nTabControlLogin.SelectedIndex = 0;
        }

        private void btnPasswordReset_Click(object sender, EventArgs e)
        {
            MessageBox.Show( "This Function is still in Process ","Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
