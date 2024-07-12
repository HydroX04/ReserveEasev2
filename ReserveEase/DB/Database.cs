using ReserveEase.DB.ORMs;
using SQLite;
using System;
using System.IO;

namespace ReserveEase.DB {
    internal static class Database {

        internal static SQLiteConnection conn;
          // Load Database.
        internal static void Load() {
            // The BaseDirectory property is a path of the folder where the running program
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reverseease.db");
             // is currently resided. 
            bool isExists = File.Exists(path);

            SQLiteConnectionString connStr = new SQLiteConnectionString(path, false);

            // The SQLiteConnection will create the database if not existed.
            conn = new SQLiteConnection(connStr);

            if (!isExists) {
                conn.CreateTable<Reservation>();
                conn.CreateTable<Payment>();
                conn.CreateTable<Guest>();
                conn.CreateTable<Room>();
                for (int i = 0; i < 20; i++) {
                    Room r = new Room();

                    r.Status = Room.RoomStatus.Available;
                    r.CheckOut = "---";
                    r.RoomNumber = i + 1;
                    if (i >= 5 && i < 15) {
                        r.RoomType = "Standard";
                    } else if (i >= 15) {
                        r.RoomType = "Deluxe";
                    } else {
                        r.RoomType = "Single";
                    }
                    conn.Insert(r);
                }
            }
        }
    }
}
