using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Dto;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.Task;

namespace TaskManager_Client.ViewModel
{
    public class AvailableTasksViewModel:CommonViewModel
    {
        private readonly ITaskService _taskService = null;
        public AvailableTasksViewModel(IFrameNavigationService navigationService,ITaskService taskService) : base(navigationService)
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

        #region Task Property

        public CommonTaskDto Task { get; set; }

        #endregion

        #region Load Command

        private ICommand _loadCommand = null;

        public ICommand LoadCommand => _loadCommand ?? (_loadCommand = new RelayCommand(LoadExecute));

        private async void LoadExecute()
        {
            var response = await _taskService.AvailableTasksAsync();
            if (response.IsSuccessStatusCode)
                TasksCollection = await response.Content.ReadAsAsync<IEnumerable<CommonTaskDto>>();
        }

        #endregion

        #region ApplyTaskCommand Command

        private ICommand _applyTaskCommand = null;

        public ICommand ApplyTaskCommand => _applyTaskCommand ?? (_applyTaskCommand = new RelayCommand(async ()=>await ApplyTaskExecute(),ApplyTaskCanExecute));

        private async Task ApplyTaskExecute()
        {
            var response = await _taskService.SetTaskToUserAsync(Task.TaskId);
            if (response.IsSuccessStatusCode)
                MessageBox.Show("Operation completed successfully");

        }
        private bool ApplyTaskCanExecute()
        {
            return Task != null;
        }

        #endregion
    }
}
