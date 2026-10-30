using bt_30_10_5._4.DTO;
using System.Data.SqlClient;

namespace bt_30_10_5._4.DAL
{
    public class KhachHangDAL
    {
        
        public KhachHangDTO GetKhachHangByCCCD(string cccd)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM KhachHang WHERE CCCD = @CCCD";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@CCCD", cccd));

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new KhachHangDTO
                    {
                        MaKH = (int)reader["MaKH"],
                        HoTen = reader["HoTen"].ToString(),
                        CCCD = reader["CCCD"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString()
                    };
                }
                return null;
            }
        }

        public int InsertKhachHang(KhachHangDTO kh)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"INSERT INTO KhachHang (HoTen, CCCD, SoDienThoai) 
                                 VALUES (@HoTen, @CCCD, @SoDienThoai); 
                                 SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HoTen", kh.HoTen);
                cmd.Parameters.AddWithValue("@CCCD", kh.CCCD);
                cmd.Parameters.AddWithValue("@SoDienThoai", kh.SoDienThoai ?? (object)System.DBNull.Value);

                conn.Open();
                return System.Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
