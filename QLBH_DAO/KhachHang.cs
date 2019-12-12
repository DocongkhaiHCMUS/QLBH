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
    public class KhachHang
    {
        public DataTable LoadKH()
        {

            try
            {
                return SelectTable.SelectProcedure("CUSTOMER_GetList");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadKHDonGian()
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

        public DataTable GetKH(string MaKH)
        {
            try
            {
                string sql = "CUSTOMER_Get";
                return SelectTable.SelectProcedure(sql, new SqlParameter { ParameterName = "@Customer_ID", Value = MaKH });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ThemKH(CKhachHang kh)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "CUSTOMER_Insert";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Customer_ID", Value = kh.MaKH },
                    new SqlParameter { ParameterName = "@CustomerName", Value = kh.TenKH },
                    new SqlParameter { ParameterName = "@Customer_Type_ID", Value = kh.LoaiKH },
                    new SqlParameter { ParameterName = "@CustomerAddress", Value = kh.DiaChi },
                    new SqlParameter { ParameterName = "@Tax", Value = kh.MaSoThue },
                    new SqlParameter { ParameterName = "@Tel", Value = kh.DienThoai },
                    new SqlParameter { ParameterName = "@Fax", Value = kh.Fax },
                    new SqlParameter { ParameterName = "@Email", Value = kh.Email },
                    new SqlParameter { ParameterName = "@Mobile", Value = kh.DiDong },
                    new SqlParameter { ParameterName = "@Website", Value = kh.Website },
                    new SqlParameter { ParameterName = "@Contact", Value = kh.LienHe },
                    new SqlParameter { ParameterName = "@NickYM", Value = kh.NickYM },
                    new SqlParameter { ParameterName = "@NickSky", Value = kh.NickSky },
                    new SqlParameter { ParameterName = "@BankAccount", Value = kh.TaiKhoan },
                    new SqlParameter { ParameterName = "@BankName", Value = kh.NganHang },
                    new SqlParameter { ParameterName = "@CreditLimit", Value = kh.GioiHanNo },
                    new SqlParameter { ParameterName = "@Discount", Value = kh.ChietKhau },
                    new SqlParameter { ParameterName = "@Customer_Group_ID", Value = kh.KhuVuc },
                    new SqlParameter { ParameterName = "@Active", Value = kh.ConQL },
                    new SqlParameter { ParameterName = "@OrderID", Value = 0 },
                    new SqlParameter { ParameterName = "@Birthday", Value = "" },
                    new SqlParameter { ParameterName = "@Barcode", Value = kh.MaKH },
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

        public void SuaKH(CKhachHang kh)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "CUSTOMER_Update";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Customer_ID", Value = kh.MaKH },
                    new SqlParameter { ParameterName = "@CustomerName", Value = kh.TenKH },
                    new SqlParameter { ParameterName = "@Customer_Type_ID", Value = kh.LoaiKH },
                    new SqlParameter { ParameterName = "@CustomerAddress", Value = kh.DiaChi },
                    new SqlParameter { ParameterName = "@Tax", Value = kh.MaSoThue },
                    new SqlParameter { ParameterName = "@Tel", Value = kh.DienThoai },
                    new SqlParameter { ParameterName = "@Fax", Value = kh.Fax },
                    new SqlParameter { ParameterName = "@Email", Value = kh.Email },
                    new SqlParameter { ParameterName = "@Mobile", Value = kh.DiDong },
                    new SqlParameter { ParameterName = "@Website", Value = kh.Website },
                    new SqlParameter { ParameterName = "@Contact", Value = kh.LienHe },
                    new SqlParameter { ParameterName = "@NickYM", Value = kh.NickYM },
                    new SqlParameter { ParameterName = "@NickSky", Value = kh.NickSky },
                    new SqlParameter { ParameterName = "@BankAccount", Value = kh.TaiKhoan },
                    new SqlParameter { ParameterName = "@BankName", Value = kh.NganHang },
                    new SqlParameter { ParameterName = "@CreditLimit", Value = kh.GioiHanNo },
                    new SqlParameter { ParameterName = "@Discount", Value = kh.ChietKhau },
                    new SqlParameter { ParameterName = "@Customer_Group_ID", Value = kh.KhuVuc },
                    new SqlParameter { ParameterName = "@Active", Value = kh.ConQL },
                    new SqlParameter { ParameterName = "@OrderID", Value = 0 },
                    new SqlParameter { ParameterName = "@Birthday", Value = "" },
                    new SqlParameter { ParameterName = "@Barcode", Value = kh.MaKH },
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

        public void XoaKH(string MaKH)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "CUSTOMER_Delete";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql, new SqlParameter { ParameterName = "@Customer_ID", Value = MaKH });
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
