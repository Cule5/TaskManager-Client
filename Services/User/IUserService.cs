using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Client.Dto;
using TaskManager_Client.Model.Account;


namespace TaskManager_Client.Services.User
{
    public interface IUserService
    {
        System.Threading.Tasks.Task LoginAsync(Account account);
        System.Threading.Tasks.Task RegisterUserAsync(Model.User.User user);
        Task<IEnumerable<string>> AllUsersTypesAsync();
        Task<IEnumerable<FindUserDto>> FindUserAsync(FindUserDto findUserDto);

    }
}
