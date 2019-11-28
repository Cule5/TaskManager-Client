using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Client.Dto;
using TaskManager_Client.Enums;

namespace TaskManager_Client.Model.User.Factories
{
    public interface IUserFactory
    {
        Task<User> CreateAsync(string name, string lastName, string email, EUserType userType, int groupId, IEnumerable<CommonProjectDto> projects);
    }
}
