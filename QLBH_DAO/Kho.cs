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

        public DataTable GetChitietChungTuBH(string MaBH)
        {
            try
            {
                string sql = "KSP_SaleProduct_Get";
                return SelectTable.SelectProcedure(sql,new SqlParameter { ParameterName="@MaBH",Value = MaBH});
            }
            catch (SqlException ex)
            {
                throw ex;
            }   
        }

        public void ThemBanHang(List<CBanHang> bh)
        {
            Provider dao = new Provider();
            try
            {
                float SthanhTien = 0, SthanhToan = 0;
                foreach(CBanHang item in bh)
                {
                    SthanhTien += item.ThanhTien;
                    SthanhToan += item.ThanhToan;
                }
                dao.Connect(); 
                string sql = "KSP_SaleProduct_SO_Insert";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@MaBH"				          , Value = bh[0].MaBH				 },
                    new SqlParameter { ParameterName = "@NgayLap"			          , Value = bh[0].NgayLap			 },
                    new SqlParameter { ParameterName = "@MaKH"				          , Value = bh[0].MaKH				 },
                    new SqlParameter { ParameterName = "@TenKH"				          , Value = bh[0].TenKH				 },
                    new SqlParameter { ParameterName = "@NhanVienBH"			      , Value = bh[0].NhanVienBH			 },
                    new SqlParameter { ParameterName = "@DiaChi"				      , Value = bh[0].DiaChi				 },
                    new SqlParameter { ParameterName = "@GhiChu"				      , Value = bh[0].GhiChu				 },
                    new SqlParameter { ParameterName = "@DienThoai"			          , Value = bh[0].DienThoai			 },
                    new SqlParameter { ParameterName = "@SoHoaDonVat"		          , Value = bh[0].SoHoaDonVat		 },
                    new SqlParameter { ParameterName = "@DieuKhoanThanhToan"	      , Value = bh[0].DieuKhoanThanhToan	 },
                    new SqlParameter { ParameterName = "@HinhThucTT"			      , Value = bh[0].HinhThucTT			 },
                    new SqlParameter { ParameterName = "@HanTT"				          , Value = bh[0].HanTT				 },
                    new SqlParameter { ParameterName = "@NgayGiao"			          , Value = bh[0].NgayGiao			 },
                    new SqlParameter { ParameterName = "@ThanhTien"			          , Value = SthanhTien			 },
                    new SqlParameter { ParameterName = "@ThanhToan"			          , Value = SthanhToan }
                    );

                int i = 0;
                foreach(CBanHang item in bh)
                { 
                sql = "KSP_SaleProduct_SOD_Insert";
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@ID"				          , Value = item.MaBH+i.ToString()   },
                    new SqlParameter { ParameterName = "@MaBH"				          , Value = item.MaBH	             },
                    new SqlParameter { ParameterName = "@NgayLap"			          , Value = item.NgayLap			 },
                    new SqlParameter { ParameterName = "@MaKH"				          , Value = item.MaKH				 },
                    new SqlParameter { ParameterName = "@TenKH"				          , Value = item.TenKH				 },
                    new SqlParameter { ParameterName = "@NhanVienBH"			      , Value = item.NhanVienBH			 },
                    new SqlParameter { ParameterName = "@KhoXuat"			          , Value = item.KhoXuat			 },
                    new SqlParameter { ParameterName = "@DiaChi"				      , Value = item.DiaChi				 },
                    new SqlParameter { ParameterName = "@GhiChu"				      , Value = item.GhiChu				 },
                    new SqlParameter { ParameterName = "@DienThoai"			          , Value = item.DienThoai			 },
                    new SqlParameter { ParameterName = "@SoHoaDonVat"		          , Value = item.SoHoaDonVat		 },
                    new SqlParameter { ParameterName = "@SoPhieuNhapTay"		      , Value = item.SoPhieuNhapTay		 },
                    new SqlParameter { ParameterName = "@DieuKhoanThanhToan"	      , Value = item.DieuKhoanThanhToan	 },
                    new SqlParameter { ParameterName = "@HinhThucTT"			      , Value = item.HinhThucTT			 },
                    new SqlParameter { ParameterName = "@HanTT"				          , Value = item.HanTT				 },
                    new SqlParameter { ParameterName = "@NgayGiao"			          , Value = item.NgayGiao			 },
                    new SqlParameter { ParameterName = "@MaHH"				          , Value = item.MaHH				 },
                    new SqlParameter { ParameterName = "@TenHH"				          , Value = item.TenHH				 },
                    new SqlParameter { ParameterName = "@DonVi"				          , Value = item.DonVi				 },
                    new SqlParameter { ParameterName = "@SoLuong"			          , Value = item.SoLuong			 },
                    new SqlParameter { ParameterName = "@DonGia"				      , Value = item.DonGia				 },
                    new SqlParameter { ParameterName = "@ThanhTien"			          , Value = item.ThanhTien			 },
                    new SqlParameter { ParameterName = "@ChietKhauTiLe"		          , Value = item.ChietKhauTiLe		 },
                    new SqlParameter { ParameterName = "@ChietKhau"			          , Value = item.ChietKhau			 },
                    new SqlParameter { ParameterName = "@ThanhToan"			          , Value = item.ThanhToan }
                    );
                    i++;
                }
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

        public void SuaBH(List<CBanHang> bh)
        {
            Provider dao = new Provider();
            try
            {
                float SthanhTien = 0, SthanhToan = 0;
                foreach (CBanHang item in bh)
                {
                    SthanhTien += item.ThanhTien;
                    SthanhToan += item.ThanhToan;
                }
                dao.Connect();
                string sql = "KSP_SaleProduct_Delete";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery( type, sql, new SqlParameter { ParameterName = "@MaBH", Value = bh[0].MaBH });

                sql = "KSP_SaleProduct_SO_Insert";
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@MaBH", Value = bh[0].MaBH },
                    new SqlParameter { ParameterName = "@NgayLap", Value = bh[0].NgayLap },
                    new SqlParameter { ParameterName = "@MaKH", Value = bh[0].MaKH },
                    new SqlParameter { ParameterName = "@TenKH", Value = bh[0].TenKH },
                    new SqlParameter { ParameterName = "@NhanVienBH", Value = bh[0].NhanVienBH },
                    new SqlParameter { ParameterName = "@DiaChi", Value = bh[0].DiaChi },
                    new SqlParameter { ParameterName = "@GhiChu", Value = bh[0].GhiChu },
                    new SqlParameter { ParameterName = "@DienThoai", Value = bh[0].DienThoai },
                    new SqlParameter { ParameterName = "@SoHoaDonVat", Value = bh[0].SoHoaDonVat },
                    new SqlParameter { ParameterName = "@DieuKhoanThanhToan", Value = bh[0].DieuKhoanThanhToan },
                    new SqlParameter { ParameterName = "@HinhThucTT", Value = bh[0].HinhThucTT },
                    new SqlParameter { ParameterName = "@HanTT", Value = bh[0].HanTT },
                    new SqlParameter { ParameterName = "@NgayGiao", Value = bh[0].NgayGiao },
                    new SqlParameter { ParameterName = "@ThanhTien", Value = SthanhTien },
                    new SqlParameter { ParameterName = "@ThanhToan", Value = SthanhToan }
                    );

                int i = 0;
                foreach (CBanHang item in bh)
                {
                    sql = "KSP_SaleProduct_SOD_Insert";
                    dao.ExeCuteNonQuery(type, sql,
                        new SqlParameter { ParameterName = "@ID", Value = item.MaBH + i.ToString() },
                        new SqlParameter { ParameterName = "@MaBH", Value = item.MaBH },
                        new SqlParameter { ParameterName = "@NgayLap", Value = item.NgayLap },
                        new SqlParameter { ParameterName = "@MaKH", Value = item.MaKH },
                        new SqlParameter { ParameterName = "@TenKH", Value = item.TenKH },
                        new SqlParameter { ParameterName = "@NhanVienBH", Value = item.NhanVienBH },
                        new SqlParameter { ParameterName = "@KhoXuat", Value = item.KhoXuat },
                        new SqlParameter { ParameterName = "@DiaChi", Value = item.DiaChi },
                        new SqlParameter { ParameterName = "@GhiChu", Value = item.GhiChu },
                        new SqlParameter { ParameterName = "@DienThoai", Value = item.DienThoai },
                        new SqlParameter { ParameterName = "@SoHoaDonVat", Value = item.SoHoaDonVat },
                        new SqlParameter { ParameterName = "@SoPhieuNhapTay", Value = item.SoPhieuNhapTay },
                        new SqlParameter { ParameterName = "@DieuKhoanThanhToan", Value = item.DieuKhoanThanhToan },
                        new SqlParameter { ParameterName = "@HinhThucTT", Value = item.HinhThucTT },
                        new SqlParameter { ParameterName = "@HanTT", Value = item.HanTT },
                        new SqlParameter { ParameterName = "@NgayGiao", Value = item.NgayGiao },
                        new SqlParameter { ParameterName = "@MaHH", Value = item.MaHH },
                        new SqlParameter { ParameterName = "@TenHH", Value = item.TenHH },
                        new SqlParameter { ParameterName = "@DonVi", Value = item.DonVi },
                        new SqlParameter { ParameterName = "@SoLuong", Value = item.SoLuong },
                        new SqlParameter { ParameterName = "@DonGia", Value = item.DonGia },
                        new SqlParameter { ParameterName = "@ThanhTien", Value = item.ThanhTien },
                        new SqlParameter { ParameterName = "@ChietKhauTiLe", Value = item.ChietKhauTiLe },
                        new SqlParameter { ParameterName = "@ChietKhau", Value = item.ChietKhau },
                        new SqlParameter { ParameterName = "@ThanhToan", Value = item.ThanhToan }
                        );
                    i++;
                }
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
                int kq = dao.ExeCuteScalarInt(type, sql);
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
