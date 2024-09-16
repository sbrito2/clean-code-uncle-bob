using System;
using BridgePattern.Interfaces;

namespace BridgePattern.Implementations.MessageSenders
{
    public class MailSender : IMessageSender
    {
        public void Send(IMessage message)
        {
            Console.WriteLine($"Sending message with Mail API ... : {message}");
        }
    }
}