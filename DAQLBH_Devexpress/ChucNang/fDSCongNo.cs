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
using DevExpress.XtraGrid;

namespace DAQLBH_Devexpress.ChucNang
{
    public partial class fDSCongNo : DevExpress.XtraEditors.XtraForm
    {
        bool CNThu = true;
        
        public fDSCongNo(bool thu = true)
        {
            InitializeComponent();
            CNThu = thu;
            Init();
        }

        private void Init()
        {
            if (CNThu == true)
            {
                gcMain.DataSource = BUS_CongNo.LoadCNThu();

                gvMain.Columns[0].FieldName = "MaBH";
                gvMain.Columns[1].FieldName = "NgayLap";
                gvMain.Columns[2].FieldName = "MaKH";
                gvMain.Columns[3].FieldName = "TenKH";
                gvMain.Columns[4].FieldName = "SoTienNo";
                gvMain.Columns[5].FieldName = "SoTienTra";
                gvMain.Columns[6].FieldName = "SoTienConNo";
                gvMain.Columns[7].FieldName = "GhiChu";

                Text = "Danh Sách Công Nợ Chi Tiết";
            }
            else
            {
                gcMain.DataSource = BUS_CongNo.LoadCNChi();

                gvMain.Columns[0].FieldName = "MaBH";
                gvMain.Columns[1].FieldName = "NgayLap";
                gvMain.Columns[2].FieldName = "MaNCC";
                gvMain.Columns[3].FieldName = "TenNCC";
                gvMain.Columns[4].FieldName = "SoTienNo";
                gvMain.Columns[5].FieldName = "SoTienTra";
                gvMain.Columns[6].FieldName = "SoTienConNo";
                gvMain.Columns[7].FieldName = "GhiChu";

                gvMain.Columns[2].Caption = "Mã NCC";
                gvMain.Columns[3].Caption = "Nhà Cung Cấp";

                Text = "Danh Sách Công Nợ Phải Chi";
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
            Close();

        }
    }
}