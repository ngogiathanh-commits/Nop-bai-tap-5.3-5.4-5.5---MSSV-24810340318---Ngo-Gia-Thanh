using System;

namespace bt_30_10_5._5.DTO
{
    public class PhieuKhoDTO
    {
        public int MaPhieu { get; set; }
        public string LoaiPhieu { get; set; } // "NHAP" hoặc "XUAT"
        public DateTime NgayLap { get; set; }
        public int? MaNCC { get; set; }
        public decimal TongTien { get; set; }
    }
}
