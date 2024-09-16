using System;

namespace MediatorPattern
{
    class Client : Base
    {
        public void DoA()
        {
            Console.WriteLine("Component 1 does A.");

            this.mediator.Notify(this, "A");
        }

        public void DoB()
        {
            Console.WriteLine("Component 1 does B.");

            this.mediator.Notify(this, "B");
        }
    }
}