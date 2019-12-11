using QLBH_DAO;
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
    }
}
