using System;

namespace Example_2.States
{
    public class Active : BaseState, ICommand
    {
        private readonly WorkItem owner;

        public Active(WorkItem owner) : base(owner)
        {
            this.owner = owner;
        }

        public void Open()
        {
            Console.WriteLine("Work Item is already active.");
        }

        public void Resolve()
        {
            owner.State = StateEnum.Resolved;
        }

        public void Close()
        {
            Console.WriteLine("Work Item is in active state and cannot be closed.");
        }

        public bool Delete()
        {
            Console.WriteLine("Work Item is already active and cannot be deleted.");
            return false;
        }
    }
}
