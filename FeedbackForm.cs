using Final_Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class FrmRating : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-8VD3OG40\\SQLEXPRESS01;Initial Catalog=LMS;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        public FrmRating()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                    conn.Open();
                    cm = new SqlCommand("INSERT INTO tblFeedback(name,email,visited,P_Reason,needStatus) VALUES(@name,@email,@visited,@P_Reason,@needStatus)", conn);

                    cm.Parameters.AddWithValue("@name", textBox1.Text);
                    cm.Parameters.AddWithValue("@email", textBox2.Text);
                    cm.Parameters.AddWithValue("@visited", radioButton1.Checked ? "Yes" : "No");
                    cm.Parameters.AddWithValue("@P_Reason", textBox3.Text);
                    cm.Parameters.AddWithValue("@needStatus", checkBox1.Checked ? "Yes, all of it" : "No, none of it");
                    cm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Feedback Added successfully");
                Clear();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
              
                conn.Close();
              
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            this.Hide();
            frmDashboard.Show();
        }
    }
}
