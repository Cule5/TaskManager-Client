﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Services.Task
{
    public interface ITaskService
    {
        System.Threading.Tasks.Task CreateTaskAsync();
    }
}
