using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Model.Project.Factories;
using TaskManager_Client.Services.Project;

namespace TaskManager_Client.ViewModel
{
    public class CreateProjectViewModel:ViewModelBase
    {
        private readonly IProjectService _projectService = null;
        private readonly IProjectFactory _projectFactory = null;
        public CreateProjectViewModel(IProjectService projectService,IProjectFactory projectFactory)
        {
            _projectService = projectService;
            _projectFactory = projectFactory;
        }
        #region ProjectName Property

        private string _projectName = string.Empty;

        public string ProjectName
        {
            get => _projectName;
            set { Set(()=>ProjectName,ref _projectName,value); }
        }

        #endregion

        #region ProjectDescription Property

        private string _projectDescription = string.Empty;

        public string ProjectDescription
        {
            get => _projectDescription;
            set { Set(()=>ProjectDescription,ref _projectDescription,value); }
        }

        #endregion

        #region StartDate Property

        private DateTime _startDate=DateTime.Now;

        public DateTime StartDate
        {
            get => _startDate;
            set { Set(()=>StartDate,ref _startDate,value); }
        }

        #endregion

        #region CreateProject Command

        private ICommand _createProjectCommand = null;

        public ICommand CreateProjectCommand => _createProjectCommand ?? (_createProjectCommand = new RelayCommand(async ()=>await CreateProjectExecute()));

        private async Task CreateProjectExecute()
        {
            var newProject = await _projectFactory.CreateAsync(ProjectName, ProjectDescription, StartDate);
            await _projectService.CreateProjectAsync(newProject);
        }

        #endregion
    }
}
