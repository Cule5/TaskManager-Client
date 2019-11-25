﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Services.Task
{
    public interface ITaskService
    {
        Task<HttpResponseMessage> CreateTaskAsync(Model.Task.Task task);
        Task<HttpResponseMessage> TasksTypesAsync();
        Task<HttpResponseMessage> TasksPrioritiesAsync();
        Task<HttpResponseMessage> UserTasksAsync();
        Task<HttpResponseMessage> AvailableTasksAsync();
    }
}
