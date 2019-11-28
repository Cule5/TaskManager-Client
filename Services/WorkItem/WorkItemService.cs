using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaskManager_Client.Helpers;

namespace TaskManager_Client.Services.WorkItem
{
    public class WorkItemService:IWorkItemService
    {
        
        public async Task<HttpResponseMessage> CreateWorkItemAsync(Model.WorkItem.WorkItem workItem)
        {
            var serializedWorkItem = JsonConvert.SerializeObject(workItem);
            var stringContent = new StringContent(serializedWorkItem, Encoding.UTF8, "application/json");
            var response = await RequestHelper.Client.PostAsync("api/WorkItem/CreateWorkItem", stringContent);
            return response;
        }
    }
}
