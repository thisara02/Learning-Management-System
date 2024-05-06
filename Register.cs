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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final_Project
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        string gender;

        public DataSet Dset = new DataSet();
        public SqlDataAdapter sqlda = new SqlDataAdapter();
        public SqlCommand cmd = new SqlCommand();
        public SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8VD3OG40\SQLEXPRESS01;Initial Catalog=LMS;Integrated Security=True");

        private void Clear()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            dtpDOB.ResetText();
            rbMale.Checked = false;
            rbFemale.Checked = false;
            txtPassword.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtMobilePhone.Text = "";
            txtHomePhone.Text = "";
            txtParentName.Text = "";
            txtNIC.Text = "";
            txtContactNumber.Text = "";
            txtFirstName.Focus();
        }

        private void LoadIDs()
        {
            try
            {
                string query = "SELECT regNo FROM Student_Register ORDER BY regNo";
                con.Open();
                sqlda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                sqlda.Fill(dt);
                con.Close();

                cmbRegNo.Items.Clear();
                cmbRegNo.Items.Add("-SELECT-");
                foreach (DataRow dr in dt.Rows)
                {
                    cmbRegNo.Items.Add(dr["regNo"]);
                }
                cmbRegNo.SelectedIndex = 0;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtFirstName.Text == "" || txtAddress.Text == "" || txtEmail.Text == "" || txtMobilePhone.Text == "" 
                || txtHomePhone.Text == "" || txtParentName.Text == "" || txtNIC.Text == "" || txtContactNumber.Text == "" || dtpDOB.Value == DateTime.Today || txtPassword.Text =="")
            {
                MessageBox.Show("Please fill in the required fields", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (rbMale.Checked == true)
                    {
                        gender = "Male";
                    }
                    else if (rbFemale.Checked == true)
                    {
                        gender = "Female";
                    }

                    string SaveQuery = "INSERT INTO Student_Register(firstName,lastName,dateOfBirth,gender,password,address,email,mobilePhone,homePhone,parentName,nic,contactNo) " +
                        "VALUES('" + txtFirstName.Text + "','" + txtLastName.Text + "','" + dtpDOB.Text + "','" + gender + "','" + txtPassword.Text + "','" + txtAddress.Text + "','" + txtEmail.Text + 
                        "','" + txtMobilePhone.Text + "','" + txtHomePhone.Text + "','" + txtParentName.Text + "','" + txtNIC.Text + "','" + txtContactNumber.Text + "')";
                    con.Open();
                    cmd = new SqlCommand(SaveQuery, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Added Successfully", "Register Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Clear();
                }
                catch(Exception error)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtFirstName.Text == "" || txtAddress.Text == "" || txtEmail.Text == "" || txtMobilePhone.Text == "" 
                || txtHomePhone.Text == "" || txtParentName.Text == "" || txtNIC.Text == "" || txtContactNumber.Text == "" || dtpDOB.Value == DateTime.Today || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill in the required fields", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else
            {
                try
                {
                    if (rbMale.Checked == true)
                    {
                        gender = "Male";
                    }
                    else if (rbFemale.Checked == true)
                    {
                        gender = "Female";
                    }

                    string UpdateQuery = "UPDATE Student_Register SET firstName='" + txtFirstName.Text + "',lastNAme='" + txtLastName.Text + "',dateOfBirth='" + dtpDOB.Text + 
                        "',gender='" + gender + "',password='" + txtPassword.Text + "',address='" + txtAddress.Text + "',email='" + txtEmail.Text + "',mobilePhone='" + txtMobilePhone.Text + "',homePhone='" +
                        txtHomePhone.Text + "',parentName='" + txtParentName.Text + "',nic='" + txtNIC.Text + "',contactNo='" + txtContactNumber.Text + "' WHERE regNo='" + cmbRegNo.Text + "'";
                    con.Open();
                    cmd = new SqlCommand(UpdateQuery, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res =MessageBox.Show("Are you sure,Do you really want to Delete this Record...?","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (cmbRegNo.Text == "")
                {
                    MessageBox.Show("Please Select a Student to Delete..?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRegNo.Focus();
                }
                if (cmbRegNo.Text == "-SELECT-")
                {
                    MessageBox.Show("Please Select a Student to Delete..?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRegNo.Focus();
                }

                try
                {
                    string DeleteQuery = "DELETE FROM Student_Register WHERE regNo='" + cmbRegNo.Text + "'";
                    con.Open();
                    cmd = new SqlCommand(DeleteQuery, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Deleted Successfully", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Clear();
                    LoadIDs();
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
            else
            {
                Clear();
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Clear();
            cmbRegNo.Visible = true;
            lblRegNo.Visible=true;
            btnClose.Visible = true;
            btnSearch.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnClear.Visible = false;
            btnRegister.Visible = false;
            cmbRegNo.Focus();
            LoadIDs() ;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Clear();
            cmbRegNo.Visible = false;
            lblRegNo.Visible = false;
            btnClose.Visible = false;
            btnSearch.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnClear.Visible = true;
            btnRegister.Visible = true;
            txtFirstName.Focus();
        }

        private void cmbRegNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cmbRegNo.SelectedIndex > 0)
                {
                    string getDetails ="SELECT * FROM Student_Register WHERE regNo='" + cmbRegNo.SelectedItem + "'";
                    con.Open();
                    cmd = new SqlCommand(getDetails,con);
                    SqlDataReader r = cmd.ExecuteReader();
                    if (r.Read())
                    {
                        txtFirstName.Text = r.GetValue(1).ToString();
                        txtLastName.Text = r.GetValue(02).ToString();
                        dtpDOB.Value=Convert.ToDateTime(r.GetValue(3).ToString());
                        if (r.GetValue(4).ToString() == "Male")
                        {
                            rbMale.Checked = true;
                            rbFemale.Checked = false;
                        }
                        else
                        {
                            rbMale.Checked = false;
                            rbFemale.Checked = true;
                        }
                        txtPassword.Text = r.GetValue(5).ToString();
                        txtAddress.Text = r.GetValue(6).ToString();
                        txtEmail.Text = r.GetValue(7).ToString();
                        txtMobilePhone.Text = r.GetValue(8).ToString();
                        txtHomePhone.Text = r.GetValue(9).ToString();
                        txtParentName.Text = r.GetValue(10).ToString();
                        txtNIC.Text = r.GetValue(11).ToString();
                        txtContactNumber.Text = r.GetValue(12).ToString();
                    }
                    con.Close();
                }
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

        private void linkLabelExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure, Do You Really want to Exit...?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure, Do You want to Logout...?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                FrmLogin objlog = new FrmLogin();
                this.Hide();
                objlog.Show();
                
            }
        }


    }
}
