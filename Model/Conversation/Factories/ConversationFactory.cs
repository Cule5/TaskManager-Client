using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.Conversation.Factories
{
    public class ConversationFactory: IConversationFactory
    {
        public Task<Conversation> CreateAsync(int receiverId, string messageContent)
        {
            return System.Threading.Tasks.Task.Factory.StartNew(() => new Conversation(receiverId,messageContent));
        }
    }
}
