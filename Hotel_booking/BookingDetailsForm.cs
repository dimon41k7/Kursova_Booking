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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Hotel_booking
{
    public partial class BookingDetailsForm: Form
    {
        private int booking_id;
        private int client_id;
        private int customer_id;
        private string status;
        public BookingDetailsForm(int id, int id2)
        {
            InitializeComponent();
            booking_id = id;
            client_id = id2;
        }

        private void fillinfo()
        {
            var adapter = new DataTable1TableAdapter();
            var bk = adapter.GetDataFullBooking(booking_id);

            label_created_at.Text = Convert.ToString(bk.Rows[0]["created_at"]);
            status = Convert.ToString(bk.Rows[0]["status"]);
            label_status.Text = status;
            label_notes.Text = Convert.ToString(bk.Rows[0]["notes"]);
            customer_id = Convert.ToInt32(bk.Rows[0]["customer_id"]);

            if (status != "Очікує")
            {
                button_cancel.Visible = false;
            }

            if (status != "Очікує"&& status != "Підтверджено")
            {
                button_p.Visible = false;
            }

            if(status == "Очікує")
            {
                button_p.Text = "Внести передплату";
            }

            if (status == "Підтверджено")
            {
                button_p.Text = "Внести доплату";
            }

            var adapt = new DataTable9TableAdapter();
            var tp = adapt.GetTotalAmount(booking_id);
            decimal total_amount;
            if (tp.Rows.Count > 0 && tp.Rows[0][0] != DBNull.Value)
            {
                total_amount = Convert.ToDecimal(tp.Rows[0][0]);
            }
            else
            {
                total_amount = 0;
            }

            label_total_amount.Text = Convert.ToString(total_amount);



            if (customer_id == client_id)
            {
                label12.Text = "Бронювання здійснено на вас!";
                label_customer.Visible = false;
            }
            else
            {
                label12.Text = "Бронювання здійснено на:";
                label_customer.Visible = true;
                var adapterr = new ClientTableAdapter();
                var cl = adapterr.GetDataById(Convert.ToInt32(customer_id));
                label_customer.Text = Convert.ToString(cl.Rows[0]["last_name"]) + " " + Convert.ToString(cl.Rows[0]["first_name"]) + " " + Convert.ToString(cl.Rows[0]["middle_name"]);
            }



            listView_rooms.BorderStyle = BorderStyle.FixedSingle;
            listView_rooms.View = View.Details;
            listView_rooms.Columns.Clear();
            listView_rooms.Columns.Add("Номер кімнати", 120);
            listView_rooms.Columns.Add("Категорія", 120);
            listView_rooms.Columns.Add("Дата заїзду", 120);
            listView_rooms.Columns.Add("Дата виїзду", 120);


            listView_rooms.Items.Clear();


            var adapter1 = new DataTable6TableAdapter();
            var book = adapter1.GetDataAboutBookingRoom(booking_id);
            if (book.Rows.Count == 0)
            {
                listView_rooms.Visible = false;
                label2.Visible = true;
                label1.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                label_search.Visible = false;
                label9.Visible = false;
                label8.Visible = false;
                textBox_room_number.Visible = false;
                textBox_category.Visible = false;
                button_search.Visible = false;
                button_search_cancel.Visible = false;
            }
            else
            {
                listView_rooms.Visible = true;
                label2.Visible = false;

                foreach (DataRow row in book.Rows)
                {
                    ListViewItem item = new ListViewItem(row["room_number"].ToString());

                    item.SubItems.Add(row["name"].ToString());

                    item.SubItems.Add(
                        Convert.ToDateTime(row["check_in_date"]).ToShortDateString());

                    item.SubItems.Add(
                        Convert.ToDateTime(row["check_out_date"]).ToShortDateString());

                    item.Tag = row["room_booking_id"];

                    listView_rooms.Items.Add(item);
                }
            }



            listView_services.BorderStyle = BorderStyle.FixedSingle;
            listView_services.View = View.Details;
            listView_services.Columns.Clear();
            listView_services.Columns.Add("Назва послуги", 120);
            listView_services.Columns.Add("Кількість днів", 120);
            listView_services.Columns.Add("Кількість осіб", 120);
            var serviceadapter = new Service1TableAdapter();
            var sa = serviceadapter.GetShortInfoAboutService(booking_id);
            listView_services.Items.Clear();

            if (sa.Rows.Count == 0)
            {
                listView_services.Visible = false;
                label10.Visible = false;
                label_noservice.Visible = true;
                button7.Visible = false;
                button6.Visible = false;
                label11.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                textBox_name.Visible = false;
                textBox_days.Visible = false;
                textBox_persons.Visible = false;
                button12.Visible = false;
                button11.Visible = false;
                label_noservice.Text = "Заброньованих додаткових послуг немає.";
            }
            else
            {
                listView_services.Visible = true;
                label_noservice.Visible = false;

                foreach (DataRow row in sa.Rows)
                {
                    ListViewItem item = new ListViewItem(row["name"].ToString());

                    item.SubItems.Add(row["days_count"].ToString());
                    item.SubItems.Add(row["persons_count"].ToString());

                    item.Tag = row["service_booking_id"];

                    listView_services.Items.Add(item);
                }
            }
            if (status == "Скасовано"||status=="Завершено"||status=="Оплачено")
            {
                button_cancel.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
            }
            
        }

        private void BookingDetailsForm_Load(object sender, EventArgs e)
        {
            fillinfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new MyBookingsForm(client_id);
            this.Close();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new EditBookingForm(booking_id, client_id==customer_id, client_id);
            form.ShowDialog();
            fillinfo();
            
        }

        private void listView_rooms_DoubleClick(object sender, EventArgs e)
        {
            if (listView_rooms.SelectedItems.Count == 0)
                return;

            var item = listView_rooms.SelectedItems[0];

            int room_booking_Id = Convert.ToInt32(item.Tag);

            var form = new RoomBookingDetailsForm(booking_id, client_id, room_booking_Id);
            this.Close();
            form.Show();
        }

        private void listView_services_DoubleClick(object sender, EventArgs e)
        {
            if (listView_services.SelectedItems.Count == 0)
                return;

            var item = listView_services.SelectedItems[0];

            int service_booking_Id = Convert.ToInt32(item.Tag);

            var form = new ServiceBookingDetailsForm(booking_id, client_id, service_booking_Id);
            this.Close();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var add = new MainForm(client_id, true, booking_id, true);
            add.Show();
            this.Close();
        }

        private void BookingDetailsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var adapt = new DataTable9TableAdapter();
            var tp = adapt.GetTotalAmount(booking_id);
            decimal total_amount;
            if (tp.Rows.Count > 0 && tp.Rows[0][0] != DBNull.Value)
            {
                total_amount = Convert.ToDecimal(tp.Rows[0][0]);
            }
            else
            {
                total_amount = 0;
            }

            var adapter = new BookingTableAdapter();
            adapter.UpdateTotalAmount(total_amount, booking_id);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView_rooms.SelectedItems.Count == 0)
            {
                MessageBox.Show("Оберіть бронювання кімнати зі списку!");
                return;

            }

            ListViewItem item = listView_rooms.SelectedItems[0];

            int room_bookingId = Convert.ToInt32(item.Tag);

            var form = new EditBookingRoomForm(booking_id, client_id, room_bookingId);
            form.ShowDialog();
            fillinfo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView_rooms.SelectedItems.Count == 0)
            {
                MessageBox.Show("Оберіть бронювання кімнати зі списку!");
                return;

            }

            ListViewItem item = listView_rooms.SelectedItems[0];

            int room_bookingId = Convert.ToInt32(item.Tag);

            var adapter1 = new DataTable5TableAdapter();
            var bk = adapter1.GetInfoAboutRoomBooking(room_bookingId);

            DateTime check = Convert.ToDateTime(bk.Rows[0]["check_in_date"]);

            string check_in = check.ToShortDateString();
            string check_out = Convert.ToDateTime(bk.Rows[0]["check_out_date"]).ToShortDateString();
            string room_number = Convert.ToString(bk.Rows[0]["room_number"]);

            if (check <= DateTime.Today)
            {
                MessageBox.Show("Бронювання кімнати не можна видалити, якщо дата заїзду вже сьогодні або вже минула.");
                return;
            }

            var result = MessageBox.Show(
                $"Ви впевнені, що хочете видалити бронювання кімнати {room_number} з {check_in} по {check_out}?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var adapter = new Room_bookingTableAdapter();
                adapter.DeleteRoomBoking(room_bookingId);
                fillinfo();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var list = new ListServicesForm(client_id, booking_id, true);
            list.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listView_services.SelectedItems.Count == 0)
            {
                MessageBox.Show("Оберіть бронювання послуги зі списку!");
                return;

            }

            ListViewItem item = listView_services.SelectedItems[0];

            int service_bookingId = Convert.ToInt32(item.Tag);

            var form = new EditBookingServiceForm(booking_id, client_id, service_bookingId);
            form.ShowDialog();
            fillinfo();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listView_services.SelectedItems.Count == 0)
            {
                MessageBox.Show("Оберіть бронювання послуги зі списку!");
                return;

            }

            ListViewItem item = listView_services.SelectedItems[0];

            int service_bookingId = Convert.ToInt32(item.Tag);

            var adapter1 = new Service2TableAdapter();
            var bk = adapter1.GetNameService(service_bookingId);

            string name = Convert.ToString(bk.Rows[0]["name"]);

            var result = MessageBox.Show(
                $"Ви впевнені, що хочете видалити бронювання послуги {name}?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var adapter = new Service_bookingTableAdapter();
                adapter.DeleteQuery(service_bookingId);
                fillinfo();
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Ви впевнені, що хочете скасувати бронювання?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                var adapter = new BookingTableAdapter();
                adapter.UpdateStatus("Скасовано", booking_id);
                fillinfo();
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            string room_number = textBox_room_number.Text.Trim().ToLower();
            string category = textBox_category.Text.Trim().ToLower();


            if (string.IsNullOrEmpty(room_number) && string.IsNullOrEmpty(category))
            {
                foreach (ListViewItem item in listView_rooms.Items)
                    item.BackColor = Color.White;


                MessageBox.Show("Заповніть хоча б одне поле для пошуку!");
                return;
            }

            foreach (ListViewItem item in listView_rooms.Items)
                item.BackColor = Color.White;

            bool found = false;

            foreach (ListViewItem item in listView_rooms.Items)
            {
                string rowNumber = item.SubItems[0].Text.ToLower();
                string rowCategory = item.SubItems[1].Text.ToLower();

                bool match = false;

                if (!string.IsNullOrEmpty(room_number) && string.IsNullOrEmpty(category))
                    match = rowNumber.Contains(room_number);
                else if (string.IsNullOrEmpty(room_number) && !string.IsNullOrEmpty(category))
                    match = rowCategory.Contains(category);
                else if (!string.IsNullOrEmpty(room_number) && !string.IsNullOrEmpty(category))
                    match = rowNumber.Contains(room_number) && rowCategory.Contains(category);

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
            foreach (ListViewItem item in listView_rooms.Items)
                item.BackColor = Color.White;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string name = textBox_name.Text.Trim().ToLower();
            string days = textBox_days.Text.Trim().ToLower();
            string persons = textBox_persons.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(days) && string.IsNullOrEmpty(persons))
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
                string rowDays = item.SubItems[1].Text.ToLower();
                string rowPersons = item.SubItems[2].Text.ToLower();

                bool match = false;

                if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(days) && string.IsNullOrEmpty(persons))
                    match = rowName.Contains(name);
                else if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(days) && string.IsNullOrEmpty(persons))
                    match = rowDays.Contains(days);
                else if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(days) && !string.IsNullOrEmpty(persons))
                    match = rowPersons.Contains(persons);
                else if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(days) && string.IsNullOrEmpty(persons))
                    match = rowName.Contains(name) && rowDays.Contains(days);
                else if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(days) && !string.IsNullOrEmpty(persons))
                    match = rowName.Contains(name) && rowPersons.Contains(persons);
                else if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(days) && !string.IsNullOrEmpty(persons))
                    match = rowDays.Contains(days) && rowPersons.Contains(persons);
                else if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(days) && !string.IsNullOrEmpty(persons))
                    match = rowName.Contains(name) && rowDays.Contains(days) && rowPersons.Contains(persons);

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

        private void button9_Click(object sender, EventArgs e)
        {
            var adapt = new DataTable9TableAdapter();
            var tp = adapt.GetTotalAmount(booking_id);
            decimal total_amount;
            if (tp.Rows.Count > 0 && tp.Rows[0][0] != DBNull.Value)
            {
                total_amount = Convert.ToDecimal(tp.Rows[0][0]);
            }
            else
            {
                total_amount = 0;
            }
            decimal payment_amount = 0;
            string payment_type = "";
            if (status == "Очікує")
            {
                payment_amount = total_amount * 0.15m;
                payment_type = "Передплата";
            }
            else if(status == "Підтверджено")
            {
                var adapt1 = new DataTable13TableAdapter();
                var tp1 = adapt1.GetTotalPaid(booking_id);
                decimal total_paid;
                if (tp1.Rows.Count > 0 && tp1.Rows[0][0] != DBNull.Value)
                {
                    total_paid = Convert.ToDecimal(tp1.Rows[0][0]);
                }
                else
                {
                    total_paid = 0;
                }
                payment_amount = total_amount - total_paid;
                payment_type = "Доплата";
            }

            var form = new PaymentForm(booking_id, client_id, payment_amount, payment_type);
            form.Show();
            this.Close();
        }

    }
}
