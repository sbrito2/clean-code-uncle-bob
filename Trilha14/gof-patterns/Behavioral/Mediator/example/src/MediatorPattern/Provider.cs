using System;

namespace MediatorPattern
{
    class Provider : Base
    {
        public void DoC()
        {
            Console.WriteLine("Component 2 does C.");

            this.mediator.Notify(this, "C");
        }

        public void DoD()
        {
            Console.WriteLine("Component 2 does D.");

            this.mediator.Notify(this, "D");
        }
    }
}