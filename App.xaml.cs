using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TaskManager_Client.Helpers;
using TaskManager_Client.View;

namespace TaskManager_Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            
        }
        //protected void OnStartup(object sender, StartupEventArgs e)
        //{
        //    RequestHelper.Configure();
        //    var loginWindow = new LoginView();
        //    loginWindow.Show();
        //    base.OnStartup(e);
        //}

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            RequestHelper.Configure();
        }
        //protected void OnStartup(object sender, StartupEventArgs e)
        //{
        //    base.OnStartup(e);
        //   // RequestHelper.Configure();
        //    var loginWindow = new LoginView();
        //    loginWindow.Show();
        //    base.OnStartup(e);
        //}

       
    }

    
}
