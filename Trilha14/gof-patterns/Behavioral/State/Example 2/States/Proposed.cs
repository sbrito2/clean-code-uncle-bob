using System;

namespace Example_2.States
{
    public class Proposed : BaseState, ICommand
    {
        private readonly WorkItem owner;

        public Proposed(WorkItem owner) : base(owner)
        {
            this.owner = owner;
        }

        public void Open()
        {
            owner.State = StateEnum.Active;
        }

        public void Resolve()
        {
            Console.WriteLine("Work Item is in proposed state and cannot be directly resolved.");
        }

        public void Close()
        {
            Console.WriteLine("Work Item is in proposed state and cannot be closed.");
        }

        public bool Delete()
        {
            return true;
        }
    }
}
