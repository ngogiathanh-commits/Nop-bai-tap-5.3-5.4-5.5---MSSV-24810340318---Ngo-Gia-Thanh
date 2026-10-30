using System.Data;
using System.Data.SqlClient;

namespace bt_30_10_5._4.DAL
{
    public class PhongDAL
    {
        
        public DataTable GetAllPhong()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Phong";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public bool UpdateTrangThai(string soPhong, string trangThai)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Phong SET TrangThai = @TrangThai WHERE SoPhong = @SoPhong";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@SoPhong", soPhong);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
