using System.Data;
using System.Data.SqlClient;

namespace bt_30_10_5._5.DAL
{
    public class NhaCungCapDAL
    {
        public DataTable GetAllNhaCungCap()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM NhaCungCap";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
