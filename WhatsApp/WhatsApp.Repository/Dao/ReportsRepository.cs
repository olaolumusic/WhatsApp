using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsApp.Core.Dto.Appsettings;
using WhatsApp.Core.Dto.Reports;
using WhatsApp.Repository.Interfaces;

namespace WhatsApp.Repository.Dao
{
    public class ReportsRepository : IReportsRepository
    {
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reports> FindAll(int pageNum = 1, int pageSize = 10)
        {
            try
            {
                using (var conn = SqlDatabaseConnectionHelper.OpenConnection())
                {
                    var result = conn.Query<Reports>("SELECT [Id] ,[Name] ,[LoginStatus] ,[LoginDateAndTime]  ,[IPAddress] FROM [application_settings](nolock)");
                    return result;
                }
            }
            catch (Exception exception)
            {
            }
            return null;
        }

        public Reports FindById(int id)
        {
            throw new NotImplementedException();
        }

        ApplicationSettings IReportsRepository.FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
