using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ReserveEase
{
    public partial class RoomManagementForm : Form
    {
        private List<Room> rooms;

        public RoomManagementForm()
        {
            InitializeComponent();
            InitializeRooms();
            DisplayRooms();
        }

        private void RoomManagementForm_Load(object sender, EventArgs e)
        {
            // Handle any initialization tasks here if needed.
        }

        private void InitializeRooms()
        {
            // Initialize dummy rooms
            rooms = new List<Room>
            {
                new Room(101, "Standard"),
                new Room(102, "Deluxe"),
                new Room(103, "Suite")
                // Add more rooms as needed
            };
        }

        private void DisplayRooms()
        {
            roomDataGridView.Rows.Clear();

            foreach (var room in rooms)
            {
                int rowIndex = roomDataGridView.Rows.Add();
                DataGridViewRow row = roomDataGridView.Rows[rowIndex];

                row.Cells["RoomNumber"].Value = room.RoomNumber;
                row.Cells["RoomType"].Value = room.RoomType;
                row.Cells["Status"].Value = room.Status.ToString();
                row.DefaultCellStyle.BackColor = GetStatusColor(room.Status);
            }
        }

        private Color GetStatusColor(RoomStatus status)
        {
            switch (status)
            {
                case RoomStatus.Available:
                    return Color.LightGreen;
                case RoomStatus.Occupied:
                    return Color.LightBlue;
                case RoomStatus.UnderMaintenance:
                    return Color.LightPink;
                default:
                    return Color.White;
            }
        }

        private void roomDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < roomDataGridView.Rows.Count)
            {
                DataGridViewRow selectedRow = roomDataGridView.Rows[e.RowIndex];
                int roomNumber = Convert.ToInt32(selectedRow.Cells["RoomNumber"].Value);
                Room room = rooms.Find(r => r.RoomNumber == roomNumber);

                if (room != null)
                {
                    // Toggle room status for demonstration
                    if (room.Status == RoomStatus.Available)
                        room.Status = RoomStatus.Occupied;
                    else if (room.Status == RoomStatus.Occupied)
                        room.Status = RoomStatus.UnderMaintenance;
                    else if (room.Status == RoomStatus.UnderMaintenance)
                        room.Status = RoomStatus.Available;

                    selectedRow.Cells["Status"].Value = room.Status.ToString();
                    selectedRow.DefaultCellStyle.BackColor = GetStatusColor(room.Status);
                }
            }
        }
    }
}
