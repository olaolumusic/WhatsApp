using System;
using System.Collections.Generic;
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
