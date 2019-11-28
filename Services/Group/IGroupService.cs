using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Client.Dto;

namespace TaskManager_Client.Services.Group
{
    public interface IGroupService
    {
        Task<HttpResponseMessage> CreateGroupAsync(CreateGroupDto createGroupDto);
        Task<HttpResponseMessage> AllGroupsAsync();
    }
}
