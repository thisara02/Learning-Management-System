using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class frmloading : Form
    {
        public frmloading()
        {
            InitializeComponent();
        }

        private void frmloading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 5;

                lblLoad.Text = progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();

                frmRegister objForm2 = new frmRegister();

                MessageBox.Show("Welcome to Learning Management System", "Welcome!!!");
                this.Hide();
                objForm2.ShowDialog();
            }
        }

    }
}
