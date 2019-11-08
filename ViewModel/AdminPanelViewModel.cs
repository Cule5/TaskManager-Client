using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Services.Group;
using TaskManager_Client.Services.Project;
using TaskManager_Client.Services.User;
using TaskManager_Client.View;

namespace TaskManager_Client.ViewModel
{
    public class AdminPanelViewModel:CommonViewModel
    {
        public AdminPanelViewModel()
        {

        }

        #region CreateGroup Command

        private ICommand _createGroupCommand = null;

        public ICommand CreateGroupCommand => 
            _createGroupCommand ?? 
            (_createGroupCommand = new RelayCommand(CreateGroupExecute, CreateGroupCanExecute));

        private void CreateGroupExecute()
        {
            var createGroupView = new CreateGroupView();
            CurrentWindow.Hide();
            createGroupView.Show();
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
            (_createProjectCommand = new RelayCommand(CreateProjectExecute, CreateGroupCanExecute));

        private void CreateProjectExecute()
        {
            var createProjectView=new CreateProjectView();
            CurrentWindow.Hide();
            createProjectView.Show();
        }

        private bool CreateProjectCanExecute()
        {
            return true;
        }

        #endregion

        #region CreateUser Command

        private ICommand _createUserCommand = null;

        public ICommand CreateUserCommand =>
            _createUserCommand ?? (_createUserCommand =
                new RelayCommand( CreateUserExecute, CreateUserCanExecute));

        private void CreateUserExecute()
        {
            var createUserView=new CreateUserView();
            CurrentWindow.Hide();
            createUserView.Show();
            
        }

        private bool CreateUserCanExecute()
        {
            return true;
        }

        #endregion

        #region CurrentWindow Property

        public Window CurrentWindow { get; set; }

        #endregion
    }
}
