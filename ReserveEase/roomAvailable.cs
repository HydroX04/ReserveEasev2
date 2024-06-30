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
    public partial class roomAvailable : Form
    {
        public roomAvailable()
        {
            InitializeComponent();
        }

        private void btnCU_Click(object sender, EventArgs e)
        {
            WELCOME_PAGE wELCOME_PAGE = new WELCOME_PAGE();
            wELCOME_PAGE.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            reservationForm reservationForm = new reservationForm();
            reservationForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reservationForm reservationForm = new reservationForm();
            reservationForm.Show();
        }
    }
}
