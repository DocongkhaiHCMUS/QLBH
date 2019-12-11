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
    public class TienTe
    {
        public DataTable LoadTiGia()
        {
            try
            {
                string sql = "CURRENCY_GetList";
                return SelectTable.SelectProcedure(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ThemTienTe(CTyGia tien)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "CURRENCY_Insert";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Currency_ID", Value = tien.MaTienTe },
                    new SqlParameter { ParameterName = "@CurrencyName", Value = tien.TenTienTe },
                    new SqlParameter { ParameterName = "@Exchange", Value = tien.TyGia },
                    new SqlParameter { ParameterName = "@Active", Value = tien.ConQL });
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

        public void SuaTienTe(CTyGia tien)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "CURRENCY_Update";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Currency_ID", Value = tien.MaTienTe },
                    new SqlParameter { ParameterName = "@CurrencyName", Value = tien.TenTienTe },
                    new SqlParameter { ParameterName = "@Exchange", Value = tien.TyGia },
                    new SqlParameter { ParameterName = "@Active", Value = tien.ConQL });
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

        public void XoaTienTe(string maTienTe)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "CURRENCY_Delete";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql, new SqlParameter { ParameterName = "@Currency_ID", Value = maTienTe });
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
