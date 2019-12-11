using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DAO
{
    public class Kho
    {

        public DataTable LoadKhoHang()
        {
            try
            {
                return SelectTable.SelectProcedure("STOCK_GetList");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadKhoHangDonGian()
        {
            try
            {
                return SelectTable.SelectQuery("select STOCK_ID,STOCK_Name from STOCK where Active = 1");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
