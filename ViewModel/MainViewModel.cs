using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Navigation;

namespace TaskManager_Client.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private readonly IFrameNavigationService _navigationService = null;
        public MainViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #region LoadCommand

        private ICommand _loadCommand = null;

        public ICommand LoadCommand
        {
            get
            {
                if(_loadCommand==null)
                    _loadCommand=new RelayCommand(LoadExecute);
                return _loadCommand;
            }
        }

        private void LoadExecute()
        {
            _navigationService.NavigateTo("Login");
        }


        #endregion
    }
}
