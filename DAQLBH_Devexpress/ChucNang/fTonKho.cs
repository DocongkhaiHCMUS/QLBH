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

namespace DAQLBH_Devexpress.ChucNang
{
    public partial class fTonKho : fBaseStatic
    {
        public fTonKho()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            gcMain.DataSource = BUS_HangHoa.LayHangHoaLookupEdit();

            gvMain.Columns[0].FieldName = "Product_ID"             ;
            gvMain.Columns[1].FieldName = "Product_Name"           ;
            gvMain.Columns[4].FieldName = "Quantity"               ;
            gvMain.Columns[2].FieldName = "Stock_Name"             ;
            gvMain.Columns[3].FieldName = "Unit"                   ;
            gvMain.Columns[5].FieldName = "Product_Group_ID"     ;
            gvMain.Columns[6].FieldName = "Active";

            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            gcMain.UseEmbeddedNavigator = true;
            gcMain.EmbeddedNavigator.Buttons.Append.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.Edit.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.Remove.Visible = false;

            gvMain.IndicatorWidth = 45;
            gvMain.CustomDrawRowIndicator += GvMain_CustomDrawRowIndicator;

            btnLamMoi.ItemClick += BtnLamMoi_ItemClick;
        }

        private void GvMain_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void BtnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gcMain.DataSource = BUS_HangHoa.LayHangHoaLookupEdit();
        }
    }
}