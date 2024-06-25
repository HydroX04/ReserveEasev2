using System;

namespace ReserveEase
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public RoomStatus Status { get; set; }

        public Room(int roomNumber, string roomType)
        {
            RoomNumber = roomNumber;
            RoomType = roomType;
            Status = RoomStatus.Available; // Default status
        }
    }

    public enum RoomStatus
    {
        Available,
        Occupied,
        UnderMaintenance
    }
}
