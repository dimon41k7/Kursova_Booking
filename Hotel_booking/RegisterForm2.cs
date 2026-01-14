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
using System.Text.RegularExpressions;

namespace Hotel_booking
{
    public partial class RegisterForm2: Form
    {
        private string email;
        private string passwordHash;
        private string pass;
        public RegisterForm2(string email, string password)
        {
            InitializeComponent();
            this.email = email;
            pass = password;
            this.passwordHash = HashPassword(password);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_last_name.Text) || string.IsNullOrWhiteSpace(textBox_first_name.Text) || string.IsNullOrWhiteSpace(textBox_middle_name.Text) || string.IsNullOrWhiteSpace(textBox_passport_data.Text) || string.IsNullOrWhiteSpace(textBox_phone.Text))
            {
                MessageBox.Show("Заповніть всі необхідні поля!");
                return;
            }

            var onlyLetters = new Regex(@"^[A-Za-zА-Яа-яІіЇїЄєҐґ]+$");

            if (!onlyLetters.IsMatch(textBox_last_name.Text))
            {
                MessageBox.Show("Прізвище може містити тільки букви!");
                return;
            }

            if (!onlyLetters.IsMatch(textBox_first_name.Text))
            {
                MessageBox.Show("Ім'я може містити тільки букви!");
                return;
            }

            if (!onlyLetters.IsMatch(textBox_middle_name.Text))
            {
                MessageBox.Show("По батькові може містити тільки букви!");
                return;
            }

            if (dateTimePicker_bith_date.Value > DateTime.Today)
            {
                MessageBox.Show("Дата народження має бути пізніше ніж сьогодні!");
                return;
            }

            var phoneRegex = new Regex(@"^\+380\d{9}$");

            if (!phoneRegex.IsMatch(textBox_phone.Text))
            {
                MessageBox.Show("Номер телефону має бути у форматі +380XXXXXXXXX");
                return;
            }           

            clientTableAdapter.Insert(
                textBox_last_name.Text,
                textBox_first_name.Text,
                textBox_middle_name.Text,
                textBox_passport_data.Text,
                dateTimePicker_bith_date.Value,
                email,
                textBox_phone.Text,
                passwordHash
            );

            MessageBox.Show("Реєстрація успішна!");
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.Show();
        }

        private void RegisterForm2_Load(object sender, EventArgs e)
        {
            this.clientTableAdapter.Fill(this.hotel_bookingDataSet.Client);
            dateTimePicker_bith_date.MaxDate = DateTime.Today;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var login = new RegisterForm(email, pass);
            login.Show();
            this.Close();
        }
    }
}
