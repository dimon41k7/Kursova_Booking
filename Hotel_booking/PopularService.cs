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
    public partial class PopularService: Form
    {
        public PopularService()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PopularService_Load(object sender, EventArgs e)
        {
            listView_services.Columns.Clear();
            listView_services.Columns.Add("Назва послуги", 150);
            listView_services.Columns.Add("Опис", 250);
            listView_services.Columns.Add("Кількість бронювань", 150);
            var adapter = new DataTable15TableAdapter();
            var dt = adapter.GetPopularService();

            listView_services.View = View.Details;
            listView_services.FullRowSelect = true;
            listView_services.GridLines = true;

            listView_services.Items.Clear();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Популярні послуги не знайдені");
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                string name = row["name"].ToString();
                string description = row["description"].ToString();

                int usage_count = row.IsNull("usage_count")
                    ? 0
                    : Convert.ToInt32(row["usage_count"]);

                ListViewItem item = new ListViewItem(name);
                item.SubItems.Add(description);
                item.SubItems.Add(usage_count.ToString());

                listView_services.Items.Add(item);
            }
        }
    }
}
