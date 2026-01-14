using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_booking
{
    public class CategoryFilter
    {
        public decimal PriceMin;
        public decimal PriceMax;
        public int CapacityMin;
        public int CapacityMax;

        public CategoryFilter(decimal priceMin, decimal priceMax, int capacityMin, int capacityMax)
        {
            PriceMin = priceMin;
            PriceMax = priceMax;
            CapacityMin = capacityMin;
            CapacityMax = capacityMax;
        }
    }
}
