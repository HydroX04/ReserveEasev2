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
    public partial class DASHBOARD : Form
    {
        public DASHBOARD()
        {
            InitializeComponent();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHomee_Click(object sender, EventArgs e)
        {
            WELCOME_PAGE wcpage = new WELCOME_PAGE();
            this.Hide();
            wcpage.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DASHBOARD aSHBOARD = new DASHBOARD();
            aSHBOARD.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            services.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            guestPage guestPage = new guestPage();
            guestPage.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dashBoardOut dashBoardOut = new dashBoardOut();
            this.Hide();
            dashBoardOut.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            guestPage guestPage = new guestPage();
            this.Hide();
            guestPage.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Services service = new Services();
            this.Hide();
            service.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            reservationForm reservationForm = new reservationForm();
            this.Hide();
            reservationForm.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            this.Hide();
            reportForm.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
