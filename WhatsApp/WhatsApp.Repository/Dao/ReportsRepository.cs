using Dapper;
using System;
using System.Collections.Generic;
using WhatsApp.Core.Dto.Reports;
using System.Data;
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
                    var result = conn.Query<Reports>(sql:"reports_findall",
                        commandType: CommandType.StoredProcedure);
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
    }
}
