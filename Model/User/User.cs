using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Client.Enums;

namespace TaskManager_Client.Model.User
{
    public class User
    {
        public User(string name,string lastName,string email,EUserType userType,string groupName,IEnumerable<string> projects)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            UserType = userType;
            GroupName = groupName;
            Projects = projects;
        }
        public string Name { get; }
        public string LastName { get;  }
        public string Email { get; set; }
        public EUserType UserType { get; set; }
        public string GroupName { get; set; }
        public IEnumerable<string> Projects { get; set; }

    }
}
