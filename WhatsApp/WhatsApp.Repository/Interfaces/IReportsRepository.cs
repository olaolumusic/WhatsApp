using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
