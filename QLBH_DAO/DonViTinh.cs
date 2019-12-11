using QLBH_DTO;
using System.Data;
using System.Data.SqlClient;

namespace QLBH_DAO
{
    public class DonViTinh
    {
        public DataTable LoadDVT()
        {
            try
            {
                return SelectTable.SelectProcedure("UNIT_GetList");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public DataTable LoadDVTDonGian()
        {
            try
            {
                return SelectTable.SelectQuery("select UNIT_ID,UNIT_Name from UNIT where Active = 1");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ThemDV(CDonViTinh dv)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "UNIT_Insert";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Unit_ID", Value = dv.MaDV },
                    new SqlParameter { ParameterName = "@Unit_Name", Value = dv.TenDV },
                    new SqlParameter { ParameterName = "@Description", Value = dv.GhiChu },
                    new SqlParameter { ParameterName = "@Active", Value = dv.ConQL });
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

        public void SuaDV(CDonViTinh dv)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "UNIT_Update";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Unit_ID", Value = dv.MaDV },
                    new SqlParameter { ParameterName = "@Unit_Name", Value = dv.TenDV },
                    new SqlParameter { ParameterName = "@Description", Value = dv.GhiChu },
                    new SqlParameter { ParameterName = "@Active", Value = dv.ConQL });
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

        public void XoaDV(string MaDV)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "UNIT_Delete";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql, new SqlParameter { ParameterName = "@Unit_ID", Value = MaDV });
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
