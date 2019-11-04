using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace TaskManager_Client.ViewModel
{
    public class ProjectManagerPanelViewModel:ViewModelBase
    {
        
        #region CreateTask Command

        private ICommand _createTaskCommand = null;

        public ICommand CreateTaskCommand
        {
            get
            {
                return _createTaskCommand ??
                       (_createTaskCommand = new RelayCommand(()=>CreateTaskCanExecute(), CreateTaskCanExecute));
            }
        }

        private async Task CreateTaskExecute()
        {

        }

        private bool CreateTaskCanExecute()
        {
            return true;
        }

        #endregion
    }
}
