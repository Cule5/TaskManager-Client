using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Client.Dto;

namespace TaskManager_Client.Services.Conversation
{
    public interface IConversationService
    {
        System.Threading.Tasks.Task SendAsync(Model.Conversation.Conversation conversation);
        Task<HttpResponseMessage> UserMessagesAsync();
        Task<HttpResponseMessage> GetMessageAsync(int conversationId);
        System.Threading.Tasks.Task ChangeMessageState(int ConversationId);
    }
}
