using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_booking
{
    public class BookingFilter
    {

        public DateTime CreatedFrom;
        public DateTime CreatedTo;
        public decimal AmountMin;
        public decimal AmountMax;
        public bool StatusPending;
        public bool StatusComfirmed;
        public bool StatusPaid;
        public bool StatusCanceled;
        public bool StatusCompleted;
        public BookingFilter(DateTime createdFrom, DateTime createdTo, decimal amountMin, decimal amountMax, bool statuspending, bool statuscomfirmed, bool statuspaid, bool statuscanceled, bool statuscompleted)
        {
            CreatedFrom = createdFrom;
            CreatedTo = createdTo;
            AmountMin = amountMin;
            AmountMax = amountMax;
            StatusPending = statuspending;
            StatusComfirmed = statuscomfirmed;
            StatusPaid = statuspaid;
            StatusCanceled = statuscanceled;
            StatusCompleted = statuscompleted;
        }

    }
}
