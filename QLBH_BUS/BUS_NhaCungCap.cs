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
    public class BUS_NhaCungCap
    {
        public static DataTable LayNhaCC()
        {
            try
            {
                NhaCungCap dao = new NhaCungCap();
                return dao.LoadNhaCC();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool KiemTraNCC(string maNCC)
        {
            try
            {
                NhaCungCap dao = new NhaCungCap();
                DataTable table = dao.GetNCC(maNCC);
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

        public static void ThemNCC(CNhaCC ncc)
        {
            try
            {
                NhaCungCap dao = new NhaCungCap();
                dao.ThemNCC(ncc);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void SuaNCC(CNhaCC ncc)
        {
            try
            {
                NhaCungCap dao = new NhaCungCap();
                dao.SuaNCC(ncc);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void XoaNCC(string MaNCC)
        {
            try
            {
                NhaCungCap dao = new NhaCungCap();
                dao.XoaNCC(MaNCC);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
