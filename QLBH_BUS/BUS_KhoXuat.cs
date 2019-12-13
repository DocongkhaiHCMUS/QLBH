using QLBH_DAO;
using QLBH_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_BUS
{
    public class BUS_KhoXuat
    {
        public static DataTable LayKho()
        {
            try
            {
                Kho dao = new Kho();
                return dao.LoadKhoHang();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public static DataTable LayKhoDonGian()
        {
            try
            {
                Kho  dao = new Kho();
                return dao.LoadKhoHangDonGian();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool KiemTraKho(string maKho)
        {
            try
            {
                Kho dao = new Kho();
                DataTable table = dao.GetKho(maKho);
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

        public static void ThemKho(CKho kho)
        {
            try
            {
                Kho dao = new Kho();
                dao.ThemKho(kho);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void SuaKho(CKho kho)
        {
            try
            {
                Kho dao = new Kho();
                dao.SuaKho(kho);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void XoaKho(string MaKho)
        {
            try
            {
                Kho dao = new Kho();
                dao.XoaKho(MaKho);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
