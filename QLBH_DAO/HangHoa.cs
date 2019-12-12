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
    public class HangHoa
    {

        public DataTable LoadHangHoa()
        {
            try
            {
                return SelectTable.SelectProcedure("PRODUCT_GetList");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadHHDonGian()
        {
            try
            {
                return SelectTable.SelectQuery("select Customer_ID,CustomerName from CUSTOMER where Active = 1");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadHHLookupEdit()
        {
            try
            {
                return SelectTable.SelectProcedure("PRODUCT_GetLookupByStock");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        //Nhóm Hàng
        public DataTable LoadNhomHang()
        {
            try
            {
                return SelectTable.SelectProcedure("PRODUCT_GROUP_GetList");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable GetNH(string MaNH)
        {
            try
            {
                string sql = "PRODUCT_GROUP_Get";
                return SelectTable.SelectProcedure(sql, new SqlParameter { ParameterName = "@ProductGroup_ID", Value = MaNH });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ThemNhomHang(CNhomHang nh)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "PRODUCT_GROUP_Insert";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@ProductGroup_ID", Value = nh.MaNH },
                    new SqlParameter { ParameterName = "@ProductGroup_Name", Value = nh.TenNH },
                    new SqlParameter { ParameterName = "@Description", Value = nh.GhiChu },
                    new SqlParameter { ParameterName = "@Active", Value = nh.ConQL });
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

        public void SuaNhomHang(CNhomHang nh)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "PRODUCT_GROUP_Update";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@ProductGroup_ID", Value = nh.MaNH },
                    new SqlParameter { ParameterName = "@ProductGroup_Name", Value = nh.TenNH },
                    new SqlParameter { ParameterName = "@Description", Value = nh.GhiChu },
                    new SqlParameter { ParameterName = "@Active", Value = nh.ConQL });
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

        public void XoaNhomHang(string MaNH)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "PRODUCT_GROUP_Delete";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql, new SqlParameter { ParameterName = "@ProductGroup_ID", Value = MaNH });
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
