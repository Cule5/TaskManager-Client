using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Services.Project
{
    public interface IProjectService
    {
        Task<HttpResponseMessage> AllProjectsAsync();
        System.Threading.Tasks.Task CreateProjectAsync(Model.Project.Project project);
        Task<HttpResponseMessage> UserProjectsAsync();
    }
}
