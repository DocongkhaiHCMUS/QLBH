using QLBH_DAO;
using System.Data;
using System.Data.SqlClient;

namespace QLBH_BUS
{
    public class BUS_KhachHang
    {
        public static DataTable GetKhachHang()
        {
            try
            {
                KhachHang dao = new KhachHang();
                return dao.LoadKH();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public static DataTable GetKhachHangDonGian()
        {
            try
            {
               KhachHang  dao = new KhachHang();
                return dao.LoadKHDonGian();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
