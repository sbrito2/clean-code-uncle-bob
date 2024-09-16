using System;

namespace Example_2.States
{
    public class Closed : BaseState, ICommand
    {
        private readonly WorkItem owner;

        public Closed(WorkItem owner) : base(owner)
        {
            this.owner = owner;
        }

        public void Open()
        {
            Console.WriteLine("Work Item is closed and cannot be modified.");
        }

        public void Resolve()
        {
            Console.WriteLine("Work Item is closed and cannot be modified.");
        }

        public void Close()
        {
            Console.WriteLine("Work Item is already closed.");
        }

        public bool Delete()
        {
            return true;
        }
    }
}
