using bt_30_10_5._1.DAL;
using System;
using System.Data;

namespace bt_30_10_5._1.BUS
{
    public class MonAnBUS
    {
        private MonAnDAL dal = new MonAnDAL();

        public DataTable GetAllMonAn()
        {
            return dal.GetAllMonAn();
        }

        public bool ThemMonAn(string tenMon, int maDanhMuc, decimal donGia, out string error)
        {
            error = "";

            // Ràng buộc 1: Tên món không được để trống
            if (string.IsNullOrWhiteSpace(tenMon))
            {
                error = "Tên món ăn không được để trống!";
                return false;
            }

            // Ràng buộc 2: Đơn giá không được âm hoặc bằng 0
            if (donGia <= 0)
            {
                error = "Đơn giá phải lớn hơn 0!";
                return false;
            }

            return dal.InsertMonAn(tenMon.Trim(), maDanhMuc, donGia);
        }

        public bool SuaMonAn(int maMon, string tenMon, int maDanhMuc, decimal donGia, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(tenMon))
            {
                error = "Tên món ăn không được để trống!";
                return false;
            }

            if (donGia <= 0)
            {
                error = "Đơn giá phải lớn hơn 0!";
                return false;
            }

            return dal.UpdateMonAn(maMon, tenMon.Trim(), maDanhMuc, donGia);
        }

        public bool XoaMonAn(int maMon)
        {
            return dal.DeleteMonAn(maMon);
        }
    }
}
