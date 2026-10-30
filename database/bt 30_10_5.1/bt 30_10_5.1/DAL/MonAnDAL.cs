using System.Data;
using System.Data.SqlClient;

namespace bt_30_10_5._1.DAL
{
    public class MonAnDAL
    {
        public DataTable GetAllMonAn()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT m.MaMon, m.TenMon, d.TenDanhMuc, m.DonGia, m.MaDanhMuc 
                                 FROM MonAn m JOIN DanhMuc d ON m.MaDanhMuc = d.MaDanhMuc";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public bool InsertMonAn(string tenMon, int maDanhMuc, decimal donGia)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia) VALUES (@TenMon, @MaDanhMuc, @DonGia)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenMon", tenMon);
                cmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);
                cmd.Parameters.AddWithValue("@DonGia", donGia);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateMonAn(int maMon, string tenMon, int maDanhMuc, decimal donGia)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE MonAn SET TenMon = @TenMon, MaDanhMuc = @MaDanhMuc, DonGia = @DonGia WHERE MaMon = @MaMon";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaMon", maMon);
                cmd.Parameters.AddWithValue("@TenMon", tenMon);
                cmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);
                cmd.Parameters.AddWithValue("@DonGia", donGia);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteMonAn(int maMon)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM MonAn WHERE MaMon = @MaMon";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaMon", maMon);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
