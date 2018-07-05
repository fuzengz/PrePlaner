using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace FusionPrePlaner
{
    class DBAccess
    {
        public static bool TestConn(string datasouce, string catalog, string userId, string password, out string expstr)
        {
            expstr = string.Empty;   
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            /*
            builder.DataSource = @"CV0010872N0\SQLEXPRESS";
            builder.InitialCatalog = "msdb";
            builder.UserID = "sa";
            builder.Password = "Password1$";
            */
            builder.DataSource = datasouce;
            builder.InitialCatalog = catalog;
            builder.UserID = userId;
            builder.Password = password;
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {  
                    connection.Open();
                    connection.Close();
                    return true;
                }
            }
            catch (SqlException exp)
            {
                expstr = exp.Message;
                return false;
            }
        }
    }
}
