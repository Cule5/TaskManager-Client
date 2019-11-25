﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaskManager_Client.Dto;
using TaskManager_Client.Enums;
using TaskManager_Client.Helpers;
using TaskManager_Client.Model.Account;
using TaskManager_Client.View;
using TaskManager_Client.Services.User;
using TaskManager_Client.Utils;

namespace TaskManager_Client.Services.User
{
    public class UserService:IUserService
    {
        
        public async System.Threading.Tasks.Task LoginAsync(Account account)
        {

            var serializedAccount=JsonConvert.SerializeObject(account);
            var stringContent=new StringContent(serializedAccount, Encoding.UTF8, "application/json");


            var response = await RequestHelper.Client.PostAsync("api/User/Login", stringContent);
            if (response.IsSuccessStatusCode)
            {
                
                var test = await response.Content.ReadAsAsync<Content>();
                TokenWraper.Token = test.Token;
                TokenWraper.Expires = test.Expires;
               

            }
            
        }

        public async Task<HttpResponseMessage> RegisterUserAsync(Model.User.User user)
        {
            var serializedUser = JsonConvert.SerializeObject(user);
            var stringContent=new StringContent(serializedUser,Encoding.UTF8, "application/json");
            var response = await RequestHelper.Client.PostAsync("api/User/Register", stringContent);
            return response;
        }

        public async Task<IEnumerable<string>> AllUsersTypesAsync()
        {
            RequestHelper.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.GetAsync("api/User/UsersTypes");
            if (!response.IsSuccessStatusCode) return new List<string>();
            var allUsersTypes = await response.Content.ReadAsAsync<IEnumerable<string>>();
            return allUsersTypes;
        }

        public async Task<IEnumerable<CommonUserDto>> FindUserAsync(CommonUserDto commonUserDto)
        {
            var serializedUser = JsonConvert.SerializeObject(commonUserDto);
            var stringContent=new StringContent(serializedUser,Encoding.UTF8,"application/json");
            var response = await RequestHelper.Client.PostAsync("api/User/FindUser",stringContent);
            if (!response.IsSuccessStatusCode) return new List<CommonUserDto>();
            var users = await response.Content.ReadAsAsync<IEnumerable<CommonUserDto>>();
            return users;
        }

        public async Task<HttpResponseMessage> UsersWithoutGroupAsync()
        {
            RequestHelper.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.GetAsync("api/User/UsersWithoutGroup");
            return response;
        }

        public async Task<HttpResponseMessage> UserInfoAsync()
        {
            throw new NotImplementedException();
        }
    }

    public class Content
    {
        
        public string Token { get; set; }
        public long Expires { get; set; }
    }

}
