using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace easyui.Database
{
    public class DaoConnection
    {
        public static SqlConnection getConnection()
        {
            String a = "Data Source =.; Initial Catalog = new_login; User ID = sa; Password=Xu1234567";
            SqlConnection sqlConnection = new SqlConnection(a);

            return sqlConnection;
        }
    }
}