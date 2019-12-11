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
using DevExpress.XtraGrid.Columns;

namespace DAQLBH_Devexpress
{
    public partial class fKhachHang : fBaseStatic
    {
        public fKhachHang()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            gcMain.DataSource = BUS_KhachHang.GetKhachHang();
             
            gvMain.Columns[0].FieldName = "Customer_ID";
            gvMain.Columns[1].FieldName = "CustomerName";
            gvMain.Columns[2].FieldName = "Customer_Group_ID";
            gvMain.Columns[3].FieldName = "Contact";
            gvMain.Columns[4].FieldName = "CustomerAddress";
            gvMain.Columns[5].FieldName = "Tel";
            gvMain.Columns[6].FieldName = "Mobile";
            gvMain.Columns[7].FieldName = "Fax";
            gvMain.Columns[8].FieldName = "Email";
            gvMain.Columns[9].FieldName = "Website";
            gvMain.Columns[10].FieldName = "Tax";
            gvMain.Columns[11].FieldName = "BankAccount";
            gvMain.Columns[12].FieldName = "BankName";
            gvMain.Columns[13].FieldName = "Active";

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