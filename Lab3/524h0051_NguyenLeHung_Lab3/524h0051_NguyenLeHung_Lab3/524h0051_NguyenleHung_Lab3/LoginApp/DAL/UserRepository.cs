using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class UserRepository
    {
        private readonly string connectionString;

        public UserRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LoginDBConnectionString"].ConnectionString;
        }

        public bool CheckLogin(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT COUNT(1)
                                 FROM tblUsers
                                 WHERE Username = @Username
                                 AND Password = @Password";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count == 1;
            }
        }
    }
}