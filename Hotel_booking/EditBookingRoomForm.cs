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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Hotel_booking
{
    public partial class EditBookingRoomForm: Form
    {
        private int booking_id;
        private int client_id;
        private int room_booking_id;
        private DateTime check__in;
        private DateTime check__out;
        public EditBookingRoomForm(int id, int id2, int id3)
        {
            InitializeComponent();
            booking_id = id;
            client_id = id2;
            room_booking_id = id3;
        }

        private void EditBookingRoomForm_Load(object sender, EventArgs e)
        {
            var adapter = new DataTable5TableAdapter();
            var bk = adapter.GetInfoAboutRoomBooking(room_booking_id);

            check__in  = Convert.ToDateTime(bk.Rows[0]["check_in_date"]);
            check__out = Convert.ToDateTime(bk.Rows[0]["check_out_date"]);
            dateTimePicker_check_in_date.Value = check__in;
            dateTimePicker_check_out_date.Value = check__out;
            textBox_guests_count.Text = Convert.ToString(bk.Rows[0]["guests_count"]);
            
            

            if (check__in <= DateTime.Today)
            {
                dateTimePicker_check_in_date.Enabled = false;
            }
            else
            {
                dateTimePicker_check_in_date.MinDate = DateTime.Today.AddDays(1);
            }

            if (check__out <= DateTime.Today)
            {
                dateTimePicker_check_out_date.Enabled = false;
            }
            else
            {
                dateTimePicker_check_out_date.MinDate = DateTime.Today.AddDays(2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            var adapter = new DataTable5TableAdapter();
            var bk = adapter.GetInfoAboutRoomBooking(room_booking_id);
            int capacity = Convert.ToInt32(bk.Rows[0]["capacity"]);
            int room_id = Convert.ToInt32(bk.Rows[0]["room_id"]);

            DateTime checkIn = dateTimePicker_check_in_date.Value.Date;
            DateTime checkOut = dateTimePicker_check_out_date.Value.Date;
            if (checkOut <= checkIn)
            {
                MessageBox.Show("Дата виїзду має бути пізніше дати заїзду!");
                return;
            }

            var roomadapter = new Room_bookingTableAdapter();
            var bookings = roomadapter.GetDataAboutRoomForEditDate(room_id, checkOut.ToString("yyyy-MM-dd"), checkIn.ToString("yyyy-MM-dd"), room_booking_id);

            if (bookings.Rows.Count != 0)
            {
                MessageBox.Show("На ці дати номер уже заброньований!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox_guests_count.Text))
            {
                MessageBox.Show("Заповніть поле, яке відповідає за кількість гостей!");
                return;
            }

            int guests;
            if (!int.TryParse(textBox_guests_count.Text, out guests))
            {
                MessageBox.Show("Некоректна кількість гостей!");
                return;
            }

            if (guests > capacity)
            {
                MessageBox.Show($"Кількість гостей не може бути більшою за місткість номера ({capacity}).");
                return;
            }

            if (guests < 1)
            {
                MessageBox.Show($"Кількість гостей не може бути меншою за 1.");
                return;
            }

            var result = MessageBox.Show(
                "Ви впевнені, що хочете зберегти зміни?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                var rbadapter = new Room_bookingTableAdapter();
                rbadapter.UpdateBookingInfo(dateTimePicker_check_in_date.Value.ToString("yyyy-MM-dd"), dateTimePicker_check_out_date.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(textBox_guests_count.Text), room_booking_id);
                this.Close();
            }
        }
    }
}
