using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.Conversation
{
    public class Conversation
    {
        public Conversation(int receiverId,string message)
        {
            ReceiverId = receiverId;
            Message = message;
        }
        public int ReceiverId { get; set; }
        public string Message { get; set; }
        
    }
}
