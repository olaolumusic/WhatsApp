using System;
namespace WhatsApp.Core.Dto.Applogs
{
    public class ApplicationLogs
    {
        public long LogId { get; set; }
        public string LogMessage { get; set; }
        public string StackTrace { get; set; }
        public DateTime LogDate { get; set; }
    }
}
