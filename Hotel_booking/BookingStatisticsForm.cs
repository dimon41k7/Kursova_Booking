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
    public partial class BookingStatisticsForm: Form
    {
        private int client_id;
        public BookingStatisticsForm(int client_id)
        {
            InitializeComponent();
            this.client_id = client_id;
        }

        private void BookingStatisticsForm_Load(object sender, EventArgs e)
        {
            var adapter = new Client2TableAdapter();
            var dt = adapter.GetBookingStatistics(client_id);
            DataRow row = dt.Rows[0];
            int created = row.IsNull("total_bookings")
                ? 0
                : Convert.ToInt32(row["total_bookings"]);

            int active = row.IsNull("active_bookings")
                ? 0
                : Convert.ToInt32(row["active_bookings"]);

            int cancelled = row.IsNull("cancelled_bookings")
                ? 0
                : Convert.ToInt32(row["cancelled_bookings"]);

            int completed = row.IsNull("completed_bookings")
                ? 0
                : Convert.ToInt32(row["completed_bookings"]);

            string last_name = Convert.ToString(row["last_name"]);
            string first_name = Convert.ToString(row["first_name"]);
            string middle_name = Convert.ToString(row["middle_name"]);
            label_last_name.Text = last_name;
            label_first_name.Text = first_name;
            label_middle_name.Text = middle_name;
            label_created.Text = Convert.ToString(created);
            label_active.Text = Convert.ToString(active);
            label_cancelled.Text = Convert.ToString(cancelled);
            label_completed.Text = Convert.ToString(completed);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
