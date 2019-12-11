using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DTO
{
    public class CKhuVuc
    {
        public string MaKV { get; set; }
        public string TenKV { get; set; }
        public string GhiChu { get; set; }
        public bool ConQL { get; set; }

        public CKhuVuc()
        {

        }
        public CKhuVuc(string _ma,string _ten,string _ghiChu,bool _conQL)
        {
            MaKV = _ma;
            TenKV = _ten;
            GhiChu = _ghiChu;
            ConQL = _conQL;
        }
    }
}
