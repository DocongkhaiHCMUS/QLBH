using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DAO
{
    public class SelectTable
    {
        public static DataTable SelectQuery(string sql)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                CommandType type = CommandType.Text;
                DataTable dataTable = dao.Select(type, sql);
                return dataTable;
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

        public static DataTable SelectProcedure(string proc)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                CommandType type = CommandType.StoredProcedure;
                DataTable dataTable = dao.Select(type, proc);
                return dataTable;
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
