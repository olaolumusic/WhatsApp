using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsApp.Core.Dto.Applogs;
using WhatsApp.Core.Dto.Appsettings;

namespace WhatsApp.Repository.Interfaces
{
    public interface IApplicationLogsRepository
    {
        IEnumerable<ApplicationLogs> FindAll(int pageNum = 1, int pageSize = 10);
        void DeleteById(int id);
        ApplicationLogs FindById(int id); 
    }
}
