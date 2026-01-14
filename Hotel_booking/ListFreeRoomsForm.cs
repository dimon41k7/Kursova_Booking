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
    public partial class ListFreeRoomsForm: Form
    {
        private DateTime check_in;
        private DateTime check_out;
        private int guests_count;
        private int client_id;
        private int booking_id;
        private bool addroom;
        private bool alreadycr;
        public ListFreeRoomsForm(int id, DateTime check_in, DateTime check_out, int guests_count, bool addroom, int booking_id , bool alreadycr)
        {
            InitializeComponent();
            client_id = id;
            this.check_in = check_in;
            this.check_out = check_out;
            this.guests_count = guests_count;
            this.addroom = addroom;
            this.booking_id = booking_id;
            this.alreadycr = alreadycr;
        }
        private void fillinfo()
        {
            label5.Text = Convert.ToString(check_in.ToShortDateString());
            label6.Text = Convert.ToString(check_out.ToShortDateString());
            var adapter1 = new DataTable8TableAdapter();
            var fa = adapter1.GetFreeRooms(guests_count, check_out, check_in);
            listView_free_rooms.Items.Clear();
            listView_free_rooms.Columns.Clear();
            listView_free_rooms.View = View.Details;
            listView_free_rooms.Columns.Add("Номер кімнати", 100);
            listView_free_rooms.Columns.Add("Опис", 350);
            listView_free_rooms.Columns.Add("Категорія", 100);
            listView_free_rooms.Columns.Add("Місткість", 100);
            listView_free_rooms.Columns.Add("Ціна за день", 100);

            foreach (DataRow row in fa.Rows)
            {
                ListViewItem item = new ListViewItem(
                    row["room_number"].ToString());
                item.SubItems.Add(row["description"].ToString());
                item.SubItems.Add(row["name"].ToString());
                item.SubItems.Add(row["capacity"].ToString());
                item.SubItems.Add(row["price_per_day"].ToString() + "грн");


                item.Tag = row["room_id"];

                listView_free_rooms.Items.Add(item);
            }
            if (fa.Rows.Count == 0)
            {
                listView_free_rooms.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label2.Text = "Вільних номерів на ці дати немає";
                button1.Visible = false;
                label_search.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                textBox_description.Visible = false;
                textBox_category.Visible = false;
                button_search.Visible = false;
                button_search_cancel.Visible = false;
                return;
            }
        }

        private void ListFreeRoomsForm_Load(object sender, EventArgs e)
        {
            fillinfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView_free_rooms.SelectedItems.Count == 0)
            {
                MessageBox.Show("Оберіть кімнату зі списку!");
                return;

            }

            ListViewItem item = listView_free_rooms.SelectedItems[0];

            int roomId = Convert.ToInt32(item.Tag);

            var bookingform = new CreateBookingForm(client_id, check_in, check_out, guests_count, roomId, addroom, booking_id, alreadycr);
            bookingform.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (!addroom && !alreadycr) {
                var form = new MainForm(client_id, false, 0, false);
                this.Close();
                form.Show();
            }
            else
            {

                var form = new MainForm(client_id, addroom, booking_id, alreadycr);
                this.Close();
                form.Show();
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            string description = textBox_description.Text.Trim().ToLower();
            string category = textBox_category.Text.Trim().ToLower();


            if (string.IsNullOrEmpty(description) && string.IsNullOrEmpty(category))
            {
                foreach (ListViewItem item in listView_free_rooms.Items)
                    item.BackColor = Color.White;


                MessageBox.Show("Заповніть хоча б одне поле для пошуку!");
                return;
            }

            foreach (ListViewItem item in listView_free_rooms.Items)
                item.BackColor = Color.White;

            bool found = false;

            foreach (ListViewItem item in listView_free_rooms.Items)
            {
                string rowDescription = item.SubItems[1].Text.ToLower();
                string rowCategory = item.SubItems[2].Text.ToLower();

                bool match = false;

                if (!string.IsNullOrEmpty(description) && string.IsNullOrEmpty(category))
                    match = rowDescription.Contains(description);
                else if (string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(category))
                    match = rowCategory.Contains(category);
                else if (!string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(category))
                    match = rowDescription.Contains(description) && rowCategory.Contains(category);

                if (match)
                {
                    item.BackColor = Color.LightGreen;
                    found = true;
                }
            }

            if (!found)
                MessageBox.Show("Нічого не знайдено.");
        }

        private void button_search_cancel_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_free_rooms.Items)
                item.BackColor = Color.White;
        }
    }
}
