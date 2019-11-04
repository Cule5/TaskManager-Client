using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;

namespace TaskManager_Client.ViewModel
{
    public class CommonViewModel:ViewModelBase
    {
        #region CurrentWindow Property

        public Window CurrentWindow { get; set; }

        #endregion
    }
}
