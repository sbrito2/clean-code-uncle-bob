using BridgePattern;
using BridgePattern.Interfaces;

namespace BridgePattern
{
    public class Notifier
    {
        private IMessageSender _messageSender;

        public Notifier(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public void ChangeMessageSender(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public void Notify(IMessage message)
        {
            _messageSender.Send(message);
        }
    }
}