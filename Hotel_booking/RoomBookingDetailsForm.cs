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
    public partial class RoomBookingDetailsForm: Form
    {
        private int booking_id;
        private int client_id;
        private int room_booking_id;
        private int category_id;
        public RoomBookingDetailsForm(int id, int id2, int id3)
        {
            InitializeComponent();
            booking_id = id;
            client_id = id2;
            room_booking_id = id3;
        }

        private void fillinfo()
        {

            var adapter = new DataTable5TableAdapter();
            var bk = adapter.GetInfoAboutRoomBooking(room_booking_id);

            DateTime checkIn = Convert.ToDateTime(bk.Rows[0]["check_in_date"]);
            DateTime checkOut = Convert.ToDateTime(bk.Rows[0]["check_out_date"]);


            label_check_in_date.Text = checkIn.ToShortDateString();
            label_check_out_date.Text = checkOut.ToShortDateString();
            label_room_number.Text = Convert.ToString(bk.Rows[0]["room_number"]);
            label_room_description.Text = Convert.ToString(bk.Rows[0]["description"]);
            label_guests_count.Text = Convert.ToString(bk.Rows[0]["guests_count"]);
            label_category.Text = Convert.ToString(bk.Rows[0]["name"]);
            int price_per_day = Convert.ToInt32(bk.Rows[0]["price_per_day"]);
            label_total_amount.Text = Convert.ToString(price_per_day * (checkOut - checkIn).Days);
            category_id = Convert.ToInt32(bk.Rows[0]["category_id"]);



            var adapter1 = new FacilityTableAdapter();
            var fa = adapter1.GetFacilityByCategoryId(category_id);
            listView_facility.Items.Clear();
            listView_facility.Columns.Clear();
            listView_facility.View = View.Details;
            listView_facility.Columns.Add("Зручності номеру", 100);

            foreach (DataRow row in fa.Rows)
            {
                listView_facility.Items.Add(row["name"].ToString());
            }
            if (fa.Rows.Count == 0)
            {
                listView_facility.Visible = false;
                label4.Text = "Зручностей немає";
                return;
            }
        }
        private void RoomBookingDetailsForm_Load(object sender, EventArgs e)
        {
            fillinfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new BookingDetailsForm(booking_id, client_id);
            this.Close();
            form.Show();
        }
    }
}
