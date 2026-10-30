create database QLHMS
go

use QLHMS
go

CREATE TABLE Phong (
	SoPhong VARCHAR(10) PRIMARY KEY,
    LoaiPhong NVARCHAR(50) NOT NULL,
    GiaTheoGio DECIMAL(18,2) NOT NULL,
    TrangThai NVARCHAR(30) DEFAULT N'Trống'
);

CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    CCCD VARCHAR(20) UNIQUE NOT NULL,
    SoDienThoai VARCHAR(15)
);

CREATE TABLE DichVu (
    MaDV INT IDENTITY(1,1) PRIMARY KEY,
    TenDV NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL
);

CREATE TABLE PhieuDatPhong (
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    SoPhong VARCHAR(10) FOREIGN KEY REFERENCES Phong(SoPhong),
    MaKH INT FOREIGN KEY REFERENCES KhachHang(MaKH),
    NgayNhanPhong DATETIME DEFAULT GETDATE(),
    NgayTraPhong DATETIME NULL,
    TongTienThanhToan DECIMAL(18,2) DEFAULT 0
);

CREATE TABLE SuDungDichVu (
    MaPhieu INT FOREIGN KEY REFERENCES PhieuDatPhong(MaPhieu),
    MaDV INT FOREIGN KEY REFERENCES DichVu(MaDV),
    SoLuong INT NOT NULL,
    ThoiGian DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (MaPhieu, MaDV, ThoiGian)
);

INSERT INTO Phong (SoPhong, LoaiPhong, GiaTheoGio, TrangThai) VALUES
('P101', N'Đơn', 100000, N'Trống'),
('P102', N'Đôi', 150000, N'Trống'),
('P201', N'VIP', 300000, N'Trống'),
('P202', N'VIP', 300000, N'Trống');

INSERT INTO DichVu (TenDV, DonGia) VALUES
(N'Nước suối', 15000),
(N'Mì ly', 20000),
(N'Giặt là', 50000),
(N'Cà phê', 25000);
GO