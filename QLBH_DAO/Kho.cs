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
    public class Kho
    {
        public DataTable LoadKhoHang()
        {
            try
            {
                return SelectTable.SelectProcedure("STOCK_GetList");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadKhoHangDonGian()
        {
            try
            {
                return SelectTable.SelectQuery("select STOCK_ID,STOCK_Name from STOCK where Active = 1");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable GetKho(string MaKho)
        {
            try
            {
                string sql = "STOCK_Get";
                return SelectTable.SelectProcedure(sql, new SqlParameter { ParameterName = "@Stock_ID", Value = MaKho });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ThemKho(CKho kho)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "STOCK_Insert";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Stock_ID", Value = kho.MaKho },
                    new SqlParameter { ParameterName = "@Stock_Name", Value = kho.TenKho },
                    new SqlParameter { ParameterName = "@Contact", Value = kho.LienHe },
                    new SqlParameter { ParameterName = "@Address", Value = kho.DiaChi },
                    new SqlParameter { ParameterName = "@Email", Value = kho.Email },
                    new SqlParameter { ParameterName = "@Telephone", Value = kho.DienThoai },
                    new SqlParameter { ParameterName = "@Fax", Value = kho.Fax },
                    new SqlParameter { ParameterName = "@Mobi", Value = kho.DiDong },
                    new SqlParameter { ParameterName = "@Manager", Value = kho.NguoiQuanLy },
                    new SqlParameter { ParameterName = "@Description", Value = kho.DienGiai },
                    new SqlParameter { ParameterName = "@Active", Value = kho.ConQL });                                             		
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

        public void SuaKho(CKho kho)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "STOCK_Update";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Stock_ID", Value = kho.MaKho },
                    new SqlParameter { ParameterName = "@Stock_Name", Value = kho.TenKho },
                    new SqlParameter { ParameterName = "@Contact", Value = kho.LienHe },
                    new SqlParameter { ParameterName = "@Address", Value = kho.DiaChi },
                    new SqlParameter { ParameterName = "@Email", Value = kho.Email },
                    new SqlParameter { ParameterName = "@Telephone", Value = kho.DienThoai },
                    new SqlParameter { ParameterName = "@Fax", Value = kho.Fax },
                    new SqlParameter { ParameterName = "@Mobi", Value = kho.DiDong },
                    new SqlParameter { ParameterName = "@Manager", Value = kho.NguoiQuanLy },
                    new SqlParameter { ParameterName = "@Description", Value = kho.DienGiai },
                    new SqlParameter { ParameterName = "@Active", Value = kho.ConQL });
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

        public void XoaKho(string maKho)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "STOCK_Delete";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql, new SqlParameter { ParameterName = "@Stock_ID", Value = maKho });
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

        //Tồn kho

        public DataTable GetTonKhoLookUp()
        {
            try
            {
                string sql = "INVENTORY_DETAIL_GetList";
                return SelectTable.SelectProcedure(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        //public void ThemBanHang()
        //{
        //    Provider dao = new Provider();
        //    try
        //    {
        //        dao.Connect();
        //        string sql = "STOCK_Insert";
        //        CommandType type = CommandType.StoredProcedure;
        //        dao.ExeCuteNonQuery(type, sql,
        //            new SqlParameter { ParameterName = "@Stock_ID", Value = kho.MaKho },
        //            new SqlParameter { ParameterName = "@Stock_Name", Value = kho.TenKho },
        //            new SqlParameter { ParameterName = "@Contact", Value = kho.LienHe },
        //            new SqlParameter { ParameterName = "@Address", Value = kho.DiaChi },
        //            new SqlParameter { ParameterName = "@Email", Value = kho.Email },
        //            new SqlParameter { ParameterName = "@Telephone", Value = kho.DienThoai },
        //            new SqlParameter { ParameterName = "@Fax", Value = kho.Fax },
        //            new SqlParameter { ParameterName = "@Mobi", Value = kho.DiDong },
        //            new SqlParameter { ParameterName = "@Manager", Value = kho.NguoiQuanLy },
        //            new SqlParameter { ParameterName = "@Description", Value = kho.DienGiai },
        //            new SqlParameter { ParameterName = "@Active", Value = kho.ConQL });
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dao.DisConnect();
        //    }
        //}

        public DataTable GetHanhDong()
        {
            try
            {
                string sql = "select * from INVENTORY_ACTION";
                return SelectTable.SelectQuery(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
