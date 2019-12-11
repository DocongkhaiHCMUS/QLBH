using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DAO
{
    public class NhaCungCap
    {
        public DataTable LoadNhaCC()
        {
            try
            {
                return SelectTable.SelectQuery("PROVIDER_GetList");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
