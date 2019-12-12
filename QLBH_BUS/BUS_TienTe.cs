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
    public class BUS_TienTe
    {
        public static DataTable LayTienTe()
        {
            try
            {
                TienTe dao = new TienTe();
                DataTable table = dao.LoadTiGia();
                return table;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool KiemTraTienTe(string maTienTe)
        {
            try
            {
                TienTe dao = new TienTe();
                DataTable table = dao.GetTienTe(maTienTe);
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

        public static void ThemTienTe(CTyGia tg)
        {
            try
            {
                TienTe dao = new TienTe();
                dao.ThemTienTe(tg);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void SuaTienTe(CTyGia tg)
        {
            try
            {
                TienTe dao = new TienTe();
                dao.SuaTienTe(tg);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void XoaTienTe(string maTienTe)
        {
            try
            {
                TienTe dao = new TienTe();
                dao.XoaTienTe(maTienTe);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
