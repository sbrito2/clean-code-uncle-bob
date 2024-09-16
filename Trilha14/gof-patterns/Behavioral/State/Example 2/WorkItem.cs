using Example_2.States;

namespace Example_2
{
    public enum StateEnum { Proposed, Active, Resolved, Closed }

    public class WorkItem : ICommand
    {
        public static WorkItemRepository WorkItemRepository { get; set; }

        public static void Init(WorkItemRepository workItemRepository)
        {
            WorkItemRepository = workItemRepository;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public StateEnum State 
        { 
            get => state; 
            set
            {
                state = value;
                switch (state)
                {
                    case StateEnum.Proposed:
                        command = new Proposed(this);
                        break;
                    case StateEnum.Active:
                        command = new Active(this);
                        break;
                    case StateEnum.Resolved:
                        command = new Resolved(this);
                        break;
                    case StateEnum.Closed:
                        command = new Closed(this);
                        break;
                }
            }
        }

        private ICommand command;
        private StateEnum state;

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
            command.Open();
        }

        public void Resolve()
        {
            command.Resolve();
        }

        public void Close()
        {
            command.Close();
        }

        public bool Delete()
        {
            if (command.Delete())
            {
                WorkItemRepository.Delete(this);
                return true;
            }

            return false;
        }        

        public void Print()
        {
            command.Print();
        }
    }
}