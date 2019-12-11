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
    public partial class fNhomHang : fBaseStatic
    {
        public delegate void sendMessage();
        public fNhomHang()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            gcMain.DataSource = BUS_HangHoa.LayNhomHang();

            gvMain.Columns[0].FieldName = "ProductGroup_ID";
            gvMain.Columns[1].FieldName = "ProductGroup_Name";
            gvMain.Columns[2].FieldName = "Description";
            gvMain.Columns[3].FieldName = "Active";

            gvMain.IndicatorWidth = 35;
            gvMain.CustomDrawRowIndicator += GvMain_CustomDrawRowIndicator;
        }

        private void GvMain_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}