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
            wcpage.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DASHBOARD aSHBOARD = new DASHBOARD();
            aSHBOARD.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BOOK_NOW bOOK_NOW = new BOOK_NOW();
            bOOK_NOW.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            services.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            INVOICE_FROM iNVOICE_FROM = new INVOICE_FROM();
            iNVOICE_FROM.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            guestPage guestPage = new guestPage();
            guestPage.Show();
        }
    }
}
