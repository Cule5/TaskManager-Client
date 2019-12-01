using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.Conversation.Factories
{
    public interface IConversationFactory
    {
        Task<Conversation> CreateAsync(int receiverId,string title,string messageContent);
    }
}
