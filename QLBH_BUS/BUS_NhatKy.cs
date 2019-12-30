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
    public class BUS_NhatKy
    {
        public static DataTable LoadNhatKy()
        {
            try
            {
                NhatKy dao = new NhatKy();
                return dao.LoadNhatKy();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public static void XoaNhatKy(int ID)
        {
            try
            {
                NhatKy dao = new NhatKy();
                dao.XoaNhatKy(ID);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public static void ThemNhatKy(CNhatKy nk)
        {
            try
            {
                NhatKy dao = new NhatKy();
                dao.ThemNhatKy(nk);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
