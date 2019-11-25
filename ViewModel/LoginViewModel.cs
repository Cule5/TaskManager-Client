using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Views;
using TaskManager_Client.Enums;
using TaskManager_Client.Model.Account.Factories;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.User;
using TaskManager_Client.Utils;
using TaskManager_Client.View;

namespace TaskManager_Client.ViewModel
{
    public class LoginViewModel:CommonViewModel
    {
        private readonly IUserService _userService = null;
        private readonly IAccountFactory _accountFactory = null;
        public LoginViewModel(IUserService userService,IAccountFactory accountFactory,IFrameNavigationService navigationService):base(navigationService)
        {
            _userService = userService;
            _accountFactory = accountFactory;
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
            var account=await _accountFactory.CreateAsync(Login, Password);
            await _userService.LoginAsync(account);

            var jwtToken = new JwtSecurityToken(TokenWraper.Token);
            var claims = jwtToken.Claims;
            var role = claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Role));
            if(role==null)
                return;
            if (role.Value.Equals(EUserType.CompanyAdmin.ToString()))
            {
                _navigationService.NavigateTo("AdminPanel");
            }
            else if (role.Value.Equals(EUserType.ProjectManager.ToString()))
            {
                _navigationService.NavigateTo("ProjectManagerPanel");
            }
            else if (role.Value.Equals(EUserType.Worker.ToString()))
            {
                _navigationService.NavigateTo("WorkerPanel");
            }
           

        }

        private bool LoginCanExecute()
        {
            return !Login.Equals(string.Empty)&&!Password.Equals(string.Empty);
        }
        #endregion

        #region CurrentWindow Property

        public Window CurrentWindow { get; set; }

        #endregion


    }
}
