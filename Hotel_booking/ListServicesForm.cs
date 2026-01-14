using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_booking.hotel_bookingDataSetTableAdapters;

namespace Hotel_booking
{
    public partial class ListServicesForm: Form
    {
        private int client_id;
        private int booking_id;
        private bool alreadycr;
        public ListServicesForm(int client_id, int booking_id, bool alreadycr)
        {
            InitializeComponent();
            this.client_id = client_id;
            this.booking_id = booking_id;
            this.alreadycr = alreadycr;
        }
        private void fillinfo()
        {
            var adapter1 = new ServiceTableAdapter();
            var fa = adapter1.GetServices();
            listView_services.Items.Clear();
            listView_services.Columns.Clear();
            listView_services.View = View.Details;
            listView_services.Columns.Add("Назва", 100);
            listView_services.Columns.Add("Опис", 350);
            listView_services.Columns.Add("Ціна за день", 100);

            foreach (DataRow row in fa.Rows)
            {
                ListViewItem item = new ListViewItem(
                    row["name"].ToString());
                item.SubItems.Add(row["description"].ToString());
                item.SubItems.Add(row["price_per_day"].ToString() + "грн");


                item.Tag = row["service_id"];

                listView_services.Items.Add(item);
            }
            if (fa.Rows.Count == 0)
            {
                listView_services.Visible = false;
                button1.Visible = false;
                label2.Text = "Доступних додаткових послуг немає";
                return;
            }
        }

        private void ListServicesForm_Load(object sender, EventArgs e)
        {
            fillinfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView_services.SelectedItems.Count == 0)
            {
                MessageBox.Show("Оберіть послугу зі списку!");
                return;

            }

            ListViewItem item = listView_services.SelectedItems[0];

            int service_id = Convert.ToInt32(item.Tag);

            var service = new AddServiceForm(client_id, booking_id, service_id, alreadycr);
            service.Show();
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string name = textBox_name.Text.Trim().ToLower();
            string description = textBox_description.Text.Trim().ToLower();
            

            if (string.IsNullOrEmpty(description) && string.IsNullOrEmpty(name))
            {
                foreach (ListViewItem item in listView_services.Items)
                    item.BackColor = Color.White;


                MessageBox.Show("Заповніть хоча б одне поле для пошуку!");
                return;
            }

            foreach (ListViewItem item in listView_services.Items)
                item.BackColor = Color.White;

            bool found = false;

            foreach (ListViewItem item in listView_services.Items)
            {
                string rowName = item.SubItems[0].Text.ToLower();
                string rowDescription = item.SubItems[1].Text.ToLower();

                bool match = false;

                if (!string.IsNullOrEmpty(description) && string.IsNullOrEmpty(name))
                    match = rowDescription.Contains(description);
                else if (string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(name))
                    match = rowName.Contains(name);
                else if (!string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(name))
                    match = rowDescription.Contains(description) && rowName.Contains(name);

                if (match)
                {
                    item.BackColor = Color.LightGreen;
                    found = true;
                }
            }

            if (!found)
                MessageBox.Show("Нічого не знайдено.");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_services.Items)
                item.BackColor = Color.White;
        }
    }
}
