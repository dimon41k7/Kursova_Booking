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
    public partial class CategoryFilterForm: Form
    {
        public CategoryFilter CurrentFilter;
        public CategoryFilterForm(CategoryFilter filter)
        {
            InitializeComponent();
            CurrentFilter = filter;

            textBox_PriceMin.Text = filter.PriceMin.ToString();
            textBox_PriceMax.Text = filter.PriceMax.ToString();

            textBox_CapacityMin.Text = filter.CapacityMin.ToString();
            textBox_CapacityMax.Text = filter.CapacityMax.ToString();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            var adapter = new DataTable4TableAdapter();
            var ca = adapter.GetMinMaxForFilter();
            var row = ca.Rows[0];

            Decimal minprice = Convert.ToDecimal(row["minprice"]);
            Decimal maxprice = Convert.ToDecimal(row["maxprice"]);
            int mincapacity = Convert.ToInt32(row["mincapacity"]);
            int maxcapacity = Convert.ToInt32(row["maxcapacity"]);

            decimal priceMin;

            if (textBox_PriceMin.Text == "")
            {
                priceMin = minprice;
            }
            else
            {
                if (!decimal.TryParse(textBox_PriceMin.Text, out priceMin))
                {
                    MessageBox.Show("Мінімальна ціна введена некоректно");
                    return;
                }
            }

            if (priceMin < minprice)
            {
                MessageBox.Show($"Мінімальна ціна не може бути меншою за {minprice}");
                return;
            }

            decimal priceMax;

            if (textBox_PriceMax.Text == "")
            {
                priceMax = maxprice;
            }
            else
            {
                if (!decimal.TryParse(textBox_PriceMax.Text, out priceMax))
                {
                    MessageBox.Show("Максимальна ціна введена некоректно");
                    return;
                }
            }
            
            if (priceMax > maxprice)
            {
                MessageBox.Show($"Максимальна ціна не може бути більшою за {maxprice}");
                return;
            }

            if (priceMin > priceMax)
            {
                MessageBox.Show("Мінімальна ціна не може бути більшою за максимальну");
                return;
            }

            int capacityMin;

            if(textBox_CapacityMin.Text == "")
            {
                capacityMin = mincapacity;
            }
            else
            {
                if (!int.TryParse(textBox_CapacityMin.Text, out capacityMin))
                {
                    MessageBox.Show("Мінімальна місткість введена некоректно");
                    return;
                }
            }
            
            if (capacityMin < mincapacity)
            {
                MessageBox.Show($"Мінімальна місткість не може бути меншою за {mincapacity}");
                return;
            }

            int capacityMax;

            if (textBox_CapacityMax.Text == "")
            {
                capacityMax = maxcapacity;
            }
            else
            {
                if (!int.TryParse(textBox_CapacityMax.Text, out capacityMax))
                {
                    MessageBox.Show("Максимальна місткість введена некоректно");
                    return;
                }
            }


            if (capacityMax > maxcapacity)
            {
                MessageBox.Show($"Максимальна місткість не може бути більшою за {maxcapacity}");
                return;
            }

            if (capacityMin > capacityMax)
            {
                MessageBox.Show("Мінімальна місткість не може бути більшою за максимальну");
                return;
            }

            CurrentFilter.PriceMin = priceMin;
            CurrentFilter.PriceMax = priceMax;
            CurrentFilter.CapacityMin = capacityMin;
            CurrentFilter.CapacityMax = capacityMax;
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
