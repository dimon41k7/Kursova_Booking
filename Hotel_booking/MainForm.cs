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
    public partial class MainForm: Form
    {
        private int client_id;
        private int booking_id;
        private bool addroom;
        private bool alreadycr;
        public MainForm(int id,  bool addroom, int booking_id, bool alreadycr)
        {
            InitializeComponent();
            client_id = id;
            this.addroom = addroom;
            this.booking_id = booking_id;
            this.alreadycr = alreadycr;
        }

        private void особистаІнформаціяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pf = new ProfileForm(client_id);
            pf.Show();
            this.Close();
        }

        private void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            var loginform = new LoginForm();
            loginform.Show();
            this.Close();
        }

        private void моїБронюванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mb = new MyBookingsForm(client_id);
            mb.Show();
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dateTime_check_in.MinDate = DateTime.Today.AddDays(1);
            dateTime_check_out.MinDate = DateTime.Today.AddDays(2);
            textBox_guests_count.Text = "1";
            if (addroom||alreadycr)
            {
                менюToolStripMenuItem.Visible = false;
            }
            else
            {
                button2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime checkIn = dateTime_check_in.Value.Date;
            DateTime checkOut = dateTime_check_out.Value.Date;
            if (checkOut <= checkIn)
            {
                MessageBox.Show("Дата виїзду має бути пізніше дати заїзду!");
                return;
            }
            int guests;
            if (!int.TryParse(textBox_guests_count.Text, out guests))
            {
                MessageBox.Show("Некоректна кількість гостей!");
                return;
            }
            if (guests < 1)
            {
                MessageBox.Show($"Кількість гостей не може бути меншою за 1.");
                return;
            }


            if (!alreadycr && !addroom)
            {
                var adapter = new DataTable12TableAdapter();
                var act = adapter.GetCountBookings(client_id);
                int activebooking = Convert.ToInt32(act[0]["active_bookings"]);
                if (activebooking >= 3)
                {
                    MessageBox.Show("Ви не створити нове бронювання,бо вже маєте 3 неоплачені бронювання!");
                    return;
                }
            }


            var list = new ListFreeRoomsForm(client_id, checkIn, checkOut, guests, addroom, booking_id, alreadycr);
            list.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (addroom&&!alreadycr)
            {
                var booking = new _2CreateBookingForm(booking_id, client_id);
                booking.Show();
                this.Close();
            }
            if (alreadycr)
            {
                var booking = new BookingDetailsForm(booking_id, client_id);
                booking.Show();
                this.Close();
            }
        }

        private void моїОплатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new MyPaymentsForm(client_id);
            this.Close();
            form.Show();
        }

        private void статистикаБронюваньToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new BookingStatisticsForm(client_id);
            form.ShowDialog();
        }

        private void статистикаВитратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PaymentStatisticsForm(client_id);
            form.ShowDialog();
        }

        private void найпопулярнішаПослугаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PopularService();
            form.ShowDialog();
        }

        private void найпопулярнішаКатегоріяНомеруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PopularCategory();
            form.ShowDialog();
        }

        private void бронюванняЗаПеріодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ListBookings(client_id);
            form.ShowDialog();
        }
    }
}
