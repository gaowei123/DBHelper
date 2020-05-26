using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace DBHelper
{
    public class HelperFactory
    {
        private static string nameSpace = "DBHelper.Helper";
        private static string dbName = ConfigurationManager.AppSettings["DBName"];
        
        public static IHelper GetHelper()
        {


            //命名空间.类型名
            string fullName = nameSpace + "." + dbName + "Helper";




            //加载程序集，创建程序集里面的 命名空间.类型名 实例
            object obj = Assembly.GetExecutingAssembly().CreateInstance(fullName, true, System.Reflection.BindingFlags.Default, null, null, null, null);



            //类型转换
            IHelper helper = (IHelper)obj;


            return helper;
        }

    }
}
