using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Services.WorkItem
{
    public interface IWorkItemService
    {
        Task<HttpResponseMessage> CreateWorkItemAsync(Model.WorkItem.WorkItem workItem);
    }
}
