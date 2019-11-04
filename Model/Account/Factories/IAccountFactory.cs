using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.Account.Factories
{
    public interface IAccountFactory
    {
        Task<Account> CreateAsync(string login,string password);
    }
}
