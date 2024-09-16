using System;

namespace FacadePattern.Services
{
    public class WhatsappService
    {
        public void SendMessage(string number)
        {
            Console.WriteLine($"Sending an whatsapp to {number}.");
        }
    }
}
