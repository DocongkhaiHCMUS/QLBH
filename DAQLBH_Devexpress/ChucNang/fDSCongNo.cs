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
using QLBH_DTO;

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

                gvMain.Columns[0].FieldName = "MaBH"        ;
                gvMain.Columns[1].FieldName = "NgayLap"     ;
                gvMain.Columns[2].FieldName = "MaNCC"       ;
                gvMain.Columns[3].FieldName = "TenNCC"      ;
                gvMain.Columns[4].FieldName = "SoTienNo"    ;
                gvMain.Columns[5].FieldName = "SoTienTra"   ;
                gvMain.Columns[6].FieldName = "SoTienConNo" ;
                gvMain.Columns[7].FieldName = "GhiChu"      ;

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

        private void btnLapPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rowIndex = gvMain.FocusedRowHandle;
            string      _MaBH        = gvMain.GetRowCellValue(rowIndex, "MaBH").ToString()                                ;
            DateTime    _NgayLap     = DateTime.Parse(gvMain.GetRowCellValue(rowIndex, "NgayLap").ToString())          ;
            string      _MaKH        = CNThu==true ? gvMain.GetRowCellValue(rowIndex, "MaKH").ToString() : gvMain.GetRowCellValue(rowIndex, "MaNCC").ToString();
            string      _TenKH       = CNThu == true ? gvMain.GetRowCellValue(rowIndex, "TenKH").ToString() : gvMain.GetRowCellValue(rowIndex, "TenNCC").ToString();
            decimal     _SoTien      = decimal.Parse(gvMain.GetRowCellValue(rowIndex, "SoTienNo").ToString())           ;
            decimal     _SoTienTra   = decimal.Parse(gvMain.GetRowCellValue(rowIndex, "SoTienTra").ToString())       ;
            decimal     _SoTienConNo = decimal.Parse(gvMain.GetRowCellValue(rowIndex, "SoTienConNo").ToString());
            string      _GhiChu      = gvMain.GetRowCellValue(rowIndex, "GhiChu").ToString();
            CCongNo phieu = new CCongNo
            {
                MaBH        = _MaBH         ,
                NgayLap     = _NgayLap      ,
                MaKH        = _MaKH         ,
                TenKH       = _TenKH        ,
                SoTien      = _SoTien       ,
                SoTienTra   = _SoTienTra    ,
                SoTienConNo = _SoTienConNo  ,
                GhiChu      = _GhiChu
            };

            if (CNThu == true)
            {
                fPhieuTraTien pt = new fPhieuTraTien(true, phieu);
                pt.ShowDialog();
            }
            else
            {
                fPhieuTraTien pt = new fPhieuTraTien(false, phieu);
                pt.ShowDialog();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CNThu == true)
            {
                gcMain.DataSource = BUS_CongNo.LoadCNThu();
            }
            else
            {
                gcMain.DataSource = BUS_CongNo.LoadCNChi();
            }
        }

        private void fDSCongNo_Activated(object sender, EventArgs e)
        {
            if (CNThu == true)
            {
                gcMain.DataSource = BUS_CongNo.LoadCNThu();
            }
            else
            {
                gcMain.DataSource = BUS_CongNo.LoadCNChi();
            }
        }
    }
}