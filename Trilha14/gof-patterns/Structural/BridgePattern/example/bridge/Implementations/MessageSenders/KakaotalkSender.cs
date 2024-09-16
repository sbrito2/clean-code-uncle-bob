using System;
using BridgePattern.Interfaces;

namespace BridgePattern.Implementations.MessageSenders
{
    public class KakaotalkSender : IMessageSender
    {
        public void Send(IMessage message)
        {
            Console.WriteLine($"Sending message with Kakao API ... : {message}");
        }
    }
}