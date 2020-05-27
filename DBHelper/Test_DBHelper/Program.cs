using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Test_DBHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            testGetTable();
            Console.ReadKey();
        }



        static void testGetTable()
        {
            string str = "select * from user_db where 1= 1 and user_id= @userid";

            SqlParameter[] parameters = {
                new SqlParameter("@userid", SqlDbType.VarChar, 50)
            };

            parameters[0].Value = "LS001";




            DataTable dt = DBHelper.Helper.GetTable(str, parameters);


            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    Console.WriteLine(dr[i]);
                }
            }
        }


        



    }
}
