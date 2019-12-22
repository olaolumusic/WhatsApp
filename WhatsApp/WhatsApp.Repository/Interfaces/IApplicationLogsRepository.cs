using System;
using System.Collections.Generic;
using WhatsApp.Core.Dto.Applogs;


namespace WhatsApp.Repository.Interfaces
{
    public interface IApplicationLogsRepository
    {
        IEnumerable<ApplicationLogs> FindAll(int pageNum = 1, int pageSize = 10);
        void DeleteById(int id);
        ApplicationLogs FindById(int id); 
    }
}
