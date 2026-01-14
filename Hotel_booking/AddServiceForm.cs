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
    public partial class AddServiceForm: Form
    {
        private int client_id;
        private int booking_id;
        private int service_id;
        private bool is_r;
        private decimal price_per_day;
        private int persons;
        private int days;
        private string notes;
        private bool alreadycr;
        public AddServiceForm(int client_id, int booking_id, int service_id, bool alreadycr)
        {
            InitializeComponent();
            this.client_id = client_id;
            this.booking_id = booking_id;
            this.service_id = service_id;
            this.alreadycr = alreadycr;
        }

        private void fillinfo()
        {
            var adapter1 = new ServiceTableAdapter();
            var se = adapter1.GetInfoService(service_id);

            label_name.Text = Convert.ToString(se.Rows[0]["name"]);

            price_per_day = Convert.ToDecimal(se.Rows[0]["price_per_day"]);
            label_price_per_day.Text = Convert.ToString(price_per_day);
            label_service_description.Text = Convert.ToString(se.Rows[0]["description"]);

            is_r = Convert.ToBoolean(se.Rows[0]["is_repeatable"]);
            label_is_r.Text = Convert.ToString(is_r);

            if (!is_r)
            {
                textBox_days.Enabled = false;
            }





            if (!int.TryParse(textBox_days.Text, out days))
            {
                MessageBox.Show("Некоректна кількість днів!");
                return;
            }

            if (!int.TryParse(textBox_persons.Text, out persons))
            {
                MessageBox.Show("Некоректна кількість днів!");
                return;
            }
        }

        private void AddServiceForm_Load(object sender, EventArgs e)
        {
            textBox_days.Text = "1";
            textBox_persons.Text = "1";
            fillinfo();
        }

        private void button1_Click(object sender, EventArgs e)
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
            var adapter = new Service_bookingTableAdapter();
            adapter.InsertServiceBooking(booking_id, service_id, persons, days, notes);


            if (alreadycr)
            {
                var det = new BookingDetailsForm(booking_id, client_id);
                det.Show();
                this.Close();
            }
            else
            {
                var list = new _2CreateBookingForm(booking_id, client_id);
                list.Show();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var list = new ListServicesForm(client_id, booking_id, alreadycr);
            list.Show();
            this.Close();
        }
    }
}
