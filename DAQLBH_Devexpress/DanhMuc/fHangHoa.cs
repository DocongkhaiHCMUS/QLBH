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

namespace DAQLBH_Devexpress
{
    public partial class fHangHoa : fBaseStatic
    {
        public fHangHoa()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            gcMain.DataSource = BUS_HangHoa.LayHangHoa();


            gvMain.Columns[0].FieldName = "Product_ID";
            gvMain.Columns[1].FieldName = "Product_Name";
            gvMain.Columns[2].FieldName = "ProductGroup_Name";
            gvMain.Columns[3].FieldName = "Unit";
            gvMain.Columns[4].FieldName = "Org_Price";
            gvMain.Columns[5].FieldName = "Sale_Price";
            gvMain.Columns[6].FieldName = "Retail_Price";
            gvMain.Columns[7].FieldName = "LimitOrders";
            gvMain.Columns[8].FieldName = "Product_Type_ID";
            gvMain.Columns[9].FieldName = "Stock_ID";
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
        }

        private void GvMain_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}