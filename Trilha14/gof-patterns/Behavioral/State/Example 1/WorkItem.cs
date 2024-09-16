using System;

namespace Example_1
{
    public enum StateEnum { Proposed, Active, Resolved, Closed }

    public class WorkItem
    {
        public static WorkItemRepository WorkItemRepository { get; set; }

        public static void Init(WorkItemRepository workItemRepository)
        {
            WorkItemRepository = workItemRepository;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public StateEnum State { get; set; }

        public static WorkItem Create(int id)
        {
            var workItem = new WorkItem() 
            { 
                Id = id, 
                State = StateEnum.Proposed 
            };
            WorkItemRepository.Add(workItem);
            return workItem;
        }

        public static WorkItem FindById(int id)
        {
            return WorkItemRepository.FindById(id);
        }

        public void Edit(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public void Open()
        {
            switch (State)
            {
                case StateEnum.Proposed:
                    this.State = StateEnum.Active;
                    break;
                case StateEnum.Active:
                    Console.WriteLine("Work Item is already active.");
                    break;
                case StateEnum.Resolved:
                    Console.WriteLine("Work Item is already resolved.");
                    break;
                case StateEnum.Closed:
                    Console.WriteLine("Work Item is closed and cannot be modified.");
                    break;
            }
        }

        public void Resolve()
        {
            switch (State)
            {
                case StateEnum.Proposed:
                    Console.WriteLine("Work Item is in proposed state and cannot be directly resolved.");
                    break;
                case StateEnum.Active:
                    this.State = StateEnum.Resolved;
                    break;
                case StateEnum.Resolved:
                    Console.WriteLine("Work Item is already resolved.");
                    break;
                case StateEnum.Closed:
                    Console.WriteLine("Work Item is closed and cannot be modified.");
                    break;
            }
        }

        public void Delete()
        {
            switch (State)
            {
                case StateEnum.Proposed:
                    WorkItemRepository.Delete(this);
                    break;
                case StateEnum.Active:
                    Console.WriteLine("Work Item is already active and cannot be deleted.");
                    break;
                case StateEnum.Resolved:
                    Console.WriteLine("Work Item is already resolved and cannot be deleted.");
                    break;
                case StateEnum.Closed:
                    WorkItemRepository.Delete(this);
                    break;
            }
        }

        public void Close()
        {
            switch (State)
            {
                case StateEnum.Proposed:
                    Console.WriteLine("Work Item is in proposed state and cannot be closed.");
                    break;
                case StateEnum.Active:
                    Console.WriteLine("Work Item is in active state and cannot be closed.");
                    break;
                case StateEnum.Resolved:
                    this.State = StateEnum.Closed;
                    break;
                case StateEnum.Closed:
                    Console.WriteLine("Work Item is already closed.");
                    break;
            }
        }

        public void Print()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"State: {State}");
            Console.WriteLine($"Description: {Description}");

        }
    }
}