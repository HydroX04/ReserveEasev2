using ReserveEase.DB.ORMs;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace ReserveEase {
    public partial class guestPage : Form {

        internal Guest NewGuest { get; private set; } = null;

        public guestPage() {
            InitializeComponent();

            InitializeTextBox(txtFirstName, "Last Name");
            InitializeTextBox(txtLastName, "First Name");
            InitializeTextBox(txtMiddleName, "Middle Name");
            InitializeTextBox(txtContactNo, "Contact No.");

        }
        private void InitializeComboBox(ComboBox comboBox, string initialText) {
            comboBox.Text = initialText;
            comboBox.ForeColor = Color.Gray;
            comboBox.Tag = initialText; // Store the initial text in the Tag property

            comboBox.Enter += ComboBox_Enter;
            comboBox.Leave += ComboBox_Leave;
        }

        private void ComboBox_Enter(object sender, EventArgs e) {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.ForeColor == Color.Gray) {
                comboBox.Text = "";
                comboBox.ForeColor = Color.Black; // Change text color to black when user starts typing
            }
        }

        private void ComboBox_Leave(object sender, EventArgs e) {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && string.IsNullOrWhiteSpace(comboBox.Text)) {
                // Set the initial text based on the Tag property
                comboBox.Text = comboBox.Tag.ToString();
                comboBox.ForeColor = Color.Gray; // Change text color back to gray if no input
            }
        }


        private void InitializeTextBox(TextBox textBox, string initialText) {
            textBox.Text = initialText;
            textBox.ForeColor = Color.Gray;
            textBox.Tag = initialText; // Store the initial text in the Tag property

            textBox.Enter += TextBox_Enter;
            textBox.Leave += TextBox_Leave;
        }

        private void TextBox_Enter(object sender, EventArgs e) {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.ForeColor == Color.Gray) {
                textBox.Text = "";
                textBox.ForeColor = Color.Black; // Change text color to black when user starts typing
            }
        }

        private void TextBox_Leave(object sender, EventArgs e) {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text)) {
                // Set the initial text based on the Tag property
                textBox.Text = textBox.Tag.ToString();
                textBox.ForeColor = Color.Gray; // Change text color back to gray if no input
            }
        }

        private void label12_Click_2(object sender, EventArgs e) {

        }

        private void guestPage_Load(object sender, EventArgs e) {

        }

        private void btnHomeg_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void button1_Click_1(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtFirstName.Text)) {
                MessageBox.Show("First Name is empty.");
                return;
            }

            if (string.IsNullOrEmpty(txtLastName.Text)) {
                MessageBox.Show("Last Name is empty.");
                return;
            }

            if (string.IsNullOrEmpty(txtAddress.Text)) {
                MessageBox.Show("Address is empty.");
                return;
            }

            if (string.IsNullOrEmpty(txtContactNo.Text)) {
                MessageBox.Show("Contact No. is empty.");
                return;
            }

            if (string.IsNullOrEmpty(txtEmail.Text)) {
                MessageBox.Show("Email is empty.");
                return;
            }

            if (string.IsNullOrEmpty(txtIdentification.Text)) {
                MessageBox.Show("Identification is empty.");
                return;
            }

            NewGuest = new Guest();
            NewGuest.ContactNo = txtContactNo.Text;
            NewGuest.FirstName = txtFirstName.Text;
            NewGuest.MiddleName = txtMiddleName.Text;
            NewGuest.LastName = txtLastName.Text;
            NewGuest.Address = txtAddress.Text;
            NewGuest.Email = txtEmail.Text;
            NewGuest.Identification = txtIdentification.Text;
            NewGuest.GuestID = "GUE" + DateTime.Now.ToString("ddMMyyyyhhmmss");
            DialogResult = DialogResult.OK;
            Close();

        }
    }
}