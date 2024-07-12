using ReserveEase.DB;
using ReserveEase.DB.ORMs;
using System;
using System.Windows.Forms;

namespace ReserveEase.UserControls {
    public partial class ReservationDashboard : UserControl {
        public ReservationDashboard() {
            InitializeComponent();
            Reset();
        }

        internal bool SendRoomInfo(int roomNumber, out Room room) {
            room = null;
            if (roomNumber > 0) {
                room = Database.conn.FindWithQuery<Room>("SELECT * FROM Room WHERE RoomNumber = ?", new object[] { roomNumber });
                if (room != null && room.Status == Room.RoomStatus.Available) {
                    textBox2.Text = room.RoomNumber.ToString();
                    textBox4.Text = room.RoomType.ToString();
                    textBox4.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    return true;
                }
            }
            return false;
        }

        internal void Reset() {
            textBox4.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox4.Clear();
            textBox2.Clear();
            textBox7.Clear();
            checkInDateTimePicker.MinDate = DateTime.Now;
            checkOutDateTimePicker.MinDate = DateTime.Now.AddDays(1);
            checkInDateTimePicker.Value = DateTime.Now;
            checkOutDateTimePicker.Value = DateTime.Now.AddDays(1);
            textBox8.Clear();
            textBox3.Clear();

            comboBox2.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;

        }

        private void button1_Click(object sender, System.EventArgs e) {
            if (string.IsNullOrEmpty(textBox2.Text) || !int.TryParse(textBox2.Text, out int x) || !SendRoomInfo(x, out Room room)) {
                MessageBox.Show("Room Number is invalid.");
                return;
            }
            if (!int.TryParse(textBox7.Text, out int guests)) {
                MessageBox.Show("Number of guests is empty.");
                return;
            }

            if (checkInDateTimePicker.Value.Date > checkOutDateTimePicker.Value.Date) {
                MessageBox.Show("Check in should not be greater than check out.");
                return;
            }

            if (string.IsNullOrEmpty(textBox8.Text) || !double.TryParse(textBox8.Text, out double amount)) {
                MessageBox.Show("Payment amount is empty.");
                return;
            }

            guestPage guestPage = new guestPage();
            if (guestPage.ShowDialog(this) == DialogResult.OK && guestPage.NewGuest != null) {
                Guest g = guestPage.NewGuest;
                Payment payment = new Payment();
                Reservation r = new Reservation();

                payment.DateOccurred = DateTime.Now;
                payment.GuestID = g.GuestID;
                payment.Method = comboBox2.SelectedItem.ToString();
                payment.PaymentAmount = amount;

                r.CheckInTime = checkInDateTimePicker.Value.Date.ToString("dd/MM/yyyy");
                r.CheckOutTime = checkOutDateTimePicker.Value.Date.ToString("dd/MM/yyyy");
                r.DateOccurred = DateTime.Now;
                r.Details = textBox3.Text;
                r.GuestID = g.GuestID;
                r.NumOfGuests = guests;
                r.Rate = comboBox7.SelectedItem.ToString();
                r.RoomNumber = room.RoomNumber;

                room.OccupiedBy = g.GuestID;
                room.Status = Room.RoomStatus.Occupied;
                room.CheckOut = r.CheckOutTime;

                Database.conn.Update(room);
                Database.conn.Insert(g);
                Database.conn.Insert(payment);
                Database.conn.Insert(r);
                MessageBox.Show("Room was reserved.");
                Reset();
            }
        }
    }
}
