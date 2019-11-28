using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using TaskManager_Client.Navigation;

namespace TaskManager_Client.ViewModel
{
    public class ExpiredTasksViewModel:CommonViewModel
    {
        public ExpiredTasksViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {

        }
    }
}
