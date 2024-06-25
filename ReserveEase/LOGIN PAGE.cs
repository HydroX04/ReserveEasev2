using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveEase
{
    public partial class LOGIN_FORMM : Form
    {
        public LOGIN_FORMM()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string id = txtNameID.Text;
            string pass = txtPassword.Text;

            if (id == "125" && pass == "123456")
            {
                WELCOME_PAGE f = new WELCOME_PAGE();
                f.Show();
            }
            else
            {
                MessageBox.Show("Password or Email is  incorrect");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
