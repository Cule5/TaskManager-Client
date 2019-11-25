using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.User;

namespace TaskManager_Client.ViewModel
{
    public class UserInfoViewModel:CommonViewModel
    {
        private readonly IUserService _userService = null;
        public UserInfoViewModel(IUserService userService,IFrameNavigationService frameNavigationService):base(frameNavigationService)
        {
            _userService = userService;
        }

        #region CurrentWindow Property

        public Window CurrentWindow { get; set; }

        #endregion

        #region Apply Command

        private ICommand _applyCommand = null;

        public ICommand ApplyCommand => _applyCommand ?? (_applyCommand = new RelayCommand(ApplyExecute));
        private void ApplyExecute()
        {
            CurrentWindow.DialogResult = true;
        }

        #endregion

        #region Cancel Command

        private ICommand _cancelCommand = null;

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(CancelExecute));

        private void CancelExecute()
        {
            CurrentWindow.DialogResult = false;
        }

        #endregion

        #region Load Command

        private ICommand _loadCommand = null;

        public ICommand LoadCommand => _loadCommand ?? (_loadCommand = new RelayCommand(LoadExecute));

        private void LoadExecute()
        {

        }

        #endregion

        #region EditProjects Command

        private ICommand _editProjectsCommand = null;

        public ICommand EditProjectsCommand => _editProjectsCommand ?? (_editProjectsCommand = new RelayCommand(EditProjectsExecute));
        private void EditProjectsExecute()
        {

        }

        #endregion

        #region EditGroups Command

        private ICommand _editGroupsCommand = null;

        public ICommand EditGroupsCommand => _editGroupsCommand ?? (_editGroupsCommand = new RelayCommand(EditGroupsExecute));

        private void EditGroupsExecute()
        {

        }

        #endregion
    }
}
