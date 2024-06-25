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
            BOOK_NOW  bOOK_NOW = new BOOK_NOW();
            bOOK_NOW.Show();

        }

        private void btnInvv_Click(object sender, EventArgs e)
        {
            INVOICE_FROM  iNVOICE_FROM = new INVOICE_FROM();
            iNVOICE_FROM.Show();
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
    }
}
