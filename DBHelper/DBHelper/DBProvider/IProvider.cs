using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.DBProvider
{
    public interface IProvider
    {
        DbConnection CreateConnection();
        DbCommand CreateCommand();
        DbDataAdapter CreateDataAdapter();
    }
}
