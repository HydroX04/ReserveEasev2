using System;
using System.Windows.Forms;

namespace ReserveEase.UserControls {
    public partial class HomeDashboard : UserControl {
        public HomeDashboard() {
            InitializeComponent();
            ChangeDate();
        }

        private void button9_Click(object sender, EventArgs e) {
            new aboutUS().ShowDialog(this);
        }

        private void button8_Click(object sender, EventArgs e) {
            new contactUS().ShowDialog(this);
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (IsHandleCreated) {
                try {
                    ChangeDate();
                } catch {
                    // Must ignore.
                }
            }
        }

        private void ChangeDate() {
            DateTime dt = DateTime.Now;
            timeLabel.Text = dt.ToString("hh:mm:ss tt");
            dateLabel.Text = dt.ToString("dddd dd MMMM, yyyy");
        }
    }
}
