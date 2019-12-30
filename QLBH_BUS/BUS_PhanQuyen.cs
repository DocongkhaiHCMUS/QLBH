using QLBH_DAO;
using QLBH_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_BUS
{
    public class BUS_PhanQuyen
    {
        public static DataTable LoadPhanQuyenALL()
        {
            try
            {
                PhanQuyen dao = new PhanQuyen();
                return dao.LoadPhanQuyenALL();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static DataTable LoadUser()
        {
            try
            {
                PhanQuyen dao = new PhanQuyen();
                return dao.LoadUser();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static DataTable LoadPermision()
        {
            try
            {
                PhanQuyen dao = new PhanQuyen();
                return dao.LoadPermision();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void XoaUser(string Ma)
        {
            try
            {
                PhanQuyen dao = new PhanQuyen();
                dao.XoaNguoiDung(Ma);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void XoaVaiTro(string Ma)
        {
            try
            {
                PhanQuyen dao = new PhanQuyen();
                dao.XoaVaiTro(Ma);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void SuaUser(CUser us)
        {
            try
            {
                PhanQuyen dao = new PhanQuyen();
                dao.SuaNguoiDung(us);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void ThemUser(CUser us)
        {
            try
            {
                PhanQuyen dao = new PhanQuyen();
                dao.ThemNguoiDung(us);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        public static void SuaVaiTro(CQuyen q,List<CQuyenHan> qh)
        {
            try
            {
                PhanQuyen dao = new PhanQuyen();
                dao.SuaVaiTro(q,qh);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void ThemVaiTro(CQuyen q, List<CQuyenHan> qh)
        {
            try
            {
                PhanQuyen dao = new PhanQuyen();
                dao.ThemVaiTro(q, qh);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static DataTable LoadPhanQuyen(string vaitro)
        {
            try
            {
                PhanQuyen dao = new PhanQuyen();
                return dao.LoadPhanQuyen(vaitro);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static DataTable LoadPhanQuyen(string vaitro,string form)
        {
            try
            {
                PhanQuyen dao = new PhanQuyen();
                return dao.LoadPhanQuyen(vaitro,form);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
