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
    public class BUS_KhuVuc
    {
        public static void ThemKV(CKhuVuc kv)
        {
            try
            {
                KhuVuc dao = new KhuVuc();
                dao.ThemKV(kv);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void SuaKV(CKhuVuc kv)
        {
            try
            {
                KhuVuc dao = new KhuVuc();
                dao.SuaKV(kv);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static DataTable KhuVuc()
        {
            try
            {
                KhuVuc dao = new KhuVuc();
                return dao.LoadKhuVuc();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool KiemTraKV(string MaKV)
        {
            try
            {
                KhuVuc dao = new KhuVuc();
                DataTable table = dao.GetKV(MaKV);
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

        public static void XoaKV(string MaKV)
        {
            try
            {
                KhuVuc dao = new KhuVuc();
                dao.XoaKV(MaKV);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
