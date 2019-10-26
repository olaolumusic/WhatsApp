using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsApp.Core.Dto.Appsettings;
using WhatsApp.Core.Dto.Usermgt;
using WhatsApp.Repository.Interfaces;

namespace WhatsApp.Repository.Dao
{
    public class UserManagementRepository : IUserManagementRepository
    {
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserManagement> FindAll(int pageNum = 1, int pageSize = 10)
        {
            try
            {
                using (var conn = SqlDatabaseConnectionHelper.OpenConnection())
                {
                    var result = conn.Query<UserManagement>("SELECT [Id] ,[Username] ,[Firstname] ,[Lastname]  ,[Password] ,[EmailAddress] FROM [application_settings](nolock)");
                    return result;
                }
            }
            catch (Exception exception)
            {
            }
            return null;
        }

        public UserManagement FindById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<UserManagement> IUserManagementRepository.FindAll(int pageNum, int pageSize)
        {
            throw new NotImplementedException();
        }

        ApplicationSettings IUserManagementRepository.FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
