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
    public class NhanVien
    {
        public DataTable LoadNV()
        {
            try
            {
                return SelectTable.SelectProcedure("EMPLOYEE_GetList");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadNVDonGian()
        {
            try
            {
                return SelectTable.SelectQuery("select EMPLOYEE_ID,EMPLOYEE_Name from EMPLOYEE where Active = 1");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        //Bộ Phận

        public DataTable LoadBoPhan()
        {
            try
            {
                return SelectTable.SelectProcedure("DEPARTMENT_GetList");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ThemBP(CBoPhan bp)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "DEPARTMENT_Insert";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Department_ID", Value = bp.MaBP },
                    new SqlParameter { ParameterName = "@Department_Name", Value = bp.TenBP },
                    new SqlParameter { ParameterName = "@Description", Value = bp.GhiChu },
                    new SqlParameter { ParameterName = "@Active", Value = bp.ConQL });
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

        public void SuaBP(CBoPhan bp)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "DEPARTMENT_Update";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Department_ID", Value = bp.MaBP },
                    new SqlParameter { ParameterName = "@Department_Name", Value = bp.TenBP },
                    new SqlParameter { ParameterName = "@Description", Value = bp.GhiChu },
                    new SqlParameter { ParameterName = "@Active", Value = bp.ConQL });
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

        public void XoaBP(string MaBP)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "DEPARTMENT_Delete";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql, new SqlParameter { ParameterName = "@Department_ID", Value = MaBP });
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
