using SQLite;

namespace ReserveEase.DB.ORMs {
    internal class Room {

        public enum RoomStatus {
            Available,
            Occupied,
            UnderMaintenance
        }

        [PrimaryKey, NotNull]
        public int RoomNumber { get; set; }
        [NotNull]
        public string RoomType { get; set; }
        [NotNull]
        public string CheckOut { get; set; }
        [NotNull]
        public RoomStatus Status { get; set; }
        public string OccupiedBy { get; set; }
    }
}
