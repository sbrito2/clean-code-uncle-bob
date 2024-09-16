using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Example_2
{
    public class WorkItemRepository
    {
        private readonly ICollection<WorkItem> workItems;
        private readonly string filename = "workitems.json";

        public WorkItemRepository()
        {
            workItems = LoadData();
            if (workItems == null)
            {
                workItems = new List<WorkItem>();
                SaveData();
            }
        }

        

        public void Add(WorkItem workItem)
        {
            workItems.Add(workItem);
            SaveData();
        }

        public void Update(WorkItem workItem)
        {
            SaveData();
        }

        public bool Delete(WorkItem workItem)
        {
            var @return = workItems.Remove(workItem);
            SaveData();
            return @return;
        }

        public long Count()
        {
            return workItems.Count;
        }

        public WorkItem FindById(int id)
        {
            return workItems.FirstOrDefault(w=>w.Id == id);
        }

        public void Save()
        {
            SaveData();
        }

        private void SaveData()
        {
            var data = JsonConvert.SerializeObject(workItems);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.WriteAllText(filePath, data);
        }

        private ICollection<WorkItem> LoadData()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            if (!File.Exists(filePath)) return null;
            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<WorkItem>>(jsonData);
        }
    }
}