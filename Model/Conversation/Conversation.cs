using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.Conversation
{
    public class Conversation
    {
        public Conversation(int receiverId,string title,string message)
        {
            ReceiverId = receiverId;
            Title = title;
            Message = message;
        }
        public int ReceiverId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        
    }
}
