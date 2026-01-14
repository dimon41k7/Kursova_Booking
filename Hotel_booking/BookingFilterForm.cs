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
    public partial class BookingFilterForm: Form
    {

        public BookingFilter CurrentFilter;
        private int client_id;
        public BookingFilterForm(BookingFilter filter, int client_id)
        {
            InitializeComponent();
            CurrentFilter = filter;
            this.client_id = client_id;

            dateFrom.Value = filter.CreatedFrom;

            dateTo.Value = filter.CreatedTo;

            textBox_AmountMin.Text = filter.AmountMin.ToString();
            textBox_AmountMax.Text = filter.AmountMax.ToString();

            checkBox_pending.Checked = filter.StatusPending;
            checkBox_paid.Checked = filter.StatusPaid;
            checkBox_confirmed.Checked = filter.StatusComfirmed;
            checkBox_canceled.Checked = filter.StatusCanceled;
            checkBox_completed.Checked = filter.StatusCompleted;
        }

        private void BookingFilterForm_Load(object sender, EventArgs e)
        {
            var adapter = new DataTable3TableAdapter();
            var mm = adapter.GetMinMaxForFIlter(client_id);
            var row = mm.Rows[0];
            DateTime mindate = Convert.ToDateTime(row["mindate"]);
            DateTime maxdate = Convert.ToDateTime(row["maxdate"]);
            dateFrom.MinDate = mindate;
            dateTo.MinDate = mindate;
            dateFrom.MaxDate = maxdate;
            dateTo.MaxDate = maxdate;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            var adapter = new DataTable3TableAdapter();
            var mm = adapter.GetMinMaxForFIlter(client_id);
            var row = mm.Rows[0];
            DateTime mindate = Convert.ToDateTime(row["mindate"]);
            DateTime maxdate = Convert.ToDateTime(row["maxdate"]);
            Decimal minamount = Convert.ToDecimal(row["minamount"]);
            Decimal maxamount = Convert.ToDecimal(row["maxamount"]);

            if (dateFrom.Value < mindate)
            {
                MessageBox.Show($"Дата 'Від' не може бути меншою за {mindate:d}");
                return;
            }

            if (dateTo.Value > maxdate)
            {
                MessageBox.Show($"Дата 'До' не може бути більшою за {maxdate:d}");
                return;
            }

            DateTime dateF = dateFrom.Value.Date;
            DateTime dateT = dateTo.Value.Date;
            if (dateF > dateT)
            {
                MessageBox.Show("Дата 'Від' не може бути більшою за дату 'До'");
                return;
            }


            decimal amountMin, amountMax;

            if (textBox_AmountMin.Text == "")
            {
                amountMin = minamount;
            }
            else
            {
                if (!decimal.TryParse(textBox_AmountMin.Text, out amountMin))
                {
                    MessageBox.Show("Мінімальна сума введена некоректно");
                    return;
                }
            }


            if (textBox_AmountMax.Text == "")
            {
                amountMax = maxamount;
            }else
            {
                if (!decimal.TryParse(textBox_AmountMax.Text, out amountMax))
                {
                    MessageBox.Show("Максимальна сума введена некоректно");
                    return;
                }
            } 

            if (amountMin < minamount)
            {
                MessageBox.Show($"Мінімальна сума не може бути меншою за {minamount}");
                return;
            }

            if (amountMax > maxamount)
            {
                MessageBox.Show($"Максимальна сума не може бути більшою за {maxamount}");
                return;
            }

            if (amountMin > amountMax)
            {
                MessageBox.Show("Мінімальна сума не може бути більшою за максимальну");
                return;
            }

            CurrentFilter.CreatedFrom = dateFrom.Value;
            CurrentFilter.CreatedTo = dateTo.Value;

            CurrentFilter.AmountMin = amountMin;

            CurrentFilter.AmountMax = amountMax;

            CurrentFilter.StatusPending = checkBox_pending.Checked;
            CurrentFilter.StatusPaid = checkBox_paid.Checked;
            CurrentFilter.StatusComfirmed = checkBox_confirmed.Checked;
            CurrentFilter.StatusCanceled = checkBox_canceled.Checked;
            CurrentFilter.StatusCompleted = checkBox_completed.Checked;
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
