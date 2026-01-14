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
    public partial class FinishBookingCreateForm: Form
    {
        private int booking_id;
        private int client_id;
        private decimal total_amount;
        int selectedClientId = -1;

        string last_name;
        string first_name;
        string middle_name;
        bool change = false;
        public FinishBookingCreateForm(int id, int id2, decimal amount)
        {
            InitializeComponent();
            booking_id = id;
            client_id = id2;
            total_amount = amount;
        }


        private void fillinfo()
        {

            rbSelf.Checked = true;
            label_total_amount.Text = Convert.ToString(total_amount);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int customer_id;
            bool bby = true;
            if (rbSelf.Checked)
            {
                customer_id = client_id;
                last_name = "";
                first_name = "";
                middle_name = "";
                bby = true;
            }
            else
            {
                bby = false;
                customer_id = selectedClientId;
                if (selectedClientId == -1)
                {
                    MessageBox.Show("Оберіть клієнта!");
                    return;
                }

            }

            string notes;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                notes = "";
            }
            else
            {
                notes = textBox1.Text;
            }

            decimal price;
            if (!decimal.TryParse(label_total_amount.Text, out price))
            {
                MessageBox.Show("Некоректна остаточна сума!");
                return;
            }
            DateTime created_at = DateTime.Now;
            var adapter = new BookingTableAdapter();
            adapter.UpdateBooking(customer_id, created_at, notes, price, "Очікує", booking_id);

            if (checkBox1.Checked)
            {
                var adapterRooms = new DataTable6TableAdapter();
                var dtRooms = adapterRooms.GetDataAboutBookingRoom(booking_id);
                List<DataRow> rooms = dtRooms.Rows.Cast<DataRow>().ToList();

                var adapterServices = new Service1TableAdapter();
                var dtServices = adapterServices.GetShortInfoAboutService(booking_id);
                List<DataRow> services = dtServices.Rows.Cast<DataRow>().ToList();

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF files (*.pdf)|*.pdf";
                    sfd.Title = "Зберегти підтвердження бронювання";
                    sfd.FileName = $"Підтвердження бронювання_{booking_id}.pdf";

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    GenerateBookingConfirmation(booking_id, Convert.ToString(created_at), bby, last_name, first_name, middle_name, total_amount, notes, rooms, services, sfd.FileName);
                    MessageBox.Show("PDF чек збережено!");
                }
            }

            var add = new MainForm(client_id, false, 0, false);
            add.Show();
            this.Close();
        }


        
        private void FinishBookingCreateForm_Load(object sender, EventArgs e)
        {
            fillinfo();
        }

        private void rbSelf_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSelf.Checked)
            {
                textBoxClient.Visible = false;
                listBoxClients.Visible = false;

            }
        }

        private void rbOtherClient_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOtherClient.Checked)
            {
                textBoxClient.Visible = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var add = new _2CreateBookingForm(booking_id, client_id);
            add.Show();
            this.Close();
        }




        public void GenerateBookingConfirmation(int bookingId, string created_at, bool bby, string last_name, string first_name, string middle_name,  decimal totalAmount, string notes, List<DataRow> rooms, List<DataRow> services, string outputPath)
        {
            var document = new Document();
            document.Info.Title = "Підтвердження бронювання";

            Section section = document.AddSection();

            Paragraph header = section.AddParagraph("ГОТЕЛЬ «Lux»");
            header.Format.Font.Size = 18;
            header.Format.Font.Bold = true;

            section.AddParagraph("Адреса: вул. Сумська 87, м. Харків");
            section.AddParagraph("Телефон: +380 66 111 11 11");
            section.AddParagraph().AddLineBreak();

            Paragraph title = section.AddParagraph("ПІДТВЕРДЖЕННЯ БРОНЮВАННЯ");
            title.Format.Font.Size = 16;
            title.Format.Font.Bold = true;
            title.Format.SpaceAfter = 20;

            section.AddParagraph($"№ бронювання: {bookingId}");

            section.AddParagraph($"Остаточна сума: {totalAmount} грн");
            if (bby)
            {
                section.AddParagraph("Бронювання здійснено на вас");
            }
            else
            {
                section.AddParagraph($"Бронювання здійснено на: {last_name} {first_name} {middle_name}");
            }
            section.AddParagraph($"Дата та час створення: {created_at}");
            if (!string.IsNullOrWhiteSpace(notes))
                section.AddParagraph($"Примітки: {notes}");

            section.AddParagraph().AddLineBreak();

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
            Paragraph thanks = section.AddParagraph("Дякуємо за бронювання!");
            thanks.Format.Font.Bold = true;

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = document;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(outputPath);
        }

        private void ShowClients()
        {
            var adapter = new Client4TableAdapter();
            DataTable dt;

            if (string.IsNullOrWhiteSpace(textBoxClient.Text))
            {
                dt = adapter.GetAllClients(client_id);
            }
            else
            {
                dt = adapter.GetClients(client_id, textBoxClient.Text);
            }

            listBoxClients.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                listBoxClients.Items.Add(new Client
                {
                    ClientId = Convert.ToInt32(row["client_id"]),
                    DisplayName = $"{row["last_name"]} {row["first_name"]} {row["middle_name"]}"
                });
            }

            listBoxClients.Visible = listBoxClients.Items.Count > 0;
        }

        private void SelectClient()
        {
            if (listBoxClients.SelectedItem is Client client)
            {
                change = true;

                selectedClientId = client.ClientId;
                textBoxClient.Text = client.DisplayName;
                listBoxClients.Visible = false;

                change = false;

                var adapter = new Client4TableAdapter();
                var dt = adapter.GetClientById(selectedClientId);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    last_name = row["last_name"].ToString();
                    first_name = row["first_name"].ToString();
                    middle_name = row["middle_name"].ToString();
                }
            }
        }

        private void textBoxClient_TextChanged(object sender, EventArgs e)
        {
            if (change)
                return;

            selectedClientId = -1;

            ShowClients();
        }

        private void textBoxClient_Enter(object sender, EventArgs e)
        {
            ShowClients();
        }

        private void listBoxClients_DoubleClick(object sender, EventArgs e)
        {
            SelectClient();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            var adapter = new BookingTableAdapter();
            adapter.DeleteBooking(booking_id);

            var add = new MainForm(client_id, false, 0, false);
            add.Show();
            this.Close();
        }
    }
}
