using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Dto
{
    public class UserEmailDto
    {
        public UserEmailDto(int userId,string name,string lastName,string email)
        {
            UserId = userId;
            Name = name;
            LastName = lastName;
            Email = email;
        }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
