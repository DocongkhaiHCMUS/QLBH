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

namespace DAQLBH_Devexpress
{
    public partial class fKhoHang : fBaseStatic
    {
        public fKhoHang()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            gcMain.DataSource = BUS_KhoXuat.GetKho();

            gvMain.Columns[0].FieldName = "Stock_ID";
            gvMain.Columns[1].FieldName = "Stock_Name";
            gvMain.Columns[2].FieldName = "Contact";
            gvMain.Columns[3].FieldName = "Address";
            gvMain.Columns[4].FieldName = "Telephone";
            gvMain.Columns[5].FieldName = "Manager";
            gvMain.Columns[6].FieldName = "Description";
            gvMain.Columns[7].FieldName = "Active";

            gvMain.IndicatorWidth = 45;
            gvMain.CustomDrawRowIndicator += GvMain_CustomDrawRowIndicator;
        }

        private void GvMain_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}