using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_booking.hotel_bookingDataSetTableAdapters;

namespace Hotel_booking
{
    public partial class RegisterForm: Form
    {
        private string email;
        private string pass;
        public RegisterForm(string email, string pass)
        {
            InitializeComponent();
            this.email = email;
            this.pass = pass;
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_email.Text) || string.IsNullOrWhiteSpace(textBox_passf.Text) || string.IsNullOrWhiteSpace(textBox_passs.Text))
            {
                MessageBox.Show("Заповніть всі поля!");
                return;
            }

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!emailRegex.IsMatch(textBox_email.Text))
            {
                MessageBox.Show("Введіть коректну адресу електронної пошти!");
                return;
            }

            if (textBox_passf.Text != textBox_passs.Text)
            {
                MessageBox.Show("Паролі не співпадають!");
                return;
            }

            if (textBox_passf.Text.Length < 8)
            {
                MessageBox.Show("Пароль має бути не менше 8 символів!");
                return;
            }

            var strongPassword = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$");

            if (!strongPassword.IsMatch(textBox_passf.Text))
            {
                MessageBox.Show("Пароль має містити великі та маленькі літери, цифри та спеціальні символи!");
                return;
            }

            var dt = clientTableAdapter.GetDataByEmail(textBox_email.Text);

            if (dt.Rows.Count != 0)
            {
                MessageBox.Show("Користувач з такою поштою вже існує!");
                return;
            }

            var reg2 = new RegisterForm2(
                textBox_email.Text,
                textBox_passf.Text
            );

            reg2.Show();
            this.Close();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.clientTableAdapter.Fill(this.hotel_bookingDataSet.Client);
            textBox_email.Text = email;
            textBox_passf.Text = pass;
            textBox_passs.Text = pass;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}
