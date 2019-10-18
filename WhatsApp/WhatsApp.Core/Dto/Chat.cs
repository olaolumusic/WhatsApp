using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsApp.Dto.Core
{
    public class Chat
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string ChatType { get; set; } //Private or Group
        public string Message { get; set; }
        public string MessageInfo { get; set; }
        public DateTime DateOfChat { get; set; }
    }
}
