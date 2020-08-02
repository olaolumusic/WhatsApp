using System;
using System.Collections.Generic;
using WhatsApp.Core.Dto.Reports;



namespace WhatsApp.Repository.Interfaces
{
    public interface IReportsRepository
    {
        IEnumerable<Reports> FindAll(int pageNum = 1, int pageSize = 10);
        void DeleteById(int id);
        Reports FindById(int id); 
    }
}
