﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.User.Factories
{
    public interface IUserFactory
    {
        Task<User> CreateAsync();
    }
}