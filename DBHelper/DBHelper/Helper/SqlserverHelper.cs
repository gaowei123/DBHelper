using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DBHelper.Helper
{
    public class SqlserverHelper : IHelper
    {
        public DataTable GetTable(string strSql)
        {
            throw new NotImplementedException();
        }

        public DataTable GetTable(string strSql, SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable GetTable(string strSql, SqlParameter[] parameters, SqlConnection conn)
        {
            throw new NotImplementedException();
        }
    }
}
