using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.Task;
using TaskManager_Client.Utils;

namespace TaskManager_Client.ViewModel
{
    public class WorkerPanelViewModel:CommonViewModel
    {
        public WorkerPanelViewModel(IFrameNavigationService navigationService):base(navigationService)
        {
            
        }

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
            _navigationService.NavigateTo("Mailbox");

        }

        #endregion

        #region MyTasks Command

        private ICommand _myTasksCommand = null;

        public ICommand MyTasksCommand => _myTasksCommand ?? (_myTasksCommand = new RelayCommand(MyTasksExecute));

        private void MyTasksExecute()
        {
            _navigationService.NavigateTo("UserTasks");
        }

        #endregion

        #region AvailableTasksViewModel Command

        private ICommand _availableTasksCommand = null;

        public ICommand AvailableTasksCommand => _availableTasksCommand ?? (_availableTasksCommand = new RelayCommand(AvailableTasksExecute));

        private void AvailableTasksExecute()
        {
            _navigationService.NavigateTo("AvailableTasksView");
        }

        #endregion

        #region Logout Command

        private ICommand _logoutCommand = null;

        public ICommand LogoutCommand => _logoutCommand ?? (_logoutCommand = new RelayCommand(LogoutExecute));

        private void LogoutExecute()
        {
            TokenWraper.Token = string.Empty;
            TokenWraper.Expires = 0;
            _navigationService.GoBack();
        }

        #endregion
    }
}
