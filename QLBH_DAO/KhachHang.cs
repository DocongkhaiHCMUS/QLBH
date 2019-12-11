using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DAO
{
    public class KhachHang
    {
        public DataTable LoadKH()
        {

            try
            {
                return SelectTable.SelectProcedure("CUSTOMER_GetList");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadKHDonGian()
        {
            try
            {
                return SelectTable.SelectQuery("select Customer_ID,CustomerName from CUSTOMER where Active = 1");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
