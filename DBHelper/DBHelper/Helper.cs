using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DBHelper
{
    public class Helper
    {
        private static DBProvider.IProvider provider = DBProvider.ProviderFactory.GetProvider();
        private static string strConnection = ConfigurationManager.ConnectionStrings["TaiyoLaser"].ConnectionString;


        public Helper()
        {
            
        }



        public static DataTable GetTable(string strSql, DbParameter[] parameters)
        {

            DbConnection con = provider.CreateConnection();
            con.ConnectionString = strConnection;



            DbCommand com = provider.CreateCommand();
            com.Connection = con;
            com.CommandText = strSql;
            com.CommandType = CommandType.Text;



            foreach (DbParameter para in parameters)
            {
                if (para != null)
                    com.Parameters.Add(para);
            }
        

            


            DataSet ds = new DataSet();
            DbDataAdapter ad = provider.CreateDataAdapter();
            ad.SelectCommand = com;
            

            con.Open();
            ad.Fill(ds);
            con.Close();

            return ds.Tables[0];
        }

     


    }
}
