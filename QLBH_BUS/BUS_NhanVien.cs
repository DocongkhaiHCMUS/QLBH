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
    public class BUS_NhanVien
    {
        public static DataTable GetBoPhan()
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

        public static DataTable GetNhanVien()
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
        public static DataTable GetNhanVienDonGian()
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
    }
}
