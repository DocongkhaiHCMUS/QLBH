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
using DAQLBH_Devexpress.DanhMuc;
using QLBH_DTO;
using DevExpress.XtraBars;

namespace DAQLBH_Devexpress
{
    public partial class fDonViTinh : fBaseStatic
    {
        public delegate void sendMessage();
        public fDonViTinh()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            QuyenNguoiDung.LayQuyenNguoiDungTheoChucNang("btnDonViTinh");
            if (QuyenNguoiDung.Them == false)
                btnThem.Visibility = BarItemVisibility.Never;
            if (QuyenNguoiDung.Sua == false)
                btnSua.Visibility = BarItemVisibility.Never;
            if (QuyenNguoiDung.Xoa == false)
                btnXoa.Visibility = BarItemVisibility.Never;

            LoadData();

            gvMain.Columns[0].FieldName = "Unit_ID";
            gvMain.Columns[1].FieldName = "Unit_Name";
            gvMain.Columns[2].FieldName = "Description";
            gvMain.Columns[3].FieldName = "Active";

            gvMain.IndicatorWidth = 45;
            gvMain.CustomDrawRowIndicator += GvMain_CustomDrawRowIndicator;

            btnThem.ItemClick += BtnThem_ItemClick;
            btnSua.ItemClick += BtnSua_ItemClick;
            btnXoa.ItemClick += BtnXoa_ItemClick;

            btnLamMoi.ItemClick += BtnLamMoi_ItemClick;
        }

        private void BtnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa ?", "CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No)
                return;
            int rowIndex = gvMain.FocusedRowHandle;
            string colID = "Unit_ID";
            string value = gvMain.GetRowCellValue(rowIndex, colID).ToString();
            if (BUS_DonViTinh.KiemTraDV(value) == true)
            {
                BUS_DonViTinh.XoaDV(value);

                Action.Module = "Đơn Vị Tính";
                Action.ActionName = "Xóa";
                Action.Reference = value;
                Action.LuuThongTin();

                LoadData();
            }
            else
                return;
        }

        private void BtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rowIndex = gvMain.FocusedRowHandle;
            CDonViTinh dv = new CDonViTinh
            {
                MaDV = gvMain.GetRowCellValue(rowIndex, "Unit_ID").ToString(),
                TenDV = gvMain.GetRowCellValue(rowIndex, "Unit_Name").ToString(),
                GhiChu = gvMain.GetRowCellValue(rowIndex, "Description").ToString(),
                ConQL = bool.Parse(gvMain.GetRowCellValue(rowIndex, "Active").ToString())
            };
            fThemSimple sua = new fThemSimple(false, dv, LoadData);
            sua.ShowDialog();
        }

        private void LoadData()
        {
            gcMain.DataSource = BUS_DonViTinh.GetDVT();
        }

        private void BtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fThemSimple themKhuVuc = new fThemSimple(true, null, LoadData,1);
            themKhuVuc.ShowDialog();
        }

        private void GvMain_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}