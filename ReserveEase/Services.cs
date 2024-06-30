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
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
        }

        private void DASHBOARD_Click(object sender, EventArgs e)
        {
            DASHBOARD aSHBOARD = new DASHBOARD();
            aSHBOARD.Show();
        }

        private void btnBss_Click(object sender, EventArgs e)
        {
            

        }

        private void btnInvv_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRmm_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            services.Show();


        }

        private void btnGss_Click(object sender, EventArgs e)
        {
            guestPage guestPage = new guestPage();
            guestPage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            roomAvailable roomAvailable = new roomAvailable();
            this.Hide();
            roomAvailable.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reservationForm reservationForm = new reservationForm();
            reservationForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            singleRate singleRate = new singleRate();
            this.Hide();
            singleRate.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            standartRate standartRate = new standartRate();
            this.Hide();
            standartRate.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            deluxeRate deluxeRate = new deluxeRate();
            this.Hide();
            deluxeRate.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DASHBOARD board = new DASHBOARD();
            this.Hide();
            board.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            guestPage guestP = new guestPage();
            this.Hide();
            guestP.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Services services = new Services();
            services.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            reservationForm reservationForm1 = new reservationForm();
            this.Hide();
            reservationForm1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            this.Hide();
            reportForm.Show();
        }
    }
}
