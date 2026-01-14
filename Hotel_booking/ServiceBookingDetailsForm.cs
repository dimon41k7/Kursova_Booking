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
    public partial class ServiceBookingDetailsForm: Form
    {
        private int booking_id;
        private int client_id;
        private int service_booking_id;
        public ServiceBookingDetailsForm(int id, int id2, int id3)
        {
            InitializeComponent();
            booking_id = id;
            client_id = id2;
            service_booking_id = id3;
        }

        private void fillinfo()
        {
            var adapter = new DataTable7TableAdapter();
            var bk = adapter.GetDataAboutBookingService(service_booking_id);
            label_name.Text = Convert.ToString(bk.Rows[0]["name"]);
            label_description.Text = Convert.ToString(bk.Rows[0]["description"]);
            label_notes.Text = Convert.ToString(bk.Rows[0]["notes"]);

            int persons = Convert.ToInt32(bk.Rows[0]["persons_count"]);
            label_persons.Text = Convert.ToString(persons);

            int days = Convert.ToInt32(bk.Rows[0]["days_count"]);
            label_days.Text = Convert.ToString(days);

            decimal price = Convert.ToDecimal(bk.Rows[0]["price_per_day"]);
            label_price.Text = Convert.ToString(days*price*persons);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new BookingDetailsForm(booking_id, client_id);
            this.Close();
            form.Show();
        }

        private void ServiceBookingDetailsForm_Load(object sender, EventArgs e)
        {
            fillinfo();
        }
    }
}
