using System;
using BridgePattern.Interfaces;

namespace BridgePattern.Implementations.MessageSenders
{
    public class TextMessage : IMessage
    {
        public TextMessage()
        {

        }
        public TextMessage(byte message)
        {           
        }
        public void Create(byte[] message)
        {
            throw new NotImplementedException();
        }
    }
}