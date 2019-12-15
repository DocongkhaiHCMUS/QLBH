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
    public class BUS_HangHoa
    {
        public static DataTable LayHangHoa()
        {
            try
            {
                HangHoa hh = new HangHoa();
                DonViTinh dv = new DonViTinh();
                Kho k = new Kho();
                DataTable dataTableHH = hh.LoadHangHoa();
                DataTable dataTableDV = dv.LoadDVTDonGian();
                DataTable dataTableKho = k.LoadKhoHang();

                var results = from table1 in dataTableHH.AsEnumerable()
                              join table2 in dataTableDV.AsEnumerable() on (string)table1["Unit"] equals (string)table2["UNIT_ID"]
                              join table3 in dataTableKho.AsEnumerable() on (string)table1["Provider_ID"] equals (string)table3["Stock_ID"]
                              select new 
                              {
                                  Product_ID = table1["Product_ID"].ToString(),
                                  Product_Name = table1["Product_Name"].ToString(),
                                  ProductGroup_Name = table1["ProductGroup_Name"].ToString(),
                                  Unit = table2["UNIT_Name"].ToString(),
                                  Org_Price = float.Parse(table1["Org_Price"].ToString()),
                                  Sale_Price = float.Parse(table1["Sale_Price"].ToString()),
                                  Retail_Price = float.Parse(table1["Retail_Price"].ToString()),
                                  LimitOrders = float.Parse(table1["LimitOrders"].ToString()),
                                  Product_Type_ID = table1["Product_Type_ID"].ToString(),
                                  Stock_ID = table3["Stock_Name"].ToString(),
                                  Active = bool.Parse(table1["Active"].ToString())

                              };

                DataTable rs = new DataTable();
                rs.Columns.Add("Product_ID");
                rs.Columns.Add("Product_Name");
                rs.Columns.Add("ProductGroup_Name");
                rs.Columns.Add("Unit");
                rs.Columns.Add("Org_Price");
                rs.Columns.Add("Sale_Price");
                rs.Columns.Add("Retail_Price");
                rs.Columns.Add("LimitOrders");
                rs.Columns.Add("Product_Type_ID");
                rs.Columns.Add("Stock_Name", typeof(string));
                rs.Columns.Add("Active",typeof(bool));

                foreach(var item in results)
                {
                    rs.Rows.Add(item.Product_ID,item.Product_Name,item.ProductGroup_Name,item.Unit,item.Org_Price,
                        item.Sale_Price,item.Retail_Price,item.LimitOrders,item.Product_Type_ID,item.Stock_ID,item.Active);
                }

                foreach (DataRow row in rs.Rows)
                {
                        if(float.Parse(row["Product_Type_ID"].ToString()) == 0)
                        {
                            row.SetField("Product_Type_ID", "Hàng hóa");
                        }
                }

                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable LayHangHoaLookupEdit()
        {
            try 
            {
                HangHoa hh = new HangHoa();
                return hh.LoadHHLookupEdit();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static DataRow TimHH(string MaHH)
        {
            DataRow rs;
            try
            {
                HangHoa dao = new HangHoa();
                DataTable table = dao.GetHH(MaHH);
                rs = table.Rows[0];
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ThemHH(CHangHoa hh)
        {
            try
            {
                HangHoa dao = new HangHoa();
                dao.ThemHangHoa(hh);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void SuaHh(CHangHoa hh)
        {
            try
            {
                HangHoa dao = new HangHoa();
                dao.SuaHangHoa(hh);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void XoaHH(string MaHH)
        {
            try
            {
                HangHoa dao = new HangHoa();
                dao.XoaHangHoa(MaHH);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool KiemTraHH(string MaHH)
        {
            try
            {
                HangHoa dao = new HangHoa();
                DataTable table = dao.GetHH(MaHH);
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
        //Nhóm hàng

        public static DataTable LayNhomHang()
        {
            try
            {
                HangHoa hh = new HangHoa();
                return hh.LoadNhomHang();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ThemNH(CNhomHang nh)
        {
            try
            {
                HangHoa dao = new HangHoa();
                dao.ThemNhomHang(nh);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void SuaNH(CNhomHang nh)
        {
            try
            {
                HangHoa dao = new HangHoa();
                dao.SuaNhomHang(nh);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void XoaNH(string MaNH)
        {
            try
            {
                HangHoa dao = new HangHoa();
                dao.XoaNhomHang(MaNH);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool KiemTraNH(string MaNH)
        {
            try
            {
                HangHoa dao = new HangHoa();
                DataTable table = dao.GetNH(MaNH);
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
    }
}
