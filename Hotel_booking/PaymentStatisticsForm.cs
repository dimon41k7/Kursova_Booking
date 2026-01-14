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
    public partial class PaymentStatisticsForm: Form
    {
        private int client_id;
        public PaymentStatisticsForm(int client_id)
        {
            InitializeComponent();
            this.client_id = client_id;
        }

        private void PaymentStatisticsForm_Load(object sender, EventArgs e)
        {
            var adapter = new Client3TableAdapter();
            var dt = adapter.GetPaymentStatistics(client_id);
            DataRow row = dt.Rows[0];
            decimal total = row.IsNull("total_paid")
                ? 0
                : Convert.ToDecimal(row["total_paid"]);

            decimal prepayments = row.IsNull("total_prepayments")
                ? 0
                : Convert.ToDecimal(row["total_prepayments"]);

            decimal addpayments = row.IsNull("total_addpayments")
                ? 0
                : Convert.ToDecimal(row["total_addpayments"]);

            decimal avg_cost = row.IsNull("avg_booking_cost")
                ? 0
                : Convert.ToDecimal(row["avg_booking_cost"]);

            string last_name = Convert.ToString(row["last_name"]);
            string first_name = Convert.ToString(row["first_name"]);
            string middle_name = Convert.ToString(row["middle_name"]);
            label_last_name.Text = last_name;
            label_first_name.Text = first_name;
            label_middle_name.Text = middle_name;
            label_total.Text = $"{total} грн";
            label_prepayment.Text = $"{prepayments} грн";
            label_add_payment.Text = $"{addpayments} грн";
            label_avg_price.Text = $"{avg_cost} грн";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
