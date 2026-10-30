using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using bt_30_10_5._5.BUS;
using bt_30_10_5._5.DAL;
using bt_30_10_5._5.DTO;

namespace bt_30_10_5._5.GUI
{
    public partial class frmInventory : Form
    {
        private VatTuBUS vatTuBUS = new VatTuBUS();
        private PhieuKhoBUS phieuKhoBUS = new PhieuKhoBUS();
        private NhaCungCapDAL nccDAL = new NhaCungCapDAL();
        private List<ChiTietPhieuKhoDTO> listChiTiet = new List<ChiTietPhieuKhoDTO>();

        public frmInventory()
        {
            InitializeComponent();
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            LoadDataVatTu();
            LoadNhaCungCap();
            LoadCboVatTu();
            cboLoaiPhieu.SelectedIndex = 0; 
            CapNhatTongGiaTriKho();
        }

        private void LoadDataVatTu()
        {
            dgvVatTu.DataSource = vatTuBUS.GetAllVatTu();
        }

        private void LoadNhaCungCap()
        {
            DataTable dt = nccDAL.GetAllNhaCungCap();
            cboNhaCungCap.DataSource = dt;
            cboNhaCungCap.DisplayMember = "TenNCC";
            cboNhaCungCap.ValueMember = "MaNCC";
        }

        private void LoadCboVatTu()
        {
            DataTable dt = vatTuBUS.GetAllVatTu();
            cboVatTu.DataSource = dt;
            cboVatTu.DisplayMember = "TenVatTu";
            cboVatTu.ValueMember = "MaVatTu";
        }

       
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text;
            dgvVatTu.DataSource = vatTuBUS.TimKiemVatTu(keyword);
        }

       
        private void btnCanhBaoTon_Click(object sender, EventArgs e)
        {
            decimal nguong = nudNguongTon.Value;
            dgvVatTu.DataSource = vatTuBUS.GetVatTuDuoiNguong(nguong);
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            LoadDataVatTu();
        }

        
        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (cboVatTu.SelectedValue == null) return;

            string maVT = cboVatTu.SelectedValue.ToString();
            string tenVT = cboVatTu.Text;
            decimal soLuong = nudSoLuong.Value;
            decimal donGia = nudDonGia.Value;

            var existing = listChiTiet.FirstOrDefault(x => x.MaVatTu == maVT);
            if (existing != null)
            {
                existing.SoLuong += soLuong;
                existing.DonGia = donGia;
            }
            else
            {
                listChiTiet.Add(new ChiTietPhieuKhoDTO
                {
                    MaVatTu = maVT,
                    TenVatTu = tenVT,
                    SoLuong = soLuong,
                    DonGia = donGia
                });
            }

            CapNhatGridChiTiet();
        }

        private void CapNhatGridChiTiet()
        {
            dgvChiTietPhieu.DataSource = null;
            dgvChiTietPhieu.DataSource = listChiTiet;

            decimal tongTien = listChiTiet.Sum(x => x.ThanhTien);
            lblTongTienPhieu.Text = $"{tongTien:N0} VNĐ";
        }

       
        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            string loaiPhieu = cboLoaiPhieu.SelectedItem.ToString() == "Phiếu Nhập" ? "NHAP" : "XUAT";
            int? maNCC = loaiPhieu == "NHAP" ? (int?)cboNhaCungCap.SelectedValue : null;
            decimal tongTien = listChiTiet.Sum(x => x.ThanhTien);

            PhieuKhoDTO phieu = new PhieuKhoDTO
            {
                LoaiPhieu = loaiPhieu,
                MaNCC = maNCC,
                TongTien = tongTien
            };

            if (phieuKhoBUS.LuuPhieuKho(phieu, listChiTiet, out string error))
            {
                MessageBox.Show("Lưu phiếu kho thành công và đã cập nhật tồn kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listChiTiet.Clear();
                CapNhatGridChiTiet();
                LoadDataVatTu();
                CapNhatGiaTriKho();
            }
            else
            {
                MessageBox.Show(error, "Lỗi SqlTransaction / Tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void CapNhatGiaTriKho()
        {
            decimal tongSoLuong = vatTuBUS.GetTongSoLuongTon();
            lblTongGiaTriKho.Text = $"Tổng số lượng tồn kho: {tongSoLuong:N2}";
        }

        private void cboLoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isNhap = cboLoaiPhieu.SelectedItem.ToString() == "Phiếu Nhập";
            cboNhaCungCap.Enabled = isNhap;
        }

        private void CapNhatTongGiaTriKho() => CapNhatGiaTriKho();
    }
}
