using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsApp.Dto.Core
{
    public class Status
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public DateTime StatusDate { get; set; }
        public string StatusType { get; set; }
    }
}
