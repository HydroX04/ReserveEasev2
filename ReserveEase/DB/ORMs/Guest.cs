using SQLite;

namespace ReserveEase.DB.ORMs {
    internal class Guest {
        [PrimaryKey, NotNull]
        public string GuestID { get; set; }
        [NotNull]
        public string LastName { get; set; }
        [NotNull]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        [NotNull]
        public string ContactNo { get; set; }
        [NotNull]
        public string Email { get; set; }
        [NotNull]
        public string Address { get; set; }
        [NotNull]
        public string Identification { get; set; }
    }
}
