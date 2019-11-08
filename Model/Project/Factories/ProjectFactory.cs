using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.Project.Factories
{
    public class ProjectFactory:IProjectFactory
    {
        public Task<Project> CreateAsync(string projectName, string projectDescription, DateTime startDate)
        {
            return Task.Factory.StartNew<Project>(()=>new Project(projectName,projectDescription,startDate));
        }
    }
}
