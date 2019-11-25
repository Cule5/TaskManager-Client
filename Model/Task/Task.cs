using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.Task
{
    public class Task
    {
        public Task(string description,DateTime startDate,DateTime endDate,string taskType,string taskPriority)
        {
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            TaskType = taskType;
            TaskPriority = taskPriority;
        }
        public string Description { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public string TaskType { get; }
        public string TaskPriority { get; }
    }
}
