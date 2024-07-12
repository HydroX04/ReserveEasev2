using SQLite;
using System;

namespace ReserveEase.DB.ORMs {
    internal class Payment {
        [PrimaryKey, NotNull]
        public DateTime DateOccurred { get; set; }
        [NotNull]
        public double PaymentAmount { get; set; }
        [NotNull]
        public string Method { get; set; }
        [NotNull]
        public string GuestID { get; set; }
    }
}
