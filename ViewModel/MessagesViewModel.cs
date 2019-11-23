using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using TaskManager_Client.Navigation;

namespace TaskManager_Client.ViewModel
{
    public class MessagesViewModel:CommonViewModel
    {
        public MessagesViewModel(IFrameNavigationService navigationService) : base(navigationService)
        {

        }
    }
}
