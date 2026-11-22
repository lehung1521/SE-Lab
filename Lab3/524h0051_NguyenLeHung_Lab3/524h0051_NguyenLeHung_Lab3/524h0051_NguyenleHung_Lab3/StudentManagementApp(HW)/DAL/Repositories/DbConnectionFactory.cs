using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public static class DbConnectionFactory
    {
        public static SqlConnection CreateConnection()
        {
            string connectionString =  ConfigurationManager.ConnectionStrings["SchoolDBConnectionString"].ConnectionString;

            return new SqlConnection(connectionString);
        }
    }
}