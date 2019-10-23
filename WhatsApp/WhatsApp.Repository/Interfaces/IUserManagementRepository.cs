using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsApp.Core.Dto.Appsettings;
using WhatsApp.Core.Dto.Usermgt;

namespace WhatsApp.Repository.Interfaces
{
    public interface IUserManagementRepository
    {
        IEnumerable<UserManagement> FindAll(int pageNum = 1, int pageSize = 10);
        void DeleteById(int id);
        ApplicationSettings FindById(int id); 
    }
}
