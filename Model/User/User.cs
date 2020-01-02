using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Client.Dto;
using TaskManager_Client.Enums;

namespace TaskManager_Client.Model.User
{
    public class User
    {
        public User(string name,string lastName,string email,EUserType userType,int? groupId,IEnumerable<CommonProjectDto> projects)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            UserType = userType;
            GroupId = groupId;
            Projects = projects;
        }
        public string Name { get; }
        public string LastName { get;  }
        public string Email { get; set; }
        public EUserType UserType { get; set; }
        public int? GroupId { get; set; }
        public IEnumerable<CommonProjectDto> Projects { get; set; }

    }
}
