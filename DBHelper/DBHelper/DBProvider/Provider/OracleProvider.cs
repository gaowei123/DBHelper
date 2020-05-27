using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;

namespace DBHelper.DBProvider.Provider
{
    public class OracleProvider : IProvider
    {
        public DbCommand CreateCommand()
        {
            return new OracleCommand();
        }

        public DbConnection CreateConnection()
        {
            return new OracleConnection();
        }

        public DbDataAdapter CreateDataAdapter()
        {
            return new OracleDataAdapter();
        }


    }
}
