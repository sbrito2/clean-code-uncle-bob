using System;

namespace Example_2.States
{
    public abstract class BaseState
    {
        private WorkItem owner;
        public BaseState(WorkItem owner)
        {
            this.owner = owner;
        }

        public void Print()
        {
            Console.WriteLine($"Id: {owner.Id}");
            Console.WriteLine($"Title: {owner.Title}");
            Console.WriteLine($"State: {owner.State}");
            Console.WriteLine($"Description: {owner.Description}");
        }
    }
}