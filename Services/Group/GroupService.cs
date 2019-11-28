using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using TaskManager_Client.Dto;
using TaskManager_Client.Helpers;
using TaskManager_Client.Utils;

namespace TaskManager_Client.Services.Group
{
    public class GroupService:IGroupService
    {
        public async Task<HttpResponseMessage> CreateGroupAsync(CreateGroupDto createGroupDto)
        {
            var serializedGroup = JsonConvert.SerializeObject(createGroupDto);
            var stringContent=new StringContent(serializedGroup,Encoding.UTF8, "application/json");
            RequestHelper.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.PostAsync("api/Group/CreateGroup",stringContent);
            return response;
        }

        public async Task<HttpResponseMessage> AllGroupsAsync()
        {
            RequestHelper.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.GetAsync("api/Group/AllGroups");
            return response;
        }
    }
}
