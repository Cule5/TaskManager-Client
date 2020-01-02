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

namespace TaskManager_Client.Services.Conversation
{
    public class ConversationService:IConversationService
    {
        public async System.Threading.Tasks.Task SendAsync(Model.Conversation.Conversation conversation)
        {
            var serializedGroup = JsonConvert.SerializeObject(conversation);
            var stringContent = new StringContent(serializedGroup, Encoding.UTF8, "application/json");
            RequestHelper.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.PostAsync("api/Conversation/SendMessage", stringContent);
            if (response.IsSuccessStatusCode)
                MessageBox.Show("Message was sent");
        }

        public async Task<HttpResponseMessage> UserMessagesAsync()
        {
            RequestHelper.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.GetAsync("api/Conversation/UserMessages");
            return response;
        }

        public async Task<HttpResponseMessage> GetMessageAsync(int conversationId)
        {
            RequestHelper.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.GetAsync($"api/Conversation/GetMessage/{conversationId}");
            return response;
        }

        public async System.Threading.Tasks.Task ChangeMessageState(int conversationId)
        {
            var serializedConversation = JsonConvert.SerializeObject(new {ConversationId=conversationId});
            var stringContent = new StringContent(serializedConversation, Encoding.UTF8, "application/json");
            RequestHelper.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenWraper.Token);
            var response = await RequestHelper.Client.PostAsync("api/Conversation/ChangeMessageState", stringContent);
        }
    }
}
