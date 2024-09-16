using System;
using BridgePattern.Interfaces;

namespace BridgePattern.Implementations.MessageSenders
{
    public class TelegramSender : IMessageSender
    {
        public void Send(IMessage message)
        {
            Console.WriteLine($"Sending message with Telegram API ... : {message}");
        }
    }
}