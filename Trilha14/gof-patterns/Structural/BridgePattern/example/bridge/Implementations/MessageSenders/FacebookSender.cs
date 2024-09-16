using System;
using BridgePattern.Interfaces;

namespace BridgePattern.Implementations.MessageSenders
{
    public class FacebookSender : IMessageSender
    {
        public void Send(IMessage message)
        {
            Console.WriteLine($"Sending message with Facebook API ... : {message}");
        }
    }
}