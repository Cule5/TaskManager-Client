using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using TaskManager_Client.Helpers;
using TaskManager_Client.Utils;

namespace TaskManager_Client.Services.Task
{
    public class TaskService:ITaskService
    {
       
        public async Task<HttpResponseMessage> CreateTaskAsync(Model.Task.Task task)
        {
            var serializedGroup = JsonConvert.SerializeObject(task);
            var stringContent = new StringContent(serializedGroup, Encoding.UTF8, "application/json");
            RequestHelper.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.PostAsync("api/Task/CreateTask", stringContent);
            return response;
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

        public async Task<HttpResponseMessage> UserTasksAsync()
        {
            RequestHelper.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.GetAsync("api/Task/UserTasks");
            return response;
        }

        public async Task<HttpResponseMessage> AvailableTasksAsync()
        {
            RequestHelper.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.GetAsync("api/Tasks/AvailableTasks");
            return response;
        }
    }
}
