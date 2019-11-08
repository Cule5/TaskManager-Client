using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.Group
{
    public class Group
    {
        public Group(string groupName)
        {
            GroupName = groupName;
        }
        public string GroupName { get; }
    }
}
