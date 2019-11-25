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

namespace TaskManager_Client.ViewModel
{
    public class CommonViewModel:ViewModelBase
    {
        protected readonly IFrameNavigationService _navigationService = null;
        public CommonViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #region Back Command

        private ICommand _backCommand = null;

        public ICommand BackCommand => _backCommand ?? (_backCommand = new RelayCommand(BackExecute));

        private void BackExecute()
        {
            _navigationService.GoBack();
        }

        #endregion
    }
}
