using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DAO
{
    public class CongNo
    {
        public DataTable LoadCNThu()
        {
            try
            {
                string sql = "KSP_CNPT_Load";
                return SelectTable.SelectProcedure(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadCNThuTraNgay()
        {
            try
            {
                string sql = "KSP_CNPTTraNgay_Load";
                return SelectTable.SelectProcedure(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadPhieuThu()
        {
            try
            {
                string sql = "KSP_PhieuThu_Load";
                return SelectTable.SelectProcedure(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadCNChi()
        {
            try
            {
                string sql = "KSP_CNPC_Load";
                return SelectTable.SelectProcedure(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadCNChiTraNgay()
        {
            try
            {
                string sql = "KSP_CNPCTraNgay_Load";
                return SelectTable.SelectProcedure(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadPhieuChi()
        {
            try
            {
                string sql = "KSP_PhieuChi_Load";
                return SelectTable.SelectProcedure(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
