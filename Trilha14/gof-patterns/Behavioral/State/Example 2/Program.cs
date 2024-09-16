using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var workItemRepository = new WorkItemRepository();
            WorkItem.Init(workItemRepository);

            string command = null, title = null, desc = null;
            int id = 0;
            try
            {
                command = args[0].ToLower();
                id = int.Parse(args[1]);
                
                if (args.Count() > 2)
                {
                    title = args[2];
                    desc = args[3];
                }
            }
            catch (Exception)
            {
                PrintUsage();
                return;
            }

            try
            {
                WorkItem workItem;
                switch (command)
                {
                    case "create":
                        workItem = WorkItem.Create(id);
                        workItem.Edit(title, desc);
                        workItem.Print();
                        break;

                    case "update":
                        workItem = WorkItem.FindById(id);
                        workItem.Edit(title, desc);
                        workItem.Print();
                        break;

                    case "open":
                        workItem = WorkItem.FindById(id);
                        workItem.Open();
                        break;

                    case "resolve":
                        workItem = WorkItem.FindById(id);
                        workItem.Resolve();
                        break;

                    case "close":
                        workItem = WorkItem.FindById(id);
                        workItem.Close();
                        break;

                    case "delete":
                        workItem = WorkItem.FindById(id);
                        workItem.Delete();
                        break;

                    case "print":
                        workItem = WorkItem.FindById(id);
                        workItem.Print();
                        break;
                }

                workItemRepository.Save();
            }
            catch (Exception)
            {
                PrintUsage();
            }
        }

        private static void PrintUsage()
        {
            Console.WriteLine("create   [id] [title] [description]");
            Console.WriteLine("update   [id] [title] [description]");
            Console.WriteLine("resolve  [id]");
            Console.WriteLine("close    [id]");
            Console.WriteLine("delete   [id]");
            Console.WriteLine("print    [id]");
        }
    }
}
