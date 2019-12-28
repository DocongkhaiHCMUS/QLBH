using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DTO
{
    public class CCongNo
    {
        public string        MaPT            {get;set;}
        public DateTime      NgayLap         {get;set;}
        public string        MaBH            {get;set;}
        public string        MaKH            {get;set;}
        public string        TenKH           {get;set;}
        public decimal       SoTienTra       {get;set;}
        public decimal       SoTien          {get;set;}
        public decimal       SoTienConNo     { get; set; }
        public string        TaoBoi          {get;set;}
        public string        MaNV            {get;set;}
        public string        GhiChu          { get; set; }
        public CCongNo() { }
        public CCongNo
            (
                string    _MaPT         ,
                DateTime  _NgayLap      ,
                string    _MaBH         ,
                string    _MaKH         ,
                string    _TenKH        ,
                decimal   _SoTienTra    ,
                string    _TaoBoi       ,
                string    _MaNV         ,
                string    _GhiChu       
            )
        {
            MaPT          =         _MaPT       ;
            NgayLap       =         _NgayLap    ;
            MaBH          =         _MaBH       ;
            MaKH          =         _MaKH       ;
            TenKH         =         _TenKH      ;
            SoTienTra     =         _SoTienTra  ;
            TaoBoi        =         _TaoBoi     ;
            MaNV          =         _MaNV       ;
            GhiChu        =         _GhiChu;
        }
    }
}
