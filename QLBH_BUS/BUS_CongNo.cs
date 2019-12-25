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
    public class BUS_CongNo
    {
        public static DataTable LoadCNThu()
        {
            try
            {
                CongNo dao = new CongNo();
                return dao.LoadCNThu();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static DataTable LoadCNThuTraNgay()
        {
            try
            {
                CongNo dao = new CongNo();
                return dao.LoadCNThuTraNgay();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public static DataTable LoadPhieuThu()
        {
            try
            {
                CongNo dao = new CongNo();
                return dao.LoadPhieuThu();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static DataTable LoadCNChi()
        {
            try
            {
                CongNo dao = new CongNo();
                return dao.LoadCNChi();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static DataTable LoadCNChiTraNgay()
        {
            try
            {
                CongNo dao = new CongNo();
                return dao.LoadCNChiTraNgay();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public static DataTable LoadPhieuChi()
        {
            try
            {
                CongNo dao = new CongNo();
                return dao.LoadPhieuChi();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
