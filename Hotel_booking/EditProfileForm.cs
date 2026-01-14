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
    public partial class EditProfileForm: Form
    {
        private int client_id;
        public EditProfileForm(int id)
        {
            InitializeComponent();
            client_id = id;
        }

        private void EditProfileForm_Load(object sender, EventArgs e)
        {
            this.clientTableAdapter.Fill(this.hotel_bookingDataSet.Client);
            var client = clientTableAdapter.GetDataById(client_id);
            textBox_email.Text = Convert.ToString(client.Rows[0]["email"]);
            textBox_phone.Text = Convert.ToString(client.Rows[0]["phone"]);
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            var client = clientTableAdapter.GetDataById(client_id);
            var phoneRegex = new Regex(@"^\+380\d{9}$");

            if (!phoneRegex.IsMatch(textBox_phone.Text))
            {
                MessageBox.Show("Номер телефону має бути у форматі +380XXXXXXXXX");
                return;
            }
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!emailRegex.IsMatch(textBox_email.Text))
            {
                MessageBox.Show("Введіть коректну адресу електронної пошти!");
                return;
            }

            var dt = clientTableAdapter.GetDataByEmail(textBox_email.Text);
            if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0]["client_id"]) != client_id)
            {
                MessageBox.Show("Користувач з такою поштою вже існує!");
                return;
            }

            if (Convert.ToString(client.Rows[0]["email"]) != textBox_email.Text && Convert.ToString(client.Rows[0]["phone"]) != textBox_phone.Text)
            {
                var result = MessageBox.Show(
                    "Ви впевнені, що хочете зберегти зміни?",
                    "Підтвердження",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                
                if (result == DialogResult.Yes)
                {
                    clientTableAdapter.UpdateEmail(textBox_email.Text, client_id);
                    clientTableAdapter.UpdatePhone(textBox_phone.Text, client_id);
                    this.Close();
                }
                    
            }
            else if (Convert.ToString(client.Rows[0]["email"]) != textBox_email.Text)
            {
                var result = MessageBox.Show(
                    "Ви впевнені, що хочете зберегти зміни?",
                    "Підтвердження",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {
                    clientTableAdapter.UpdateEmail(textBox_email.Text, client_id);
                    this.Close();
                }
                    
            }
            else
            {
                var result = MessageBox.Show(
                    "Ви впевнені, що хочете зберегти зміни?",
                    "Підтвердження",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {
                    clientTableAdapter.UpdatePhone(textBox_phone.Text, client_id);
                    this.Close();
                }
                    
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
