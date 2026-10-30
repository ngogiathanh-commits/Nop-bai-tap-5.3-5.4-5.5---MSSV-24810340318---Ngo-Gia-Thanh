using bt_30_10_5._4.DAL;
using bt_30_10_5._4.BUS;
using bt_30_10_5._4.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace bt_30_10_5._4.GUI
{
    public partial class frmMain : Form
    {
        private PhongBUS phongBUS = new PhongBUS();
        private KhachHangDAL khachHangDAL = new KhachHangDAL(); 
        private PhieuDatPhongDAL phieuDAL = new PhieuDatPhongDAL();
        private SuDungDichVuDAL dichVuDAL = new SuDungDichVuDAL();
        private DataTable dtPhong;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadDataPhong();
        }

        // Nạp và hiển thị danh sách phòng
        private void LoadDataPhong()
        {
            try
            {
                dtPhong = phongBUS.GetAllPhong();
                dgvPhong.DataSource = dtPhong;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể tải dữ liệu phòng. Hãy kiểm tra SQL Server, cơ sở dữ liệu QLHMS và chuỗi kết nối.\n\nChi tiết: {ex.Message}",
                    "Lỗi kết nối cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Lọc ngắt kết nối với DataView
        private void cboLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterPhongData();
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterPhongData();
        }

        private void FilterPhongData()
        {
            if (dtPhong == null) return;
            string loai = cboLoaiPhong.SelectedItem?.ToString();
            string trangThai = cboTrangThai.SelectedItem?.ToString();
            dgvPhong.DataSource = phongBUS.FilterPhong(dtPhong, loai, trangThai);
        }

        // 1. CHỨC NĂNG CHECK-IN
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            string soPhong = txtSoPhong.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if (string.IsNullOrEmpty(soPhong) || string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Vui lòng nhập Số phòng và CCCD!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tra cứu xem khách hàng đã từng ở chưa (dùng SqlParameter)
            KhachHangDTO kh = khachHangDAL.GetKhachHangByCCCD(cccd);
            int maKH;

            if (kh == null)
            {
                if (string.IsNullOrEmpty(hoTen))
                {
                    MessageBox.Show("Khách hàng mới! Vui lòng nhập thêm Họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Thêm khách hàng mới
                maKH = khachHangDAL.InsertKhachHang(new KhachHangDTO { HoTen = hoTen, CCCD = cccd, SoDienThoai = sdt });
            }
            else
            {
                maKH = kh.MaKH;
            }

            // Lập phiếu nhận phòng
            if (phieuDAL.CheckIn(soPhong, maKH))
            {
                MessageBox.Show("Check-in thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataPhong();
            }
            else
            {
                MessageBox.Show("Check-in thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. CHỨC NĂNG GỌI DỊCH VỤ
        private void btnGoiDichVu_Click(object sender, EventArgs e)
        {
            string soPhong = txtSoPhong.Text.Trim();
            PhieuDatPhongDTO phieu = phieuDAL.GetPhieuActiveBySoPhong(soPhong);

            if (phieu == null)
            {
                MessageBox.Show("Phòng hiện chưa có khách ở!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDV = Convert.ToInt32(cboDichVu.SelectedValue);
            int soLuong = (int)nudSoLuongDV.Value;

            if (dichVuDAL.OrderDichVu(phieu.MaPhieu, maDV, soLuong))
            {
                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDichVuDaDung(phieu.MaPhieu);
            }
        }

        // 3. CHỨC NĂNG CHECK-OUT & THANH TOÁN (Transaction)
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            string soPhong = txtSoPhong.Text.Trim();
            PhieuDatPhongDTO phieu = phieuDAL.GetPhieuActiveBySoPhong(soPhong);

            if (phieu == null)
            {
                MessageBox.Show("Phòng này chưa thể Check-out!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy giá phòng theo giờ
            decimal giaTheoGio = Convert.ToDecimal(dgvPhong.CurrentRow.Cells["GiaTheoGio"].Value);

            // Tính số giờ ở (Làm tròn lên tối thiểu 1 giờ)
            TimeSpan duration = DateTime.Now - phieu.NgayNhanPhong;
            double tongSoGio = Math.Max(1, Math.Ceiling(duration.TotalHours));
            decimal tienPhong = (decimal)tongSoGio * giaTheoGio;

            // Tính tiền dịch vụ
            DataTable dtDV = dichVuDAL.GetDichVuByPhieu(phieu.MaPhieu);
            decimal tienDichVu = 0;
            foreach (DataRow row in dtDV.Rows)
            {
                tienDichVu += Convert.ToDecimal(row["ThanhTien"]);
            }

            decimal tongThanhToan = tienPhong + tienDichVu;

            string thongBao = $"HÓA ĐƠN THANH TOÁN PHÒNG {soPhong}\n" +
                               $"Thời gian ở: {tongSoGio} giờ ({tienPhong:N0} VNĐ)\n" +
                               $"Tiền dịch vụ: {tienDichVu:N0} VNĐ\n" +
                               $"----------------------------------------\n" +
                               $"TỔNG CỘNG: {tongThanhToan:N0} VNĐ\n\n" +
                               $"Xác nhận thanh toán?";

            if (MessageBox.Show(thongBao, "Xác nhận Check-out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (phieuDAL.CheckOutWithTransaction(phieu.MaPhieu, soPhong, tongThanhToan))
                {
                    MessageBox.Show("Thanh toán thành công! Phòng chuyển sang trạng thái 'Đang dọn dẹp'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataPhong();
                }
                else
                {
                    MessageBox.Show("Lỗi trong quá trình thanh toán transaction!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadDichVuDaDung(int maPhieu)
        {
            dgvDichVuDaDung.DataSource = dichVuDAL.GetDichVuByPhieu(maPhieu);
        }
    }
}
