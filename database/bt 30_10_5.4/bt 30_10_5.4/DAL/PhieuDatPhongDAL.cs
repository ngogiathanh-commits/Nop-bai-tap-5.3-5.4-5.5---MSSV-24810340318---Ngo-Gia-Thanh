using bt_30_10_5._4.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace bt_30_10_5._4.DAL
{
    public class PhieuDatPhongDAL
    {
        public bool CheckIn(string soPhong, int maKH)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    
                    string insertPhieu = @"INSERT INTO PhieuDatPhong (SoPhong, MaKH, NgayNhanPhong) 
                                           VALUES (@SoPhong, @MaKH, GETDATE())";
                    SqlCommand cmdPhieu = new SqlCommand(insertPhieu, conn, tran);
                    cmdPhieu.Parameters.AddWithValue("@SoPhong", soPhong);
                    cmdPhieu.Parameters.AddWithValue("@MaKH", maKH);
                    cmdPhieu.ExecuteNonQuery();

                    
                    string updatePhong = "UPDATE Phong SET TrangThai = N'Đang ở' WHERE SoPhong = @SoPhong";
                    SqlCommand cmdPhong = new SqlCommand(updatePhong, conn, tran);
                    cmdPhong.Parameters.AddWithValue("@SoPhong", soPhong);
                    cmdPhong.ExecuteNonQuery();

                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
        }

        public PhieuDatPhongDTO GetPhieuActiveBySoPhong(string soPhong)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM PhieuDatPhong WHERE SoPhong = @SoPhong AND NgayTraPhong IS NULL";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoPhong", soPhong);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new PhieuDatPhongDTO
                    {
                        MaPhieu = (int)reader["MaPhieu"],
                        SoPhong = reader["SoPhong"].ToString(),
                        MaKH = (int)reader["MaKH"],
                        NgayNhanPhong = Convert.ToDateTime(reader["NgayNhanPhong"])
                    };
                }
                return null;
            }
        }

        
        public bool CheckOutWithTransaction(int maPhieu, string soPhong, decimal tongTien)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    
                    string updatePhieu = @"UPDATE PhieuDatPhong 
                                           SET NgayTraPhong = GETDATE(), TongTienThanhToan = @TongTien 
                                           WHERE MaPhieu = @MaPhieu";
                    SqlCommand cmdPhieu = new SqlCommand(updatePhieu, conn, tran);
                    cmdPhieu.Parameters.AddWithValue("@TongTien", tongTien);
                    cmdPhieu.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmdPhieu.ExecuteNonQuery();

                    
                    string updatePhong = "UPDATE Phong SET TrangThai = N'Đang dọn dẹp' WHERE SoPhong = @SoPhong";
                    SqlCommand cmdPhong = new SqlCommand(updatePhong, conn, tran);
                    cmdPhong.Parameters.AddWithValue("@SoPhong", soPhong);
                    cmdPhong.ExecuteNonQuery();

                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
        }
    }
}
