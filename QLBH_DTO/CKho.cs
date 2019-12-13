using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DTO
{
    public class CKho
    {
        public string MaKho { get; set; }
        public string TenKho { get; set; }
        public string LienHe { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public string Fax { get; set; }
        public string DiDong { get; set; }
        public string NguoiQuanLy { get; set; }
        public string DienGiai { get; set; }
        public bool ConQL { get; set; }

        public CKho()
        {

        }

        public CKho(string _MaKho, string _TenKho, string _LienHe, string _DiaChi, string _Email, string _DienThoai,
                    string _Fax, string _DiDong, string _NguoiQuanLy, string _DienGiai, bool _ConQL)
        {
            MaKho       = _MaKho;
            TenKho      = _TenKho;
            LienHe      = _LienHe;
            DiaChi      = _DiaChi;
            Email       = _Email;
            DienThoai   = _DienThoai;
            Fax         = _Fax;
            DiDong      = _DiDong;
            NguoiQuanLy = _NguoiQuanLy;
            DienGiai    = _DienGiai;
            ConQL       = _ConQL;
        }
    }
}