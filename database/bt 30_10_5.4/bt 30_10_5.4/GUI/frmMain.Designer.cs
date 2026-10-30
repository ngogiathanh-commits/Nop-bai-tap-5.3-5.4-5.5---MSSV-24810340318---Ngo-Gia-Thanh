namespace bt_30_10_5._4.GUI
{
    partial class frmMain
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
            this.grpPhong = new System.Windows.Forms.GroupBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblLoaiPhong = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.cboLoaiPhong = new System.Windows.Forms.ComboBox();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.grpThaoTac = new System.Windows.Forms.GroupBox();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.txtSoPhong = new System.Windows.Forms.TextBox();
            this.lblSoPhong = new System.Windows.Forms.Label();
            this.grpDichVu = new System.Windows.Forms.GroupBox();
            this.dgvDichVuDaDung = new System.Windows.Forms.DataGridView();
            this.btnGoiDichVu = new System.Windows.Forms.Button();
            this.nudSoLuongDV = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.cboDichVu = new System.Windows.Forms.ComboBox();
            this.lblDichVu = new System.Windows.Forms.Label();
            this.grpPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.grpThaoTac.SuspendLayout();
            this.grpDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuDaDung)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPhong
            // 
            this.grpPhong.Controls.Add(this.lblTrangThai);
            this.grpPhong.Controls.Add(this.lblLoaiPhong);
            this.grpPhong.Controls.Add(this.cboTrangThai);
            this.grpPhong.Controls.Add(this.cboLoaiPhong);
            this.grpPhong.Controls.Add(this.dgvPhong);
            this.grpPhong.Location = new System.Drawing.Point(12, 12);
            this.grpPhong.Name = "grpPhong";
            this.grpPhong.Size = new System.Drawing.Size(460, 510);
            this.grpPhong.TabIndex = 0;
            this.grpPhong.TabStop = false;
            this.grpPhong.Text = "Danh Sách Phòng Khách Sạn";
            // 
            // dgvPhong
            // 
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.AllowUserToDeleteRows = false;
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhong.Location = new System.Drawing.Point(10, 60);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.Size = new System.Drawing.Size(440, 440);
            this.dgvPhong.TabIndex = 0;
            // 
            // cboLoaiPhong
            // 
            this.cboLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiPhong.FormattingEnabled = true;
            this.cboLoaiPhong.Items.AddRange(new object[] {
            "Tất cả",
            "Đơn",
            "Đôi",
            "VIP"});
            this.cboLoaiPhong.Location = new System.Drawing.Point(80, 25);
            this.cboLoaiPhong.Name = "cboLoaiPhong";
            this.cboLoaiPhong.Size = new System.Drawing.Size(130, 21);
            this.cboLoaiPhong.TabIndex = 1;
            this.cboLoaiPhong.SelectedIndexChanged += new System.EventHandler(this.cboLoaiPhong_SelectedIndexChanged);
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Trống",
            "Đang ở",
            "Đang dọn dẹp"});
            this.cboTrangThai.Location = new System.Drawing.Point(310, 25);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(140, 21);
            this.cboTrangThai.TabIndex = 2;
            this.cboTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboTrangThai_SelectedIndexChanged);
            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.AutoSize = true;
            this.lblLoaiPhong.Location = new System.Drawing.Point(10, 28);
            this.lblLoaiPhong.Name = "lblLoaiPhong";
            this.lblLoaiPhong.Size = new System.Drawing.Size(63, 13);
            this.lblLoaiPhong.TabIndex = 3;
            this.lblLoaiPhong.Text = "Loại phòng:";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(240, 28);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(58, 13);
            this.lblTrangThai.TabIndex = 4;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // grpThaoTac
            // 
            this.grpThaoTac.Controls.Add(this.btnCheckOut);
            this.grpThaoTac.Controls.Add(this.btnCheckIn);
            this.grpThaoTac.Controls.Add(this.txtSDT);
            this.grpThaoTac.Controls.Add(this.lblSDT);
            this.grpThaoTac.Controls.Add(this.txtHoTen);
            this.grpThaoTac.Controls.Add(this.lblHoTen);
            this.grpThaoTac.Controls.Add(this.txtCCCD);
            this.grpThaoTac.Controls.Add(this.lblCCCD);
            this.grpThaoTac.Controls.Add(this.txtSoPhong);
            this.grpThaoTac.Controls.Add(this.lblSoPhong);
            this.grpThaoTac.Location = new System.Drawing.Point(485, 12);
            this.grpThaoTac.Name = "grpThaoTac";
            this.grpThaoTac.Size = new System.Drawing.Size(387, 210);
            this.grpThaoTac.TabIndex = 1;
            this.grpThaoTac.TabStop = false;
            this.grpThaoTac.Text = "Thông Tin Đặt / Nhận / Trả Phòng";
            // 
            // lblSoPhong
            // 
            this.lblSoPhong.AutoSize = true;
            this.lblSoPhong.Location = new System.Drawing.Point(15, 30);
            this.lblSoPhong.Name = "lblSoPhong";
            this.lblSoPhong.Size = new System.Drawing.Size(56, 13);
            this.lblSoPhong.TabIndex = 0;
            this.lblSoPhong.Text = "Số phòng:";
            // 
            // txtSoPhong
            // 
            this.txtSoPhong.Location = new System.Drawing.Point(100, 27);
            this.txtSoPhong.Name = "txtSoPhong";
            this.txtSoPhong.Size = new System.Drawing.Size(265, 20);
            this.txtSoPhong.TabIndex = 1;
            // 
            // lblCCCD
            // 
            this.lblCCCD.AutoSize = true;
            this.lblCCCD.Location = new System.Drawing.Point(15, 65);
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.Size = new System.Drawing.Size(76, 13);
            this.lblCCCD.TabIndex = 2;
            this.lblCCCD.Text = "CCCD / CMND:";
            // 
            // txtCCCD
            // 
            this.txtCCCD.Location = new System.Drawing.Point(100, 62);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(265, 20);
            this.txtCCCD.TabIndex = 3;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(15, 100);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(57, 13);
            this.lblHoTen.TabIndex = 4;
            this.lblHoTen.Text = "Họ và tên:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(100, 97);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(265, 20);
            this.txtHoTen.TabIndex = 5;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(15, 135);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(73, 13);
            this.lblSDT.TabIndex = 6;
            this.lblSDT.Text = "Số điện thoại:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(100, 132);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(265, 20);
            this.txtSDT.TabIndex = 7;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.LightGreen;
            this.btnCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckIn.Location = new System.Drawing.Point(100, 165);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(125, 35);
            this.btnCheckIn.TabIndex = 8;
            this.btnCheckIn.Text = "Check-in (Nhận)";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.Coral;
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Location = new System.Drawing.Point(240, 165);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(125, 35);
            this.btnCheckOut.TabIndex = 9;
            this.btnCheckOut.Text = "Check-out (Trả)";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // grpDichVu
            // 
            this.grpDichVu.Controls.Add(this.dgvDichVuDaDung);
            this.grpDichVu.Controls.Add(this.btnGoiDichVu);
            this.grpDichVu.Controls.Add(this.nudSoLuongDV);
            this.grpDichVu.Controls.Add(this.lblSoLuong);
            this.grpDichVu.Controls.Add(this.cboDichVu);
            this.grpDichVu.Controls.Add(this.lblDichVu);
            this.grpDichVu.Location = new System.Drawing.Point(485, 230);
            this.grpDichVu.Name = "grpDichVu";
            this.grpDichVu.Size = new System.Drawing.Size(387, 292);
            this.grpDichVu.TabIndex = 2;
            this.grpDichVu.TabStop = false;
            this.grpDichVu.Text = "Sử Dụng Dịch Vụ";
            // 
            // lblDichVu
            // 
            this.lblDichVu.AutoSize = true;
            this.lblDichVu.Location = new System.Drawing.Point(15, 30);
            this.lblDichVu.Name = "lblDichVu";
            this.lblDichVu.Size = new System.Drawing.Size(47, 13);
            this.lblDichVu.TabIndex = 0;
            this.lblDichVu.Text = "Dịch vụ:";
            // 
            // cboDichVu
            // 
            this.cboDichVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDichVu.FormattingEnabled = true;
            this.cboDichVu.Location = new System.Drawing.Point(70, 27);
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.Size = new System.Drawing.Size(140, 21);
            this.cboDichVu.TabIndex = 1;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(220, 30);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(23, 13);
            this.lblSoLuong.TabIndex = 2;
            this.lblSoLuong.Text = "SL:";
            // 
            // nudSoLuongDV
            // 
            this.nudSoLuongDV.Location = new System.Drawing.Point(245, 28);
            this.nudSoLuongDV.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuongDV.Name = "nudSoLuongDV";
            this.nudSoLuongDV.Size = new System.Drawing.Size(45, 20);
            this.nudSoLuongDV.TabIndex = 3;
            this.nudSoLuongDV.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnGoiDichVu
            // 
            this.btnGoiDichVu.Location = new System.Drawing.Point(300, 25);
            this.btnGoiDichVu.Name = "btnGoiDichVu";
            this.btnGoiDichVu.Size = new System.Drawing.Size(75, 25);
            this.btnGoiDichVu.TabIndex = 4;
            this.btnGoiDichVu.Text = "Gọi món";
            this.btnGoiDichVu.UseVisualStyleBackColor = true;
            this.btnGoiDichVu.Click += new System.EventHandler(this.btnGoiDichVu_Click);
            // 
            // dgvDichVuDaDung
            // 
            this.dgvDichVuDaDung.AllowUserToAddRows = false;
            this.dgvDichVuDaDung.AllowUserToDeleteRows = false;
            this.dgvDichVuDaDung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDichVuDaDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVuDaDung.Location = new System.Drawing.Point(10, 60);
            this.dgvDichVuDaDung.Name = "dgvDichVuDaDung";
            this.dgvDichVuDaDung.ReadOnly = true;
            this.dgvDichVuDaDung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDichVuDaDung.Size = new System.Drawing.Size(365, 222);
            this.dgvDichVuDaDung.TabIndex = 5;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 534);
            this.Controls.Add(this.grpDichVu);
            this.Controls.Add(this.grpThaoTac);
            this.Controls.Add(this.grpPhong);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý Khách Sạn & Dịch Vụ (Hotel Management System)";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpPhong.ResumeLayout(false);
            this.grpPhong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.grpThaoTac.ResumeLayout(false);
            this.grpThaoTac.PerformLayout();
            this.grpDichVu.ResumeLayout(false);
            this.grpDichVu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuDaDung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPhong;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblLoaiPhong;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.ComboBox cboLoaiPhong;
        private System.Windows.Forms.GroupBox grpThaoTac;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.TextBox txtSoPhong;
        private System.Windows.Forms.Label lblSoPhong;
        private System.Windows.Forms.GroupBox grpDichVu;
        private System.Windows.Forms.DataGridView dgvDichVuDaDung;
        private System.Windows.Forms.Button btnGoiDichVu;
        private System.Windows.Forms.NumericUpDown nudSoLuongDV;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.Label lblDichVu;
    }
}
