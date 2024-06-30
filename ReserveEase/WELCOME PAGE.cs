using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveEase
{
    public partial class WELCOME_PAGE : Form
    {
        public WELCOME_PAGE()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LOGIN_FORMM login = new LOGIN_FORMM();
            this.Hide();
            login.Show();
            

        }

        

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            DASHBOARD dashb = new DASHBOARD();
            this.Hide();
            dashb.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            reservationForm reservationForm = new reservationForm();
            this.Hide();
            reservationForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            this.Hide();
            services.Show();
 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            guestPage guestPage = new guestPage();
            this.Hide();
            guestPage.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            contactUS contactUS = new contactUS();
            this.Hide();
            contactUS.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            aboutUS aboutUS = new aboutUS();
            this.Hide();
            aboutUS.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            this.Hide();
            reportForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}