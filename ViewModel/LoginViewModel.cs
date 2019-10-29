using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Services.User;

namespace TaskManager_Client.ViewModel
{
    public class LoginViewModel:ViewModelBase
    {
        private readonly IUserService _userService = null;
        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
        }
        #region Login Property

        private string _login = string.Empty;

        public string Login
        {
            get => _login;
            set { Set(()=>Login,ref _login,value); }
        }

        #endregion

        #region Password Property

        private string _password = string.Empty;

        public string Password
        {
            get => _password;
            set { Set(()=>Password,ref _password,value); }
        }

        #endregion

        #region Login Command

        private ICommand _loginCommand = null;

        public ICommand LoginCommand => _loginCommand ?? (_loginCommand = new RelayCommand(async()=>await LoginExecute(), LoginCanExecute));

        private async Task LoginExecute()
        {
            await _userService.LoginAsync(Login,Password);
        }

        private bool LoginCanExecute()
        {
            return !Login.Equals(string.Empty)&&!Password.Equals(string.Empty);
        }
        #endregion
    }
}
