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
    public partial class CreateBookingForm: Form
    {
        private DateTime check_in;
        private DateTime check_out;
        private int guests_count;
        private int client_id;
        private int room_id;
        private int booking_id;
        private int category_id;
        private int price_per_day;
        private bool addroom;
        private bool alreadycr;
        public CreateBookingForm(int id, DateTime check_in, DateTime check_out, int guests_count, int rid, bool addroom, int booking_id, bool alreadycr)
        {
            InitializeComponent();
            client_id = id;
            this.check_in = check_in;
            this.check_out = check_out;
            this.guests_count = guests_count;
            room_id = rid;
            this.addroom = addroom;
            if (addroom||alreadycr)
            {
                this.booking_id = booking_id;
            }

            this.alreadycr = alreadycr;
        }

        private void fillinfo()
        {
            var roomadapter = new RoomTableAdapter();
            var rm = roomadapter.GetInfoBooking(room_id);
            category_id = Convert.ToInt32(rm.Rows[0]["category_id"]);
            label_check_in.Text = Convert.ToString(check_in);
            label_check_out.Text = Convert.ToString(check_out);
            label_guests_count.Text = Convert.ToString(guests_count);

            label_room_number.Text = Convert.ToString(rm.Rows[0]["room_number"]);
            label_room_description.Text = Convert.ToString(rm.Rows[0]["description"]);

            var categoryadapter = new CategoryTableAdapter();
            var ct = categoryadapter.GetCategory(category_id);
            price_per_day = Convert.ToInt32(ct.Rows[0]["price_per_day"]);
            label_price_per_day.Text = Convert.ToString(price_per_day);
            label_categoryname.Text = Convert.ToString(ct.Rows[0]["name"]);
            label_categort_description.Text = Convert.ToString(ct.Rows[0]["description"]);
            label_total_amount.Text = Convert.ToString(price_per_day * (check_out - check_in).Days);


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
                label10.Text = "Зручностей немає";
                return;
            }


        }
        private void CreateBookingForm_Load(object sender, EventArgs e)
        {
            if (!addroom)
            {
                var adapter = new BookingTableAdapter();
                booking_id = Convert.ToInt32(adapter.InsertBooking(client_id, client_id, DateTime.Now, "1", 1, "1"));
            }
            
            fillinfo();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!addroom&&!alreadycr)
            {
                var adapter = new BookingTableAdapter();
                adapter.DeleteBooking(booking_id);
                var list = new ListFreeRoomsForm(client_id, check_in, check_out, guests_count, false, 0, false);
                list.Show();
                this.Close();
            }
            else
            {
                var list = new ListFreeRoomsForm(client_id, check_in, check_out, guests_count, addroom, booking_id, alreadycr);
                list.Show();
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var adapter = new Room_bookingTableAdapter();
            adapter.InsertRoomBooking(booking_id, room_id, check_in, check_out, guests_count);
            if (alreadycr)
            {
                var booking = new BookingDetailsForm(booking_id, client_id);
                booking.Show();
                this.Close();
            }
            else
            {
                var booking = new _2CreateBookingForm(booking_id, client_id);
                booking.Show();
                this.Close();
            }

        }
    }
}
