using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Dto;
using TaskManager_Client.Model.Task.Factories;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.Project;
using TaskManager_Client.Services.Task;

namespace TaskManager_Client.ViewModel
{
    public class CreateTaskViewModel:CommonViewModel
    {
        private readonly ITaskService _taskService = null;
        private readonly IProjectService _projectService = null;
        private readonly ITaskFactory _taskFactory = null;
        public CreateTaskViewModel(ITaskService taskService,IProjectService projectService,ITaskFactory taskFactory,IFrameNavigationService navigationService):base(navigationService)
        {
            _taskService = taskService;
            _projectService = projectService;
            _taskFactory = taskFactory;
        }

        #region TaskDescription Property

        private string _taskDescription = string.Empty;

        public string TaskDescription
        {
            get => _taskDescription;
            set { Set(()=>TaskDescription,ref _taskDescription,value); }
        }

        #endregion

        #region TasksTypes Property

        private IEnumerable<string>_tasksTypes=new List<string>();

        public IEnumerable<string> TasksTypes
        {
            get => _tasksTypes;
            set { Set(()=>TasksTypes,ref _tasksTypes,value); }
        }

        #endregion

        #region TasksPriorities Property

        private IEnumerable<string> _tasksPriorities=new List<string>();

        public IEnumerable<string> TasksPriorities
        {
            get => _tasksPriorities;
            set { Set(()=>TasksPriorities,ref _tasksPriorities,value); }
        }

        #endregion

        #region Projects Property

        private IEnumerable<CommonProjectDto>_projects=new List<CommonProjectDto>();

        public IEnumerable<CommonProjectDto> Projects
        {
            get => _projects;
            set { Set(()=>Projects,ref _projects,value); }
        }


        #endregion

        #region StartDate Property

        private DateTime _startDate=DateTime.Today;
        public DateTime StartDate
        {
            get => _startDate;
            set { Set(()=>StartDate,ref _startDate,value); }
        }

        #endregion

        #region EndDate Property

        private DateTime _endDate = DateTime.Today;

        public DateTime EndDate
        {
            get => _endDate;
            set { Set(()=>EndDate,ref _endDate,value); }
        }

        #endregion

        #region TaskPriority Property

        private string _taskPriority = string.Empty;
        public string TaskPriority
        {
            get => _taskPriority;
            set { Set(()=>TaskPriority,ref _taskPriority,value); }
        }

        #endregion

        #region TaskType Property

        private string _taskType=string.Empty;

        public string TaskType
        {
            get => _taskType;
            set { Set(() => TaskType, ref _taskType, value); }
        }

        #endregion

        #region Project Property

        public CommonProjectDto Project { get; set; }

        #endregion

        #region TasksTypes Command

        private ICommand _tasksTypesCommand = null;

        public ICommand TasksTypesCommand => _tasksTypesCommand ?? (_tasksTypesCommand = new RelayCommand(async ()=>await TaskTypesExecute()));

        private async Task TaskTypesExecute()
        {
            var response = await _taskService.TasksTypesAsync();
            if (response.IsSuccessStatusCode)
            {
                var tasksTypes = await response.Content.ReadAsAsync<IEnumerable<string>>();
                TasksTypes=new ObservableCollection<string>(tasksTypes);
            }
        }

        #endregion

        #region TasksPriorities Command

        private ICommand _tasksPrioritiesCommand = null;

        public ICommand TasksPrioritiesCommand
        {
            get
            {
                return _tasksPrioritiesCommand ?? (_tasksPrioritiesCommand =
                           new RelayCommand(async () => await TasksPrioritiesExecute()));
            }
        }

        private async Task TasksPrioritiesExecute()
        {
            var response = await _taskService.TasksPrioritiesAsync();
            if (response.IsSuccessStatusCode)
            {
                var tasksPriorities = await response.Content.ReadAsAsync<IEnumerable<string>>();
                TasksPriorities=new ObservableCollection<string>(tasksPriorities);
            }
        }

        #endregion

        #region Projects Command

        private ICommand _projectsCommand = null;

        public ICommand ProjectsCommand => _projectsCommand ?? (_projectsCommand = new RelayCommand(async () => await ProjectsExecute()));

        private async Task ProjectsExecute()
        {
            var response = await _projectService.UserProjectsAsync();
            if (response.IsSuccessStatusCode)
                Projects = await response.Content.ReadAsAsync<IEnumerable<CommonProjectDto>>();
        }

        #endregion

        #region CreateTask Command

        private ICommand _createTaskCommand = null;

        public ICommand CreateTaskCommand => _createTaskCommand ?? (_createTaskCommand = new RelayCommand(async ()=>await CreateTaskExecute()));

        private async Task CreateTaskExecute()
        {
            var task = await _taskFactory.CreateAsync(TaskDescription,StartDate,EndDate,TaskType,TaskPriority,Project.ProjectId);
            try
            {
                var response = await _taskService.CreateTaskAsync(task);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Task was created");
                }
            }
            catch (HttpRequestException)
            {

            }
            
        }

        #endregion
    }
}
