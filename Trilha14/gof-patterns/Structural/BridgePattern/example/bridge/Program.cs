using System;
using BridgePattern;
using BridgePattern.Implementations.MessageSenders;

namespace bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = "It's 7pm, Go to Gym.";
            var textMessage = new TextMessage(Convert.ToByte(message));

            Notifier notifier = new Notifier(new TelegramSender());
            notifier.Notify(textMessage);

            notifier.ChangeMessageSender(new MailSender());
            notifier.Notify(textMessage);

            notifier.ChangeMessageSender(new SkypeSender());
            notifier.Notify(textMessage);

            Console.ReadKey();
        }
    }
}
