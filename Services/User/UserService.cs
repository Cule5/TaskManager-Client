using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Client.Helpers;
using TaskManager_Client.View;
using TaskManager_Client.Services.User;

namespace TaskManager_Client.Services.User
{
    public class UserService:IUserService
    {
        public async Task LoginAsync(string login,string password)
        {
            
            var response = await RequestHelper.Client.GetAsync("api/User/test");
            if (response.IsSuccessStatusCode)
            {

            }
            
        }
    }
}
