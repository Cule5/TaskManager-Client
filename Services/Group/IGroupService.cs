using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Services.Group
{
    public interface IGroupService
    {
        System.Threading.Tasks.Task CreateGroupAsync(string groupName);
    }
}
