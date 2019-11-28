using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.WorkItem.Factories
{
    class WorkItemFactory:IWorkItemFactory
    {
        public Task<WorkItem> CreateAsync(string comment, double time, DateTime reportDate,string taskProgress,int taskId)
        {
            return System.Threading.Tasks.Task.Factory.StartNew<WorkItem>(() => new WorkItem(comment,time,reportDate,taskProgress,taskId));
        }
    }
}
