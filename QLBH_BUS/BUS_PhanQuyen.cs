using QLBH_DAO;
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
