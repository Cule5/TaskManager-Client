using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.WorkItem.Factories
{
    public interface IWorkItemFactory
    {
        Task<WorkItem> CreateAsync(string comment,double time,DateTime reportDate,string taskProgress,int taskId);
    }
}
