using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DBHelper
{
    public interface IHelper
    {

        DataTable GetTable(string strSql);


        DataTable GetTable(string strSql, SqlParameter[] parameters);


        DataTable GetTable(string strSql, SqlParameter[] parameters, SqlConnection conn);



        DataSet GetDataSet(string strSql);


        DataSet GetDataSet(string strSql, SqlParameter[] parameters);


        DataSet GetDataSet(string strSql, SqlParameter[] parameters, SqlConnection conn);


        int ExcuteSQL(string strSql);


        int ExcuteSQL(string strSql, SqlParameter[] parameters);


        int ExcuteSQL(string strSql, SqlParameter[] parameters, SqlConnection conn);


        //int ExcuteProc(string strProcName);


        //int ExcuteProc(string strProcName, SqlParameter[] parameters);


        //bool BulkToDB(DataTable sourceDt, string targetTable);

        

        


    }
}