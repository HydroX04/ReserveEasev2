using ReserveEase.DB;
using ReserveEase.DB.ORMs;
using ReserveEase.DB.ORMs.Non_ORM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ReserveEase.UserControls {
    public partial class MainDashboard : UserControl {

        private List<DashboardORM> lists = new List<DashboardORM>();
        public MainDashboard() {
            InitializeComponent();
            this.dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
        }

        internal void LoadData() {
            try {

                DateTime now = DateTime.Now;
                timeLabel.Text = $"As of {now:dddd (MMMM dd, yyyy)}";

                List<Reservation> reservationList = Database.conn.Table<Reservation>().ToList();
                List<Room> roomList = Database.conn.Table<Room>().ToList();

                int checkInCount = reservationList.Count(r => r.DateOccurred.Date == now.Date);
                int availableRoomCount = roomList.Count(r => r.Status == Room.RoomStatus.Available);
                int occupiedRoomCount = roomList.Count(r => r.Status == Room.RoomStatus.Occupied);
                int reservationCount = reservationList.Count;

                // Debugging statements
                Debug.Print($"Check-In Count: {checkInCount}");
                Debug.Print($"Available Room Count: {availableRoomCount}");
                Debug.Print($"Occupied Room Count: {occupiedRoomCount}");
                Debug.Print($"Reservation Count: {reservationCount}");

                label19.Text = checkInCount.ToString();
                label20.Text = availableRoomCount.ToString();
                label21.Text = occupiedRoomCount.ToString();
                label22.Text = reservationCount.ToString();

                SortReservation(false);
            } catch (Exception ex) {
                Debug.Print(ex.Message);
            }
        }

        private void SortReservation(bool isCheckOut) {
            lists.Clear();
            DateTime now = DateTime.Now;

            foreach (Reservation r in Database.conn.Table<Reservation>().ToList().Where(r => (!isCheckOut ?
                                            r.DateOccurred.Date == now.Date : DateTime.ParseExact(r.CheckOutTime, "dd/MM/yyyy", CultureInfo.InvariantCulture).Date >= now.Date)).ToArray()) {
                try {
                    Guest g = Database.conn.Table<Guest>().ToList().Where(gx => gx.GuestID.Equals(r.GuestID)).FirstOrDefault();
                    if (g == null) continue;
                    Room room = Database.conn.Table<Room>().ToList().Where(rx => !string.IsNullOrEmpty(rx.OccupiedBy) && rx.OccupiedBy.Equals(g.GuestID)).FirstOrDefault();
                    if (room == null) continue;

                    DashboardORM orm = new DashboardORM();
                    orm.CheckOutTime = r.CheckOutTime;
                    orm.RoomNumber = r.RoomNumber;
                    orm.RoomType = room.RoomType;
                    orm.GuestName = $"{g.FirstName}{(string.IsNullOrEmpty(g.MiddleName) ? "" : " " + g.MiddleName)} {g.LastName}";
                    lists.Add(orm);
                } catch (Exception ex) {
                    Debug.Print(ex.Message);
                }
            }

            Debug.Print("Number of items in lists: " + lists.Count);
            foreach (var item in lists) {
                Debug.Print($"GuestName: {item.GuestName}, RoomNumber: {item.RoomNumber}, RoomType: {item.RoomType}, CheckOutTime: {item.CheckOutTime}");
            }

            dataGridView1.DataSource = null; // Clear the existing data source
            dataGridView1.DataSource = lists;

            // Ensure the columns match the properties of the DashboardORM class
            if (dataGridView1.Columns.Count >= 4) {
                dataGridView1.Columns[0].HeaderText = "Guest Name";
                dataGridView1.Columns[0].DataPropertyName = "GuestName"; // Ensure it matches the property name in DashboardORM
                dataGridView1.Columns[1].HeaderText = "Room Number";
                dataGridView1.Columns[1].DataPropertyName = "RoomNumber"; // Ensure it matches the property name in DashboardORM
                dataGridView1.Columns[2].HeaderText = "Room Type";
                dataGridView1.Columns[2].DataPropertyName = "RoomType"; // Ensure it matches the property name in DashboardORM
                dataGridView1.Columns[3].HeaderText = "Check Out Date";
                dataGridView1.Columns[3].DataPropertyName = "CheckOutTime"; // Ensure it matches the property name in DashboardORM
            } else {
                Debug.Print("Expected 4 columns but found " + dataGridView1.Columns.Count);
            }

            button8.BackColor = SystemColors.Control;
            button6.BackColor = SystemColors.Control;
            (isCheckOut ? button8 : button6).BackColor = SystemColors.ActiveCaption;
        }

        private void button6_Click(object sender, EventArgs e) {
            SortReservation(false);
        }

        private void button8_Click(object sender, EventArgs e) {
            SortReservation(true);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            Debug.Print("DataGridView DataError: " + e.Exception.Message);
            e.ThrowException = false;
        }

        private void MainDashboard_Load(object sender, EventArgs e) {
        }

        private void label22_Click(object sender, EventArgs e) {
        }

        private void panel6_Paint(object sender, PaintEventArgs e) {
        }
    }
}
