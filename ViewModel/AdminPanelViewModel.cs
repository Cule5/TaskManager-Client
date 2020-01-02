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
using GalaSoft.MvvmLight.Views;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.Group;
using TaskManager_Client.Services.Project;
using TaskManager_Client.Services.User;
using TaskManager_Client.Utils;
using TaskManager_Client.View;

namespace TaskManager_Client.ViewModel
{
    public class AdminPanelViewModel:CommonViewModel
    {
        
        public AdminPanelViewModel(IFrameNavigationService navigationService):base(navigationService)
        {
            
        }

        #region CreateGroup Command

        private ICommand _createGroupCommand = null;

        public ICommand CreateGroupCommand => 
            _createGroupCommand ?? 
            (_createGroupCommand = new RelayCommand(CreateGroupExecute, CreateGroupCanExecute));

        private void CreateGroupExecute()
        {
            _navigationService.NavigateTo("CreateGroup");
        }
        private bool CreateGroupCanExecute()
        {
            return true;
        }

        #endregion

        #region CreateProject Command

        private ICommand _createProjectCommand = null;

        public ICommand CreateProjectCommand =>
            _createProjectCommand ??
            (_createProjectCommand = new RelayCommand(CreateProjectExecute));

        private void CreateProjectExecute()
        {
            _navigationService.NavigateTo("CreateProject");
        }

        #endregion

        #region CreateUser Command

        private ICommand _createUserCommand = null;

        public ICommand CreateUserCommand =>
            _createUserCommand ?? (_createUserCommand =
                new RelayCommand( CreateUserExecute));

        private void CreateUserExecute()
        {
            _navigationService.NavigateTo("CreateUser");
        }

        #endregion

        #region EditUser Command

        private ICommand _editUserCommand = null;

        public ICommand EditUserCommand => _editUserCommand ?? (_editUserCommand = new RelayCommand(EditUserExecute));

        private void EditUserExecute()
        {
            _navigationService.NavigateTo("FindUser");
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
            _navigationService.NavigateTo("Mailbox");
        }

        #endregion


        #region CurrentWindow Property

        public Window CurrentWindow { get; set; }

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
