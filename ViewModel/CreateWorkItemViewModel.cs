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
using TaskManager_Client.Model.WorkItem.Factories;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.Task;
using TaskManager_Client.Services.WorkItem;

namespace TaskManager_Client.ViewModel
{
    public class CreateWorkItemViewModel:CommonViewModel
    {
        private readonly IWorkItemService _workItemService = null;
        private readonly ITaskService _taskService = null;
        private readonly IWorkItemFactory _workItemFactory = null;
        public CreateWorkItemViewModel(IFrameNavigationService navigationService,IWorkItemService workItemService,ITaskService taskService,IWorkItemFactory workItemFactory):base(navigationService)
        {
            _workItemService = workItemService;
            _taskService = taskService;
            _workItemFactory = workItemFactory;
        }

        #region Comment Property

        public string Comment { get; set; } = string.Empty;

        #endregion

        #region ReportDate Property

        public DateTime ReportDate { get; set; }=DateTime.Now;

        #endregion

        #region Time Property

        public double Time { get; set; }

        #endregion

        #region TaskProgress Property

        public IEnumerable<string> TaskProgress { get; set; }

        #endregion

        #region SelectedTaskProgress Property

        public string SelectedTaskProgress { get; set; }

        #endregion

        #region CreateReport Command

        private ICommand _createReportCommand = null;

        public ICommand CreateReportCommand => _createReportCommand ?? (_createReportCommand = new RelayCommand(async ()=>await CreateReportExecute()));

        private async Task CreateReportExecute()
        {
            var workItem=await _workItemFactory.CreateAsync(Comment,Time,ReportDate,SelectedTaskProgress,((CommonTaskDto)_navigationService.Parameter).TaskId);
            var response = await _workItemService.CreateWorkItemAsync(workItem);
            if (response.IsSuccessStatusCode)
                MessageBox.Show("Operation completed");
        }

        #endregion

        #region Load Command

        private ICommand _loadCommand = null;

        public ICommand LoadCommand => _loadCommand ?? (_loadCommand = new RelayCommand(async ()=>await LoadExecute()));

        private async Task LoadExecute()
        {
            var response = await _taskService.TaskTypesAsync();
            if (response.IsSuccessStatusCode)
            {
                TaskProgress = await response.Content.ReadAsAsync<IEnumerable<string>>();
                RaisePropertyChanged("TaskProgress");
            }
                
        }

        #endregion
    }
}
