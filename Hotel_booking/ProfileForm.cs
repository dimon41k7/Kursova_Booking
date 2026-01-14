using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_booking.hotel_bookingDataSetTableAdapters;

namespace Hotel_booking
{
    public partial class ProfileForm: Form
    {

        private int client_id;
        public ProfileForm(int id)
        {
            InitializeComponent();
            client_id = id;
        }

        private void fillinfo()
        {
            var client = clientTableAdapter.GetDataById(client_id);
            label_last_name.Text = Convert.ToString(client.Rows[0]["last_name"]);
            label_first_name.Text = Convert.ToString(client.Rows[0]["first_name"]);
            label_middle_name.Text = Convert.ToString(client.Rows[0]["middle_name"]);
            label_bith_date.Text = Convert.ToDateTime(client.Rows[0]["birth_day"]).ToShortDateString();
            label_email.Text = Convert.ToString(client.Rows[0]["email"]);
            label_phone.Text = Convert.ToString(client.Rows[0]["phone"]);
        }
        private void ProfileForm_Load(object sender, EventArgs e)
        {
            this.clientTableAdapter.Fill(this.hotel_bookingDataSet.Client);
            fillinfo();
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            var form = new EditProfileForm(client_id);
            form.ShowDialog();
            fillinfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new MainForm(client_id, false, 0, false);
            form.Show();
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var adapter = new DataTable11TableAdapter();
            var act = adapter.GetCountActiveBooking(client_id);
            int activebooking = Convert.ToInt32(act[0]["active_bookings"]);
            if (activebooking != 0)
            {
                MessageBox.Show("Ви не можете видалити аккаунт, бо маєте активні бронювання!");
                return;
            }

            var result = MessageBox.Show(
                "Ви впевнені, що хочете видалити аккаунт?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                var clientadapt = new ClientTableAdapter();
                clientadapt.DeleteClient(client_id);

                var form = new LoginForm();
                form.Show();
                this.Close();
            }  
        }
    }
}
