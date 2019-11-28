using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Dto;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.Task;

namespace TaskManager_Client.ViewModel
{
    public class UserTasksViewModel:CommonViewModel
    {
        private readonly ITaskService _taskService = null;
        public UserTasksViewModel(IFrameNavigationService navigationService,ITaskService taskService):base(navigationService)
        {
            _taskService = taskService;
        }

        #region TasksCollection Property

        private IEnumerable<CommonTaskDto>_tasksCollection=new List<CommonTaskDto>();

        public IEnumerable<CommonTaskDto> TasksCollection
        {
            get => _tasksCollection;
            set { Set(()=>TasksCollection,ref _tasksCollection,value); }
        }

        #endregion

        #region 

        public CommonTaskDto Task { get; set; }

        #endregion

        #region Load Command

        private ICommand _loadCommand = null;

        public ICommand LoadCommand => _loadCommand ?? (_loadCommand = new RelayCommand(LoadExecute));

        private async void LoadExecute()
        {
            var response = await _taskService.UserTasksAsync();
            if (response.IsSuccessStatusCode)
            {
                TasksCollection = await response.Content.ReadAsAsync<IEnumerable<CommonTaskDto>>();
            }
        }

        #endregion

        
        #region CreateReport Command

        private ICommand _createReportCommand = null;

        public ICommand CreateReportCommand => _createReportCommand ?? (_createReportCommand = new RelayCommand(CreateReportExecute,CreateReportCanExecute));

        private void CreateReportExecute()
        {
            _navigationService.NavigateTo("CreateWorkItem",Task);
        }

        private bool CreateReportCanExecute()
        {
            return Task != null;
        }

        #endregion
    }
}
