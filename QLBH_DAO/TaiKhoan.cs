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

        public static StringBuilder encrypt(String str)
        {
            StringBuilder sb = new StringBuilder();
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] hash = md5.ComputeHash(inputBytes);
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x"));
            }
            return sb;
        }

        public DataTable GetUser(string UserName, string Password)
        {
            try
            {
                string sql = "select * from SYS_USER where username = '" + UserName + "' and password = '" + encrypt(Password) + "'";
                return SelectTable.SelectQuery(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
