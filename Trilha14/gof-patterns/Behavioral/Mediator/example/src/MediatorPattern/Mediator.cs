using System;
using MediatorPattern.Interfaces;

namespace MediatorPattern
{
    class Mediator : IMediator
    {
        private Client client;
        private Provider provider;

        public Mediator(Client client, Provider provider)
        {
            this.client = client;
            this.client.SetMediator(this);

            this.provider = provider;
            this.provider.SetMediator(this);
        } 

        public void Notify(object sender, string ev)
        {
            if (ev == "A")
            {
                Console.WriteLine("Mediator reacts on A and triggers folowing operations:");
                this.provider.DoC();
            }
            
            if (ev == "D")
            {
                Console.WriteLine("Mediator reacts on D and triggers following operations:");
                this.client.DoB();
                this.provider.DoC();
            }
        }
    }
}