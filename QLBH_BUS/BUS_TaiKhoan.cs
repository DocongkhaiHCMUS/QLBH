using System;
using System.Data;
using System.Data.SqlClient;
using QLBH_DAO;

namespace QLBH_BUS
{
    public class BUS_TaiKhoan
    {
        public static DataTable LayTenUser()
        {
            try
            {
                TaiKhoan dao = new TaiKhoan();
                return dao.LoadUser();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
        public static string getInfo(string UserName,string Password,string PropertyName)
        {
            string rs = "";
            try
            {
                TaiKhoan dao = new TaiKhoan();
                DataTable table = dao.GetUser(UserName, Password);
                if(table != null)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        rs = dr[PropertyName].ToString();
                    }
                }
            }
            catch (Exception)
            {
                rs = "";
            }
            return rs;
        }

        public static void DoiMatKhau(string userId,string pass)
        {
            try
            {
                TaiKhoan dao = new TaiKhoan();
                dao.DoiMatKhau(userId,pass);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
