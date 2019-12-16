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

namespace DAQLBH_Devexpress.DanhMuc
{
    public partial class fLichSuGiaoDich : DevExpress.XtraEditors.XtraForm
    {
        public fLichSuGiaoDich()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            gcMain.DataSource = BUS_KhoXuat.GetTonKhoLookup();
            gvMain.BestFitColumns();

            gvMain.Columns[0].FieldName     = "RefDate"               ;
            gvMain.Columns[1].FieldName     = "RefNo"                   ;
            gvMain.Columns[2].FieldName     = "RefType"                 ;
            gvMain.Columns[3].FieldName     = "Stock_ID"                ;
            gvMain.Columns[4].FieldName     = "Product_ID"              ;
            gvMain.Columns[5].FieldName     = "Product_Name"            ;
            gvMain.Columns[6].FieldName     = "Unit"                    ;
            gvMain.Columns[7].FieldName     = "Quantity"                ;
            gvMain.Columns[8].FieldName     = "Price"                   ;
            gvMain.Columns[9].FieldName     = "Price"                   ;
            gvMain.Columns[10].FieldName    = "UnitPrice"               ;
            gvMain.Columns[11].FieldName    = "Amount"                  ;
            gvMain.Columns[12].FieldName    = "E_Qty"                   ;
            gvMain.Columns[13].FieldName    = "E_Amt"                   ;
            gvMain.Columns[14].FieldName    = "Description"             ;

            gvMain.IndicatorWidth = 45;
            gvMain.CustomDrawRowIndicator += GvMain_CustomDrawRowIndicator;
        }

        private void GvMain_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            
        }
    }
}