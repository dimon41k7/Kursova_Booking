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
    public partial class PopularCategory: Form
    {
        public PopularCategory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PopularCategory_Load(object sender, EventArgs e)
        {

            listView_category.BorderStyle = BorderStyle.FixedSingle;
            listView_category.View = View.Details;
            listView_category.Columns.Clear();
            listView_category.Columns.Add("Назва", 120);
            listView_category.Columns.Add("Кількість бронювань", 100);
            listView_category.Columns.Add("Частка від загальної кількості бронювань", 120);
            listView_category.Columns.Add("Середня тривалість проживання", 120);

            var adapter = new Category1TableAdapter();
            var dt = adapter.GetPopularCategory();

            listView_category.Items.Clear();


            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(
                    row["name"].ToString());
                item.SubItems.Add(row["bookings_count"].ToString());
                item.SubItems.Add(row["percent_of_total"].ToString()+"%");
                item.SubItems.Add(row["avg_stay_length"].ToString());

                listView_category.Items.Add(item);
            }

        }
    }
}
