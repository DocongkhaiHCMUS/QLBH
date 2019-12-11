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
    public class BUS_DonViTinh
    {

        public static DataTable GetDVT()
        {
            try
            {
                DonViTinh dao = new DonViTinh();
                return dao.LoadDVT();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool KiemTraDV(string MaDV)
        {
            try
            {
                DonViTinh dao = new DonViTinh();
                DataTable table = dao.GetDV(MaDV);
                if (table.Rows.Count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public static DataTable GetDVTDonGian()
        {
            try
            {
                DonViTinh dao = new DonViTinh();
                return dao.LoadDVTDonGian();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void ThemDV(CDonViTinh dv)
        {
            try
            {
                DonViTinh dao = new DonViTinh();
                dao.ThemDV(dv);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void SuaDV(CDonViTinh dv)
        {
            try
            {
                DonViTinh dao = new DonViTinh();
                dao.SuaDV(dv);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void XoaDV(string MaDV)
        {
            try
            {
                DonViTinh dao = new DonViTinh();
                dao.XoaDV(MaDV);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
