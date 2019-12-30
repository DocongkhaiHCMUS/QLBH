using QLBH_BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAQLBH_Devexpress
{
    public class QuyenNguoiDung
    {
        public static string vaitro         { get; set; }

        public static bool Xem             { get; set; }
        public static bool Them             { get; set; }
        public static bool Xoa             { get; set; }
        public static bool Sua             { get; set; }
        public static bool ConHoatDong     { get; set; }

        public static DataTable LayQuyenNguoiDung()
        {
            try
            {
                return BUS_PhanQuyen.LoadPhanQuyen(vaitro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void LayQuyenNguoiDungTheoChucNang(string form)
        {
            try
            {
                DataTable table = BUS_PhanQuyen.LoadPhanQuyen(vaitro, form);


                Xem = bool.Parse(table.Rows[0]["AllowView"].ToString());
                Sua = bool.Parse(table.Rows[0]["AllowEdit"].ToString());
                Xoa = bool.Parse(table.Rows[0]["AllowDelete"].ToString());
                Them = bool.Parse(table.Rows[0]["AllowAdd"].ToString());
                ConHoatDong = bool.Parse(table.Rows[0]["Active"].ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
