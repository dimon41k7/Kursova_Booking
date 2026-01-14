using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using Hotel_booking.hotel_bookingDataSetTableAdapters;

namespace Hotel_booking
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.clientTableAdapter.Fill(this.hotel_bookingDataSet.Client);
            textBox_pass.UseSystemPasswordChar = true;
            AutoCompleteBookings();

        }

        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string email = textBox_email.Text.Trim();
            string passwordHash = HashPassword(textBox_pass.Text);
            if (string.IsNullOrWhiteSpace(textBox_email.Text) || string.IsNullOrWhiteSpace(textBox_pass.Text))
            {
                MessageBox.Show("Заповніть всі необхідні поля!");
                return;
            }

            var dt = clientTableAdapter.GetDataByEmail(textBox_email.Text);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Користувача з таким email не знайдено.");
                return;
            }

            var row = dt.Rows[0];

            if (row["password"].ToString() != passwordHash)
            {
                MessageBox.Show("Невірний пароль!");
                return;
            }

            MessageBox.Show("Вхід виконано успішно!");

            this.Hide();
            var mainForm = new MainForm(Convert.ToInt32(dt.Rows[0]["client_id"]), false, 0, false);
            mainForm.Show();
        }

        private void button_register_Click(object sender, EventArgs e)
        {
            this.Hide();
            var registerform = new RegisterForm("", "");
            registerform.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox_pass.UseSystemPasswordChar = false;
            }
            else
            {
                textBox_pass.UseSystemPasswordChar = true;
            }
        }


        public void AutoCompleteBookings()
        {
            var bookingAdapter = new Booking2TableAdapter();
            var roomAdapter = new Room_bookingTableAdapter();

            var paidBookings = bookingAdapter.GetPaidBookings();

            foreach (var row in paidBookings)
            {
                int booking_id = (int)row["booking_id"];

                DateTime? maxCheckout = roomAdapter.GetMaxCheckoutDate(booking_id);

                if (!maxCheckout.HasValue)
                    continue;

                if (DateTime.Now > maxCheckout.Value)
                {
                    var bookingAdapter1 = new BookingTableAdapter();
                    bookingAdapter1.UpdateStatus("Завершено", booking_id);
                }
            }
        }
    }
}
