using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Client.Helpers;
using TaskManager_Client.Utils;

namespace TaskManager_Client.Services.Task
{
    public class TaskService:ITaskService
    {
       
        public System.Threading.Tasks.Task CreateTaskAsync(Model.Task.Task task)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> TasksTypesAsync()
        {
            RequestHelper.Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.GetAsync("api/Task/TasksTypes");
            return response;
        }

        public async Task<HttpResponseMessage> TasksPrioritiesAsync()
        {
            RequestHelper.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.GetAsync("api/Task/TasksPriorities");
            return response;
        }
    }
}
