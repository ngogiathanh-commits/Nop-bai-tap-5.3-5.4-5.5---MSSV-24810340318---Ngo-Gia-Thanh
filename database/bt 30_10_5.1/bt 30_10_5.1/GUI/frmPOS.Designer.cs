namespace bt_30_10_5._1.GUI
{
    partial class frmPOS
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flpBanAn;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.ComboBox cboMonAn;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Label lblTenBanDangChon;
        private System.Windows.Forms.Label lblTongTien;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            flpBanAn = new System.Windows.Forms.FlowLayoutPanel();
            cboDanhMuc = new System.Windows.Forms.ComboBox();
            cboMonAn = new System.Windows.Forms.ComboBox();
            nudSoLuong = new System.Windows.Forms.NumericUpDown();
            btnThemMon = new System.Windows.Forms.Button();
            btnThanhToan = new System.Windows.Forms.Button();
            dgvHoaDon = new System.Windows.Forms.DataGridView();
            lblTenBanDangChon = new System.Windows.Forms.Label();
            lblTongTien = new System.Windows.Forms.Label();
            var labelDanhMuc = new System.Windows.Forms.Label();
            var labelMonAn = new System.Windows.Forms.Label();
            var labelTongTien = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            SuspendLayout();

            flpBanAn.AutoScroll = true;
            flpBanAn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            flpBanAn.Location = new System.Drawing.Point(12, 12);
            flpBanAn.Name = "flpBanAn";
            flpBanAn.Size = new System.Drawing.Size(430, 480);

            labelDanhMuc.AutoSize = true;
            labelDanhMuc.Location = new System.Drawing.Point(455, 15);
            labelDanhMuc.Text = "Danh mục:";
            cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboDanhMuc.Location = new System.Drawing.Point(530, 12);
            cboDanhMuc.Size = new System.Drawing.Size(200, 21);
            cboDanhMuc.SelectedIndexChanged += cboDanhMuc_SelectedIndexChanged;

            labelMonAn.AutoSize = true;
            labelMonAn.Location = new System.Drawing.Point(455, 43);
            labelMonAn.Text = "Món ăn:";
            cboMonAn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboMonAn.Location = new System.Drawing.Point(530, 40);
            cboMonAn.Size = new System.Drawing.Size(200, 21);

            nudSoLuong.Location = new System.Drawing.Point(740, 41);
            nudSoLuong.Minimum = 1;
            nudSoLuong.Value = 1;
            nudSoLuong.Size = new System.Drawing.Size(60, 20);

            btnThemMon.Location = new System.Drawing.Point(740, 10);
            btnThemMon.Size = new System.Drawing.Size(80, 25);
            btnThemMon.Text = "Thêm món";
            btnThemMon.Click += btnThemMon_Click;

            btnThanhToan.BackColor = System.Drawing.Color.LightSkyBlue;
            btnThanhToan.Location = new System.Drawing.Point(720, 440);
            btnThanhToan.Size = new System.Drawing.Size(100, 52);
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.Click += btnThanhToan_Click;

            lblTenBanDangChon.AutoSize = true;
            lblTenBanDangChon.Location = new System.Drawing.Point(452, 75);
            lblTenBanDangChon.Text = "Chưa chọn bàn";
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.Location = new System.Drawing.Point(455, 100);
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.Size = new System.Drawing.Size(365, 330);

            labelTongTien.AutoSize = true;
            labelTongTien.Location = new System.Drawing.Point(455, 457);
            labelTongTien.Text = "Tổng tiền:";
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new System.Drawing.Point(540, 455);
            lblTongTien.Text = "0 VNĐ";

            ClientSize = new System.Drawing.Size(834, 506);
            Controls.Add(labelTongTien);
            Controls.Add(lblTongTien);
            Controls.Add(lblTenBanDangChon);
            Controls.Add(dgvHoaDon);
            Controls.Add(btnThanhToan);
            Controls.Add(btnThemMon);
            Controls.Add(nudSoLuong);
            Controls.Add(cboMonAn);
            Controls.Add(labelMonAn);
            Controls.Add(cboDanhMuc);
            Controls.Add(labelDanhMuc);
            Controls.Add(flpBanAn);
            Name = "frmPOS";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản Lý Quán Cafe - POS";
            Load += frmPOS_Load;
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
