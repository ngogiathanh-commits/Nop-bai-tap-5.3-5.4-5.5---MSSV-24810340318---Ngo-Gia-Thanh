using bt_30_10_5._1.BUS;
using System;
using System.Windows.Forms;

namespace bt_30_10_5._1.GUI
{
    public partial class frmMenuManagement : Form
    {
        private MonAnBUS bus = new MonAnBUS();
        private int selectedMaMon = -1;

        public frmMenuManagement()
        {
            InitializeComponent();
        }

        private void frmMenuManagement_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvMonAn.DataSource = bus.GetAllMonAn();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenMon = txtTenMon.Text;
            int maDanhMuc = Convert.ToInt32(cboDanhMuc.SelectedValue);
            decimal donGia = nudDonGia.Value;

            if (bus.ThemMonAn(tenMon, maDanhMuc, donGia, out string error))
            {
                MessageBox.Show("Thêm món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show(error, "Lỗi Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedMaMon == -1)
            {
                MessageBox.Show("Vui lòng chọn món cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenMon = txtTenMon.Text;
            int maDanhMuc = Convert.ToInt32(cboDanhMuc.SelectedValue);
            decimal donGia = nudDonGia.Value;

            if (bus.SuaMonAn(selectedMaMon, tenMon, maDanhMuc, donGia, out string error))
            {
                MessageBox.Show("Cập nhật món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show(error, "Lỗi Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedMaMon == -1) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa món này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bus.XoaMonAn(selectedMaMon))
                {
                    MessageBox.Show("Xóa món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }

        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMonAn.Rows[e.RowIndex];
                selectedMaMon = Convert.ToInt32(row.Cells["MaMon"].Value);
                txtTenMon.Text = row.Cells["TenMon"].Value.ToString();
                cboDanhMuc.SelectedValue = row.Cells["MaDanhMuc"].Value;
                nudDonGia.Value = Convert.ToDecimal(row.Cells["DonGia"].Value);
            }
        }
    }
}
