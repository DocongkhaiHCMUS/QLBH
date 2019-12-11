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
    public class BUS_KhoXuat
    {
        public static DataTable GetKho()
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
        public static DataTable GetKhoDonGian()
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
    }
}
