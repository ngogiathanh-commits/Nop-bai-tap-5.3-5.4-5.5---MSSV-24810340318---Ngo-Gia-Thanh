using System.Collections.Generic;
using bt_30_10_5._5.DAL;
using bt_30_10_5._5.DTO;

namespace bt_30_10_5._5.BUS
{
    public class PhieuKhoBUS
    {
        private PhieuKhoDAL dal = new PhieuKhoDAL();

        public bool LuuPhieuKho(PhieuKhoDTO phieu, List<ChiTietPhieuKhoDTO> listChiTiet, out string errorMessage)
        {
            errorMessage = "";
            if (listChiTiet == null || listChiTiet.Count == 0)
            {
                errorMessage = "Vui lòng chọn ít nhất 1 vật tư vào phiếu kho!";
                return false;
            }

            return dal.LuuPhieuKho(phieu, listChiTiet, out errorMessage);
        }
    }
}
