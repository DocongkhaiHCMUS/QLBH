using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DTO
{
    public class CNhomHang
    {
        public string MaNH { get; set; }
        public string TenNH { get; set; }
        public string GhiChu { get; set; }
        public bool ConQL { get; set; }

        public CNhomHang()
        {

        }
        public CNhomHang(string _ma, string _ten, string _ghiChu, bool _conQL)
        {
            MaNH = _ma;
            TenNH = _ten;
            GhiChu = _ghiChu;
            ConQL = _conQL;
        }
    }
}
