using System;

namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client();
            var provider = new Provider();
            new Mediator(client, provider);

            Console.WriteLine("Client triggets operation A.");
            client.DoA();

            Console.WriteLine();

            Console.WriteLine("Client triggers operation D.");
            provider.DoD();
        }
    }
}
