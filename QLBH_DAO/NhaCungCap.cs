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
    public class NhaCungCap
    {
        public DataTable LoadNhaCC()
        {
            try
            {
                return SelectTable.SelectQuery("PROVIDER_GetList");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable GetNCC(string MaNCC)
        {
            try
            {
                string sql = "PROVIDER_Get";
                return SelectTable.SelectProcedure(sql, new SqlParameter { ParameterName = "@Customer_ID", Value = MaNCC });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ThemNCC(CNhaCC ncc)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "PROVIDER_Insert";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Customer_ID", Value = ncc.MaNCC },
                    new SqlParameter { ParameterName = "@CustomerName", Value = ncc.TenNCC },
                    new SqlParameter { ParameterName = "@Customer_Type_ID", Value = 0 },
                    new SqlParameter { ParameterName = "@CustomerAddress", Value = ncc.DiaChi },
                    new SqlParameter { ParameterName = "@Tax", Value = ncc.MaSoThue },
                    new SqlParameter { ParameterName = "@Tel", Value = ncc.DienThoai },
                    new SqlParameter { ParameterName = "@Fax", Value = ncc.Fax },
                    new SqlParameter { ParameterName = "@Email", Value = ncc.Email },
                    new SqlParameter { ParameterName = "@Mobile", Value = ncc.DiDong },
                    new SqlParameter { ParameterName = "@Website", Value = ncc.Website },
                    new SqlParameter { ParameterName = "@Contact", Value = ncc.LienHe },
                    new SqlParameter { ParameterName = "@NickYM", Value = "" },
                    new SqlParameter { ParameterName = "@NickSky", Value = "" },
                    new SqlParameter { ParameterName = "@BankAccount", Value = ncc.TaiKhoan },
                    new SqlParameter { ParameterName = "@BankName", Value = ncc.NganHang },
                    new SqlParameter { ParameterName = "@CreditLimit", Value = ncc.GioiHanNo },
                    new SqlParameter { ParameterName = "@Discount", Value = ncc.ChietKhau },
                    new SqlParameter { ParameterName = "@Customer_Group_ID", Value = ncc.KhuVuc },
                    new SqlParameter { ParameterName = "@Active", Value = ncc.ConQL },
                    new SqlParameter { ParameterName = "@OrderID", Value = 0 },
                    new SqlParameter { ParameterName = "@Birthday", Value = "" },
                    new SqlParameter { ParameterName = "@Barcode", Value = ncc.MaNCC },
                    new SqlParameter { ParameterName = "@Position", Value = "" },
                    new SqlParameter { ParameterName = "@Area", Value = "" },
                    new SqlParameter { ParameterName = "@District", Value = "" },
                    new SqlParameter { ParameterName = "@Contry", Value = "" },
                    new SqlParameter { ParameterName = "@City", Value = "" },
                    new SqlParameter { ParameterName = "@Description", Value = "" });
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

        public void SuaNCC(CNhaCC ncc)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "PROVIDER_Update";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Customer_ID", Value = ncc.MaNCC },
                    new SqlParameter { ParameterName = "@CustomerName", Value = ncc.TenNCC },
                    new SqlParameter { ParameterName = "@Customer_Type_ID", Value = 0 },
                    new SqlParameter { ParameterName = "@CustomerAddress", Value = ncc.DiaChi },
                    new SqlParameter { ParameterName = "@Tax", Value = ncc.MaSoThue },
                    new SqlParameter { ParameterName = "@Tel", Value = ncc.DienThoai },
                    new SqlParameter { ParameterName = "@Fax", Value = ncc.Fax },
                    new SqlParameter { ParameterName = "@Email", Value = ncc.Email },
                    new SqlParameter { ParameterName = "@Mobile", Value = ncc.DiDong },
                    new SqlParameter { ParameterName = "@Website", Value = ncc.Website },
                    new SqlParameter { ParameterName = "@Contact", Value = ncc.LienHe },
                    new SqlParameter { ParameterName = "@NickYM", Value = "" },
                    new SqlParameter { ParameterName = "@NickSky", Value = "" },
                    new SqlParameter { ParameterName = "@BankAccount", Value = ncc.TaiKhoan },
                    new SqlParameter { ParameterName = "@BankName", Value = ncc.NganHang },
                    new SqlParameter { ParameterName = "@CreditLimit", Value = ncc.GioiHanNo },
                    new SqlParameter { ParameterName = "@Discount", Value = ncc.ChietKhau },
                    new SqlParameter { ParameterName = "@Customer_Group_ID", Value = ncc.KhuVuc },
                    new SqlParameter { ParameterName = "@Active", Value = ncc.ConQL },
                    new SqlParameter { ParameterName = "@OrderID", Value = 0 },
                    new SqlParameter { ParameterName = "@Birthday", Value = "" },
                    new SqlParameter { ParameterName = "@Barcode", Value = ncc.MaNCC },
                    new SqlParameter { ParameterName = "@Position", Value = "" },
                    new SqlParameter { ParameterName = "@Area", Value = "" },
                    new SqlParameter { ParameterName = "@District", Value = "" },
                    new SqlParameter { ParameterName = "@Contry", Value = "" },
                    new SqlParameter { ParameterName = "@City", Value = "" },
                    new SqlParameter { ParameterName = "@Description", Value = "" });
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

        public void XoaNCC(string MaNCC)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "PROVIDER_Delete";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql, new SqlParameter { ParameterName = "@Customer_ID", Value = MaNCC });
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
