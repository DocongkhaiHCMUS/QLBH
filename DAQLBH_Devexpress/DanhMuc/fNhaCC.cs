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
using DevExpress.XtraGrid.Columns;

namespace DAQLBH_Devexpress
{
    public partial class fNhaCC : fBaseStatic
    {
        public fNhaCC()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            InitColumns();
            gcMain.DataSource = BUS_NhaCungCap.GetNhaCC();

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

        private void GvMain_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        /// <summary>
        /// Binding các columns với FileName của DataSource
        /// </summary>
        private void InitColumns()
        {
            gvMain.Columns[0].FieldName = "Customer_ID";
            gvMain.Columns[1].FieldName = "CustomerName";
            gvMain.Columns[2].FieldName = "Customer_Group_ID";
            gvMain.Columns[3].FieldName = "Contact";
            gvMain.Columns[4].FieldName = "Position";
            gvMain.Columns[5].FieldName = "CustomerAddress";
            gvMain.Columns[6].FieldName = "Tel";
            gvMain.Columns[7].FieldName = "Mobile";
            gvMain.Columns[8].FieldName = "Fax";
            gvMain.Columns[9].FieldName = "Active";
        }
    }
}