using System.Data;
using System.Data.SqlClient;

namespace bt_30_10_5._4.DAL
{
    public class SuDungDichVuDAL
    {
        public DataTable GetAllDichVu()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT MaDV, TenDV, DonGia FROM DichVu ORDER BY TenDV", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public bool OrderDichVu(int maPhieu, int maDV, int soLuong)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"IF NOT EXISTS (SELECT 1 FROM DichVu WHERE MaDV = @MaDV)
                                    THROW 50001, 'Dịch vụ không tồn tại.', 1;

                                 INSERT INTO SuDungDichVu (MaPhieu, MaDV, SoLuong, ThoiGian)
                                 VALUES (@MaPhieu, @MaDV, @SoLuong, GETDATE())";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@MaPhieu", SqlDbType.Int).Value = maPhieu;
                cmd.Parameters.Add("@MaDV", SqlDbType.Int).Value = maDV;
                cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = soLuong;

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
