using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.Project
{
    public class Project
    {
        public Project(string projectName,string projectDescription,DateTime startDate)
        {
            ProjectName = projectName;
            ProjectDescription = projectDescription;
            StartDate = startDate;
        }
        public string ProjectName { get; }
        public string ProjectDescription { get; }
        public DateTime StartDate { get; }
    }
}
