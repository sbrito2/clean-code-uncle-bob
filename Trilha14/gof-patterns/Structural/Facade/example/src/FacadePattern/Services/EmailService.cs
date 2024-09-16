using System;

namespace FacadePattern.Services
{
    public class EmailService
    {
        public void SendEmail(string emailTo)
        {
            Console.WriteLine($"Sending an email to {emailTo}.");
        }
    }
}
