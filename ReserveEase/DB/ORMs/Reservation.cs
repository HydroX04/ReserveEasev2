using SQLite;
using System;

namespace ReserveEase.DB.ORMs {
    internal class Reservation {
        [PrimaryKey, NotNull]
        public DateTime DateOccurred { get; set; }
        [NotNull]
        public int RoomNumber { get; set; }
        [NotNull]
        public int NumOfGuests { get; set; }
        [NotNull]
        public string CheckInTime { get; set; }
        [NotNull]
        public string Rate { get; set; }
        [NotNull]
        public string CheckOutTime { get; set; }
        [NotNull]
        public string Details { get; set; }
        [NotNull]
        public string GuestID { get; set; }
    }
}
