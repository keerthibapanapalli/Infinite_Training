using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ElectricityBill
{

    public class DBHandler
    {
        public SqlConnection GetConnection()
        {
            // Use the exact name from Web.config
            string cs = ConfigurationManager.ConnectionStrings["ElectricityDb"].ConnectionString;
            return new SqlConnection(cs);
        }
    }

}