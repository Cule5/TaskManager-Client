using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.Group.Factories
{
    public class GroupFactory:IGroupFactory
    {
        public Task<Group> CreateAsync(string groupName)
        {
            return System.Threading.Tasks.Task.Factory.StartNew<Group>(()=>new Group(groupName));
        }
    }
}
