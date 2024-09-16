using System;
using BridgePattern.Interfaces;

namespace BridgePattern.Implementations.MessageSenders
{
    public class SkypeSender : IMessageSender
    {
        public void Send(IMessage message)
        {
            Console.WriteLine($"Sending message with Skype API ... : {message}");
        }
    }
}