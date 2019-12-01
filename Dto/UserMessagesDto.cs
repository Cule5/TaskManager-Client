using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Client.Enums;

namespace TaskManager_Client.Dto
{
    public class UserMessagesDto
    {
        public int ConversationId { get; set; }
        public string SenderEmail { get; set; }
        public string Title { get; set; }
        public EMessageStatus MessageStatus { get; set; }
    }
}
