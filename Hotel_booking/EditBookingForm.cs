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
    public partial class EditBookingForm: Form
    {
        private int booking_id;
        private bool bby;
        private int client_id;
        private int customer_id;

        int selectedClientId = -1;

        string last_name;
        string first_name;
        string middle_name;
        bool change = false;

        public EditBookingForm(int id, bool b, int id2)
        {
            InitializeComponent();
            booking_id = id;
            bby = b;
            client_id = id2;
        }

        private void EditBookingForm_Load(object sender, EventArgs e)
        {
            var adapter = new DataTable1TableAdapter();
            var bk = adapter.GetDataFullBooking(booking_id);

            textBox1.Text = Convert.ToString(bk.Rows[0]["notes"]);

            if (bby)
            {
                rbSelf.Select();

                textBoxClient.Visible = false;
                listBoxClients.Visible = false;

            }
            else
            {
                
                rbOtherClient.Select();
                customer_id = Convert.ToInt32(bk.Rows[0]["customer_id"]);

                textBoxClient.Visible = true;
                

                var adapter1 = new ClientTableAdapter();
                var cl = adapter1.GetDataById(customer_id);
                last_name = Convert.ToString(cl.Rows[0]["last_name"]);
                first_name = Convert.ToString(cl.Rows[0]["first_name"]);
                middle_name = Convert.ToString(cl.Rows[0]["middle_name"]);

                textBoxClient.Text = $"{last_name} {first_name} {middle_name}";

                listBoxClients.Visible = false;

            }
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

                if (bby)
                {
                    textBoxClient.Text = "";
                }
                else
                {
                    textBoxClient.Text = $"{last_name} {first_name} {middle_name}";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var adapter = new DataTable1TableAdapter();
            var bk = adapter.GetDataFullBooking(booking_id);
            if (rbSelf.Checked)
            {
                string notes;
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    notes = "";
                }
                else
                {
                    notes = textBox1.Text;
                }

                var result = MessageBox.Show(
                    "Ви впевнені, що хочете зберегти зміни?",
                    "Підтвердження",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var cladapter = new Client1TableAdapter();
                    cladapter.UpdateCustomerId(client_id, notes, booking_id);
                    this.Close();
                } 
            }
            else
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

                var cladapter = new Client1TableAdapter();

                string notes;
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    notes = "";
                }
                else
                {
                    notes = textBox1.Text;
                }
                var result = MessageBox.Show(
                    "Ви впевнені, що хочете зберегти зміни?",
                    "Підтвердження",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    cladapter.UpdateCustomerId(customer_id,notes, booking_id);
                    this.Close();
                }

            }
 
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
    }
}
