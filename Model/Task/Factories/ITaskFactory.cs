using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.Task.Factories
{
    public interface ITaskFactory
    {
        Task<Task> CreateAsync(string description,DateTime endDate,string taskType,string taskPriority);
    }
}
