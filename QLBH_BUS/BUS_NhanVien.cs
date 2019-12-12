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
    public class BUS_NhanVien
    {
        public static DataTable LayNhanVien()
        {
            try
            {
                NhanVien dao = new NhanVien();
                return dao.LoadNV();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public static DataTable LayNhanVienDonGian()
        {
            try
            {
                NhanVien dao = new NhanVien();
                return dao.LoadNVDonGian();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        //Bộ Phận
        public static DataTable LayBoPhan()
        {
            try
            {
                NhanVien dao = new NhanVien();
                return dao.LoadBoPhan();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool KiemTraBP(string MaBP)
        {
            try
            {
                NhanVien dao = new NhanVien();
                DataTable table = dao.GetBP(MaBP);
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

        public static void ThemBP(CBoPhan bp)
        {
            try
            {
                NhanVien dao = new NhanVien();
                dao.ThemBP(bp);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void SuaBP(CBoPhan bp)
        {
            try
            {
                NhanVien dao = new NhanVien();
                dao.SuaBP(bp);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void XoaBP(string MaBP)
        {
            try
            {
                NhanVien dao = new NhanVien();
                dao.XoaBP(MaBP);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
