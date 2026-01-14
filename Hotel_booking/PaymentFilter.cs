using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_booking
{

    public class PaymentFilter
    {
        public DateTime PaymentDateFrom;
        public DateTime PaymentDateTo;
        public decimal AmountMin;
        public decimal AmountMax;
        public bool PrePayment;
        public bool AddPayment;
        public bool Card;
        public bool Online;

        public PaymentFilter(DateTime paymentDateFrom, DateTime paymentDateTo, decimal amountMin, decimal amountMax, bool prePayment, bool addPayment, bool card, bool online)
        {
            PaymentDateFrom = paymentDateFrom;
            PaymentDateTo = paymentDateTo;
            AmountMin = amountMin;
            AmountMax = amountMax;
            PrePayment = prePayment;
            AddPayment = addPayment;
            Card = card;
            Online = online;
        }
    }
}
