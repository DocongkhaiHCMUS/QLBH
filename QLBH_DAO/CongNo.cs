using QLBH_DTO;
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

        public void ThemPhieuThu(CCongNo pt)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "KSP_PT_Insert";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@MaPT"          , Value = pt.MaPT		},
                    new SqlParameter { ParameterName = "@NgayLap"       , Value = pt.NgayLap	},
                    new SqlParameter { ParameterName = "@MaBH"          , Value = pt.MaBH		},
                    new SqlParameter { ParameterName = "@MaKH"          , Value = pt.MaKH		},
                    new SqlParameter { ParameterName = "@TenKH"         , Value = pt.TenKH		},
                    new SqlParameter { ParameterName = "@SoTienTra"     , Value = pt.SoTienTra	},
                    new SqlParameter { ParameterName = "@TaoBoi"        , Value = pt.TaoBoi		},
                    new SqlParameter { ParameterName = "@MaNV"          , Value = pt.MaNV		},
                    new SqlParameter { ParameterName = "@GhiChu"        , Value = pt.GhiChu     });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dao.DisConnect();
            }
        }
        public void XoaPT(string MaPT)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "KSP_PT_Delete";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql, new SqlParameter { ParameterName = "@MaPT", Value = MaPT });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dao.DisConnect();
            }
        }

        public void ThemPhieuChi(CCongNo pc)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "KSP_PC_Insert";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@MaPC"      , Value = pc.MaPT },
                    new SqlParameter { ParameterName = "@NgayLap"   , Value = pc.NgayLap },
                    new SqlParameter { ParameterName = "@MaMH"      , Value = pc.MaBH },
                    new SqlParameter { ParameterName = "@MaNCC"     , Value = pc.MaKH },
                    new SqlParameter { ParameterName = "@TenNCC"     , Value = pc.TenKH },
                    new SqlParameter { ParameterName = "@SoTienTra" , Value = pc.SoTienTra },
                    new SqlParameter { ParameterName = "@TaoBoi"    , Value = pc.TaoBoi },
                    new SqlParameter { ParameterName = "@MaNV"      , Value = pc.MaNV },
                    new SqlParameter { ParameterName = "@GhiChu"    , Value = pc.GhiChu });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dao.DisConnect();
            }
        }
        public void XoaPC(string MaPC)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "KSP_PC_Delete";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql, new SqlParameter { ParameterName = "@MaPC", Value = MaPC });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dao.DisConnect();
            }
        }
    }
}
