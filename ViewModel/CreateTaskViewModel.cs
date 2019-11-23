﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Model.Task.Factories;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.Task;

namespace TaskManager_Client.ViewModel
{
    public class CreateTaskViewModel:CommonViewModel
    {
        private readonly ITaskService _taskService = null;
        private readonly ITaskFactory _taskFactory = null;
        public CreateTaskViewModel(ITaskService taskService,ITaskFactory taskFactory,IFrameNavigationService navigationService):base(navigationService)
        {
            _taskService = taskService;
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

        private ObservableCollection<string>_tasksTypes=new ObservableCollection<string>();

        public ObservableCollection<string> TasksTypes
        {
            get => _tasksTypes;
            set { Set(()=>TasksTypes,ref _tasksTypes,value); }
        }

        #endregion

        #region TasksPriorities Property

        private ObservableCollection<string> _tasksPriorities;

        public ObservableCollection<string> TasksPriorities
        {
            get => _tasksPriorities;
            set { Set(()=>TasksPriorities,ref _tasksPriorities,value); }
        }

        #endregion

        #region EndDate Property

        private DateTime _endDate;

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

        #region CreateTask Command

        private ICommand _createTaskCommand = null;

        public ICommand CreateTaskCommand => _createTaskCommand ?? (_createTaskCommand = new RelayCommand(async ()=>await CreateTaskExecute()));

        private async Task CreateTaskExecute()
        {
            var task = await _taskFactory.CreateAsync(TaskDescription,EndDate,TaskType,TaskPriority);
            await _taskService.CreateTaskAsync(task);
        }

        #endregion
    }
}
