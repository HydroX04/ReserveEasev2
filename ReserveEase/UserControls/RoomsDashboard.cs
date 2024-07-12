using ReserveEase.DB;
using ReserveEase.DB.ORMs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReserveEase.UserControls {
    public partial class RoomsDashboard : UserControl {

        private List<Room> rooms = new List<Room>();

        public RoomsDashboard() {
            InitializeComponent();
        }

        internal void LoadData() {
            dataGridView1.DataSource = null;
            try {
                rooms = Database.conn.Table<Room>().ToList();
                dataGridView1.DataSource = rooms;
                dataGridView1.Columns[0].HeaderText = "Room Number";
                dataGridView1.Columns[1].HeaderText = "Type";
                dataGridView1.Columns[2].HeaderText = "Check Out";
            } catch {

            }

        }

        private void button3_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count != 1) return;

            Room r = rooms[dataGridView1.SelectedRows[0].Index];
            if (r.Status != Room.RoomStatus.Occupied) {
                MessageBox.Show(this, "Couldn't update the details for the available rooms.");
                LoadData();
                return;
            }
            if (MessageBox.Show(this, "Do you want to set this room as check out?", "", MessageBoxButtons.YesNo) == DialogResult.No) {
                LoadData();
                return;
            }
            r.Status = Room.RoomStatus.Available;
            r.OccupiedBy = "";
            Database.conn.Update(r);
            LoadData();
        }

        private void RoomsDashboard_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count != 1) return;

            Room r = rooms[dataGridView1.SelectedRows[0].Index];

            if (r.Status != Room.RoomStatus.Available) {
                MessageBox.Show(this, "Couldn't make a reservation yet.");
                LoadData();
                return;
            }
            if (ParentForm is DASHBOARD board) {
                board.TransportDataToReservation(r.RoomNumber);
            }
        }

        private void button8_Click(object sender, EventArgs e) {
            new singleRate().ShowDialog(this);
        }

        private void button9_Click(object sender, EventArgs e) {
            new standartRate().ShowDialog(this);
        }

        private void button10_Click(object sender, EventArgs e) {
            new deluxeRate().ShowDialog(this);
        }
    }
}
