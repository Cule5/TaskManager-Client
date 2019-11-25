using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.Task;
using TaskManager_Client.View;

namespace TaskManager_Client.ViewModel
{
    public class ProjectManagerPanelViewModel:CommonViewModel
    {
        private readonly ITaskService _taskService = null;
        public ProjectManagerPanelViewModel(ITaskService taskService,IFrameNavigationService frameNavigationService):base(frameNavigationService)
        {
            _taskService = taskService;
            
        }

        #region CurrentWindow Property

        public Window CurrentWindow { get; set; }

        #endregion

        #region CreateTask Command

        private ICommand _createTaskCommand = null;

        public ICommand CreateTaskCommand =>
            _createTaskCommand ??
            (_createTaskCommand = new RelayCommand(CreateTaskExecute));

        private void CreateTaskExecute()
        {
            _navigationService.NavigateTo("CreateTask");
        }


        #endregion

        #region SendMessage Command

        private ICommand _sendMessageCommand = null;

        public ICommand SendMessageCommand => _sendMessageCommand ?? (_sendMessageCommand = new RelayCommand(SendMessageExecute));

        private void SendMessageExecute()
        {
            _navigationService.NavigateTo("SendMessage");
        }

        #endregion

        #region Mailbox Command

        private ICommand _mailboxCommand = null;

        public ICommand MailboxCommand => _mailboxCommand ?? (_mailboxCommand = new RelayCommand(MailboxExecute));

        private void MailboxExecute()
        {

        }

        #endregion
    }
}
