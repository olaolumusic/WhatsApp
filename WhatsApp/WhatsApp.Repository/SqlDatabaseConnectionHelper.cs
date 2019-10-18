using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsApp.Repository
{
    public class SqlDatabaseConnectionHelper
    {
        public static DbConnection OpenConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["WhatsAppConnectionString"].ConnectionString);
        }
    }
}
