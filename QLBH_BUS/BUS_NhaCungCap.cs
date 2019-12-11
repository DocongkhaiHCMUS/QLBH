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
    public class BUS_NhaCungCap
    {
        public static DataTable GetNhaCC()
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
    }
}
