using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DTO
{
    public class CDonViTinh
    {
        public string MaDV { get; set; }
        public string TenDV { get; set; }
        public string GhiChu { get; set; }
        public bool ConQL { get; set; }

        public CDonViTinh()
        {

        }
        public CDonViTinh(string _ma, string _ten, string _ghiChu, bool _conQL)
        {
            MaDV = _ma;
            TenDV = _ten;
            GhiChu = _ghiChu;
            ConQL = _conQL;
        }
    }
}
