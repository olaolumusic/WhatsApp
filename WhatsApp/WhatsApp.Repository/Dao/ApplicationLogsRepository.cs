using Dapper;
using System;
using System.Collections.Generic;
using WhatsApp.Core.Dto.Applogs;
using WhatsApp.Core.Dto.Appsettings;
using WhatsApp.Repository.Interfaces;

namespace WhatsApp.Repository.Dao
{
    public class ApplicationLogsRepository : IApplicationLogsRepository
    {
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationLogs> FindAll(int pageNum = 1, int pageSize = 10)
        {
            try
            {
                using (var conn = SqlDatabaseConnectionHelper.OpenConnection())
                {
                    var result = conn.Query<ApplicationLogs>("SELECT [Id] ,[Name] ,[PhoneNumber] ,[State]  ,[Country] ,[DeviceName] ,[TimeDuration] ,[UserAgent] FROM [application_logs](nolock)");
                    return result;
                }
            }
            catch (Exception exception)
            {
            }
            return null;
        }

        public ApplicationLogs FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
