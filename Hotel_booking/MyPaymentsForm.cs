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
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Tables;
namespace Hotel_booking
{
    public partial class MyPaymentsForm: Form
    {
        private int client_id;
        private string currentSortColumn = "created_at";
        private string currentSortDirection = "ASC";

        private PaymentFilter currentPaymentFilter;
        public MyPaymentsForm(int client_id)
        {
            InitializeComponent();
            this.client_id = client_id;
        }

        private void MyPaymentsForm_Load(object sender, EventArgs e)
        {
            listView_mypayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            listView_mypayments.View = View.Details;
            listView_mypayments.Columns.Clear();
            listView_mypayments.Columns.Add("№ бронювання", 120);
            listView_mypayments.Columns.Add("Тип оплати", 120);
            listView_mypayments.Columns.Add("Сума оплати", 120);
            listView_mypayments.Columns.Add("Спосіб оплати", 120);
            listView_mypayments.Columns.Add("Дата оплати", 120);

            var adapter = new PaymentTableAdapter();
            var dt = adapter.GetPayments(client_id);

            listView_mypayments.Items.Clear();

            if (dt.Rows.Count == 0)
            {
                listView_mypayments.Visible = false;
                labelnobooking.Visible = true;
                button_filter.Visible = false;
                button_filtr_cancel.Visible = false;

                labelnobooking.Text = "У вас ще немає оплат.";
                button2.Visible = false;
            }
            else
            {
                listView_mypayments.Visible = true;
                labelnobooking.Visible = false;
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(
                        row["booking_id"].ToString());
                    item.SubItems.Add(row["payment_type"].ToString());
                    item.SubItems.Add(row["payment_amount"].ToString() + " грн");
                    item.SubItems.Add(row["payment_method"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(row["payment_date"]).ToShortDateString());

                    item.Tag = row["payment_id"];

                    listView_mypayments.Items.Add(item);
                }
            }

            var adapter1 = new DataTable14TableAdapter();
            var mm = adapter1.GetMinMaxForFilter(client_id);

            var row1 = mm.Rows[0];

            DateTime minDate = row1.IsNull("mindate") ? DateTime.Today : Convert.ToDateTime(row1["mindate"]);
            DateTime maxDate = row1.IsNull("maxdate") ? DateTime.Today : Convert.ToDateTime(row1["maxdate"]);
            decimal minAmount = row1.IsNull("minamount") ? 0 : Convert.ToDecimal(row1["minamount"]);
            decimal maxAmount = row1.IsNull("maxamount") ? 0 : Convert.ToDecimal(row1["maxamount"]);

            currentPaymentFilter = new PaymentFilter(minDate, maxDate, minAmount, maxAmount, false, false, false, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new MainForm(client_id, false, 0, false);
            this.Close();
            form.Show();
        }

        private void button_filter_Click(object sender, EventArgs e)
        {
            var filterForm = new PaymentFilterForm(currentPaymentFilter, client_id);

            filterForm.ShowDialog();
            currentPaymentFilter = filterForm.CurrentFilter;

            ApplyBookingFilter();
        }

        private void button_filtr_cancel_Click(object sender, EventArgs e)
        {
            var adapter1 = new DataTable14TableAdapter();
            var mm = adapter1.GetMinMaxForFilter(client_id);

            if (mm.Rows.Count == 0)
            {
                currentPaymentFilter = new PaymentFilter(DateTime.Today, DateTime.Today, 0, 0, false, false, false, false);
            }
            else
            {
                var row = mm.Rows[0];
                currentPaymentFilter = new PaymentFilter(Convert.ToDateTime(row["mindate"]), Convert.ToDateTime(row["maxdate"]), Convert.ToDecimal(row["minamount"]), Convert.ToDecimal(row["maxamount"]), false, false, false, false);
            }
            ApplyBookingFilter();
        }

        private void ApplyBookingFilter()
        {
            var adapter = new BookingTableAdapter();

            DateTime dateFrom = currentPaymentFilter.PaymentDateFrom;
            DateTime dateTo = currentPaymentFilter.PaymentDateTo;
            decimal amountMin = currentPaymentFilter.AmountMin;
            decimal amountMax = currentPaymentFilter.AmountMax;
            bool prePay = currentPaymentFilter.PrePayment;
            bool addPay = currentPaymentFilter.AddPayment;
            bool pCard = currentPaymentFilter.Card;
            bool pOnline = currentPaymentFilter.Online;


            var methods = new List<string>();
            if (pCard) methods.Add("Банківська картка");
            if (pOnline) methods.Add("Онлайн платіж");

            string methodsFilter = methods.Count > 0
                ? string.Join(",", methods.Select(s => $"{s}"))
                : "";

            var types = new List<string>();
            if (prePay) types.Add("Передплата");
            if (addPay) types.Add("Доплата");

            string typesFilter = types.Count > 0
                ? string.Join(",", types.Select(s => $"{s}"))
                : "";

            var adapter1 = new Payment1TableAdapter();
            var filteredTable = adapter1.GetFilteredBooking(dateFrom, dateTo, amountMin, amountMax, methodsFilter, typesFilter, client_id, $"{currentSortColumn} {currentSortDirection}");

            listView_mypayments.Items.Clear();

            if (filteredTable.Rows.Count == 0)
            {
                listView_mypayments.Visible = false;
                labelnobooking.Visible = true;

                labelnobooking.Text = "Немає підходящих оплат!";
                button2.Visible = false;
            }
            else
            {
                listView_mypayments.Visible = true;
                labelnobooking.Visible = false;
                foreach (DataRow row in filteredTable.Rows)
                {
                    ListViewItem item = new ListViewItem(
                        row["booking_id"].ToString());
                    item.SubItems.Add(row["payment_type"].ToString());
                    item.SubItems.Add(row["payment_amount"].ToString() + " грн");
                    item.SubItems.Add(row["payment_method"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(row["payment_date"]).ToShortDateString());

                    item.Tag = row["payment_id"];

                    listView_mypayments.Items.Add(item);
                }
            }

        }

        private void listView_mypayments_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            switch (e.Column)
            {
                case 0:
                    currentSortColumn = "booking_id";
                    break;

                case 1:
                    currentSortColumn = "payment_type";
                    break;

                case 2:
                    currentSortColumn = "payment_amount";
                    break;

                case 3:
                    currentSortColumn = "payment_method";
                    break;

                case 4:
                    currentSortColumn = "payment_date";
                    break;
            }

            if (currentSortDirection == "ASC")
                currentSortDirection = "DESC";
            else
                currentSortDirection = "ASC";

            ApplyBookingFilter();
        }





        private void button2_Click(object sender, EventArgs e)
        {
            if (listView_mypayments.SelectedItems.Count == 0)
            {
                MessageBox.Show("Оберіть оплату, чек якої хочете сформувати!");
                return;

            }

            ListViewItem item = listView_mypayments.SelectedItems[0];

            int payment_id = Convert.ToInt32(item.Tag);

            var adapter = new PaymentTableAdapter();
            var p = adapter.GetPayment(payment_id);

            string booking_id = Convert.ToString(p.Rows[0]["booking_id"]);
            string type = Convert.ToString(p.Rows[0]["payment_type"]);
            decimal amount = Convert.ToDecimal(p.Rows[0]["payment_amount"]);
            string method = Convert.ToString(p.Rows[0]["payment_method"]);
            DateTime date = Convert.ToDateTime(p.Rows[0]["payment_date"]);

            var adapterRooms = new DataTable6TableAdapter();
            var dtRooms = adapterRooms.GetDataAboutBookingRoom(Convert.ToInt32(booking_id));
            List<DataRow> rooms = dtRooms.Rows.Cast<DataRow>().ToList();

            var adapterServices = new Service1TableAdapter();
            var dtServices = adapterServices.GetShortInfoAboutService(Convert.ToInt32(booking_id));
            List<DataRow> services = dtServices.Rows.Cast<DataRow>().ToList();

            var adapter22 = new DataTable16TableAdapter();
            var dt = adapter22.GetAlreadyPaid(
                Convert.ToInt32(booking_id),
                payment_id
            );

            decimal alreadyPaid = 0;

            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                alreadyPaid = Convert.ToDecimal(dt.Rows[0][0]);
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF files (*.pdf)|*.pdf";
                sfd.Title = "Зберегти квитанцію";
                sfd.FileName = $"Квитанція_{payment_id}.pdf";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                GeneratePaymentReceipt(payment_id, booking_id, type, amount, method, date, sfd.FileName, alreadyPaid, rooms, services);
                MessageBox.Show("PDF чек збережено!");
            }
        }


        public void GeneratePaymentReceipt(int paymentId, string bookingId, string paymentType, decimal amount, string method, DateTime date, string outputPath, decimal alreadyPaid, List<DataRow> rooms, List<DataRow> services)
        {
            var document = new Document();
            document.Info.Title = "Квитанція про оплату";

            Section section = document.AddSection();

            Paragraph header = section.AddParagraph("ГОТЕЛЬ «Lux»");
            header.Format.Font.Size = 18;
            header.Format.Font.Bold = true;

            section.AddParagraph("Адреса: вул. Сумська 87, м. Харків");
            section.AddParagraph("Телефон: +380 66 111 11 11");

            section.AddParagraph().AddLineBreak();

            Paragraph title = section.AddParagraph("КВИТАНЦІЯ ПРО ОПЛАТУ");
            title.Format.Font.Size = 16;
            title.Format.Font.Bold = true;
            title.Format.SpaceAfter = 20;

            section.AddParagraph($"№ платежу: {paymentId}");
            section.AddParagraph($"№ бронювання: {bookingId}");
            section.AddParagraph($"Тип оплати: {paymentType}");
            section.AddParagraph($"Спосіб оплати: {method}");
            if (paymentType == "Доплата")
            {
                section.AddParagraph($"Загальна вартість бронювання: {alreadyPaid + amount} грн");
                section.AddParagraph($"Сплачено раніше: {alreadyPaid} грн");
            }
            section.AddParagraph($"Поточний платіж: {amount} грн");
            section.AddParagraph($"Дата оплати: {date:dd.MM.yyyy}");

            if (rooms.Count > 0)
            {
                Paragraph roomsTitle = section.AddParagraph("Заброньовані кімнати:");
                roomsTitle.Format.Font.Bold = true;
                roomsTitle.Format.SpaceBefore = 10;

                Table roomTable = section.AddTable();
                roomTable.Borders.Width = 0.75;
                roomTable.AddColumn(Unit.FromCentimeter(4));
                roomTable.AddColumn(Unit.FromCentimeter(3));
                roomTable.AddColumn(Unit.FromCentimeter(3));
                roomTable.AddColumn(Unit.FromCentimeter(3));

                var row = roomTable.AddRow();
                row.Cells[0].AddParagraph("Номер кімнати");
                row.Cells[1].AddParagraph("Категорія");
                row.Cells[2].AddParagraph("Дата заїзду");
                row.Cells[3].AddParagraph("Дата виїзду");

                foreach (var r in rooms)
                {
                    row = roomTable.AddRow();
                    row.Cells[0].AddParagraph(r["room_number"].ToString());
                    row.Cells[1].AddParagraph(r["name"].ToString());
                    row.Cells[2].AddParagraph(Convert.ToDateTime(r["check_in_date"]).ToShortDateString());
                    row.Cells[3].AddParagraph(Convert.ToDateTime(r["check_out_date"]).ToShortDateString());
                }
            }

            if (services.Count > 0)
            {
                Paragraph servicesTitle = section.AddParagraph("Заброньовані послуги:");
                servicesTitle.Format.Font.Bold = true;
                servicesTitle.Format.SpaceBefore = 10;

                Table serviceTable = section.AddTable();
                serviceTable.Borders.Width = 0.75;
                serviceTable.AddColumn(Unit.FromCentimeter(6));
                serviceTable.AddColumn(Unit.FromCentimeter(3));
                serviceTable.AddColumn(Unit.FromCentimeter(3));

                var row = serviceTable.AddRow();
                row.Cells[0].AddParagraph("Назва послуги");
                row.Cells[1].AddParagraph("Кількість днів");
                row.Cells[2].AddParagraph("Кількість осіб");

                foreach (var s in services)
                {
                    row = serviceTable.AddRow();
                    row.Cells[0].AddParagraph(s["name"].ToString());
                    row.Cells[1].AddParagraph(s["days_count"].ToString());
                    row.Cells[2].AddParagraph(s["persons_count"].ToString());
                }
            }

            section.AddParagraph().AddLineBreak();

            Paragraph thanks = section.AddParagraph("Дякуємо за оплату!");
            thanks.Format.Font.Bold = true;

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = document;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(outputPath);
        }

    }
}
