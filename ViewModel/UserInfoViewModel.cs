using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        #region Apply Command

        private ICommand _applyCommand = null;

        public ICommand ApplyCommand => _applyCommand ?? (_applyCommand = new RelayCommand(ApplyExecute));
        private void ApplyExecute()
        {

        }

        #endregion

        #region Cancel Command

        private ICommand _cancelCommand = null;

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(CancelExecute));

        private void CancelExecute()
        {

        }

        #endregion

        #region Load Command

        private ICommand _loadCommand = null;

        public ICommand LoadCommand => _loadCommand ?? (_loadCommand = new RelayCommand(LoadExecute));

        private void LoadExecute()
        {

        }

        #endregion
    }
}
