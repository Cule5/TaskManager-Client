using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Services.User
{
    public interface IUserService
    {
        Task LoginAsync(string login,string password);
    }
}
