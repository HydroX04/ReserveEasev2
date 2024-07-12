using ReserveEase.DB;
using ReserveEase.DB.ORMs;
using System.Windows.Forms;

namespace ReserveEase.UserControls {
    public partial class GuestDashboard : UserControl {
        public GuestDashboard() {
            InitializeComponent();
        }

        internal void LoadData() {
            dataGridView1.DataSource = null;
            try {
                dataGridView1.DataSource = Database.conn.Table<Guest>().ToList(); ;
                dataGridView1.Columns[0].HeaderText = "Guest ID";
                dataGridView1.Columns[1].HeaderText = "Last Name";
                dataGridView1.Columns[2].HeaderText = "First Name";
                dataGridView1.Columns[3].HeaderText = "Middle Name";
                dataGridView1.Columns[4].HeaderText = "Contact No.";
            } catch {

            }
        }
    }
}
