﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DTO
{
    public class CKhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public bool LoaiKH { get; set; }
        public string KhuVuc { get; set; }
        public string DiaChi { get; set; }
        public string MaSoThue { get; set; }
        public string DienThoai { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string DiDong { get; set; }
        public string Website { get; set; }
        public string LienHe { get; set; }
        public string NickYM { get; set; }
        public string NickSky { get; set; }
        public string TaiKhoan { get; set; }
        public string NganHang { get; set; }
        public float GioiHanNo { get; set; }
        public float ChietKhau { get; set; }
        public bool ConQL { get; set; }

        public CKhachHang()
        {

        }

        public CKhachHang(string _MaKH, string _TenKH, bool _LoaiKH, string _KhuVuc, string _DiaChi, string _MaSoThue,
                          string _DienThoai, string _Fax, string _Email, string _DiDong, string _Website, string _LienHe,
                          string _NickYM, string _NickSky, string _TaiKhoan, string _NganHang, float _GioiHanNo, float _ChietKhau,
                          bool _ConQL)
        {
            MaKH = _MaKH;
            TenKH = _TenKH;
            LoaiKH = _LoaiKH;
            KhuVuc = _KhuVuc;
            DiaChi = _DiaChi;
            MaSoThue = _MaSoThue;
            DienThoai = _DienThoai;
            Fax = _Fax;
            Email = _Email;
            DiDong = _DiDong;
            Website = _Website;
            LienHe = _LienHe;
            NickYM = _NickYM;
            NickSky = _NickSky;
            TaiKhoan = _TaiKhoan;
            NganHang = _NganHang;
            GioiHanNo = _GioiHanNo;
            ChietKhau = _ChietKhau;
            ConQL = _ConQL;
        }
    }
}