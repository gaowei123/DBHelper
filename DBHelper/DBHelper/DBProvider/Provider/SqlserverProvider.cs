using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBHelper.DBProvider.Provider
{
    public class SqlserverProvider : IProvider
    {
        public DbCommand CreateCommand()
        {
            return new SqlCommand();
        }


        public DbConnection CreateConnection()
        {
            return new SqlConnection();
        }

        public DbDataAdapter CreateDataAdapter()
        {
            return new SqlDataAdapter();
        }


    }
}