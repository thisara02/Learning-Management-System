using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Final_Project
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure, Do You want to Logout...?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                FrmWelcome objwel = new FrmWelcome();
                this.Hide();
                objwel.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure, Do You Really want to Exit...?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmRating objrate = new FrmRating();
            this.Hide();
            objrate.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmLecture objlec = new FrmLecture();
            this.Hide();
            objlec.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmActivity objactivity = new FrmActivity();
            this.Hide();
            objactivity.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSuggest objsuggest = new FrmSuggest();
            this.Hide();
            objsuggest.Show();
        }
    }
}
