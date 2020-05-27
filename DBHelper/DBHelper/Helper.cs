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


        public class TransactionParas
        {
            public string SQLString { get; set; }
            public DbParameter[] SQLParameters { get; set; }
        }


        public static DataTable GetTable(string strSql, DbParameter[] parameters)
        {
            DbConnection con = provider.CreateConnection();
          
            try
            {
                con.ConnectionString = strConnection;


                DbCommand com = provider.CreateCommand();
                com.Connection = con;
                com.CommandText = strSql;
                com.CommandType = CommandType.Text;


                if (parameters != null)
                {
                    foreach (DbParameter para in parameters)
                    {
                        if (para != null)
                            com.Parameters.Add(para);
                    }
                }



                DbDataAdapter ad = provider.CreateDataAdapter();
                ad.SelectCommand = com;
                con.Open();


                DataTable dt = new DataTable();
                ad.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

     
        public static DataSet GetDataSet(string strSql, DbParameter[] parameters)
        {
            DbConnection con = provider.CreateConnection();

            try
            {
                con.ConnectionString = strConnection;


                DbCommand com = provider.CreateCommand();
                com.Connection = con;
                com.CommandText = strSql;
                com.CommandType = CommandType.Text;


                if (parameters != null)
                {
                    foreach (DbParameter para in parameters)
                    {
                        if (para != null)
                            com.Parameters.Add(para);
                    }
                }



                DbDataAdapter ad = provider.CreateDataAdapter();
                ad.SelectCommand = com;
                con.Open();


                DataSet ds = new DataSet();
                ad.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            
        }
        

        public static int ExcuteSQL(string strSql, DbParameter[] pars)
        {
           DbConnection con = provider.CreateConnection();

            try
            {
                con.ConnectionString = strConnection;

                DbCommand com = provider.CreateCommand();
                com.Connection = con;
                com.CommandText = strSql;
                com.CommandType = CommandType.Text;

                if (pars!= null)
                {
                    foreach (DbParameter parameter in pars)
                    {
                        com.Parameters.Add(parameter);
                    }
                }

                con.Open();


                int result = com.ExecuteNonQuery();

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                
                con.Close();
            }
        }




        public static bool SetDataRollBack(List<TransactionParas> SqlParas)
        {
            DbConnection con = provider.CreateConnection();

            DbTransaction tran = null;

            bool result = true;

            try
            {
                con.ConnectionString = strConnection;
                tran = con.BeginTransaction();

                
                DbCommand com = provider.CreateCommand();
                com.Connection = con;
                com.Transaction = tran;
                com.CommandType = CommandType.Text;

                con.Open();

             
                foreach (TransactionParas item in SqlParas)
                {
                    com.CommandText = item.SQLString;


                    com.Parameters.Clear();
                    foreach (DbParameter para in item.SQLParameters)
                    {
                        if (para != null)
                            com.Parameters.Add(para);
                    }


                    int effectRow = com.ExecuteNonQuery();
                    if (effectRow < 0)
                    {
                        tran.Rollback();
                        result = false;
                        break;
                    }


                   
                }

                if (result)
                {
                    tran.Commit();
                }

     



                return result;

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                tran.Dispose();
                con.Close();
            }
        }

    }
}
