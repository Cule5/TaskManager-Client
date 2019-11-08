using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.Group.Factories
{
    public interface IGroupFactory
    {
        Task<Group> CreateAsync(string groupName);
    }
}
