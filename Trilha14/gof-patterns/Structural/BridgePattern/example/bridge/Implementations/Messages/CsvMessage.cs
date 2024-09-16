using System;
using BridgePattern.Interfaces;

namespace BridgePattern.Implementations.MessageSenders
{
    public class CsvMessage : IMessage
    {
        public void Create(byte[] message)
        {
            throw new NotImplementedException();
        }
    }
}