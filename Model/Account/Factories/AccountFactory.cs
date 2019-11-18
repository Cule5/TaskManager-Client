using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.Account.Factories
{
    public class AccountFactory:IAccountFactory
    {
        public Task<Account> CreateAsync(string email,string password)
        {
            return System.Threading.Tasks.Task.Factory.StartNew(()=>new Account(email,password));
        }
    }
}
