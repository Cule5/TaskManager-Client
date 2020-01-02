using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Client.Dto;
using TaskManager_Client.Enums;

namespace TaskManager_Client.Model.User.Factories
{
    class UserFactory:IUserFactory
    {
        

        public Task<User> CreateAsync(string name, string lastName, string email, EUserType userType, int? groupId,
            IEnumerable<CommonProjectDto> projects)
        {
            return System.Threading.Tasks.Task.Factory.StartNew<User>(() => new User(name, lastName, email, userType, groupId, projects));
        }
    }
}
