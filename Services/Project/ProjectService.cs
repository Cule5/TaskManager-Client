using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaskManager_Client.Helpers;

namespace TaskManager_Client.Services.Project
{
    public class ProjectService:IProjectService
    {
        public async Task<IEnumerable<string>> AllProjectsAsync()
        {
            var response = await RequestHelper.Client.GetAsync("api/Project/AllProjects");
            if (!response.IsSuccessStatusCode) return new List<string>();
            var allProjects=await response.Content.ReadAsAsync<IEnumerable<string>>();
            return allProjects;
        }

        public async System.Threading.Tasks.Task CreateProjectAsync(Model.Project.Project project)
        {
            var serializedProject=JsonConvert.SerializeObject(project);
            var stringContent = new StringContent(serializedProject, Encoding.UTF8, "application/json");

            var response = await RequestHelper.Client.PostAsync("api/Project/CreateProject", stringContent);
            if (response.IsSuccessStatusCode)
            {

            }
        }
    }
}
