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
    public partial class deluxeRate : Form
    {
        public deluxeRate()
        {
            InitializeComponent();
        }

        private void btnHomeg_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            this.Hide();
            services.Show();
        }
    }
}
