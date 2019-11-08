using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Services.Project
{
    public interface IProjectService
    {
        Task<IEnumerable<string>> AllProjectsAsync();
        System.Threading.Tasks.Task CreateProjectAsync(Model.Project.Project project);
    }
}
