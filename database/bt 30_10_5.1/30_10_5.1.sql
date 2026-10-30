create database QLCF;
go

use QLCF;
go

CREATE TABLE BanAn (
	MaBan INT IDENTITY(1,1) PRIMARY KEY,
	TenBan nvarchar(50) NOT NULL,
	TrangThai nvarchar(50) DEFAULT N'TRỐNG'
);

CREATE TABLE DanhMuc (
    MaDanhMuc INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL
);

CREATE TABLE MonAn (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    MaDanhMuc INT FOREIGN KEY REFERENCES DanhMuc(MaDanhMuc),
    DonGia DECIMAL(18,2) NOT NULL
);

CREATE TABLE HoaDon (
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaBan INT FOREIGN KEY REFERENCES BanAn(MaBan),
    GioVao DATETIME DEFAULT GETDATE(),
    GioRa DATETIME NULL,
    TongTien DECIMAL(18,2) DEFAULT 0,
    TrangThai BIT DEFAULT 0
);

CREATE TABLE ChiTietHoaDon (
    MaHoaDon INT FOREIGN KEY REFERENCES HoaDon(MaHoaDon),
    MaMon INT FOREIGN KEY REFERENCES MonAn(MaMon),
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (MaHoaDon, MaMon)
);

INSERT INTO BanAn (TenBan, TrangThai) VALUES 
(N'Bàn 01', N'Trống'), (N'Bàn 02', N'Trống'), 
(N'Bàn 03', N'Trống'), (N'Bàn 04', N'Trống'), (N'Bàn 05', N'Trống');

INSERT INTO DanhMuc (TenDanhMuc) VALUES 
(N'Cà phê'), (N'Trà sữa'), (N'Đồ ăn nhẹ');

INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia) VALUES 
(N'Cà phê đen', 1, 25000), 
(N'Cà phê sữa', 1, 30000), 
(N'Trà sữa Ô Long', 2, 45000), 
(N'Bánh mì que', 3, 20000);
GO
