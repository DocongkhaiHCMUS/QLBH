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
using QLBH_DTO;

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

        private void btnLapPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rowIndex = gvMain.FocusedRowHandle;
            string      _MaBH        = ((DataTable)gcMain.DataSource).Rows[rowIndex]["MaBH"].ToString()            ;
            DateTime    _NgayLap     = DateTime.Parse(((DataTable)gcMain.DataSource).Rows[rowIndex]["NgayLap"].ToString());
            string      _MaKH        = CNThu==true ?((DataTable)gcMain.DataSource).Rows[rowIndex]["MaKH"].ToString(): ((DataTable)gcMain.DataSource).Rows[rowIndex]["MaNCC"].ToString();
            string      _TenKH       = CNThu == true ? ((DataTable)gcMain.DataSource).Rows[rowIndex]["TenKH"].ToString() : ((DataTable)gcMain.DataSource).Rows[rowIndex]["TenNCC"].ToString();
            decimal     _SoTien      = decimal.Parse(((DataTable)gcMain.DataSource).Rows[rowIndex]["SoTienNo"].ToString());
            decimal     _SoTienTra   = decimal.Parse(((DataTable)gcMain.DataSource).Rows[rowIndex]["SoTienTra"].ToString());
            decimal     _SoTienConNo = decimal.Parse(((DataTable)gcMain.DataSource).Rows[rowIndex]["SoTienConNo"].ToString());
            string      _GhiChu      = ((DataTable)gcMain.DataSource).Rows[rowIndex]["GhiChu"].ToString();

            CCongNo phieu = new CCongNo
            {
                MaBH = _MaBH,
                NgayLap = _NgayLap,
                MaKH = _MaKH,
                TenKH = _TenKH,
                SoTien = _SoTien,
                SoTienTra = _SoTienTra,
                SoTienConNo = _SoTienConNo,
                GhiChu = _GhiChu
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
                gcMain.DataSource = BUS_CongNo.LoadCNThuTraNgay();
            }
            else 
            {
                gcMain.DataSource = BUS_CongNo.LoadCNChiTraNgay();
            }
        }

        private void fCongNoTraNgay_Activated(object sender, EventArgs e)
        {
            if (CNThu == true)
            {
                gcMain.DataSource = BUS_CongNo.LoadCNThuTraNgay();
            }
            else
            {
                gcMain.DataSource = BUS_CongNo.LoadCNChiTraNgay();
            }
        }
    }
}