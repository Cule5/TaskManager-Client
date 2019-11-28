using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.Task.Factories
{
    public class TaskFactory:ITaskFactory
    {
        public Task<Task> CreateAsync(string description,DateTime startDate, DateTime endDate, string taskType, string taskPriority,int projectId)
        {
            return System.Threading.Tasks.Task.Factory.StartNew(()=>new Task(description,startDate,endDate,taskType,taskPriority,projectId));
        }
    }
}
