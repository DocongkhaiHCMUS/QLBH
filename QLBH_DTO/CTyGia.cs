using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DTO
{
    public class CTyGia
    {
        public string MaTienTe { get; set; }
        public string TenTienTe { get; set; }
        public float TyGia { get; set; }
        public bool ConQL { get; set; }

        public CTyGia()
        {

        }
        public CTyGia(string _ma, string _ten, float _tygia, bool _conQL)
        {
            MaTienTe = _ma;
            TenTienTe = _ten;
            TyGia = _tygia;
            ConQL = _conQL;
        }
    }
}
