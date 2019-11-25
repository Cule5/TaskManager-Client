using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Dto
{
    public class CreateGroupDto
    {
        public CreateGroupDto(string groupName,IEnumerable<CommonUserDto>users)
        {
            GroupName = groupName;
            Users = users;
        }
        public string GroupName { get; }
        public IEnumerable<CommonUserDto> Users { get; }
    }
}
