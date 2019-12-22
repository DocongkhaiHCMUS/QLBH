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
    public class BUS_KhoXuat
    {
        public static DataTable LayKho()
        {
            try
            {
                Kho dao = new Kho();
                return dao.LoadKhoHang();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public static DataTable LayKhoDonGian()
        {
            try
            {
                Kho  dao = new Kho();
                return dao.LoadKhoHangDonGian();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool KiemTraKho(string maKho)
        {
            try
            {
                Kho dao = new Kho();
                DataTable table = dao.GetKho(maKho);
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

        public static void ThemKho(CKho kho)
        {
            try
            {
                Kho dao = new Kho();
                dao.ThemKho(kho);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void SuaKho(CKho kho)
        {
            try
            {
                Kho dao = new Kho();
                dao.SuaKho(kho);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void XoaKho(string MaKho)
        {
            try
            {
                Kho dao = new Kho();
                dao.XoaKho(MaKho);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        //Tồn Kho
        public static DataTable GetTonKhoLookup()
        {
            try
            {
                DonViTinh dv = new DonViTinh();
                Kho k = new Kho();
                DataTable dataTableTonKho = k.LayTonKhoLookUp();
                DataTable dataTableDV = dv.LoadDVTDonGian();
                DataTable dataTableKho = k.LoadKhoHang();
                DataTable dataTableHD = k.GetHanhDong();

                var results = from table1 in dataTableTonKho.AsEnumerable()
                              join table2 in dataTableDV.AsEnumerable() on (string)table1["Unit"] equals (string)table2["UNIT_ID"]
                              join table3 in dataTableKho.AsEnumerable() on (string)table1["Stock_ID"] equals (string)table3["Stock_ID"]
                              join table4 in dataTableHD.AsEnumerable() on (int)table1["RefType"] equals (int)table4["Action_ID"]
                              select new
                              {
                                    RefDate        =  DateTime.Parse(table1["RefDate"].ToString()),
                                    RefNo          =  table1["RefNo"].ToString()       ,
                                    RefType        =  table4["Action_Name"].ToString()       ,
                                    Stock_ID       =  table3["Stock_Name"].ToString()       ,
                                    Product_ID     =  table1["Product_ID"].ToString()       ,
                                    Product_Name   =  table1["Product_Name"].ToString()       ,
                                    Unit           =  table2["Unit_Name"].ToString()       ,
                                    Quantity       =  float.Parse(table1["Quantity"].ToString())       ,
                                    Price          =  float.Parse(table1["Price"].ToString())       ,
                                    UnitPrice      = float.Parse(table1["UnitPrice"].ToString())       ,
                                    Amount         = float.Parse(table1["Amount"].ToString())       ,
                                    E_Qty          =  float.Parse(table1["E_Qty"].ToString())       ,
                                    E_Amt          = float.Parse(table1["E_Amt"].ToString())     ,
                                    Description    =  table1["Description"].ToString()       
                              };

                DataTable rs = new DataTable();
                rs.Columns.Add("RefDate"      );
                rs.Columns.Add("RefNo"        );
                rs.Columns.Add("RefType"      );
                rs.Columns.Add("Stock_ID"     );
                rs.Columns.Add("Product_ID"   );
                rs.Columns.Add("Product_Name" );
                rs.Columns.Add("Unit"         );
                rs.Columns.Add("Quantity"     );
                rs.Columns.Add("Price"        );
                rs.Columns.Add("UnitPrice"    );
                rs.Columns.Add("Amount"       );
                rs.Columns.Add("E_Qty"          );
                rs.Columns.Add("E_Amt"          );
                rs.Columns.Add("Description"    );

                foreach (var item in results)
                {               
                    rs.Rows.Add
                        (
                            item.RefDate       ,
                            item.RefNo         ,
                            item.RefType       ,
                            item.Stock_ID      ,
                            item.Product_ID    ,
                            item.Product_Name  ,
                            item.Unit          ,
                            item.Quantity      ,
                            item.Price         ,
                            item.UnitPrice     ,
                            item.Amount        ,
                            item.E_Qty         ,
                            item.E_Amt         ,
                            item.Description
                        );
                }

                return rs;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static DataTable layHanhDongTonKho()
        {
            try
            {
                Kho dao = new Kho();
                return dao.GetHanhDong();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public static int getMaxID()
        {
            try
            {
                Kho dao = new Kho();
                return dao.GetMaxID();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        //Bán hàng

        public static DataTable LayChungTuBH()
        {
            try
            {
                Kho dao = new Kho();
                DataTable dataTableCT = dao.ChitietChungTuBH();
                DonViTinh dv = new DonViTinh();
                DataTable dataTableDV = dv.LoadDVTDonGian();
                DataTable dataTableKho = dao.LoadKhoHang();
                DataTable dataTableBH = dao.LayChungTuBH();

                var results = from table1 in dataTableCT.AsEnumerable()
                              join table2 in dataTableDV.AsEnumerable() on (string)table1["Unit"] equals (string)table2["UNIT_ID"]
                              join table3 in dataTableKho.AsEnumerable() on (string)table1["Stock_ID"] equals (string)table3["Stock_ID"]
                              join table4 in dataTableBH.AsEnumerable() on (string)table1["Outward_ID"] equals(string)table4["ID"]
                              select new
                              {
                                  Outward_ID   = table1["Outward_ID"].ToString(),
                                  RefDate      = DateTime.Parse(table4["RefDate"].ToString()),
                                  Description  = table1["Description"].ToString(),
                                  Product_ID   = table1["Product_ID"].ToString(),
                                  ProductName  = table1["ProductName"].ToString(),
                                  Stock_ID     = table3["Stock_Name"].ToString(),
                                  Unit         = table2["Unit_Name"].ToString(),
                                  Quantity     = float.Parse(table1["Quantity"].ToString()),
                                  UnitPrice    = float.Parse(table1["UnitPrice"].ToString()),
                                  Charge       = float.Parse(table1["Charge"].ToString()),
                                  DiscountRate = float.Parse(table1["DiscountRate"].ToString()),
                                  Discount     = float.Parse(table1["Discount"].ToString()),
                                  Amount       = float.Parse(table1["Amount"].ToString())

                              };

                DataTable rs = new DataTable();
                rs.Columns.Add("Outward_ID"    );
                rs.Columns.Add("RefDate"       );
                rs.Columns.Add("Description"   );
                rs.Columns.Add("Product_ID"    );
                rs.Columns.Add("ProductName"   );
                rs.Columns.Add("Stock_ID"      );
                rs.Columns.Add("Unit"          );
                rs.Columns.Add("Quantity"      ,typeof(float));
                rs.Columns.Add("UnitPrice", typeof(float));
                rs.Columns.Add("Charge", typeof(float));
                rs.Columns.Add("DiscountRate", typeof(float));
                rs.Columns.Add("Discount", typeof(float));
                rs.Columns.Add("Amount", typeof(float));

                foreach (var item in results)
                {
                    rs.Rows.Add(item.Outward_ID,item.RefDate,item.Description,item.Product_ID,item.ProductName,item.Stock_ID,item.Unit,
                                item.Quantity,item.UnitPrice,item.Charge,item.DiscountRate,item.Discount,item.Amount);
                }
                return rs;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static DataTable TimBH(string MaBH)
        {
            try
            {
                Kho dao = new Kho();
                DataTable table = dao.GetChitietChungTuBH(MaBH);
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ThemBH(List<CBanHang> bh)
        {
            try
            {
                Kho dao = new Kho();
                dao.ThemBanHang(bh);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void SuaBH(List<CBanHang> bh)
        {
            try
            {
                Kho dao = new Kho();
                dao.SuaBH(bh);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void XoaBH(string MaBH)
        {
            try
            {
                Kho dao = new Kho();
                dao.XoaBH(MaBH);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
