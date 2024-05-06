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


namespace Final_Project
{
    public partial class FrmStudLogin : Form
    {
        public FrmStudLogin()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8VD3OG40\SQLEXPRESS01;Initial Catalog=LMS;Integrated Security=True");

        private void Clear()
        {
            txtuname.Text = "";
            txtpass.Text = "";
            txtuname.Focus();
        }

        private void btnlogin2_Click(object sender, EventArgs e)
        {
            string username, pw;

            username = txtuname.Text;
            pw = txtpass.Text;

            try
            {
                string query = "SELECT firstName,password FROM Student_Register WHERE firstName='" + txtuname.Text + "' AND password='" + txtpass.Text + "'";

                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pw))
                {
                    MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                if (dt.Rows.Count > 0)
                {
                    FrmDashboard objDash = new FrmDashboard();
                    this.Hide();
                    objDash.Show();
                }
                else
                {
                    MessageBox.Show("Invalid login credintials,please check Username and Password and try again", "Invalid Login Deatils", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Found!" + error, "Login Error");
            }
            finally
            {
                con.Close();
            }
        }

        private void btnclear1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmWelcome objwel = new FrmWelcome();
            this.Hide();
            objwel.Show();
        }

        private void cbshow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbshow.Checked == true)
            {
                txtpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
            }
        }
    }
}
