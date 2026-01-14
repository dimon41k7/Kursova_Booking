using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_booking.hotel_bookingDataSetTableAdapters;

namespace Hotel_booking
{
    public partial class EditBookingServiceForm: Form
    {
        private int booking_id;
        private int client_id;
        private int service_booking_id;
        private int persons;
        private int days;
        private string notes;
        public EditBookingServiceForm(int booking_id, int client_id, int service_booking_id)
        {
            InitializeComponent();
            this.booking_id = booking_id;
            this.client_id = client_id;
            this.service_booking_id = service_booking_id;
        }

        private void EditBookingServiceForm_Load(object sender, EventArgs e)
        {
            var adapter = new Service_booking1TableAdapter();
            var bk = adapter.GetServiceBooking(service_booking_id);
            textBox_days.Text = Convert.ToString(bk.Rows[0]["days_count"]);
            textBox_persons.Text = Convert.ToString(bk.Rows[0]["persons_count"]);
            textBox1.Text = Convert.ToString(bk.Rows[0]["notes"]);

            bool is_r = Convert.ToBoolean(bk.Rows[0]["is_repeatable"]);

            if (!is_r)
            {
                textBox_days.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_days.Text) || string.IsNullOrWhiteSpace(textBox_persons.Text))
            {
                MessageBox.Show("Заповніть всі необхідні поля!");
                return;
            }

            if (!int.TryParse(textBox_days.Text, out days))
            {
                MessageBox.Show("Некоректна кількість днів!");
                return;
            }

            if (days < 1)
            {
                MessageBox.Show("Кількість днів не може бути менше 1");
                return;
            }

            if (!int.TryParse(textBox_persons.Text, out persons))
            {
                MessageBox.Show("Некоректна кількість днів!");
                return;
            }
            if (persons < 1)
            {
                MessageBox.Show("Кількість осіб не може бути менше 1");
                return;
            }

            var adapter1 = new DataTable10TableAdapter();
            var se = adapter1.GetMaxDaysPersons(booking_id);
            int maxdays;
            int maxpersons;
            if (se.Count == 0)
            {
                maxdays = 3;
                maxpersons = 3;
            }
            else
            {
                maxdays = Convert.ToInt32(se.Rows[0]["max_days"]);
                maxpersons = Convert.ToInt32(se.Rows[0]["max_guests"]);
            }

            if (days > maxdays)
            {
                MessageBox.Show($"Кількість днів не може бути більше за {maxdays}");
                return;
            }

            if (persons > maxpersons)
            {
                MessageBox.Show($"Кількість осіб не може бути більше за {maxpersons}");
                return;
            }


            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                notes = "";
            }
            else
            {
                notes = textBox1.Text;
            }

            var result = MessageBox.Show(
                "Ви впевнені, що хочете зберегти зміни?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                var adapter = new Service_bookingTableAdapter();
                adapter.UpdateServiceBooking(persons, days, notes, service_booking_id);
                this.Close();
            }
                
        }
    }
}
