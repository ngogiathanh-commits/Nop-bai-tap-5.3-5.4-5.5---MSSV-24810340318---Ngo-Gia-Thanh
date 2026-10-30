using System.Data;
using System.Data.SqlClient;

namespace bt_30_10_5._4.DAL
{
    public class SuDungDichVuDAL
    {
        public bool OrderDichVu(int maPhieu, int maDV, int soLuong)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"INSERT INTO SuDungDichVu (MaPhieu, MaDV, SoLuong, ThoiGian) 
                                 VALUES (@MaPhieu, @MaDV, @SoLuong, GETDATE())";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                cmd.Parameters.AddWithValue("@MaDV", maDV);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable GetDichVuByPhieu(int maPhieu)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT d.TenDV, s.SoLuong, d.DonGia, (s.SoLuong * d.DonGia) AS ThanhTien, s.ThoiGian 
                                 FROM SuDungDichVu s 
                                 JOIN DichVu d ON s.MaDV = d.MaDV 
                                 WHERE s.MaPhieu = @MaPhieu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
