using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsApp.Dto.Core
{
    public class Call
    {
        public int CallerId { get; set; }
        public int ReceiverId { get; set; }
        public TimeSpan CallDuration  { get; set; }
        public DateTime CallDateAndTime { get; set; }
    }
}
