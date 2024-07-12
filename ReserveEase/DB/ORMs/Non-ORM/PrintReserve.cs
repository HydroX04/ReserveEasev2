using System;

namespace ReserveEase.DB.ORMs.Non_ORM {
    internal class PrintReserve {

        public DateTime Date { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public string Duration { get; set; }
        public double TotalAmount { get; set; }
    }
}
