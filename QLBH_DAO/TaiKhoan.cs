using QLBH_DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace QLBH_DAO
{
    public class TaiKhoan
    {
        public DataTable LoadUser()
        {
            try
            {
                return SelectTable.SelectQuery("select UserName from SYS_USER");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        //public static StringBuilder encrypt(String str)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    MD5 md5 = MD5.Create();
        //    byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(str);
        //    byte[] hash = md5.ComputeHash(inputBytes);
        //    for (int i = 0; i < hash.Length; i++)
        //    {
        //        sb.Append(hash[i].ToString("x"));
        //    }
        //    return sb;
        //}

        public DataTable GetUser(string UserName, string Password)
        {
            try
            {
                string sql = "select * from SYS_USER where username = N'" + UserName + "' and password = '" + Password + "'";
                return SelectTable.SelectQuery(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void DoiMatKhau(string user_ID,string pass)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql =string.Format("UPDATE dbo.SYS_USER SET Password='{0}' WHERE UserID ='{1}'",pass,user_ID);
                CommandType type = CommandType.Text;
                dao.ExeCuteNonQuery(type, sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dao.DisConnect();
            }
        }
    }
}
