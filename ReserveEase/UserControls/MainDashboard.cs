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
        }

        internal void LoadData() {
            try {

                DateTime now = DateTime.Now;
                timeLabel.Text = $"As of {now:dddd (MMMM dd, yyyy)}";
                List<Reservation> reservationList = Database.conn.Table<Reservation>().ToList();
                label19.Text = reservationList.Count.ToString();
                label20.Text = Database.conn.Table<Room>().Count(r => r.Status == Room.RoomStatus.Available).ToString();
                label21.Text = Database.conn.Table<Room>().Count(r => r.Status == Room.RoomStatus.Occupied).ToString();

                label22.Text = Database.conn.Table<Reservation>().ToList().Where(r => DateTime.ParseExact(r.CheckOutTime, "dd/MM/yyyy", CultureInfo.InvariantCulture).Date >= now.Date).Count().ToString();

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
                    orm.GuestName = $"{g.FirstName}{(string.IsNullOrEmpty(g.MiddleName) ? "" : " " + g.MiddleName)}, {g.LastName}";
                    lists.Add(orm);
                } catch (Exception ex) {
                    Debug.Print(ex.Message);
                }
            }

            dataGridView1.DataSource = lists;
            dataGridView1.Columns[0].HeaderText = "Guest Name";
            dataGridView1.Columns[1].HeaderText = "Room Number";
            dataGridView1.Columns[2].HeaderText = "Room Type";
            dataGridView1.Columns[3].HeaderText = "Check Out Date";

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
    }
}
