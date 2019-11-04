using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaskManager_Client.Enums;
using TaskManager_Client.Helpers;
using TaskManager_Client.Model.Account;
using TaskManager_Client.View;
using TaskManager_Client.Services.User;
using TaskManager_Client.Utils;

namespace TaskManager_Client.Services.User
{
    public class UserService:IUserService
    {
        
        public async System.Threading.Tasks.Task LoginAsync(Account account)
        {

            var serializedAccount=JsonConvert.SerializeObject(account);
            var stringContent=new StringContent(serializedAccount, Encoding.UTF8, "application/json");


            var response = await RequestHelper.Client.PostAsync("api/User/Login", stringContent);
            if (response.IsSuccessStatusCode)
            {
                
                var test = await response.Content.ReadAsAsync<Content>();
                TokenWraper.Token = test.Token;
                TokenWraper.Expires = test.Expires;
               

            }
            
        }

        public System.Threading.Tasks.Task RegisterUserAsync()
        {
            throw new NotImplementedException();
        }
    }

    public class Content
    {
        
        public string Token { get; set; }
        public long Expires { get; set; }
    }

}
