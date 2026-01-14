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
    public partial class ListBookings: Form
    {
        private int client_id;
        public ListBookings(int client_id)
        {
            InitializeComponent();
            this.client_id = client_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = dateTime_check_in.Value.Date;
            DateTime dateTo = dateTime_check_out.Value.Date;

            if (dateFrom > dateTo)
            {
                MessageBox.Show("Дата заїзду не може бути пізніше дати виїзду");
                return;
            }

            var adapter = new DataTable17TableAdapter();
            var dt = adapter.GetBookings(dateFrom, dateTo, client_id);

            listView_bookings.Items.Clear();

            if (dt.Rows.Count == 0)
            {
                listView_bookings.Visible = false;
                label_no_booking.Visible = true;
                label_no_booking.Text = "На цей період немає бронювань";
            }
            else
            {
                listView_bookings.Visible = true;
                label_no_booking.Visible = false;
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(
                        (row["booking_id"].ToString()));
                    item.SubItems.Add(Convert.ToDateTime(row["created_at"]).ToShortDateString());
                    item.SubItems.Add(row["total_amount"].ToString() + " грн");
                    item.SubItems.Add(row["status"].ToString());


                    item.Tag = row["booking_id"];

                    listView_bookings.Items.Add(item);
                }
            }
        }

        private void ListBookings_Load(object sender, EventArgs e)
        {
            dateTime_check_in.MinDate = DateTime.Today.AddDays(1);
            dateTime_check_out.MinDate = DateTime.Today.AddDays(2);

            listView_bookings.Visible = false;

            listView_bookings.BorderStyle = BorderStyle.FixedSingle;
            listView_bookings.View = View.Details;
            listView_bookings.Columns.Clear();
            listView_bookings.Columns.Add("Номер бронювання", 120);
            listView_bookings.Columns.Add("Дата створення", 120);
            listView_bookings.Columns.Add("Сума", 120);
            listView_bookings.Columns.Add("Статус", 120);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
