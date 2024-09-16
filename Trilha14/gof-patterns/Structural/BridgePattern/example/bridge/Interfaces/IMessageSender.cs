namespace BridgePattern.Interfaces
{
    public interface IMessageSender
    {
        void Send(IMessage message);
    }
}