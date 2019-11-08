using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.Project.Factories
{
    public interface IProjectFactory
    {
        Task<Project> CreateAsync(string projectName,string projectDescription,DateTime startDate);
    }
}
