using QLBH_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DAO
{
    public class HangHoa
    {

        public DataTable LoadHangHoa()
        {
            try
            {
                return SelectTable.SelectProcedure("PRODUCT_GetList");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadHHDonGian()
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

        public DataTable LoadHHLookupEdit()
        {
            try
            {
                return SelectTable.SelectProcedure("PRODUCT_GetLookupByStock");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable GetHH(string MaHH)
        {
            try
            {
                string sql = "PRODUCT_Get";
                return SelectTable.SelectProcedure(sql, new SqlParameter { ParameterName = "@Product_ID", Value = MaHH });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ThemHangHoa(CHangHoa hh)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "PRODUCT_Insert_New";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Product_ID"             ,Value = hh.Product_ID },
                    new SqlParameter { ParameterName = "@Product_Name"		     , Value = hh.Product_Name		},
                    new SqlParameter { ParameterName = "@Product_Type_ID"	     , Value = hh.Product_Type_ID	 },
                    new SqlParameter { ParameterName = "@Product_Group_ID"	     , Value = hh.Product_Group_ID	},
                    new SqlParameter { ParameterName = "@Provider_ID"            , Value = hh.Provider_ID },
                    new SqlParameter { ParameterName = "@Barcode"			     , Value = hh.Barcode			},
                    new SqlParameter { ParameterName = "@Unit"				     , Value = hh.Unit				 },
                    new SqlParameter { ParameterName = "@Photo"				     , Value = hh.Photo				},
                    new SqlParameter { ParameterName = "@Org_Price"              , Value = hh.Org_Price },
                    new SqlParameter { ParameterName = "@Sale_Price"			 , Value = hh.Sale_Price			},
                    new SqlParameter { ParameterName = "@Retail_Price"		     , Value = hh.Retail_Price		 },
                    new SqlParameter { ParameterName = "@Customer_ID"		     , Value = hh.Customer_ID		},
                    new SqlParameter { ParameterName = "@Customer_Name"          , Value = hh.Customer_Name },
                    new SqlParameter { ParameterName = "@MinStock"			     , Value = hh.MinStock			},
                    new SqlParameter { ParameterName = "@UserID"				 , Value = hh.UserID				 },
                    new SqlParameter { ParameterName = "@Active"				 , Value = hh.Active }
                    );
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

        public void SuaHangHoa(CHangHoa hh)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "PRODUCT_Update";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@Product_ID", Value = hh.Product_ID },
                    new SqlParameter { ParameterName = "@Product_Name", Value = hh.Product_Name },
                    new SqlParameter { ParameterName = "@Product_Type_ID", Value = hh.Product_Type_ID },
                    new SqlParameter { ParameterName = "@Product_Group_ID", Value = hh.Product_Group_ID },
                    new SqlParameter { ParameterName = "@Provider_ID", Value = hh.Provider_ID },
                    new SqlParameter { ParameterName = "@Barcode", Value = hh.Barcode },
                    new SqlParameter { ParameterName = "@Unit", Value = hh.Unit },
                    new SqlParameter { ParameterName = "@Photo", Value = hh.Photo },
                    new SqlParameter { ParameterName = "@Org_Price", Value = hh.Org_Price },
                    new SqlParameter { ParameterName = "@Sale_Price", Value = hh.Sale_Price },
                    new SqlParameter { ParameterName = "@Retail_Price", Value = hh.Retail_Price },
                    new SqlParameter { ParameterName = "@Customer_ID", Value = hh.Customer_ID },
                    new SqlParameter { ParameterName = "@Customer_Name", Value = hh.Customer_Name },
                    new SqlParameter { ParameterName = "@MinStock", Value = hh.MinStock },
                    new SqlParameter { ParameterName = "@UserID", Value = hh.UserID },
                    new SqlParameter { ParameterName = "@Active", Value = hh.Active }
                    );
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

        public void XoaHangHoa(string MaHH)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "PRODUCT_Delete";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql, new SqlParameter { ParameterName = "@Product_ID", Value = MaHH });
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

        //Nhóm Hàng
        public DataTable LoadNhomHang()
        {
            try
            {
                return SelectTable.SelectProcedure("PRODUCT_GROUP_GetList");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable GetNH(string MaNH)
        {
            try
            {
                string sql = "PRODUCT_GROUP_Get";
                return SelectTable.SelectProcedure(sql, new SqlParameter { ParameterName = "@ProductGroup_ID", Value = MaNH });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ThemNhomHang(CNhomHang nh)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "PRODUCT_GROUP_Insert";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@ProductGroup_ID", Value = nh.MaNH },
                    new SqlParameter { ParameterName = "@ProductGroup_Name", Value = nh.TenNH },
                    new SqlParameter { ParameterName = "@Description", Value = nh.GhiChu },
                    new SqlParameter { ParameterName = "@Active", Value = nh.ConQL });
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

        public void SuaNhomHang(CNhomHang nh)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "PRODUCT_GROUP_Update";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@ProductGroup_ID", Value = nh.MaNH },
                    new SqlParameter { ParameterName = "@ProductGroup_Name", Value = nh.TenNH },
                    new SqlParameter { ParameterName = "@Description", Value = nh.GhiChu },
                    new SqlParameter { ParameterName = "@Active", Value = nh.ConQL });
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

        public void XoaNhomHang(string MaNH)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "PRODUCT_GROUP_Delete";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql, new SqlParameter { ParameterName = "@ProductGroup_ID", Value = MaNH });
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
