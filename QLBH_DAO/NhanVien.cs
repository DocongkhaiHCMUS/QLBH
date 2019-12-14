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

        public DataTable GetNV(string MaNV)
        {
            try
            {
                string sql = "EMPLOYEE_Get";
                return SelectTable.SelectProcedure(sql, new SqlParameter { ParameterName = "@Employee_ID", Value = MaNV });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ThemNV(CNhanVien nv)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "EMPLOYEE_Insert";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Employee_ID", Value = nv.MaNV },
                    new SqlParameter { ParameterName = "@FirtName", Value = nv.FirtName },
                    new SqlParameter { ParameterName = "@LastName", Value = nv.LastName },
                    new SqlParameter { ParameterName = "@Employee_Name", Value = nv.TenNV },
                    new SqlParameter { ParameterName = "@Alias", Value = nv.Alias },
                    new SqlParameter { ParameterName = "@Sex", Value = nv.GioiTinh },
                    new SqlParameter { ParameterName = "@Address", Value = nv.DiaChi },
                    new SqlParameter { ParameterName = "@Country_ID", Value = nv.Country_ID },
                    new SqlParameter { ParameterName = "@H_Tel", Value = nv.H_Tel },
                    new SqlParameter { ParameterName = "@O_Tel", Value = nv.DienThoai },
                    new SqlParameter { ParameterName = "@Mobile", Value = nv.DiDong },
                    new SqlParameter { ParameterName = "@Fax", Value = nv.Fax },
                    new SqlParameter { ParameterName = "@Email", Value = nv.Email },
                    new SqlParameter { ParameterName = "@Birthday", Value = nv.NgaySinh },
                    new SqlParameter { ParameterName = "@Married", Value = nv.Married },
                    new SqlParameter { ParameterName = "@Position_ID", Value = nv.Position_ID },
                    new SqlParameter { ParameterName = "@JobTitle_ID", Value = nv.JobTitle_ID },
                    new SqlParameter { ParameterName = "@Branch_ID", Value = nv.Branch_ID },
                    new SqlParameter { ParameterName = "@Department_ID", Value = nv.BoPhan },
                    new SqlParameter { ParameterName = "@Team_ID", Value = nv.Team_ID },
                    new SqlParameter { ParameterName = "@PersonalTax_ID", Value = nv.PersonalTax_ID },
                    new SqlParameter { ParameterName = "@City_ID", Value = nv.City_ID },
                    new SqlParameter { ParameterName = "@District_ID", Value = nv.District_ID },
                    new SqlParameter { ParameterName = "@Manager_ID", Value = nv.QuanLy },
                    new SqlParameter { ParameterName = "@EmployeeType", Value = nv.EmployeeType },
                    new SqlParameter { ParameterName = "@BasicSalary", Value = nv.BasicSalary },
                    new SqlParameter { ParameterName = "@Advance", Value = nv.Advance },
                    new SqlParameter { ParameterName = "@AdvanceOther", Value = nv.AdvanceOther },
                    new SqlParameter { ParameterName = "@Commission", Value = nv.Commission },
                    new SqlParameter { ParameterName = "@Discount", Value = nv.Discount },
                    new SqlParameter { ParameterName = "@ProfitRate", Value = nv.ProfitRate },
                    new SqlParameter { ParameterName = "@IsPublic", Value = nv.IsPublic },
                    new SqlParameter { ParameterName = "@CreatedBy", Value = nv.CreatedBy },
                    new SqlParameter { ParameterName = "@CreatedDate", Value = nv.CreatedDate },
                    new SqlParameter { ParameterName = "@ModifiedBy", Value = nv.ModifiedBy },
                    new SqlParameter { ParameterName = "@ModifiedDate", Value = nv.ModifiedDate },
                    new SqlParameter { ParameterName = "@OwnerID", Value = nv.OwnerID },
                    new SqlParameter { ParameterName = "@Description", Value = nv.ChucVu },
                    new SqlParameter { ParameterName = "@Sorted", Value = nv.Sorted },
                    new SqlParameter { ParameterName = "@Active", Value = nv.ConQL });
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

        public void SuaNV(CNhanVien nv)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "EMPLOYEE_Update";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Employee_ID", Value = nv.MaNV },
                    new SqlParameter { ParameterName = "@FirtName", Value = nv.FirtName },
                    new SqlParameter { ParameterName = "@LastName", Value = nv.LastName },
                    new SqlParameter { ParameterName = "@Employee_Name", Value = nv.TenNV },
                    new SqlParameter { ParameterName = "@Alias", Value = nv.Alias },
                    new SqlParameter { ParameterName = "@Sex", Value = nv.GioiTinh },
                    new SqlParameter { ParameterName = "@Address", Value = nv.DiaChi },
                    new SqlParameter { ParameterName = "@Country_ID", Value = nv.Country_ID },
                    new SqlParameter { ParameterName = "@H_Tel", Value = nv.H_Tel },
                    new SqlParameter { ParameterName = "@O_Tel", Value = nv.DienThoai },
                    new SqlParameter { ParameterName = "@Mobile", Value = nv.DiDong },
                    new SqlParameter { ParameterName = "@Fax", Value = nv.Fax },
                    new SqlParameter { ParameterName = "@Email", Value = nv.Email },
                    new SqlParameter { ParameterName = "@Birthday", Value = nv.NgaySinh.GetDateTimeFormats()[5] },
                    new SqlParameter { ParameterName = "@Married", Value = nv.Married },
                    new SqlParameter { ParameterName = "@Position_ID", Value = nv.Position_ID },
                    new SqlParameter { ParameterName = "@JobTitle_ID", Value = nv.JobTitle_ID },
                    new SqlParameter { ParameterName = "@Branch_ID", Value = nv.Branch_ID },
                    new SqlParameter { ParameterName = "@Department_ID", Value = nv.BoPhan },
                    new SqlParameter { ParameterName = "@Team_ID", Value = nv.Team_ID },
                    new SqlParameter { ParameterName = "@PersonalTax_ID", Value = nv.PersonalTax_ID },
                    new SqlParameter { ParameterName = "@City_ID", Value = nv.City_ID },
                    new SqlParameter { ParameterName = "@District_ID", Value = nv.District_ID },
                    new SqlParameter { ParameterName = "@Manager_ID", Value = nv.QuanLy },
                    new SqlParameter { ParameterName = "@EmployeeType", Value = nv.EmployeeType },
                    new SqlParameter { ParameterName = "@BasicSalary", Value = nv.BasicSalary },
                    new SqlParameter { ParameterName = "@Advance", Value = nv.Advance },
                    new SqlParameter { ParameterName = "@AdvanceOther", Value = nv.AdvanceOther },
                    new SqlParameter { ParameterName = "@Commission", Value = nv.Commission },
                    new SqlParameter { ParameterName = "@Discount", Value = nv.Discount },
                    new SqlParameter { ParameterName = "@ProfitRate", Value = nv.ProfitRate },
                    new SqlParameter { ParameterName = "@IsPublic", Value = nv.IsPublic },
                    new SqlParameter { ParameterName = "@CreatedBy", Value = nv.CreatedBy },
                    new SqlParameter { ParameterName = "@CreatedDate", Value = nv.CreatedDate.GetDateTimeFormats()[5] },
                    new SqlParameter { ParameterName = "@ModifiedBy", Value = nv.ModifiedBy },
                    new SqlParameter { ParameterName = "@ModifiedDate", Value = nv.ModifiedDate.GetDateTimeFormats()[5] },
                    new SqlParameter { ParameterName = "@OwnerID", Value = nv.OwnerID },
                    new SqlParameter { ParameterName = "@Description", Value = nv.ChucVu },
                    new SqlParameter { ParameterName = "@Sorted", Value = nv.Sorted },
                    new SqlParameter { ParameterName = "@Active", Value = nv.ConQL });
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

        public void XoaNV(string MaNV)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "EMPLOYEE_Delete";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql, new SqlParameter { ParameterName = "@Employee_ID", Value = MaNV });
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

        public DataTable GetBP(string MaBP)
        {
            try
            {
                string sql = "DEPARTMENT_Get";
                return SelectTable.SelectProcedure(sql, new SqlParameter { ParameterName = "@Department_ID", Value = MaBP });
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
