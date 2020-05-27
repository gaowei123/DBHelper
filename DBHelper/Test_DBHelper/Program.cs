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
            string str = "select * from user_db where 1= 1 and user_id= @userid";

            SqlParameter[] para = {
                new SqlParameter("@userid", SqlDbType.VarChar, 50)
            };

            para[0].Value = "LS001";




            DataTable dt = DBHelper.Helper.GetTable(str, para);


            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    Console.WriteLine(dr[i]);
                }
            }


            Console.ReadKey();
        }
    }
}
