using QLBH_DAO;
using QLBH_DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLBH_BUS
{
    public class BUS_KhachHang
    {
        public static DataTable LayKhachHang()
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
        public static DataTable LayKhachHangDonGian()
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

        public static bool KiemTraKH(string MaKH)
        {
            try
            {
                KhachHang dao = new KhachHang();
                DataTable table = dao.GetKH(MaKH);
                if (table.Rows.Count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public static void ThemKH(CKhachHang kh)
        {
            try
            {
                KhachHang dao = new KhachHang();
                dao.ThemKH(kh);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void SuaKH(CKhachHang kh)
        {
            try
            {
                KhachHang dao = new KhachHang();
                dao.SuaKH(kh);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void XoaKH(string MaKH)
        {
            try
            {
                KhachHang dao = new KhachHang();
                dao.XoaKH(MaKH);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
