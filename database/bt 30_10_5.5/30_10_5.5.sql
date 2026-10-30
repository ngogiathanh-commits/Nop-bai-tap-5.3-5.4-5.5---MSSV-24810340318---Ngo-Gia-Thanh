CREATE DATABASE QLIM
GO

USE QLIM
GO

CREATE TABLE NhaCungCap (
    MaNCC INT IDENTITY(1,1) PRIMARY KEY,
    TenNCC NVARCHAR(150) NOT NULL,
    DienThoai VARCHAR(15) UNIQUE,
    DiaChi NVARCHAR(255)
);

CREATE TABLE VatTu (
    MaVatTu VARCHAR(20) PRIMARY KEY,
    TenVatTu NVARCHAR(150) NOT NULL,
    DVT NVARCHAR(20),
    SoLuongTon DECIMAL(18,2) DEFAULT 0 CHECK (SoLuongTon >= 0)
);

CREATE TABLE PhieuKho (
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    LoaiPhieu NVARCHAR(10) NOT NULL CHECK (LoaiPhieu IN (N'NHAP', N'XUAT')),
    NgayLap DATETIME DEFAULT GETDATE(),
    MaNCC INT NULL FOREIGN KEY REFERENCES NhaCungCap(MaNCC),
    TongTien DECIMAL(18,2) DEFAULT 0
);

CREATE TABLE ChiTietPhieuKho (
    MaPhieu INT FOREIGN KEY REFERENCES PhieuKho(MaPhieu),
    MaVatTu VARCHAR(20) FOREIGN KEY REFERENCES VatTu(MaVatTu),
    SoLuong DECIMAL(18,2) NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
    PRIMARY KEY (MaPhieu, MaVatTu)
);

INSERT INTO NhaCungCap (TenNCC, DienThoai, DiaChi) VALUES
(N'Công ty VLXD Hoàn Mỹ', '0901234567', N'123 Lê Duẩn, Hà Nội'),
(N'Nhà phân phối An Phát', '0987654321', N'456 Nguyễn Huệ, TP.HCM');

INSERT INTO VatTu (MaVatTu, TenVatTu, DVT, SoLuongTon) VALUES
('VT001', N'Xi măng Hà Tiên', N'Bao', 100.00),
('VT002', N'Thép Hòa Phát 10mm', N'Cây', 50.00),
('VT003', N'Gạch men 60x60', N'Thùng', 5.00), 
('VT004', N'Sơn KOVA trắng', N'Thùng', 2.00);  
GO