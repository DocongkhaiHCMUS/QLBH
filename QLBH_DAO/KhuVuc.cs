using QLBH_DTO;
using System.Data;
using System.Data.SqlClient;

namespace QLBH_DAO
{
    public class KhuVuc
    {
        public DataTable LoadKhuVuc()
        {
            try
            {
                return SelectTable.SelectQuery("select CUSTOMER_GROUP_ID , CUSTOMER_GROUP_Name  , Description , Active  from CUSTOMER_GROUP");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable GetKV(string MaKV)
        {
            try
            {
                string sql = "select * from CUSTOMER_GROUP where CUSTOMER_GROUP_ID = '" + MaKV + "'";
                return SelectTable.SelectQuery(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ThemKV(CKhuVuc kv)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "CUSTOMER_GROUP_Insert";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter {ParameterName = "@Customer_Group_ID",Value = kv.MaKV },
                    new SqlParameter { ParameterName = "@Customer_Group_Name", Value = kv.TenKV },
                    new SqlParameter { ParameterName = "@Description", Value = kv.GhiChu },
                    new SqlParameter { ParameterName = "@Active", Value = kv.ConQL });
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

        public void SuaKV(CKhuVuc kv)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "CUSTOMER_GROUP_Update";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Customer_Group_ID", Value = kv.MaKV },
                    new SqlParameter { ParameterName = "@Customer_Group_Name", Value = kv.TenKV },
                    new SqlParameter { ParameterName = "@Description", Value = kv.GhiChu },
                    new SqlParameter { ParameterName = "@Active", Value = kv.ConQL });
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

        public void XoaKV(string MaKV)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "CUSTOMER_GROUP_Delete";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,new SqlParameter {ParameterName = "@Customer_Group_ID",Value = MaKV });
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
