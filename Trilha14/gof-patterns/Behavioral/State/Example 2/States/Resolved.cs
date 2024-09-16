using System;

namespace Example_2.States
{
    public class Resolved : BaseState, ICommand
    {
        private readonly WorkItem owner;

        public Resolved(WorkItem owner) : base(owner)
        {
            this.owner = owner;
        }

        public void Open()
        {
            Console.WriteLine("Work Item is already resolved.");
        }

        public void Resolve()
        {
            Console.WriteLine("Work Item is already resolved.");
        }

        public void Close()
        {
            owner.State = StateEnum.Closed;
        }

        public bool Delete()
        {
            Console.WriteLine("Work Item is already resolved and cannot be deleted.");
            return false;
        }
    }
}
