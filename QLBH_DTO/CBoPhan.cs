using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DTO
{
    public class CBoPhan
    {
        public string MaBP { get; set; }
        public string TenBP { get; set; }
        public string GhiChu { get; set; }
        public bool ConQL { get; set; }

        public CBoPhan()
        {

        }
        public CBoPhan(string _ma, string _ten, string _ghiChu, bool _conQL)
        {
            MaBP = _ma;
            TenBP = _ten;
            GhiChu = _ghiChu;
            ConQL = _conQL;
        }
    }
}
