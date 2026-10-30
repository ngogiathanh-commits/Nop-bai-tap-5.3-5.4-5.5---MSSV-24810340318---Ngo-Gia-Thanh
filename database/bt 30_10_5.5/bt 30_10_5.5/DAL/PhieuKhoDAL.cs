
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using bt_30_10_5._5.DTO;

namespace bt_30_10_5._5.DAL
{
    public class PhieuKhoDAL
    {
        
        public bool LuuPhieuKho(PhieuKhoDTO phieu, List<ChiTietPhieuKhoDTO> listChiTiet, out string errorMessage)
        {
            errorMessage = "";
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    
                    string sqlPhieu = @"INSERT INTO PhieuKho (LoaiPhieu, NgayLap, MaNCC, TongTien) 
                                       VALUES (@LoaiPhieu, GETDATE(), @MaNCC, @TongTien);
                                       SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdPhieu = new SqlCommand(sqlPhieu, conn, tran);
                    cmdPhieu.Parameters.AddWithValue("@LoaiPhieu", phieu.LoaiPhieu);
                    cmdPhieu.Parameters.AddWithValue("@MaNCC", (object)phieu.MaNCC ?? DBNull.Value);
                    cmdPhieu.Parameters.AddWithValue("@TongTien", phieu.TongTien);

                    int maPhieu = Convert.ToInt32(cmdPhieu.ExecuteScalar());

                    
                    foreach (var item in listChiTiet)
                    {
                        
                        if (phieu.LoaiPhieu == "XUAT")
                        {
                            string sqlCheckTon = "SELECT SoLuongTon FROM VatTu WHERE MaVatTu = @MaVatTu";
                            SqlCommand cmdCheck = new SqlCommand(sqlCheckTon, conn, tran);
                            cmdCheck.Parameters.AddWithValue("@MaVatTu", item.MaVatTu);

                            object tonObj = cmdCheck.ExecuteScalar();
                            decimal tonHienTai = tonObj != null ? Convert.ToDecimal(tonObj) : 0;

                            if (tonHienTai < item.SoLuong)
                            {
                                
                                tran.Rollback();
                                errorMessage = $"Không đủ hàng trong kho đối với mã '{item.MaVatTu}'! (Tồn: {tonHienTai}, Xuất: {item.SoLuong})";
                                return false;
                            }
                        }

                        
                        string sqlCT = @"INSERT INTO ChiTietPhieuKho (MaPhieu, MaVatTu, SoLuong, DonGia) 
                                         VALUES (@MaPhieu, @MaVatTu, @SoLuong, @DonGia)";
                        SqlCommand cmdCT = new SqlCommand(sqlCT, conn, tran);
                        cmdCT.Parameters.AddWithValue("@MaPhieu", maPhieu);
                        cmdCT.Parameters.AddWithValue("@MaVatTu", item.MaVatTu);
                        cmdCT.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                        cmdCT.Parameters.AddWithValue("@DonGia", item.DonGia);
                        cmdCT.ExecuteNonQuery();

                        
                        string sqlUpdateTon = phieu.LoaiPhieu == "NHAP"
                            ? "UPDATE VatTu SET SoLuongTon = SoLuongTon + @SoLuong WHERE MaVatTu = @MaVatTu"
                            : "UPDATE VatTu SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaVatTu = @MaVatTu";

                        SqlCommand cmdUpdate = new SqlCommand(sqlUpdateTon, conn, tran);
                        cmdUpdate.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                        cmdUpdate.Parameters.AddWithValue("@MaVatTu", item.MaVatTu);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    
                    tran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    errorMessage = "Lỗi hệ thống SQL Transaction: " + ex.Message;
                    return false;
                }
            }
        }
    }
}