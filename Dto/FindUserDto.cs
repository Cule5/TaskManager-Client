﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Dto
{
    public class FindUserDto
    {
        public FindUserDto()
        {

        }
        public FindUserDto(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
        public FindUserDto(string name, string lastName,string email)
        {
            Name = name;
            LastName = lastName;
            Email = email;
        }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
