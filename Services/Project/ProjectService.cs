using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaskManager_Client.Helpers;
using TaskManager_Client.Utils;

namespace TaskManager_Client.Services.Project
{
    public class ProjectService:IProjectService
    {
        public async Task<HttpResponseMessage> AllProjectsAsync()
        {
            RequestHelper.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.GetAsync("api/Project/AllProjects");
            return response;
        }

        public async Task<HttpResponseMessage> CreateProjectAsync(Model.Project.Project project)
        {
            var serializedProject = JsonConvert.SerializeObject(project);

            var stringContent = new StringContent(serializedProject, Encoding.UTF8, "application/json");
            RequestHelper.Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.PostAsync("api/Project/CreateProject", stringContent);
            return response;
        }

        public async Task<HttpResponseMessage> UserProjectsAsync()
        {
            RequestHelper.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.GetAsync("api/Project/UserProjects");
            return response;
        }
    }
}
