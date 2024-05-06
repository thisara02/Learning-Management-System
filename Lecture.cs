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

namespace Final_Project
{
    public partial class FrmLecture : Form
    {
        public FrmLecture()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://nie.lk/pdffiles/tg/eGr12TG%20ICT.pdf";

            // Open the URL in the default web browser
            Process.Start(url);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.nie.lk/pdffiles/tg/eGr13TG%20ICT.pdf";

            // Open the URL in the default web browser
            Process.Start(url);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://nie.lk/pdffiles/tg/eALSyl%20ICT.pdf";

            // Open the URL in the default web browser
            Process.Start(url);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.mathsapi.com/2020/05/advanced-level-ict-past-papers-and.html";

            // Open the URL in the default web browser
            Process.Start(url);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.youtube.com/live/TejLGD6-aUk?si=EKqH77jRN0Xcd26O";

            // Open the URL in the default web browser
            Process.Start(url);

        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.youtube.com/live/ggaH4PmdsJE?si=riFhzlcHwfizIQGP";

            // Open the URL in the default web browser
            Process.Start(url);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            this.Hide();
            frmDashboard.Show();
        }
    }
}
