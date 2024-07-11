using System;
using System.Windows.Forms;

namespace ReserveEase {
    public partial class LOGIN_FORMM : Form {
        public LOGIN_FORMM() {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void btnLogin_Click(object sender, EventArgs e) {
            string id = txtNameID.Text;
            string pass = txtPassword.Text;

            // Change '==' into .Equals for consistency.
            if (id.Equals("staff") && pass.Equals("123456")) {
                new DASHBOARD().Show();
                Close();
            } else {
                MessageBox.Show("Password or Email is incorrect");
            }
        }

        private void btnAU_Click(object sender, EventArgs e) {
            Close();
            Application.Exit();
        }
    }
}