using System.Data.SqlClient;

namespace bt_30_10_5._5.DAL
{
    public class DatabaseConnection
    {
        private static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLIM;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
