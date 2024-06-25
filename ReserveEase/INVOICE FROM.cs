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
    public partial class INVOICE_FROM : Form
    {
        public INVOICE_FROM()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            WELCOME_PAGE wELCOME_PAGE = new WELCOME_PAGE();
            wELCOME_PAGE.Show();
        }
    }
}
