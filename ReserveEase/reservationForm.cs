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
    public partial class reservationForm : Form
    {
        public reservationForm()
        {
            InitializeComponent();
        }

        private void btnHmInvoice_Click(object sender, EventArgs e)
        {
            WELCOME_PAGE wELCOME_PAGE = new WELCOME_PAGE();
            this.Hide();
            wELCOME_PAGE.Show();
        }

        private void reservationForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
