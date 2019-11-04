using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.Account.Factories
{
    public class AccountFactory:IAccountFactory
    {
        public Task<Account> CreateAsync(string login,string password)
        {
            return Task.Factory.StartNew(()=>new Account(login,password));
        }
    }
}
