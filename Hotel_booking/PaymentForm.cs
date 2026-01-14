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
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace Hotel_booking
{
    public partial class PaymentForm: Form
    {
        private int booking_id;
        private int client_id;
        private decimal payment_amount;
        private string payment_type;
        public PaymentForm(int booking_id, int client_id, decimal payment_amount, string payment_type)
        {
            InitializeComponent();
            this.booking_id = booking_id;
            this.client_id = client_id;
            this.payment_amount = payment_amount;
            this.payment_type = payment_type;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            rbCard.Checked = true;
            label_payment_amount.Text = Convert.ToString(payment_amount);
            label3.Text = $"{payment_type} за бронювання";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string payment_method;
            if (rbCard.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBox_number.Text))
                {
                    MessageBox.Show("Введіть номер картки.");
                    return;
                }
                if (textBox_number.Text.Length < 16)
                {
                    MessageBox.Show("Номер картки має містити 16 цифр.");
                    return;
                }
                if (!textBox_number.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Номер картки повинен складатися лише з цифр.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox_mm.Text))
                {
                    MessageBox.Show("Введіть місяць закінчення картки.");
                    return;
                }
                if (!textBox_mm.Text.All(char.IsDigit) || textBox_mm.Text.Length != 2)
                {
                    MessageBox.Show("Місяць має бути у форматі MM (наприклад, 08).");
                    return;
                }
                int mm = int.Parse(textBox_mm.Text);
                if (mm < 1 || mm > 12)
                {
                    MessageBox.Show("Місяць повинен бути від 01 до 12.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox_yy.Text))
                {
                    MessageBox.Show("Введіть рік закінчення картки.");
                    return;
                }
                if (!textBox_yy.Text.All(char.IsDigit) || textBox_yy.Text.Length != 2)
                {
                    MessageBox.Show("Рік має бути у форматі YY (наприклад, 27).");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox_cvv.Text))
                {
                    MessageBox.Show("Введіть CVV код.");
                    return;
                }
                if (!textBox_cvv.Text.All(char.IsDigit) || textBox_cvv.Text.Length != 3)
                {
                    MessageBox.Show("CVV має містити 3 цифри.");
                    return;
                }
                payment_method = "Банківська картка";
            }
            else
            {
                payment_method = "Онлайн платіж";
            }
            DateTime p = DateTime.Now;

            var adapter = new PaymentTableAdapter();
            adapter.InsertPayment(booking_id, payment_amount, p, payment_method, payment_type);

            object result = adapter.ScalarMaxId();

            int payment_id = result == DBNull.Value
                ? 0
                : Convert.ToInt32(result);

            if (checkBox1.Checked)
            {
                string booking_id_st = Convert.ToString(booking_id);
                string type = payment_type;
                decimal amount = payment_amount;
                string method = payment_method;
                DateTime date = p;

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

                    GeneratePaymentReceipt(payment_id, booking_id_st, type, amount, method, date, sfd.FileName, alreadyPaid, rooms, services);
                    MessageBox.Show("PDF чек збережено!");
                }
            }



            if (payment_type == "Передплата")
            {
                var adapter1 = new BookingTableAdapter();
                adapter1.UpdateStatus("Підтверджено", booking_id);
            }
            else if (payment_type == "Доплата")
            {
                var adapter1 = new BookingTableAdapter();
                adapter1.UpdateStatus("Оплачено", booking_id);
            }

            var form = new BookingDetailsForm(booking_id, client_id);
            form.Show();
            this.Close();

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



        private void rbCard_CheckedChanged(object sender, EventArgs e)
        {
            textBox_number.Visible = true;
            textBox_mm.Visible = true;
            textBox_yy.Visible = true;
            textBox_cvv.Visible = true;
            textBox_number.Text = "";
            textBox_mm.Text = "";
            textBox_yy.Text = "";
            textBox_cvv.Text = "";
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;

        }

        private void rbOnline_CheckedChanged(object sender, EventArgs e)
        {
            textBox_number.Visible = false;
            textBox_mm.Visible = false;
            textBox_yy.Visible = false;
            textBox_cvv.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new BookingDetailsForm(booking_id, client_id);
            form.Show();
            this.Close();
        }
    }
}
