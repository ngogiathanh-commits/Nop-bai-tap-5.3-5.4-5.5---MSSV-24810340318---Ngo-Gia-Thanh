using bt_30_10_5._4.DAL;
using System.Data;

namespace bt_30_10_5._4.BUS
{
    public class PhongBUS
    {
        private PhongDAL dal = new PhongDAL();

        public DataTable GetAllPhong() => dal.GetAllPhong();

        
        public DataView FilterPhong(DataTable dtSource, string loaiPhong, string trangThai)
        {
            DataView dv = dtSource.DefaultView;
            string filter = "1=1";

            if (!string.IsNullOrEmpty(loaiPhong) && loaiPhong != "Tất cả")
                filter += $" AND LoaiPhong = '{loaiPhong}'";

            if (!string.IsNullOrEmpty(trangThai) && trangThai != "Tất cả")
                filter += $" AND TrangThai = '{trangThai}'";

            dv.RowFilter = filter;
            return dv;
        }
    }
}
