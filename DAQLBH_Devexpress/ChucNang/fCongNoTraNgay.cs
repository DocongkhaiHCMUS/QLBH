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
using DevExpress.XtraGrid.Views.Grid;
using QLBH_BUS;

namespace DAQLBH_Devexpress.ChucNang
{
    public partial class fCongNoTraNgay : DevExpress.XtraEditors.XtraForm
    {
        bool CNThu = true;
        public fCongNoTraNgay(bool thu = true)
        {
            InitializeComponent();
            CNThu = thu;
            Init();
        }

        private void Init()
        {
            if (CNThu == true)
            {
                gcMain.DataSource = BUS_CongNo.LoadCNThuTraNgay();

                gvMain.Columns[0].FieldName = "MaBH";
                gvMain.Columns[1].FieldName = "NgayLap";
                gvMain.Columns[2].FieldName = "MaKH";
                gvMain.Columns[3].FieldName = "TenKH";
                gvMain.Columns[4].FieldName = "SoTienConNo";
            }
            else
            {
                gcMain.DataSource = BUS_CongNo.LoadCNChiTraNgay();

                gvMain.Columns[0].FieldName = "MaBH";
                gvMain.Columns[1].FieldName = "NgayLap";
                gvMain.Columns[2].FieldName = "MaNCC";
                gvMain.Columns[3].FieldName = "TenNCC";
                gvMain.Columns[4].FieldName = "SoTienConNo";
            }

            gvMain.IndicatorWidth = 50;
            gvMain.CustomDrawRowIndicator += gvMain_CustomDrawRowIndicator;

            gcMain.UseEmbeddedNavigator = true;
            gcMain.EmbeddedNavigator.Buttons.Append.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.Edit.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.Remove.Visible = false;
        }

        private void gvMain_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}