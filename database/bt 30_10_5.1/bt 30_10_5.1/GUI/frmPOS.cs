using bt_30_10_5._1.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace bt_30_10_5._1.GUI
{
    public partial class frmPOS : Form
    {
        private int maBanDangChon = -1;
        private int maHoaDonHienTai = -1;
        private DataTable dtChiTietHD;
        private SqlDataAdapter adapter;

        public frmPOS()
        {
            InitializeComponent();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            LoadSoDoBan();
            LoadDanhMuc();
        }

        // 1. TẢI SƠ ĐỒ BÀN DẠNG BUTTON ĐỘNG
        private void LoadSoDoBan()
        {
            flpBanAn.Controls.Clear();
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM BanAn";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int maBan = Convert.ToInt32(reader["MaBan"]);
                    string tenBan = reader["TenBan"].ToString();
                    string trangThai = reader["TrangThai"].ToString();

                    Button btn = new Button
                    {
                        Width = 100,
                        Height = 80,
                        Text = $"{tenBan}\n({trangThai})",
                        Tag = maBan,
                        Font = new Font("Arial", 9, FontStyle.Bold)
                    };

                    // Màu sắc theo trạng thái bàn
                    if (trangThai == "Trống")
                    {
                        btn.BackColor = Color.LightGreen;
                        btn.ForeColor = Color.Black;
                    }
                    else
                    {
                        btn.BackColor = Color.LightCoral;
                        btn.ForeColor = Color.White;
                    }

                    btn.Click += BtnBanAn_Click;
                    flpBanAn.Controls.Add(btn);
                }
            }
        }

        // 2. SỰ KIỆN CHỌN BÀN
        private void BtnBanAn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            maBanDangChon = (int)btn.Tag;
            lblTenBanDangChon.Text = btn.Text.Split('\n')[0];

            LoadHoaDonCuaBan(maBanDangChon);
        }

        // 3. NẠP HÓA ĐƠN TẠM BẰNG MODEL NGẮT KẾT NỐI (DataTable + SqlDataAdapter)
        private void LoadHoaDonCuaBan(int maBan)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                // Lấy Mã Hóa Đơn chưa thanh toán của bàn
                string getHDQuery = "SELECT MaHoaDon FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = 0";
                SqlCommand cmdHD = new SqlCommand(getHDQuery, conn);
                cmdHD.Parameters.AddWithValue("@MaBan", maBan);

                object result = cmdHD.ExecuteScalar();
                maHoaDonHienTai = result != null ? Convert.ToInt32(result) : -1;

                if (maHoaDonHienTai != -1)
                {
                    string query = @"SELECT m.TenMon, c.SoLuong, c.DonGia, (c.SoLuong * c.DonGia) AS ThanhTien 
                                     FROM ChiTietHoaDon c 
                                     JOIN MonAn m ON c.MaMon = m.MaMon 
                                     WHERE c.MaHoaDon = @MaHD";

                    adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@MaHD", maHoaDonHienTai);
                    dtChiTietHD = new DataTable();
                    adapter.Fill(dtChiTietHD);

                    dgvHoaDon.DataSource = dtChiTietHD;
                    TinhTongTien();
                }
                else
                {
                    dgvHoaDon.DataSource = null;
                    lblTongTien.Text = "0 VNĐ";
                }
            }
        }

        // 4. CHỨC NĂNG THÊM MÓN VÀO HÓA ĐƠN
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (maBanDangChon == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi gọi món!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboMonAn.SelectedValue == null) return;

            int maMon = Convert.ToInt32(cboMonAn.SelectedValue);
            int soLuong = (int)nudSoLuong.Value;

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // Nếu chưa có hóa đơn chưa thanh toán -> Tạo hóa đơn mới
                if (maHoaDonHienTai == -1)
                {
                    string insertHD = "INSERT INTO HoaDon (MaBan, GioVao, TrangThai) VALUES (@MaBan, GETDATE(), 0); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdInsertHD = new SqlCommand(insertHD, conn);
                    cmdInsertHD.Parameters.AddWithValue("@MaBan", maBanDangChon);
                    maHoaDonHienTai = Convert.ToInt32(cmdInsertHD.ExecuteScalar());

                    // Cập nhật trạng thái bàn sang "Có khách"
                    string updateBan = "UPDATE BanAn SET TrangThai = N'Có khách' WHERE MaBan = @MaBan";
                    SqlCommand cmdUpdateBan = new SqlCommand(updateBan, conn);
                    cmdUpdateBan.Parameters.AddWithValue("@MaBan", maBanDangChon);
                    cmdUpdateBan.ExecuteNonQuery();
                }

                // Lấy đơn giá món ăn
                string getGiaQuery = "SELECT DonGia FROM MonAn WHERE MaMon = @MaMon";
                SqlCommand cmdGia = new SqlCommand(getGiaQuery, conn);
                cmdGia.Parameters.AddWithValue("@MaMon", maMon);
                decimal donGia = Convert.ToDecimal(cmdGia.ExecuteScalar());

                // Thêm hoặc Cập nhật ChiTietHoaDon
                string insertCTHD = @"
                    IF EXISTS (SELECT * FROM ChiTietHoaDon WHERE MaHoaDon = @MaHD AND MaMon = @MaMon)
                        UPDATE ChiTietHoaDon SET SoLuong = SoLuong + @SoLuong WHERE MaHoaDon = @MaHD AND MaMon = @MaMon
                    ELSE
                        INSERT INTO ChiTietHoaDon (MaHoaDon, MaMon, SoLuong, DonGia) VALUES (@MaHD, @MaMon, @SoLuong, @DonGia)";

                SqlCommand cmdCTHD = new SqlCommand(insertCTHD, conn);
                cmdCTHD.Parameters.AddWithValue("@MaHD", maHoaDonHienTai);
                cmdCTHD.Parameters.AddWithValue("@MaMon", maMon);
                cmdCTHD.Parameters.AddWithValue("@SoLuong", soLuong);
                cmdCTHD.Parameters.AddWithValue("@DonGia", donGia);
                cmdCTHD.ExecuteNonQuery();
            }

            LoadSoDoBan();
            LoadHoaDonCuaBan(maBanDangChon);
        }

        // 5. CHỨC NĂNG THANH TOÁN DÙNG SqlTransaction
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (maHoaDonHienTai == -1)
            {
                MessageBox.Show("Bàn này hiện chưa có hóa đơn để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal tongTien = TinhTongTien();

            if (MessageBox.Show($"Xác nhận thanh toán cho {lblTenBanDangChon.Text}?\nTổng tiền: {tongTien:N0} VNĐ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    SqlTransaction tran = conn.BeginTransaction();

                    try
                    {
                        // Update 1: Cập nhật Hóa Đơn (Thanh toán xong, lưu giờ ra, tổng tiền)
                        string updateHD = @"UPDATE HoaDon 
                                            SET GioRa = GETDATE(), TongTien = @TongTien, TrangThai = 1 
                                            WHERE MaHoaDon = @MaHD";
                        SqlCommand cmdHD = new SqlCommand(updateHD, conn, tran);
                        cmdHD.Parameters.AddWithValue("@TongTien", tongTien);
                        cmdHD.Parameters.AddWithValue("@MaHD", maHoaDonHienTai);
                        cmdHD.ExecuteNonQuery();

                        // Update 2: Cập nhật Trạng thái Bàn về "Trống"
                        string updateBan = "UPDATE BanAn SET TrangThai = N'Trống' WHERE MaBan = @MaBan";
                        SqlCommand cmdBan = new SqlCommand(updateBan, conn, tran);
                        cmdBan.Parameters.AddWithValue("@MaBan", maBanDangChon);
                        cmdBan.ExecuteNonQuery();

                        // Commit Transaction nếu không có lỗi
                        tran.Commit();

                        MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        maHoaDonHienTai = -1;
                        LoadSoDoBan();
                        LoadHoaDonCuaBan(maBanDangChon);
                    }
                    catch (Exception ex)
                    {
                        // Rollback nếu phát sinh lỗi
                        tran.Rollback();
                        MessageBox.Show("Lỗi trong quá trình thanh toán: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // HÀM HỖ TRỢ
        private decimal TinhTongTien()
        {
            decimal tong = 0;
            if (dtChiTietHD != null)
            {
                foreach (DataRow row in dtChiTietHD.Rows)
                {
                    tong += Convert.ToDecimal(row["ThanhTien"]);
                }
            }
            lblTongTien.Text = $"{tong:N0} VNĐ";
            return tong;
        }

        private void LoadDanhMuc()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM DanhMuc";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboDanhMuc.DataSource = dt;
                cboDanhMuc.DisplayMember = "TenDanhMuc";
                cboDanhMuc.ValueMember = "MaDanhMuc";
            }
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDanhMuc.SelectedValue == null || !(cboDanhMuc.SelectedValue is int)) return;

            int maDanhMuc = (int)cboDanhMuc.SelectedValue;
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM MonAn WHERE MaDanhMuc = @MaDanhMuc";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboMonAn.DataSource = dt;
                cboMonAn.DisplayMember = "TenMon";
                cboMonAn.ValueMember = "MaMon";
            }
        }
    }
}
