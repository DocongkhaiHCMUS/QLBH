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

        public DataTable LayTonKhoLookUp()
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

        public DataTable ChitietChungTuBH()
        {
            try
            {
                string sql = "STOCK_OUTWARD_DETAIL_GetList";
                return SelectTable.SelectProcedure(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LayChungTuBH()
        {
            try
            {
                string sql = "STOCK_OUTWARD_GetList";
                return SelectTable.SelectProcedure(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ThemBanHang(CBanHang bh)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "KSP_SaleProduct_Insert";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@MaBH"				          , Value = bh.MaBH				 },
                    new SqlParameter { ParameterName = "@NgayLap"			          , Value = bh.NgayLap			 },
                    new SqlParameter { ParameterName = "@MaKH"				          , Value = bh.MaKH				 },
                    new SqlParameter { ParameterName = "@TenKH"				          , Value = bh.TenKH				 },
                    new SqlParameter { ParameterName = "@NhanVienBH"			      , Value = bh.NhanVienBH			 },
                    new SqlParameter { ParameterName = "@KhoXuat"			          , Value = bh.KhoXuat			 },
                    new SqlParameter { ParameterName = "@DiaChi"				      , Value = bh.DiaChi				 },
                    new SqlParameter { ParameterName = "@GhiChu"				      , Value = bh.GhiChu				 },
                    new SqlParameter { ParameterName = "@DienThoai"			          , Value = bh.DienThoai			 },
                    new SqlParameter { ParameterName = "@SoHoaDonVat"		          , Value = bh.SoHoaDonVat		 },
                    new SqlParameter { ParameterName = "@SoPhieuNhapTay"		      , Value = bh.SoPhieuNhapTay		 },
                    new SqlParameter { ParameterName = "@DieuKhoanThanhToan"	      , Value = bh.DieuKhoanThanhToan	 },
                    new SqlParameter { ParameterName = "@HinhThucTT"			      , Value = bh.HinhThucTT			 },
                    new SqlParameter { ParameterName = "@HanTT"				          , Value = bh.HanTT				 },
                    new SqlParameter { ParameterName = "@NgayGiao"			          , Value = bh.NgayGiao			 },
                    new SqlParameter { ParameterName = "@MaHH"				          , Value = bh.MaHH				 },
                    new SqlParameter { ParameterName = "@TenHH"				          , Value = bh.TenHH				 },
                    new SqlParameter { ParameterName = "@DonVi"				          , Value = bh.DonVi				 },
                    new SqlParameter { ParameterName = "@SoLuong"			          , Value = bh.SoLuong			 },
                    new SqlParameter { ParameterName = "@DonGia"				      , Value = bh.DonGia				 },
                    new SqlParameter { ParameterName = "@ThanhTien"			          , Value = bh.ThanhTien			 },
                    new SqlParameter { ParameterName = "@ChietKhauTiLe"		          , Value = bh.ChietKhauTiLe		 },
                    new SqlParameter { ParameterName = "@ChietKhau"			          , Value = bh.ChietKhau			 },
                    new SqlParameter { ParameterName = "@ThanhToan"			          , Value = bh.ThanhToan }
                    );
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

        public void SuaBH(CBanHang bh)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "INVENTORY_DETAIL_Update";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@MaBH", Value = bh.MaBH },
                    new SqlParameter { ParameterName = "@NgayLap", Value = bh.NgayLap },
                    new SqlParameter { ParameterName = "@MaKH", Value = bh.MaKH },
                    new SqlParameter { ParameterName = "@TenKH", Value = bh.TenKH },
                    new SqlParameter { ParameterName = "@NhanVienBH", Value = bh.NhanVienBH },
                    new SqlParameter { ParameterName = "@KhoXuat", Value = bh.KhoXuat },
                    new SqlParameter { ParameterName = "@DiaChi", Value = bh.DiaChi },
                    new SqlParameter { ParameterName = "@GhiChu", Value = bh.GhiChu },
                    new SqlParameter { ParameterName = "@DienThoai", Value = bh.DienThoai },
                    new SqlParameter { ParameterName = "@SoHoaDonVat", Value = bh.SoHoaDonVat },
                    new SqlParameter { ParameterName = "@SoPhieuNhapTay", Value = bh.SoPhieuNhapTay },
                    new SqlParameter { ParameterName = "@DieuKhoanThanhToan", Value = bh.DieuKhoanThanhToan },
                    new SqlParameter { ParameterName = "@HinhThucTT", Value = bh.HinhThucTT },
                    new SqlParameter { ParameterName = "@HanTT", Value = bh.HanTT },
                    new SqlParameter { ParameterName = "@NgayGiao", Value = bh.NgayGiao },
                    new SqlParameter { ParameterName = "@MaHH", Value = bh.MaHH },
                    new SqlParameter { ParameterName = "@TenHH", Value = bh.TenHH },
                    new SqlParameter { ParameterName = "@DonVi", Value = bh.DonVi },
                    new SqlParameter { ParameterName = "@SoLuong", Value = bh.SoLuong },
                    new SqlParameter { ParameterName = "@DonGia", Value = bh.DonGia },
                    new SqlParameter { ParameterName = "@ThanhTien", Value = bh.ThanhTien },
                    new SqlParameter { ParameterName = "@ChietKhauTiLe", Value = bh.ChietKhauTiLe },
                    new SqlParameter { ParameterName = "@ChietKhau", Value = bh.ChietKhau },
                    new SqlParameter { ParameterName = "@ThanhToan", Value = bh.ThanhToan }
                    );
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

        public void XoaBH(string MaBH)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "KSP_SaleProduct_Delete";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql, new SqlParameter { ParameterName = "@MaBH", Value = MaBH });
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

        public int GetMaxID()
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "select Max(ID) from INVENTORY_DETAIL";
                CommandType type = CommandType.Text;
                int kq = dao.ExeCuteScalar(type, sql);
                return kq;
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
