using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using WhatsApp.Core.Dto.Appsettings;
using WhatsApp.Repository.Interfaces;

namespace WhatsApp.Repository.Dao
{
    public class ApplicationSettingsRepository : IApplicationSettingsRepository
    {
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationSettings> FindAll(int pageNum = 1, int pageSize = 10)
        {
            try
            {
                using (var conn = SqlDatabaseConnectionHelper.OpenConnection())
                {
                    var result = conn.Query<ApplicationSettings>(sql:"application_settings_findall",
                                  commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception exception)
            {
            }
            return null;
        }

        public ApplicationSettings FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
