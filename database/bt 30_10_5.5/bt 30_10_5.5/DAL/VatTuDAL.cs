
using System;
using System.Data;
using System.Data.SqlClient;
using bt_30_10_5._5.DTO;

namespace bt_30_10_5._5.DAL
{
    public class VatTuDAL
    {
        public DataTable GetAllVatTu()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM VatTu";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        
        public DataTable TimKiemVatTu(string keyword)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM VatTu WHERE MaVatTu LIKE @Keyword OR TenVatTu LIKE @Keyword";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Keyword", "%" + keyword + "%"));

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

    
        public DataTable GetVatTuDuoiNguong(decimal nguongAnToan)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM VatTu WHERE SoLuongTon <= @Nguong";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Nguong", nguongAnToan));

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

      
        public decimal GetTongSoLuongTon()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT ISNULL(SUM(SoLuongTon), 0) FROM VatTu";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToDecimal(result);
            }
        }
    }
}
