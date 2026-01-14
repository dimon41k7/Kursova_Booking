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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotel_booking
{
    public partial class MyBookingsForm: Form
    {
        private int client_id;
        private string currentSortColumn = "created_at";
        private string currentSortDirection = "ASC";

        private BookingFilter currentBookingFilter;
        public MyBookingsForm(int id)
        {
            InitializeComponent();
            client_id = id;
        }

        private void MyBookingsForm_Load(object sender, EventArgs e)
        {
            this.clientTableAdapter.Fill(this.hotel_bookingDataSet.Client);

            listView_mybookings.BorderStyle = BorderStyle.FixedSingle;
            listView_mybookings.View = View.Details;
            listView_mybookings.Columns.Clear();
            listView_mybookings.Columns.Add("Створення", 120);
            listView_mybookings.Columns.Add("Сума", 100);
            listView_mybookings.Columns.Add("Статус", 120);

            var adapter = new DataTable2TableAdapter();
            var dt = adapter.GetDataShortBooking(client_id);

            listView_mybookings.Items.Clear();

            if (dt.Rows.Count == 0)
            {
                listView_mybookings.Visible = false;
                labelnobooking.Visible = true;
                button_filter.Visible = false;
                button_filtr_cancel.Visible = false;

                labelnobooking.Text = "У вас ще немає бронювань.";
            }
            else
            {
                listView_mybookings.Visible = true;
                labelnobooking.Visible = false;
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(
                        Convert.ToDateTime(row["created_at"]).ToShortDateString());
                    item.SubItems.Add(row["total_amount"].ToString() + " грн");
                    item.SubItems.Add(row["status"].ToString());


                    item.Tag = row["booking_id"];

                    listView_mybookings.Items.Add(item);
                }
            }



            var adapter1 = new DataTable3TableAdapter();
            var mm = adapter1.GetMinMaxForFIlter(client_id);


            var row1 = mm.Rows[0];

            DateTime minDate = row1.IsNull("mindate") ? DateTime.Today : Convert.ToDateTime(row1["mindate"]);
            DateTime maxDate = row1.IsNull("maxdate") ? DateTime.Today : Convert.ToDateTime(row1["maxdate"]);
            decimal minTotal = row1.IsNull("minamount") ? 0 : Convert.ToDecimal(row1["minamount"]);
            decimal maxTotal = row1.IsNull("maxamount") ? 0 : Convert.ToDecimal(row1["maxamount"]);

            currentBookingFilter = new BookingFilter(minDate, maxDate, minTotal, maxTotal, false, false, false, false, false);
        }

        private void listView_mybookings_DoubleClick(object sender, EventArgs e)
        {
            if (listView_mybookings.SelectedItems.Count == 0)
                return;

            var item = listView_mybookings.SelectedItems[0];

            int bookingId = Convert.ToInt32(item.Tag);

            var form = new BookingDetailsForm(bookingId, client_id);
            this.Close();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new MainForm(client_id, false, 0, false);
            this.Close();
            form.Show();
        }

        private void button_filter_Click(object sender, EventArgs e)
        {
            var filterForm = new BookingFilterForm(currentBookingFilter, client_id);

            filterForm.ShowDialog();
            currentBookingFilter = filterForm.CurrentFilter;

            ApplyBookingFilter();
        }

        private void button_filtr_cancel_Click(object sender, EventArgs e)
        {
            var adapter = new DataTable3TableAdapter();
            var mm = adapter.GetMinMaxForFIlter(client_id);


            if (mm.Rows.Count == 0)
            {
                currentBookingFilter = new BookingFilter(DateTime.Today, DateTime.Today, 0, 0, false, false, false, false, false);
            }
            else
            {
                var row = mm.Rows[0];
                currentBookingFilter = new BookingFilter(Convert.ToDateTime(row["mindate"]), Convert.ToDateTime(row["maxdate"]), Convert.ToDecimal(row["minamount"]), Convert.ToDecimal(row["maxamount"]), false, false, false, false, false);
            }
            ApplyBookingFilter();
        }

        private void ApplyBookingFilter()
        {
            var adapter = new BookingTableAdapter();

            DateTime dateFrom = currentBookingFilter.CreatedFrom;
            DateTime dateTo = currentBookingFilter.CreatedTo;
            decimal? amountMin = currentBookingFilter.AmountMin;
            decimal? amountMax = currentBookingFilter.AmountMax;
            bool StatusPending = currentBookingFilter.StatusPending;
            bool StatusComfirmed = currentBookingFilter.StatusComfirmed;
            bool StatusPaid = currentBookingFilter.StatusPaid;
            bool StatusCanceled = currentBookingFilter.StatusCanceled;
            bool StatusCompleted = currentBookingFilter.StatusCompleted;


            var statuses = new List<string>();
            if (StatusPending) statuses.Add("Очікує");
            if (StatusComfirmed) statuses.Add("Підтверджено");
            if (StatusPaid) statuses.Add("Оплачено");
            if (StatusCanceled) statuses.Add("Скасовано");
            if (StatusCompleted) statuses.Add("Завершено");

            string statusFilter = statuses.Count > 0
                ? string.Join(",", statuses.Select(s => $"{s}"))
                : "";

            var adapter1 = new Booking1TableAdapter();
            var filteredTable = adapter1.GetFilteredBooking(dateFrom, dateTo, amountMin, amountMax, statusFilter, client_id, $"{currentSortColumn} {currentSortDirection}");

            listView_mybookings.Items.Clear();

            if (filteredTable.Rows.Count == 0)
            {
                listView_mybookings.Visible = false;
                labelnobooking.Visible = true; 

                labelnobooking.Text = "Немає підходящих бронювань!";
            }
            else
            {
                listView_mybookings.Visible = true;
                labelnobooking.Visible = false;
                foreach (DataRow row in filteredTable.Rows)
                {
                    ListViewItem item = new ListViewItem(
                        Convert.ToDateTime(row["created_at"]).ToShortDateString());
                    item.SubItems.Add(row["total_amount"].ToString() + " грн");
                    item.SubItems.Add(row["status"].ToString());


                    item.Tag = row["booking_id"];

                    listView_mybookings.Items.Add(item);
                }
            }

        }

        private void listView_mybookings_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            switch (e.Column)
            {
                case 0:
                    currentSortColumn = "created_at";
                    break;

                case 1:
                    currentSortColumn = "total_amount";
                    break;

                case 2:
                    currentSortColumn = "status";
                    break;
            }

            if (currentSortDirection == "ASC")
                currentSortDirection = "DESC";
            else
                currentSortDirection = "ASC";

            ApplyBookingFilter();
        }
    }
}
