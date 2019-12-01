using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Client.Enums;

namespace TaskManager_Client.Dto
{
    public class ExtendedUserDto
    {
        public ExtendedUserDto(int userId,EUserType userType,CommonGroupDto group,IEnumerable<CommonProjectDto>project )
        {
            UserId = userId;
            UserType = userType;
            Group = group;
            Projects = project;
        }
        public int UserId { get; set; }
        public EUserType UserType { get; set; }
        public CommonGroupDto Group { get; set; }
        public IEnumerable<CommonProjectDto> Projects { get; set; }
    }
}
