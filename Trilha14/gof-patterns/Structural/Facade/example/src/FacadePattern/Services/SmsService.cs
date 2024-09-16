using System;

namespace FacadePattern.Services
{
    public class SmsService
    {
        public void SendSms(string mobilePhone)
        {
            Console.WriteLine($"Sending an sms to {mobilePhone}.");
        }
    }
}
