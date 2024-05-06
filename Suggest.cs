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
    public partial class FrmSuggest : Form
    {
        public FrmSuggest()
        {
            InitializeComponent();
        }

        public SqlCommand cmd = new SqlCommand();
        public SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8VD3OG40\SQLEXPRESS01;Initial Catalog=LMS;Integrated Security=True");

        private void Clear() 
        {
            txtfullName.Text = "";
            txtSuggest.Text = "";
            txtfullName.Focus();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            this.Hide();
            frmDashboard.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           Clear();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtfullName.Text == "" || txtSuggest.Text == "")
            {
                MessageBox.Show("Please fill in the required fields", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string SaveQuery = "INSERT INTO Suggestion(fullname,suggest) " +
                        "VALUES('" + txtfullName.Text + "','" + txtSuggest.Text + "')";
                    con.Open();
                    cmd = new SqlCommand(SaveQuery, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seggestion Recorded Successfully", "Feedback", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Clear();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
