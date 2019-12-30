using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBH_BUS;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using DAQLBH_Devexpress.DanhMuc;
using QLBH_DTO;

namespace DAQLBH_Devexpress
{
    public partial class fHangHoa : fBaseStatic
    {
        public delegate void sendMessage();
        public fHangHoa()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            QuyenNguoiDung.LayQuyenNguoiDungTheoChucNang("btnHangHoa");
            if (QuyenNguoiDung.Them == false)
                btnThem.Visibility = BarItemVisibility.Never;
            if (QuyenNguoiDung.Sua == false)
                btnSua.Visibility = BarItemVisibility.Never;
            if (QuyenNguoiDung.Xoa == false)
                btnXoa.Visibility = BarItemVisibility.Never;

            LoadData();

            gvMain.Columns[0].FieldName = "Product_ID";
            gvMain.Columns[1].FieldName = "Product_Name";
            gvMain.Columns[2].FieldName = "ProductGroup_Name";
            gvMain.Columns[3].FieldName = "Unit";
            gvMain.Columns[4].FieldName = "Org_Price";
            gvMain.Columns[5].FieldName = "Sale_Price";
            gvMain.Columns[6].FieldName = "Retail_Price";
            gvMain.Columns[7].FieldName = "LimitOrders";
            gvMain.Columns[8].FieldName = "Product_Type_ID";
            gvMain.Columns[9].FieldName = "Stock_Name";
            gvMain.Columns[10].FieldName = "Active";

            gcMain.UseEmbeddedNavigator = true;
            gcMain.EmbeddedNavigator.Buttons.Append.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.Edit.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gvMain.Columns[2].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            gvMain.OptionsBehavior.AutoExpandAllGroups = true;

            gvMain.IndicatorWidth = 45;
            gvMain.CustomDrawRowIndicator += GvMain_CustomDrawRowIndicator;

            btnLamMoi.ItemClick += BtnLamMoi_ItemClick;

            btnThem.ItemClick += BtnThem_ItemClick;
            btnSua.ItemClick += BtnSua_ItemClick;
            btnXoa.ItemClick += BtnXoa_ItemClick;
        }

        private void BtnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa ?", "CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No)
                return;
            int rowIndex = gvMain.FocusedRowHandle;
            string colID = "Product_ID";
            string value = gvMain.GetRowCellValue(rowIndex, colID).ToString();
            if (BUS_HangHoa.KiemTraHH(value) == true)
            {
                BUS_HangHoa.XoaHH(value);

                Action.Module = "Hàng Hóa";
                Action.ActionName = "Xóa";
                Action.Reference = value;
                Action.LuuThongTin();

                LoadData();
            }
            else
                return;
        }

        private void BtnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            int rowIndex = gvMain.FocusedRowHandle;
            DataRow fHH = BUS_HangHoa.TimHH(gvMain.GetRowCellValue(rowIndex, "Product_ID").ToString());
            string    _Product_ID            = fHH.Field<string>(    "Product_ID"     )           ;
            string    _Product_Name          = fHH.Field<string>(    "Product_Name"     )           ;
            int    _Product_Type_ID          = fHH.Field<int>("Product_Type_ID")           ;
            string    _Product_Group_ID      = fHH.Field<string>(    "Product_Group_ID"     )           ;
            string    _Provider_ID           = fHH.Field<string>(    "Provider_ID"     )           ;
            string    _Unit                  = fHH.Field<string>(    "Unit"     )           ;
            string    _Photo                 = fHH.Field<string>(  "_Photo"     )           ;
            decimal     _Org_Price             = fHH.Field<decimal>(    "Org_Price"     )           ;
            decimal _Sale_Price             = fHH.Field<decimal>(    "Sale_Price"     )           ;
            decimal _Retail_Price           = fHH.Field<decimal>(    "Retail_Price"     )           ;
            string    _Customer_ID           = fHH.Field<string>(    "Customer_ID"     )           ;
            string    _Customer_Name         = fHH.Field<string>(      "Customer_Name"     )           ;
            decimal       _MinStock              = fHH.Field<decimal>(    "MinStock"     )           ;
            bool      _Active               = fHH.Field<bool>(      "Active"     )           ;
            CHangHoa hh = new CHangHoa
            {
                Product_ID               = _Product_ID                   ,
                Product_Name             = _Product_Name                 ,
                Product_Type_ID          = _Product_Type_ID              ,
                Product_Group_ID         = _Product_Group_ID             ,
                Provider_ID              = _Provider_ID                  ,
                Unit                     = _Unit                         ,
                Photo                    = _Photo==null?"":_Photo        ,
                Org_Price                = float.Parse(_Org_Price.ToString())    ,
                Sale_Price               = float.Parse(_Sale_Price.ToString()),
                Retail_Price             = float.Parse(_Retail_Price.ToString()),
                Customer_ID              = _Customer_ID                  ,
                Customer_Name            = _Customer_Name                ,
                MinStock                 = (int)_MinStock                     ,
                Active                   = _Active
            };
            fThemHangHoa sua = new fThemHangHoa(false, hh, LoadData);
            sua.ShowDialog();
        }

        private void BtnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            fThemHangHoa kho = new fThemHangHoa(true, null, LoadData);
            kho.ShowDialog();
        }

        private void BtnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            gcMain.DataSource = BUS_HangHoa.LayHangHoa();
        }

        private void GvMain_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}