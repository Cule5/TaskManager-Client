﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using TaskManager_Client.Helpers;
using TaskManager_Client.Utils;

namespace TaskManager_Client.Services.Group
{
    public class GroupService:IGroupService
    {
        public async System.Threading.Tasks.Task CreateGroupAsync(Model.Group.Group group)
        {
            var serializedGroup = JsonConvert.SerializeObject(group);
            var stringContent=new StringContent(serializedGroup,Encoding.UTF8, "application/json");
            RequestHelper.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.PostAsync("api/Group/CreateGroup",stringContent);
            if (response.IsSuccessStatusCode)
                MessageBox.Show("Group was created");
        }

        public async Task<IEnumerable<string>> AllGroupsAsync()
        {
            RequestHelper.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.GetAsync("api/Group/AllGroups");
            if (!response.IsSuccessStatusCode) return new List<string>();
            var allGroups = await response.Content.ReadAsAsync<IEnumerable<string>>();
            return allGroups;

        }
    }
}