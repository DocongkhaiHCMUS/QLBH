using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DAO
{
    public class PhanQuyen
    {
        public DataTable LoadPhanQuyen(string vaitro)
        {
            try
            {
                string sql = string.Format("select * from K_Permision_Detail where PER_ID ='{0}'",vaitro);
                return SelectTable.SelectQuery(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadPhanQuyen(string vaitro,string form)
        {
            try
            {
                string sql = string.Format("select * from K_Permision_Detail where PER_ID ='{0}' and Object_ID ='{1}'"
                    , vaitro,form);
                return SelectTable.SelectQuery(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
