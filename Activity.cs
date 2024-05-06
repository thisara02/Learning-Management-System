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
    public partial class FrmActivity : Form
    {
        public FrmActivity()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure, Do You want to Exit...?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                FrmDashboard objdash = new FrmDashboard();
                this.Hide();
                objdash.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmQuiz objquiz = new FrmQuiz();
            this.Hide();
            objquiz.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmQuiz2 objquiz2 = new FrmQuiz2();
            this.Hide();
            objquiz2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmQuiz3 objquiz3 = new FrmQuiz3();
            this.Hide();
            objquiz3.Show();
        }
    }
}
