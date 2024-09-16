using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Services
{
    public class PaymentService
    {
        public void PaymentByPaypal()
        {
            Console.WriteLine("Payment by Paypal.");
        }

        public void PaymentByCreditCard()
        {
            Console.WriteLine("Payment by Debit card.");
        }

        public void PaymentByDebitCard()
        {
            Console.WriteLine("Payment by Credit card.");
        }

        public void PaymentByCash()
        {
            Console.WriteLine("Payment by cash.");
        }

        public void PaymentByQrCode()
        {
            Console.WriteLine("Payment by Qrcode.");
        }
    }
}
