using ReserveEase.DB.ORMs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReserveEase {
    public partial class DASHBOARD : Form {
        public DASHBOARD() {
            InitializeComponent();
            homeDashboard1.btnDashboard.Click += (s, e) => button5.PerformClick();
            homeDashboard1.btnGuest.Click += (s, e) => button3.PerformClick();
            homeDashboard1.btnReports.Click += (s, e) => button4.PerformClick();
            homeDashboard1.btnBookings.Click += (s, e) => button1.PerformClick();
            homeDashboard1.btnRooms.Click += (s, e) => button2.PerformClick();
        }


        private void button3_Click_1(object sender, EventArgs e) {
            if (!IsInTop(guestDashboard1)) guestDashboard1.LoadData();
            guestDashboard1.BringToFront();
            RefreshButton((Control)sender);
        }

        private bool IsInTop(Control c) {
            return StagePanel.Controls.GetChildIndex(c) == 0;
        }

        private void button2_Click_1(object sender, EventArgs e) {
            if (!IsInTop(roomsDashboard1)) roomsDashboard1.LoadData();
            roomsDashboard1.BringToFront();
            RefreshButton((Control)sender);
        }

        private void button1_Click_1(object sender, EventArgs e) {
            if (!IsInTop(reservationDashboard1)) reservationDashboard1.Reset();
            reservationDashboard1.BringToFront();
            RefreshButton((Control)sender);
        }

        private void button4_Click_1(object sender, EventArgs e) {
            reportDashboard1.BringToFront();
            RefreshButton((Control)sender);
        }

        private void button5_Click_1(object sender, EventArgs e) {
            if (!IsInTop(mainDashboard1)) mainDashboard1.LoadData();
            mainDashboard1.BringToFront();
            RefreshButton((Control)sender);
        }

        private void btnLogout_Click(object sender, EventArgs e) {
            Close();
            new LOGIN_FORMM().ShowDialog();
        }

        private void RefreshButton(Control selectedButton) {
            foreach (Control c in panel3.Controls) {
                c.BackColor = SystemColors.ActiveCaption;
            }
            selectedButton.BackColor = SystemColors.GradientInactiveCaption;
        }

        internal void TransportDataToReservation(int RoomNumber) {
            homeDashboard1.btnBookings.PerformClick();
            if (!reservationDashboard1.SendRoomInfo(RoomNumber, out Room r) || r.Status != Room.RoomStatus.Available) {
                MessageBox.Show("Room not yet available.");
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e) {
            RefreshButton((Control)sender);
            homeDashboard1.BringToFront();
        }
    }
}
