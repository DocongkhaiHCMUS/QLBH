using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DTO
{
    public class CBanHang
    {
        public string   MaBH                            {get;set;}
        public DateTime NgayLap			                {get;set;}
        public string   MaKH				            {get;set;}
        public string   TenKH				            {get;set;}
        public string   NhanVienBH			            {get;set;}
        public string   KhoXuat			                {get;set;}
        public string   DiaChi				            {get;set;}
        public string   GhiChu				            {get;set;}
        public string   DienThoai			            {get;set;}
        public string   SoHoaDonVat		                {get;set;}
        public string   SoPhieuNhapTay		            {get;set;}
        public string   DieuKhoanThanhToan	            {get;set;}
        public string   HinhThucTT			            {get;set;}
        public DateTime HanTT				            {get;set;}
        public DateTime NgayGiao			            {get;set;}
        public string   MaHH				            {get;set;}
        public string   TenHH				            {get;set;}
        public string   DonVi				            {get;set;}
        public float    SoLuong			                {get;set;}
        public float    DonGia				            {get;set;}
        public float    ThanhTien			            {get;set;}
        public float    ChietKhauTiLe		            {get;set;}
        public float    ChietKhau			            {get;set;}
        public float    ThanhToan                       { get; set; }
        
        

        public CBanHang() 
        {
            
        }

        public CBanHang
            (
                string   _MaBH                     ,
                DateTime _NgayLap			      ,
                string   _MaKH				      ,
                string   _TenKH				      ,
                string   _NhanVienBH			      ,
                string   _KhoXuat			      ,
                string   _DiaChi				      ,
                string   _GhiChu				      ,
                string   _DienThoai			      ,
                string   _SoHoaDonVat		      ,
                string   _SoPhieuNhapTay		      ,
                string   _DieuKhoanThanhToan	      ,
                string   _HinhThucTT			      ,
                DateTime _HanTT				      ,
                DateTime _NgayGiao			      ,
                string   _MaHH				      ,
                string   _TenHH                    ,
                string   _DonVi                      ,
                float    _SoLuong			      ,
                float    _DonGia				      ,
                float    _ThanhTien			      ,
                float    _ChietKhauTiLe		      ,
                float    _ChietKhau			      ,
                float    _ThanhToan           
            )
        {
            MaBH                   =        _MaBH                      ;
            NgayLap                =        _NgayLap			          ;
            MaKH                   =        _MaKH				      ;
            TenKH                  =        _TenKH				      ;
            NhanVienBH             =        _NhanVienBH		          ;
            KhoXuat                =        _KhoXuat			          ;
            DiaChi                 =        _DiaChi			          ;
            GhiChu                 =        _GhiChu			          ;
            DienThoai              =        _DienThoai			      ;
            SoHoaDonVat            =        _SoHoaDonVat		          ;
            SoPhieuNhapTay         =        _SoPhieuNhapTay	          ;
            DieuKhoanThanhToan     =        _DieuKhoanThanhToan        ;
            HinhThucTT             =        _HinhThucTT		          ;
            HanTT                  =        _HanTT				      ;
            NgayGiao               =        _NgayGiao			      ;
            MaHH                   =        _MaHH				      ;
            TenHH                  =        _TenHH                     ;
            DonVi                  =        _DonVi                     ;
            SoLuong                =        _SoLuong			          ;
            DonGia                 =        _DonGia			          ;
            ThanhTien              =        _ThanhTien			      ;
            ChietKhauTiLe          =        _ChietKhauTiLe		      ;
            ChietKhau              =        _ChietKhau			      ;
            ThanhToan              =        _ThanhToan;

        }
    }
}
