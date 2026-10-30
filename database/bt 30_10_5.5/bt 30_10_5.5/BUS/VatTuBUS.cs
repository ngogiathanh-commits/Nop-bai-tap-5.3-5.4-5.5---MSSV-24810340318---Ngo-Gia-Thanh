using System.Data;
using bt_30_10_5._5.DAL;

namespace bt_30_10_5._5.BUS
{
    public class VatTuBUS
    {
        private VatTuDAL dal = new VatTuDAL();

        public DataTable GetAllVatTu() => dal.GetAllVatTu();

        public DataTable TimKiemVatTu(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return dal.GetAllVatTu();
            return dal.TimKiemVatTu(keyword.Trim());
        }

        public DataTable GetVatTuDuoiNguong(decimal nguongAnToan) => dal.GetVatTuDuoiNguong(nguongAnToan);

        public decimal GetTongSoLuongTon() => dal.GetTongSoLuongTon();
    }
}
