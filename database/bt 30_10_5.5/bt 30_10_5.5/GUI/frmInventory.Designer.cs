namespace bt_30_10_5._5.GUI
{
    partial class frmInventory
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpKho = new System.Windows.Forms.GroupBox();
            this.btnTatCa = new System.Windows.Forms.Button();
            this.nudNguongTon = new System.Windows.Forms.NumericUpDown();
            this.btnCanhBaoTon = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgvVatTu = new System.Windows.Forms.DataGridView();
            this.lblTongGiaTriKho = new System.Windows.Forms.Label();
            this.grpPhieu = new System.Windows.Forms.GroupBox();
            this.lblTongTienPhieu = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnLuuPhieu = new System.Windows.Forms.Button();
            this.dgvChiTietPhieu = new System.Windows.Forms.DataGridView();
            this.btnThemChiTiet = new System.Windows.Forms.Button();
            this.nudDonGia = new System.Windows.Forms.NumericUpDown();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.cboVatTu = new System.Windows.Forms.ComboBox();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.cboLoaiPhieu = new System.Windows.Forms.ComboBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblVatTu = new System.Windows.Forms.Label();
            this.lblNCC = new System.Windows.Forms.Label();
            this.lblLoaiPhieu = new System.Windows.Forms.Label();
            this.grpKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNguongTon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVatTu)).BeginInit();
            this.grpPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // grpKho
            // 
            this.grpKho.Controls.Add(this.btnTatCa);
            this.grpKho.Controls.Add(this.nudNguongTon);
            this.grpKho.Controls.Add(this.btnCanhBaoTon);
            this.grpKho.Controls.Add(this.btnTimKiem);
            this.grpKho.Controls.Add(this.txtTimKiem);
            this.grpKho.Controls.Add(this.dgvVatTu);
            this.grpKho.Controls.Add(this.lblTongGiaTriKho);
            this.grpKho.Location = new System.Drawing.Point(12, 12);
            this.grpKho.Name = "grpKho";
            this.grpKho.Size = new System.Drawing.Size(430, 510);
            this.grpKho.TabIndex = 0;
            this.grpKho.TabStop = false;
            this.grpKho.Text = "Danh Sách Vật Tư Tồn Kho";
            // 
            // btnTatCa
            // 
            this.btnTatCa.Location = new System.Drawing.Point(365, 20);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(55, 23);
            this.btnTatCa.TabIndex = 6;
            this.btnTatCa.Text = "Tất cả";
            this.btnTatCa.UseVisualStyleBackColor = true;
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
            // 
            // nudNguongTon
            // 
            this.nudNguongTon.Location = new System.Drawing.Point(235, 22);
            this.nudNguongTon.Name = "nudNguongTon";
            this.nudNguongTon.Size = new System.Drawing.Size(45, 20);
            this.nudNguongTon.TabIndex = 5;
            this.nudNguongTon.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnCanhBaoTon
            // 
            this.btnCanhBaoTon.BackColor = System.Drawing.Color.MistyRose;
            this.btnCanhBaoTon.Location = new System.Drawing.Point(285, 20);
            this.btnCanhBaoTon.Name = "btnCanhBaoTon";
            this.btnCanhBaoTon.Size = new System.Drawing.Size(75, 23);
            this.btnCanhBaoTon.TabIndex = 4;
            this.btnCanhBaoTon.Text = "Tồn thấp";
            this.btnCanhBaoTon.UseVisualStyleBackColor = false;
            this.btnCanhBaoTon.Click += new System.EventHandler(this.btnCanhBaoTon_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(165, 20);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(60, 23);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(10, 22);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(150, 20);
            this.txtTimKiem.TabIndex = 2;
            // 
            // dgvVatTu
            // 
            this.dgvVatTu.AllowUserToAddRows = false;
            this.dgvVatTu.AllowUserToDeleteRows = false;
            this.dgvVatTu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVatTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVatTu.Location = new System.Drawing.Point(10, 50);
            this.dgvVatTu.Name = "dgvVatTu";
            this.dgvVatTu.ReadOnly = true;
            this.dgvVatTu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVatTu.Size = new System.Drawing.Size(410, 420);
            this.dgvVatTu.TabIndex = 1;
            // 
            // lblTongGiaTriKho
            // 
            this.lblTongGiaTriKho.AutoSize = true;
            this.lblTongGiaTriKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongGiaTriKho.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTongGiaTriKho.Location = new System.Drawing.Point(10, 480);
            this.lblTongGiaTriKho.Name = "lblTongGiaTriKho";
            this.lblTongGiaTriKho.Size = new System.Drawing.Size(163, 15);
            this.lblTongGiaTriKho.TabIndex = 0;
            this.lblTongGiaTriKho.Text = "Tổng số lượng tồn kho: 0";
            // 
            // grpPhieu
            // 
            this.grpPhieu.Controls.Add(this.lblTongTienPhieu);
            this.grpPhieu.Controls.Add(this.lblTongTien);
            this.grpPhieu.Controls.Add(this.btnLuuPhieu);
            this.grpPhieu.Controls.Add(this.dgvChiTietPhieu);
            this.grpPhieu.Controls.Add(this.btnThemChiTiet);
            this.grpPhieu.Controls.Add(this.nudDonGia);
            this.grpPhieu.Controls.Add(this.nudSoLuong);
            this.grpPhieu.Controls.Add(this.cboVatTu);
            this.grpPhieu.Controls.Add(this.cboNhaCungCap);
            this.grpPhieu.Controls.Add(this.cboLoaiPhieu);
            this.grpPhieu.Controls.Add(this.lblDonGia);
            this.grpPhieu.Controls.Add(this.lblSoLuong);
            this.grpPhieu.Controls.Add(this.lblVatTu);
            this.grpPhieu.Controls.Add(this.lblNCC);
            this.grpPhieu.Controls.Add(this.lblLoaiPhieu);
            this.grpPhieu.Location = new System.Drawing.Point(450, 12);
            this.grpPhieu.Name = "grpPhieu";
            this.grpPhieu.Size = new System.Drawing.Size(420, 510);
            this.grpPhieu.TabIndex = 1;
            this.grpPhieu.TabStop = false;
            this.grpPhieu.Text = "Lập Phiếu Nhập / Xuất Kho (SqlTransaction)";
            // 
            // lblTongTienPhieu
            // 
            this.lblTongTienPhieu.AutoSize = true;
            this.lblTongTienPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienPhieu.ForeColor = System.Drawing.Color.Red;
            this.lblTongTienPhieu.Location = new System.Drawing.Point(100, 477);
            this.lblTongTienPhieu.Name = "lblTongTienPhieu";
            this.lblTongTienPhieu.Size = new System.Drawing.Size(58, 18);
            this.lblTongTienPhieu.TabIndex = 14;
            this.lblTongTienPhieu.Text = "0 VNĐ";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(15, 478);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(71, 15);
            this.lblTongTien.TabIndex = 13;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // btnLuuPhieu
            // 
            this.btnLuuPhieu.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLuuPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuPhieu.Location = new System.Drawing.Point(280, 468);
            this.btnLuuPhieu.Name = "btnLuuPhieu";
            this.btnLuuPhieu.Size = new System.Drawing.Size(125, 35);
            this.btnLuuPhieu.TabIndex = 12;
            this.btnLuuPhieu.Text = "Lưu Phiếu Kho";
            this.btnLuuPhieu.UseVisualStyleBackColor = false;
            this.btnLuuPhieu.Click += new System.EventHandler(this.btnLuuPhieu_Click);
            // 
            // dgvChiTietPhieu
            // 
            this.dgvChiTietPhieu.AllowUserToAddRows = false;
            this.dgvChiTietPhieu.AllowUserToDeleteRows = false;
            this.dgvChiTietPhieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietPhieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhieu.Location = new System.Drawing.Point(15, 185);
            this.dgvChiTietPhieu.Name = "dgvChiTietPhieu";
            this.dgvChiTietPhieu.ReadOnly = true;
            this.dgvChiTietPhieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietPhieu.Size = new System.Drawing.Size(390, 270);
            this.dgvChiTietPhieu.TabIndex = 11;
            // 
            // btnThemChiTiet
            // 
            this.btnThemChiTiet.Location = new System.Drawing.Point(300, 148);
            this.btnThemChiTiet.Name = "btnThemChiTiet";
            this.btnThemChiTiet.Size = new System.Drawing.Size(105, 25);
            this.btnThemChiTiet.TabIndex = 10;
            this.btnThemChiTiet.Text = "Thêm vào phiếu";
            this.btnThemChiTiet.UseVisualStyleBackColor = true;
            this.btnThemChiTiet.Click += new System.EventHandler(this.btnThemChiTiet_Click);
            // 
            // nudDonGia
            // 
            this.nudDonGia.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.nudDonGia.Location = new System.Drawing.Point(100, 150);
            this.nudDonGia.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.nudDonGia.Name = "nudDonGia";
            this.nudDonGia.Size = new System.Drawing.Size(180, 20);
            this.nudDonGia.TabIndex = 9;
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.DecimalPlaces = 2;
            this.nudSoLuong.Location = new System.Drawing.Point(100, 120);
            this.nudSoLuong.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(180, 20);
            this.nudSoLuong.TabIndex = 8;
            this.nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cboVatTu
            // 
            this.cboVatTu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVatTu.FormattingEnabled = true;
            this.cboVatTu.Location = new System.Drawing.Point(100, 90);
            this.cboVatTu.Name = "cboVatTu";
            this.cboVatTu.Size = new System.Drawing.Size(305, 21);
            this.cboVatTu.TabIndex = 7;
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(100, 58);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(305, 21);
            this.cboNhaCungCap.TabIndex = 6;
            // 
            // cboLoaiPhieu
            // 
            this.cboLoaiPhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiPhieu.FormattingEnabled = true;
            this.cboLoaiPhieu.Items.AddRange(new object[] {
            "Phiếu Nhập",
            "Phiếu Xuất"});
            this.cboLoaiPhieu.Location = new System.Drawing.Point(100, 25);
            this.cboLoaiPhieu.Name = "cboLoaiPhieu";
            this.cboLoaiPhieu.Size = new System.Drawing.Size(180, 21);
            this.cboLoaiPhieu.TabIndex = 5;
            this.cboLoaiPhieu.SelectedIndexChanged += new System.EventHandler(this.cboLoaiPhieu_SelectedIndexChanged);
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(15, 153);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(47, 13);
            this.lblDonGia.TabIndex = 4;
            this.lblDonGia.Text = "Đơn giá:";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(15, 122);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(52, 13);
            this.lblSoLuong.TabIndex = 3;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // lblVatTu
            // 
            this.lblVatTu.AutoSize = true;
            this.lblVatTu.Location = new System.Drawing.Point(15, 93);
            this.lblVatTu.Name = "lblVatTu";
            this.lblVatTu.Size = new System.Drawing.Size(68, 13);
            this.lblVatTu.TabIndex = 2;
            this.lblVatTu.Text = "Chọn vật tư:";
            // 
            // lblNCC
            // 
            this.lblNCC.AutoSize = true;
            this.lblNCC.Location = new System.Drawing.Point(15, 61);
            this.lblNCC.Name = "lblNCC";
            this.lblNCC.Size = new System.Drawing.Size(78, 13);
            this.lblNCC.TabIndex = 1;
            this.lblNCC.Text = "Nhà cung cấp:";
            // 
            // lblLoaiPhieu
            // 
            this.lblLoaiPhieu.AutoSize = true;
            this.lblLoaiPhieu.Location = new System.Drawing.Point(15, 28);
            this.lblLoaiPhieu.Name = "lblLoaiPhieu";
            this.lblLoaiPhieu.Size = new System.Drawing.Size(59, 13);
            this.lblLoaiPhieu.TabIndex = 0;
            this.lblLoaiPhieu.Text = "Loại phiếu:";
            // 
            // frmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 534);
            this.Controls.Add(this.grpPhieu);
            this.Controls.Add(this.grpKho);
            this.Name = "frmInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý Xuất - Nhập Kho Nguyên Vật Liệu (Inventory Management)";
            this.Load += new System.EventHandler(this.frmInventory_Load);
            this.grpKho.ResumeLayout(false);
            this.grpKho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNguongTon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVatTu)).EndInit();
            this.grpPhieu.ResumeLayout(false);
            this.grpPhieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpKho;
        private System.Windows.Forms.DataGridView dgvVatTu;
        private System.Windows.Forms.Label lblTongGiaTriKho;
        private System.Windows.Forms.Button btnCanhBaoTon;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.NumericUpDown nudNguongTon;
        private System.Windows.Forms.Button btnTatCa;
        private System.Windows.Forms.GroupBox grpPhieu;
        private System.Windows.Forms.Label lblLoaiPhieu;
        private System.Windows.Forms.ComboBox cboLoaiPhieu;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.Label lblNCC;
        private System.Windows.Forms.Label lblVatTu;
        private System.Windows.Forms.ComboBox cboVatTu;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.NumericUpDown nudDonGia;
        private System.Windows.Forms.Button btnThemChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTietPhieu;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblTongTienPhieu;
    }
}
